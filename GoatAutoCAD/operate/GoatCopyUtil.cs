using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD.operate
{
    public class GoatCopyUtil : BaseData
    {
        /// <summary>
        /// 移动实体。  移动当前模型空间上的实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <param name="basePt">移动基点</param>
        /// <param name="targetPt">移动终点</param>
        /// <returns>true：成功 false：失败</returns>
        public static void moveById(ObjectId id,Point3d basePt,Point3d targetPt)
        {
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                Entity entity = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                Vector3d vec = targetPt - basePt;
                Matrix3d mt = Matrix3d.Displacement(vec);
                entity.TransformBy(mt);
                trans.Commit();
            }
        }


    }
}