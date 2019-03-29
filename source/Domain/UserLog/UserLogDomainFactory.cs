using DotNetCoreArchitecture.Model;

namespace DotNetCoreArchitecture.Domain
{
    public static class UserLogDomainFactory
    {
        public static UserLogDomain Create(AddUserLogModel addUserLogModel)
        {
            return new UserLogDomain
            (
                addUserLogModel.UserId,
                addUserLogModel.LogType
            );
        }
    }
}
