using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model;

namespace SampleDataOper
{
    public class DataQuery
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">继承至BaseModel</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageSize">单页记录数</param>
        /// <param name="pageIndex">页数</param>
        /// <returns></returns>
        public static List<T> GetRecords<T>(int pageSize, int pageIndex, Func<T, bool> whereLambda = null) where T : BaseModel
        {
            if (whereLambda == null) whereLambda = p => true;
            return new SunginDataContext().Set<T>().Where(whereLambda).Where(p => p.IsDelete == false).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">继承至BaseModel</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public static List<T> GetRecords<T>(Func<T, bool> whereLambda=null) where T : BaseModel
        {
            if (whereLambda == null) whereLambda = p => true;
            return new SunginDataContext().Set<T>().Where(whereLambda).Where(p=>p.IsDelete==false).ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">继承至BaseModel</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageSize">单页记录数</param>
        /// <param name="pageIndex">页数</param>
        /// <returns></returns>
        public static List<T> GetAllRecords<T>( int pageSize, int pageIndex, Func<T, bool> whereLambda = null) where T : class
        {
            if (whereLambda == null) whereLambda = p => true;
            return new SunginDataContext().Set<T>().Where(whereLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">继承至BaseModel</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public static List<T> GetAllRecords<T>(Func<T, bool> whereLambda=null) where T : class
        {
            if (whereLambda == null) whereLambda = p => true;
            return new SunginDataContext().Set<T>().Where(whereLambda).ToList();
        }

        public static T GetSingle<T>(Func<T, bool> whereLambda=null)  where T:class
        {
            if (whereLambda == null) whereLambda = p => true;
            return new SunginDataContext().Set<T>().Where(whereLambda).ToList().FirstOrDefault();
        }
            
       
    }
}
