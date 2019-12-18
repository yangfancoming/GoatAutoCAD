
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatLine))]
namespace GoatAutoCAD{

    public class GoatLine{

        [CommandMethod("MyGroup", "goatLine", "goatLine", CommandFlags.Modal)]
        public void goatLine() {
            Line line = new Line(new Point3d(0, 0, 0),new Point3d(100, 100, 0));
            ObjectId id = line.AddToModelSpace();
            GoatDB.ed.WriteMessage("Hello, this is your first command." + id);
        }

        [CommandMethod("MyGroup", "goatLines", "goatLines", CommandFlags.Modal)]
        public void goatLines() {
            Line line1 = new Line(new Point3d(0, 0, 0),new Point3d(100, 100, 0));
            Line line2 = new Line(new Point3d(10, 50, 0),new Point3d(10, 400, 0));
            List<Entity> list = new List<Entity>();
            list.Add(line1);
            list.Add(line2);
            IEnumerable<ObjectId> ids = list.AddToModelSpace();
            ids.ForEach(x=> GoatDB.ed.WriteMessage("Hello" + x));
        }


        [CommandMethod("MyGroup", "line1", "line1", CommandFlags.Modal)]
        public void line1() {
            var entityId = GoatPickUtill.GetEntityId("\nSpecify a Line", typeof(Line));

        }

    }

}
