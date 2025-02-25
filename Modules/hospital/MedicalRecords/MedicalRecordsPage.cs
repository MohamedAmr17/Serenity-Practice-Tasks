using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene2.hospital.Pages;

[PageAuthorize(typeof(MedicalRecordsRow))]
public class MedicalRecordsPage : Controller
{
    [Route("hospital/MedicalRecords")]
    public ActionResult Index()
    {
        return this.GridPage<MedicalRecordsRow>("@/hospital/MedicalRecords/MedicalRecordsPage");
    }
}