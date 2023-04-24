using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
    
namespace XML_tarea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<Carro> carros = new List<Carro>();
            XmlSerializer searial = new XmlSerializer(typeof(List<Carro>));
            carros.Add(new Carro() { placa = "XML340", modelo = 2023, dueño = "Emmanuel"});
            carros.Add(new Carro() { placa = "RTX190", modelo = 2021, dueño = "Benito" });
            carros.Add(new Carro() { placa = "UML230", modelo = 2020, dueño = "Miller" });
            using (FileStream FS = new FileStream(Environment.CurrentDirectory + "\\xmltarea.xml", FileMode.Create, FileAccess.Write))
            {
                searial.Serialize(FS, carros);
                MessageBox.Show("Creado");
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            List<Carro> p1 = new List<Carro>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Carro>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\xmltarea.xml", FileMode.Open, FileAccess.Read))
            {
                p1 = serial.Deserialize(fs) as List<Carro>;
            }
            dataGridView1.DataSource = p1;
        }
    }
}
