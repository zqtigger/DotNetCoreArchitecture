using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserApplicationService userApplicationService)
        {
            UserApplicationService = userApplicationService;
        }

        private IUserApplicationService UserApplicationService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserModel addUserModel)
        {
            var result = await UserApplicationService.AddAsync(addUserModel);

            return new DefaultResult(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            var result = await UserApplicationService.DeleteAsync(userId);

            return new DefaultResult(result);
        }

        [HttpGet("Grid")]
        public async Task<PagedList<UserModel>> GridAsync([FromQuery]PagedListParameters parameters)
        {
            return await UserApplicationService.ListAsync(parameters);
        }

        [HttpPatch("{userId}/Inactivate")]
        public async Task<IActionResult> InactivateAsync(long userId)
        {
            var result = await UserApplicationService.InactivateAsync(userId);

            return new DefaultResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await UserApplicationService.ListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<UserModel> SelectAsync(long userId)
        {
            return await UserApplicationService.SelectAsync(userId);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            var result = await UserApplicationService.SignInJwtAsync(signInModel);

            return new DefaultResult(result);
        }

        [HttpPost("SignOut")]
        public Task SignOutAsync()
        {
            var signOutModel = new SignOutModel(User.Id());

            return UserApplicationService.SignOutAsync(signOutModel);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long userId, UpdateUserModel updateUserModel)
        {
            updateUserModel.UserId = userId;

            var result = await UserApplicationService.UpdateAsync(updateUserModel);

            return new DefaultResult(result);
        }
    }
}
