using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlViewer.View
{
    public partial class ResultForm : Form
    {
        public ResultForm(DataTable dataTable)
        {
            InitializeComponent();
            dg.DataSource = dataTable;
        }
    }
}
