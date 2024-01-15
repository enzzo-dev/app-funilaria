using BodyShopAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Infra.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(Guid idUser);
        public Task<List<User>> ListUsersAsync(Func<User, User> filter);
        public Task AddAsync(User user);
        public Task UpdateAsync(User userUpdated, Func<User, bool> filter);
        public Task DeleteAsync(Guid idUser);
    }
}
