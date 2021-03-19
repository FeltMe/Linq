using System;
using System.Collections.Generic;
using System.Text;
using Linq.Objects;

namespace Linq.Tests.Comparers
{
    class YearSchoolComparer : IEqualityComparer<YearSchoolStat>
    {
        public bool Equals(YearSchoolStat x, YearSchoolStat y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.NumberOfSchools == y.NumberOfSchools && x.Year == y.Year;
        }

        public int GetHashCode(YearSchoolStat obj)
        {
            return obj.GetHashCode();
        }
    }
}
