using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital;

[ConnectionKey("Default"), Module("hospital"), TableName("Doctors")]
[DisplayName("Doctors"), InstanceName("Doctors")]
[ReadPermission(hospitalPermissionKeys.Doctors.View)]
[ModifyPermission(hospitalPermissionKeys.Doctors.Modify)]
[NavigationPermission(hospitalPermissionKeys.Doctors.Link)]
//[ServiceLookupPermission("Administration:General")]
[LookupScript]
public sealed class DoctorsRow : Row<DoctorsRow.RowFields>, IIdRow, INameRow
{
    const string jSpeciality = nameof(jSpeciality);

    [DisplayName("Doctor Id"), Identity, IdProperty, AlignCenter]
    public int? DoctorId { get => fields.DoctorId[this]; set => fields.DoctorId[this] = value; }

    [DisplayName("Doctor Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string DoctorName { get => fields.DoctorName[this]; set => fields.DoctorName[this] = value; }

    [DisplayName("Type"),LookupInclude]
    public TypeEnum? Type { get => fields.Type[this]; set => fields.Type[this] = value; }

    [DisplayName("Speciality"), LookupEditor(typeof(SpecialityRow), Multiple = true), NotMapped]
    [LinkingSetRelation(typeof(DocSpecRow), nameof(DocSpecRow.DoctorId), nameof(DocSpecRow.SpecialityId))]
    public List<int> SpecialityList
    {
        get => fields.SpecialityList[this];
        set => fields.SpecialityList[this] = value;
    }
    public class RowFields : RowFieldsBase
    {
        public Int32Field DoctorId;
        public StringField DoctorName;
        public EnumField<TypeEnum> Type;
        public ListField<int> SpecialityList;
    }
}