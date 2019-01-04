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

        public List<account> getAllAccounts()
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    return context.account.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool changeActiveStatus(int accId, int newState)
        {
            using (restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    account toChange = context.account.Where(i => i.id == accId).ToList().First();
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

        public bool usernameExists(String username)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    if (context.account.Where(a => a.username.Equals(username)).ToList().Count > 0)
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

        public bool addAccount(String username, String password, int accTypeId)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    account newAcc = new account
                    {
                        username = username,
                        password = password,
                        AccountType_id = accTypeId,
                        active = 1
                    };
                    context.account.Add(newAcc);
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool addAccountAndTable(String username, String password, int accTypeId, int tableNumber)
        {
            using (restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    account newAcc = new account
                    {
                        username = username,
                        password = password,
                        AccountType_id = accTypeId,
                        active = 1
                    };
                    context.account.Add(newAcc);
                    context.SaveChanges();

                    table newTable = new table
                    {
                        number = tableNumber,
                        Account_id = newAcc.id
                    };
                    context.table.Add(newTable);
                    context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool updatePassword(int accountId, String newPassword)
        {
            using(restaurantEntities context = new restaurantEntities())
            {
                try
                {
                    account toUpdate = context.account.Where(a => a.id == accountId).First();
                    toUpdate.password = newPassword;
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
