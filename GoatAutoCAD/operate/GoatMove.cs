

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatMove))]
namespace GoatAutoCAD {


    public class GoatMove {

        [CommandMethod("MyGroup", "move2", "move2", CommandFlags.Modal)]
        public void move2() {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            Vector3d vec = targetPt - basePt;
            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要移动的对象");
            objectId.QOpenForWrite(vec,Constant.actionMoveByVector3d);
        }


        [CommandMethod("MyGroup", "move3", "move3", CommandFlags.Modal)]
        public void move3() {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);

            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要移动的对象");
            objectId.QOpenForWrite(basePt,targetPt,Constant.actionMoveByPoint);
        }
    }

}
