using Forum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationForum.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ITopicRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        private readonly ITopicRepository _repository;

        public List<Forum.Domain.Topic> TopicList { get; set; }
        public Guid userId { get; set; }
        public string userName { get; set; }


        public void OnGet()
        {
            if (HttpContext.Session.Get("UserId") != null)
            {
                userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
                userName = HttpContext.Session.GetString("UserName");
            }
            TopicList = _repository.GetAll();
        }
    }
}