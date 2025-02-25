namespace Serene2.hospital.Pages;

[PageAuthorize(typeof(PatientsRow))]
public class PatientsPage : Controller
{
    [Route("hospital/Patients")]
    public ActionResult Index()
    {
        return this.GridPage<PatientsRow>("@/hospital/Patients/PatientsPage");
    }
}