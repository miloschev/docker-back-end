using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VegaIT.Core.ServiceInterfaces;
using VegaIT.API.DTOs;
using VegaIT.API.MapperInterfaces;
using VegaIT.Core.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VegaIT.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;
        private readonly ILogger _logger;

        public UserController(IUserService userService, IUserMapper userMapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _userMapper = userMapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("/user/all")]
        public IEnumerable<GetUserDTO> GetAll()
        {
            var iteration = 4;

            _logger.LogDebug($"Debug {iteration}");
            _logger.LogInformation($"Information {iteration}");
            _logger.LogWarning($"Warning {iteration}");
            _logger.LogError($"Error {iteration}");
            _logger.LogCritical($"Critical {iteration}");

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            List<UserModel> users = _userService.GetAll();

            List<GetUserDTO> response = _userMapper.ToDTO(users);

            return response;
        }

        [HttpGet]
        [Route("/user/byId/{id}")]
        public GetUserDTO GetById(int id)
        {
            var iteration = 4;

            _logger.LogDebug($"Debug {iteration}");
            _logger.LogInformation($"Information {iteration}");
            _logger.LogWarning($"Warning {iteration}");
            _logger.LogError($"Error {iteration}");
            _logger.LogCritical($"Critical {iteration}");

            UserModel user = _userService.GetById(id);

            GetUserDTO response = _userMapper.ToDTO(user);

            return response;
        }
    }
}
