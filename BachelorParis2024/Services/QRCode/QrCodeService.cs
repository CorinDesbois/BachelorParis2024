using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;

public class QrCodeService
{
    [SupportedOSPlatform("windows")]
    public byte[] GenerateQrCode(string content)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new QRCode(qrData);
        using var bitmap = qrCode.GetGraphic(20);
        using var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }
}

