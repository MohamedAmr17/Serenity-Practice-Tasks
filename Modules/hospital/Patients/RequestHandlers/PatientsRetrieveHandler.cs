using Serene2.Modules.hospital.Patients.Enum;
using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.hospital.PatientsRow>;
using MyRow = Serene2.hospital.PatientsRow;

namespace Serene2.hospital;

public interface IPatientsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class PatientsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPatientsRetrieveHandler
{
    public PatientsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
    //protected override void PrepareQuery(SqlQuery query)
    //{
    //    base.PrepareQuery(query);
    //    query.Where(PatientsRow.Fields.Gender == 1);
    //}
}