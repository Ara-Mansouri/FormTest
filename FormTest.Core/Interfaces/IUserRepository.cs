using FormTest.Core.Entities;

namespace FormTest.Core.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByEmailAndPassword(string email, string password);
        User? GetByEmail(string email);
    }


}
