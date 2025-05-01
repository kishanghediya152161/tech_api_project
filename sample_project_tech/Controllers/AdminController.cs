using Microsoft.AspNetCore.Mvc;
using System.Net;
using tech.Common.ViewModel;
using tech.Services.IServices;

namespace sample_project_tech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBookService _bookService;        
        public AdminController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetStories")]
        public async Task<IActionResult> GetStories([FromQuery] string? key, [FromQuery] string Section, [FromQuery] int? pageNumber, [FromQuery] int? numberOfElements)
        {            
            try
            {
                bookRequest bookRequest = new bookRequest();
                bookRequest.key = key;
                bookRequest.Section = Section;
                bookRequest.pageNumber = pageNumber;
                bookRequest.numberOfElements = numberOfElements;

                var apiResponseModel = await _bookService.GetStoryList(bookRequest);
                if (apiResponseModel.Code == (int)HttpStatusCode.OK)
                {
                    return Ok(apiResponseModel);
                }
                else
                {
                    return BadRequest(apiResponseModel.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
