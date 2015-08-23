namespace Recepcia
{
    partial class Kalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kalendar));
            this.kalendar_grid = new System.Windows.Forms.DataGridView();
            this.btn_novaRezervacia = new System.Windows.Forms.Button();
            this.btn_pridajHosta = new System.Windows.Forms.Button();
            this.filter_tb = new System.Windows.Forms.TextBox();
            this.btn_zmazRezervaciu = new System.Windows.Forms.Button();
            this.lb_guestList = new System.Windows.Forms.ListBox();
            this.lbl_filter = new System.Windows.Forms.Label();
            this.btn_upravHosta = new System.Windows.Forms.Button();
            this.lbl_prihlasenyPouzivatel = new System.Windows.Forms.Label();
            this.btn_odhlasit = new System.Windows.Forms.Button();
            this.cb_farby = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kalendar_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // kalendar_grid
            // 
            this.kalendar_grid.AllowUserToAddRows = false;
            this.kalendar_grid.AllowUserToDeleteRows = false;
            this.kalendar_grid.AllowUserToOrderColumns = true;
            this.kalendar_grid.AllowUserToResizeRows = false;
            this.kalendar_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.kalendar_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kalendar_grid.Location = new System.Drawing.Point(12, 53);
            this.kalendar_grid.Name = "kalendar_grid";
            this.kalendar_grid.ReadOnly = true;
            this.kalendar_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.kalendar_grid.RowTemplate.Height = 24;
            this.kalendar_grid.ShowCellErrors = false;
            this.kalendar_grid.ShowCellToolTips = false;
            this.kalendar_grid.ShowEditingIcon = false;
            this.kalendar_grid.ShowRowErrors = false;
            this.kalendar_grid.Size = new System.Drawing.Size(1029, 378);
            this.kalendar_grid.TabIndex = 0;
            // 
            // btn_novaRezervacia
            // 
            this.btn_novaRezervacia.BackColor = System.Drawing.Color.Lime;
            this.btn_novaRezervacia.Location = new System.Drawing.Point(729, 492);
            this.btn_novaRezervacia.Name = "btn_novaRezervacia";
            this.btn_novaRezervacia.Size = new System.Drawing.Size(217, 38);
            this.btn_novaRezervacia.TabIndex = 1;
            this.btn_novaRezervacia.Text = "Pridaj novú rezerváciu";
            this.btn_novaRezervacia.UseVisualStyleBackColor = false;
            this.btn_novaRezervacia.Click += new System.EventHandler(this.btn_novaRezervacia_Click);
            // 
            // btn_pridajHosta
            // 
            this.btn_pridajHosta.Location = new System.Drawing.Point(12, 448);
            this.btn_pridajHosta.Name = "btn_pridajHosta";
            this.btn_pridajHosta.Size = new System.Drawing.Size(106, 38);
            this.btn_pridajHosta.TabIndex = 2;
            this.btn_pridajHosta.Text = "Pridaj hosťa";
            this.btn_pridajHosta.UseVisualStyleBackColor = true;
            this.btn_pridajHosta.Click += new System.EventHandler(this.btn_pridajHosta_Click);
            // 
            // filter_tb
            // 
            this.filter_tb.Location = new System.Drawing.Point(212, 459);
            this.filter_tb.Name = "filter_tb";
            this.filter_tb.Size = new System.Drawing.Size(137, 22);
            this.filter_tb.TabIndex = 4;
            this.filter_tb.TextChanged += new System.EventHandler(this.filter_tb_TextChanged);
            // 
            // btn_zmazRezervaciu
            // 
            this.btn_zmazRezervaciu.BackColor = System.Drawing.Color.Red;
            this.btn_zmazRezervaciu.Location = new System.Drawing.Point(729, 550);
            this.btn_zmazRezervaciu.Name = "btn_zmazRezervaciu";
            this.btn_zmazRezervaciu.Size = new System.Drawing.Size(217, 37);
            this.btn_zmazRezervaciu.TabIndex = 5;
            this.btn_zmazRezervaciu.Text = "Zmaž označenú rezerváciu";
            this.btn_zmazRezervaciu.UseVisualStyleBackColor = false;
            this.btn_zmazRezervaciu.Click += new System.EventHandler(this.btn_zmazRezervaciu_Click);
            // 
            // lb_guestList
            // 
            this.lb_guestList.FormattingEnabled = true;
            this.lb_guestList.ItemHeight = 16;
            this.lb_guestList.Location = new System.Drawing.Point(366, 448);
            this.lb_guestList.Name = "lb_guestList";
            this.lb_guestList.Size = new System.Drawing.Size(248, 180);
            this.lb_guestList.TabIndex = 6;
            // 
            // lbl_filter
            // 
            this.lbl_filter.AutoSize = true;
            this.lbl_filter.Location = new System.Drawing.Point(150, 459);
            this.lbl_filter.Name = "lbl_filter";
            this.lbl_filter.Size = new System.Drawing.Size(43, 17);
            this.lbl_filter.TabIndex = 7;
            this.lbl_filter.Text = "Filter:";
            // 
            // btn_upravHosta
            // 
            this.btn_upravHosta.Location = new System.Drawing.Point(12, 505);
            this.btn_upravHosta.Name = "btn_upravHosta";
            this.btn_upravHosta.Size = new System.Drawing.Size(106, 38);
            this.btn_upravHosta.TabIndex = 8;
            this.btn_upravHosta.Text = "Uprav hosťa";
            this.btn_upravHosta.UseVisualStyleBackColor = true;
            this.btn_upravHosta.Click += new System.EventHandler(this.btn_upravHosta_Click);
            // 
            // lbl_prihlasenyPouzivatel
            // 
            this.lbl_prihlasenyPouzivatel.AutoSize = true;
            this.lbl_prihlasenyPouzivatel.Location = new System.Drawing.Point(537, 20);
            this.lbl_prihlasenyPouzivatel.Name = "lbl_prihlasenyPouzivatel";
            this.lbl_prihlasenyPouzivatel.Size = new System.Drawing.Size(151, 17);
            this.lbl_prihlasenyPouzivatel.TabIndex = 9;
            this.lbl_prihlasenyPouzivatel.Text = "Prihlásený používateľ: ";
            this.lbl_prihlasenyPouzivatel.UseMnemonic = false;
            // 
            // btn_odhlasit
            // 
            this.btn_odhlasit.Location = new System.Drawing.Point(935, 9);
            this.btn_odhlasit.Name = "btn_odhlasit";
            this.btn_odhlasit.Size = new System.Drawing.Size(106, 38);
            this.btn_odhlasit.TabIndex = 10;
            this.btn_odhlasit.Text = "Odhlásiť";
            this.btn_odhlasit.UseVisualStyleBackColor = true;
            this.btn_odhlasit.Click += new System.EventHandler(this.btn_odhlasit_Click);
            // 
            // cb_farby
            // 
            this.cb_farby.FormattingEnabled = true;
            this.cb_farby.Items.AddRange(new object[] {
            "lightblue",
            "lightcoral",
            "lightcyan",
            "lightgray",
            "lightgreen",
            "lightpink",
            "lightsalmon",
            "lightseagreen",
            "lightskyblue",
            "lightslategray",
            "lightsteelblue",
            "lightyellow"});
            this.cb_farby.Location = new System.Drawing.Point(783, 17);
            this.cb_farby.Name = "cb_farby";
            this.cb_farby.Size = new System.Drawing.Size(131, 24);
            this.cb_farby.TabIndex = 11;
            this.cb_farby.SelectedValueChanged += new System.EventHandler(this.cb_farby_SelectedValueChanged);
            // 
            // Kalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 637);
            this.Controls.Add(this.cb_farby);
            this.Controls.Add(this.btn_odhlasit);
            this.Controls.Add(this.lbl_prihlasenyPouzivatel);
            this.Controls.Add(this.btn_upravHosta);
            this.Controls.Add(this.lbl_filter);
            this.Controls.Add(this.lb_guestList);
            this.Controls.Add(this.btn_zmazRezervaciu);
            this.Controls.Add(this.filter_tb);
            this.Controls.Add(this.btn_pridajHosta);
            this.Controls.Add(this.btn_novaRezervacia);
            this.Controls.Add(this.kalendar_grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Kalendar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kalendar";
            ((System.ComponentModel.ISupportInitialize)(this.kalendar_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kalendar_grid;
        private System.Windows.Forms.Button btn_novaRezervacia;
        private System.Windows.Forms.Button btn_pridajHosta;
        private System.Windows.Forms.TextBox filter_tb;
        private System.Windows.Forms.Button btn_zmazRezervaciu;
        private System.Windows.Forms.ListBox lb_guestList;
        private System.Windows.Forms.Label lbl_filter;
        private System.Windows.Forms.Button btn_upravHosta;
        private System.Windows.Forms.Label lbl_prihlasenyPouzivatel;
        private System.Windows.Forms.Button btn_odhlasit;
        private System.Windows.Forms.ComboBox cb_farby;
    }
}