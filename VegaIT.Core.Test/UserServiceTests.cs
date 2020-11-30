using System.Collections.Generic;
using VegaIT.Core.Mappers;
using VegaIT.Core.Models;
using VegaIT.Core.Services;
using VegaIT.Data.RepositoryInterfaces;
using Xunit;
using Moq;
using System.Threading.Tasks;
using VegaIT.Data.Entities;
using Microsoft.Extensions.Logging;

namespace VegaIT.Core.Test
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly UserMapper _userMapper;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<ILogger<UserMapper>> _loggerMock = new Mock<ILogger<UserMapper>>();

        public UserServiceTests()
        {
            // Initialize
            _userMapper = new UserMapper(_loggerMock.Object);
            _userService = new UserService(_userRepositoryMock.Object, _userMapper);

            // Arrange
            UserEntity user1 = new UserEntity("John", "Doe", "j.doe", "j.doe@gmail.com", "p@ssw0rd", "011-444-000");
            UserEntity user2 = new UserEntity("Clark", "Kent", "c.kent", "c.kent@gmail.com", "p@ssw0rd", "011-444-000");

            List<UserEntity> users = new List<UserEntity>();

            users.Add(user1);
            users.Add(user2);

            //List<UserEntity> users = new List<UserEntity>
            //{
            //    new UserEntity {
            //            FirstName = "Luka",
            //            LastName = "Vuckovic",
            //            Username = "l.vuckovic",
            //            Email = "luka@gmail.com",
            //            Password = "secret"
            //        },
            //        new UserEntity {
            //            FirstName = "Nikola",
            //            LastName = "Vucetic",
            //            Username = "n.vucetic",
            //            Email = "nikola@gmail.com",
            //            Password = "secret"
            //        },
            //        new UserEntity {
            //            FirstName = "Boris",
            //            LastName = "Bibic",
            //            Username = "b.bibic",
            //            Email = "boris@gmail.com",
            //            Password = "secret"
            //        },
            //        new UserEntity {
            //            FirstName = "Zarko",
            //            LastName = "Milosev",
            //            Username = "z.milosev",
            //            Email = "zarko@gmail.com",
            //            Password = "secret"
            //        }
            //};

            // Mock
            _userRepositoryMock.Setup(x => x.GetAll()).Returns(users);
            _userRepositoryMock.Setup(x => x.GetById(1)).Returns(user1);
        }

        //test poziva getAll funkciju iz klase userService i 
        //proverava da li je funkcija vratila 2 korisnika
        [Fact]
        public async Task GetAll_validInput_CountTwo()
        {
            // Act
            List<UserModel> users = _userService.GetAll();

            // Assert
            Assert.Equal(2, users.Count);
        }

        //test poziva funkciju getById iz UserService klase, prosledjuje joj id=1 i 
        //proverava da li je funkcija vratila dobrog korisnika
        [Fact]
        public async Task GetById_validInput_FirstNameJohnLastNameDoe()
        {
            // Act
            UserModel users = _userService.GetById(1);

            // Assert
            Assert.Equal("John", users.FirstName);
            Assert.Equal("Doe", users.LastName);
        }
    }
}
