using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;

namespace GoatAutoCAD.interaction  {

    public static class InteractionUtil {



        public static string getString(string message) {
            var res = GoatDB.ed.GetString(message);
            if (res.Status == PromptStatus.OK) return res.StringResult;
            return null;
        }

        /// <summary>
        /// 提示用户输入关键字
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="keywords">The keywords.</param>
        /// <param name="defaultIndex">The default index.</param>
        /// <returns>The keyword result.</returns>
        public static string getKeywords(string message, string[] keywords, int defaultIndex = 0) {
            PromptKeywordOptions opt = new PromptKeywordOptions(message) { AllowNone = true };
            keywords.ForEach(key => opt.Keywords.Add(key));
            opt.Keywords.Default = keywords[defaultIndex];
            var res = GoatDB.ed.GetKeywords(opt);
            if (res.Status == PromptStatus.OK) return res.StringResult;
            return null;
        }

        /// <summary> ed.GetDouble(new PromptDoubleOptions(message) { AllowNone = true })
        /// 提示用户输入整数
        /// </summary>
        /// <param name="msg">提示</param>
        /// <returns>返回Point3d</returns>
        /// <summary>
        public static int getInteger(string msg){
            PromptIntegerOptions options = new PromptIntegerOptions(msg){ AllowNone = false };
            PromptIntegerResult pt = GoatDB.ed.GetInteger(options);
            if (pt.Status == PromptStatus.OK) return pt.Value;
            return 0;
        }

        /// <summary>
        /// 设置选中
        /// </summary>
        /// <param name="entityIds"> 待选中的实体id</param>
        public static void SetPickSet(ObjectId[] entityIds) {
            GoatDB.ed.SetImpliedSelection(entityIds);
        }





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


    }
}