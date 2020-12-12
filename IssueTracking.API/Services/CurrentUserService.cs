using System;
using System.Security.Claims;
using IssueTracking.Application.Interfaces;
using IssueTracking.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IssueTracking.API.Services
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor ,UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public Guid UserId =>Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));

        public string UserEmail=> _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
        public User User => _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
    }
}
