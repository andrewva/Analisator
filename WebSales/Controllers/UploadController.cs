using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Concordanse;
using DataModel;
using WebSales.Models;

namespace WebSales.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            var filePath = "";
            var fileName = "";
            var resultPath = "";
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                var path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
                fileName = Path.GetFileName(file.FileName);
                if (fileName == null) continue;
                filePath = (Path.Combine(path, Guid.NewGuid() + "_" + fileName));
                resultPath = filePath.Substring(0, filePath.Length - 3) + "xml";
                file.SaveAs(filePath);
            }
            var parse = new Parse();
            var data = new UploadData()
            {
                ResultText = parse.ParseFile(filePath)
            };
            using (var db = new UploadDB())
            {
                var item = new Item
                {
                    FileName = fileName,
                    UploadDate = DateTime.Now,
                    UserId = HttpContext.User.Identity.Name,
                    ResultPath = resultPath,
                    UploadPath = filePath
                };
                db.Items.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Result", data);
        }

        public ActionResult UpladText(string fileUpload)
        {
            var filePath = "";
            var fileName = "";
            var resultPath = "";
            var path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
            filePath = (Path.Combine(path, Guid.NewGuid() + "_" + fileName + ".txt"));
            resultPath = filePath.Substring(0, filePath.Length - 3) + "xml";

            using (var sr = new StreamWriter(filePath))
            {
                sr.Write(fileUpload);
            }
            var parse = new Parse();
            var data = new UploadData()
            {
                ResultText = parse.ParseFile(filePath)
            };
            using (var db = new UploadDB())
            {
                var item = new Item
                {
                    FileName = fileName,
                    UploadDate = DateTime.Now,
                    UserId = HttpContext.User.Identity.Name,
                    ResultPath = resultPath,
                    UploadPath = filePath
                };
                db.Items.Add(item);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Result", data);
        }
    }
}