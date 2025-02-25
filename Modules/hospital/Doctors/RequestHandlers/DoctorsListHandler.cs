using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.hospital.DoctorsRow>;
using MyRow = Serene2.hospital.DoctorsRow;

namespace Serene2.hospital;

public interface IDoctorsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class DoctorsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDoctorsListHandler
{
    public DoctorsListHandler(IRequestContext context)
            : base(context)
    {
    }
}