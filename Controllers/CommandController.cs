using Microsoft.AspNetCore.Mvc;
using WebApiBackgroudServices.Domain;
using WebApiBackgroudServices.Repository;

namespace WebApiBackgroudServices.Controllers
{
    [ApiController]
    [Route("api/command")]
    public class CommandController : ControllerBase
    {
        private ICommandRepository _commandRepository;

        public CommandController(ICommandRepository commandRepository)
        {
            _commandRepository =  commandRepository;
        }

        [HttpPost]
        public IActionResult SetCommand([FromBody] Message message)
        {
            _commandRepository.SetMessage(message);

            return Ok(_commandRepository.GetMessage());
        }
    }
}