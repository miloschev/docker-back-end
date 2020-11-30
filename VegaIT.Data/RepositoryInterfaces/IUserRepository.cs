using System;
using System.Collections.Generic;
using VegaIT.Data.Entities;

namespace VegaIT.Data.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public IEnumerable<UserEntity> GetAll();

        public UserEntity GetById(int id);
    }
}
