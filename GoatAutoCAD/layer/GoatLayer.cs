

using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;
using GoatAutoCAD.form;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatLayer))]
namespace GoatAutoCAD {


    public class GoatLayer {

        // 命令行消息提示
        [CommandMethod("MyGroup", "layer1", "layer1", CommandFlags.Modal)]
        public void layer1() {
            // 新创建一个图层表记录，并命名为”MyLayer”
            LayerTableRecord ltr = new LayerTableRecord();
            ltr.Name = "luck";
            ltr.addLayerTableR1ecord();
        }


        //
        [CommandMethod("MyGroup", "layer2", "layer2", CommandFlags.Modal)]
        public void layer2() {
            string[] allLayerNames = GoatDB.GetAllLayerNames();
            allLayerNames.ForEach(GoatMessageUtil.msg);
        }

        //
        [CommandMethod("MyGroup", "layer3", "layer3", CommandFlags.Modal)]
        public void layer3() {
            string[] availableLayerNames = GoatDB.GetAllLayerNames();
            string[] selectedLayerNames = Gui.GetChoices("Specify layers", availableLayerNames);
            if (selectedLayerNames.Length < 1){
                return;
            }

            FilterList filterList = FilterList.Create().Layer(selectedLayerNames);

            var ids = QuickSelection.SelectAll(filterList).ToArray();
            InteractionUtil.SetPickSet(ids);
        }

    }

}
