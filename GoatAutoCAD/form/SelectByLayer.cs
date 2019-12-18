using System;
using System.Linq;
using System.Windows.Forms;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.db;
using GoatAutoCAD.interaction;

namespace GoatAutoCAD.form {

    public partial class SelectByLayer : Form {
        public SelectByLayer() {
            InitializeComponent();
        }


        // 窗体加载事件
        private void SelectByLayer_Load(object sender, EventArgs e) {
            // 获取所有图层名称
            string[] availableLayerNames = GoatDB.GetAllLayerNames();
            // 将所有图层名称 添加到checkListBox控件列表
            availableLayerNames.ForEach(choice => clb.Items.Add(choice));
        }

        // 点击确定按钮
        private void btnOk_Click(object sender, EventArgs e) {
            string[] list = new string[clb.CheckedItems.Count];
            // 将列表复选框的所有选中项 复制到 数组中
            clb.CheckedItems.CopyTo(list,0);
            FilterList filterList = FilterList.Create().Layer(list);
            var ids = QuickSelection.SelectAll(filterList).ToArray();
            // 通过 ids 设置对象为选中状态
            InteractionUtil.SetPickSet(ids);
            // 关闭对话框
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}