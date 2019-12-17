using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

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


        public static void QOpenForWrite<T>(this ObjectId id, Action<T> action) where T : DBObject  {
            using (var trans = id.Database.TransactionManager.StartTransaction()) {
                action(trans.GetObject(id, OpenMode.ForWrite) as T);
                trans.Commit();
            }
        }


        public static void QOpenForWrite<T>(this ObjectId id, Line3d line3d,Action<T,Line3d> action) where T : DBObject  {
            using (var trans = id.Database.TransactionManager.StartTransaction()) {
                action(trans.GetObject(id, OpenMode.ForWrite) as T,line3d);
                trans.Commit();
            }
        }

        public static void QOpenForWrite<T>(this ObjectId id, Point3d point3d1,Point3d point3d2,Action<T,Point3d,Point3d> action) where T : DBObject  {
            using (var trans = id.Database.TransactionManager.StartTransaction()) {
                action(trans.GetObject(id, OpenMode.ForWrite) as T,point3d1,point3d2);
                trans.Commit();
            }
        }
    }
}