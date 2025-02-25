using Serene2.hospital.Pages;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Serene2.hospital;

[ConnectionKey("Default"), Module("hospital"), TableName("MedicalRecords")]
[DisplayName("Medical Records"), InstanceName("Medical Records")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
public sealed class MedicalRecordsRow : Row<MedicalRecordsRow.RowFields>, IIdRow, INameRow
{
    const string jDoctor = nameof(jDoctor);
    const string jPatient = nameof(jPatient);
    const string jSpeciality = nameof(jSpeciality);

    [DisplayName("Record Id"), Identity, IdProperty]
    public int? RecordId { get => fields.RecordId[this]; set => fields.RecordId[this] = value; }

    [DisplayName("Doctor"), NotNull, ForeignKey(typeof(DoctorsRow)), LeftJoin(jDoctor), TextualField(nameof(DoctorName))]
    [ServiceLookupEditor(typeof(DoctorsRow))]
    public int? DoctorId { get => fields.DoctorId[this]; set => fields.DoctorId[this] = value; }

    [DisplayName("Patient"), NotNull, ForeignKey(typeof(PatientsRow)), LeftJoin(jPatient), TextualField(nameof(PatientName))]
    [ServiceLookupEditor(typeof(PatientsRow))]
    public int? PatientId { get => fields.PatientId[this]; set => fields.PatientId[this] = value; }

    [DisplayName("Speciality"), ForeignKey(typeof(SpecialityRow)), LeftJoin(jSpeciality), TextualField(nameof(SpecialityName))]
    [ServiceLookupEditor(typeof(SpecialityRow))]
    public int? SpecialityId { get => fields.SpecialityId[this]; set => fields.SpecialityId[this] = value; }

    [DisplayName("Record Date")]
    public DateTime? RecordDate { get => fields.RecordDate[this]; set => fields.RecordDate[this] = value; }

    [DisplayName("Notes"), Size(1000), NameProperty]
    public string Notes { get => fields.Notes[this]; set => fields.Notes[this] = value; }

    [DisplayName("Doctor Name"), QuickSearch, Origin(jDoctor, nameof(DoctorsRow.DoctorName))]
    public string DoctorName { get => fields.DoctorName[this]; set => fields.DoctorName[this] = value; }

    [DisplayName("Patient Name"), QuickSearch, Origin(jPatient, nameof(PatientsRow.PatientName))]
    public string PatientName { get => fields.PatientName[this]; set => fields.PatientName[this] = value; }

    [DisplayName("Speciality Name"), Origin(jSpeciality, nameof(SpecialityRow.SpecialityName))]
    public string SpecialityName { get => fields.SpecialityName[this]; set => fields.SpecialityName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field RecordId;
        public Int32Field DoctorId;
        public Int32Field PatientId;
        public Int32Field SpecialityId;
        public DateTimeField RecordDate;
        public StringField Notes;
        public StringField DoctorName;
        public StringField PatientName;
        public StringField SpecialityName;
    }
}