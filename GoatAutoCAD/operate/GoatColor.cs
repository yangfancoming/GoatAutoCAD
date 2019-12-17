

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatColor))]
namespace GoatAutoCAD{

    public class GoatColor{

        [CommandMethod("MyGroup", "color1", "color1", CommandFlags.Modal)]
        public void color1(){
            GoatColorUtil.setColor(1);
        }

    }

}
