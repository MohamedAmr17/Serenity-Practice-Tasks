using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital.Forms;

[FormScript("hospital.Patients")]
[BasedOnRow(typeof(PatientsRow), CheckNames = true)]
public class PatientsForm
{
    public string PatientName { get; set; }
    public int Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public GenderEnum Gender { get; set; }

    [Required]
    public int GovernateId { get; set; }
    public int CityId { get; set; }

    [TextAreaEditor(Rows = 5)]
    public string Address { get; set; }
    public int DoctorId { get; set; }

    public int Cost { get; set; }

    [DisplayName("Loyalty Years")]
    public int LoyaltyYears { get; set; }

    [DisplayName("Total Discount"),ReadOnly(true)]
    public int TotalDiscount { get; set; }
    
    [Required]
    
    public int TaskValue { get; set; }

}