using Forum.Domain;
using Forum.Service;

namespace Forum.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext db;
        public UserRepository(ForumDbContext db)
        {
            this.db = db;
        }
        public User? SignIn(string user, string password)
        {
            return db.User.FirstOrDefault(c => c.Username.Equals(user) && c.Password.Equals(password));
        }
    }
}
