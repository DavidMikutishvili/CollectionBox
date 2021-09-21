using CollectionBoxWebApi.DataLayer.Authentication;
using CollectionBoxWebApi.DataLayer.DTO;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using CollectionBoxWebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sentry;
using System;

namespace CollectionBoxWebApi.Controllers
{
    /*
     * https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-5.0
     * Controller or ControllerBase ?
     */

    [Route(template:"api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost(template:"register")]
        public IActionResult Register(RegisterDto dto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = dto.Name,
                Email = dto.Email
                //Password = BCrypt...
            };

            return Created("success", _repository.CreateUser(user));
        }

        [HttpPost(template: "login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(error: new { message = "Invalid Credentials" });
            }

            //if (31:00 verify password)
            //{

            //}
            var userId = user.Id.ToString();
            var jwt = _jwtService.Generate(userId);

            //Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
            //{
            //    HttpOnly = true
            //});

            //return Ok(new
            //{
            //    jwt
            //});
            return Ok(new
            {
                token = jwt
            });
        }

        [HttpGet(template: "user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies;

                var token = _jwtService.Verify("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MzE4MjYwMDAsImlzcyI6IjcyMDQ3NmI3LTZlMjktNDgwZi04NWJiLWY1OWVhYzAwNGRhMCJ9.bfW2NGB0_MqdMGgzcA5if0HoGt1DYDcLrRsvGdgmf7g");

                string userId = token.Issuer;

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost(template:"logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(key: "jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}
