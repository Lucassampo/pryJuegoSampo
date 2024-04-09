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

        public void CrearJuagador()
        {
            vida = 100;
            nombre = "Jugador1";
            puntosDaño = 1;
            imgNave = new PictureBox();
            imgNave.SizeMode = PictureBoxSizeMode.StretchImage;
            imgNave.ImageLocation = "https://cdna.artstation.com/p/assets/images/images/053/627/736/large/otis-jackson-iv-galaga1-512x512-copy.jpg?1662646025";
        }

        public void CrearEnemigo()
        {
            vida = 25;
            nombre = "malo1";
            puntosDaño = 2;
        }
    }
}
