 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAPI.Helpers;
using CourseAPI.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsDb = _courseLibraryRepository.GetAuthors();
            var authors = new List<AuthorDto>();

            foreach(var a in authorsDb)
            {
                authors.Add(new AuthorDto()
                {
                    Id = a.Id,
                    Name = $"{a.FirstName} {a.LastName}",
                    MainCategory = a.MainCategory,
                    Age = a.DateOfBirth.GetAge()
                });
            }

            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
