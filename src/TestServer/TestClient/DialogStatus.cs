using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestServer;

namespace TestClient
{
    internal partial class DialogStatus : Form
    {
        private OrderView order;

        public DialogStatus(OrderView ov, List<Status> statuses)
        {
            if (ov is null || statuses is null) throw new ArgumentNullException();

            InitializeComponent();
            order = ov;
            label1.Text= string.Format("Change order #{0} status to:", ov.OrderId);
            BindingSource bns = new BindingSource();
            bns.DataSource = statuses;
            listBoxStatuses.DataSource = bns;
            listBoxStatuses.DisplayMember = "Name";

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var item = listBoxStatuses.SelectedItem;
            if (item is null) return;
            order.Status = (Status)item;
        }
    }
}
