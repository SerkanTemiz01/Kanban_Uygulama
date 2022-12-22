using DataAccess.ConcreteRepository;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Enum;
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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
            db=new KanbanContext();
            userRepository = new UserRepository(db);
            workRepository= new WorkRepository(db);
        }
        KanbanContext db;
        UserRepository userRepository;
        WorkRepository workRepository;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Work w = new Work()
            {
                WorkName = txtWorkName.Text,
                UserID=Form1.gelenID

            };
            if (rdbToDo.Checked)
                w.States = State.ToDo;
            else if(rdbDoing.Checked)
                w.States = State.Doing;
            else
                w.States = State.Done;

            var taskList = workRepository.GetAll().Where(x=>x.UserID==Form1.gelenID).ToList();
            if(!taskList.Exists(x=>x.WorkName==txtWorkName.Text))
            {
                workRepository.Add(w);
                DgwGuncelleme();
            }
            
        }
        
        
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            DgwGuncelleme();
            
        }

      
       
        Work updateTask;
        
        private void LabelBasma(DataGridView dataGridView)
        {
            
            int updateWorkId = (int)dataGridView.CurrentRow.Cells["TaskID"].Value;
            updateTask=workRepository.GetById(updateWorkId);
            lblShowTask.Text = updateTask.WorkName;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if(rdbToDo1.Checked)
                updateTask.States = State.ToDo;
            else if(rdbDoing1.Checked)
                updateTask.States = State.Doing;
            else
                updateTask.States = State.Done;

            workRepository.Update(updateTask);
            DgwGuncelleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DgwGuncelleme();
        }

        private void DgwGuncelleme()
        {
            var taskList = workRepository.GetAll().Where(x => x.UserID == Form1.gelenID).Select(x => new
            {
                TaskID=x.ID,
                InHisCharge=x.User.FirstName+ " "+x.User.LastName,
                Task=x.WorkName,
                x.States
            }).ToList();
            dataGridView1.DataSource = taskList.Where(x => x.States == State.ToDo).ToList();
            dataGridView2.DataSource = taskList.Where(x => x.States == State.Doing).ToList();
            dataGridView3.DataSource = taskList.Where(x => x.States == State.Done).ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            LabelBasma(dataGridView1);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
           LabelBasma(dataGridView2);
        }
    }
}
