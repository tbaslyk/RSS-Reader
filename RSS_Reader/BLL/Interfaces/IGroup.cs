using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGroup<T>
    {
        void Add(T obj);

        void AddRange(List<T> objList);

        void Remove(string name);

        List<T> GetAll();
    }
}
