

using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using GoatAutoCAD;
using GoatAutoCAD.db;

[assembly: CommandClass(typeof(GoatText))]
namespace GoatAutoCAD {

    public class GoatText {


        // 单行文字
        [CommandMethod("MyGroup", "text1", "text1", CommandFlags.Modal)]
        public void text1() {
            DBText dbText = new DBText();
            // 文字内容
            dbText.TextString = "我是单行文字~";
            // 文字高度
            dbText.Height = 100;
            // 插入点
            dbText.Position = Point3d.Origin;
            // 旋转角度
            dbText.Rotation = Math.PI * 0.1;
            // 是否在 X/Y 轴 镜像
            dbText.IsMirroredInX = false;
            dbText.IsMirroredInY = false;
            // 水平对齐模式
            dbText.HorizontalMode = TextHorizontalMode.TextCenter;
            // 垂直对齐模式
            dbText.VerticalMode = TextVerticalMode.TextTop;
            // 对齐点
            dbText.AlignmentPoint = dbText.Position;
            dbText.AddToCurrentSpace();
        }


        // 多行文字
        [CommandMethod("MyGroup", "text2", "text2", CommandFlags.Modal)]
        public void text2() {
            MText mText = new MText();
            // 文字框内容
            mText.Contents = "我是多行文字~";
            // 文字框 高度
            mText.Height = 100;
            // 文字高度
            mText.TextHeight = 200;
            // 文字框宽度  如果文字超过该宽度则自动换行
            mText.Width = 50;
            // 插入点
            mText.Location = new Point3d(100,100,0);
            // 旋转角度
            mText.Rotation = Math.PI * 0.25;
            mText.AddToCurrentSpace();
        }


    }

}
