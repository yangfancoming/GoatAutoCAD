

using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatInteraction))]
namespace GoatAutoCAD
{

    public class GoatInteraction
    {
        [CommandMethod("MyGroup", "interaction1", "interaction1", CommandFlags.Modal)]
        public void interaction1() {
            DBObjectCollection list = GoatSelectorUtil.selectAll();
            List<ObjectId> entityIds = new List<ObjectId>();
            foreach (DBObject o in list){
                entityIds.Add(o.Id);
            }
            InteractionUtil.HighlightObjects(entityIds);
        }

        [CommandMethod("MyGroup", "interaction2", "interaction2", CommandFlags.Modal)]
        public void interaction2() {
            DBObjectCollection list = GoatSelectorUtil.selectAll();
            List<ObjectId> entityIds = new List<ObjectId>();
            foreach (DBObject o in list){
                entityIds.Add(o.Id);
            }
            InteractionUtil.UnhighlightObjects(entityIds);
        }

        [CommandMethod("MyGroup", "TestKeywords", "TestKeywords", CommandFlags.Modal)]
        public void TestKeywords() {
            string[] keys = { "A", "B", "C", "D" };
            var key = InteractionUtil.GetKeywords("\nChoose an option", keys, 3);
            GoatMessageUtil.msg("You chose {0}.", key);
        }

        // 获取用户输入整数
        [CommandMethod("MyGroup", "pickInteger", "pickInteger", CommandFlags.Modal)]
        public void pickInteger(){
            int pt = InteractionUtil.pickInteger("\n 请输入整数：");
            BaseData.ed.WriteMessage("\n 输入的整数:({0})" ,pt);
        }

    }

}
