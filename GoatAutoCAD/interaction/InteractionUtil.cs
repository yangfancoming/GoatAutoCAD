using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using GoatAutoCAD.db;
namespace GoatAutoCAD.interaction  {

    public static class InteractionUtil {

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


        /// <summary>
        /// 提示用户输入关键字
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="keywords">The keywords.</param>
        /// <param name="defaultIndex">The default index.</param>
        /// <returns>The keyword result.</returns>
        public static string GetKeywords(string message, string[] keywords, int defaultIndex = 0) {
            var opt = new PromptKeywordOptions(message) { AllowNone = true };
            keywords.ForEach(key => opt.Keywords.Add(key));
            opt.Keywords.Default = keywords[defaultIndex];
            var res = GoatDB.ed.GetKeywords(opt);
            if (res.Status == PromptStatus.OK){
                return res.StringResult;
            }
            return null;
        }

        /// <summary> ed.GetDouble(new PromptDoubleOptions(message) { AllowNone = true })
        /// 提示用户输入整数
        /// </summary>
        /// <param name="msg">提示</param>
        /// <returns>返回Point3d</returns>
        /// <summary>
        public static int pickInteger(string msg){
            PromptIntegerOptions options = new PromptIntegerOptions(msg){ AllowNone = false };
            PromptIntegerResult pt = GoatDB.ed.GetInteger(options);
            if (pt.Status == PromptStatus.OK){
                return pt.Value;
            }
            return 0;
        }







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


    }
}