using System;
using System.Linq;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;
using SkiaSharp;

namespace Avalonia.CustomControls.SnowflakesControlSample.Controls;

/// <summary>
///     自定义渲染用户的分数
/// </summary>
internal class ScoreRenderer(Rect bounds, string text) : ICustomDrawOperation
{
    #region Private Properties

    private string Text { get; } = text;

    #endregion

    #region Public Properties

    /// <inheritdoc />
    public Rect Bounds { get; } = bounds;

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public bool Equals(ICustomDrawOperation? other)
    {
        // 当前示例无需使用该方法
        return false;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // 可以在这里释放资源
    }

    /// <inheritdoc />
    public bool HitTest(Point p)
    {
        // 该控件不需要 HitTest，即不需要处理点击事件
        return false;
    }

    /// <inheritdoc />
    public void Render(ImmediateDrawingContext context)
    {
        // 实现控件渲染逻辑

        var leaseFeature = context.TryGetFeature<ISkiaSharpApiLeaseFeature>();
        // 获取不到  SkiaSharpApiLeaseFeature 时，使用 GlyphRun 绘制
        if (leaseFeature is null)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var glyphs = Text.Select(c => Typeface.Default.GlyphTypeface.GetGlyph(c)).ToArray();
#pragma warning restore CS0618 // Type or member is obsolete
            var glyphRun = new GlyphRun(
                Typeface.Default.GlyphTypeface,
                20,
                Text.AsMemory(),
                glyphs,
                Bounds.TopRight - new Point(50, 50)
            );
            context.DrawGlyphRun(Brushes.Goldenrod, glyphRun.TryCreateImmutableGlyphRunReference()!);
            return;
        }

        // 使用 canvas 绘制文本
        using var lease = leaseFeature.Lease();
        var canvas = lease.SkCanvas;
        canvas.Save();

        // 设置文本的样式
        using var paint = new SKPaint();
        paint.Shader = SKShader.CreateColor(SKColors.Goldenrod);
        paint.TextSize = 30;
        paint.TextAlign = SKTextAlign.Right;

        var origin = Bounds.TopRight.ToSKPoint();
        origin.Offset(-25, +50);

        paint.ImageFilter = SKImageFilter.CreateDropShadow(0, 0, 10, 10, SKColors.White);
        canvas.DrawText(Text, origin, paint);
    }

    #endregion
}