using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.JwtAuth.Models;

namespace WebApi.JwtAuth.Controllers;

/// <summary>
/// Book Controller
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly List<BookModel> _bookModels =
    [
        new BookModel
        {
            Id = Guid.NewGuid().ToString(), BookName = "西游记", Author = "吴承恩", Publisher = "中国文学出版社",
            PublishDate = new DateOnly(2023, 1, 1)
        },
        new BookModel
        {
            Id = Guid.NewGuid().ToString(), BookName = "水浒传", Author = "施耐庵", Publisher = "中国文学出版社",
            PublishDate = new DateOnly(2023, 8, 1)
        },
        new BookModel
        {
            Id = Guid.NewGuid().ToString(), BookName = "三国演义", Author = "罗贯中", Publisher = "中国文学出版社",
            PublishDate = new DateOnly(2023, 10, 1)
        },
        new BookModel
        {
            Id = Guid.NewGuid().ToString(), BookName = "红楼梦", Author = "曹雪芹", Publisher = "中国文学出版社",
            PublishDate = new DateOnly(2023, 6, 1)
        }
    ];

    [HttpGet]
    [Authorize]
    public ActionResult<List<BookModel>> List()
    {
        return Ok(_bookModels);
    }
}