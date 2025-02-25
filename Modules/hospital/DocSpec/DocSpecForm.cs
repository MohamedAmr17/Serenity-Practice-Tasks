using Serenity.ComponentModel;

namespace Serene2.hospital.Forms;

[FormScript("hospital.DocSpec")]
[BasedOnRow(typeof(DocSpecRow), CheckNames = true)]
public class DocSpecForm
{
    public int SpecialityId { get; set; }
    public int DoctorId { get; set; }
}