using Serenity.ComponentModel;

namespace Serene2.Default.Forms;

[FormScript("Default.Governate")]
[BasedOnRow(typeof(GovernateRow), CheckNames = true)]
public class GovernateForm
{
    public string GovernateName { get; set; }
}