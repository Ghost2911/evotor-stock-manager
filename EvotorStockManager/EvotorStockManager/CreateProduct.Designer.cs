
namespace EvotorStockManager
{
    partial class CreateProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProduct));
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.tbArticle = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lbBarcodes = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.btnAddBarcode = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteBarcode = new System.Windows.Forms.Button();
            this.btnChooseGroup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCost
            // 
            this.nudCost.DecimalPlaces = 2;
            this.nudCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCost.Location = new System.Drawing.Point(589, 27);
            this.nudCost.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(200, 26);
            this.nudCost.TabIndex = 5;
            this.nudCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCost.ThousandsSeparator = true;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPrice.Location = new System.Drawing.Point(589, 68);
            this.nudPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(200, 26);
            this.nudPrice.TabIndex = 6;
            this.nudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrice.ThousandsSeparator = true;
            // 
            // nudCount
            // 
            this.nudCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCount.Location = new System.Drawing.Point(132, 323);
            this.nudCount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nudCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(272, 26);
            this.nudCount.TabIndex = 4;
            this.nudCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbArticle
            // 
            this.tbArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbArticle.Location = new System.Drawing.Point(132, 246);
            this.tbArticle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbArticle.Name = "tbArticle";
            this.tbArticle.Size = new System.Drawing.Size(273, 26);
            this.tbArticle.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(132, 25);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(273, 92);
            this.tbName.TabIndex = 0;
            // 
            // tbDesc
            // 
            this.tbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDesc.Location = new System.Drawing.Point(132, 123);
            this.tbDesc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(273, 116);
            this.tbDesc.TabIndex = 1;
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCode.Location = new System.Drawing.Point(132, 278);
            this.tbCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(273, 26);
            this.tbCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Артикул";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 278);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Код";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(410, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Цена закупки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(410, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Цена продажи";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 326);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Количество";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(12, 366);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(776, 58);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "СОЗДАТЬ ТОВАР";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lbBarcodes
            // 
            this.lbBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBarcodes.FormattingEnabled = true;
            this.lbBarcodes.ItemHeight = 20;
            this.lbBarcodes.Location = new System.Drawing.Point(414, 246);
            this.lbBarcodes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbBarcodes.Name = "lbBarcodes";
            this.lbBarcodes.Size = new System.Drawing.Size(375, 104);
            this.lbBarcodes.TabIndex = 15;
            this.lbBarcodes.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(410, 163);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Штрих-коды";
            // 
            // tbBarcode
            // 
            this.tbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBarcode.Location = new System.Drawing.Point(414, 188);
            this.tbBarcode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(278, 26);
            this.tbBarcode.TabIndex = 8;
            // 
            // btnAddBarcode
            // 
            this.btnAddBarcode.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddBarcode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddBarcode.Location = new System.Drawing.Point(698, 188);
            this.btnAddBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddBarcode.Name = "btnAddBarcode";
            this.btnAddBarcode.Size = new System.Drawing.Size(91, 26);
            this.btnAddBarcode.TabIndex = 19;
            this.btnAddBarcode.TabStop = false;
            this.btnAddBarcode.Text = "добавить";
            this.btnAddBarcode.UseVisualStyleBackColor = false;
            this.btnAddBarcode.Click += new System.EventHandler(this.btnAddBarcode_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(410, 220);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Все штрих-коды товара";
            // 
            // btnDeleteBarcode
            // 
            this.btnDeleteBarcode.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBarcode.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteBarcode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteBarcode.Location = new System.Drawing.Point(758, 216);
            this.btnDeleteBarcode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteBarcode.Name = "btnDeleteBarcode";
            this.btnDeleteBarcode.Size = new System.Drawing.Size(31, 33);
            this.btnDeleteBarcode.TabIndex = 23;
            this.btnDeleteBarcode.TabStop = false;
            this.btnDeleteBarcode.Text = "x";
            this.btnDeleteBarcode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnDeleteBarcode.UseVisualStyleBackColor = false;
            this.btnDeleteBarcode.Click += new System.EventHandler(this.btnDeleteBarcode_Click);
            // 
            // btnChooseGroup
            // 
            this.btnChooseGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChooseGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseGroup.Location = new System.Drawing.Point(482, 118);
            this.btnChooseGroup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnChooseGroup.Name = "btnChooseGroup";
            this.btnChooseGroup.Size = new System.Drawing.Size(307, 27);
            this.btnChooseGroup.TabIndex = 7;
            this.btnChooseGroup.Tag = "";
            this.btnChooseGroup.Text = "БЕЗ ГРУППЫ";
            this.btnChooseGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseGroup.UseVisualStyleBackColor = false;
            this.btnChooseGroup.Click += new System.EventHandler(this.btnChooseGroup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(410, 120);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Группа:";
            // 
            // CreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(798, 423);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnChooseGroup);
            this.Controls.Add(this.btnDeleteBarcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAddBarcode);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbBarcodes);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbArticle);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProduct";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка товара";
            this.Load += new System.EventHandler(this.CreateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.TextBox tbArticle;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ListBox lbBarcodes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Button btnAddBarcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeleteBarcode;
        private System.Windows.Forms.Button btnChooseGroup;
        private System.Windows.Forms.Label label10;
    }
}