using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Users;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IResimHelper resimHelper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal kullanici;


        public UserService(IUnitOfWork unitOfWork, IResimHelper resimHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager )
        {
            this.unitOfWork = unitOfWork;
            this.resimHelper = resimHelper;
            this.httpContextAccessor = httpContextAccessor;
            kullanici = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<AppUser> AppUserIdGetir(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<List<AppRole>> TümRolesGetirAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserViewModel>> TümRoleVeUserGetirASync()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserViewModel>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }

            return map;
        }

        public async Task<IdentityResult> UserGüncelleAsync(UserGüncellemeViewModel userGüncellemeViewModel)
        {
            var user = await AppUserIdGetir(userGüncellemeViewModel.Id);
            var userRole = await UserRoleGetirAsync(user);

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(userGüncellemeViewModel.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }

        public async Task<IdentityResult> UserOlusturAsync(UserEklemeViewModel userEklemeViewModel)
        {
            var map = mapper.Map<AppUser>(userEklemeViewModel);

            map.UserName = userEklemeViewModel.Email;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userEklemeViewModel.Parola) ? "" : userEklemeViewModel.Parola);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(userEklemeViewModel.RoleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;


        }

        public async Task<UserProfilViewModel> UserProfilGetirAsync()
        {
            var userId = kullanici.GetLoggedInUserId();
            var UserVeResimGetir = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Resim);
            var map = mapper.Map<UserProfilViewModel>(UserVeResimGetir);
            map.Resim.FileName = UserVeResimGetir.Resim.FileName;

            return map;
        }

        public async Task<string> UserRoleGetirAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<(IdentityResult identityResult, string? email)> UserSilAsync(Guid userId)
        {
            var user = await AppUserIdGetir(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return (result, user.Email);
            }
            else return (result, null);
        }
    }
}
