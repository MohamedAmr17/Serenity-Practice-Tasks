using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.Default.GovernateRow>;
using MyRow = Serene2.Default.GovernateRow;

namespace Serene2.Default;

public interface IGovernateRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class GovernateRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IGovernateRetrieveHandler
{
    public GovernateRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}