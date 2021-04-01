using System.Collections.Generic;

namespace Common.Account
{
    public class UserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Identifier { get; set; }
    }
}
