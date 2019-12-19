using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.db {

    public static class GoatDB  {

        public static Database db = Application.DocumentManager.MdiActiveDocument.Database;
        public static Document doc = Application.DocumentManager.MdiActiveDocument;
        public static Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;


        // 获取所有图层名称
//        public static string[] GetAllLayerNames() {
//            return GetSymbolTableRecordNames(db.LayerTableId);
//        }

        public static string[] GetSymbolTableRecordNames(ObjectId symbolTableId) {
            return
                // 通过符号表id获取符号表所有记录的id
                GetSymbolTableRecords(symbolTableId)
                // 通过符号表所有记录的id  从数据库中获取对应的实体
                .QOpenForRead<SymbolTableRecord>()
                // 投影实体集合集合中的 Name属性
                .Select(record => record.Name).ToArray();
        }

        public static Database GetDatabase(IEnumerable<ObjectId> objectIds) {
            return objectIds.Select(id => id.Database).Distinct().Single();
        }


        // 通过符号表id获取符号表所有记录的id
        public static ObjectId[] GetSymbolTableRecords(ObjectId symbolTableId){
            using (var trans = symbolTableId.Database.TransactionManager.StartTransaction()){
                SymbolTable table = trans.GetObject(symbolTableId, OpenMode.ForRead) as SymbolTable;
                return table.Cast<ObjectId>().ToArray();
            }
        }


        /// <summary>
        /// 将块表记录加入到块表中
        /// </summary>
        /// <returns></returns>
        public static ObjectId AddBlockTableRecord(this BlockTableRecord btr){
            ObjectId id = new ObjectId();
            using (Transaction trans = db.TransactionManager.StartTransaction()){
                BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                id = bt.Add(btr);
                trans.AddNewlyCreatedDBObject(btr, true);
                trans.Commit();
            }
            return id;
        }

        /// <summary>
        /// Adds an entity to current space.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="db">The database.</param>
        /// <returns>The objected IDs.</returns>
        /// 空合并运算符(??)：
        /// 用于定义可空类型和引用类型的默认值。如果此运算符的左操作数不为null，则此运算符将返回左操作数，否则返回右操作数。
        /// 例如：a??b 当a为null时则返回b，a不为null时则返回a本身。
        public static ObjectId AddToCurrentSpace(this Entity entity){
            using (var trans = db.TransactionManager.StartTransaction()) {
                var currentSpace = trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite, false) as BlockTableRecord;
                var id = currentSpace.AppendEntity(entity);
                trans.AddNewlyCreatedDBObject(entity, true);
                trans.Commit();
                return id;
            }
        }


        public static ObjectId AddToModelSpace(this Entity ent){
            ObjectId id = new ObjectId();
            using (Transaction trans = db.TransactionManager.StartTransaction()){
                //③ 以读方式打开图形数据库的块表 ： 默认有 模型空间、布局1、布局2
                BlockTable bt = (BlockTable) trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //④以写方式打开模型空间块表记录.打开一个存储实体的块表记录(通常绘图都在模型空间进行)，所有模型空间的实体都存储在块表的“模型空间”记录中
                BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //⑤将图形对象的信息添加到块表记录中,并返回对象的ID号.
                id = btr.AppendEntity(ent);
                trans.AddNewlyCreatedDBObject(ent, true); //把对象添加到事务处理中.
                trans.Commit(); //提交事务处理
            }
            return id;
        }

        public static IEnumerable<ObjectId> AddToModelSpace(this IEnumerable<Entity> ents) {
            List<ObjectId> list = new List<ObjectId>(ents.Count());
            using (Transaction trans = db.TransactionManager.StartTransaction()) {
                //③ 以读方式打开图形数据库的块表 ： 默认有 模型空间、布局1、布局2
                BlockTable bt = (BlockTable) trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //④以写方式打开模型空间块表记录.打开一个存储实体的块表记录(通常绘图都在模型空间进行)，所有模型空间的实体都存储在块表的“模型空间”记录中
                BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //⑤将图形对象的信息添加到块表记录中,并返回对象的ID号.
                ents.ForEach(ent => {
                    list.Add(btr.AppendEntity(ent));
                    trans.AddNewlyCreatedDBObject(ent, true); //把对象添加到事务处理中.
                });
                trans.Commit(); //提交事务处理
            }
            return list;
        }

        // 添加 单个 层表
        public static ObjectId addLayerTableR1ecord(this LayerTableRecord ltr){
            ObjectId id = new ObjectId();
            // 获取当前文档和数据库，并启动事务；
            using (Transaction acTrans = db.TransactionManager.StartTransaction()){
                // 返回当前数据库的图层表
                LayerTable acLyrTbl = acTrans.GetObject(db.LayerTableId,OpenMode.ForWrite) as LayerTable;
                // 检查图层表里是否有图层 MyLayer
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