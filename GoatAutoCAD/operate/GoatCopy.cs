

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatCopy))]
namespace GoatAutoCAD
{

    public class GoatCopy
    {
        [CommandMethod("MyGroup", "copy1", "copy1", CommandFlags.Modal)]
        public void copy1()
        {
            Entity ent = SelectorUtil.select("\n 选择对象");
            BaseData.ed.WriteMessage("\n 你选择的对象ObjectId:"+ent.ObjectId);
        }



    }

}
