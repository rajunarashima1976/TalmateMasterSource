using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalmateSourceCode.EntityModel;
using TalmateSourceCode.Models;

namespace TalmateSourceCode.UserService
{
    public interface IUserService
    {
        Task<UserRolesDTO> Authenticate(string username, string password);
        Task<IQueryable<User>> GetAll();
        Task<User> GetById(int id);
    }
}
