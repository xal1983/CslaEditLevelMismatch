using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csla;
using Csla.Core;
namespace EditLevelMismatch
{
    public partial class Form1 : Form
    {
        Invoice originalInvoice;
        public Form1()
        {
            InitializeComponent();
            originalInvoice = Program.Host.Services.GetRequiredService<IDataPortal<Invoice>>().Create();
            SetDataSource(originalInvoice);
        }

        private void SetDataSource(Invoice i)
        {
            invoiceBindingSource.DataSource = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clone the invoice
            var clonedInvoice = originalInvoice.Clone();

            //Get the cost objects from each invoice and show their EditLevels
            var originalCost = originalInvoice.Costs.First();
            var clonedCost = clonedInvoice.Costs.First();

            Console.WriteLine(
                $"Original cost   EditLevel: {((IUndoableObject)originalCost).EditLevel}   FieldManager EditLevel: {originalCost.GetFieldManager().EditLevel}\n" +
                $"Cloned cost     EditLevel: {((IUndoableObject)clonedCost).EditLevel}   FieldManager EditLevel: {clonedCost.GetFieldManager().EditLevel}");

            var newForm = new Form1();
            newForm.SetDataSource(clonedInvoice);
            newForm.ShowDialog();
        }
    }
}
