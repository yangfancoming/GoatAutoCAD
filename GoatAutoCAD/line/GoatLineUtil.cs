using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.db;

namespace GoatAutoCAD.operate {

    public static class GoatLineUtil {

//        public static Line Line(Point3d point1, Point3d point2){
//            return new Line(point1, point2);
//        }

//        public static Line[] Line(params Point3d[] points) {
//            return Enumerable
//                .Range(0, points.Length - 1)
//                .Select(index => Line(points[index], points[index + 1]))
//                .ToArray();
//        }

        public static ObjectId Line(Point3d point1, Point3d point2){

            return new Line(point1, point2).AddToCurrentSpace();
        }

    }
}