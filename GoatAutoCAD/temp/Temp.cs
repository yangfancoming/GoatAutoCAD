

using System.Collections.Generic;
using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.constant;
using GoatAutoCAD.interaction;
using GoatAutoCAD.operate;
using GoatAutoCAD.selector;

[assembly: CommandClass(typeof(Temp))]
namespace GoatAutoCAD {

    public static class  Temp {

        //  要求用户选择一个/多个实体 按下回车后  将所有用户选择的实体用矩形包裹起来！
        [CommandMethod("ShowExtents", CommandFlags.UsePickSet)]
        public static void Temp1() {
            ObjectId[] ids = QuickSelection.GetSelection("\n Select entity");
            var extents = ids.GetExtents();
            // 画出矩形后 返回矩形id
            var rectId = GoatPolylineUtil.RectangAdd(extents.MinPoint, extents.MaxPoint);
            InteractionUtil.GetString("\nPress ENTER to reset...");
            // 删除矩形
            rectId.QOpenForWrite(Constant.actionErase);
        }

        public static Extents3d GetExtents(this IEnumerable<ObjectId> entityIds){
            return GetExtents(entityIds.QOpenForRead<Entity>());
        }

        public static Extents3d GetExtents(this IEnumerable<Entity> entities) {
            Extents3d extent = entities.First().GeometricExtents;
            foreach (var ent in entities){
                extent.AddExtents(ent.GeometricExtents);
            }
            return extent;
        }




    }

}
