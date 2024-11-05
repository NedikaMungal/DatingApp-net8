using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<IEnumerable> GetMembersAsync(string username);

        Task<IEnumerable> GetMembersAsync();
        Task<AppUser?> GetUserByIdAsync(int id);
        Task<AppUser?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<AppUser>> GetUsersAsync();
  
        Task<bool> SaveAllAsync ();
      
       // Task<MemberDto?> GetMemberAsync(string username, bool isCurrentUser);
        //Task<AppUser?> GetUserByPhotoId(int photoId); 
    }
}