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
    public class BaseDAL : IBaseDAL
    {
        /// <summary>
        /// 泛型按主键查询
        /// </summary>
        /// <typeparam name="T">约束只能查询BaseModel及子类</typeparam>
        /// <param name="id"></param>
        public T QueryById<T>(int id)
            where T : BaseModel
        {
            Type type = typeof(T);
            //拼接sql语句
            string columnStr = string.Join(",", type.GetProperties().Select(item => $"[{item.GetMappingName()}]"));
            string sql = $"SELECT {columnStr} FROM [{type.Name}] WHERE Id={id}";
            SqlDataReader reader = SqlHelper.ExecuteReader(sql);
            //实例化返回的List集合的首项或默认值
            T t = Reader2List<T>(reader).FirstOrDefault();
            //关闭SqlConnection连接
            reader.Close();
            return t;
        }

        /// <summary>
        /// 查询全表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Query<T>()
            where T : BaseModel
        {
            Type type = typeof(T);
            string columnStr = string.Join(",", type.GetProperties().Select(item => $"[{item.GetMappingName()}]"));
            string sql = $"SELECT {columnStr} FROM [{type.Name}]";
            SqlDataReader reader = SqlHelper.ExecuteReader(sql);
            List<T> list = Reader2List<T>(reader);
            reader.Close();
            return list;
        }

        /// <summary>
        /// DataReader转对象List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<T> Reader2List<T>(SqlDataReader reader) where T : BaseModel
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            while (reader.Read())
            {
                T t = (T)Activator.CreateInstance(type);
                foreach (var item in type.GetProperties())
                {
                    object objValue = reader[item.GetMappingName()];
                    //处理可空类型
                    if (objValue is DBNull)
                    {
                        objValue = null;
                    }
                    item.SetValue(t, objValue);
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <exception cref="Exception"></exception>
        public void Update<T>(T t)
            where T : BaseModel
        {
            if (!t.Validate())
            {
                throw new Exception("数据验证未通过");
                return;
            }
            Type type = typeof(T);
            var propArray = type.GetProperties().Where(item => !item.Name.Equals("Id"));
            //拼接后的形式： [列名] = @列名
            string columnStr = string.Join(",", propArray.Select(item => $"[{item.GetMappingName()}]=@{item.GetMappingName()}"));
            //如果为空值则输入DBNull
            SqlParameter[] pms = propArray.Select(item => new SqlParameter($"@{item.GetMappingName()}", item.GetValue(t) ?? DBNull.Value)).ToArray();
            string sql = $"UPDATE [{type.Name}] SET {columnStr} where [Id] = {t.Id}";
            int uResult = SqlHelper.ExecuteNonQuery(sql, pms);
            if (uResult == 0)
            {
                throw new Exception("修改失败");
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <exception cref="Exception"></exception>
        public void Insert<T>(T t)
            where T : BaseModel
        {
            if (!t.Validate())
            {
                throw new Exception("数据验证未通过");
                return;
            }
            Type type = typeof(T);
            var propArray = type.GetProperties().Where(item => !item.Name.Equals("Id"));
            string valueStr = string.Join(",", propArray.Select(item => $"@{item.GetMappingName()}"));
            string columnStr = string.Join(",", propArray.Select(item => $"[{item.GetMappingName()}]"));
            //填充参数数组，如果为空值则输入DBNull
            SqlParameter[] pms = propArray.Select(item => new SqlParameter($"@{item.GetMappingName()}", item.GetValue(t) ?? DBNull.Value)).ToArray();
            string sql = $"INSERT INTO [{type.Name}]({columnStr}) VALUES({valueStr})";
            int uResult = SqlHelper.ExecuteNonQuery(sql, pms);
            if (uResult == 0)
            {
                throw new Exception("添加失败");
            }
        }

        /// <summary>
        /// 按主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void Delete<T>(int id)
            where T : BaseModel
        {
            Type type = typeof(T);
            //填充参数数组，如果为空值则输入DBNull
            string sql = $"DELETE FROM [{type.Name}] where [Id] = {id}";
            int uResult = SqlHelper.ExecuteNonQuery(sql);
            if (uResult == 0)
            {
                throw new Exception("删除失败");
            }
        }
    }
}
