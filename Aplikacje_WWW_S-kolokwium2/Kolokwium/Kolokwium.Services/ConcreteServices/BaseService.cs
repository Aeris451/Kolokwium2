using AutoMapper;
using Kolokwium.DAL;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices;

public abstract class BaseService
{
    protected readonly ApplicationDbContext DbContext = null!;
    protected readonly ILogger Logger = null!;
    protected readonly IMapper Mapper = null!;
    public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
    {
        DbContext = dbContext;
        Logger = logger;
        Mapper = mapper;
    }
}






























/*
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        private UserManager<User> _userManager;

        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            try
            {
                if (addOrUpdateGroupVm == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var groupEntity = Mapper.Map<Group>(addOrUpdateGroupVm);
                if (addOrUpdateGroupVm.Id == null || addOrUpdateGroupVm.Id == 0)
                    DbContext.Groups.Add(groupEntity);
                else
                    DbContext.Groups.Update(groupEntity);

                DbContext.SaveChanges();
                var groupVm = Mapper.Map<GroupVm>(groupEntity);

                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm)
        {
            try
            {
                if (attachStudentToGroupVm == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var student = DbContext.Users.OfType<Student>().FirstOrDefault(t => t.Id == attachStudentToGroupVm.StudentId);
                if (student == null || !_userManager.IsInRoleAsync(student, "Student").Result)
                    throw new ArgumentNullException($"Student is null or user is not student");

                var group = DbContext.Groups.FirstOrDefault(x => x.Id == attachStudentToGroupVm.GroupId);
                if (group == null)
                    throw new ArgumentNullException($"Group is null");

                student.GroupId = group.Id;
                student.Group = group;
                DbContext.SaveChanges();

                var studentVm = Mapper.Map<StudentVm>(student);
                return studentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachSubjectGroupVm)
        {
            try
            {
                if (attachSubjectGroupVm == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachSubjectGroupVm.SubjectId);
                if (subject == null)
                    throw new ArgumentNullException($"Subject is null");

                var group = DbContext.Groups.FirstOrDefault(x => x.Id == attachSubjectGroupVm.GroupId);
                if (group == null)
                    throw new ArgumentNullException($"Group is null");

                if (group.SubjectGroups.FirstOrDefault(sg => sg.SubjectId == attachSubjectGroupVm.SubjectId) != null)
                    throw new ArgumentNullException($"Subject is already added");

                group.SubjectGroups.Add(new SubjectGroup {
                    SubjectId = attachSubjectGroupVm.SubjectId,
                    GroupId = attachSubjectGroupVm.GroupId
                });
                DbContext.SaveChanges();

                var groupVm = Mapper.Map<GroupVm>(group);
                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubject)
        {
            try
            {
                if (attachDetachSubject == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubject.TeacherId);
                if (teacher == null || !_userManager.IsInRoleAsync(teacher, "Teacher").Result)
                    throw new ArgumentNullException($"Teacher is null or user is not teacher");

                var subject = DbContext.Subjects.FirstOrDefault(x => x.Id == attachDetachSubject.SubjectId);
                if (subject == null)
                    throw new ArgumentNullException($"Subject is null");

                subject.TeacherId = teacher.Id;
                subject.Teacher = teacher;
                DbContext.SaveChanges();

                var subjectVm = Mapper.Map<SubjectVm>(subject);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm)
        {
            try
            {
                if (detachStudentToGroupVm == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var student = DbContext.Users.OfType<Student>().FirstOrDefault(t => t.Id == detachStudentToGroupVm.StudentId);
                if (student == null || !_userManager.IsInRoleAsync(student, "Student").Result)
                    throw new ArgumentNullException($"Student is null or user is not student");

                var group = DbContext.Groups.FirstOrDefault(x => x.Id == detachStudentToGroupVm.GroupId);
                if (group == null)
                    throw new ArgumentNullException($"Group is null");

                student.GroupId = null;
                student.Group = null!;
                DbContext.SaveChanges();

                var studentVm = Mapper.Map<StudentVm>(student);
                return studentVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm detachDetachSubject)
        {
            try
            {
                if (detachDetachSubject == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == detachDetachSubject.SubjectId);
                if (subject == null)
                    throw new ArgumentNullException($"Subject is null");

                var group = DbContext.Groups.FirstOrDefault(x => x.Id == detachDetachSubject.GroupId);
                if (group == null)
                    throw new ArgumentNullException($"Group is null");

                var subjectGroupToRemove = group.SubjectGroups.FirstOrDefault(sg => sg.GroupId == detachDetachSubject.GroupId && sg.SubjectId == detachDetachSubject.SubjectId);

                group.SubjectGroups.Remove(subjectGroupToRemove);
                DbContext.SaveChanges();

                var groupVm = Mapper.Map<GroupVm>(group);
                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            try
            {
                if (attachDetachSubjectToTeacherVm == null)
                    throw new ArgumentNullException($"View model parameter is null");

                var teacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubjectToTeacherVm.TeacherId);
                if (teacher == null || !_userManager.IsInRoleAsync(teacher, "Teacher").Result)
                    throw new ArgumentNullException($"Teacher is null or user is not teacher");

                var subject = DbContext.Subjects.FirstOrDefault(x => x.Id == attachDetachSubjectToTeacherVm.SubjectId);
                if (subject == null)
                    throw new ArgumentNullException($"Subject is null");

                subject.TeacherId = null;
                subject.Teacher = null!;
                DbContext.SaveChanges();

                var subjectVm = Mapper.Map<SubjectVm>(subject);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException($" FilterPredicate is null");

                var groupEntity = DbContext.Groups.FirstOrDefault(filterPredicate);
                var groupVm = Mapper.Map<GroupVm>(groupEntity);

                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null)
        {
            try
            {
                var groupEntities = DbContext.Groups.AsQueryable();

                if (filterPredicate != null)
                    groupEntities = groupEntities.Where(filterPredicate);

                var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntities);

                return groupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
*/