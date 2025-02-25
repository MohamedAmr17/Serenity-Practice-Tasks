using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene2.Default.GovernateRow;

namespace Serene2.Default;

public interface IGovernateDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class GovernateDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IGovernateDeleteHandler
{
    public GovernateDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}