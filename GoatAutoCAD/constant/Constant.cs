using System;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;

namespace GoatAutoCAD.constant {

    public static class Constant {


        // 改变实体颜色    带1个参数的委托
        public static readonly Action<Entity,int> entityColor  = (entity,colorIndex) => entity.ColorIndex = colorIndex;

        // 删除实体  带1个参数的委托
        public static readonly Action<Entity> actionErase  = entity=>entity.Erase();

        // 改变 层表记录 颜色    带1个参数的委托
        public static readonly Action<LayerTableRecord,short> layerColor  = (ltr,colorIndex) => ltr.Color = Color.FromColorIndex(ColorMethod.ByAci,colorIndex);


    }
}