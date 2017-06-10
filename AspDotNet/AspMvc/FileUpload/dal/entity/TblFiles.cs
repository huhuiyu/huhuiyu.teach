using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.dal.entity
{
    public class TblFiles
    {
        public int Fid { get; set; }
        public string Filepath { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
    }
}