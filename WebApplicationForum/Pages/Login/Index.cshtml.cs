using Forum.Domain;
using Forum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages.Login
{
    public class IndexModel : PageModel
    {

        private readonly IUserRepository _repository;

        public IndexModel(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User user { get; set; }
        public Guid userId { get; set; }
        public string userName { get; set; }

        public void OnGet(User user)
        {
            if (HttpContext.Session.Get("UserId") != null)
            {
                userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
                userName = HttpContext.Session.GetString("UserName");
            }
        }

        public IActionResult? OnPost(User user)
        {
            var loginUser = _repository.SignIn(user.Username, user.Password);
            
            if (loginUser != null)
            {
                HttpContext.Session.SetString("UserId", loginUser.UserId.ToString());
                HttpContext.Session.SetString("UserName", loginUser.Name);
                return RedirectToPage("/Index");
            }

            return null;
        }
    }
}
