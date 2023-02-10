using System.Collections.Generic;

namespace MyFirstApplication.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public double Mark { get; set; }

        public int NumberOfSemesters { get; set; }
        public List<string> Subjects { get; set; }
    }
}