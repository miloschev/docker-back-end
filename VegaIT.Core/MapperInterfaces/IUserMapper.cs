using System;
using System.Collections.Generic;
using VegaIT.Core.Models;
using VegaIT.Data.Entities;

namespace VegaIT.Core.MapperInterfaces
{
    public interface IUserMapper
    {
        public UserModel ToModel(UserEntity entity);

        public UserEntity ToEntity(UserModel model);

        public List<UserModel> ToModel(IEnumerable<UserEntity> entities);

        public IEnumerable<UserEntity> ToEntity(List<UserModel> models);
    }
}
