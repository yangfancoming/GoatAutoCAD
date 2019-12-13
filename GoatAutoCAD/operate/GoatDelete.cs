

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatDelete))]
namespace GoatAutoCAD
{

    public class GoatDelete : BaseData
    {
        // 报错：内部错误 eNotOpenForWrite
        [CommandMethod("MyGroup", "delete1", "delete1", CommandFlags.Modal)]
        public void delete1()
        {
            GoatDeleteUtil.deleteBySelect();
        }


        // 报错：内部错误 eNotOpenForWrite
        [CommandMethod("MyGroup", "delete2", "delete2", CommandFlags.Modal)]
        public void delete2()
        {

        }


    }

}
