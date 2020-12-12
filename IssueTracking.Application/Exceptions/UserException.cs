using System;
using JetBrains.Annotations;

namespace IssueTracking.Application.Exceptions
{
    public class UserException:Exception
    {
        public const string DefaultMessage = "Sorry something wrong please try again !!!";


        public UserException()
            : this(DefaultMessage)
        {
        }

        public UserException([NotNull] string message)
            : base(message)
        {
        }
    }
}
