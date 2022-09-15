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

namespace WinForms_EF_CRUD.Presentation
{
    public partial class FrmUserInfo : Form
    {
        public int? id;
        UserInfo objUserInfo = null;
        public FrmUserInfo(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                if (id == null)
                {
                    objUserInfo = new UserInfo();
                }
                 
                objUserInfo.Nombre = txtNombre.Text;
                objUserInfo.Correo = txtCorreo.Text;
                objUserInfo.Fecha_Nacimiento = dtFechaNacimiento.Value;

                if (id == null)
                {
                    db.UserInfoes.Add(objUserInfo); //Guardar en entity
                }
                else
                {
                    db.Entry(objUserInfo).State = System.Data.Entity.EntityState.Modified;
                }
                
                db.SaveChanges(); //Guardar en la base de datos

                this.Close();
            }            
        }

        private void LoadData()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                objUserInfo = db.UserInfoes.Find(id);
                txtNombre.Text = objUserInfo.Nombre;
                txtCorreo.Text = objUserInfo.Correo;
                dtFechaNacimiento.Value = objUserInfo.Fecha_Nacimiento;
            }
        }
    }
}
