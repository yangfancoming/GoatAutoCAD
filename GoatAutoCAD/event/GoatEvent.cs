

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;

[assembly: CommandClass(typeof(GoatEvent))]
namespace GoatAutoCAD
{

    public class GoatEvent
    {

        [CommandMethod("MyGroup", "event1", "event1", CommandFlags.Modal)]
        public void event1()
        {
            BaseData.db.ObjectErased += db_ObjectErased;
        }

        /**
            加载程序运行” event1”命令后，每当数据库中删除对象时，则跳出警告框显示被删除对象的ObjectId。
            当然你也可以根据你自己的需要更改db_ObjectErased()函数里面的内容来对数据库中删除对象做出所需的反应。
        */
        public static void db_ObjectErased(object sender, ObjectErasedEventArgs e) {
            Application.ShowAlertDialog("\n你删除的对象ObjectId为： " + e.DBObject.ObjectId);
        }

    }

}
