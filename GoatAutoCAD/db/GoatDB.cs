using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.db
{
    public class GoatDB : BaseData
    {
        public static ObjectId AddToModelSpace(Entity ent) {
            ObjectId entId;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //③ 以读方式打开图形数据库的块表 ： 默认有 模型空间、布局1、布局2
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //④以写方式打开模型空间块表记录.打开一个存储实体的块表记录(通常绘图都在模型空间进行)，所有模型空间的实体都存储在块表的“模型空间”记录中
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //⑤将图形对象的信息添加到块表记录中,并返回对象的ID号.
                entId = btr.AppendEntity(ent);
                trans.AddNewlyCreatedDBObject(ent, true); //把对象添加到事务处理中.
                trans.Commit(); //提交事务处理
            }
            return entId;
        }
        
        public static List<ObjectId> AddToModelSpace(List<Entity> ents) {
            List<ObjectId> list = new List<ObjectId>(ents.Count);
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //③ 以读方式打开图形数据库的块表 ： 默认有 模型空间、布局1、布局2
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //④以写方式打开模型空间块表记录.打开一个存储实体的块表记录(通常绘图都在模型空间进行)，所有模型空间的实体都存储在块表的“模型空间”记录中
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
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

    }
}