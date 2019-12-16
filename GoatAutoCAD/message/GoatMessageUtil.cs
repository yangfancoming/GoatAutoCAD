using GoatAutoCAD.baseutil;

namespace GoatAutoCAD.operate {
    public class GoatMessageUtil : BaseData {

        /// <summary>
        /// 移动实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <param name="basePt">移动基点</param>
        /// <param name="targetPt">移动终点</param>
        /// <returns>true：成功 false：失败</returns>
        public static void msg(string msg) {
            ed.WriteMessage("\n");
            ed.WriteMessage(msg);
        }

        /// <summary>
        /// Writes message line.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public static void msg(string message, params object[] args){
            ed.WriteMessage("\n");
            ed.WriteMessage(message, args);
        }




    }
}