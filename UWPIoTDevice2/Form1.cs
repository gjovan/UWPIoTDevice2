using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UWPIoTDevice2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Task.Run(async () => {
                while (true)
                {
                    var message = await AzureIoTHub.ReceiveCloudToDeviceMessageAsync();
                    //await ...
                    textBox1.Text = message;
                    textBox1.Update();
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(async() => { await AzureIoTHub.SendDeviceToCloudMessageAsync(); });
        }
    }
}
