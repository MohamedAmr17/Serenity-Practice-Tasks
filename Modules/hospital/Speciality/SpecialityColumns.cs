using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene2.hospital.Columns;

[ColumnsScript("hospital.Speciality")]
[BasedOnRow(typeof(SpecialityRow), CheckNames = true)]
public class SpecialityColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignCenter]
    public int SpecialityId { get; set; }
    [EditLink]
    public string SpecialityName { get; set; }

    public string DoctorName { get; set; }
}