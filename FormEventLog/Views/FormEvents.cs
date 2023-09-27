
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
        string url = $"https://localhost:7258/";

        public FormEvents()
        {
            InitializeComponent();

        }

        private async void FormEvents_Load(object sender, EventArgs e)
        {

            await DataGrid();

        }

        private async Task DataGrid()
        {
            List<EventLogs> logs = await Listar();
            DataTable dt = new DataTable();

            dt.Columns.Add("EventId", typeof(int));
            dt.Columns.Add("EventDate", typeof(DateTime));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("EventType", typeof(string));

            foreach (var item in logs)
            {
                DataRow row = dt.NewRow();
                row["EventId"] = item.EventId;
                row["EventDate"] = item.EventDate;
                row["Description"] = item.Description;
                row["EventType"] = item.EventType;

                dt.Rows.Add(row);
            }

            dataGridViewEvents.DataSource = dt;

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
