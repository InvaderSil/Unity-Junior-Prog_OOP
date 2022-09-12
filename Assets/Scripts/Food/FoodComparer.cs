
using System.Collections.Generic;


namespace Assets.Scripts.Food
{
    public class FoodComparer : IEqualityComparer<PlatableFood>
    {
        public bool Equals(PlatableFood x, PlatableFood y)
        {
            if (x is null || y is null)
            {
                return false;
            }

            return x.GetName() == y.GetName() && x.GetDescription() == y.GetDescription();
        }

        public int GetHashCode(PlatableFood obj)
        {
            return obj.GetName().GetHashCode() ^ obj.GetDescription().GetHashCode();
        }
    }
}
