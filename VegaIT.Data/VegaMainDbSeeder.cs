using System;
using System.Collections.Generic;
using System.Linq;
using VegaIT.Data.Entities;

namespace VegaIT.Data
{
    public static class VegaMainDbSeeder
    {
        public static void EnsureSeedUserData(this VegaMainDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<UserEntity>
                {
                    new UserEntity {
                        FirstName = "Luka",
                        LastName = "Vuckovic",
                        Username = "l.vuckovic",
                        Email = "luka@gmail.com",
                        Password = "secret"
                    },
                    new UserEntity {
                        FirstName = "Nikola",
                        LastName = "Vucetic",
                        Username = "n.vucetic",
                        Email = "nikola@gmail.com",
                        Password = "secret"
                    },
                    new UserEntity {
                        FirstName = "Boris",
                        LastName = "Bibic",
                        Username = "b.bibic",
                        Email = "boris@gmail.com",
                        Password = "secret"
                    },
                    new UserEntity {
                        FirstName = "Zarko",
                        LastName = "Milosev",
                        Username = "z.milosev",
                        Email = "zarko@gmail.com",
                        Password = "secret"
                    }
                };

                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
