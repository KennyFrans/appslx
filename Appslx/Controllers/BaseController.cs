using System.Threading.Tasks;
using Appslx.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Appslx.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private async Task<User> GetCurrentUserAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                await _signInManager.SignOutAsync();
                return null;
            }

            return user;
        }

        protected User CurrentUser()
        {
            return GetCurrentUserAsync().Result;
        }

        protected bool IsUserAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}