using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pt_legitymacjestudenckie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CardReader cr = new CardReader();

            int i = 0;

            cr.Initialize();
            if(cr.Connect())
                i = cr.ReadData();
            cr.Release();
        }
    }
}
