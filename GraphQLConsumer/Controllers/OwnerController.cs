using GraphQLConsumer.GraphQLConsuming;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerConsumer _consumer;

        public OwnerController(OwnerConsumer consumer)
        {
            _consumer = consumer;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var owners = await _consumer.GetAllOwners();
            return Ok(owners);
        }
    }
}
