
using System;
using System.Reflection;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.LayerManager;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;
using GoatAutoCAD.line;
using Microsoft.Win32;

[assembly: CommandClass(typeof(MyCommands))]

namespace GoatAutoCAD
{

    public class MyCommands
    {

        [CommandMethod("MyGroup", "MyCommand", "MyCommandLocal", CommandFlags.Modal)]
        public void MyCommand() // This method can have any name
        {
            GoatDB.editor.WriteMessage("Hello, this is your first command.");
        }
        Database db = Application.DocumentManager.MdiActiveDocument.Database;

        [CommandMethod("MyGroup", "goatLine", "GoatLine", CommandFlags.Modal)]
        public void goatLine()
        {
            Point3d p1 = new Point3d(0, 0, 0);
            Point3d p2 = new Point3d(100, 100, 0);
            Line line = new Line(p1,p2);
            ObjectId id = GoatDB.AddToModelSpace(line);
            GoatDB.editor.WriteMessage("Hello, this is your first command." + id);
        }

        //本程序在AutoCAD的快捷命令是"NL"

        [CommandMethod("MyGroup", "test1", "test1", CommandFlags.Modal)]
        public void myLoad()
        {
            //AutoCAD命令栏
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            //在AutoCAD命令栏输出选择的文件路径
            String path = "E:\\Code\\C#_code\\AutoCAD\\GoatAutoCAD\\GoatAutoCAD\\bin\\Debug\\GoatAutoCAD.dll";
            ed.WriteMessage("文件路径:" + path);
            //打开文件，将文件以二进制方式复制到内存，自动关闭文件
            byte[] buffer = System.IO.File.ReadAllBytes(path);
            //加载内存中的文件
            Assembly assembly = Assembly.Load(buffer);
            ed.WriteMessage("assembly:" + assembly);
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
