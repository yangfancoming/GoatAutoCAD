

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatRotate))]
namespace GoatAutoCAD{

    public class GoatRotate{

        [CommandMethod("MyGroup", "rotate1", "rotate1", CommandFlags.Modal)]
        public void rotate1(){
            Point3d center = new Point3d(0,0,0);
            ObjectId objectId = GoatPickUtill.getEntityId("\n 选择要移动的对象");
            objectId.QOpenForWrite(x=>x.rotate(center,60));
        }



    }

}
