using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.hospital.SpecialityRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.hospital.SpecialityRow;

namespace Serene2.hospital;

public interface ISpecialitySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class SpecialitySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISpecialitySaveHandler
{
    public SpecialitySaveHandler(IRequestContext context)
            : base(context)
    {
    }
}