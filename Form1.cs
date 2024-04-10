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
        Random random = new Random();
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
            objNaveEnemigo.CrearEnemigo();
            objNaveEnemigo.imgNaveEnemiga.Location = new Point(200, 100);   
            Controls.Add(objNaveEnemigo.imgNaveEnemiga);
            
            int x = random.Next(this.Width -  objNaveEnemigo.imgNaveEnemiga.Width);
            int y = random.Next(this.Height - objNaveEnemigo.imgNaveEnemiga.Height);
            
            objNaveEnemigo.imgNaveEnemiga.Location = new Point(x, y);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X + 5, 
                    objNaveJugador.imgNave.Location.Y);
            }

            if (e.KeyCode == Keys.Left)
            {
                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X - 5,
                    objNaveJugador.imgNave.Location.Y);
            }

            if (e.KeyCode == Keys.Up)
            {
                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X,
                    objNaveJugador.imgNave.Location.Y - 5);
            }

            if(e.KeyCode == Keys.Down)
            {
                objNaveJugador.imgNave.Location = new Point(
                    objNaveJugador.imgNave.Location.X,
                    objNaveJugador.imgNave.Location.Y + 5);
            }
        }
    }
}
