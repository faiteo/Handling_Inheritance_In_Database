using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handling_Inheritance_In_Database.ModelLayer
{
    public class FitnessClass
    {
        private int classID;

        public int ClassID
        {
            get { return classID; }
            set { classID = value; }
        }
        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        private string instructorName;

        public string InstructorName
        {
            get { return instructorName; }
            set { instructorName = value; }
        }
        private string classTime;

        public string ClassTime
        {
            get { return classTime; }
            set { classTime = value; }
        }
        private string classDate;

        public string ClassDate
        {
            get { return classDate; }
            set { classDate = value; }
        }

    }
}
