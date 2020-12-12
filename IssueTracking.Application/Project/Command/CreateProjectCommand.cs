using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Command
{
    public class CreateProjectCommand : ICommand
    {
        public string Name { get; set; }

        public string Key { get; set; }
    }
}
