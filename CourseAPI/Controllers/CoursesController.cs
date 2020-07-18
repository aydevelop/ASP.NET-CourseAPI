using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseAPI.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetCoursesForAuthor(Guid authorId)
        {
            var coursesForAuthorFromRepo = _courseLibraryRepository.GetCourses(authorId);
            var res = _mapper.Map<IEnumerable<CourseDto>>(coursesForAuthorFromRepo);

            if (res.Count() == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{courseId}")]
        public IActionResult GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            var course = _courseLibraryRepository.GetCourse(authorId, courseId);
            if (course == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<CourseDto>(course);
            return Ok(res);
        }
    }
}
