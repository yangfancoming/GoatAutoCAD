using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.line
{
    public class GoatLine
    {
        /// <summary>
        /// 由两点创建直线
        /// </summary>
        /// <param name="pt1">点1</param>
        /// <param name="pt2">点2</param>
        /// <returns>点1为始点,点2为终点的直线</returns>
        public static Line Line(Point3d pt1, Point3d pt2)
        {
            return new Line(pt1, pt2);
        }

        /// <summary>
        /// 由两点坐标创建直线
        /// </summary>
        /// <param name="x1">起点X坐标</param>
        /// <param name="y1">起点Y坐标</param>
        /// <param name="z1">起点Z坐标</param>
        /// <param name="x2">终点X坐标</param>
        /// <param name="y2">终点Y坐标</param>
        /// <param name="z2">终点Z坐标</param>
        /// <returns>直线</returns>
        public static Line Line(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return new Line(new Point3d(x1, y1, z1), new Point3d(x2, y2, z2));
        }
    }
}