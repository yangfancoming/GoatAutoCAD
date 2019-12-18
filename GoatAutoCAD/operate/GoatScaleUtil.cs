using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.operate {

    public static class GoatScaleUtil {

        //    旋转
        public static void scale(this Entity entity,Point3d basePoint,double scale) {
            entity.TransformBy(Matrix3d.Scaling(scale, basePoint));
        }


    }
}