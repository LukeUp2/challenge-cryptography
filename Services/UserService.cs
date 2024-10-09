using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Criptografia.Api.Dtos;
using Desafio_Criptografia.Api.Models;
using Desafio_Criptografia.Api.Repositories;

namespace Desafio_Criptografia.Api.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserPayment>> GetAll()
        {
            return await _userRepository.ListAll();
        }

        public async Task<UserPayment> GetById(long userId)
        {
            if (userId == 0)
            {
                throw new BadHttpRequestException("Id não fornecido");
            }

            var user = await _userRepository.GetUserById(userId) ?? throw new Exception("Not found");

            return user;
        }

        public async Task<UserPayment> Create(CreateUserDto createUserDto)
        {
            Validate(createUserDto);
            var hashedUserDocument = CryptoService.Hash256(createUserDto.UserDocument);
            var hashedCreditCardToken = CryptoService.Hash256(createUserDto.CreditCardToken);

            UserPayment user = new()
            {
                UserDocument = hashedUserDocument,
                CreditCardToken = hashedCreditCardToken,
                Value = createUserDto.Value,
            };

            try
            {
                var userCreated = await _userRepository.Insert(user);
                return userCreated;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<UserPayment> Update(long userId, PatchUserDto patchUserDto)
        {
            var user = await _userRepository.GetUserById(userId) ?? throw new BadHttpRequestException("Usuário não encontrado");
            if (patchUserDto.Value != null)
            {
                user.Value = (long)patchUserDto.Value;
            }

            if (patchUserDto.CreditCardToken != null)
            {
                var hashedCreditCardToken = CryptoService.Hash256(patchUserDto.CreditCardToken);
                user.CreditCardToken = hashedCreditCardToken;
            }

            if (patchUserDto.UserDocument != null)
            {
                var hashedUserDocument = CryptoService.Hash256(patchUserDto.UserDocument);
                user.UserDocument = hashedUserDocument;
            }

            await _userRepository.Update(user);

            return user;
        }

        public async Task Delete(long userId)
        {
            var user = await _userRepository.GetUserById(userId) ?? throw new BadHttpRequestException("Usuário não encontrado");

            await _userRepository.Delete(user);
        }
        private void Validate(CreateUserDto createUserDto)
        {
            if (createUserDto.UserDocument == string.Empty || createUserDto.CreditCardToken == string.Empty || createUserDto.Value == 0)
            {
                throw new BadHttpRequestException("Dados inválidos");
            }
        }
    }
}