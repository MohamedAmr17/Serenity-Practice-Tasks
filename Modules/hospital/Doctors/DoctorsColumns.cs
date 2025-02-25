using hospital;
using MovieTutorial;

namespace Serene2.hospital.Columns;

[ColumnsScript("hospital.Doctors")]
[BasedOnRow(typeof(DoctorsRow), CheckNames = true)]
public class DoctorsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignCenter]
    public int DoctorId { get; set; }
    [EditLink]
    public string DoctorName { get; set; }

    [Width(200), DocSpecialityListFormatter]
    public List<int> SpecialityList { get; set; }

}
