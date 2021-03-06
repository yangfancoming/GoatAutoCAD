﻿

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatExplode))]
namespace GoatAutoCAD{

    public class GoatExplode{

        // 命令行消息提示
        [CommandMethod("MyGroup", "explode1", "explode1", CommandFlags.Modal)]
        public void explode1() {
            ObjectId objectId = InteractionUtil.getEntityId("\n 选择要更炸开的对象");
            if (objectId == ObjectId.Null) return;
            ObjectId[] objectIds = GoatExplodeUtil.Explode(objectId);
            GoatMessageUtil.msg(objectIds.Length.ToString());
        }

    }

}
