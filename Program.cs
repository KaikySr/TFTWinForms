using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

int gold = 42;
int enemyGold = 35;

ApplicationConfiguration.Initialize();
Application.EnableVisualStyles();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

Bitmap bmp = null;
Graphics g = null; 
Point cursor = Point.Empty;
bool isDown = false;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;

System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

form.Controls.Add(pb);
tm.Interval = 20;

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
    {
        Application.Exit();
    }
};

form.Load += (o, e) =>
{
    bmp = new Bitmap(pb.Width, pb.Height);
    pb.Image = bmp;
    g = Graphics.FromImage(bmp);
    tm.Start();
};

Point ajdCenter = Point.Empty;

tm.Tick += (o, e) =>
{
    Front.Desenhar(bmp, g, Cursor.Position, isDown, gold, enemyGold);
    pb.Refresh();
};

pb.MouseMove += (o, e) =>
{
    cursor = e.Location;
};

pb.MouseDown += (o, e) =>
{
    isDown = true;
};

pb.MouseUp += (o, e) =>
{
    isDown = false;
};

form.KeyDown += (o, e) =>
{

};

Application.Run(form);

