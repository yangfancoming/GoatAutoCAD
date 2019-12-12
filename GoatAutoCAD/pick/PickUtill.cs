

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
        public static Point3d pick(string msg){
            PromptPointResult pt = ed.GetPoint(msg);
            if (pt.Status == PromptStatus.OK){
                return pt.Value;
            }
            return new Point3d();
        }
    }
}