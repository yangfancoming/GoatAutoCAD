using System;
using Autodesk.AutoCAD.DatabaseServices;

namespace GoatAutoCAD.constant {

    public static class Constant {

        // 不带参数的委托
        public static Action<Entity> actionColo  = entity => entity.ColorIndex = 1;

        // 带参数的 委托
//       public static Action<Entity,int> actionColo2  = (entity,colorIndex) => entity.ColorIndex = colorIndex;





    }
}