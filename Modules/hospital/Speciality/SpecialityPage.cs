using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene2.hospital.Pages;

[PageAuthorize(typeof(SpecialityRow))]
public class SpecialityPage : Controller
{
    [Route("hospital/Speciality")]
    public ActionResult Index()
    {
        return this.GridPage<SpecialityRow>("@/hospital/Speciality/SpecialityPage");
    }
}