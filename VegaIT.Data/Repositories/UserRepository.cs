using System;
using System.Collections.Generic;
using System.Linq;
using VegaIT.Data.Entities;
using VegaIT.Data.RepositoryInterfaces;

namespace VegaIT.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VegaMainDbContext _context;

        public UserRepository(VegaMainDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserEntity> GetAll()
        {

            return _context.Set<UserEntity>().AsEnumerable();
        }

        public UserEntity GetById(int id)
        {
            
            return _context.Set<UserEntity>().Find(id);
        }
    }
}
