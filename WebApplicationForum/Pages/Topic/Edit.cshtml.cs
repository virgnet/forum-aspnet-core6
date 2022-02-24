using Forum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages.Topic
{
    public class EditModel : PageModel
    {
        private readonly ITopicRepository _repository;

        public EditModel(ITopicRepository repository)
        {
            this._repository = repository;
        }

        public Forum.Domain.Topic topic { get; set; }

        public IActionResult OnGet(Guid id)
        {
            topic = _repository.GetById(id);

            if(topic == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Forum.Domain.Topic topic)
        {
            var item = _repository.Update(topic.TopicId, topic.Title, topic.Description);
            return RedirectToPage("/Index");
        }
    }
}
