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
        public static void QOpenForWrite<T>(this ObjectId id, Action<T> action) where T : DBObject {
            using (var trans = id.Database.TransactionManager.StartTransaction()) {
                action(trans.GetObject(id, OpenMode.ForWrite) as T);
                trans.Commit();
            }
        }

        // sos 注意： 操作对象 必须要在 using 代码块中并且通过GetObject获取后才能操作成功！否则报错：内部错误 eNotOpenForWrite
        public static void QOpenForWrite(this ObjectId id, Action<Entity> action){
            using (var trans = id.Database.TransactionManager.StartTransaction()){
                action(trans.GetObject(id, OpenMode.ForWrite) as Entity);
                trans.Commit();
            }
        }

        public static void QOpenForWrite<T>(this ObjectId id, int colorIndex,Action<T,int> action) where T : DBObject{
            using (var trans = id.Database.TransactionManager.StartTransaction()){
                action(trans.GetObject(id, OpenMode.ForWrite) as T,colorIndex);
                trans.Commit();
            }
        }
        public static void QOpenForWrite<T>(this ObjectId id,short colorIndex, Action<T,short> action) where T : DBObject {
            using (var trans = id.Database.TransactionManager.StartTransaction()){
                action(trans.GetObject(id, OpenMode.ForWrite) as T,colorIndex);
                trans.Commit();
            }
        }



        public static T[] QOpenForRead<T>(this IEnumerable<ObjectId> ids)  where T : DBObject  {
            using (var trans = GoatDB.GetDatabase(ids).TransactionManager.StartTransaction()) {
                return ids.Select(id => trans.GetObject(id, OpenMode.ForRead) as T).ToArray();
            }
        }


        public static T QOpenForRead<T>(this ObjectId id) where T : DBObject  {
            using (var trans = id.Database.TransactionManager.StartOpenCloseTransaction()){
                return trans.GetObject(id, OpenMode.ForRead) as T;
            }
        }

        /// <summary>
        /// Opens objects for write (for each).
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="ids">The object IDs.</param>
        /// <param name="action">The action.</param>
        public static void QForEach<T>(this IEnumerable<ObjectId> ids, Action<T> action) where T : DBObject {
            using (Transaction trans = GoatDB.db.TransactionManager.StartTransaction()) {
                ids.Select(id => trans.GetObject(id, OpenMode.ForWrite) as T).ToList().ForEach(action);
                trans.Commit();
            }
        }

    }
}