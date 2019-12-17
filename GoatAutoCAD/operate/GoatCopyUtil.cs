using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.operate {

    public class GoatCopyUtil : BaseData {
        /// <summary>
        /// 移动实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <param name="basePt">移动基点</param>
        /// <param name="targetPt">移动终点</param>
        /// <returns>true：成功 false：失败</returns>
        public static void copyById(ObjectId id,Point3d sourcePt,Point3d targetPt){
            using (Transaction trans = db.TransactionManager.StartTransaction()){
                Entity entity = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                Matrix3d mt = Matrix3d.Displacement(targetPt - sourcePt);
                entity.GetTransformedCopy(mt);
                trans.Commit();
            }
        }


    }
}