

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatDelete))]
namespace GoatAutoCAD {

    public class GoatDelete : BaseData {

        // 报错：内部错误 eNotOpenForWrite
        [CommandMethod("MyGroup", "delete2", "delete2", CommandFlags.Modal)]
        public void delete2() {
            ObjectId objectId = GoatPickUtill.selectEntityId("\n 选择要删除的对象");
            objectId.QOpenForWrite(Constant.actionErase);
        }


    }

}
