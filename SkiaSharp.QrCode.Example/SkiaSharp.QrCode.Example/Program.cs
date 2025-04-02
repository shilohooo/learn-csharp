using SkiaSharp;
using SkiaSharp.QrCode;

const string qrContent = "https://github.com";
const string text = "扫描访问网站，这是一个很长的文字需要换行显示";
const string outputPath = @"D:\qrcode_with_text.png";
const int qrSize = 300;
const int textSpace = 150;
const float textSize = 24;
const float lineSpacing = 10;

const int totalHeight = qrSize + textSpace;

// 创建画布
var imageInfo = new SKImageInfo(qrSize, totalHeight);
using var surface = SKSurface.Create(imageInfo);
var canvas = surface.Canvas;

// 清空画布为白色背景
canvas.Clear(SKColors.White);

// 生成二维码
var qrGenerator = new QRCodeGenerator();
var qrCode = qrGenerator.CreateQrCode(qrContent, ECCLevel.M);

// 创建二维码位图
using var qrBitmap = new SKBitmap(qrSize, qrSize);
using var qrCanvas = new SKCanvas(qrBitmap);
qrCanvas.Clear(SKColors.White); // 背景色

// 获取矩阵并处理 List<BitArray>
var moduleMatrix = qrCode.ModuleMatrix;
var matrixSize = moduleMatrix.Count; // 获取行数
var scale = (float)qrSize / matrixSize; // 计算每个模块的像素大小
for (var y = 0; y < matrixSize; y++)
{
    var row = moduleMatrix[y]; // 获取当前行的 BitArray
    for (var x = 0; x < row.Length; x++) // 使用 BitArray 的 Length 获取列数
    {
        if (row[x]) // 访问 BitArray 中的布尔值
        {
            var rect = SKRect.Create(x * scale, y * scale, scale, scale);
            qrCanvas.DrawRect(rect, new SKPaint { Color = SKColors.Black });
        }
    }
}

// 将二维码绘制到主画布
canvas.DrawBitmap(qrBitmap, 0, 0);

// 加载支持中文的字体
SKTypeface typeface;
try
{
    typeface = SKTypeface.FromFamilyName(
        "Microsoft YaHei",
        SKFontStyleWeight.Normal,
        SKFontStyleWidth.Normal,
        SKFontStyleSlant.Upright
    );

    if (typeface == null)
    {
        typeface = SKTypeface.FromFamilyName(
            "PingFang SC",
            SKFontStyleWeight.Normal,
            SKFontStyleWidth.Normal,
            SKFontStyleSlant.Upright
        );
    }

    if (typeface == null)
    {
        typeface = SKTypeface.FromFamilyName(
            "Noto Sans CJK SC",
            SKFontStyleWeight.Normal,
            SKFontStyleWidth.Normal,
            SKFontStyleSlant.Upright
        );
    }

    if (typeface == null)
    {
        typeface = SKTypeface.Default;
        Console.WriteLine("警告：未找到支持中文的字体，可能会出现乱码。");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"字体加载失败: {ex.Message}");
    throw;
}

// 设置文字样式
using var textPaint = new SKPaint();
textPaint.Color = SKColors.Black;
textPaint.IsAntialias = true;
textPaint.Style = SKPaintStyle.Fill;
textPaint.TextAlign = SKTextAlign.Center;
textPaint.TextSize = textSize;
textPaint.Typeface = typeface;

// 换行处理
var maxWidth = qrSize - 20;
var lines = new List<string>();
var currentLine = "";
var textToProcess = text;

while (textToProcess.Length > 0)
{
    var nextChar = textToProcess[0];
    var testLine = currentLine + nextChar;
    var testBounds = new SKRect();
    textPaint.MeasureText(testLine, ref testBounds);

    if (testBounds.Width <= maxWidth)
    {
        currentLine = testLine;
        textToProcess = textToProcess.Substring(1);
    }
    else
    {
        if (currentLine.Length > 0)
        {
            lines.Add(currentLine);
        }

        currentLine = nextChar.ToString();
        textToProcess = textToProcess.Substring(1);
    }
}

if (currentLine.Length > 0)
{
    lines.Add(currentLine);
}

// 计算文字总高度
var lineHeight = textPaint.FontSpacing;
var totalTextHeight = lines.Count * (lineHeight + lineSpacing) - lineSpacing;

// 计算起始 Y 坐标（居中对齐）
var textStartY = qrSize + (textSpace - totalTextHeight) / 2;

// 绘制每一行文字
for (var i = 0; i < lines.Count; i++)
{
    var line = lines[i];
    var textX = qrSize / 2f;
    var textY = textStartY + i * (lineHeight + lineSpacing);
    canvas.DrawText(line, textX, textY, textPaint);
}

// 保存图片
using var image = surface.Snapshot();
using var encodedData = image.Encode(SKEncodedImageFormat.Png, 100);

// 将图片保存到文件（可选）
await using var fileStream = File.OpenWrite(outputPath);
encodedData.SaveTo(fileStream);

var qrCodeBytes = encodedData.ToArray();
await File.WriteAllBytesAsync(@"D:\test-qrcode.png", qrCodeBytes);
// 转换为 Base64 字符串
var base64String = Convert.ToBase64String(qrCodeBytes);
Console.WriteLine("Base64 字符串：");
Console.WriteLine(base64String);

// 如果需要带前缀的 Base64（例如用于 HTML img 标签）
var base64WithPrefix = $"data:image/png;base64,{base64String}";
Console.WriteLine("\n带前缀的 Base64 字符串（用于 HTML）：");
Console.WriteLine(base64WithPrefix);