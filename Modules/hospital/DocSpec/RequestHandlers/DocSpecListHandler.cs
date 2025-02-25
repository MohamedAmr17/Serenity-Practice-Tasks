using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.hospital.DocSpecRow>;
using MyRow = Serene2.hospital.DocSpecRow;

namespace Serene2.hospital;

public interface IDocSpecListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class DocSpecListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDocSpecListHandler
{
    public DocSpecListHandler(IRequestContext context)
            : base(context)
    {
    }
}