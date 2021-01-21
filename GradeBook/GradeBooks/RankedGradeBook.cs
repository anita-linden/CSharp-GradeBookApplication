using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("You need at least 5 students for ranked grading");

            int groupSize = Students.Count / 5;

            List<double> grades = new List<double>();
            foreach(Student student in Students)
            {
                grades.Add(student.AverageGrade);
            }

            grades.Sort((x, y) => y.CompareTo(x));

            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i]==averageGrade)
                {
                    if (i<groupSize)
                    {
                        return 'A';
                    }
                    else if (i<groupSize*2)
                    {
                        return 'B';
                    }
                    else if (i<groupSize*3)
                    {
                        return 'C';
                    }
                    else if (i<groupSize*4)
                    {
                        return 'D';
                    }    
                }
            }


                return 'F';
            }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
