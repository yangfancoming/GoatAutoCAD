using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.operate {

    public static class GoatMoveUtil {

        // 按照 Vector3d  移动实体
        public static void moveByVector3d(this Entity entity,Vector3d vector3d) {
            Matrix3d mt = Matrix3d.Displacement(vector3d);
            entity.TransformBy(mt);
        }

        // 按照 Point3d  移动实体
        public static void moveByPoint3d(this Entity entity,Point3d p1,Point3d p2) {
            Vector3d vector3d = p1 - p2;
            moveByVector3d(entity,vector3d);
        }
    }
}