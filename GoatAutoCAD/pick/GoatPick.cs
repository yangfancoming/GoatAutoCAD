

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.interaction;

[assembly: CommandClass(typeof(GoatPic))]
namespace GoatAutoCAD
{

    public class GoatPic{

        // 命令行获取 用户拾取点
        [CommandMethod("MyGroup", "pickPoint1", "pickPoint1", CommandFlags.Modal)]
        public void pickPoint1(){
            Point3d pt = InteractionUtil.getPoint("\n 选择点对象");
            BaseData.ed.WriteMessage("\n 拾取的点坐标为:({0},{1},{2})" ,pt.X,pt.Y,pt.Z);
        }

        // 对话框获取 用户拾取点
        [CommandMethod("MyGroup", "pickPoint2", "pickPoint2", CommandFlags.Modal)]
        public void pickPoint2(){
            // 打开对话框窗体
            using (GoatForm form = new GoatForm()){
                Application.ShowModalDialog(form);
                //点击“确定”按钮命令行显示窗体文本框中的信息
                BaseData.ed.WriteMessage(form.Text);
            }
        }



    }

}
