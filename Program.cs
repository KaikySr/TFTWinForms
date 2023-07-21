using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

int gold = 43;
int enemyGold = 22;

Campeao DonPlatinado = new Campeao
(
    "Don Platinado",
    5,
    "Lendario",
    2000, 
    100, 
    4, 
    new Classes[]{Classes.Desenvolvedores, Classes.Instrutores, Classes.Mecanicos},
    "assets/imgs/x.png"
);

List<Campeao> campeaos = new List<Campeao>();
campeaos.Add(DonPlatinado);

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
    g.Clear(Color.White);
    Front.Desenhar(bmp, g, Cursor.Position, isDown, gold, enemyGold);

    foreach (var item in campeaos)
        item.Update();

    foreach (var item in campeaos)
        item.Draw(g);

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
    if (DonPlatinado.ActualState == State.Batendo)
        DonPlatinado.ActualState = State.Andando;
    else if (DonPlatinado.ActualState == State.Andando)
        DonPlatinado.ActualState = State.Batendo;
};

Application.Run(form);

