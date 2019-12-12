
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatLine))]
namespace GoatAutoCAD
{

    public class GoatLine
    {

        [CommandMethod("MyGroup", "goatLine", "goatLine", CommandFlags.Modal)]
        public void goatLine()
        {
            Line line = new Line(new Point3d(0, 0, 0),new Point3d(100, 100, 0));
            ObjectId id = GoatDB.AddToModelSpace(line);
            GoatDB.ed.WriteMessage("Hello, this is your first command." + id);
        }

        [CommandMethod("MyGroup", "goatLines", "goatLines", CommandFlags.Modal)]
        public void goatLines()
        {
            Line line1 = new Line(new Point3d(0, 0, 0),new Point3d(100, 100, 0));
            Line line2 = new Line(new Point3d(10, 50, 0),new Point3d(10, 400, 0));
            List<Entity> list = new List<Entity>();
            list.Add(line1);
            list.Add(line2);
            List<ObjectId> ids = GoatDB.AddToModelSpace(list);
            GoatDB.ed.WriteMessage("Hello, this is your first command." + ids);
        }

    }

}
