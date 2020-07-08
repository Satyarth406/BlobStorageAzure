using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImplementingBlobStorage.Models
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileUri { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
    }

    public class FileUploadViewModel
    {
        public IFormFile Image { get; set; }
    }
}