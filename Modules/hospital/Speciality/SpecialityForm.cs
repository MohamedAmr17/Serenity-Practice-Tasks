using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital.Forms;


[FormScript("hospital.Speciality")]
[BasedOnRow(typeof(SpecialityRow), CheckNames = true)]
public class SpecialityForm
{
    public string SpecialityName { get; set; }
    public int DoctorId { get; set; }
}