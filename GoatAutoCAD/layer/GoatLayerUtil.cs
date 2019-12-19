using GoatAutoCAD.db;

namespace GoatAutoCAD.operate {

    public static class GoatLayerUtil {

        // 获取所有图层名称
        public static string[] GetAllLayerNames() {
            return GoatDB.GetSymbolTableRecordNames(GoatDB.db.LayerTableId);
        }

    }
}