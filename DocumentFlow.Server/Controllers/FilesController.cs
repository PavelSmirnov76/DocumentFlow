using DocumentFlow.Server.Crypt;
using DocumentFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using File = DocumentFlow.Server.Models.File;

namespace DocumentFlow.Server.Controllers
{
    [Route("api/Files")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly DocumentFlowServerContext _context;
        IWebHostEnvironment _appEnvironment;

        public FilesController(DocumentFlowServerContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("{path}")]
        public async Task<ActionResult<File>> GetFile(string path)
        {
            string file_path = _appEnvironment.WebRootPath + "/Files/" + path;

            string file_type = "application/octet-stream";

            return PhysicalFile(file_path, file_type);
        }

        [HttpPost]
        public ActionResult<long> PostFile(IFormCollection upFile)
        {

            var uploadedFile = upFile.Files;

            var path = "/Files/" + uploadedFile["file"].FileName;


            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                uploadedFile["file"].CopyTo(fileStream);

            }

            var file = new File { FileName = uploadedFile["file"].FileName, FilePath = path};


            if (uploadedFile["cert"] != null)
            {
                var certStream = new StreamReader(uploadedFile["cert"].OpenReadStream());

                var fileStream = new StreamReader(uploadedFile["file"].OpenReadStream());

                var digSing = new DigitalSignature();

                var sign = BitConverter.ToString(digSing.SignMessage(System.Text.Encoding.Default.GetBytes(fileStream.ReadToEnd()),
                                                    BigInteger.Parse(certStream.ReadLine())));

                using (var signStream = new StreamWriter(_appEnvironment.WebRootPath + "/Files/" + uploadedFile["file"].FileName + "_подпись.txt"))
                {
                    signStream.WriteLine(sign);
                }
                file.FileName = uploadedFile["file"].FileName + "_подпись.txt";
                file.SignPath = path + "_подпись.txt";
            }


            _context.Files.Add(file);

            _context.SaveChanges();

            return file.Id;
        }
    }
}
