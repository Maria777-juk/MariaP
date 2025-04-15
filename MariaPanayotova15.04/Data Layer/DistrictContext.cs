using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer
{
    public class DistrictContext : IDb<District, int>
    {
        private WebsiteDbContext dbContext;
        public DistrictContext(WebsiteDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public void Create(District entity)
        {
            dbContext.Districts.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            District  districtFromDb = Read(key);
            dbContext.Districts.Remove(districtFromDb);
            dbContext.SaveChanges();
        }

        public District Read(int key, bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            IQueryable<District> query = dbContext.Districts;
            if (useNavigatonalProperties) query = query.Include(d => d.Users);


            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            District district = query.FirstOrDefault(d => d.Id == key);

            if (district == null) throw new ArgumentException($"District with Id {key} does not exist!");

            return district;
        }

        public List<District> ReadAll(bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            IQueryable<District> query = dbContext.Districts;
            if (useNavigatonalProperties) query.Include(a => a.Users);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();
            return query.ToList();
        }

        public void Update(District entity, bool useNavigatonalProperties = false)
        {
            District districtFromDb = Read(entity.Id, useNavigatonalProperties);
            dbContext.Entry<District>(districtFromDb).CurrentValues.SetValues(entity);
            if (useNavigatonalProperties)
            {
                List<User> users = new List<User>();
                for (int i = 0; i < entity.Users.Count; i++)
                {
                    User userFromDb = dbContext.Users.Find(entity.Users[i].Id);
                    if (userFromDb is not null) users.Add(userFromDb);
                    else users.Add(entity.Users[i]);
                }
                districtFromDb.Users = users;
            }

            dbContext.SaveChanges();
        }
    }
}
