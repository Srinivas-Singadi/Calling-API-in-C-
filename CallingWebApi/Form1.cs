using CallingWebApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallingWebApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CallingMetods call = new CallingMetods();
            // ICollection<Customer> objList = call.GetUsers();
             call.GetUsers();

           // dataGridView1.DataSource = objList;

           
            
        }
    }
}
