using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryJuegoSampo
{
    public partial class Form1 : Form
    {
        //zona de decalracion global
        clsNave objNaveJugador;
        clsNave objNaveEnemigo;
        clsNave objLaserP;
        clsNave objLaser;
        public int Score = 0;
        public int Muertes = 0;
        

        List<clsNave> objList = new List<clsNave>();
        List<clsNave> objEnemigo = new List<clsNave>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objNaveJugador = new clsNave();
            objNaveJugador.CrearJuagador();
            objNaveJugador.imgNave.Location = new Point(200, 500);
            Controls.Add(objNaveJugador.imgNave);

            objNaveEnemigo = new clsNave();
            int x = 10;
            for (int i = 0; i < 5; i++)
            {
                objNaveEnemigo=new clsNave();
                objNaveEnemigo.CrearEnemigo();
                objNaveEnemigo.imgNaveEnemiga.Location = new Point(x, 50);
                Controls.Add(objNaveEnemigo.imgNaveEnemiga);
                x += (objNaveEnemigo.imgNaveEnemiga.Size.Width * 2) - 10;

               objEnemigo.Add(objNaveEnemigo);
               objNaveEnemigo = null;

            }

            timer1.Start();
            timer1.Enabled = true;
            timerEnemigos.Start();
            timerEnemigos.Enabled = true; 
            timerMovimientoNaves.Start();
            timerEnemigos.Enabled = true; 

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X + 5, objNaveJugador.imgNave.Location.Y);
                
            }

            if (e.KeyCode == Keys.Left)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X - 5,objNaveJugador.imgNave.Location.Y);
                
            }
           
            if (e.KeyCode == Keys.Space)
            {
                objLaserP = new clsNave();
                objLaserP.CrearLaserJugador();

                objLaserP.imgBala.Location = new Point(objNaveJugador.imgNave.Location.X + 14, objNaveJugador.imgNave.Location.Y - objNaveJugador.imgNave.Size.Height);
                Controls.Add(objLaserP.imgBala);
            
                 objList.Add(objLaserP);
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Recorre uno por uno
            foreach (clsNave bala in objList)
            {
                bala.imgBala.Location = new Point(bala.imgBala.Location.X,
                bala.imgBala.Location.Y - 10);
                foreach (clsNave Enemigo in objEnemigo)
                {
                    if (bala.imgBala.Bounds.IntersectsWith(Enemigo.imgNaveEnemiga.Bounds))
                    {
                        Enemigo.imgNaveEnemiga.Dispose();
                        bala.imgBala.Dispose();
                        objEnemigo.Remove(Enemigo);
                        

                        Score = Score + 25;
                        lblPuntos.Text = Score.ToString();
                        Muertes = Muertes + 1;
                        if (Muertes == 5)
                        {
                            
                            Muertes = 0;
                        }

                        break;
                    }
                }
            }
        }

        int PosX, PosY;
        Random randomx = new Random();
        Random randomY = new Random();

        private void timerMovimientoNaves_Tick(object sender, EventArgs e)
        {
            foreach(clsNave Enemigos in objEnemigo)
            {
                Random random = new Random();
                int direction = random.Next(2) == 0 ? -2 : 2;


                Enemigos.imgNaveEnemiga.Location = new Point(Enemigos.imgNaveEnemiga.Location.X + direction, Enemigos.imgNaveEnemiga.Location.Y);
            }
        }

        private void timerEnemigos_Tick(object sender, EventArgs e)
        {
            if (objEnemigo.Count == 0)
            {
                int x = 10;
                for (int i = 0; i < 5; i++)
                {
                    PosX = randomx.Next(0, 650);
                    PosY = randomY.Next(30, 40);
                    objNaveEnemigo = new clsNave();
                    objNaveEnemigo.CrearEnemigo();
                    objEnemigo.Add(objNaveEnemigo);
                    objNaveEnemigo.imgNaveEnemiga.Location = new Point(PosX, PosY);
                    Controls.Add(objNaveEnemigo.imgNaveEnemiga);
                    //PosX += objNaveEnemigo.imgNaveEnemiga.Size.Width * 2;
                }
            }
        }
    }
}