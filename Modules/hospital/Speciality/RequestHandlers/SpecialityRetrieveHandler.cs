using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene2.hospital.SpecialityRow>;
using MyRow = Serene2.hospital.SpecialityRow;

namespace Serene2.hospital;

public interface ISpecialityRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class SpecialityRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISpecialityRetrieveHandler
{
    public SpecialityRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}