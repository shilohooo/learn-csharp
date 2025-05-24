using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia.CustomControls.SnowflakesControlSample.Models;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.CustomControls.SnowflakesControlSample.ViewModels;

/// <summary>
/// </summary>
public partial class SnowflakeGameViewModel : ViewModelBase
{
    #region Constructors

    public SnowflakeGameViewModel()
    {
        // 每 100 毫秒运行一次计时器，且设置为后台运行，运行之后会调用指定的 OnGameTimerTick 方法
        _gameTimer =
            new DispatcherTimer(TimeSpan.FromMicroseconds(100), DispatcherPriority.Background, OnGameTimerTick);
    }

    #endregion

    #region Commands

    /// <summary>
    ///     启动游戏
    /// </summary>
    [RelayCommand]
    private void StartGame()
    {
        Debug.WriteLine("start game");
        // 清除雪花和分数
        Snowflakes.Clear();
        Score = 0;

        // 创建随机数量的雪花
        for (var i = 0; i < 200; i++)
            Snowflakes.Add(new Snowflake(
                Random.Shared.NextDouble(),
                Random.Shared.NextDouble(),
                Random.Shared.NextDouble() * 5 + 2,
                Random.Shared.NextDouble() / 5 + 0.1
            ));

        // 设置游戏总时长
        GameDuration = TimeSpan.FromMinutes(1);
        IsGameRunning = true;

        // 启动计时器
        _stopwatch.Restart();
        _gameTimer.Start();
    }

    #endregion

    #region Private Methods

    /// <summary>
    ///     计时器触发回调
    /// </summary>
    /// <param name="sender">触发时间的对象</param>
    /// <param name="e">事件参数</param>
    private void OnGameTimerTick(object? sender, EventArgs e)
    {
        Debug.WriteLine("OnGameTimerTick");

        OnPropertyChanged(nameof(RemainingMs));

        if (RemainingMs > 0) return;

        _gameTimer.Stop();
        _stopwatch.Stop();
        IsGameRunning = false;
    }

    #endregion

    #region Private Fields

    /// <summary>
    ///     每 100 毫秒更新一次游戏状态
    /// </summary>
    private readonly DispatcherTimer _gameTimer;

    /// <summary>
    ///     计算游戏运行时间，游戏结束后需要重置
    /// </summary>
    private readonly Stopwatch _stopwatch = new();

    /// <summary>
    ///     游戏是否正在运行
    /// </summary>
    [ObservableProperty] private bool _isGameRunning;

    /// <summary>
    ///     分数
    /// </summary>
    [ObservableProperty] private double _score;

    /// <summary>
    ///     游戏时长
    /// </summary>
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(GameDurationMs))]
    private TimeSpan _gameDuration;

    #endregion

    #region Public Properties

    /// <summary>
    ///     雪花列表
    /// </summary>
    public ObservableCollection<Snowflake> Snowflakes { get; set; } = [];

    /// <summary>
    ///     游戏时长（毫秒）
    /// </summary>
    public double GameDurationMs => GameDuration.TotalMilliseconds;

    /// <summary>
    ///     剩余时间（毫秒）
    /// </summary>
    public double RemainingMs => (GameDuration - _stopwatch.Elapsed).TotalMilliseconds;

    #endregion
}