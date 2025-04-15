using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer;

namespace Data_Layer
{
    public class HobbyContext : IDb<HobbyContext, int>
    {
        public void Create(HobbyContext entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public HobbyContext Read(int key, bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            throw new NotImplementedException();
        }

        public List<HobbyContext> ReadAll(bool useNavigatonalProperties = false, bool isReadOnly = false)
        {
            throw new NotImplementedException();
        }

        public void Update(HobbyContext entity, bool useNavigatonalProperties = false)
        {
            throw new NotImplementedException();
        }
    }
}
