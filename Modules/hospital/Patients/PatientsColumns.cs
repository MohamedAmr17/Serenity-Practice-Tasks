using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital.Columns;

[ColumnsScript("hospital.Patients")]
[BasedOnRow(typeof(PatientsRow), CheckNames = true)]
public class PatientsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignCenter]
    public int PatientId { get; set; }

    [EditLink, Width(200)]
    public string PatientName { get; set; }

    [Width(100), AlignCenter]
    public int Age { get; set; }

    [Width(100), AlignCenter]
    public int Cost { get; set; }

    [Width(100), AlignCenter]
    public int TotalDiscount { get; set; }

    [Width(150)]
    public DateTime DateOfBirth { get; set; }

    [Width(100), AlignCenter]
    public GenderEnum Gender { get; set; }

    [Width(120)]
    public string Address { get; set; }

    [Width(120), QuickFilter]
    public string GovName { get; set; }

    [Width(120), QuickFilter]
    public string CityName { get; set; }
    public string DoctorName { get; set; }
}