using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia.Controls;
using Avalonia.CustomControls.SnowflakesControlSample.Models;
using Avalonia.Media;
using Avalonia.Rendering;
using Avalonia.Threading;

namespace Avalonia.CustomControls.SnowflakesControlSample.Controls;

/// <summary>
/// </summary>
public class SnowflakeControl : Control, ICustomHitTest
{
    #region Private Fields

    /// <summary>
    ///     计算两次渲染帧之间消耗的时间，每次渲染之后都会重置
    /// </summary>
    private readonly Stopwatch _stopwatch = new();

    #endregion

    #region Constructors

    static SnowflakeControl()
    {
        // 这个方法会在指定的所有 AvaloniaProperty 都发生变化时，重新渲染控件
        AffectsRender<SnowflakeControl>(IsRunningProperty, SnowflakesProperty, ScoreProperty);
    }

    #endregion

    #region Protected Methods

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property != IsRunningProperty) return;

        // 游戏开始 / 停止运行的时候，要重置/停止计时器
        if (change.GetNewValue<bool>())
        {
            _stopwatch.Restart();
            return;
        }

        _stopwatch.Stop();
    }

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public bool HitTest(Point point)
    {
        if (!IsRunning) return false;

        var snowflake = Snowflakes.FirstOrDefault(x => x.IsHit(point, Bounds));
        if (snowflake is null) return false;

        // 点中了某个雪花，从列表中移除，并计算分数
        Snowflakes.Remove(snowflake);
        Score += snowflake.GetHitScore();
        return true;
    }

    /// <inheritdoc />
    public override void Render(DrawingContext context)
    {
        // 重写这个方法，可以自定义绘制逻辑
        var elapsedMs = _stopwatch.Elapsed.TotalMilliseconds;
        foreach (var snowflake in Snowflakes)
        {
            if (IsRunning) snowflake.Move(elapsedMs);

            context.DrawEllipse(
                Brushes.White,
                null,
                snowflake.GetCenterForViewport(Bounds),
                snowflake.Radius,
                snowflake.Radius
            );
        }

        base.Render(context);

        if (!IsRunning) return;

        // 请求下一帧，使用 Background 模式，避免 UI 线程卡顿
        Dispatcher.UIThread.Post(InvalidateVisual, DispatcherPriority.Background);
        _stopwatch.Restart();
    }

    #endregion

    #region Direct Properties

    private IList<Snowflake> _snowFlakes = [];

    /// <summary>
    ///     用于渲染的雪花列表
    /// </summary>
    public IList<Snowflake> Snowflakes
    {
        get => _snowFlakes;
        set => SetAndRaise(SnowflakesProperty, ref _snowFlakes, value);
    }

    public static readonly DirectProperty<SnowflakeControl, IList<Snowflake>> SnowflakesProperty =
        AvaloniaProperty.RegisterDirect<SnowflakeControl, IList<Snowflake>>(
            nameof(Snowflakes),
            o => o.Snowflakes,
            (o, v) => o.Snowflakes = v
        );

    private double _score;

    /// <summary>
    ///     分数
    /// </summary>
    public double Score
    {
        get => _score;
        set => SetAndRaise(ScoreProperty, ref _score, value);
    }

    public static readonly DirectProperty<SnowflakeControl, double> ScoreProperty =
        AvaloniaProperty.RegisterDirect<SnowflakeControl, double>(
            nameof(Score),
            o => o.Score,
            (o, v) => o.Score = v
        );

    #endregion

    #region Styled Properties

    /// <summary>
    ///     游戏是否正在运行
    /// </summary>
    public bool IsRunning
    {
        get => GetValue(IsRunningProperty);
        set => SetValue(IsRunningProperty, value);
    }

    public static readonly StyledProperty<bool> IsRunningProperty =
        AvaloniaProperty.Register<SnowflakeControl, bool>(nameof(IsRunning));

    #endregion
}