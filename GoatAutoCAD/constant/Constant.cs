using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.constant {

    public static class Constant {

        /// <summary>
        /// 改变实体颜色    带1个参数的委托
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="mirrorPt1">镜像点1</param>
        /// <param name="mirrorPt2">镜像点2</param>
        public static readonly Action<Entity> actionColo  = entity => entity.ColorIndex = 1;

        public static readonly Action<Entity> actionErase  = entity=>entity.Erase();


        // 按照参照线 镜像实体
        public static void mirrorByLine3d(this Entity entity,Line3d line3d) {
            Matrix3d mt = Matrix3d.Mirroring(line3d);
            entity.TransformBy(mt);
        }

        // 按照参照点 镜像实体
        public static void mirrorByPoint(this Entity entity,Point3d pt1,Point3d pt2) {
            Line3d line3d = new Line3d(pt1,pt2);
            mirrorByLine3d(entity, line3d);
        }


        /// <summary>
        /// 按照参照线 移动实体    带2个参数的委托
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="mirrorPt1">镜像点1</param>
        /// <param name="mirrorPt2">镜像点2</param>
        public static readonly Action<Entity, Vector3d> actionMoveByVector3d = (entity,vector3d) => {
            Matrix3d mt = Matrix3d.Displacement(vector3d);
            entity.TransformBy(mt);
        };

        /// <summary>
        /// 按照参照点 移动实体    带3个参数的委托
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="mirrorPt1">镜像点1</param>
        /// <param name="mirrorPt2">镜像点2</param>
        public static readonly Action<Entity, Point3d,Point3d> actionMoveByPoint = (entity,mirrorPt1,mirrorPt2) => {
            Vector3d line3d = mirrorPt2 - mirrorPt1;
            actionMoveByVector3d(entity, line3d);
        };


    }
}