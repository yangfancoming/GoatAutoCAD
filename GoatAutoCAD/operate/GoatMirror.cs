

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatMirror))]
namespace GoatAutoCAD {

    public class GoatMirror {

        [CommandMethod("MyGroup", "mirror2", "mirror2", CommandFlags.Modal)]
        public void mirror2() {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            Line3d line3d = new Line3d(basePt, targetPt);
            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要镜像的对象");
           objectId.QOpenForWrite(x=>x.mirrorByLine3d(line3d));
        }


        [CommandMethod("MyGroup", "mirror3", "mirror3", CommandFlags.Modal)]
        public void mirror3() {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要镜像的对象");
            objectId.QOpenForWrite(x=>x.mirrorByPoint(basePt,targetPt));
        }


    }

}
