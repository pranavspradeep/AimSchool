namespace SchoolManagement
{
    partial class frmstock
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.cmdLoadItems = new System.Windows.Forms.Button();
            this.cmdSaveItem = new System.Windows.Forms.Button();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.txtPurchaseAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNewSupplier = new System.Windows.Forms.Button();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdUpdateStock = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtNewStock = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtFilterManufacturer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFilterCategory = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dgvPurchasedItem = new System.Windows.Forms.DataGridView();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.cmdDeletePurchasedItem = new System.Windows.Forms.Button();
            this.gbPurchase = new System.Windows.Forms.GroupBox();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.cmdClosePurchase = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasedItem)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.gbPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmdClear);
            this.groupBox7.Controls.Add(this.dtpPurchaseDate);
            this.groupBox7.Controls.Add(this.cmdLoadItems);
            this.groupBox7.Controls.Add(this.cmdSaveItem);
            this.groupBox7.Controls.Add(this.txtVehicleNo);
            this.groupBox7.Controls.Add(this.txtPurchaseAmount);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtInvoiceNo);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.cmdNewSupplier);
            this.groupBox7.Controls.Add(this.txtAddr);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtSupplier);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Location = new System.Drawing.Point(3, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(457, 146);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(198, 116);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(72, 23);
            this.cmdClear.TabIndex = 8;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(373, 63);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(76, 20);
            this.dtpPurchaseDate.TabIndex = 5;
            // 
            // cmdLoadItems
            // 
            this.cmdLoadItems.Location = new System.Drawing.Point(359, 116);
            this.cmdLoadItems.Name = "cmdLoadItems";
            this.cmdLoadItems.Size = new System.Drawing.Size(77, 23);
            this.cmdLoadItems.TabIndex = 7;
            this.cmdLoadItems.Text = "Load Items";
            this.cmdLoadItems.UseVisualStyleBackColor = true;
            this.cmdLoadItems.Click += new System.EventHandler(this.cmdLoadItems_Click);
            // 
            // cmdSaveItem
            // 
            this.cmdSaveItem.Location = new System.Drawing.Point(276, 116);
            this.cmdSaveItem.Name = "cmdSaveItem";
            this.cmdSaveItem.Size = new System.Drawing.Size(77, 23);
            this.cmdSaveItem.TabIndex = 7;
            this.cmdSaveItem.Text = "Save";
            this.cmdSaveItem.UseVisualStyleBackColor = true;
            this.cmdSaveItem.Click += new System.EventHandler(this.cmdSaveItem_Click);
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Location = new System.Drawing.Point(373, 90);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(77, 20);
            this.txtVehicleNo.TabIndex = 6;
            // 
            // txtPurchaseAmount
            // 
            this.txtPurchaseAmount.Location = new System.Drawing.Point(373, 38);
            this.txtPurchaseAmount.Name = "txtPurchaseAmount";
            this.txtPurchaseAmount.Size = new System.Drawing.Size(77, 20);
            this.txtPurchaseAmount.TabIndex = 4;
            this.txtPurchaseAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vehicle No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Purchase Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Purchase Date";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(355, 12);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(95, 20);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Invoice No";
            // 
            // cmdNewSupplier
            // 
            this.cmdNewSupplier.Location = new System.Drawing.Point(250, 15);
            this.cmdNewSupplier.Name = "cmdNewSupplier";
            this.cmdNewSupplier.Size = new System.Drawing.Size(22, 22);
            this.cmdNewSupplier.TabIndex = 1;
            this.cmdNewSupplier.Text = "+";
            this.cmdNewSupplier.UseVisualStyleBackColor = true;
            this.cmdNewSupplier.Click += new System.EventHandler(this.cmdNewSupplier_Click);
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(92, 43);
            this.txtAddr.Multiline = true;
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(152, 67);
            this.txtAddr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            // 
            // txtSupplier
            // 
            this.txtSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSupplier.Location = new System.Drawing.Point(92, 17);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(152, 20);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            this.txtSupplier.Leave += new System.EventHandler(this.txtSupplier_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier Name";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.groupBox6);
            this.groupBox11.Controls.Add(this.groupBox2);
            this.groupBox11.Controls.Add(this.groupBox1);
            this.groupBox11.Location = new System.Drawing.Point(3, 164);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(587, 206);
            this.groupBox11.TabIndex = 2;
            this.groupBox11.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmdUpdateStock);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Location = new System.Drawing.Point(473, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(106, 174);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Update Stock";
            // 
            // cmdUpdateStock
            // 
            this.cmdUpdateStock.Location = new System.Drawing.Point(16, 145);
            this.cmdUpdateStock.Name = "cmdUpdateStock";
            this.cmdUpdateStock.Size = new System.Drawing.Size(69, 23);
            this.cmdUpdateStock.TabIndex = 2;
            this.cmdUpdateStock.Text = "Update";
            this.cmdUpdateStock.UseVisualStyleBackColor = true;
            this.cmdUpdateStock.Click += new System.EventHandler(this.cmdUpdateStock_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtNewStock);
            this.groupBox9.Location = new System.Drawing.Point(10, 73);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(87, 66);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Update Stock With";
            // 
            // txtNewStock
            // 
            this.txtNewStock.Location = new System.Drawing.Point(6, 32);
            this.txtNewStock.Name = "txtNewStock";
            this.txtNewStock.Size = new System.Drawing.Size(75, 20);
            this.txtNewStock.TabIndex = 0;
            this.txtNewStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewStock_KeyPress);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtCurrentStock);
            this.groupBox8.Location = new System.Drawing.Point(10, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(87, 48);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Current Stock";
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Location = new System.Drawing.Point(6, 19);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(75, 20);
            this.txtCurrentStock.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(0, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 65);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Filter";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtFilterManufacturer);
            this.groupBox5.Location = new System.Drawing.Point(308, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(144, 43);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Manufacturer";
            // 
            // txtFilterManufacturer
            // 
            this.txtFilterManufacturer.Location = new System.Drawing.Point(5, 15);
            this.txtFilterManufacturer.Name = "txtFilterManufacturer";
            this.txtFilterManufacturer.Size = new System.Drawing.Size(133, 20);
            this.txtFilterManufacturer.TabIndex = 0;
            this.txtFilterManufacturer.TextChanged += new System.EventHandler(this.txtFilterManufacturer_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFilterCategory);
            this.groupBox4.Location = new System.Drawing.Point(158, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 43);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Category";
            // 
            // txtFilterCategory
            // 
            this.txtFilterCategory.Location = new System.Drawing.Point(5, 15);
            this.txtFilterCategory.Name = "txtFilterCategory";
            this.txtFilterCategory.Size = new System.Drawing.Size(133, 20);
            this.txtFilterCategory.TabIndex = 0;
            this.txtFilterCategory.TextChanged += new System.EventHandler(this.txtFilterCategory_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilterName);
            this.groupBox3.Location = new System.Drawing.Point(8, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 43);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name";
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(5, 15);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(133, 20);
            this.txtFilterName.TabIndex = 0;
            this.txtFilterName.TextChanged += new System.EventHandler(this.txtFilterName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvItemList);
            this.groupBox1.Location = new System.Drawing.Point(0, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item List";
            // 
            // dgvItemList
            // 
            this.dgvItemList.AllowUserToAddRows = false;
            this.dgvItemList.AllowUserToDeleteRows = false;
            this.dgvItemList.AllowUserToResizeColumns = false;
            this.dgvItemList.AllowUserToResizeRows = false;
            this.dgvItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItemList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemList.Location = new System.Drawing.Point(3, 16);
            this.dgvItemList.MultiSelect = false;
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.ReadOnly = true;
            this.dgvItemList.RowHeadersVisible = false;
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(451, 105);
            this.dgvItemList.TabIndex = 0;
            this.dgvItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemList_CellClick);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dgvPurchasedItem);
            this.groupBox12.Location = new System.Drawing.Point(3, 370);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(457, 126);
            this.groupBox12.TabIndex = 5;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Purchased Items";
            // 
            // dgvPurchasedItem
            // 
            this.dgvPurchasedItem.AllowUserToAddRows = false;
            this.dgvPurchasedItem.AllowUserToDeleteRows = false;
            this.dgvPurchasedItem.AllowUserToResizeColumns = false;
            this.dgvPurchasedItem.AllowUserToResizeRows = false;
            this.dgvPurchasedItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPurchasedItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPurchasedItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchasedItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchasedItem.Location = new System.Drawing.Point(3, 16);
            this.dgvPurchasedItem.MultiSelect = false;
            this.dgvPurchasedItem.Name = "dgvPurchasedItem";
            this.dgvPurchasedItem.ReadOnly = true;
            this.dgvPurchasedItem.RowHeadersVisible = false;
            this.dgvPurchasedItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchasedItem.Size = new System.Drawing.Size(451, 107);
            this.dgvPurchasedItem.TabIndex = 0;
            this.dgvPurchasedItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchasedItem_CellClick);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cmdLoad);
            this.groupBox10.Controls.Add(this.cmdExit);
            this.groupBox10.Controls.Add(this.cmdNew);
            this.groupBox10.Location = new System.Drawing.Point(466, 12);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(124, 110);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(7, 48);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(109, 23);
            this.cmdLoad.TabIndex = 1;
            this.cmdLoad.Text = "Load Invoice";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(7, 77);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(109, 23);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(7, 19);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(109, 23);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "New Entry";
            this.cmdNew.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.cmdDeletePurchasedItem);
            this.groupBox13.Location = new System.Drawing.Point(473, 386);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(117, 43);
            this.groupBox13.TabIndex = 7;
            this.groupBox13.TabStop = false;
            // 
            // cmdDeletePurchasedItem
            // 
            this.cmdDeletePurchasedItem.Location = new System.Drawing.Point(7, 13);
            this.cmdDeletePurchasedItem.Name = "cmdDeletePurchasedItem";
            this.cmdDeletePurchasedItem.Size = new System.Drawing.Size(102, 23);
            this.cmdDeletePurchasedItem.TabIndex = 0;
            this.cmdDeletePurchasedItem.Text = "Delete Item";
            this.cmdDeletePurchasedItem.UseVisualStyleBackColor = true;
            this.cmdDeletePurchasedItem.Click += new System.EventHandler(this.cmdDeletePurchasedItem_Click);
            // 
            // gbPurchase
            // 
            this.gbPurchase.Controls.Add(this.dgvPurchase);
            this.gbPurchase.Location = new System.Drawing.Point(596, 32);
            this.gbPurchase.Name = "gbPurchase";
            this.gbPurchase.Size = new System.Drawing.Size(469, 341);
            this.gbPurchase.TabIndex = 8;
            this.gbPurchase.TabStop = false;
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeColumns = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPurchase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchase.Location = new System.Drawing.Point(3, 16);
            this.dgvPurchase.MultiSelect = false;
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            this.dgvPurchase.RowHeadersVisible = false;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(463, 322);
            this.dgvPurchase.TabIndex = 0;
            this.dgvPurchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellClick);
            // 
            // cmdClosePurchase
            // 
            this.cmdClosePurchase.FlatAppearance.BorderSize = 0;
            this.cmdClosePurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClosePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClosePurchase.Location = new System.Drawing.Point(1026, 11);
            this.cmdClosePurchase.Name = "cmdClosePurchase";
            this.cmdClosePurchase.Size = new System.Drawing.Size(20, 26);
            this.cmdClosePurchase.TabIndex = 7;
            this.cmdClosePurchase.Text = "X";
            this.cmdClosePurchase.UseVisualStyleBackColor = true;
            this.cmdClosePurchase.Click += new System.EventHandler(this.cmdClosePurchase_Click);
            // 
            // frmstock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 501);
            this.Controls.Add(this.cmdClosePurchase);
            this.Controls.Add(this.gbPurchase);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox7);
            this.Name = "frmstock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmstock";
            this.Load += new System.EventHandler(this.frmstock_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasedItem)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.gbPurchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Button cmdLoadItems;
        private System.Windows.Forms.Button cmdSaveItem;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.TextBox txtPurchaseAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdNewSupplier;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button cmdUpdateStock;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtNewStock;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtFilterManufacturer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFilterCategory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dgvPurchasedItem;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button cmdDeletePurchasedItem;
        private System.Windows.Forms.GroupBox gbPurchase;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Button cmdClosePurchase;
    }
}