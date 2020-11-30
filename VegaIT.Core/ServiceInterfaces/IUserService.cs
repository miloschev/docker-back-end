using System;
using System.Collections.Generic;
using VegaIT.Core.Models;

namespace VegaIT.Core.ServiceInterfaces
{
    public interface IUserService
    {
        public List<UserModel> GetAll();

        public UserModel GetById(int id);
    }
}
