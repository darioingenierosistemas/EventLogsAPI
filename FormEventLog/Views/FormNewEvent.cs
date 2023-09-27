using FormEventLog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEventLog.Views
{
    public partial class FormNewEvent : Form
    {
        Thread th;
        string url = $"https://localhost:7258/";
        DateTime fechaSeleccionada = DateTime.Now;
        string valorSeleccionado = string.Empty;

        public FormNewEvent()
        {
            InitializeComponent();
        }

        private void FormNewEvent_Load(object sender, EventArgs e)
        {
          
        
        }

        private void dateTimeEventDate_ValueChanged(object sender, EventArgs e)
        {
            fechaSeleccionada = ((DateTimePicker)sender).Value;
        }

        private void cbxEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            valorSeleccionado = ((ComboBox)sender).SelectedItem.ToString();
        }

        private async void btnSaveEventLog_Click(object sender, EventArgs e)
        {
            EventLogs eventLog = new EventLogs();
            eventLog.EventDate = fechaSeleccionada;
            eventLog.Description = txbDescription.Text;
            eventLog.EventType = valorSeleccionado;

            string json = JsonConvert.SerializeObject(eventLog);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync
              (url + "eventlogs", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                this.Close();
                th = new Thread(openForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }

        }

        private void openForm(Object obj)
        {
            Application.Run(new FormEvents());
        }

        private void FormNewEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
    
            th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
