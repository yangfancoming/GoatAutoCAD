using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.db;

namespace GoatAutoCAD.baseutil {

    public static class IEnumerableEx {

        /// <summary>
        /// For each loop.
        /// </summary>
        /// <typeparam name="T">The element type of source.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var element in source) {
                action(element);
            }
        }


        // sos 注意： 操作对象 必须要在 using 代码块中并且通过GetObject获取后才能操作成功！否则报错：内部错误 eNotOpenForWrite
        public static void QOpenForWrite(this ObjectId id, Action<Entity> action){
            using (var trans = id.Database.TransactionManager.StartTransaction()){
                action(trans.GetObject(id, OpenMode.ForWrite) as Entity);
                trans.Commit();
            }
        }


        public static T[] QOpenForRead<T>(this IEnumerable<ObjectId> ids)  where T : DBObject  {
            using (var trans = GoatDB.GetDatabase(ids).TransactionManager.StartTransaction()) {
                return ids.Select(id => trans.GetObject(id, OpenMode.ForRead) as T).ToArray();
            }
        }


        public static T QOpenForRead<T>(this ObjectId id) where T : DBObject  {// newly 20130122
            using (var trans = id.Database.TransactionManager.StartOpenCloseTransaction()){
                return trans.GetObject(id, OpenMode.ForRead) as T;
            }
        }


    }
}