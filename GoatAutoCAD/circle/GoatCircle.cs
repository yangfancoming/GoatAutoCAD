

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatCircle))]
namespace GoatAutoCAD {

    public class GoatCircle {

        [CommandMethod("MyGroup", "circle1", "circle1", CommandFlags.Modal)]
        public void circle1() {
            Circle circle = GoatCircleUtil.Circle(new Point3d(0, 0, 0),10);
            circle.AddToModelSpace();
        }

    }

}
