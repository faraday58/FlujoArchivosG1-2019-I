using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FormularioArchivos
{
    public partial class Form1 : Form
    {
        FileStream fs;
        StreamReader sr;
        List<string> texto;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if( ofd.ShowDialog() == DialogResult.OK    )
            {
                texto = new List<string>();
                try
                {
                    fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    string aux = sr.ReadLine();
                    while( aux != null   )
                    {
                        texto.Add(aux);
                        aux=sr.ReadLine();
                    }

                }
                catch(IOException error)
                {
                    MessageBox.Show("Error :" + error.Message);
                }
                finally
                {
                    fs.Close();
                    sr.Close();
                }
                for(int i=0; i < texto.Count;i ++)
                {
                    rtbNotas.AppendText(texto[i]);
                }
                

            }


        }
    }
}
