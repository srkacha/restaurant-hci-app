using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;


namespace Restaurant.Util
{
    class AccountTypeUtil
    {
        public List<accounttype> getAllAccountTypes()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.accounttype.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
