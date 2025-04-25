using Microsoft.AspNetCore.Mvc;

namespace ReStore.API.Controllers
{
    [Route("api/[controller]")] //https://localhost:5001/api/products
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
