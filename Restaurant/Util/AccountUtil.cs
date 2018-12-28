using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model;

namespace Restaurant.Util
{
    class AccountUtil
    {
        public account getAccountForUsernameAndPassword(String username, String password)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.account.Where(a => a.username.Equals(username) && a.password.Equals(password)).First();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
