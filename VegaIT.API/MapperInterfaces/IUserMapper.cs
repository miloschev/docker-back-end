using System;
using System.Collections.Generic;
using VegaIT.API.DTOs;
using VegaIT.Core.Models;

namespace VegaIT.API.MapperInterfaces
{
    public interface IUserMapper
    {
        public GetUserDTO ToDTO(UserModel model);

        public UserModel ToModel(GetUserDTO dto);

        public List<GetUserDTO> ToDTO(List<UserModel> models);

        public List<UserModel> ToModel(List<GetUserDTO> dtos);
    }
}
