using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProtobufPOC.DTOs;

namespace ProtobufPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [FormatFilter]
        public ActionResult<ResponseDTO> Get()
        {
            var result = new ResponseDTO() {
                Elements = new List<string>() {
                    "Appel",
                    "Tomato",
                    "Chicken"
                }
            };

            return result;
        }
    }
}
