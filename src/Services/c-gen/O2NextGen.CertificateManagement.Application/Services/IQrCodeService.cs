using System.Drawing;

namespace O2NextGen.CertificateManagement.Application.Services;

public interface IQrCodeService
{
    Task<Image> GetQrCodeBasicCertificate(long certificateId, int sizeQrCode);
}