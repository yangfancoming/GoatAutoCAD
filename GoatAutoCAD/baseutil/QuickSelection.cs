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
            PromptSelectionResult res = filterList != null && filterList.Any() ? ed.SelectAll(new SelectionFilter(filterList)) : ed.SelectAll();
            return getResult(res);
        }

        public static ObjectId[] SelectAll(FilterList filterList){
            return SelectAll(filterList.ToArray());
        }

        /// <summary>
        /// Gets multiple entities.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="filterList">The filter list.</param>
        /// <returns>The entity IDs.</returns>
        public static ObjectId[] GetSelection(string message, params TypedValue[] filterList) {
            var ed = GoatDB.ed;
            var opt = new PromptSelectionOptions { MessageForAdding = message };
            PromptSelectionResult res = (filterList != null && filterList.Any()) ? ed.GetSelection(opt, new SelectionFilter(filterList)) : ed.GetSelection(opt);
            return getResult(res);
        }

        public static ObjectId[] getResult(PromptSelectionResult result) {
            if (result.Status == PromptStatus.OK) {
                return result.Value.GetObjectIds();
            }
            return new ObjectId[0];
        }

    }
}