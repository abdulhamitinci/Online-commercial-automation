using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kod)
        {
            if (string.IsNullOrEmpty(kod))
            {
                ViewBag.ErrorMessage = "Lütfen bir kod girin!";
                return View();
            }

            try
            {
                // QR kod oluşturma işlemi
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                // QR kodu grafik olarak oluştur
                using (Bitmap qrCodeImage = qrCode.GetGraphic(10))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // QR kodu PNG formatında MemoryStream'e kaydet
                        qrCodeImage.Save(ms, ImageFormat.Png);
                        // Base64 string'e çevir ve ViewBag'e at
                        ViewBag.KarekodImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "QR kodu oluşturulurken bir hata oluştu: " + ex.Message;
            }

            return View();
        }
    }
}
