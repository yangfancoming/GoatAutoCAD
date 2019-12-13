

using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatInteraction))]
namespace GoatAutoCAD
{

    public class GoatInteraction
    {
        // 命令行消息提示
        [CommandMethod("MyGroup", "interaction1", "interaction1", CommandFlags.Modal)]
        public void interaction1()
        {
            DBObjectCollection list = GoatSelectorUtil.selectAll();
            List<ObjectId> entityIds = new List<ObjectId>();
            foreach (DBObject o in list)
            {
                entityIds.Add(o.Id);
            }
            InteractionUtil.HighlightObjects(entityIds);
        }


    }

}
