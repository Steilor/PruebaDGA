using ClnArq.Application.Dtos;
using ClnArq.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClnArq.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(JwtSettings _jwtSettings,
    UserManager<ApplicationUser> _userManager) : ControllerBase
{
    

 
}
