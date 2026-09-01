using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmester
{
    public partial class quizForm : Form
    {
        public quizForm()
        {
            InitializeComponent();
        }


        RegisterForm RegisterForm = new RegisterForm();
        private void btnTestForm_Click(object sender, EventArgs e)
        {
            RegisterForm.Show();
        }
    }
}
