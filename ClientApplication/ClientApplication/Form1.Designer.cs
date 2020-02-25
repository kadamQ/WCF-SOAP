namespace ClientApplication
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.labelISBN = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxPublicationDate = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelInstock = new System.Windows.Forms.Label();
            this.textBoxInstock = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDiscountAll = new System.Windows.Forms.Button();
            this.buttonDiscountByAuthor = new System.Windows.Forms.Button();
            this.buttonDiscountOne = new System.Windows.Forms.Button();
            this.buttonListByISBN = new System.Windows.Forms.Button();
            this.labelPricePercentage = new System.Windows.Forms.Label();
            this.textBoxPricePercentage = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBooks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 3);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowTemplate.Height = 28;
            this.dataGridViewBooks.Size = new System.Drawing.Size(1016, 270);
            this.dataGridViewBooks.TabIndex = 0;
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelISBN.Location = new System.Drawing.Point(8, 287);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(51, 22);
            this.labelISBN.TabIndex = 1;
            this.labelISBN.Text = "ISBN";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(8, 354);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(45, 22);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Title";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAuthor.Location = new System.Drawing.Point(239, 287);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(63, 22);
            this.labelAuthor.TabIndex = 3;
            this.labelAuthor.Text = "Author";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPublicationDate.Location = new System.Drawing.Point(8, 415);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(204, 22);
            this.labelPublicationDate.TabIndex = 4;
            this.labelPublicationDate.Text = "Publication date (YEAR)";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrice.Location = new System.Drawing.Point(239, 415);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(135, 22);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Price (FORINT)";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonAdd.Location = new System.Drawing.Point(12, 491);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(268, 55);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(12, 312);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(202, 26);
            this.textBoxISBN.TabIndex = 7;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 377);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(555, 26);
            this.textBoxTitle.TabIndex = 8;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(243, 312);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(324, 26);
            this.textBoxAuthor.TabIndex = 9;
            // 
            // textBoxPublicationDate
            // 
            this.textBoxPublicationDate.Location = new System.Drawing.Point(12, 438);
            this.textBoxPublicationDate.Name = "textBoxPublicationDate";
            this.textBoxPublicationDate.Size = new System.Drawing.Size(177, 26);
            this.textBoxPublicationDate.TabIndex = 10;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(243, 438);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(137, 26);
            this.textBoxPrice.TabIndex = 11;
            // 
            // labelInstock
            // 
            this.labelInstock.AutoSize = true;
            this.labelInstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInstock.Location = new System.Drawing.Point(417, 415);
            this.labelInstock.Name = "labelInstock";
            this.labelInstock.Size = new System.Drawing.Size(55, 22);
            this.labelInstock.TabIndex = 12;
            this.labelInstock.Text = "Stock";
            // 
            // textBoxInstock
            // 
            this.textBoxInstock.Location = new System.Drawing.Point(421, 438);
            this.textBoxInstock.Name = "textBoxInstock";
            this.textBoxInstock.Size = new System.Drawing.Size(146, 26);
            this.textBoxInstock.TabIndex = 13;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDelete.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDelete.Location = new System.Drawing.Point(299, 565);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(268, 55);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Delete by ISBN";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonUpdate.Location = new System.Drawing.Point(12, 565);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(268, 55);
            this.buttonUpdate.TabIndex = 15;
            this.buttonUpdate.Text = "Update (Price, Stock)";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDiscountAll
            // 
            this.buttonDiscountAll.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDiscountAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDiscountAll.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDiscountAll.Location = new System.Drawing.Point(833, 298);
            this.buttonDiscountAll.Name = "buttonDiscountAll";
            this.buttonDiscountAll.Size = new System.Drawing.Size(183, 55);
            this.buttonDiscountAll.TabIndex = 16;
            this.buttonDiscountAll.Text = "Discount All";
            this.buttonDiscountAll.UseVisualStyleBackColor = false;
            this.buttonDiscountAll.Click += new System.EventHandler(this.buttonDiscountAll_Click);
            // 
            // buttonDiscountByAuthor
            // 
            this.buttonDiscountByAuthor.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDiscountByAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDiscountByAuthor.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDiscountByAuthor.Location = new System.Drawing.Point(833, 363);
            this.buttonDiscountByAuthor.Name = "buttonDiscountByAuthor";
            this.buttonDiscountByAuthor.Size = new System.Drawing.Size(183, 55);
            this.buttonDiscountByAuthor.TabIndex = 17;
            this.buttonDiscountByAuthor.Text = "Discount by Author";
            this.buttonDiscountByAuthor.UseVisualStyleBackColor = false;
            this.buttonDiscountByAuthor.Click += new System.EventHandler(this.buttonDiscountByAuthor_Click);
            // 
            // buttonDiscountOne
            // 
            this.buttonDiscountOne.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDiscountOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDiscountOne.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDiscountOne.Location = new System.Drawing.Point(640, 363);
            this.buttonDiscountOne.Name = "buttonDiscountOne";
            this.buttonDiscountOne.Size = new System.Drawing.Size(183, 55);
            this.buttonDiscountOne.TabIndex = 18;
            this.buttonDiscountOne.Text = "Discount by ISBN";
            this.buttonDiscountOne.UseVisualStyleBackColor = false;
            this.buttonDiscountOne.Click += new System.EventHandler(this.buttonDiscountOne_Click);
            // 
            // buttonListByISBN
            // 
            this.buttonListByISBN.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonListByISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonListByISBN.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonListByISBN.Location = new System.Drawing.Point(299, 491);
            this.buttonListByISBN.Name = "buttonListByISBN";
            this.buttonListByISBN.Size = new System.Drawing.Size(268, 55);
            this.buttonListByISBN.TabIndex = 19;
            this.buttonListByISBN.Text = "List by ISBN";
            this.buttonListByISBN.UseVisualStyleBackColor = false;
            this.buttonListByISBN.Click += new System.EventHandler(this.buttonListByISBN_Click);
            // 
            // labelPricePercentage
            // 
            this.labelPricePercentage.AutoSize = true;
            this.labelPricePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPricePercentage.Location = new System.Drawing.Point(636, 290);
            this.labelPricePercentage.Name = "labelPricePercentage";
            this.labelPricePercentage.Size = new System.Drawing.Size(151, 22);
            this.labelPricePercentage.TabIndex = 20;
            this.labelPricePercentage.Text = "Price Percent (%)";
            // 
            // textBoxPricePercentage
            // 
            this.textBoxPricePercentage.Location = new System.Drawing.Point(639, 312);
            this.textBoxPricePercentage.Name = "textBoxPricePercentage";
            this.textBoxPricePercentage.Size = new System.Drawing.Size(166, 26);
            this.textBoxPricePercentage.TabIndex = 21;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Blue;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLogin.Location = new System.Drawing.Point(630, 438);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(386, 85);
            this.buttonLogin.TabIndex = 22;
            this.buttonLogin.Text = "Bejelentkezés";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Blue;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLogout.Location = new System.Drawing.Point(630, 535);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(386, 85);
            this.buttonLogout.TabIndex = 23;
            this.buttonLogout.Text = "Kijelentkezés";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 637);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPricePercentage);
            this.Controls.Add(this.labelPricePercentage);
            this.Controls.Add(this.buttonListByISBN);
            this.Controls.Add(this.buttonDiscountOne);
            this.Controls.Add(this.buttonDiscountByAuthor);
            this.Controls.Add(this.buttonDiscountAll);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxInstock);
            this.Controls.Add(this.labelInstock);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxPublicationDate);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelPublicationDate);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelISBN);
            this.Controls.Add(this.dataGridViewBooks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "Form1";
            this.Text = "Bookshop";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxPublicationDate;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelInstock;
        private System.Windows.Forms.TextBox textBoxInstock;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDiscountAll;
        private System.Windows.Forms.Button buttonDiscountByAuthor;
        private System.Windows.Forms.Button buttonDiscountOne;
        private System.Windows.Forms.Button buttonListByISBN;
        private System.Windows.Forms.Label labelPricePercentage;
        private System.Windows.Forms.TextBox textBoxPricePercentage;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
    }
}

