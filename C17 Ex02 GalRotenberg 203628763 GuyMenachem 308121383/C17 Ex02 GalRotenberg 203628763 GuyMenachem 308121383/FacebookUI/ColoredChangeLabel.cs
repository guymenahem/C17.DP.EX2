using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    class ColoredChangeLabel : Label
    {
        private Label m_Label { get; set; }
        private Color m_color { get; set; }

        public Color Color
        {
            get
            {
                return this.m_color;
            }

            set
            {
                this.m_color = value;
                this.m_Label.BackColor = this.m_color;
                this.m_Label.ForeColor = InvertColour();

            }
        }

        public ColoredChangeLabel(Label i_Label)
        {
            this.m_Label = i_Label;
        }

        private Color InvertColour()
        {
            return Color.FromArgb((byte)~this.m_color.R, (byte)~this.m_color.G, (byte)~this.m_color.B);
        }

        private void UpdateColorByPhoto(Bitmap i_Bitmap)
        {
            this.Color = i_Bitmap.GetPixel((int)(i_Bitmap.Width * 0.1),(int)(i_Bitmap.Height * 0.7));
        }

        public void BindToPictureUpload(object sender, AsyncCompletedEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            this.UpdateColorByPhoto(new Bitmap(p.Image));
        }
    }
}
