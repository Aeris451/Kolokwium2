using Microsoft.AspNetCore.Identity;

namespace Kolokwium.Model.DataModels;

public class User : IdentityUser<int>
{

}



























/*
namespace SchoolRegister.Model.DataModels;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Student : User {
    public virtual Group Group {get; set;}  = null!;
    public int? GroupId {get; set;}

    public virtual IList<Grade> Grades {get; set;} = new List<Grade>();

    public virtual Parent Parent {get; set;} = null!;
    public int? ParentId {get; set;}

    [NotMapped]
    public double AverageGrade { 
        get {
            if (Grades.Count > 0) {
                return ((double)Grades.Sum(x => (int)x.GradeValue) / (double)Grades.Count);
            }
            return -1;
        } 
    }

    [NotMapped]
    public IDictionary<string, double> AverageGradePerSubject { 
        get {
            var dict = new Dictionary<string, double>();

            foreach(var g in Grades) {
                if (!dict.ContainsKey(g.Subject.Name)) {
                    double avg = Grades.Where(gr => gr.Subject.Name == g.Subject.Name).Sum(gr => (int)gr.GradeValue) / (double)Grades.Count(gr => gr.Subject.Name == g.Subject.Name);
                    dict.Add(g.Subject.Name, avg);
                }
            }

            return dict;
        }
    }
    
    [NotMapped]
    public IDictionary<string, List<GradeScale>> GradesPerSubject { 
        get {
            var dict = new Dictionary<string, List<GradeScale>>();

            foreach(var g in Grades) {
                if (!dict.ContainsKey(g.Subject.Name)) {
                    var gradeList = Grades.Where(gr => gr.Subject.Name == g.Subject.Name).Select(gr => gr.GradeValue).ToList();
                    dict.Add(g.Subject.Name, gradeList);
                }
            }

            return dict;
        }
     }

    public Student() {
        
    }
}

*/