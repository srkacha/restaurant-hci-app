using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Util
{
    class TableUtil
    {
        public table getTableForAccountId(int id)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.table.Where(t => t.Account_id == id).First();
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool tableNumberExists(int tableNumber)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.table.Where(t => t.number == tableNumber).ToList().Count > 0;
                }
                catch
                {
                    return true;
                }
            }
        }


    }
}
