using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.hospital.MedicalRecordsRow>;
using MyRow = Serene2.hospital.MedicalRecordsRow;

namespace Serene2.hospital;

public interface IMedicalRecordsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class MedicalRecordsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMedicalRecordsListHandler
{
    public MedicalRecordsListHandler(IRequestContext context)
            : base(context)
    {
    }
}