using System.Linq.Expressions;
using Serene2.Default;
using Serene2.Modules.hospital.Patients.Enum;

namespace Serene2.hospital;

[ConnectionKey("Default"), Module("hospital"), TableName("Patients")]
[DisplayName("Patients"), InstanceName("Patients")]
[ReadPermission(hospitalPermissionKeys.Patients.View)]
[ModifyPermission(hospitalPermissionKeys.Patients.Modify)]
[NavigationPermission(hospitalPermissionKeys.Patients.Link)]
[ServiceLookupPermission("Administration:General")]
[LookupScript]

public sealed class PatientsRow : Row<PatientsRow.RowFields>, IIdRow, INameRow
{
    private const string jGovernate = nameof(jGovernate);
    private const string jCity = nameof(jCity);
    private const string jDoctor = nameof(jDoctor);

    [DisplayName("Patient Id"), Identity, IdProperty]
    public int? PatientId { get => fields.PatientId[this]; set => fields.PatientId[this] = value; }

    [DisplayName("Patient Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string PatientName { get => fields.PatientName[this]; set => fields.PatientName[this] = value; }

    [DisplayName("Governate Name")]
    [Origin(jGovernate, nameof(GovernateRow.GovernateName))]
    public string GovName { get => fields.GovName[this]; set => fields.GovName[this] = value; }

    [DisplayName("City Name")]
    [Origin(jCity, nameof(CityRow.CityName))]
    public string CityName { get => fields.CityName[this]; set => fields.CityName[this] = value; }

    [DisplayName("Governate"), ForeignKey(typeof(GovernateRow)), LeftJoin(jGovernate)]
    [LookupEditor(typeof(GovernateRow))]
    public int? GovernateId { get => fields.GovernateId[this]; set => fields.GovernateId[this] = value; }
    
    [DisplayName("City"), ForeignKey(typeof(CityRow)), LeftJoin(jCity)]
    [LookupEditor(typeof(CityRow), CascadeFrom = "GovernateId", CascadeField = "GovernateId")]
    public int? CityId { get => fields.CityId[this]; set => fields.CityId[this] = value; }

    [DisplayName("Date Of Birth"), NotNull]
    public DateTime? DateOfBirth { get => fields.DateOfBirth[this]; set => fields.DateOfBirth[this] = value; }

    [DisplayName("Gender"),NotNull]
    public GenderEnum? Gender { get => fields.Gender[this]; set => fields.Gender[this] = value; }

    [DisplayName("Address Details"), Size(255)]
    public string Address { get => fields.Address[this]; set => fields.Address[this] = value; }

    [DisplayName("Age"), QuickSearch,NotNull]
    public int? Age { get => fields.Age[this]; set => fields.Age[this] = value; }

    [DisplayName("Task Value"), NotNull]
    public int? TaskValue { get => fields.TaskValue[this]; set => fields.TaskValue[this] = value; }

    [DisplayName("Cost"), NotNull]
    public int? Cost { get => fields.Cost[this]; set => fields.Cost[this] = value; }

    [DisplayName("Loyalty Years"), NotNull]
    public int? LoyaltyYears { get => fields.LoyaltyYears[this]; set => fields.LoyaltyYears[this] = value; }

    [DisplayName("Total Discount")]
    [Expression("(t0.Cost * t0.LoyaltyYears * 0.05)")]
    public int? TotalDiscount { get => fields.TotalDiscount[this]; set => fields.TotalDiscount[this] = value; }

    [DisplayName("Doctor"), ForeignKey(typeof(DoctorsRow)), LeftJoin(jDoctor)]
    [LookupEditor(typeof(DoctorsRow))]
    public int? DoctorId { get => fields.DoctorId[this]; set => fields.DoctorId[this] = value; }

    [DisplayName("Doctor Name")]
    [Origin(jDoctor, nameof(DoctorsRow.DoctorName))]
    public string DoctorName { get => fields.DoctorName[this]; set => fields.DoctorName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field PatientId;
        public Int32Field DoctorId;
        public StringField PatientName;
        public StringField DoctorName;
        public StringField GovName;
        public StringField CityName;
        public Int32Field GovernateId;
        public Int32Field CityId;
        public DateTimeField DateOfBirth;
        public EnumField<GenderEnum> Gender;
        public StringField Address;
        public Int32Field Age;
        public Int32Field LoyaltyYears;
        public Int32Field TaskValue;
        public Int32Field Cost;
        public Int32Field TotalDiscount;
    }
}