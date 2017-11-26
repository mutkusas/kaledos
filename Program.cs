using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecretSanta
{
    class Program
    {
        static ArrayList dalyviai = new ArrayList();
        static ArrayList potas = new ArrayList();
        static void Main(string[] args)
        {
            Application.Run(new Visuals());

            //Santa vienas = new Santa("Irmantas", "ivanauskas96@gmail.com");
            //Santa du = new Santa("Petras", "petropastas@abc.com");
            //Santa trys = new Santa("Jonas", "jonopastas@abc.com");
            //Santa keturi = new Santa("Deima", "jonopastas@abc.com");
            //Santa penki= new Santa("Matas", "jonopastas@abc.com");

            //dalyviai.Add(vienas);
            //dalyviai.Add(du);
            //dalyviai.Add(trys);
            //dalyviai.Add(keturi);
            //dalyviai.Add(penki);

            //randomizator();

            //foreach (Santa a in dalyviai)
            //{
            //    a.sendMail();
            //}            
        }

        public static void randomizator()
        {
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
                Console.WriteLine(participant.name + " " + istrauktas.name);
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
            //vienas.sendMail("ivanauskas96@gmail.com");
            Console.Read();
        }
    }
}
