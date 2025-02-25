using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.hospital.SpecialityRow>;
using MyRow = Serene2.hospital.SpecialityRow;

namespace Serene2.hospital;

public interface ISpecialityListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class SpecialityListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISpecialityListHandler
{
    public SpecialityListHandler(IRequestContext context)
            : base(context)
    {
    }
}