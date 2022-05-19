using System.Text.RegularExpressions;
using UnifiedLearningSystem.Domain.Exceptions.TaskUser;

namespace UnifiedLearningSystem.Domain.ValueObjects.TaskUser
{
    public record TaskRepositoriumLink
    {
        private const string ValidWebsiteRegexPattern = "(([\\w]+:)?//)?(([\\d\\w]|%[a-fA-f\\d]{2,2})+(:([\\d\\w]|%[a-fA-f\\d]{2,2})+)?@)" +
                                                        "?([\\d\\w][-\\d\\w]{0,253}[\\d\\w]\\.)+[\\w]{2,63}(:[\\d]+)?(/([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)" +
                                                        "*(\\?(&?([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})=?)*)?(#([-+_~.\\d\\w]|%[a-fA-f\\d]{2,2})*)?";

        public string Value { get; set; }

        public TaskRepositoriumLink()
        {

        }

        public TaskRepositoriumLink(string value)
        {
            if (Regex.Match(value, ValidWebsiteRegexPattern).Success)
            {
                Value = value;
            } else if (string.IsNullOrWhiteSpace(value))
            {
                throw new MissingLinkRepositoryException("Link to repository is required");
            } else
            {
                throw new BrokenRepositoryLinkException("Link to repository should be in form o WWW repository hosted page adress");
            }
        }

        public static implicit operator string(TaskRepositoriumLink taskLink) => taskLink.Value;

        public static implicit operator TaskRepositoriumLink(string value) => new TaskRepositoriumLink(value);
    }
}
