using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene2.Default.Columns;

[ColumnsScript("Default.City")]
[BasedOnRow(typeof(CityRow), CheckNames = true)]
public class CityColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int CityId { get; set; }
    [EditLink]
    public string CityName { get; set; }
    [Width(200)]
    public string GovernateName { get; set; }
}