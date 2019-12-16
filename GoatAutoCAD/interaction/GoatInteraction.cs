

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

        [CommandMethod("MyGroup", "interaction2", "interaction2", CommandFlags.Modal)]
        public void interaction2()
        {
            DBObjectCollection list = GoatSelectorUtil.selectAll();
            List<ObjectId> entityIds = new List<ObjectId>();
            foreach (DBObject o in list)
            {
                entityIds.Add(o.Id);
            }
            InteractionUtil.UnhighlightObjects(entityIds);
        }

    }

}
