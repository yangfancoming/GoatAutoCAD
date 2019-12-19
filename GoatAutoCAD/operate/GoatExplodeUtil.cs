using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.db;

namespace GoatAutoCAD.operate {

    public static class GoatExplodeUtil {


        /// <summary>
        /// Explodes an entity.
        /// </summary>
        /// <param name="entityId">The entity ID.</param>
        /// <returns>The object IDs.</returns>
        public static ObjectId[] Explode(this ObjectId entityId) {
            // 通过id 获取实体
            Entity entity = entityId.QOpenForRead<Entity>();
            // 准备接收被炸开的个体
            DBObjectCollection results = new DBObjectCollection();
            // 炸开实体  到  新建好的集合中
            entity.Explode(results);
            // 删除原来实体
            entityId.QOpenForWrite(Constant.actionErase);
            // 返回已炸开的个体
            return results
                .Cast<Entity>()
                .Select(newEntity => newEntity.AddToCurrentSpace())
                .ToArray(); ;
        }



    }
}