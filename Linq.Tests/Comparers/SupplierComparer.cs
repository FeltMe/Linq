using System;
using System.Collections.Generic;
using System.Text;
using Linq.Objects;

namespace Linq.Tests.Comparers
{
    class SupplierComparer: IEqualityComparer<Supplier>
    {
        public bool Equals(Supplier x, Supplier y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id && x.YearOfBirth == y.YearOfBirth && x.Adress.Equals(y.Adress);
        }

        public int GetHashCode(Supplier obj)
        {
            return obj.GetHashCode();
        }
    }
}
