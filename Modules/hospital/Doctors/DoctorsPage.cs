namespace Serene2.hospital.Pages;

//[PageAuthorize(PermissionKeys.Doctors)]
public class DoctorsPage : Controller
{
    [Route("hospital/Doctors")]
    public ActionResult Index()
    {
        return this.GridPage<DoctorsRow>("@/hospital/Doctors/DoctorsPage");
    }
}