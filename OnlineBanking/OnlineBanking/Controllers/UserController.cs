using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineBanking.Model;
using System;
using System.Linq;

namespace OnlineBanking.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("AllowHeader")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UserContext _context;

        public object ViewBag { get; private set; }

        public UserController(IConfiguration config,UserContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_context.Users.Where(u => u.Email == user.Email).FirstOrDefault()!=null)
            {
               return Ok("AlreadyExist");
            }
            user.MemberSince = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }





        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = _context.Users.Where(u => u.Email == user.Email && u.pwd == user.pwd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.Userid.ToString(),
                    userAvailable.FullName,
                    userAvailable.MobileNumber,
                    userAvailable.Email,
                    userAvailable.AadharNumber,
                    userAvailable.DateOfBirth,
                    userAvailable.Address,
                    userAvailable.Occupation,
                    userAvailable.AnnualIncome
                    )

                  );

            }
            return Ok("Failure");
        }

        [AllowAnonymous]
        [HttpPost("Adminlogin")]
        public IActionResult Admin(Admin admin)
        {
            var adminAvailable = _context.Admins.Where(u => u.Email == admin.Email && u.pwd == admin.pwd).FirstOrDefault();
            if (adminAvailable != null)
            {


                return Ok("Successfull");

            }
            return Ok("Failure");
        }

        [AllowAnonymous]
        [HttpGet("getAllUsers")]
        public IActionResult getAllUsers(User user)
        {
            var users = _context.Users;
            var result = users.Select(user => new
            {
                user.Userid,
                user.FullName,
                user.MobileNumber,
                user.Email,
                user.AadharNumber,
                user.DateOfBirth,
                user.Address,
                user.AnnualIncome,
                user.Occupation
               
            });
            return Ok(result);
        }

        

        

    }
}
