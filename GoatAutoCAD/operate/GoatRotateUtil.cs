using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.operate {

    public static class GoatRotateUtil {

        //    旋转
        public static void rotate(this Entity entity,Point3d center, double angle, Vector3d? axis = null) {
            entity.TransformBy(Matrix3d.Rotation(angle, axis ?? Vector3d.ZAxis, center));
        }

    }
}