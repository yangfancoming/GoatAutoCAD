

using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.selector {

    public class GoatPickUtill : BaseData {
        /// <summary>
        /// 提示用户拾取点
        /// </summary>
        /// <param name="msg">提示</param>
        /// <returns>返回Point3d</returns>
        /// <summary>
        public static Point3d getPoint(string msg){
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
        public static Entity getEntity(string msg){
            PromptEntityResult ent = ed.GetEntity(msg);
            if (ent.Status == PromptStatus.OK) {
                return ent.ObjectId.QOpenForRead<Entity>();
            }
            return null;
        }

        public static ObjectId getEntityId(string msg){
            PromptEntityResult ent = ed.GetEntity(msg);
            if (ent.Status == PromptStatus.OK) {
                return ent.ObjectId;
            }
            return ObjectId.Null;
        }

        public static ObjectId getEntityId(string message, Type allowedType, bool exactMatch = true)  {
            PromptEntityOptions opt = new PromptEntityOptions(message);
            // 设置用户选择指定类型之外的图形是的提示信息   此行代码必须在 AddAllowedClass 之前 否则报错
            opt.SetRejectMessage("Allowed type: " + allowedType.Name);
            // 设置 允许用户选择的图形类型  eg：只允许选择直线类型
            opt.AddAllowedClass(allowedType, exactMatch);
            PromptEntityResult res = ed.GetEntity(opt);
            if (res.Status == PromptStatus.OK){
                return res.ObjectId;
            }
            return ObjectId.Null;
        }
    }
}