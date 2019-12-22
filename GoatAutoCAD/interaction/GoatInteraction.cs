

using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
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

        // 获取用户输入 距离
        [CommandMethod("MyGroup", "GetDistance", "GetDistance", CommandFlags.Modal)]
        public void GetDistance(){
            double value = InteractionUtil.getDistance("\nSize");
            GoatMessageUtil.msg("\n 输入的距离:({0})" ,value);
        }

        // 获取用户输入 距离
        [CommandMethod("MyGroup", "getAngle", "getAngle", CommandFlags.Modal)]
        public void getAngle(){
            double value = InteractionUtil.getAngle("\n 输入 角度");
            GoatMessageUtil.msg("\n 输入的 角度:({0})" ,value);
        }


        // 命令行获取 用户拾取点
        [CommandMethod("MyGroup", "getPoint1", "getPoint1", CommandFlags.Modal)]
        public void getPoint1(){
            Point3d pt = InteractionUtil.getPoint("\n 选择点对象");
            BaseData.ed.WriteMessage("\n 拾取的点坐标为:({0},{1},{2})" ,pt.X,pt.Y,pt.Z);
        }

        [CommandMethod("MyGroup", "getPoint2", "getPoint2", CommandFlags.Modal)]
        public void getPoint2(){
            Point3d pt = InteractionUtil.getPoint("\n 选择点对象",true);
            BaseData.ed.WriteMessage("\n 拾取的点坐标为:({0},{1},{2})" ,pt.X,pt.Y,pt.Z);
        }
    }

}
