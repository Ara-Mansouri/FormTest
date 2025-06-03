using FormTest.Core.Domain.Entities;

namespace FormTest.Core.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByEmailAndPassword(string email, string password);
        User? GetByEmail(string email);
    }


}
