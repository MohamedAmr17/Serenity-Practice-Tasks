using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.hospital.DocSpecRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.hospital.DocSpecRow;

namespace Serene2.hospital;

public interface IDocSpecSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class DocSpecSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDocSpecSaveHandler
{
    public DocSpecSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}