using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_EF_CRUD.Models;

namespace WinForms_EF_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        #region HELPER
        private void Refresh()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                var lst = from d in db.UserInfoes
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {

                return null;
            }
            
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FrmUserInfo objUserInfo = new Presentation.FrmUserInfo();
            objUserInfo.ShowDialog(); //Abrir cuadro de dialogo Hijo

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Presentation.FrmUserInfo objUserInfo = new Presentation.FrmUserInfo(id);
                objUserInfo.ShowDialog(); //abrir cuadro de dialogo Hijo

                Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (TestDBEntities db = new TestDBEntities())
                {
                    UserInfo objUserInfo = db.UserInfoes.Find(id);
                    db.UserInfoes.Remove(objUserInfo);

                    db.SaveChanges();
                }

                Refresh();
            }
        }
    }
}
