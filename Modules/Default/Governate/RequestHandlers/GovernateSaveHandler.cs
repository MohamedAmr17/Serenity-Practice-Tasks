using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.Default.GovernateRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.Default.GovernateRow;

namespace Serene2.Default;

public interface IGovernateSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class GovernateSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IGovernateSaveHandler
{
    public GovernateSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}