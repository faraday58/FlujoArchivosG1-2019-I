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
        BinaryReader br;
        BinaryWriter bw;
        FileInfo fi;
        List<string> texto;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt,*.bin| txt,bin";

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

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            
            if(sfd.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    fi = new FileInfo(sfd.FileName);
                    bw = new BinaryWriter(fi.OpenWrite());

                    string texto = rtbNotas.Text;
                    int entero =int.Parse( txtbEntero.Text);
                    double doble = double.Parse(txtbDouble.Text);
                    bw.Write(texto);
                    bw.Write(entero);
                    bw.Write(doble);

                }
                catch(IOException error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
                finally
                {
                    bw.Close();
                }
            }
        }
    }
}
