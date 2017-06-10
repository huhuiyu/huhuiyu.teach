using FileUpload.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class DefaultModel
    {
        public string ActionMessage { get; set; }
        public int ActionCode { get; set; }
        public List<TblFiles> Files { get; set; }
        public TblFiles UpFile { get; set; }
        public Page PageInfo { get; set; }

        public DefaultModel()
        {
            Files = new List<TblFiles>();
            PageInfo = new Page();
            UpFile = new TblFiles();
            ActionMessage = "";
            ActionCode = 0;
        }

    }
}