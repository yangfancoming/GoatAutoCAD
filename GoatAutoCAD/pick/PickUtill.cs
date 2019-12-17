

using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.selector
{
    public class PickUtill : BaseData {
        /// <summary>
        /// 提示用户拾取点
        /// </summary>
        /// <param name="msg">提示</param>
        /// <returns>返回Point3d</returns>
        /// <summary>
        public static Point3d pickPoint(string msg){
            PromptPointOptions options = new PromptPointOptions(msg);
            PromptPointResult pt = ed.GetPoint(options);
            if (pt.Status != PromptStatus.OK){
                return new Point3d();
            }
            // 获取用户选择点的坐标
            return pt.Value;
        }


        /// <summary>
        /// 提示用户输入整数
        /// </summary>
        /// <param name="msg">提示</param>
        /// <returns>返回Point3d</returns>
        /// <summary>
        public static Point3d pickInteger(string msg){
            PromptPointOptions options = new PromptPointOptions(msg);
            PromptPointResult pt = ed.GetPoint(options);
            if (pt.Status != PromptStatus.OK){
                return new Point3d();
            }
            // 获取用户选择点的坐标
            return pt.Value;
        }
    }
}