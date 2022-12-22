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
    public partial class KayıtOl : Form
    {
        public KayıtOl()
        {
            InitializeComponent();
            db=new KanbanContext();
            userRepository = new UserRepository(db);
        }
        KanbanContext db;
        UserRepository userRepository;
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
            };
            var UserList = userRepository.GetAll();

            
            if (!UserList.Exists(x => x.UserName == txtUserName.Text) && !UserList.Exists(x => x.Password == txtPassword.Text))
            {
                userRepository.Add(user);
                MessageBox.Show("Kayıt Başarılı bir şekilde olmuştur");
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
            else
                MessageBox.Show("There is a exist. Please again different username or password");
        }
    }
}
