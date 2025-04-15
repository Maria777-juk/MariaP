using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer
{
    public class UserContext : IDb<User, int>
    {
        private WebsiteDbContext dbContext;
        public UserContext(WebsiteDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public void Create(User entity)
        {
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

        }



        public User Read(int key, bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            IQueryable<User> query = dbContext.Users;
            if (useNavigatonalProperties) query = query.Include(u => u.Friends).Include(u => u.Hobbies);


            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            User user = query.FirstOrDefault(u => u.Id == key);

            if (user == null) throw new ArgumentException($"User with Id {key} does not exist!");

            return user;

        }

        public List<User> ReadAll(bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            IQueryable<User> query = dbContext.Users;

            if (useNavigatonalProperties) query = query.Include(u => u.Friends).Include(u => u.Hobbies);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(User entity, bool useNavigatonalProperties = false)
        {
            User userFromDb = Read(entity.Id, useNavigatonalProperties);
            dbContext.Entry<User>(userFromDb).CurrentValues.SetValues(entity);
            if (useNavigatonalProperties)
            {
                List<Hobby> hobbies = new List<Hobby>();
                List<User> friends = new List<User>();
                for (int i = 0; i < entity.Hobbies.Count; i++)
                {
                    Hobby hobby = dbContext.Hobbies.Find(entity.Hobbies[i]);
                    if (hobby != null)
                    {
                        hobbies.Add(hobby);
                    }
                    else
                    {
                        hobbies.Add(entity.Hobbies[i]);
                    }
                }
                for (int i = 0; i < entity.Friends.Count; i++)
                {

                    if (userFromDb != null)
                    {
                        friends.Add(userFromDb);
                    }
                    else
                    {
                        friends.Add(entity.Friends[i]);
                    }
                }

                userFromDb.Hobbies = hobbies;
                userFromDb.Friends = friends;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int key)
        {
            User userFromDb = Read(key);
            dbContext.Users.Remove(userFromDb);
            dbContext.SaveChanges();
        }
    }
}
