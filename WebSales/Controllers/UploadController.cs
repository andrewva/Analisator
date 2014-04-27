using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Concordanse;
using Microsoft.AspNet.Identity;
using WebSales.Models;
using XMLParser;

namespace WebSales.Controllers
{
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
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                var path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
                var filename = Path.GetFileName(file.FileName);
                if (filename == null) continue;
                filePath = (Path.Combine(path, filename));
                file.SaveAs(filePath);
            }
              var parse = new Parse();
            var data = new UploadData()
            {
                ResultText = parse.ParseFile(filePath),
                UploadDate = DateTime.Now,
                UploadText = filePath,
                UserId = HttpContext.User.Identity.GetUserId()
            };
          
            return RedirectToAction("Index", "Result", data);
        }

        public ActionResult UpladText(string fileUpload)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
            var filename = Path.GetFileName(Guid.NewGuid().ToString());
            using (var sr = new StreamWriter(Path.Combine(path, filename)))
            {
                sr.Write(fileUpload);
            }
            var parse = new Parse();
            var xmlPath = parse.ParseFile(path);
            return RedirectToAction("Index", "Result", xmlPath);
        }
    }
}