using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class ImgCodeController : Controller
    {
        public const string Codes = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static Random rand = new Random();
        public const int Length = 4;
        public const int FontSize = 18;
        public const string SessionCodeKey = "ImageCode";

        public static string BuildCode()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                sb.Append(Codes.Substring(rand.Next(Codes.Length), 1));
            }
            return sb.ToString();
        }

        public byte[] CreateImg(string code)
        {
            Bitmap image = new Bitmap(Length * FontSize + 6, (FontSize - 1) * 2);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //清空图片背景色
                g.Clear(Color.Yellow);

                //输出校验码
                Font font = new Font("Arial", FontSize,
                    (FontStyle.Bold | FontStyle.Italic));
                g.DrawString(code, font, Brushes.Red, 3, 2);

                //输出干扰线
                for (int i = 0; i < 10; i++)
                {
                    int x1 = rand.Next(image.Width);
                    int x2 = rand.Next(image.Width);
                    int y1 = rand.Next(image.Height);
                    int y2 = rand.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }

                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        public FileResult Code()
        {
            string code = BuildCode();
            Session[SessionCodeKey] = code;
            return File(CreateImg(code), "image/jpeg");
        }

        public string CheckCode(string code)
        {
            string saveCode = (string)Session[SessionCodeKey];
            Session.Remove(SessionCodeKey);
            if (string.IsNullOrWhiteSpace(code) ||
                string.IsNullOrWhiteSpace(saveCode)
                 || !code.Equals(saveCode, StringComparison.OrdinalIgnoreCase))
            {
                return "图片校验码不正确！";
            }
            else
            {
                return "图片校验码正确！";
            }
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
