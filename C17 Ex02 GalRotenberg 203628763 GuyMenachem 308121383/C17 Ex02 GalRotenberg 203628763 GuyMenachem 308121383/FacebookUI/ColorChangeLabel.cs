using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    public class ColorChangeLabel : Label
    {

        public void AdjustColors(PictureBox i_Pic)
        {
            Bitmap bitmap = new Bitmap(i_Pic.Image);
            Color col = bitmap.GetPixel(bitmap.Width - 30, bitmap.Height - 30);

            this.ForeColor = col;
            this.BackColor = Color.FromArgb(col.A, col.R > 127 ? 0 : 255, col.G > 127 ? 0 : 255, col.B > 127 ? 0 : 255);
        }

    }
}
