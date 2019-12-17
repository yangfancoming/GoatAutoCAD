using System;
using Autodesk.AutoCAD.DatabaseServices;

namespace GoatAutoCAD.constant {

    public static class Constant {


        // 改变实体颜色    带1个参数的委托
        public static readonly Action<Entity> actionColo  = entity => entity.ColorIndex = 1;

        // 删除实体  带1个参数的委托
        public static readonly Action<Entity> actionErase  = entity=>entity.Erase();






    }
}