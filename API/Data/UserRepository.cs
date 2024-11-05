using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace API.Data
{
    public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
    {
        public void Update(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
        public async Task<MemberDto?> GetMemberAsync(string username)
        {
            return await context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
             return await context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public Task<AppUser?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<AppUser?> GetUserByUsernameAsync(string username)
        {
            return await context.Users
                .Include(x => x.Photos)
                .SingleOrDefaultAsync(x=>x.UserName == username);
        }
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
               return await context.Users
                .Include(x => x.Photos)
                .ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
            
        }

        public Task<IEnumerable> GetMembersAsync(string username)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable> IUserRepository.GetMembersAsync()
        {
            throw new NotImplementedException();
        }
    }
}