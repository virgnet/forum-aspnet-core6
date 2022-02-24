using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages.Login
{
    public class LogOffModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserName");
        }
    }
}
