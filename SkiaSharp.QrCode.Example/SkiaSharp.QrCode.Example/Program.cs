using SkiaSharp;
using SkiaSharp.QrCode;

const string QR_CONTENT = "https://example.com";
const string TEXT = "南海区桂城街道测试学校";
const string OUTPUT_PATH = @"D:\qrcode_with_text.png";
const int QR_SIZE = 300;
const int TEXT_SPACE = 100;
const int TEXT_OFFSET = 50;
const float TEXT_SIZE = 24;

var totalWidth = QR_SIZE;
var totalHeight = QR_SIZE + TEXT_SPACE;

// 创建画布
var imageInfo = new SKImageInfo(totalWidth, totalHeight);
using var surface = SKSurface.Create(imageInfo);
var canvas = surface.Canvas;

// 清空画布为白色背景
canvas.Clear(SKColors.White);

// 生成二维码
var qrGenerator = new QRCodeGenerator();
var qrCode = qrGenerator.CreateQrCode(QR_CONTENT, ECCLevel.M);

// 创建二维码位图
using var qrBitmap = new SKBitmap(QR_SIZE, QR_SIZE);
using var qrCanvas = new SKCanvas(qrBitmap);
qrCanvas.Clear(SKColors.White); // 背景色

// 获取矩阵并处理 List<BitArray>
var moduleMatrix = qrCode.ModuleMatrix;
var matrixSize = moduleMatrix.Count; // 获取行数
var scale = (float)QR_SIZE / matrixSize; // 计算每个模块的像素大小
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
var qrX = (totalWidth - QR_SIZE) / 2;
var qrY = 0;
canvas.DrawBitmap(qrBitmap, qrX, qrY);

// 加载字体
SKTypeface typeface;
try
{
    // 尝试加载系统字体（Windows 示例）
    typeface = SKTypeface.FromFamilyName("Microsoft YaHei", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
    
    // 如果需要加载特定字体文件（取消注释并提供字体文件路径）
    // typeface = SKTypeface.FromFile("path/to/your/font.ttf");
}
catch (Exception ex)
{
    Console.WriteLine($"字体加载失败: {ex.Message}");
    throw;
}

// 设置文字样式
using var textPaint = new SKPaint
{
    Color = SKColors.Black,
    IsAntialias = true,
    Style = SKPaintStyle.Fill,
    TextAlign = SKTextAlign.Center,
    TextSize = TEXT_SIZE,
    Typeface = typeface // 设置字体
};

// 获取文字边界
var textBounds = new SKRect();
textPaint.MeasureText(TEXT, ref textBounds);

// 计算文字位置（二维码下方居中）
var textX = totalWidth / 2f;
var textY = QR_SIZE + TEXT_OFFSET;

// 绘制文字
canvas.DrawText(TEXT, textX, textY, textPaint);

// 保存图片
using var image = surface.Snapshot();
using var encodedData = image.Encode(SKEncodedImageFormat.Png, 100);
using var fileStream = File.OpenWrite(OUTPUT_PATH);
encodedData.SaveTo(fileStream);