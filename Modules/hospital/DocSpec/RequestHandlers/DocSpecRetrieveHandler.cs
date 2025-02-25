using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.hospital.DocSpecRow>;
using MyRow = Serene2.hospital.DocSpecRow;

namespace Serene2.hospital;

public interface IDocSpecRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class DocSpecRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDocSpecRetrieveHandler
{
    public DocSpecRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}