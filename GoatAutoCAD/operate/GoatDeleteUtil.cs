using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.operate {

    public class GoatDeleteUtil : BaseData {

        /// <summary>
        /// 删除多个实体
        /// 删除当前模型空间上的实体。
        /// </summary>
        /// <param name="ids">实体ID</param>
        public static void deleteByIds(ObjectIdCollection ids){
            using (Transaction trans = db.TransactionManager.StartTransaction()) {
                foreach (ObjectId id in ids) {
                    Entity entity = (Entity)trans.GetObject(id, OpenMode.ForWrite, true);
                    if (entity == null || entity.IsErased || entity is ProxyEntity)
                        continue;
                    entity.Erase(true);
                }
                trans.Commit();
            }
        }

    }
}