using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene2.hospital.SpecialityRow;

namespace Serene2.hospital;

public interface ISpecialityDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class SpecialityDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISpecialityDeleteHandler
{
    public SpecialityDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}