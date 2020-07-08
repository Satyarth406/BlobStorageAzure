using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace BlobStorageStandard.Interfaces
{
    public interface IFileStorage
    {
        Task<CloudBlockBlob> UploadFileAsync(byte[] fileByteArray, string fileName);
    }
}
