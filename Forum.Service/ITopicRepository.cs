using Forum.Domain;

namespace Forum.Service
{
    public interface ITopicRepository
    {
        Topic? GetById(Guid id);
        List<Topic> GetAll();
        Topic? Create(Guid userId, string title, string description);
        Topic? Update(Guid topicId, string title, string description);
        bool Delete(Guid id);
    }
}