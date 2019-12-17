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


        /// <summary>
        /// 按照参照线 镜像实体    带2个参数的委托
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="mirrorPt1">镜像点1</param>
        /// <param name="mirrorPt2">镜像点2</param>
        public static readonly Action<Entity, Line3d> actionMirrorByLine = (entity, line3d) => {
            Matrix3d mt = Matrix3d.Mirroring(line3d);
            entity.TransformBy(mt);
        };

        /// <summary>
        /// 按照参照点 镜像实体    带3个参数的委托
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="mirrorPt1">镜像点1</param>
        /// <param name="mirrorPt2">镜像点2</param>
        public static readonly Action<Entity, Point3d,Point3d> actionMirrorByPoint = (entity,mirrorPt1,mirrorPt2) => {
            Line3d line3d = new Line3d(mirrorPt1, mirrorPt2);
            actionMirrorByLine(entity, line3d);
        };



    }
}