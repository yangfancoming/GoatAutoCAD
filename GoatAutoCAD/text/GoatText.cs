using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace GoatAutoCAD.text
{
    public class GoatText
    {
        /// <summary>
        /// 由插入点、文字内容、文字样式、文字高度创建单行文字
        /// </summary>
        /// <param name="textString">文字内容</param>
        /// <param name="position">基点</param>
        /// <param name="height">文字高度</param>
        /// <param name="rot">文字转角</param>
        /// <param name="isfield">是否是包含域</param>
        /// <returns></returns>
        public static DBText DBText(string textString, Point3d position, double height, double rot, bool isfield)
        {
            DBText txt = new DBText();
            txt.Position = position;
            txt.Height = height;
            txt.Rotation = rot;
            if (isfield)
            {
                Field field = new Field(textString);
                txt.SetField(field);
            }
            else
                txt.TextString = textString;

            return txt;
        }

        /// <summary>
        /// 由插入点、文字内容、文字样式、文字高度、文字宽度创建多行文字
        /// </summary>
        /// <param name="textString">文字内容</param>
        /// <param name="location">基点</param>
        /// <param name="height">文字高度</param>
        /// <param name="width">宽度</param>
        /// <param name="rot">文字转角</param>
        /// <param name="isfield">是否是包含域</param>
        /// <returns></returns>
        public static MText Mtext(string textString,Point3d location, double height, double width,double rot,bool isfield)
        {
            MText txt = new MText();
            txt.Location = location;
            txt.TextHeight = height;
            txt.Width = width;
            txt.Rotation = rot;
            if (isfield)
            {
                Field field = new Field(textString);
                txt.SetField(field);
            }
            else
                txt.Contents = textString;
            return txt;
        }
    }
}