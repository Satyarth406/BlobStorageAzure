using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlobStorageStandard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImplementingBlobStorage.Models;
using Microsoft.Azure.Storage.Blob;

namespace ImplementingBlobStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileStorage _fileStorage;
        private readonly BlobStorageDbContext _blobStorageDbContext;

        public HomeController(ILogger<HomeController> logger, IFileStorage fileStorage,
            BlobStorageDbContext blobStorageDbContext)
        {
            _logger = logger;
            _fileStorage = fileStorage;
            _blobStorageDbContext = blobStorageDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FileUploadViewModel fileUpload)
        {
            using (var ms = new MemoryStream())
            {
                fileUpload.Image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                CloudBlockBlob cloudBlockBlob =  await _fileStorage.UploadFileAsync(fileBytes, fileUpload.Image.FileName);

                // act on the Base64 data
            }
            return View();
        }
    }
}
