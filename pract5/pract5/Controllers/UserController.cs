using Microsoft.AspNetCore.Mvc;
using pract5.Models;

namespace pract5.Controllers;
[ApiController]
[Route("users")]

public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        var users = new List<User>()
        {
            new User()
            { 
                Id = 1,
                Nickname="user1",
                Password = "user123",
                DateOfBirth ="12.03.2001",
                Description="User1"
            },
             new User()
            {
                Id = 2,
                Nickname="user2",
                Password = "user456",
                DateOfBirth ="09.06.2003",
                Description="User2"
            },
    };
        return Ok(users);
        }

    [HttpGet("{Nickname}")]
    public ActionResult<User> GetUsersByNickname([FromRoute] string Nickname)
    {
        var user = new User() {
            Id = 3,
            Nickname = Nickname,
            Password = "user456",
            DateOfBirth = "09.06.2003",
            Description = "User2"
        };
        return Ok(user);
    }
    [HttpPost]
    public ActionResult<User> AddUser([FromBody] User user)
    {
        user.Id = new Random().Next(1, 1000000);
        return Created($"/users/{user.Id}", user);
    }
}

