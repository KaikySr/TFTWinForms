using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

int gold = 43;
int enemyGold = 22;

#region campeoes
Campeao DonPlatinado = new Campeao
(
    "assets/imgs/donplatinado.jpg",
    "Don Platinado",
    5,
    "Lendario",
    2000, 
    100, 
    4, 
    new Classes[]{Classes.Desenvolvedores, Classes.Instrutores, Classes.Mecanicos},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Trevisan = new Campeao
(
    "assets/imgs/trevisan.jpg",
    "Trevisan",
    4,
    "Epico",
    1500, 
    80, 
    4, 
    new Classes[]{Classes.Desenvolvedores, Classes.Instrutores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Andressa = new Campeao
(
    "assets/imgs/andressa.jpg",
    "Andressa",
    4,
    "Epico",
    1700, 
    80, 
    3, 
    new Classes[]{Classes.Desenvolvedores, Classes.Mecanicos},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Thigas = new Campeao
(
    "assets/imgs/thiago.jpg",
    "Thigas",
    2,
    "Raro",
    1200, 
    60, 
    2, 
    new Classes[]{Classes.Desenvolvedores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Kaiky = new Campeao
(
    "assets/imgs/kaiky.jpg",
    "Kaiky",
    1,
    "Comum",
    1000, 
    50, 
    2, 
    new Classes[]{Classes.Desenvolvedores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Queila = new Campeao
(
    "assets/imgs/queila.jpg",
    "Queila",
    2,
    "Raro",
    1200, 
    40, 
    3, 
    new Classes[]{Classes.Instrutores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Luis = new Campeao
(
    "assets/imgs/luis.jpg",
    "Luis",
    1,
    "Comum",
    1000, 
    30, 
    3, 
    new Classes[]{Classes.Instrutores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Alisson = new Campeao
(
    "assets/imgs/alisson.jpg",
    "Alisson",
    1,
    "Comum",
    1000, 
    30, 
    3, 
    new Classes[]{Classes.Instrutores},
    "assets/imgs/x.png",
    Front.Slots
);

Campeao Fabio = new Campeao
(
    "assets/imgs/fabio.jpg",
    "Fabio",
    1,
    "Comum",
    1200, 
    30, 
    2, 
    new Classes[]{Classes.Mecanicos},

    "assets/imgs/x.png",
    Front.Slots
);
#endregion

List<Campeao> campeaos = new List<Campeao>();
campeaos.Add(DonPlatinado);
campeaos.Add(Trevisan);
campeaos.Add(Andressa);
campeaos.Add(Thigas);
campeaos.Add(Kaiky);
campeaos.Add(Queila);
campeaos.Add(Luis);
campeaos.Add(Alisson);
campeaos.Add(Fabio);

ApplicationConfiguration.Initialize();
Application.EnableVisualStyles();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

Bitmap bmp = null;
Graphics g = null; 
Point cursor = Point.Empty;
bool isDown = false;
bool clicked = false;

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

form.Click += (o, e) =>
{
    if ()
};

form.Load += (o, e) =>
{
    bmp = new Bitmap(pb.Width, pb.Height);
    pb.Image = bmp;
    g = Graphics.FromImage(bmp);
    tm.Start();

    // DonPlatinado.ActualSlot = DonPlatinado.Slots[0];
    // Kaiky.ActualSlot = Kaiky.Slots[1];
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

    DonPlatinado.ActualSlot = DonPlatinado.Slots[0];
    Kaiky.ActualSlot = Kaiky.Slots[1];
    Trevisan.ActualSlot = Trevisan.Slots[2];
    Thigas.ActualSlot = Thigas.Slots[3];
    Alisson.ActualSlot = Alisson.Slots[4];

    DonPlatinado.ActualState = State.Shop;
    Kaiky.ActualState = State.Shop;
    Trevisan.ActualState = State.Shop;
    Thigas.ActualState = State.Shop;
    Alisson.ActualState = State.Shop;
   
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

