using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;

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


        /// <summary>
        /// Opens object for write.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="id">The object ID.</param>
        /// <param name="action">The action.</param>
        public static void QOpenForWrite<T>(this ObjectId id, Action<T> action) where T : DBObject  {
            using (var trans = id.Database.TransactionManager.StartTransaction()) {
                action(trans.GetObject(id, OpenMode.ForWrite) as T);
                trans.Commit();
            }
        }


    }
}