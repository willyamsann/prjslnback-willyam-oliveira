using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> baseRepository,IUserRepository userRepository)
        {
            _baseRepository = baseRepository;
            _userRepository = userRepository;
        }

        public User Add<TValidator>(User obj) where TValidator : AbstractValidator<User >
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            obj.Password = GerarMD5(obj.Password);
            _baseRepository.Insert(obj);
            return obj;
        }

        public User GetUser(string email, string password)
        {
            var passwordHash = GerarMD5(password);

            var obj = _userRepository.GetAllAuthentication(email, passwordHash);
            if (obj == null)
                return null;

            return obj;
        }
        private void Validate(User obj, AbstractValidator<User> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        public string GerarMD5(string valor)

        {


            MD5 md5Hasher = MD5.Create();


            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));


            StringBuilder strBuilder = new StringBuilder();


            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }


            return strBuilder.ToString();

        }


    }
}
