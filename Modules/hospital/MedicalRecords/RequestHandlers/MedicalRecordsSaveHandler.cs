using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.hospital.MedicalRecordsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.hospital.MedicalRecordsRow;

namespace Serene2.hospital;

public interface IMedicalRecordsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class MedicalRecordsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMedicalRecordsSaveHandler
{
    public MedicalRecordsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}