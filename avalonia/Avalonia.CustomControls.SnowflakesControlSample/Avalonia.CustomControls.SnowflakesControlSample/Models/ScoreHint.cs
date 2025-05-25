using System;
using System.Collections.Generic;

namespace Avalonia.CustomControls.SnowflakesControlSample.Models;

/// <summary>
///     雪花得分提示
/// </summary>
internal class ScoreHint
{
    #region Constructors

    internal ScoreHint(Snowflake snowflake, ICollection<ScoreHint> scoreHints)
    {
        Score = snowflake.GetHitScore();
        X = snowflake.X;
        Y = snowflake.Y;
        Opacity = 1.0;
        _scoreHints = scoreHints;
    }

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public override string ToString()
    {
        return $"+{Score:N0}";
    }

    #endregion

    #region Internal Methods

    /// <summary>
    ///     获取提示框左上角的坐标
    /// </summary>
    /// <param name="viewport">显示区域</param>
    /// <param name="textSize">文本尺寸</param>
    /// <returns>坐标</returns>
    internal Point GetTopLeftForViewport(Rect viewport, Size textSize)
    {
        var left = X * viewport.Width + viewport.Left - textSize.Width / 2.0;
        var top = X * viewport.Height + viewport.Top - textSize.Height;

        if (left < 0) left = 0;
        if (top < 0) top = 0;
        if (left + textSize.Width > viewport.Width) left = viewport.Width - textSize.Width;

        return new Point(left, top);
    }

    /// <summary>
    ///     更新当前项和垂直坐标
    /// </summary>
    /// <param name="elapsedMs">耗时，单位：毫秒</param>
    internal void Update(double elapsedMs)
    {
        _elapsedMsTotal += elapsedMs;

        switch (_elapsedMsTotal)
        {
            case >= 1000:
                _scoreHints.Remove(this);
                break;
            case > 500:
                var percentage = (_elapsedMsTotal - 500) / 500;
                Opacity = Math.Max(1.0 - percentage, 0);
                Y -= 0.01 * percentage;
                return;
            default:
                return;
        }
    }

    #endregion

    #region Internal Properties

    /// <summary>
    ///     鼠标点中雪花时显示的分数
    /// </summary>
    internal int Score { get; }

    /// <summary>
    ///     水平坐标
    /// </summary>
    internal double X { get; }

    /// <summary>
    ///     垂直坐标
    /// </summary>
    internal double Y { get; private set; }

    /// <summary>
    ///     不透明度
    /// </summary>
    internal double Opacity { get; private set; }

    #endregion

    #region Private Fields

    private double _elapsedMsTotal;

    private readonly ICollection<ScoreHint> _scoreHints;

    #endregion
}