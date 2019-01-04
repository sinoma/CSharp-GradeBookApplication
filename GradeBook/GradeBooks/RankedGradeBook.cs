
using GradeBook.Enums;
using System;

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

            Students.Sort((x, y) =>x.AverageGrade.CompareTo(y.AverageGrade));

            if (averageGrade >= Students[(int)Math.Ceiling(Students.Count*0.2)].AverageGrade)
                return 'A';
            else if (averageGrade >= Students[(int)Math.Ceiling(Students.Count * 0.4)].AverageGrade)
                return 'B';
            else if (averageGrade >= Students[(int)Math.Ceiling(Students.Count * 0.6)].AverageGrade)
                return 'C';
            else if (averageGrade >= Students[(int)Math.Ceiling(Students.Count * 0.8)].AverageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
