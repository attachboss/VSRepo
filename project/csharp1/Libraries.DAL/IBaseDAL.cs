using Libraries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.Common;
using System.Data.SqlClient;

namespace Libraries.DAL
{
    public interface IBaseDAL
    {
        T QueryById<T>(int id)
           where T : BaseModel;

        List<T> Query<T>()
           where T : BaseModel;

        void Update<T>(T t)
           where T : BaseModel;

        void Insert<T>(T t)
           where T : BaseModel;

        void Delete<T>(int id)
           where T : BaseModel;
    }
}
