using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace GoatAutoCAD.baseutil
{
    public  class BaseData
    {
        public static Database db = Application.DocumentManager.MdiActiveDocument.Database;
        public static Document doc = Application.DocumentManager.MdiActiveDocument;
        public static Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
    }
}