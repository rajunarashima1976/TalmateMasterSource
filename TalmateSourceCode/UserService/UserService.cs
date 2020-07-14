using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalmateSourceCode.EntityModel;
using TalmateSourceCode.Models;

namespace TalmateSourceCode.UserService
{
    public class UserService:IUserService
    {
        private readonly TalmateDBContext _talmateDbContext;

        public UserService(TalmateDBContext talmateDbContext)
        {

            _talmateDbContext = talmateDbContext;
        }

        public async Task<UserRolesDTO> Authenticate(string username, string password)
        {

            var user = (from u in _talmateDbContext.Users
                        join ur in _talmateDbContext.UserRoles on u.Id equals ur.UserId
                        join r in _talmateDbContext.Roles on ur.RoleId equals r.Id
                        where u.Username == username && u.Password == password
                        select new UserRolesDTO()
                        {
                            Id = u.Id,
                            Username = u.Username,
                            RoleName = r.Name
                        }).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            return await Task.FromResult(user);

        }

        public async Task<IQueryable<User>> GetAll()
        {
            return await Task.FromResult(_talmateDbContext.Users.AsQueryable());
        }

        public async Task<User> GetById(int id)
        {
            var user = _talmateDbContext.Users.AsQueryable().FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }

    }
}
