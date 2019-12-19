using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

// 被优化了  优化代码  在 constant 类中
namespace GoatAutoCAD.operate {
    public static class GoatMirrorUtil {

        // 按照参照点 镜像实体
        public static void mirrorByPoint(this Entity entity,Point3d pt1,Point3d pt2) {
            Line3d line3d = new Line3d(pt1,pt2);
            mirrorByLine3d(entity, line3d);
        }

        // 按照参照线 镜像实体
        public static void mirrorByLine3d(this Entity entity,Line3d line3d) {
            Matrix3d mt = Matrix3d.Mirroring(line3d);
            entity.TransformBy(mt);
        }


    }
}