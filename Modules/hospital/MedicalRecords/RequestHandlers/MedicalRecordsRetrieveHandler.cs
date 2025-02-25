using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.hospital.MedicalRecordsRow>;
using MyRow = Serene2.hospital.MedicalRecordsRow;

namespace Serene2.hospital;

public interface IMedicalRecordsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class MedicalRecordsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMedicalRecordsRetrieveHandler
{
    public MedicalRecordsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}