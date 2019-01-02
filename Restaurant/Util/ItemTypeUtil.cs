using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Util
{
    class ItemTypeUtil
    {
        public List<itemtype> getAllItemTypes()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.itemtype.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
