

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatBlock))]
namespace GoatAutoCAD{

    public class GoatBlock{

        [CommandMethod("MyGroup", "block1", "block1", CommandFlags.Modal)]
        public void block1(){
            BlockTableRecord btr = new BlockTableRecord();
            btr.Name = "GoatBlock";
            Line line = new Line(Point3d.Origin, new Point3d(10, 15, 0));
            Circle circle = new Circle(Point3d.Origin, Vector3d.ZAxis, 10);
            btr.AppendEntity(line);
            btr.AppendEntity(circle);
            btr.AddBlockTableRecord();
        }

    }

}
