using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EvotorStockManager
{
    public partial class GroupPicker : Form
    {
        public string idGroup { get; set; }
        public List<string> childGroups = new List<string>();

        public GroupPicker(string idGroup)
        {
            InitializeComponent();
            this.idGroup = idGroup;
        }

        private void GroupPicker_Load(object sender, EventArgs e)
        {
            BindTreeview();
        }

        private void BindTreeview()
        {
            List<EvotorProductV2> parentRows = Main.groups.Where(p => p.parent_id==null).ToList();

            //пустая нода группы
            TreeNode empty = new TreeNode();
            empty.Text = "БЕЗ ГРУППЫ";
            empty.Tag = null;
            tvGroups.Nodes.Add(empty);
            
            //корневые ноды
            foreach (EvotorProductV2 row in parentRows) 
            {
                TreeNode node = new TreeNode();
                node.Text = row.name;
                node.Tag = row.id;
                int nodeNum = tvGroups.Nodes.Add(node);
                if (row.id == idGroup)
                {
                    tvGroups.SelectedNode = node;
                    tvGroups.Focus();
                }
                AddChildNodes(Convert.ToInt32(row.code), node);
            }
        }

        //вложенные ноды
        private void AddChildNodes(int catId, TreeNode node) 
        {
            List<EvotorProductV2> childRows = Main.groups.Where(p => p.parent_id == (string)node.Tag).ToList(); 

            if (childRows.Count == 0) { return; }

            foreach (EvotorProductV2 row in childRows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = row.name;
                childNode.Tag = row.id;
                int nodeNum = node.Nodes.Add(childNode);
                if (row.id == idGroup)
                {
                    tvGroups.SelectedNode = childNode;
                    tvGroups.Focus();
                }
                AddChildNodes(Convert.ToInt32(row.code), childNode);
            }
        }


        private void FindAllChild(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Nodes.Count == 0)
                    childGroups.Add(node.Tag.ToString());
                else
                    FindAllChild(node);
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tvGroups.SelectedNode.Tag != null)
            {
                idGroup = (tvGroups.SelectedNode.Tag).ToString();
                childGroups.Add(tvGroups.SelectedNode.Tag.ToString());
                FindAllChild(tvGroups.SelectedNode);
            }
            else
            {
                idGroup = String.Empty; //не трогать
                childGroups = null;
            }
        }
    }
}
