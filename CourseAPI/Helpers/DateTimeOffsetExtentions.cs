using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Helpers
{
    public static class DateTimeOffsetExtentions
    {
        public static int GetAge(this DateTimeOffset dateTimeOffset)
        {
            var current = DateTime.UtcNow;
            int age = current.Year - dateTimeOffset.Year;

            if(current < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
