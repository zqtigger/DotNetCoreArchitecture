using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class UserLogApplicationService : BaseApplicationService, IUserLogApplicationService
    {
        public UserLogApplicationService
        (
            IDatabaseUnitOfWork databaseUnitOfWork,
            IUserLogRepository userLogRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            UserLogRepository = userLogRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private IUserLogRepository UserLogRepository { get; }

        public async Task AddAsync(AddUserLogModel addUserLogModel)
        {
            var validation = new AddUserLogModelValidator().Valid(addUserLogModel);

            if (!validation.Success) { return; }

            var userLogDomain = UserLogDomainFactory.Create(addUserLogModel);

            userLogDomain.Add();

            var userLogEntity = UserLogEntityFactory.Create(userLogDomain);

            await UserLogRepository.AddAsync(userLogEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();
        }
    }
}
