

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatSelect))]
namespace GoatAutoCAD
{

    public class GoatSelect
    {
        [CommandMethod("MyGroup", "select1", "select1", CommandFlags.Modal)]
        public void msg1()
        {
            Entity ent = SelectorUtil.select("\n 选择对象");
            BaseData.ed.WriteMessage("\n 你选择的对象ObjectId:"+ent.ObjectId.ToString());
        }


    }

}
