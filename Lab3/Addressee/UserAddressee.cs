using Itmo.ObjectOrientedProgramming.Lab3.Essences;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee
{
    private readonly IUser _user;

    public UserAddressee(IUser user)
    {
        _user = user;
    }

    public void SendMessage(IMessage message)
    {
        _user.GetMessage(message);
    }
}