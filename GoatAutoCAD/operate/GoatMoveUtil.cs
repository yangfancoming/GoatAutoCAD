using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD.operate
{
    public class GoatMoveUtil : BaseData
    {
        /// <summary>
        /// 移动实体。  移动当前模型空间上的实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <param name="basePt">移动基点</param>
        /// <param name="targetPt">移动终点</param>
        /// <returns>true：成功 false：失败</returns>
        /// 注意： 操作对象 必须要 再 using 代码块中 并且 通过GetObject获取后  才能操作成功！ 否则报错：内部错误 eNotOpenForWrite
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

        public static void moveByEntity(Entity entity,Point3d basePt,Point3d targetPt)
        {
            if (entity == null)  return;
            moveById(entity.Id,basePt,targetPt);
        }


        public static void moveBySelect(Point3d basePt,Point3d targetPt)
        {
            Entity ent = SelectorUtil.select("\n 选择要移动的对象");
            moveByEntity(ent,basePt,targetPt);
        }
    }
}