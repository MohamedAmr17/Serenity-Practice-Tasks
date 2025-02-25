using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene2.hospital.DocSpecRow;

namespace Serene2.hospital;

public interface IDocSpecDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class DocSpecDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IDocSpecDeleteHandler
{
    public DocSpecDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}