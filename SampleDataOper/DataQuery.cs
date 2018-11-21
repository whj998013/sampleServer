using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        public static List<T> GetRecords<T>(Func<T, bool> whereLambda, int pageSize, int pageIndex) where T : BaseModel
        {
            return new SampleContext().Set<T>().Where(whereLambda).Where(p => p.IsDelete == false).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">继承至BaseModel</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        public static List<T> GetRecords<T>(Func<T, bool> whereLambda) where T : BaseModel
        {
            return new SampleContext().Set<T>().Where(whereLambda).Where(p=>p.IsDelete==false).ToList();
        }
    }
}
