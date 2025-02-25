namespace Serene2.hospital.Forms;

[FormScript("hospital.MedicalRecords")]
[BasedOnRow(typeof(MedicalRecordsRow), CheckNames = true)]
public class MedicalRecordsForm
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime RecordDate { get; set; }
    [TextAreaEditor]
    public string Notes { get; set; }
}