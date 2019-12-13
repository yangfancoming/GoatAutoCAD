using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.db
{
    public class GoatDB : BaseData
    {

        /// <summary>
        /// 将块表记录加入到块表中
        /// </summary>
        /// <returns></returns>
        public static ObjectId AddBlockTableRecord(BlockTableRecord btr, Database db)
        {
            ObjectId id = new ObjectId();
            using (Transaction transaction = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = transaction.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                id = bt.Add(btr);
                transaction.AddNewlyCreatedDBObject(btr, true);
                transaction.Commit();
            }
            return id;
        }

        public static ObjectId AddToModelSpace(Entity ent)
        {
            ObjectId id = new ObjectId();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
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

        public static List<ObjectId> AddToModelSpace(List<Entity> ents)
        {
            List<ObjectId> list = new List<ObjectId>(ents.Count);
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //③ 以读方式打开图形数据库的块表 ： 默认有 模型空间、布局1、布局2
                BlockTable bt = (BlockTable) trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //④以写方式打开模型空间块表记录.打开一个存储实体的块表记录(通常绘图都在模型空间进行)，所有模型空间的实体都存储在块表的“模型空间”记录中
                BlockTableRecord btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //⑤将图形对象的信息添加到块表记录中,并返回对象的ID号.
                foreach (Entity entity in ents)
                {
                    list.Add(btr.AppendEntity(entity));
                    trans.AddNewlyCreatedDBObject(entity, true); //把对象添加到事务处理中.
                }
                trans.Commit(); //提交事务处理
            }

            return list;
        }

        // 添加 单个 层表
        public static ObjectId addLayerTableR1ecord(LayerTableRecord ltr)
        {
            ObjectId id = new ObjectId();
            // 获取当前文档和数据库，并启动事务；
            using (Transaction acTrans = db.TransactionManager.StartTransaction())
            {
                // 返回当前数据库的图层表
                LayerTable acLyrTbl = acTrans.GetObject(db.LayerTableId,OpenMode.ForWrite) as LayerTable;
                // 检查图层表里是否有图层 MyLayer
                if (!acLyrTbl.Has(ltr.Name))
                {
                    // 以写模式打开图层表
                    acLyrTbl.UpgradeOpen();
                    // 添加新的图层表记录到图层表，添加事务
                    id = acLyrTbl.Add(ltr);
                    acTrans.AddNewlyCreatedDBObject(ltr, true);
                    //提交修改
                    acTrans.Commit();
                }
                // 关闭事务，回收内存；
                return id;
            }

        }
    }
}