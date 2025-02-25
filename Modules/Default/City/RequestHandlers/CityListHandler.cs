using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.Default.CityRow>;
using MyRow = Serene2.Default.CityRow;

namespace Serene2.Default;

public interface ICityListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class CityListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ICityListHandler
{
    public CityListHandler(IRequestContext context)
            : base(context)
    {
    }
}