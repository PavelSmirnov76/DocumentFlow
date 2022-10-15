using DocumentFlow.Server.Crypt;
using DocumentFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/VerificationSignature")]
    [ApiController]
    public class VerificationSignatureController
    {
        public VerificationSignatureController()
        {
        }

        [HttpPost]
        public bool PostFile(IFormCollection upFile)
        {

            var uploadedFile = upFile.Files;

            if (uploadedFile["cert"] != null && uploadedFile["file"] != null && uploadedFile["sign"] != null)
            {

                var certStream = new StreamReader(uploadedFile["cert"].OpenReadStream());

                var fileStream = new StreamReader(uploadedFile["file"].OpenReadStream());

                var signStream = new StreamReader(uploadedFile["sign"].OpenReadStream());
                var digSing = new DigitalSignature();

                var signStr = signStream.ReadToEnd().Trim().Split('-');
                byte[] sign = new byte[signStr.Length];
                for (int i = 0; i < signStr.Length; i++)
                {
                    sign[i] = Convert.ToByte(signStr[i], 16);
                }


                return digSing.SignVer(System.Text.Encoding.Default.GetBytes(fileStream.ReadToEnd()),
                                        sign,
                                        new ECPoint
                                        {
                                            x = BigInteger.Parse(certStream.ReadLine()),
                                            y = BigInteger.Parse(certStream.ReadLine())
                                        });
            }
            return false;
        }
    }
}
