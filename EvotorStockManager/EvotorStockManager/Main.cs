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
        static public List<EvotorProductV2> groups = new List<EvotorProductV2>();
        static public List<string> groupSort;

        public Main()
        {
            InitializeComponent();
            UpdateDataAsync(true);
            btnSearchGroup.Tag = String.Empty;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false;
            
            //получение данных облака          
            UpdateDataAsync();
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

        private List<EvotorProductV2> GetGroups()
        {
            string cursor = String.Empty;
            List<EvotorProductV2> arr = new List<EvotorProductV2>();
            do
            {
                RootItemsJSON response = EvotorAPI.GetGroups(cursor);
                arr.AddRange(response.items);
                cursor = response.paging.next_cursor;
            } while (cursor != null);

            return arr;
        }

        public async void UpdateDataAsync(bool isFirst = false)
        {
            pbLoading.Visible = true;
            pnlNavigation.Visible = false;
            await Task.Run(() => products = GetProducts());
            await Task.Run(() => groups = GetGroups());
            if (isFirst)
            {
                ((DataGridViewComboBoxColumn)dgvMain.Columns["parent_id"]).DataPropertyName = "parent_id";
                ((DataGridViewComboBoxColumn)dgvMain.Columns["parent_id"]).DisplayMember = "name";
                ((DataGridViewComboBoxColumn)dgvMain.Columns["parent_id"]).ValueMember = "id";
            }
            ((DataGridViewComboBoxColumn)dgvMain.Columns["parent_id"]).DataSource = groups;

            dgvMain.DataSource = products;
            pbLoading.Visible = false;
            pnlNavigation.Visible = true;
            tslProductCount.Text = "Загружено товаров: " + products.Count + "; Групп: " + groups.Count;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
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
            CreateProduct f = new CreateProduct(null);
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dgvMain.Rows[dgvMain.SelectedRows[0].Index].Cells["id"].Value.ToString();
            EvotorProductV2 editProduct = products.Where(x => x.id == id).First();
            CreateProduct f = new CreateProduct(editProduct);
            if (f.ShowDialog() == DialogResult.OK)
            {
                UpdateSearch(tbSearch.Text);
            }
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            string idGroup = Convert.ToString(dgvMain.SelectedRows[0].Cells["parent_id"].Value);
            GroupPicker gp = new GroupPicker(idGroup);
            if (gp.ShowDialog() == DialogResult.OK)
            {
                ((EvotorProductV2)dgvMain.SelectedRows[0].DataBoundItem).parent_id = gp.idGroup;
                EvotorAPI.UpdateProduct(((EvotorProductV2)dgvMain.SelectedRows[0].DataBoundItem));
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите удалить - " + dgvMain.SelectedRows[0].Cells["name"].Value.ToString() + "?", "Подтвержение", MessageBoxButtons.YesNo))
                {
                    EvotorAPI.DeleteProduct(dgvMain.SelectedRows[0].Cells["id"].Value.ToString());
                    EvotorProductV2 delProduct = (EvotorProductV2)dgvMain.SelectedRows[0].DataBoundItem;
                    products.Remove(delProduct);
                    dgvMain.DataSource = products;
                }
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateDataAsync();
        }

        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (tbSearch.TextLength > 2 || tbSearch.TextLength == 0)
            {
                UpdateSearch(tbSearch.Text);
            }
        }

        public void UpdateSearch(string text_search)
        {
            BindingList<EvotorProductV2> filtered;
            if (groupSort!=null)
                filtered = new BindingList<EvotorProductV2>(products.Where(
                                     p => ((p.name.IndexOf(text_search, StringComparison.OrdinalIgnoreCase) >= 0) || (p.description.IndexOf(text_search, StringComparison.OrdinalIgnoreCase) >= 0))
                                    && groupSort.Contains(p.parent_id)).OrderBy(p=>p.name).ToList());
            else
                filtered = new BindingList<EvotorProductV2>(products.Where(
                                    p => (p.name.IndexOf(text_search, StringComparison.OrdinalIgnoreCase) >= 0) || (p.description.IndexOf(text_search, StringComparison.OrdinalIgnoreCase) >= 0)).OrderBy(p => p.name).ToList());
            dgvMain.DataSource = filtered;
        }

        private void tbSearchBarcode_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchBarcode.TextLength > 2 || tbSearchBarcode.TextLength == 0)
            {
                BindingList<EvotorProductV2> filtered = new BindingList<EvotorProductV2>(products.Where(
                                      p => ((p.barcodes != null && p.barcodes.Contains(tbSearchBarcode.Text)) && (p.parent_id.Equals(groupSort)||groupSort==null))).OrderBy(p => p.name).ToList());
                dgvMain.DataSource = filtered;
            }
        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            string idGroup = btnSearchGroup.Tag.ToString();
            GroupPicker gp = new GroupPicker(idGroup);
            if (gp.ShowDialog() == DialogResult.OK)
            {
                if (gp.idGroup != String.Empty)
                {
                    btnSearchGroup.Text = groups.Where(x =>(x.id == gp.idGroup)).First().name;
                    btnSearchGroup.Tag = gp.idGroup;
                    groupSort = gp.childGroups;
                }
                else
                {
                    btnSearchGroup.Text = "ВСЕ ТОВАРЫ";
                    btnSearchGroup.Tag = String.Empty;
                    groupSort = null;
                }
                UpdateSearch(tbSearch.Text);
            }
        }

        private void dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }
    }
}
