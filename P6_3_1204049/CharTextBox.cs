using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P6_3_1204049
{
    [ToolboxBitmap(typeof(CharTextBox),"P6_3_1204049.CharTextBox.ico")]
    public partial class CharTextBox : TextBox
    {
        public CharTextBox()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                try
                {
                    int.Parse(value);
                    base.Text = value;
                    return;
                }
                catch
                { }
                if (value == null)
                {
                    base.Text = value;
                    return;
                }
            }
        }
        
        private void CharTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
