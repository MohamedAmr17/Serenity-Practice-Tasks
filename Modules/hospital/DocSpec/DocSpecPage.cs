using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene2.hospital.Pages;

[PageAuthorize(typeof(DocSpecRow))]
public class DocSpecPage : Controller
{
    [Route("hospital/DocSpec")]
    public ActionResult Index()
    {
        return this.GridPage<DocSpecRow>("@/hospital/DocSpec/DocSpecPage");
    }
}