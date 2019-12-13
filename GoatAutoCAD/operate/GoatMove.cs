

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatMove))]
namespace GoatAutoCAD
{

    public class GoatMove
    {
        [CommandMethod("MyGroup", "move1", "move1", CommandFlags.Modal)]
        public void move1()
        {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            GoatMoveUtil.moveBySelect(basePt, targetPt);
        }

    }

}
