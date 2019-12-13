using System;
using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.operate
{
    public class GoatDictionaryUtil : BaseData
    {
        public static void TraverseNamedDictionary() {
            //开启事务。
            using (Transaction trans = db.TransactionManager.StartTransaction())
            try {
                //获取数据库中 NamedDictionary 对应的 ObjectId。
                ObjectId namedDictionaryId = db.NamedObjectsDictionaryId;
                //通过指定的 ObjectId 打开数据库的 NamedDictionary。
                DBDictionary namedDictionary = trans.GetObject(namedDictionaryId, OpenMode.ForRead) as DBDictionary;
                //输出 NamedDictionary 中的数据数量。
                ed.WriteMessage("---------------命名对象词典---------------\r\n");
                ed.WriteMessage(String.Format("当前词典中的数据量为: {0:G}\r\n", namedDictionary.Count));
                //遍历 NamedDictionary 中的入口。
                ed.WriteMessage("---------------词典入口---------------\r\n");
                {
                    int index = 0;
                    foreach (DBDictionaryEntry entry in namedDictionary) {
                        ed.WriteMessage(String.Format("第 {0:G} 个入口，其键为: {1}, 其值为: {2}, 值的对象类型为: {3}\r\n",++index, entry.Key,entry.Value.ToString(),trans.GetObject(entry.Value, OpenMode.ForRead).GetType().Name));
                    }
                }
                trans.Commit();
            } catch (Autodesk.AutoCAD.Runtime.Exception e) {
                ed.WriteMessage(e.Message);
                //如果操作过程中产生了任何异常，则中止事务。
                trans.Abort();
            } finally {
                //在final语句块中释放事务。
                trans.Dispose();
            }
        }
    }
}