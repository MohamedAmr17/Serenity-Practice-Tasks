using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.Default.CityRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.Default.CityRow;

namespace Serene2.Default;

public interface ICitySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class CitySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ICitySaveHandler
{
    public CitySaveHandler(IRequestContext context)
            : base(context)
    {
    }
}