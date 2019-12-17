using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.operate {

    public class GoatColorUtil:BaseData {

        // 设置实体颜色
        public static void setColor(int colorIndex,ObjectId objectId){
            using (Transaction trans = db.TransactionManager.StartTransaction()){
                Entity entity = trans.GetObject(objectId, OpenMode.ForWrite, true) as Entity;
                entity.ColorIndex = colorIndex;
                trans.Commit();
            }
        }


    }
}