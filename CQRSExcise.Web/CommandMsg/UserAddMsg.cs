using MediatR;

namespace CQRSExcise.Web.CommandMsg;

public class UserAddMsg:IRequest<int>
{
    public string UserName { get; set; }
    public string UserAddr { get; set; }
}