﻿

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatMessage))]
namespace GoatAutoCAD
{

    public class GoatMessage
    {
        // 命令行消息提示
        [CommandMethod("MyGroup", "msg1", "msg1", CommandFlags.Modal)]
        public void msg1()
        {
            GoatDB.ed.WriteMessage("Hello, this is msg1.");
        }


        // 弹出警告框提示
        [CommandMethod("MyGroup", "msg2", "msg2", CommandFlags.Modal)]
        public void msg2()
        {
            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Hello, this is msg2.");
        }

    }

}