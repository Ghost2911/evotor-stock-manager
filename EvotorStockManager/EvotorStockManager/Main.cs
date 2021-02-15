using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvotorStockManager
{
    public partial class Main : Form
    {
        static public List<EvotorProductV2> products = new List<EvotorProductV2>();
        List<EvotorProductV2> groups = new List<EvotorProductV2>();

        public Main()
        {
            InitializeComponent();
            GetProductsAsync();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false;
            GetProductsAsync();
        }

        private List<EvotorProductV2> GetProducts()
        {
            string cursor = String.Empty; 
            List<EvotorProductV2> arr = new List<EvotorProductV2>();
            do
            {
                RootItemsJSON response = EvotorAPI.GetProducts(cursor);
                arr.AddRange(response.items);
                cursor = response.paging.next_cursor;
            } while (cursor != null);

            return arr;
        }

        public async void GetProductsAsync()
        {
            pbLoading.Visible = true;
            await Task.Run(() => products = GetProducts());
            dgvMain.DataSource = products;
            pbLoading.Visible = false;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.TextLength > 2 || tbSearch.TextLength == 0)
            {
                BindingList<EvotorProductV2> filtered = new BindingList<EvotorProductV2>(products.Where(
                                      p => (p.name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                      (p.article_number.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)).ToList());
                dgvMain.DataSource = filtered;
            }
        }


        private void btnAddApi_Click(object sender, EventArgs e)
        {
            EvotorAPI.Add(DAL.GetTable("COMMODITY"));
        }

        private void btnRecreate_Click(object sender, EventArgs e)
        {
            try
            {
                string[] bufGroup = { "", "", "", "", "" };
                string lastCat = null;
                int num;

                MessageBox.Show(DAL.ExecuteDML("DELETE FROM [COMMODITY]").ToString());
                string[] str = File.ReadAllLines("DB_EXCEL.txt", Encoding.GetEncoding("windows-1251"));
                progressBar.Maximum = str.Length;
                //чтение исходника с SD карты
                for (int i = 2; i < str.Length; i++)
                {
                    progressBar.Value = i;
                    String[] mas = str[i].Split('\t');

                    if (int.TryParse(mas[0], out num))
                    {
                        //разграничение по уровням категорий
                        int nowGr = Convert.ToInt32(mas[0]);

                        string uuid = Guid.NewGuid().ToString();
                        bufGroup[nowGr] = uuid;
                        lastCat = uuid;

                        DAL.ExecuteDML(String.Format("INSERT INTO [COMMODITY]([UUID], [NAME], [NAME_UPPER_CASE], [CODE],[CODE_UPPER_CASE],[IS_GROUP],[PARENT_UUID],[SELL_FORBIDDEN],[TYPE]) " +
                            "VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}'); ", uuid, mas[2], mas[2].ToUpper(), mas[1], mas[1], 1, (bufGroup[nowGr - 1] == null) ? "NULL" : "'" + bufGroup[nowGr - 1] + "'", 1, "NORMAL"));

                    }
                    else
                    {
                        string uuid = Guid.NewGuid().ToString();

                        DAL.ExecuteDML(String.Format("INSERT INTO [COMMODITY]([UUID], [NAME], [NAME_UPPER_CASE], [CODE],[CODE_UPPER_CASE],[IS_GROUP],[PARENT_UUID],[SELL_FORBIDDEN],[TYPE],[ARTICLE_NUMBER],[ARTICLE_NUMBER_UPPER_CASE],[DESCRIPTION],[PRICE_OUT],[COST_PRICE],[QUANTITY],[CLASSIFICATION_CODE]) " +
                                "VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}',{7},'{8}','{9}','{10}','{11}','{12}',{13},{14},'{15}'); ", uuid, mas[2], mas[2].ToUpper(), mas[1], mas[1], 0, lastCat, 1, "NORMAL", mas[10], mas[10].ToUpper(), mas[11], mas[4], mas[5], Convert.ToInt32(mas[3]),mas[12]));
                    }
                }
                progressBar.Value = progressBar.Maximum;
            }
            catch(Exception ex) {
                
            }
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvMain.Rows[e.RowIndex].Cells["id"].Value.ToString();
            EvotorProductV2 editProduct = products.Where(x => x.id == id).First();
            EvotorAPI.UpdateProduct(editProduct);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateProduct f = new CreateProduct(true);
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EvotorAPI.GetGroups(String.Empty).ToString());

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count != 0)
            {
                EvotorAPI.DeleteProduct(dgvMain.SelectedRows[0].Cells["id"].Value.ToString());
                EvotorProductV2 delProduct = (EvotorProductV2)dgvMain.Rows[0].DataBoundItem;
                products.Remove(delProduct);
                dgvMain.DataSource = products;
            }
        }
    }
}
