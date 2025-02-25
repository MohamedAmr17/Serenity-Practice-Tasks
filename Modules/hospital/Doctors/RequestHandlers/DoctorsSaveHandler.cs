using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.hospital.DoctorsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.hospital.DoctorsRow;

namespace Serene2.hospital;

public interface IDoctorsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class DoctorsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDoctorsSaveHandler
{
    public DoctorsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}