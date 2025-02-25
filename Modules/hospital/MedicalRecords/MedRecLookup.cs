using Serene2.hospital;

namespace Serene2.Modules.hospital.MedicalRecords;
 

[LookupScript("MedRecLookup", Permission = "?")]
public sealed class MedRecLookup : RowLookupScript<SpecialityRow>
{
    public MedRecLookup(ISqlConnections sqlConnections)
        : base(sqlConnections)
    {
        IdField = SpecialityRow.Fields.SpecialityId.PropertyName;
        TextField = SpecialityRow.Fields.SpecialityName.PropertyName;
    }

    protected override void PrepareQuery(SqlQuery query)
    {
        base.PrepareQuery(query);

        query.Select(SpecialityRow.Fields.SpecialityName);
    }
}
