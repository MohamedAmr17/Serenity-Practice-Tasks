namespace Serene2.hospital.Forms;

using Serene2.Modules.hospital.Patients.Enum;
using Serenity.ComponentModel;


[FormScript("hospital.Doctors")]
[BasedOnRow(typeof(DoctorsRow), CheckNames = true)]
public class DoctorsForm
{
        public string DoctorName { get; set; }
        
        public List<int> SpecialityList { get; set; }

        public TypeEnum Type { get; set; }
}
 