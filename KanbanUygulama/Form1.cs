using DataAccess.ConcreteRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanbanUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            db = new KanbanContext();
            userRepository = new UserRepository(db);
        }
        KanbanContext db;
        UserRepository userRepository;
        public static int gelenID;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayıtOl kayıtOl=new KayıtOl();
            kayıtOl.Show();
            this.Hide();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            var UserList=userRepository.GetAll();
            
            if (UserList.Exists(x => x.UserName == txtUserName.Text) && UserList.Exists(x => x.Password == txtPassword.Text))
            {
                gelenID=UserList.FirstOrDefault(x=>x.UserName==txtUserName.Text&&x.Password==txtPassword.Text).ID;
                MessageBox.Show("Giriş işlemi başarılı bir şekilde olmuştur");
               AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Wrong username or password");
        }
    }
}
