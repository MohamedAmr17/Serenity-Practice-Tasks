using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene2.hospital.MedicalRecordsRow;

namespace Serene2.hospital;

public interface IMedicalRecordsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class MedicalRecordsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IMedicalRecordsDeleteHandler
{
    public MedicalRecordsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}