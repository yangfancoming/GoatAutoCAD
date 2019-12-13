

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatCopy))]
namespace GoatAutoCAD
{

    public class GoatCopy
    {
        [CommandMethod("MyGroup", "copy1", "copy1", CommandFlags.Modal)]
        public void copy1()
        {
            Point3d sourcePt = new Point3d(0,0,0);
            Point3d targetPt = new Point3d(100,100,0);
            Entity ent = GoatSelectorUtil.select("\n 选择要删除的对象");
            GoatCopyUtil.copyById(ent.Id,sourcePt,targetPt);
        }



    }

}
