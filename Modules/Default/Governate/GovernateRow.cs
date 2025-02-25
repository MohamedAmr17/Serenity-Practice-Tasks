namespace Serene2.Default;

[ConnectionKey("Default"), Module("Default"), TableName("Governate")]
[DisplayName("Governate"), InstanceName("Governate")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
[LookupScript("Default.Governate",Permission ="?") ]
public sealed class GovernateRow : Row<GovernateRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Governate Id"), PrimaryKey, IdProperty]
    public int? GovernateId { get => fields.GovernateId[this]; set => fields.GovernateId[this] = value; }

    [DisplayName("Governate Name"), Size(10), NotNull, QuickSearch, NameProperty]
    public string GovernateName { get => fields.GovernateName[this]; set => fields.GovernateName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field GovernateId;
        public StringField GovernateName;
    }
}