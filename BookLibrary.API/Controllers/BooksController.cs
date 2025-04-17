using MediatR;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Core.Queries.Books;

namespace BookLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator) => _mediator = mediator;

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string type,
            [FromQuery] string value = "")
        {
            var query = new SearchBooksQuery(type, value);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
