using System;
using System.Collections.Generic;
using VegaIT.API.DTOs;
using VegaIT.API.MapperInterfaces;
using VegaIT.Core.Models;

namespace VegaIT.API.Mappers
{
    public class UserMapper : IUserMapper
    {
        public GetUserDTO ToDTO(UserModel model)
        {
            GetUserDTO dto = new GetUserDTO();

            dto.FirstName = model.FirstName;
            dto.LastName = model.LastName;
            dto.Username = model.Username;

            return dto;
        }

        public UserModel ToModel(GetUserDTO dto)
        {
            UserModel model = new UserModel();

            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.Username = dto.Username;

            return model;
        }

        public List<GetUserDTO> ToDTO(List<UserModel> models)
        {
            List<GetUserDTO> dtos = new List<GetUserDTO>();

            foreach (UserModel model in models)
            {
                dtos.Add(ToDTO(model));
            }

            return dtos;
        }

        public List<UserModel> ToModel(List<GetUserDTO> dtos)
        {
            List<UserModel> models = new List<UserModel>();

            foreach (GetUserDTO dto in dtos)
            {
                models.Add(ToModel(dto));
            }

            return models;
        }
    }
}
