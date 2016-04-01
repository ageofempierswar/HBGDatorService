using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HBGDatorServiceDAL.Models
{
    public class UploadFileModel
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
    }

    public enum FileType
    {
        Avatar = 1, Photo
    }
}
