using AutoMapper;
using CourseAPI.Helpers;
using CourseAPI.Models;
using CourseLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                
                .ForMember(
                    e1 => e1.Name,
                    e2 => e2.MapFrom(src => $"{src.FirstName} {src.LastName}")
                )

                .ForMember(
                    e1 => e1.Age,
                    e2 => e2.MapFrom(src => $"{src.DateOfBirth.GetAge()}")
                );

        }
    }
}
