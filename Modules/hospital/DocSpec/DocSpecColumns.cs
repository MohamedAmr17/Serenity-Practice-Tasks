using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene2.hospital.Columns;

[ColumnsScript("hospital.DocSpec")]
[BasedOnRow(typeof(DocSpecRow), CheckNames = true)]
public class DocSpecColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int DocSpecId { get; set; }
    public int SpecialityId { get; set; }
    public int DoctorId { get; set; }
}