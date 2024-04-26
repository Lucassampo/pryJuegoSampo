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
            int x = 23;
            for (int i = 0; i < 7; i++)
            {
                objNaveEnemigo=new clsNave();
                objNaveEnemigo.CrearEnemigo();
                objNaveEnemigo.imgNaveEnemiga.Location = new Point(x, 50);
                Controls.Add(objNaveEnemigo.imgNaveEnemiga);
                x += objNaveEnemigo.imgNaveEnemiga.Size.Width * 2;

                //objLaser = new clsNave();
                //objLaser.CrearLaserEnemiga();

                //objLaser.imgBalaEnemiga.Location = new Point(objNaveEnemigo.imgNaveEnemiga.Location.X + 12, objNaveEnemigo.imgNaveEnemiga.Location.Y + 20);
                //Controls.Add(objLaser.imgBalaEnemiga);

                objEnemigo.Add(objNaveEnemigo);
                objNaveEnemigo = null;

            }

           
            timer1.Start();
            timer1.Enabled = true;

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

                        Score = Score + 1;
                        lblPuntos.Text = Score.ToString();
                        
                    }

                    if(Score == 50)
                    {
                        PictureBox Boss = new PictureBox();
                        Boss.BackColor = Color.White;

                        Controls.Add(Boss);
                    }
                }
            }
        }   
    }
}
