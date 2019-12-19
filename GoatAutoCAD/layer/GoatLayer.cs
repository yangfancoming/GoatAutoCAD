

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.db;
using GoatAutoCAD.form;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatLayer))]
namespace GoatAutoCAD {


    public class GoatLayer {

        // 命令行消息提示
        [CommandMethod("MyGroup", "layer1", "layer1", CommandFlags.Modal)]
        public void layer1() {
            // 新创建一个图层表记录，并命名为”MyLayer”  图层名称必须合法！ 不能为空/特殊字符
            LayerTableRecord ltr = new LayerTableRecord(){ Name = "lucky" };
//            LayerTableRecord ltr = new LayerTableRecord(){ Name = " " };
            // 校检 输入的图层名称是否合法 不合法则抛出异常
            SymbolUtilityServices.ValidateSymbolName(ltr.Name,false);
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


        //  layer5 和 layer6 两个方法比起来 感觉还是 layer6 要好一些
        [CommandMethod("layer5")]
        public void layer5() {
            // 通过 图层名称获得图层id
            ObjectId objectId = GoatLayerUtil.GetLayerByName("aaa");
            if (objectId != ObjectId.Null) {
                // 通过委托 更改图层颜色属性
                objectId.QOpenForWrite(1,Constant.layerColor);
            }
            GoatMessageUtil.msg(objectId.ToString());
        }


        [CommandMethod("layer6")]
        public void layer6() {
            // 通过 图层名称获得图层id
            ObjectId objectId = GoatLayerUtil.GetLayerByName("aaa");
            if (objectId != ObjectId.Null) {
                objectId.setLayerProperties(5,true);
            }
        }

    }

}
