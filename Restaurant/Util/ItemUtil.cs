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
        public List<item> getAllActiveItems()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.item.Where(i => i.active == 1).ToList();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public List<item> getAlItems()
        {
            using (restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.item.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public bool changeActiveStatus(int itemId, int newState)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    item toChange = context.item.Where(i => i.id == itemId).ToList().First();
                    toChange.active = (sbyte)newState;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
