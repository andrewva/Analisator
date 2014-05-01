using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebSales.Controllers
{
    public class CabinetController : Controller
    {
        public ActionResult Index()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
            var files = Directory.GetFiles(path, "*.txt").Where(x => x.Split('_')[0] == HttpContext.User.Identity.GetUserId());
            return View(files.ToList());
        }
	}
}