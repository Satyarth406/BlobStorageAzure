using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlobStorageStandard.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace BlobStorageStandard.Services
{
    public class FileStorageAzure:IFileStorage
    {
        public async Task<CloudBlockBlob>  UploadFileAsync(byte[] fileByteArray, string fileName)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(ApplicationSettings.ContainerConnectionString);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("images");
            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, null, null);

            var cloudBlockBlob = container.GetBlockBlobReference(fileName);
            await cloudBlockBlob.UploadFromByteArrayAsync(fileByteArray,0,fileByteArray.Length);
            return cloudBlockBlob;
        }
    }
}
