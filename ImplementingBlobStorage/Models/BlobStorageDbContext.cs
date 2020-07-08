using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImplementingBlobStorage.Models
{
    public class BlobStorageDbContext:DbContext
    {
        public BlobStorageDbContext(DbContextOptions<BlobStorageDbContext> options):base(options)
        {
            
        }

        public DbSet<FileUpload> FileUploads { get; set; }
    }
}
