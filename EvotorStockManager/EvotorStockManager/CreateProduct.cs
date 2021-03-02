using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvotorStockManager
{
    public partial class CreateProduct : Form
    {
        public EvotorProductV2 productEdit = null;

        public CreateProduct(EvotorProductV2 product)
        {
            InitializeComponent();
            this.productEdit = product;
            
            btnChooseGroup.Tag = "";
            if (product != null)
            {
                tbName.Text = product.name;
                tbDesc.Text = product.description;
                tbArticle.Text = product.article_number;
                tbCode.Text = product.code;
                nudPrice.Value = (decimal)product.price;
                nudCost.Value = (decimal)product.cost_price;
                nudCount.Value = (decimal)product.quantity;
                if (product.parent_id != null && product.parent_id != String.Empty)
                {
                    btnChooseGroup.Tag = product.parent_id;
                    btnChooseGroup.Text = Main.groups.Find(x => x.id == btnChooseGroup.Tag.ToString()).name;
                }
                if (product.barcodes != null)
                {
                    lbBarcodes.Items.AddRange(product.barcodes);
                }
                btnCreate.Text = "Сохранить изменения";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (productEdit != null)
            {
                productEdit = new EvotorProductV2(productEdit.id, tbName.Text, tbCode.Text, tbArticle.Text, tbDesc.Text, (float)nudPrice.Value, (float)nudCost.Value, (float)nudCount.Value, lbBarcodes.Items.OfType<string>().ToArray(), (btnChooseGroup.Tag==null)?null: btnChooseGroup.Tag.ToString());
                UpdateProductAsync(productEdit);           
                Main.products.Remove(Main.products.Find(x => x.id == productEdit.id));
                Main.products.Add(productEdit);
                
            }
            else
            {
                productEdit = new EvotorProductV2("", tbName.Text, tbCode.Text, tbArticle.Text, tbDesc.Text, (float)nudPrice.Value, (float)nudCost.Value, (float)nudCount.Value, lbBarcodes.Items.OfType<string>().ToArray(), (btnChooseGroup.Tag == null) ? null : btnChooseGroup.Tag.ToString());
                CreateProductAsync(productEdit);
            }
        }

        public async void CreateProductAsync(EvotorProductV2 prod)
        {
            string id = String.Empty;
            await Task.Run(() => id = EvotorAPI.CreateProduct(prod));
            prod.id = id;
            Main.products.Add(prod);
        }

        public async void UpdateProductAsync(EvotorProductV2 prod)
        {
            string id = prod.id;
            await Task.Run(() => EvotorAPI.UpdateProduct(prod));
        }

        private void btnAddBarcode_Click(object sender, EventArgs e)
        {
            if (tbBarcode.TextLength != 0)
                lbBarcodes.Items.Add(tbBarcode.Text.ToString());
            else
                MessageBox.Show("Заполните поле для добавления штрихкода");
        }

        private void btnDeleteBarcode_Click(object sender, EventArgs e)
        {
            if (lbBarcodes.SelectedItems.Count!=0)
                lbBarcodes.Items.Remove(lbBarcodes.SelectedItem);
        }

        private void btnChooseGroup_Click(object sender, EventArgs e)
        {
            string idGroup = btnChooseGroup.Tag.ToString();
            GroupPicker gp = new GroupPicker(idGroup);
            if (gp.ShowDialog() == DialogResult.OK)
            {
                btnChooseGroup.Tag = gp.idGroup;
                if (gp.idGroup != String.Empty)
                    btnChooseGroup.Text = Main.groups.Find(x => x.id == btnChooseGroup.Tag).name;
                else
                    btnChooseGroup.Text = "БЕЗ ГРУППЫ";
            }
        }

        private void CreateProduct_Load(object sender, EventArgs e)
        {
        }
    }
}
