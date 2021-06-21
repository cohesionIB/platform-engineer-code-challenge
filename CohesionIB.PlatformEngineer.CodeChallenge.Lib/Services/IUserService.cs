using CohesionIB.PlatformEngineer.CodeChallenge.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionIB.PlatformEngineer.CodeChallenge.Lib.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
