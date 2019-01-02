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
        public bool addItem(String name, String description, int typeId, decimal price, String image_path)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    item newItem = new item
                    {
                        name = name,
                        description = description,
                        ItemType_id = typeId,
                        image_path = image_path,
                        active = 1,
                        price = price
                    };
                    context.item.Add(newItem);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool updateItem(int itemId, String name, String description, int typeId, decimal price, String image_path)
        {
            using (restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    item toUpdate = context.item.Where(i => i.id == itemId).First();
                    toUpdate.name = name;
                    toUpdate.description = description;
                    toUpdate.ItemType_id = typeId;
                    toUpdate.price = price;
                    toUpdate.image_path = image_path;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

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

        public String getItemNameForId(int itemId)
        {
            using (restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.item.Where(i => i.id == itemId).First().name;
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool nameExists(String name)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    if (context.item.Where(i => i.name.Equals(name)).ToList().Count > 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return true;
                }
            }
        }
    }
}
