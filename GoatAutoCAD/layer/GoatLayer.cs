

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatLayer))]
namespace GoatAutoCAD
{

    public class GoatLayer
    {
        // 命令行消息提示
        [CommandMethod("MyGroup", "layer1", "layer1", CommandFlags.Modal)]
        public void msg1()
        {
            // 新创建一个图层表记录，并命名为”MyLayer”
            LayerTableRecord ltr = new LayerTableRecord();
            ltr.Name = "luck";
            ltr.addLayerTableR1ecord();
        }




    }

}
