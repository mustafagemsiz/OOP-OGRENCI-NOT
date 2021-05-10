using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITYLAYER;
using FACADELAYER;
using BUSINESSLOGICLAYER;
namespace OgrenciNot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void OgrenciListele()
        {
            List<ENTITYOGRENCI> ListOgr = BLLOGRENCI.LISTELE();
            dataGridView1.DataSource = ListOgr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListele();
        }
    }
}
