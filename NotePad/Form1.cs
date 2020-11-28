using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class ParentFrm : Form
    {
        public ParentFrm()
        {
            InitializeComponent();
        }

        byte count = 0;

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File filefrm = new File();
            filefrm.MdiParent = this;
            count++;
            filefrm.Text = "File "+count;
            filefrm.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
