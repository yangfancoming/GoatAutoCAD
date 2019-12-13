

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatEvent))]
namespace GoatAutoCAD
{

    public class GoatEvent
    {

        /**
            加载程序运行” event1”命令后，每当数据库中删除对象时，则跳出警告框显示被删除对象的ObjectId。
            当然你也可以根据你自己的需要更改db_ObjectErased()函数里面的内容来对数据库中删除对象做出所需的反应。
        */
        private readonly DatabaseIOEventHandler _beginSave = Database_BeginSave;
        private readonly ObjectEventHandler _objectAppend = DataBase_ObjectAppended;
        private readonly ObjectErasedEventHandler _objectErased = Database_ObjectErased;

        private static void Database_BeginSave(object sender, DatabaseIOEventArgs e) {
            GoatMessageUtil.msg("FireBeginSave: " + e + "该侦听在文件保存的时候被触发，保存的文件名称为: " + e.FileName);
        }

        private static void DataBase_ObjectAppended(object sender, ObjectEventArgs e) {
            GoatMessageUtil.msg("FireObjectAppended: " + e + "该侦听在数据库对象添加之后被触发，添加的对象的类型是: " + e.DBObject.GetType() );
        }

        private static void Database_ObjectErased(object sender, ObjectErasedEventArgs e) {
            GoatMessageUtil.msg("FireObjectErased: " + e + "该侦听在数据库对象删除之后被触发，删除的对象的类型是: " + e.DBObject.GetType() + "是否删除: " + e.Erased );
            GoatMessageUtil.msg("\n你删除的对象ObjectId为： " + e.DBObject.ObjectId);
        }

        [CommandMethod("event1")]
        public void event1() {
            //添加 BeginSave 的侦听。
            GoatDB.db.BeginSave += _beginSave;
            //添加 ObjectAppended 的侦听。
            GoatDB.db.ObjectAppended += _objectAppend;
            //添加 ObjectErased 的侦听。
            GoatDB.db.ObjectErased += _objectErased;
            GoatMessageUtil.msg("侦听器已经添加完毕，现在您可以尝试对数据库进行操作...");
        }

        [CommandMethod("event2")]
        public void event2() {
            //移除 BeginSave 的侦听。
            GoatDB.db.BeginSave -= _beginSave;
            //移除 ObjectAppended 的侦听。
            GoatDB.db.ObjectAppended -= _objectAppend;
            //移除 ObjectErased 的侦听。
            GoatDB.db.ObjectErased -= _objectErased;
            GoatMessageUtil.msg("侦听器已经添加完毕，现在您可以尝试对数据库进行操作...");
        }
    }

}
