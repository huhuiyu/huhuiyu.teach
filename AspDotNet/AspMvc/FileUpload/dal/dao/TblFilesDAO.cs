using FileUpload.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.dal.dao
{
    public class TblFilesDAO
    {
        public static int QueryCount()
        {
            return (int)DBHelper.QueryOne(@"select count(*) from TblFiles");
        }

        public static List<TblFiles> QueryPage(Page page)
        {
            return DBHelper.QueryRows(new TblFiles(),
string.Format(@"select top {0} * from TblFiles 
 where fid not in(select top {1} fid from TblFiles order by fid desc)
 order by fid desc", page.PageSize, page.Skip));
        }

        public static TblFiles QueryById(TblFiles file)
        {
            return DBHelper.QueryOneRow(file, @"select * from TblFiles where fid=@p0", file.Fid);
        }

        public static int Add(TblFiles file)
        {
            return DBHelper.Update(
@"insert into TblFiles(filepath,filename,contentType,size,description) values(@p0,@p1,@p2,@p3,@p4)"
, file.Filepath, file.Filename, file.ContentType, file.Size, file.Description);
        }
    }
}