using MyRequest = Serene2.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene2.Administration.UserRow>;
using MyRow = Serene2.Administration.UserRow;

namespace Serene2.Administration;
public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
{
    public UserListHandler(IRequestContext context)
         : base(context)
    {
    }
}