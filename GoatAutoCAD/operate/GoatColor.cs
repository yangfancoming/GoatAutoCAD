

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;
using GoatAutoCAD.baseutil;

[assembly: CommandClass(typeof(GoatColor))]
namespace GoatAutoCAD{

    public class GoatColor{

        [CommandMethod("MyGroup", "color1", "color1", CommandFlags.Modal)]
        public void color1(){
            Entity ent = GoatPickUtill.selectEntity("\n 选择要更改颜色的对象");
            GoatColorUtil.setColor(1,ent.Id);
        }


        [CommandMethod("MyGroup", "color2", "color2", CommandFlags.Modal)]
        public void color2(){
            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要更改颜色的对象");
            objectId.QOpenForWrite<Entity>(e => e.ColorIndex = 1);
        }

    }

}
