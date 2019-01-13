
using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            List<Student> LetterGrade = new List<Student>();
            LetterGrade = Students;

            LetterGrade.Sort((x, y) =>-x.AverageGrade.CompareTo(y.AverageGrade));

            if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count*0.2)-1].AverageGrade)
                return 'A';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count * 0.4) - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count * 0.6) - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count * 0.8) - 1].AverageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}
