using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Util
{
    class ItemUtil
    {
        public List<item> getAllItems()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.item.ToList();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
