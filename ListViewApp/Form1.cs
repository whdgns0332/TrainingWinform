using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    listView1.View = View.LargeIcon;
                    break;

                case 1:
                    listView1.View = View.Details;
                    break;

                case 2:
                    listView1.View = View.SmallIcon;
                    break;

                case 3:
                    listView1.View = View.List;
                    break;

                case 4:
                    listView1.View = View.Tile;
                    break;

                default:
                    break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                ListViewSubItemCollection subItem = item.SubItems;
                
            }
        }
    }
}
