using Serenity.ComponentModel;

namespace Serene2.Default.Forms;

[FormScript("Default.City")]
[BasedOnRow(typeof(CityRow), CheckNames = true)]
public class CityForm
{
    public string CityName { get; set; }
    [LookupEditor(typeof(GovernateRow))]
    public int GovernateId { get; set; }
}