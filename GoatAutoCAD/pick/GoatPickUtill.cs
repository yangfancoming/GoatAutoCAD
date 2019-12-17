

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;

namespace GoatAutoCAD.selector
{
    public class GoatPickUtill : BaseData {
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
        /// 提示用户选择单个实体
        /// </summary>
        /// <param name="msg">选择提示</param>
        /// <returns>实体对象</returns>
        public static Entity selectEntity(string msg){
            PromptEntityResult ent = ed.GetEntity(msg);
            if (ent.Status == PromptStatus.OK) {
                return ent.ObjectId.getEntityById();
            }
            return null;
        }

        public static ObjectId selectEntityId(string msg){
            PromptEntityResult ent = ed.GetEntity(msg);
            if (ent.Status == PromptStatus.OK) {
                return ent.ObjectId;
            }
            return ObjectId.Null;
        }
    }
}