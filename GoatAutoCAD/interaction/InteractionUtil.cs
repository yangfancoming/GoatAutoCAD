using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.db;

namespace GoatAutoCAD.interaction  {
    public static class InteractionUtil  {


        /// <summary>
        /// Highlights entities.
        /// </summary>
        /// <param name="entityIds">The entity IDs.</param>
        public static void HighlightObjects(IEnumerable<ObjectId> entityIds){
            entityIds.QForEach<Entity>(entity => entity.Highlight());
        }
        /// <summary>
        /// Unhighlights entities.
        /// </summary>
        /// <param name="entityIds">The entity IDs.</param>
        public static void UnhighlightObjects(IEnumerable<ObjectId> entityIds){
            entityIds.QForEach<Entity>(entity => entity.Unhighlight());
        }

        /// <summary>
        /// Opens objects for write (for each).
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="ids">The object IDs.</param>
        /// <param name="action">The action.</param>
        public static void QForEach<T>(this IEnumerable<ObjectId> ids, Action<T> action) where T : DBObject { // newly 20130520
            using (Transaction trans = GoatDB.db.TransactionManager.StartTransaction()) {
                ids.Select(id => trans.GetObject(id, OpenMode.ForWrite) as T).ToList().ForEach(action);
                trans.Commit();
            }
        }

    }
}