using Microsoft.AspNetCore.Identity;

namespace MeMoney.UserIdentity
{
    public class CheckUserIdentity : IdentityUser
    {
        public bool IsMemAuthor { get; set; }

    }
}
