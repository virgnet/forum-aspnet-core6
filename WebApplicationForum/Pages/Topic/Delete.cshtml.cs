using Forum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages.Topic
{
    public class DeleteModel : PageModel
    {
        private readonly ITopicRepository _repository;

        public DeleteModel(ITopicRepository repository)
        {
            this._repository = repository;
        }

        public Forum.Domain.Topic topic { get; set; }

        public IActionResult OnGet(Guid id)
        {
            topic = _repository.GetById(id);

            if (topic == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Forum.Domain.Topic topic)
        {
            var item = _repository.Delete(topic.TopicId);
            if(item)
                return RedirectToPage("/Index");
            else
                return RedirectToPage("/Error");
        }
    }
}
