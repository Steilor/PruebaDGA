using ClnArq.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClnArq.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(JwtSettings _jwtSettings,
    UserManager<ApplicationUser> _userManager) : ControllerBase
{
    

 
}
