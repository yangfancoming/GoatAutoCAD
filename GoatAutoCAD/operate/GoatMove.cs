

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(GoatMove))]
namespace GoatAutoCAD
{

    public class GoatMove
    {
        [CommandMethod("MyGroup", "move1", "move1", CommandFlags.Modal)]
        public void move1()
        {
            Entity ent = SelectorUtil.select("\n 选择对象");
            Point3d p1 = new Point3d(0,0,0);
            Point3d p2 = new Point3d(100,100,0);
//            move(ent, p1, p2);
            move(ent);
        }


        /// <summary>
        /// 指定基点与目标点移动实体
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="BasePt">基点</param>
        /// <param name="TargetPt">目标点</param>
        public static void move(Entity ent, Point3d basePt, Point3d targetPt)
        {
            Vector3d vec = targetPt - basePt;
            Matrix3d mt = Matrix3d.Displacement(vec);
            ent.TransformBy(mt);
        }

        /// <summary>
        /// 指定基点与目标点移动实体
        /// </summary>
        /// <param name="ent">实体对象</param>
        /// <param name="BasePt">基点</param>
        /// <param name="TargetPt">目标点</param>
        ///
        ///
        public static void move(Entity ent)
        {
            // 创建一个矩阵，使用(0,0,0)到(2,0,0)的矢量移动圆
            Point3d acPt3d = new Point3d(0, 0, 0);
            Vector3d acVec3d = acPt3d.GetVectorTo(new Point3d(2, 0, 0));
            Matrix3d mt = Matrix3d.Displacement(acVec3d);
            ent.TransformBy(mt);
        }
    }

}
