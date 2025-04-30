using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library.Members;

public static class UserFactory
{
    public static dynamic CreateUser(string role, string email, string password, string name, string lastName)
    {
        return role switch
        {
            "admin" => new Admin(email, password, name, lastName),
            _ => new User(email, password, name, lastName),
        };
    }
}
