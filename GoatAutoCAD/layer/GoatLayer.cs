

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;
using GoatAutoCAD.form;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatLayer))]
namespace GoatAutoCAD {


    public class GoatLayer {

        // 命令行消息提示
        [CommandMethod("MyGroup", "layer1", "layer1", CommandFlags.Modal)]
        public void layer1() {
            // 新创建一个图层表记录，并命名为”MyLayer”
            LayerTableRecord ltr = new LayerTableRecord(){ Name = "lucky" };
            ltr.addLayerTableR1ecord();
        }


        //
        [CommandMethod("MyGroup", "layer2", "layer2", CommandFlags.Modal)]
        public void layer2() {
            string[] allLayerNames = GoatLayerUtil.GetAllLayerNames();
            allLayerNames.ForEach(GoatMessageUtil.msg);
        }


        //  显示模态对话框 自动选择指定层的实体对象
        [CommandMethod("MyGroup", "layer4", "layer4", CommandFlags.Modal)]
        public void layer4() {
            DocumentLock doclock = BaseData.doc.LockDocument();
            //操作过程
            using (SelectByLayer form = new SelectByLayer()) {
                Application.ShowModalDialog(form);
            }
            doclock.Dispose();
        }



        [CommandMethod("TestSetLayer")]
        public void TestSetLayer(){
            Line line = new Line(new Point3d(0, 0, 0),new Point3d(100, 200, 0));
            ObjectId id = line.AddToModelSpace();
            id.SetLayer("aaa");
        }

    }

}
