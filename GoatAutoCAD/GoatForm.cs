using System;
using System.Windows.Forms;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD
{
    public partial class GoatForm : Form
    {
        public TextBox _textBox ;
        public GoatForm()
        {
            InitializeComponent();
        }

        //点击“切入到 AutoCAD 拾取点”按钮窗体自动隐藏，程序焦点切换到 AutoCAD 主界面
        private void button1_Click(object sender, EventArgs e)
        {
            using (EditorUserInteraction edUsrInt = BaseData.ed.StartUserInteraction(this))
            {
                //交互过程
                Point3d pt =  PickUtill.pick("\n n选择点");
                _textBox = textBox1;
                _textBox.Text  = "(" + pt.X + "," + pt.Y + "," + pt.Z + ")";
                //交互结束
                edUsrInt.End();
                Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}
