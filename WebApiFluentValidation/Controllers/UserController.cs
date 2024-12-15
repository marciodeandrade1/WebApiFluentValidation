using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiFluentValidation.Models;

namespace WebApiFluentValidation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IValidator<UserRegistrationRequest> _validator;

        // Injeção do Validator
        public UserController(IValidator<UserRegistrationRequest> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegistrationRequest request)
        {
            // Validação com FluentValidation
            var validationResult = _validator.Validate(request);

            // Verifica se a validação falhou
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Message = e.ErrorMessage
                    })
                });
            }

            // Lógica do registro (exemplo)
            return Ok(new { Message = "Usuário registrado com sucesso!" });
        }
    }
}
