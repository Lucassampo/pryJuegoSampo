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
                objNaveEnemigo.CrearEnemigo();
                objNaveEnemigo.imgNaveEnemiga.Location = new Point(x, 50);
                Controls.Add(objNaveEnemigo.imgNaveEnemiga);
                x += objNaveEnemigo.imgNaveEnemiga.Size.Width * 2;

                objLaser = new clsNave();
                objLaser.CrearLaserEnemiga();

                objLaser.imgBalaEnemiga.Location = new Point(objNaveEnemigo.imgNaveEnemiga.Location.X + 12, objNaveEnemigo.imgNaveEnemiga.Location.Y + 20);
                Controls.Add(objLaser.imgBalaEnemiga);
            }
            
            objLaserP = new clsNave();
            objLaserP.CrearLaserJugador();

            objLaserP.imgBala.Location = new Point(objNaveJugador.imgNave.Location.X + 14, objNaveJugador.imgNave.Location.Y - objNaveJugador.imgNave.Size.Height);
            Controls.Add(objLaserP.imgBala);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X + 5, objNaveJugador.imgNave.Location.Y);
                objLaserP.imgBala.Location = new Point(objLaserP.imgBala.Location.X + 5, objLaserP.imgBala.Location.Y);
            }

            if (e.KeyCode == Keys.Left)
            {
                objNaveJugador.imgNave.Location = new Point(objNaveJugador.imgNave.Location.X - 5,objNaveJugador.imgNave.Location.Y);
                objLaserP.imgBala.Location = new Point(objLaserP.imgBala.Location.X - 5, objLaserP.imgBala.Location.Y);
            }

            if(e.KeyCode == Keys.Space)
            {
                objLaserP.imgBala.Location = new Point(objLaserP.imgBala.Location.X, objLaserP.imgBala.Location.Y);
            }        
            timer1.Enabled = true; 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            objLaserP.imgBala.Location = new Point(objLaserP.imgBala.Location.X, objLaserP.imgBala.Location.Y - 50);
        }

    }
}
