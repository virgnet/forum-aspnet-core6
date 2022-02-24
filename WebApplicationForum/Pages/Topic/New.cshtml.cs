using Forum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages.Topic
{
    public class NewModel : PageModel
    {
        private readonly ITopicRepository _repository;

        public NewModel(ITopicRepository repository)
        {
            this._repository = repository;
        }

        public Forum.Domain.Topic topic { get; set; }

        public Guid userId { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Forum.Domain.Topic topic)
        {
            if (HttpContext.Session.Get("UserId") != null)
            {
                userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
            }

            var item = _repository.Create(userId, topic.Title, topic.Description);
            return RedirectToPage("/Index");
        }
    }
}
