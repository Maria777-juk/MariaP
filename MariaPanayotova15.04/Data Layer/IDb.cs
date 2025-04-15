using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public interface IDb<T, K>
    {
        void Create(T entity);
        T Read(K key, bool useNavigatonalProperties = false, bool isReadOnly = false);
        List<T> ReadAll(bool useNavigatonalProperties = false, bool isReadOnly = false);
        void Update(T entity, bool useNavigatonalProperties = false);
        void Delete(K key);
    }
}
