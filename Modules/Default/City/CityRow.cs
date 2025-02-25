namespace Serene2.Default;

[ConnectionKey("Default"), Module("Default"), TableName("City")]
[DisplayName("City"), InstanceName("City")]
[ReadPermission("\"Administration:General\"")]
[ModifyPermission("\"Administration:General\"")]
[ServiceLookupPermission("Administration:General")]
[LookupScript("Default.City", Permission = "?")]
public sealed class CityRow : Row<CityRow.RowFields>, IIdRow, INameRow
{
    const string jGovernate = nameof(jGovernate);

    [DisplayName("City Id"), Identity, PrimaryKey, IdProperty]
    public int? CityId { get => fields.CityId[this]; set => fields.CityId[this] = value; }

    [DisplayName("City Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string CityName { get => fields.CityName[this]; set => fields.CityName[this] = value; }

    [DisplayName("Governate"),LookupInclude, ForeignKey(typeof(GovernateRow)), LeftJoin(jGovernate), TextualField(nameof(GovernateName))]
    [ServiceLookupEditor(typeof(GovernateRow))]
    public int? GovernateId { get => fields.GovernateId[this]; set => fields.GovernateId[this] = value; }

    [Origin(jGovernate, nameof(GovernateRow.GovernateName))]
    [DisplayName("Governate Name"), QuickSearch]
    public string GovernateName { get => fields.GovernateName[this]; set => fields.GovernateName[this] = value; }
    public class RowFields : RowFieldsBase
    {
        public Int32Field CityId;
        public StringField CityName;
        public Int32Field GovernateId;
        public StringField GovernateName;
    }
}

