

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
        public static Point3d pick(string msg){
            #region 提示用户拾取点
            PromptPointOptions options = new PromptPointOptions(msg);
            PromptPointResult pt = ed.GetPoint(options);
            if (pt.Status != PromptStatus.OK){
                return new Point3d();
            }
            return pt.Value;
            #endregion
        }
    }
}