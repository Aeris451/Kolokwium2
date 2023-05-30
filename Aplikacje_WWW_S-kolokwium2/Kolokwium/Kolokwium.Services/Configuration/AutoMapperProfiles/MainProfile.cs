﻿using AutoMapper;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        //AutoMapper maps

    }
}





























/*
using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Services.Configuration.AutoMapperProfiles;

public class MainProfile : Profile
{
    public MainProfile()
    {
        // AutoMapper maps
        CreateMap<Subject, SubjectVm>()
            .ForMember(dest => dest.TeacherName,
                        x => x.MapFrom(src => src.Teacher == null ? null
                        : $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.SubjectGroups.Select(y => y.Group)));

        CreateMap<AddOrUpdateSubjectVm, Subject>();
        CreateMap<SubjectVm, AddOrUpdateSubjectVm>();

        CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Students, x => x.MapFrom(src => src.Students))
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.SubjectGroups.Select(s => s.Subject)));

        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group == null ? null : src.Group.Name))
            .ForMember(dest => dest.ParentName,
                        x => x.MapFrom(src => src.Parent == null ? null
                        : $"{src.Parent.FirstName} {src.Parent.LastName}"));

        CreateMap<Teacher, TeacherVm>()
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.Subjects));

        CreateMap<Grade, GradeVm>()
            .ForMember(dest => dest.SubjectName,
                        x => x.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.StudentName,
                        x => x.MapFrom(src => src.Student == null ? null
                        : $"{src.Student.FirstName} {src.Student.LastName}"));

        CreateMap<AddGradeToStudentVm, Grade>();
        CreateMap<GradeVm, AddGradeToStudentVm>();

        CreateMap<List<Grade>, GradesReportVm>()
            .ForMember(dest => dest.Grades, x => x.MapFrom(src => src));

        CreateMap<AddOrUpdateGroupVm, Group>();
        CreateMap<GroupVm, AddOrUpdateGroupVm>();

        CreateMap<RegisterNewUserVm, User>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));

        CreateMap<RegisterNewUserVm, Parent>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));

        CreateMap<RegisterNewUserVm, Student>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));

        CreateMap<RegisterNewUserVm, Teacher>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Title, y => y.MapFrom(src => src.TeacherTitles));
    }
}

*/