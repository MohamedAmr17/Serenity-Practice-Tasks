using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene2.Default.Columns;

[ColumnsScript("Default.Governate")]
[BasedOnRow(typeof(GovernateRow), CheckNames = true)]
public class GovernateColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int GovernateId { get; set; }
    [EditLink]
    public string GovernateName { get; set; }
}