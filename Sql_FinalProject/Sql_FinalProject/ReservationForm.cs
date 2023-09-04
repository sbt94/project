using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_FinalProject
{
    public partial class ReservationForm : Form
    {

    private string email;
        public ReservationForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
