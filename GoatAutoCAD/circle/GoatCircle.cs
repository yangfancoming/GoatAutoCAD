

using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatCircle))]
namespace GoatAutoCAD
{

    public class GoatCircle
    {

        [CommandMethod("MyGroup", "circle1", "circle1", CommandFlags.Modal)]
        public void circle1()
        {
            Circle circle = Circle(new Point3d(0, 0, 0),10);
            GoatDB.AddToModelSpace(circle);
        }

        /// <summary>
        /// 由圆心和半径创建圆
        /// </summary>
        /// <param name="cenPt">圆心</param>
        /// <param name="radius">半径</param>
        /// <returns>圆</returns>
        public static Circle Circle(Point3d cenPt, double radius)
        {
            return new Circle(cenPt, Vector3d.ZAxis, radius);
        }


        /// <summary>
        /// 由三点(Point3d)创建圆
        /// </summary>
        /// <param name="pt1">点1</param>
        /// <param name="pt2">点2</param>
        /// <param name="pt3">点3</param>
        /// <returns>过三点的圆</returns>
        public static Circle Circle(Point3d pt1, Point3d pt2, Point3d pt3)
        {
            Vector3d va = pt1.GetVectorTo(pt2);
            Vector3d vb = pt1.GetVectorTo(pt3);
            if (va.GetAngleTo(vb) == 0 | va.GetAngleTo(vb) == Math.PI)
            {
                return new Circle();
            }
            CircularArc3d geoArc = new CircularArc3d(pt1, pt2, pt3);
            Point3d cenPt = new Point3d(geoArc.Center.X, geoArc.Center.Y, 0);
            double radius = geoArc.Radius;
            return new Circle(cenPt, Vector3d.ZAxis, radius);
        }
    }

}
