
using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeight):base(name, isWeight)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var LetterGrade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= LetterGrade[(int)Math.Ceiling(Students.Count * 0.2) - 1])
                return 'A';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(Students.Count * 0.4) - 1])
                return 'B';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count * 0.6) - 1])
                return 'C';
            else if (averageGrade >= LetterGrade[(int)Math.Ceiling(LetterGrade.Count * 0.8) - 1])
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
