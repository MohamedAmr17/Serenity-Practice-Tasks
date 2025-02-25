using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital;

[ConnectionKey("Default"), Module("hospital"), TableName("Speciality")]
[DisplayName("Speciality"), InstanceName("Speciality")]
[LookupScript]
[ReadPermission("?")]
[ModifyPermission("?")]
[ServiceLookupPermission("?")]
public sealed class SpecialityRow : Row<SpecialityRow.RowFields>, IIdRow, INameRow
{

    private const string jDoctor = nameof(jDoctor);

    [DisplayName("Speciality Id"), Identity, IdProperty]
    public int? SpecialityId { get => fields.SpecialityId[this]; set => fields.SpecialityId[this] = value; }

    [DisplayName("Speciality Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string SpecialityName { get => fields.SpecialityName[this]; set => fields.SpecialityName[this] = value; }

    [DisplayName("Doctor"), ForeignKey(typeof(DoctorsRow)), LeftJoin(jDoctor)]
    [LookupEditor(typeof(DoctorsRow))]
    public int? DoctorId { get => fields.DoctorId[this]; set => fields.DoctorId[this] = value; }

    [DisplayName("Doctor Name")]
    [Origin(jDoctor, nameof(DoctorsRow.DoctorName))]
    public string DoctorName { get => fields.DoctorName[this]; set => fields.DoctorName[this] = value; }


    public class RowFields : RowFieldsBase
    {
        public Int32Field SpecialityId;
        public Int32Field DoctorId;
        public StringField SpecialityName;
        public StringField DoctorName;
    }
}