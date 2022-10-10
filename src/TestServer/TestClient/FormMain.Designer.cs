
namespace TestClient
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxAddr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonChangeStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxBasket = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxStock = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripButtonStock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddOrd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.Location = new System.Drawing.Point(260, 44);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(240, 394);
            this.listBoxOrders.TabIndex = 0;
            this.listBoxOrders.SelectedIndexChanged += new System.EventHandler(this.listBoxOrders_SelectedIndexChanged);
            this.listBoxOrders.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.listBoxOrders_Format);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxAddr,
            this.toolStripButtonConnect,
            this.toolStripSeparator1,
            this.toolStripButtonStock,
            this.toolStripSeparator3,
            this.toolStripButtonChangeStatus,
            this.toolStripSeparator2,
            this.toolStripButtonAddOrd,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1003, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBoxAddr
            // 
            this.toolStripTextBoxAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxAddr.Name = "toolStripTextBoxAddr";
            this.toolStripTextBoxAddr.Size = new System.Drawing.Size(150, 25);
            this.toolStripTextBoxAddr.ToolTipText = "Enter the server\'s address";
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConnect.Image")));
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonConnect.Text = "Connect";
            this.toolStripButtonConnect.ToolTipText = "Connect and load customers";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonChangeStatus
            // 
            this.toolStripButtonChangeStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonChangeStatus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChangeStatus.Image")));
            this.toolStripButtonChangeStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeStatus.Name = "toolStripButtonChangeStatus";
            this.toolStripButtonChangeStatus.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonChangeStatus.Text = "Change status";
            this.toolStripButtonChangeStatus.ToolTipText = "Change order status";
            this.toolStripButtonChangeStatus.Click += new System.EventHandler(this.toolStripButtonChangeStatus_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(12, 44);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(240, 394);
            this.listBoxClients.TabIndex = 2;
            this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders:";
            // 
            // listBoxBasket
            // 
            this.listBoxBasket.FormattingEnabled = true;
            this.listBoxBasket.Location = new System.Drawing.Point(506, 44);
            this.listBoxBasket.Name = "listBoxBasket";
            this.listBoxBasket.Size = new System.Drawing.Size(240, 394);
            this.listBoxBasket.TabIndex = 7;
            this.listBoxBasket.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.listBoxBasket_Format);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Basket:";
            // 
            // listBoxStock
            // 
            this.listBoxStock.FormattingEnabled = true;
            this.listBoxStock.Location = new System.Drawing.Point(752, 44);
            this.listBoxStock.Name = "listBoxStock";
            this.listBoxStock.Size = new System.Drawing.Size(240, 394);
            this.listBoxStock.TabIndex = 9;
            this.listBoxStock.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.listBoxStock_Format);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(749, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stock:";
            // 
            // toolStripButtonStock
            // 
            this.toolStripButtonStock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStock.Image")));
            this.toolStripButtonStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStock.Name = "toolStripButtonStock";
            this.toolStripButtonStock.Size = new System.Drawing.Size(80, 22);
            this.toolStripButtonStock.Text = "Update stock";
            this.toolStripButtonStock.Click += new System.EventHandler(this.toolStripButtonStock_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAddOrd
            // 
            this.toolStripButtonAddOrd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddOrd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddOrd.Image")));
            this.toolStripButtonAddOrd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddOrd.Name = "toolStripButtonAddOrd";
            this.toolStripButtonAddOrd.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonAddOrd.Text = "Add order";
            this.toolStripButtonAddOrd.Click += new System.EventHandler(this.toolStripButtonAddOrd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxBasket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.listBoxOrders);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "TestClient";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAddr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxBasket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButtonChangeStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonStock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ListBox listBoxStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddOrd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

