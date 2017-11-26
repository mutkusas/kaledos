using System;
using System.Collections;
using System.Windows.Forms;

namespace SecretSanta
{
    public partial class Visuals : Form
    {
        static ArrayList dalyviai = new ArrayList();
        static ArrayList potas = new ArrayList();
        public Visuals()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Santa naujas = new Santa(nameBox.Text, mailBox.Text);
            listBox.Items.Add(naujas.name);
            dalyviai.Add(naujas);
            potas.Add(naujas);
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            randomizator();
            foreach (Santa a in dalyviai)
            {
                a.sendMail();
            }
            MessageBox.Show("Programa sėkmingai baigė darbą. Galite pasitikrinti savo elektroninį paštą.", "Kalėdų Senelio generatorius");
        }

        public static void randomizator()
        {
            potas.Clear();
            foreach (Santa a in dalyviai)
            {
                potas.Add(a);
            }
            Random rnd = new Random();
            foreach (Santa participant in dalyviai)
            {
                bool stop = false;
                Santa istrauktas = null;
                int number = -1;
                number = rnd.Next(0, potas.Count);
                istrauktas = (Santa)potas[number];
                if (participant == istrauktas)
                {
                    stop = true;
                    randomizator();
                }
                if (stop)
                {
                    return;
                }
                participant.asignee = istrauktas;
                potas.RemoveAt(number);
            }
        }
    }
}
