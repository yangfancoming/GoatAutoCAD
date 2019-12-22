

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatCircle))]
namespace GoatAutoCAD {

    public class GoatCircle {

        [CommandMethod("MyGroup", "circle1", "circle1", CommandFlags.Modal)]
        public void circle1() {
            Circle circle = GoatCircleUtil.Circle(new Point3d(0, 0, 0),10);
            circle.AddToModelSpace();
        }


        [CommandMethod("MyGroup", "circle2", "circle2", CommandFlags.Modal)]
        public void circle2() {
            Point3d point3d = InteractionUtil.getPoint("请输入圆心：");
            double distance = InteractionUtil.getDistance("请输入半径：");
            Circle circle = GoatCircleUtil.Circle(point3d,distance);
            circle.AddToModelSpace();
        }
    }

}
