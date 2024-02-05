using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.Domain;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService userQueryService;
        private readonly ICreateUserCommand createUserCommand;

        public UserController(IUserQueryService userQueryService, ICreateUserCommand createUserCommand)
        {
            this.userQueryService = userQueryService;
            this.createUserCommand = createUserCommand;
        }



        //http://localhost:5149/swagger/index.html
        [HttpGet()]
        public async Task<ActionResult<UserModel>> Get() => Ok(await this.userQueryService.Get());

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            return Ok(await this.createUserCommand.Create(userModel));
        }
    }
}
