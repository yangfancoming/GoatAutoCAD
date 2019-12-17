using Autodesk.AutoCAD.DatabaseServices;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD.operate {

    public class GoatColorUtil:BaseData {

        // 设置实体颜色
        public static void setColor(int colorIndex){
            Entity ent = GoatSelectorUtil.select("\n 选择要更改颜色的对象");
            using (Transaction trans = db.TransactionManager.StartTransaction()){
                Entity entity = trans.GetObject(ent.Id, OpenMode.ForWrite, true) as Entity;
                entity.ColorIndex = colorIndex;
                trans.Commit();
            }
        }


    }
}