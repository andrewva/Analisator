using System.Web.Mvc;
using WebSales.Models;
using XMLParser;

namespace WebSales.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        public ActionResult Index(UploadData data)
        {
            var parse = new Parser();
            var model = parse.Parse(data.ResultText);
            return View(model);
        }
        public ActionResult ConcordanseResult (UploadData data)
        {
            var parse = new Parser();
            var model = parse.ParseToConcordanse(data.ResultText);
            return View(model.GetConcordanseResult());
        }
    }
}