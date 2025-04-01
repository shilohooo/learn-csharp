using System.Drawing;
using QRCoder;

await CreateQrCode();
await CreateQrCodeWithLogo();
return;

// 生成普通的二维码
async Task CreateQrCode()
{
    var qrCodeGenerator = new QRCodeGenerator();
    var qrCodeData =
        qrCodeGenerator.CreateQrCode("https://github.com/shilohooo/arale-codegen", QRCodeGenerator.ECCLevel.Q);
    var qrCode = new BitmapByteQRCode(qrCodeData);
    // GetGraphic(缩放比例)，比例值越大，二维码越清晰，但占的存储空间也越大
    var qrCodeBytes = qrCode.GetGraphic(5);
    var filepath = $"D:\\qrcode_{Guid.NewGuid().ToString()}.png";
    await File.WriteAllBytesAsync(filepath, qrCodeBytes);
    Console.WriteLine($"二维码已生成，保存路径：{filepath}");
}

// 生成带 logo 的二维码
async Task CreateQrCodeWithLogo()
{
    var qrCodeGenerator = new QRCodeGenerator();
    var qrCodeData =
        qrCodeGenerator.CreateQrCode("https://github.com/shilohooo/arale-codegen", QRCodeGenerator.ECCLevel.Q);
    var qrCode = new SvgQRCode(qrCodeData);
    // GetGraphic(缩放比例)，比例值越大，二维码越清晰，但占的存储空间也越大
    var logoBytes = await File.ReadAllBytesAsync(@"D:\\huaji.jpg");
    var svgLogo = new SvgQRCode.SvgLogo(logoBytes);
    var svgQrCodeContent = qrCode.GetGraphic(5, darkColor: Color.Black, lightColor: Color.White, logo: svgLogo);
    Console.WriteLine($"svg 二维码内容：{svgQrCodeContent}");
}