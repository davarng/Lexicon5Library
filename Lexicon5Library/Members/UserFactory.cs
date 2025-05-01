using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library.Members;

public static class UserFactory
{
    //Dynamic Factory method to create a User or Admin based on the role.
    //The method is dynamic to allow for the return value to be of the correct reference type.
    public static dynamic CreateUser(string role, string email, string password, string name, string lastName)
    {
        //Checks if the role is null or empty and sets it to "user" by default.
        return role switch
        {
            "admin" => new Admin(email, password, name, lastName),
            _ => new User(email, password, name, lastName),
        };
    }
}
