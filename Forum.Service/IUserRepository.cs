using Forum.Domain;

namespace Forum.Service
{
    public interface IUserRepository
    {
        User? SignIn(string user, string password);
    }
}
