using System;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;

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
            entityId.QOpenForWrite<Entity>(entity => entity.LayerId = GetLayerName(layer,true));
        }

        /// <summary>
        /// Gets layer ID by name. Creates new if not found.
        /// </summary>
        /// <param name="layerName">The layer name.</param>
        /// <param name="mark"> 如果没找到 是否新建 </param>
        /// <returns>The layer ID.</returns>
        public static ObjectId GetLayerName(string layerName,bool mark = false) {
            if (mark) {
                return GoatDB.GetSymbolTableRecord(GoatDB.db.LayerTableId, layerName, () => new LayerTableRecord {Name = layerName});
            }
            return GoatDB.GetSymbolTableRecord(GoatDB.db.LayerTableId, layerName);
        }



        // 添加 单个 层表
        public static ObjectId addLayerTableR1ecord(this LayerTableRecord ltr) {
            Database db = GoatDB.db;
            ObjectId id = new ObjectId();
            // 获取当前文档和数据库，并启动事务；
            using (Transaction acTrans = db.TransactionManager.StartTransaction()){
                // 返回当前数据库的图层表
                LayerTable acLyrTbl = acTrans.GetObject(db.LayerTableId,OpenMode.ForWrite) as LayerTable;
                // 检查图层表里是否已经存在了 待添加的图层  如果已经存在则不做任何处理
                if (!acLyrTbl.Has(ltr.Name)){
                    // 以写模式打开图层表
                    acLyrTbl.UpgradeOpen();
                    // 添加新的图层表记录到图层表，添加事务
                    id = acLyrTbl.Add(ltr);
                    acTrans.AddNewlyCreatedDBObject(ltr, true);
                    //提交修改
                    acTrans.Commit();
                }
                return id;// 关闭事务，回收内存；
            }
        }
    }
}