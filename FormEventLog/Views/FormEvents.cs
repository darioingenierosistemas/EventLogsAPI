
using FormEventLog.Models;
using FormEventLog.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormEventLog
{
    public partial class FormEvents : Form
    {
        Thread th;
        private BindingList<List<EventLogs>> dataList = new BindingList<List<EventLogs>>();
        private BindingSource bindingSource = new BindingSource();
        string url = $"https://localhost:7258/";

        public FormEvents()
        {
            InitializeComponent();
            

        }

        private async void FormEvents_Load(object sender, EventArgs e)
        {

            DataGrid();

        }

        private async void DataGrid()
        {
            dataGridViewEvents.DataSource = await Listar();
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewEvents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Establece la propiedad ScrollBars.
            dataGridViewEvents.ScrollBars = ScrollBars.Both;

            // Añade el DataGridView al formulario.
            this.Controls.Add(dataGridViewEvents);

         

        }

        public async Task<List<EventLogs>> Listar()
        {
            WebRequest request = WebRequest.Create(url + "eventlogs");
            WebResponse webResponse = request.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            List<EventLogs> logs = JsonConvert.DeserializeObject<List<EventLogs>>(await sr.ReadToEndAsync());
            return logs;
        }


        private void dataGridViewEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
 
            }
        }

        private void openForm(Object obj)
        {
            Application.Run(new FormNewEvent());
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {

            this.Close();
            th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void FormEvents_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

      

       
    }
}
