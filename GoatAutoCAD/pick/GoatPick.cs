

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatPic))]
namespace GoatAutoCAD
{

    public class GoatPic{
        [CommandMethod("MyGroup", "pick1", "pick1", CommandFlags.Modal)]
        public void pick1(){
            Point3d pt = PickUtill.pickPoint("\n 选择对象");
            BaseData.ed.WriteMessage("\n 拾取的点坐标为:({0},{1},{2})" ,pt.X,pt.Y,pt.Z);
        }


        [CommandMethod("MyGroup", "pick2", "pick2", CommandFlags.Modal)]
        public void pick2(){
            DocumentLock doclock = BaseData.doc.LockDocument();
            //操作过程
            using (GoatForm form = new GoatForm()){
                Application.ShowModalDialog(form);
                //点击“确定”按钮命令行显示窗体文本框中的信息
                BaseData.ed.WriteMessage(form._textBox.Text);
            }
            doclock.Dispose();
        }



    }

}
