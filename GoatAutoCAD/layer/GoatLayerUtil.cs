using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.db;
using GoatAutoCAD.baseutil;
namespace GoatAutoCAD.operate {

    public static class GoatLayerUtil {

        // 获取所有图层名称
        public static string[] GetAllLayerNames() {
            return GoatDB.GetSymbolTableRecordNames(GoatDB.db.LayerTableId);
        }

        /// <summary>
        /// 通过实体id 将实体添加到指定层  若层不存在 则创建
        /// </summary>
        /// <param name="entityId"> 待添加到指定层的实体id</param>
        /// <param name="layer">添加到指定层的名称</param>
        public static void SetLayer(this ObjectId entityId, string layer) {
            entityId.QOpenForWrite<Entity>(entity => entity.LayerId = GetLayerId(layer));
        }

        /// <summary>
        /// Gets layer ID by name. Creates new if not found.
        /// </summary>
        /// <param name="layerName">The layer name.</param>
        /// <param name="db">The database.</param>
        /// <returns>The layer ID.</returns>
        public static ObjectId GetLayerId(string layerName, Database db = null) {
            return GoatDB.GetSymbolTableRecord(
                (db ?? HostApplicationServices.WorkingDatabase).LayerTableId,
                layerName,
                create: () => new LayerTableRecord {Name = layerName});
        }
    }
}