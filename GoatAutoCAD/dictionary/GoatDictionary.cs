

using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.operate;

[assembly: CommandClass(typeof(GoatDictionary))]
namespace GoatAutoCAD
{

    public class GoatDictionary
    {
        // 命令行消息提示
        [CommandMethod("MyGroup", "dic1", "dic1", CommandFlags.Modal)]
        public void msg1()
        {
            GoatDictionaryUtil.TraverseNamedDictionary();
        }


    }

}
