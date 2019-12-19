using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;

namespace GoatAutoCAD.operate {

    public static class GoatPolylineUtil {


        public static ObjectId RectangAdd(Point3d point1, Point3d point2){
            return Rectang(point1, point2).AddToCurrentSpace();
        }


        public static Polyline Rectang(Point3d point1, Point3d point2){
            var result = Pline(point1, new Point3d(point1.X, point2.Y, 0), point2, new Point3d(point2.X, point1.Y, 0));
            result.Closed = true;
            return result;
        }


        public static Polyline Pline(params Point3d[] points){

            return Pline(points.ToList());
        }


        /// <summary>
        /// Creates a polyline by a sequence of points and a global width.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="globalWidth">The global width. Default is 0.</param>
        /// <returns>The result.</returns>
        public static Polyline Pline(IEnumerable<Point3d> points, double globalWidth = 0) {
            return Pline(
                vertices: points.Select(point => Tuple.Create(point, 0d)).ToList(),
                globalWidth: globalWidth);
        }


        public static Polyline Pline(List<Tuple<Point3d, double>> vertices, double globalWidth = 0) {
            var poly = new Polyline();
            Enumerable
                .Range(0, vertices.Count)
                .ForEach(index => poly.AddVertexAt(
                    index: index,
                    pt: vertices[index].Item1.ToPoint2d(),
                    bulge: vertices[index].Item2,
                    startWidth: globalWidth,
                    endWidth: globalWidth));

            return poly;
        }

        public static Point2d ToPoint2d(this Point3d point) {
            return new Point2d(point.X, point.Y);
        }

    }
}