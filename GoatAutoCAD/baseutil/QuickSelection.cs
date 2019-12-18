using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using GoatAutoCAD.db;

namespace GoatAutoCAD.baseutil {


    public static class QuickSelection {


        /// <summary>
        /// Selects all entities with specified filters in current editor.
        /// </summary>
        /// <param name="filterList">The filter list.</param>
        /// <returns>The object IDs.</returns>
        public static ObjectId[] SelectAll(TypedValue[] filterList) {
            var ed = GoatDB.ed;
            var selRes = filterList != null && filterList.Any() ? ed.SelectAll(new SelectionFilter(filterList)) : ed.SelectAll();
            if (selRes.Status == PromptStatus.OK){
                return selRes.Value.GetObjectIds();
            }
            return new ObjectId[0];
        }


        public static ObjectId[] SelectAll(FilterList filterList){
            return SelectAll(filterList.ToArray());
        }

    }
}