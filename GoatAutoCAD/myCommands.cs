
using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(MyCommands))]
namespace GoatAutoCAD
{

    public class MyCommands
    {

        [CommandMethod("MyGroup", "goatLine", "GoatLine", CommandFlags.Modal)]
        public void goatLine()
        {
            Line line = new Line(new Point3d(0, 0, 0),new Point3d(100, 100, 0));
            ObjectId id = GoatDB.AddToModelSpace(line);
            GoatDB.editor.WriteMessage("Hello, this is your first command." + id);
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
            GoatDB.editor.WriteMessage("Hello, this is your first command." + ids);
        }

        [CommandMethod("MyGroup", "MyCommand", "MyCommandLocal", CommandFlags.Modal)]
        public void MyCommand() // This method can have any name
        {
            GoatDB.editor.WriteMessage("Hello, this is your first command.");
        }


        [CommandMethod("MyGroup", "MyPickFirst", "MyPickFirstLocal", CommandFlags.Modal | CommandFlags.UsePickSet)]
        public void MyPickFirst()
        {
            PromptSelectionResult result = Application.DocumentManager.MdiActiveDocument.Editor.GetSelection();
            if (result.Status == PromptStatus.OK)
            {
            }

        }

        [CommandMethod("MyGroup", "MySessionCmd", "MySessionCmdLocal", CommandFlags.Modal | CommandFlags.Session)]
        public void MySessionCmd()
        {
        }


        [LispFunction("MyLispFunction", "MyLispFunctionLocal")]
        public int MyLispFunction(ResultBuffer args)
        {
            return 1;
        }

    }

}
