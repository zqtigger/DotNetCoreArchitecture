using DotNetCoreArchitecture.Model;
using System;

namespace DotNetCoreArchitecture.Domain
{
    public class UserLogDomain
    {
        protected internal UserLogDomain
        (
            long userId,
            LogType logType
        )
        {
            UserId = userId;
            LogType = logType;
        }

        public long UserLogId { get; private set; }

        public long UserId { get; private set; }

        public LogType LogType { get; private set; }

        public DateTime DateTime { get; private set; }

        public void Add()
        {
            UserLogId = 0;
            DateTime = DateTime.UtcNow;
        }
    }
}
