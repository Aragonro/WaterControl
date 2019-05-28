using System;
using WoterCantrol.BLL.DTO;
using WoterCantrol.DAL.Entities;
using WoterCantrol.DAL.Interfaces;
using WoterCantrol.BLL.Infrastructure;
using WoterCantrol.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace WoterCantrol.BLL.Services
{
    class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateUser(UserDTO userDTO)
        {
            var emptyUser = Database.Users.Find(i => i.Email == userDTO.Email).GetEnumerator().Current;
            if(emptyUser != null)
            {
                throw new ValidationException("User is exist with this email", "");
            }
            if (userDTO.Role == null) {
                userDTO.Role = "User";
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            Database.Users.Create(user);
            Database.Save();
        }

        public UserDTO GetUser(string email)
        {
            var user = Database.Users.Find(u => u.Email == email).GetEnumerator().Current;
            if (user == null)
                throw new ValidationException("User isn`t exist with this email or password", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetСouriers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.Find(u => u.Role == "Courier"));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
