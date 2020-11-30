using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VegaIT.Core.MapperInterfaces;
using VegaIT.Core.Models;
using VegaIT.Data.Entities;

namespace VegaIT.Core.Mappers
{
    public class UserMapper : IUserMapper
    {
        private ILogger<UserMapper> @object;

        public UserMapper(ILogger<UserMapper> @object)
        {
            this.@object = @object;
        }

        public UserEntity ToEntity(UserModel model)
        {
            UserEntity entity = new UserEntity();

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Email = model.Email;
            entity.Phone = model.Phone;

            return entity;
        }

        public UserModel ToModel(UserEntity entity)
        {
            UserModel model = new UserModel();

            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Email = entity.Email;
            model.Phone = entity.Phone;

            return model;
        }

        public List<UserModel> ToModel(IEnumerable<UserEntity> entities)
        {
            List<UserModel> models = new List<UserModel>();

            foreach(UserEntity entity in entities)
            {
                models.Add(ToModel(entity));
            }

            return models;
        }

        public IEnumerable<UserEntity> ToEntity(List<UserModel> models)
        {
            List<UserEntity> entities = new List<UserEntity>();

            foreach(UserModel model in models)
            {
                entities.Add(ToEntity(model));
            }

            return entities;
        }
    }
}
