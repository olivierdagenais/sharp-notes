using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpNotes
{
    public partial class BatchEditDialog : Form
    {
        public bool Accepted { get; set; }
        public string Value { get; set; }

        public BatchEditDialog()
        {
            InitializeComponent();
        }

        public BatchEditDialog(string fieldName)
            : this()
        {
            instructions.Text = string.Format("Enter the value to set as '{0}' for all selected songs.", fieldName);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Accepted = true;
            Value = batchValue.Text;
            Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
