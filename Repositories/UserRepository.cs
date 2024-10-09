using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Criptografia.Api.Data;
using Desafio_Criptografia.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Criptografia.Api.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<UserPayment>> ListAll()
        {
            var users = await _context.UserPayments.ToListAsync();
            return users;
        }

        public async Task<UserPayment?> GetUserById(long id)
        {
            var user = await _context.UserPayments.FindAsync(id);
            return user;
        }

        public async Task<UserPayment> Insert(UserPayment userPayment)
        {
            await _context.UserPayments.AddAsync(userPayment);
            await _context.SaveChangesAsync();

            return userPayment;
        }

        public async Task Update(UserPayment user)
        {
            _context.UserPayments.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(UserPayment user)
        {
            _context.UserPayments.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}