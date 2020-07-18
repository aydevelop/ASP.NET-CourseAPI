 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public IActionResult GetAuthors(string mainCategory, string searchQuery)
        {
            var authorsDb = _courseLibraryRepository.GetAuthors();
            if (!String.IsNullOrWhiteSpace(mainCategory))
            {
                authorsDb = _courseLibraryRepository.GetAuthors(mainCategory);
            }

            var res = _mapper.Map<IEnumerable<AuthorDto>>(authorsDb);
            return Ok(res);
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
