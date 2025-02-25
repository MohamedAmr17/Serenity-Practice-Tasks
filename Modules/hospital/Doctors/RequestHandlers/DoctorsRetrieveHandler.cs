using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.hospital.DoctorsRow>;
using MyRow = Serene2.hospital.DoctorsRow;

namespace Serene2.hospital;

public interface IDoctorsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class DoctorsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDoctorsRetrieveHandler
{
    public DoctorsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}