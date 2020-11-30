using System;
using System.Collections.Generic;
using VegaIT.Core.MapperInterfaces;
using VegaIT.Core.Models;
using VegaIT.Core.ServiceInterfaces;
using VegaIT.Data.Entities;
using VegaIT.Data.RepositoryInterfaces;

namespace VegaIT.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public List<UserModel> GetAll()
        {
            IEnumerable<UserEntity> users = _userRepository.GetAll();

            List<UserModel> result = _userMapper.ToModel(users);

            return result;
        }

        public UserModel GetById(int id)
        {
            UserEntity user = _userRepository.GetById(id);

            UserModel result = _userMapper.ToModel(user);

            return result;
        }
    }
}
