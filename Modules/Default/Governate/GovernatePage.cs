using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene2.Default.Pages;

[PageAuthorize(typeof(GovernateRow))]
public class GovernatePage : Controller
{
    [Route("Default/Governate")]
    public ActionResult Index()
    {
        return this.GridPage<GovernateRow>("@/Default/Governate/GovernatePage");
    }
}