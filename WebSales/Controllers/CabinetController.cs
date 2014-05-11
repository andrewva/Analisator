using System.Linq;
using System.Web.Mvc;
using DataModel;

namespace WebSales.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new UploadDB())
            {
                var items = db.Items.Where(x => x.UserId == HttpContext.User.Identity.Name);
                return View( items.ToList());
            }
        }

        public FileResult Download(string path)
        {
            var paths = path.Split('/');
            var name = paths[paths.Length - 1];
            return File(path, System.Net.Mime.MediaTypeNames.Application.Octet, name); 
        }
	}
}