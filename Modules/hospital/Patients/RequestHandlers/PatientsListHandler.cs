using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.hospital.PatientsRow>;
using MyRow = Serene2.hospital.PatientsRow;

namespace Serene2.hospital;

public interface IPatientsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class PatientsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPatientsListHandler
{
    public PatientsListHandler(IRequestContext context)
        : base(context)
    {
     }
}