using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Servcies.IService
{
    public interface ILaonServiceemployee<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T item);
        int Update(T item, int id);
        int Delete(int id);
        
    } 
}
