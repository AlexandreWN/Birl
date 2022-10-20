using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerUser([FromBody] User user){
        var id = user.save();
        if(id == -1){
            return "usuario ja cadastrado";
        }else{
            return new {
                id = user.id,
                nome = user.nome,
                login = user.login,
                senha = user.senha
            };
        }
    }
}