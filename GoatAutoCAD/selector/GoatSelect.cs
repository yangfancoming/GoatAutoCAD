

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatSelect))]
namespace GoatAutoCAD {

    public class GoatSelect {

        [CommandMethod("MyGroup", "select1", "select1", CommandFlags.Modal)]
        public void msg1() {
            Entity ent = GoatPickUtill.selectEntity("\n 选择对象");
            BaseData.ed.WriteMessage("\n 你选择的对象ObjectId:"+ent.ObjectId);
        }

        [CommandMethod("MyGroup", "Select2", "Select2", CommandFlags.Modal)]
        public void Select2() {
            GoatSelectorUtil.Select2();
        }

        [CommandMethod("MyGroup", "Select3", "Select3", CommandFlags.Modal)]
        public void Select3() {
            GoatSelectorUtil.Select3();
        }

        [CommandMethod("MyGroup", "selects", "selects", CommandFlags.Modal)]
        public void selects() {
            DBObjectCollection list = GoatSelectorUtil.selects();
            GoatMessageUtil.msg(list.Count.ToString());
        }

        [CommandMethod("MyGroup", "selectAll", "selectAll", CommandFlags.Modal)]
        public void selectAll() {
            DBObjectCollection list = GoatSelectorUtil.selectAll();
            GoatMessageUtil.msg(list.Count.ToString());

        }
    }

}
