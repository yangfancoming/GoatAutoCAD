using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.selector
{
    public class GoatSelectorUtil : BaseData
    {
        /// <summary>
        /// 提示用户选择单个实体
        /// </summary>
        /// <param name="msg">选择提示</param>
        /// <returns>实体对象</returns>
        public static Entity select(string msg)
        {
            Entity entity = null;
            PromptEntityResult ent = ed.GetEntity(msg);
            if (ent.Status == PromptStatus.OK)
            {
                using (Transaction transaction = db.TransactionManager.StartTransaction())
                {
                    entity = (Entity)transaction.GetObject(ent.ObjectId, OpenMode.ForWrite, true);
                    transaction.Commit();
                }
            }
            return entity;
        }

        public static void Select2()
        {
            PromptSelectionOptions selectionOp = new PromptSelectionOptions();
            PromptSelectionResult ssRes = ed.GetSelection(selectionOp);
            if (ssRes.Status == PromptStatus.OK)
            {
                SelectionSet SS = ssRes.Value;
                int nCount = SS.Count;
                ed.WriteMessage("选择了{0}个实体" , nCount);
            }
        }

        public static void Select3()
        {
            PromptSelectionOptions selectionOp = new PromptSelectionOptions();
            //创建选择集过滤器，只选择块对象
            TypedValue[] filList = new TypedValue[1];
            filList[0] = new TypedValue((int)DxfCode.Start,"INSERT");
            SelectionFilter filter = new SelectionFilter(filList);
            PromptSelectionResult ssRes = ed.GetSelection(selectionOp, filter);
            if (ssRes.Status == PromptStatus.OK)
            {
                SelectionSet SS = ssRes.Value;
                int nCount = SS.Count;
                ed.WriteMessage("选择了{0}个块" , nCount);
            }
        }



        /// <summary>
        /// 选择集合
        /// </summary>
        /// <returns></returns>
        public static DBObjectCollection selects()
        {
            Entity entity;
            DBObjectCollection EntityCollection = new DBObjectCollection();
            PromptSelectionResult ents = ed.GetSelection();
            if (ents.Status == PromptStatus.OK)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    SelectionSet SS = ents.Value;
                    foreach (ObjectId id in SS.GetObjectIds())
                    {
                        entity = (Entity)trans.GetObject(id, OpenMode.ForWrite, true);
                        if (entity != null)
                            EntityCollection.Add(entity);
                    }
                    trans.Commit();
                }
            }
            return EntityCollection;
        }



        /// <summary>
        /// 选择所有对象
        /// </summary>
        /// <returns></returns>
        public static DBObjectCollection selectAll()
        {
            Entity entity;
            DBObjectCollection EntityCollection = new DBObjectCollection();
            PromptSelectionResult ents = ed.SelectAll();
            if (ents.Status == PromptStatus.OK)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    SelectionSet ss = ents.Value;
                    foreach (ObjectId id in ss.GetObjectIds())
                    {
                        entity = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                        if (entity != null)
                            EntityCollection.Add(entity);
                    }
                    trans.Commit();
                }
            }
            return EntityCollection;
        }



    }
}