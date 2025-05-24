namespace Avalonia.CustomControls.SnowflakesControlSample.Models;

/// <summary>
///     雪花 Model，用于控制雪花的坐标、速度等
///     <remarks>属性单位均使用相对单位，用于适配不同的尺寸</remarks>
/// </summary>
public class Snowflake(double x, double y, double diameter, double speed)
{
    /// <summary>
    ///     水平坐标
    /// </summary>
    public double X { get; set; } = x;

    /// <summary>
    ///     垂直坐标
    /// </summary>
    public double Y { get; set; } = y;

    /// <summary>
    ///     直径，单位：px
    /// </summary>
    public double Diameter { get; set; } = diameter;

    /// <summary>
    ///     半径，单位：px
    /// </summary>
    public double Radius { get; set; } = diameter / 2.0;

    /// <summary>
    ///     每秒落下的速度
    /// </summary>
    public double Speed { get; set; } = speed;

    /// <summary>
    ///     获取雪花在视图中的中心点
    /// </summary>
    /// <param name="viewport">视图尺寸</param>
    /// <returns>中心点坐标</returns>
    public Point GetCenterForViewport(Rect viewport)
    {
        return new Point(X * viewport.Width + viewport.Left, Y * viewport.Height + viewport.Top);
    }

    /// <summary>
    ///     移动雪花
    /// </summary>
    /// <param name="elapsedMs">移动时间，单位：毫秒</param>
    public void Move(double elapsedMs)
    {
        Y += elapsedMs * Speed / 1000.0;
        if (Y > 1) Y = 0;
    }

    /// <summary>
    ///     判断点是否在雪花范围内
    /// </summary>
    /// <param name="point">点</param>
    /// <param name="viewport">视图尺寸</param>
    /// <returns>是否在雪花范围内</returns>
    public bool IsHit(Point point, Rect viewport)
    {
        var distance = ((Vector)GetCenterForViewport(viewport) - point).Length;
        return distance <= Radius;
    }

    /// <summary>
    ///     获取分数
    /// </summary>
    /// <returns>分数</returns>
    public int GetHitScore()
    {
        // 雪花越小、越快，得分就越高。
        return (int)(1 / Radius * 200 + Speed / 10.0);
    }
}