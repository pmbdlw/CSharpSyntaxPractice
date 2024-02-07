using MediatR;
namespace CQRSExcise.Web.CommandMsg;

public class UserAddMsgHandler:IRequestHandler<UserAddMsg,int>
{
    public Task<int> Handle(UserAddMsg request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"User has been added! UserName: {request.UserName},Address:{request.UserAddr}");
        return Task.FromResult(1);
    }
}