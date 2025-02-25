using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.Default.CityRow>;
using MyRow = Serene2.Default.CityRow;

namespace Serene2.Default;

public interface ICityRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class CityRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ICityRetrieveHandler
{
    public CityRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}