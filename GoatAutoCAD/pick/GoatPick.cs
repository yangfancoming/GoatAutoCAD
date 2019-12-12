

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatPic))]
namespace GoatAutoCAD
{

    public class GoatPic
    {
        [CommandMethod("MyGroup", "pick1", "pick1", CommandFlags.Modal)]
        public void pick1()
        {
            Point3d pt = PickUtill.pick("\n 选择对象");
            BaseData.ed.WriteMessage("\n 拾取的点坐标为:({0},{1},{2})" ,pt.X,pt.Y,pt.Z);
        }




    }

}
