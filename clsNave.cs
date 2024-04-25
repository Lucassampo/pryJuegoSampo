using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryJuegoSampo
{
    internal class clsNave
    {
        //Caracteristicas
        public int vida;
        public string nombre;
        int puntosDaño;
        public PictureBox imgNave;
        public PictureBox imgNaveEnemiga;
        public PictureBox imgBala;
        public PictureBox imgBalaEnemiga;

        public void CrearJuagador()
        {
            vida = 100;
            nombre = "Jugador1";
            puntosDaño = 1;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = "https://static.wikia.nocookie.net/xenofighters/images/c/c3/Profilepic834_14.gif/revision/latest/scale-to-width/360?cb=20110106152439";
            imgNave.BackColor = System.Drawing.Color.Transparent;
           
        }

        public void CrearEnemigo()
        {
            vida = 25;
            nombre = "malo1";
            puntosDaño = 2;
            imgNaveEnemiga= new PictureBox();
            imgNaveEnemiga.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNaveEnemiga.ImageLocation = "https://64.media.tumblr.com/349ab85cdb85bd3c0a82e7c5b463d6c8/tumblr_p0g2924Jw31wo2b1bo3_400.gif";
            imgNaveEnemiga.Size = new System.Drawing.Size(60, 70);
            imgNaveEnemiga.BackColor = System.Drawing.Color.Transparent;
        }

        public void CrearLaserEnemiga()
        {
            imgBalaEnemiga = new PictureBox();
            imgBalaEnemiga.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBalaEnemiga.ImageLocation = "https://i0.wp.com/donaldcarling.wordpress.com/wp-content/uploads/2016/03/blast-harrier-laser-1.png?w=502&h=893&ssl=1";
            imgBalaEnemiga.Size = new System.Drawing.Size(7, 50);
            imgBalaEnemiga.BackColor = System.Drawing.Color.Transparent;
        }

        public void CrearLaserJugador()
        {
            imgBala = new PictureBox();
            imgBala.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBala.ImageLocation = "https://donaldcarling.wordpress.com/wp-content/uploads/2016/03/mega-laser-1.png";
            imgBala.Size = new System.Drawing.Size(8, 100);
            imgBala.BackColor = System.Drawing.Color.Transparent;
           
        }
    }
}
