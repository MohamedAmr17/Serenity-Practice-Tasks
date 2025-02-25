using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.Default.GovernateRow>;
using MyRow = Serene2.Default.GovernateRow;

namespace Serene2.Default;

public interface IGovernateListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class GovernateListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IGovernateListHandler
{
    public GovernateListHandler(IRequestContext context)
            : base(context)
    {
    }
}