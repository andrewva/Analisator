using System.Linq;
using System.Web.Mvc;
using DataModel;

namespace WebSales.Controllers
{
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
	}
}