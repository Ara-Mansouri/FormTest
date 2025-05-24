using FormTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTest.Core.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByEmailAndPassword(string email, string password);
        User? GetByEmail(string email);
    }


}
