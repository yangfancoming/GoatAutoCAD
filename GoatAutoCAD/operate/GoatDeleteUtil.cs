using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD.operate
{
    public class GoatDeleteUtil : BaseData
    {

        /// <summary>
        /// 删除多个实体
        /// 删除当前模型空间上的实体。
        /// </summary>
        /// <param name="ids">实体ID</param>
        public static void deleteByIds(ObjectIdCollection  ids)
        {
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId id in ids)
                {
                    Entity entity = (Entity)trans.GetObject(id, OpenMode.ForWrite, true);
                    if (entity == null || entity.IsErased || entity is ProxyEntity)
                        continue;
                    entity.Erase(true);
                }
                trans.Commit();
            }
        }

        /// <summary>
        /// 删除实体。  删除当前模型空间上的实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns>true：成功 false：失败</returns>
        /// 注意： 操作对象 必须要 再 using 代码块中 并且 通过GetObject获取后  才能操作成功！ 否则报错：内部错误 eNotOpenForWrite
        public static void deleteById(ObjectId id)
        {
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                Entity entity = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                entity.Erase(true);
                trans.Commit();
            }
        }

        /// <summary>
        /// 删除实体。  删除当前模型空间上的实体。
        /// </summary>
        /// <param name="entity">要删除的实体对象</param>
        /// <returns>true：成功 false：失败</returns>
        public static void deleteByEntity(Entity entity)
        {
            if (entity == null)  return;
            deleteById(entity.Id);
        }

        /// <summary>
        /// 删除用户选择的实体对象
        /// </summary>
        public static void deleteBySelect()
        {
            Entity ent = GoatSelectorUtil.select("\n 选择要删除的对象");
            deleteByEntity(ent);
        }
    }
}