

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatMirror))]
namespace GoatAutoCAD
{

    public class GoatMirror
    {
        [CommandMethod("MyGroup", "mirror1", "mirror1", CommandFlags.Modal)]
        public void mirror1()
        {
            Point3d basePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            GoatMirrorUtil.mirrorBySelect(basePt, targetPt);
        }





    }

}
