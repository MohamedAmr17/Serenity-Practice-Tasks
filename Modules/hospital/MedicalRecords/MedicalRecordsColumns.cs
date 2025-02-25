using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene2.hospital.Columns;

[ColumnsScript("hospital.MedicalRecords")]
[BasedOnRow(typeof(MedicalRecordsRow), CheckNames = true)]
public class MedicalRecordsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignCenter]
    public int RecordId { get; set; }
   [QuickSearch(SearchType.StartsWith)]
    public string DoctorName { get; set; }
    public string PatientName { get; set; }
    public DateTime RecordDate { get; set; }
    [EditLink]
    public string Notes { get; set; }
}