using ProjectTrackerEF;
using EFModel = ProjectTrackerEF.Models;
using System;
using System.Linq;

using System.Web.Http.ModelBinding;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

namespace ProjectTrackerAPI.ModelServices
{
    public class User : IUser
    {
        private ProjectTrackerContext db ;
        public User()
        {
            db = new ProjectTrackerContext();
        }
        public List<EFModel.User> AllUsers()
        {
            try
            {
                var lstUser = new List<EFModel.User>();
                foreach (var item in db.Users)
                {
                    lstUser.Add(new EFModel.User {
                        Employee_ID=item.Employee_ID,
                        FirstName=item.FirstName,
                        IsMgr=item.IsMgr,
                        LastName=item.LastName,
                        Project=item.Project,
                        Task=item.Task,
                        User_ID=item.User_ID
                    });
                }
                //return db.Users;
                return lstUser;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public int CreateUser(EFModel.User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }

        public int DeleteUser(int id)
        {
            EFModel.User user = db.Users.Find(id);
            if (user == null)
            {
                return 0;
            }

            db.Users.Remove(user);
            return db.SaveChanges();
        }

        public EFModel.User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public int PatchUser(int id, EFModel.User user)
        {
            db.Entry(user).State = EntityState.Modified;
            try
            {
                return db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.User_ID == id) > 0;
        }
    }
}