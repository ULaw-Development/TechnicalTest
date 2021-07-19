using System;
using Ulaw.ApplicationProcessor.Models;
using ULaw.ApplicationProcessor.Enums;

namespace ULaw.ApplicationProcessor.Models
{
    public class ApplicationModel
    {

        public ApplicationModel( string faculty, string courseCode, DateTime startDate, UserModel user )
        {
            ApplicationId = new Guid();
            Faculty = faculty;
            CourseCode = courseCode;
            StartDate = startDate;
            User = user;
        }
        public Guid ApplicationId { get; private set; }
        public UserModel User { get; set; }
        public string Faculty { get; set; }
        public string CourseCode { get; set; }
        public DateTime StartDate { get; set; }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }
    }
}

