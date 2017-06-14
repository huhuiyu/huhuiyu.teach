using FileUpload.dal.dao;
using FileUpload.dal.entity;
using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class DefaultController : Controller
    {
        private void QueryInfo(DefaultModel model)
        {
            try
            {
                model.PageInfo.Count = TblFilesDAO.QueryCount();
                model.Files = TblFilesDAO.QueryPage(model.PageInfo);
            }
            catch (Exception ex)
            {
                model.ActionCode = 500;
                model.ActionMessage = ex.Message;
            }
        }

        public ActionResult Index(DefaultModel model)
        {
            QueryInfo(model);
            return View(model);
        }

        public ActionResult Add(DefaultModel model, HttpPostedFileBase uploadFile)
        {
            try
            {
                //处理文件上传
                if (uploadFile != null)
                {
                    //原始文件名称
                    string filename = uploadFile.FileName;
                    if (filename.IndexOf("\\") > -1)
                    {
                        filename = filename.Substring(filename.LastIndexOf("\\") + 1);
                    }
                    model.UpFile.Filename = filename;
                    //通过guid产生不重复的文件名
                    model.UpFile.Filepath = Guid.NewGuid().ToString();
                    //获取文件类型和文件大小
                    model.UpFile.ContentType = uploadFile.ContentType;
                    model.UpFile.Size = uploadFile.ContentLength;
                    //设置保存文件名
                    string saveName = Server.MapPath(
                        WebMvc.MvcApplication.UploadPath +
                        model.UpFile.Filepath);
                    //保存文件
                    uploadFile.SaveAs(saveName);
                    //保存信息到数据库
                    TblFilesDAO.Add(model.UpFile);
                    //提示消息保存成功
                    model.ActionCode = 200;
                }
                QueryInfo(model);
            }
            catch (Exception ex)
            {
                model.ActionCode = 500;
                model.ActionMessage = ex.Message;
            }
            return View("Index", model);
        }

        public FileResult DownLoad(DefaultModel model)
        {
            model.UpFile = TblFilesDAO.QueryById(model.UpFile);
            //文件路径信息
            string filePath = Server.MapPath(
                WebMvc.MvcApplication.UploadPath
                + model.UpFile.Filepath);
            //文件路径，文件类型，下载文件名称
            return File(filePath, model.UpFile.ContentType, model.UpFile.Filename);
        }

        public ActionResult ShowImage(DefaultModel model)
        {
            return View(model);
        }

        public ActionResult ToUpFiles(DefaultModel model)
        {
            return View(model);
        }

        public ActionResult AddFiles(DefaultModel model, HttpPostedFileBase[] uploadFile)
        {
            try
            {
                //处理文件上传
                if (uploadFile != null)
                {
                    foreach (HttpPostedFileBase uf in uploadFile)
                    {
                        TblFiles tf = new TblFiles();
                        tf.Description = model.UpFile.Description;

                        //原始文件名称
                        string filename = uf.FileName;
                        if (filename.IndexOf("\\") > -1)
                        {
                            filename = filename.Substring(filename.LastIndexOf("\\") + 1);
                        }
                        tf.Filename = filename;
                        //通过guid产生不重复的文件名
                        tf.Filepath = Guid.NewGuid().ToString();
                        //获取文件类型和文件大小
                        tf.ContentType = uf.ContentType;
                        tf.Size = uf.ContentLength;
                        //设置保存文件名
                        string saveName = Server.MapPath(
                            WebMvc.MvcApplication.UploadPath +
                            tf.Filepath);
                        //保存文件
                        uf.SaveAs(saveName);
                        //保存信息到数据库
                        TblFilesDAO.Add(tf);
                    }
                }
                model.ActionCode = 200;
            }
            catch (Exception ex)
            {
                model.ActionCode = 500;
                model.ActionMessage = ex.Message;
            }
            return View("ToUpFiles", model);
        }


    }
}
