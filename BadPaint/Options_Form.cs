using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BadPaint
{
    public partial class Options_Form : Form
    {

        private frmBadPaint fbp;
        private Panel pnlCanvas;
        public Options_Form(frmBadPaint _fbp, Panel _pnlCanvas)
        {
            InitializeComponent();

            fbp = _fbp;
            pnlCanvas = _pnlCanvas;

            nudLineWidth.Value = fbp.lineWidth;

            // Setup palette controls
            fbp.paletteBoxes = new List<PictureBox>
            {
                boxPalette1,
                boxPalette2,
                boxPalette3,
                boxPalette4,
                boxPalette5,
                boxPalette6,
                boxPalette7,
                boxPalette8,
                boxPalette9,
                boxPalette10,
                boxPalette11,
                boxPalette12,
                boxPalette13,
                boxPalette14,
                boxPalette15,
                boxPalette16
            };
        }

        
        public void loadPalette(int paletteNum)
        {
            if (paletteNum < 0) {
                paletteNum = fbp.palettes.Count - 1;
            }
            if (paletteNum >= fbp.palettes.Count)
            {
                paletteNum = 0;
            }
            for (int i = 0; i < 16; i++)
            {
                if (i < fbp.palettes[paletteNum].Count)
                {
                    if (fbp.palettes[paletteNum][i] != null)
                    {
                        fbp.paletteBoxes[i].Enabled = true;
                        fbp.paletteBoxes[i].Visible = true;
                        fbp.paletteBoxes[i].BackColor = fbp.palettes[paletteNum][i];
                    }
                    else
                    {
                        fbp.paletteBoxes[i].Enabled = false;
                        fbp.paletteBoxes[i].Visible = false;
                        fbp.paletteBoxes[i].BackColor = Color.Black;
                    }
                }
                else
                {
                    fbp.paletteBoxes[i].Enabled = false;
                    fbp.paletteBoxes[i].Visible = false;
                    fbp.paletteBoxes[i].BackColor = Color.Black;
                }
            }
            nudPaletteNum.Value = paletteNum;
        }

        public void addPalettes()
        {
            fbp.palettes.Add(new List<Color> { Color.White, Color.Silver, Color.Gray, Color.Black, Color.Red, Color.Maroon, Color.Yellow, Color.Olive, Color.Lime, Color.Green, Color.Aqua, Color.Teal, Color.Blue, Color.Navy, Color.Fuchsia, Color.Purple });
            fbp.palettes.Add(new List<Color> {
                Color.MediumVioletRed, Color.DeepPink, Color.PaleVioletRed, Color.HotPink, Color.LightPink, Color.Pink,
                Color.DarkRed, Color.Firebrick, Color.Crimson, Color.IndianRed, Color.LightCoral, Color.Salmon, Color.DarkSalmon, Color.LightSalmon
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.OrangeRed, Color.Tomato, Color.DarkOrange, Color.Coral, Color.Orange,

                Color.DarkKhaki, Color.Gold, Color.Khaki,
                Color.PeachPuff, Color.PaleGoldenrod,
                Color.Moccasin, Color.PapayaWhip,
                Color.LightGoldenrodYellow, Color.LemonChiffon,
                Color.LightYellow
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.Maroon, Color.Brown, Color.SaddleBrown, Color.Sienna, Color.Chocolate, Color.DarkGoldenrod,
                Color.Peru, Color.RosyBrown, Color.Goldenrod
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.SandyBrown, Color.Tan, Color.BurlyWood, Color.Wheat, Color.NavajoWhite, Color.Bisque,
                Color.BlanchedAlmond, Color.Cornsilk
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.Indigo, Color.DarkMagenta, Color.DarkViolet, Color.DarkSlateBlue, Color.BlueViolet, Color.DarkOrchid,
                Color.SlateBlue, Color.MediumSlateBlue, Color.MediumOrchid, Color.MediumPurple, Color.Orchid,
                Color.Violet, Color.Plum, Color.Thistle, Color.Lavender
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.MidnightBlue, Color.Navy, Color.DarkBlue, Color.MediumBlue, Color.RoyalBlue, Color.SteelBlue,
                Color.DodgerBlue, Color.DeepSkyBlue, Color.CornflowerBlue, Color.SkyBlue, Color.LightSkyBlue,
                Color.LightSteelBlue, Color.LightBlue, Color.PowderBlue
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.DarkCyan, Color.LightSeaGreen, Color.CadetBlue, Color.DarkTurquoise, Color.MediumTurquoise,
                Color.Turquoise, Color.Aqua, Color.Cyan, Color.Aquamarine, Color.PaleTurquoise, Color.LightCyan
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.DarkGreen, Color.DarkOliveGreen, Color.ForestGreen, Color.SeaGreen, Color.OliveDrab, Color.MediumSeaGreen,
                Color.LimeGreen, Color.SpringGreen, Color.MediumSpringGreen
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.DarkSeaGreen, Color.MediumAquamarine,
                Color.YellowGreen, Color.LawnGreen, Color.Chartreuse, Color.LightGreen, Color.GreenYellow, Color.PaleGreen
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.MistyRose, Color.AntiqueWhite, Color.Linen, Color.Beige, Color.WhiteSmoke, Color.LavenderBlush,
                Color.OldLace, Color.AliceBlue, Color.SeaShell, Color.GhostWhite, Color.Honeydew, Color.FloralWhite,
                Color.Azure, Color.MintCream, Color.Snow, Color.Ivory
            });
            fbp.palettes.Add(new List<Color>
            {
                Color.DarkSlateGray, Color.DimGray, Color.SlateGray, Color.LightSlateGray, Color.DarkGray, Color.LightGray, Color.Gainsboro
            });
        }

        private void box_palette_MouseDown(object sender, MouseEventArgs e)
        {
            // Change pen color
            PictureBox paletteBox = (PictureBox) sender;

            if (e.Button == MouseButtons.Right)
            {
                // Change secondary pen
                fbp.pen2.Color = paletteBox.BackColor;
            }
            else
            {
                // Change primary pen
                fbp.pen1.Color = paletteBox.BackColor;
            }

            updateSelectedColors();
        }

        private void Options_Form_Load(object sender, EventArgs e)
        {
            // Draw selected colors
            updateSelectedColors();

            // Draw palette
            loadPalette(0);
        }

        private void Options_Form_Enter(object sender, EventArgs e)
        {
            //isActive(true);
        }

        private void Options_Form_Leave(object sender, EventArgs e)
        {
            //isActive(false);
        }

        private void Options_Form_MouseEnter(object sender, EventArgs e)
        {
            //isActive(true);
        }

        private void isActive(bool _active)
        {
            if (_active)
            {
                this.Opacity = 1.0;
                label1.Visible = false;
            }
            else
            {
                this.Opacity = 0.75;
                label1.Visible = true;
            }
        }

        private void Options_Form_MouseLeave(object sender, EventArgs e)
        {
            //isActive(false);
        }

        private void Options_Form_Activated(object sender, EventArgs e)
        {
            isActive(true);
        }

        private void Options_Form_Deactivate(object sender, EventArgs e)
        {
            isActive(false);
        }

        private void boxOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.ShowDialog();

            if (dlgOpen.FileName != "")
            {
                fbp.imageBuffer = new Bitmap(dlgOpen.FileName);
                fbp.graphics = Graphics.FromImage(fbp.imageBuffer);
                fbp.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Graphics pnlgfx = pnlCanvas.CreateGraphics();
                pnlgfx.DrawImage(fbp.imageBuffer, 0, 0);
                pnlgfx.Dispose();
            }
        }

        private void btnChangeCustomColor_Click(object sender, EventArgs e)
        {
            dlgCustomPalette.ShowDialog();

            if (dlgCustomPalette.Color != null)
            {
                boxPaletteCustom.BackColor = dlgCustomPalette.Color;
            }
        }

        private void boxSave_Click(object sender, EventArgs e)
        {
            dlgSave = new SaveFileDialog();
            dlgSave.Filter = "PNG Image|*.png";
            dlgSave.Title = "Save an Image File";
            dlgSave.ShowDialog();

            if (dlgSave.FileName != "")
            {
                pnlCanvas.DrawToBitmap(fbp.imageBuffer, new Rectangle(0, 0, pnlCanvas.Width, pnlCanvas.Height));
                fbp.imageBuffer.Save(dlgSave.FileName, ImageFormat.Png);
            }
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            fbp.lineWidth = (int)nudLineWidth.Value;
            fbp.pen1.Width = fbp.lineWidth;
            fbp.pen2.Width = fbp.lineWidth;
        }

        private void boxFill_Click(object sender, EventArgs e)
        {
            // 
        }

        public void updateSelectedColors()
        {
            // Update selected color boxes
            boxPaletteSelected1.BackColor = fbp.pen1.Color;
            boxPaletteSelected2.BackColor = fbp.pen2.Color;
        }

        private void boxFill_MouseDown(object sender, MouseEventArgs e)
        {

            // Fill canvas with pen
            if (e.Button == MouseButtons.Right)
            {
                // Fill with secondary color
                fbp.graphics.FillRectangle(fbp.pen2.Brush, Rectangle.FromLTRB(0, 0, pnlCanvas.Width, pnlCanvas.Height));
            }
            else
            {
                // Fill with primary color
                fbp.graphics.FillRectangle(fbp.pen1.Brush, Rectangle.FromLTRB(0, 0, pnlCanvas.Width, pnlCanvas.Height));
            }

            // Redraw
            Graphics pnlgfx = pnlCanvas.CreateGraphics();
            pnlgfx.DrawImage(fbp.imageBuffer, 0, 0);
            pnlgfx.Dispose();
        }

        private void nudPaletteNum_ValueChanged(object sender, EventArgs e)
        {
            // Change palette to value
            NumericUpDown nud = (NumericUpDown)sender;
            loadPalette((int)nud.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void box_palette_MouseDown(object sender, EventArgs e)
        {

        }
    }
}
