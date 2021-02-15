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
        public bool isCreate;

        public CreateProduct(bool isCreate)
        {
            InitializeComponent();
            this.isCreate = isCreate;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EvotorProductV2 product = new EvotorProductV2(tbName.Text, tbCode.Text, tbArticle.Text, tbDesc.Text, (float)nudPrice.Value, (float)nudCost.Value, (float)nudCount.Value);
            if (isCreate)
                CreateProductAsync(product);
            else
                CreateProductAsync(product);
        }

        public async void CreateProductAsync(EvotorProductV2 prod)
        {
            string id = String.Empty;
            await Task.Run(() => id = EvotorAPI.CreateProduct(prod));
            prod.id = id;
            Main.products.Add(prod);
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
    }
}
