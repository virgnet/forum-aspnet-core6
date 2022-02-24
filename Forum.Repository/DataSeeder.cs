using Forum.Domain;

namespace Forum.Repository
{
    public class DataSeeder
    {
        private readonly ForumDbContext forumDbContext;

        public DataSeeder(ForumDbContext forumDbContext)
        {
            this.forumDbContext = forumDbContext;
        }

        public void Seed()
        {
            //User
            if (!forumDbContext.User.Any())
            {
                var configs = new List<User>(){
                    new () { UserId = Guid.NewGuid(), Name = "Miguel", Username = "miguel", Password = "123"},
                    new () { UserId = Guid.NewGuid(), Name = "Maria", Username = "maria", Password = "123"},
                };
                forumDbContext.User.AddRange(configs);
                forumDbContext.SaveChanges();
            }

            //Topic
            if (!forumDbContext.Topic.Any())
            {
                var user1 = forumDbContext.User.FirstOrDefault(c => c.Username.Equals("miguel"));
                var user2 = forumDbContext.User.FirstOrDefault(c => c.Username.Equals("maria"));

                var configs = new List<Topic>(){
                    new () { TopicId = Guid.NewGuid(), UserId = user1.UserId, Title = "Topic title 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", CreationDate = DateTime.Now},
                    new () { TopicId = Guid.NewGuid(), UserId = user1.UserId, Title = "Topic title 2", Description = "Excepteur sint occaecat cupidatat non proident.", CreationDate = DateTime.Now},
                    new () { TopicId = Guid.NewGuid(), UserId = user2.UserId, Title = "Topic title 3", Description = "Sunt in culpa qui officia deserunt mollit anim id est laborum.", CreationDate = DateTime.Now},
                };
                forumDbContext.Topic.AddRange(configs);
                forumDbContext.SaveChanges();
            }
        }
    }
}
