using Forum.Domain;
using Forum.Service;

namespace Forum.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ForumDbContext db;
        public TopicRepository(ForumDbContext db)
        {
            this.db = db;
        }

        public Topic? GetById(Guid id)
        {
            return db.Topic.FirstOrDefault(c => c.TopicId.Equals(id));
        }

        public List<Topic> GetAll()
        {
            return db.Topic.ToList();
        }

        public Topic? Create(Guid userId, string title, string description)
        {
            try
            {
                var item = new Topic();
                item.TopicId = Guid.NewGuid();
                item.UserId = userId;
                item.Title = title;
                item.Description = description;
                item.CreationDate = DateTime.Now;
                db.Topic.Add(item);
                db.SaveChanges();
                return item;
            }
            catch
            {
                return null;
            }
        }

        public Topic? Update(Guid topicId, string title, string description)
        {
            var item = db.Topic.FirstOrDefault(c => c.TopicId.Equals(topicId));
            if (item != null)
            {
                item.Title = title;
                item.Description = description;
                db.Topic.Update(item);
                db.SaveChanges();
            }

            return item;
        }

        public bool Delete(Guid topicId)
        {
            try
            {
                var user = db.Topic.FirstOrDefault(c => c.TopicId.Equals(topicId));
                if (user != null)
                {
                    db.Topic.Remove(user);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
