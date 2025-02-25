namespace Serene2.hospital;

[ConnectionKey("Default"), Module("hospital"), TableName("DocSpec")]
[DisplayName("Doc Spec"), InstanceName("Doc Spec")]
[ReadPermission("?")]
[ModifyPermission("?")]
[LookupScript]
public sealed class DocSpecRow : Row<DocSpecRow.RowFields>, IIdRow
{
    [DisplayName("Doc Spec Id"), PrimaryKey, IdProperty]
    public int? DocSpecId { get => fields.DocSpecId[this]; set => fields.DocSpecId[this] = value; }

    [DisplayName("Speciality Id")]
    public int? SpecialityId { get => fields.SpecialityId[this]; set => fields.SpecialityId[this] = value; }

    [DisplayName("Doctor Id")]
    public int? DoctorId { get => fields.DoctorId[this]; set => fields.DoctorId[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field DocSpecId;
        public Int32Field SpecialityId;
        public Int32Field DoctorId;
    }
}