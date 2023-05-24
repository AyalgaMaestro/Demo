
namespace pannda
{
    partial class Sklad2
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
            this.t1 = new System.Windows.Forms.DataGridView();
            this.t2 = new System.Windows.Forms.DataGridView();
            this.combo_search = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).BeginInit();
            this.SuspendLayout();
            // 
            // t1
            // 
            this.t1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.t1.Location = new System.Drawing.Point(12, 61);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(672, 231);
            this.t1.TabIndex = 0;
            this.t1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.t1_CellMouseClick);
            // 
            // t2
            // 
            this.t2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.t2.Location = new System.Drawing.Point(690, 36);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(228, 261);
            this.t2.TabIndex = 1;
            // 
            // combo_search
            // 
            this.combo_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_search.FormattingEnabled = true;
            this.combo_search.Items.AddRange(new object[] {
            "артикулу",
            "производителю ",
            "наименованию"});
            this.combo_search.Location = new System.Drawing.Point(85, 36);
            this.combo_search.Name = "combo_search";
            this.combo_search.Size = new System.Drawing.Size(135, 21);
            this.combo_search.TabIndex = 2;
            this.combo_search.SelectedIndexChanged += new System.EventHandler(this.combo_search_SelectedIndexChanged);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(226, 36);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(146, 20);
            this.txt_search.TabIndex = 3;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поиск по:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить товар в систему";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Посмотреть шаблон характеристик";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Sklad2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 323);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.combo_search);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Name = "Sklad2";
            this.Text = "Главное меню";
            ((System.ComponentModel.ISupportInitialize)(this.t1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView t1;
        private System.Windows.Forms.DataGridView t2;
        private System.Windows.Forms.ComboBox combo_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}