

using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
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

        [CommandMethod("MyGroup", "GetKeywords1", "GetKeywords1", CommandFlags.Modal)]
        public void GetKeywords1() {
            string[] keys = { "A", "B", "C", "D" };
            var key = InteractionUtil.getKeywords("\nChoose an option", keys, 3);
            GoatMessageUtil.msg("You chose {0}.", key);
        }

        [CommandMethod("MyGroup", "GetKeywords2", "GetKeywords2", CommandFlags.Modal)]
        public void GetKeywords2() {
            string[] keys = { "A", "B", "C", "D" };
            var key = InteractionUtil.getKeywords("\nChoose an option", keys, 3);
            GoatMessageUtil.msg("You chose {0}.", key);
        }


        // 获取用户输入整数
        [CommandMethod("MyGroup", "getInteger", "getInteger", CommandFlags.Modal)]
        public void getInteger(){
            int pt = InteractionUtil.getInteger("\n 请输入整数：");
            GoatMessageUtil.msg("\n 输入的整数:({0})" ,pt);
        }

        // 获取用户输入 字符串1
        [CommandMethod("MyGroup", "getString1", "getString1", CommandFlags.Modal)]
        public void getString1(){
            string stringResult = InteractionUtil.getString("\n hello getString1 ：");
            GoatMessageUtil.msg("\n 输入的字符串:({0})" ,stringResult);
        }

        // 获取用户输入 字符串2
        [CommandMethod("MyGroup", "getString2", "getString2", CommandFlags.Modal)]
        public void getString2(){
            string stringResult = InteractionUtil.getString("\n hello getString2 ：","123",true);
            GoatMessageUtil.msg("\n 输入的字符串:({0})" ,stringResult);
        }

        // 获取用户输入 字符串3
        [CommandMethod("MyGroup", "getString3", "getString3", CommandFlags.Modal)]
        public void getString3(){
            string stringResult = InteractionUtil.getString("\n hello getString2 ：","heihei");
            GoatMessageUtil.msg("\n 输入的字符串:({0})" ,stringResult);
        }


    }

}
