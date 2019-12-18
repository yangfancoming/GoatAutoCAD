

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatScale))]
namespace GoatAutoCAD{

    public class GoatScale{

        [CommandMethod("MyGroup", "scale1", "scale1", CommandFlags.Modal)]
        public void scale1(){
            Point3d center = new Point3d(0,0,0);
            ObjectId objectId = GoatPickUtill.GetEntityId("\n 选择要移动的对象");
            objectId.QOpenForWrite(x=>x.scale(center,2));
        }


    }

}
