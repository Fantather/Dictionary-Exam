using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary_Exam
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CreateDictionary_Click(object sender, EventArgs e)
        {
            Application.Run(new Form1());
        }

        private void LoadDictionary_Click(object sender, EventArgs e)
        {
            Application.Run(new Form1());
        }
    }
}
