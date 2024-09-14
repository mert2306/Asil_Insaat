using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IUserService
    {
        Task<List<UserViewModel>> TümRoleVeUserGetirASync();
        Task<List<AppRole>> TümRolesGetirAsync();
        Task<AppUser> AppUserIdGetir(Guid userId);

        Task<IdentityResult> UserOlusturAsync(UserEklemeViewModel userEklemeViewModel);

        Task<IdentityResult> UserGüncelleAsync(UserGüncellemeViewModel userGüncellemeViewModel);

        Task<string> UserRoleGetirAsync(AppUser user);

        Task<UserProfilViewModel> UserProfilGetirAsync();

        Task<(IdentityResult identityResult, string? email)> UserSilAsync(Guid userId);



    }
}
