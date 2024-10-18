using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Param_Randomizer.Settings
{
    public partial class WeaponWeight : Form
    {

        public float UserInput { get; set; }

        public WeaponWeight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInput = (float)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
