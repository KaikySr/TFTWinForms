using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
public static class Front
{
    public static List<Rectangle> Slots { get; private set; } = new List<Rectangle>();
    public static List<Rectangle> Bancos { get; private set; } = new List<Rectangle>();
    private static int bancoSize = 0;
    public static bool locked = false;

    private static bool updateMouseDown = false;
    public static void Desenhar(Bitmap bmp, Graphics g, Point cursor, bool isDown, int gold, int goldEnemy, List<Campeao> campeoes)
    {
        #region Canetas
        Pen canetaPreta = new Pen(Brushes.Black, 5f);
        Pen canetaDourada = new Pen(Brushes.DarkGoldenrod, 5f);
        Pen canetaVermelha = new Pen(Brushes.Red, 5f);
        Pen canetaBranca = new Pen(Brushes.WhiteSmoke, 5f);
        #endregion

        #region Pinceis
        SolidBrush fundoShop = new SolidBrush(Color.FromArgb(41, 41, 41));
        Brush fundoAzul = Brushes.DarkBlue;
        Brush rollBrush = Brushes.DarkGoldenrod;
        Brush noGold = Brushes.Gray;
        Brush raridadeComum = Brushes.Gray;
        Brush raridadeRara = Brushes.Green;
        Brush raridadeEpica = Brushes.Violet;
        Brush raridadeLendaria = Brushes.Yellow;
        
        //  Brush GradientBotoes = new LinearGradientBrush(
        //     new Point(5, alturaMolduraMarrom + 25),
        //     new Point(5 + larguraBotao * 4, alturaMolduraMarrom + 25 + alturaBotao),
        //     Color.FromArgb(255,42,72,88),  
        //     Color.FromArgb(255,8,159,143));
        #endregion

        #region Imagens
        Bitmap lockCloseImg = new Bitmap("assets/imgs/lockClose.png");
        Bitmap lockOpenImg = new Bitmap("assets/imgs/lockOpen.png");
        #endregion

        #region Variaveis para tamanhos e posicionamentos
        int linha = 10;

        int larguraArena = (int)(0.700f * bmp.Width) - 3;
        int alturaArena = (int)(0.795f * bmp. Height);

        int larguraRound = ((bmp.Width - larguraArena) / 2) - 25;
        int alturaRound = (int)(0.150 * bmp. Height);

        int larguraMyGold = (int)(0.030 * bmp. Width);
        int alturaMyGold = alturaArena / 2;

        int larguraMyChamps = larguraArena;
        int alturaMyChamps = (int)(0.100 * bmp. Height);

        int larguraMyChampsSlot = (larguraMyChamps/9);

        int larguraShop = larguraArena;
        int alturaShop = (int)(0.180f * bmp.Height);

        int larguraSlot = (larguraShop - 4 - linha) / 6;
        int alturaSlot = alturaShop - linha;

        int larguraExpAndRoll = larguraSlot - 10;
        int alturaExpAndRoll = (alturaSlot / 2) - 10;

        int larguraStats = larguraSlot;
        int alturaStats = alturaSlot;

        int larguraLockShop = larguraStats / 3;
        int alturaLockShop = alturaStats / 3;

        int larguraTimer = larguraRound;
        int alturaTimer = (int)(0.015 * bmp. Height);

        int larguraComps = (bmp.Width - larguraArena - (larguraMyGold * 3)) / 2;
        int alturaComps = alturaMyGold - ((alturaMyGold/5) * 2);

        int larguraBuffs = (int)(0.010 * bmp. Width);
        int alturaBuffs = (((alturaComps/3) - 15) / 2) / 2;


        int point0LargArena = (bmp.Width - larguraArena) / 2;
        int point0AltArena = (int)(0.010 * bmp.Height);

        int point0LargMyGold = point0LargArena - larguraMyGold;
        int point0AltMyGold = (alturaArena - alturaMyGold) / 2;
        
        int point0LargShop = (bmp.Width - larguraShop) / 2;
        int point0AltShop =  bmp.Height - alturaShop - 3;

        int point0LargMyChamps = point0LargShop;
        int point0AltMyChamps = point0AltArena + alturaArena - alturaMyChamps;

        int point0LargRound = point0LargArena + larguraArena + 15;
        int point0AltRound = point0AltArena;

        int point0LargComps = 5;
        int point0AltComps = point0AltMyGold + (alturaMyGold/5) + 5;
        #endregion

        #region Molduras
        
        Rectangle arena = new Rectangle(point0LargArena, point0AltArena, larguraArena, alturaArena);

        Rectangle comps = new Rectangle(point0LargComps, point0AltComps, larguraComps, alturaComps);

        Rectangle devs = new Rectangle(point0LargComps, point0AltComps, larguraComps, (alturaComps/3) - 15);
        Rectangle devsQnt = new Rectangle(point0LargComps, point0AltComps, larguraComps/3,(alturaComps/3) - 15);
        Rectangle devsNome = new Rectangle((point0LargComps + larguraComps/3), point0AltComps, (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle devsBuffs = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle devBuff1 = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle devBuff2 = new Rectangle((point0LargComps + larguraComps/3) + larguraBuffs, (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle devBuff3 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 2), (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle devBuff4 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 3), (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle devBuff5 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 4), (point0AltComps + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);

        Rectangle instrutores = new Rectangle(point0LargComps, point0AltComps + alturaComps/3, larguraComps, (alturaComps/3) - 15);
        Rectangle instrutoresQnt = new Rectangle(point0LargComps, point0AltComps + alturaComps/3, larguraComps/3,(alturaComps/3) - 15);
        Rectangle instrutoresNome = new Rectangle((point0LargComps + larguraComps/3), point0AltComps + alturaComps/3 , (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle instrutoresBuffs = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + alturaComps/3 + ((alturaComps/3) - 15) / 2) + 1, (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle instrutoresBuff1 = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + alturaComps/3 + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle instrutoresBuff2 = new Rectangle((point0LargComps + larguraComps/3) + larguraBuffs, (point0AltComps + alturaComps/3 + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle instrutoresBuff3 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 2), (point0AltComps + alturaComps/3 + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);

        Rectangle mecanicos = new Rectangle(point0LargComps, point0AltComps + ((alturaComps/3) * 2), larguraComps, (alturaComps/3) - 15);
        Rectangle mecanicosQnt = new Rectangle(point0LargComps, point0AltComps + ((alturaComps/3) * 2), larguraComps/3,(alturaComps/3) - 15);
        Rectangle mecanicosNome = new Rectangle((point0LargComps + larguraComps/3), point0AltComps + ((alturaComps/3) * 2), (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle mecanicosBuffs = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, (larguraComps/3) * 2,((alturaComps/3) - 15) / 2);
        Rectangle mecanicosBuff1 = new Rectangle((point0LargComps + larguraComps/3), (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle mecanicosBuff2 = new Rectangle((point0LargComps + larguraComps/3) + larguraBuffs, (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle mecanicosBuff3 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 2), (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle mecanicosBuff4 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 3), (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        Rectangle mecanicosBuff5 = new Rectangle((point0LargComps + larguraComps/3) + (larguraBuffs * 4), (point0AltComps + ((alturaComps/3) * 2) + ((alturaComps/3) - 15) / 2) + 1, larguraBuffs, alturaBuffs);
        

        Rectangle round = new Rectangle(point0LargRound, point0AltRound, larguraRound, alturaRound);
        Rectangle timer = new Rectangle(point0LargRound, point0AltRound + alturaRound + 10, larguraTimer, alturaTimer);

        Rectangle myChamps = new Rectangle(point0LargMyChamps, point0AltMyChamps, larguraMyChamps, alturaMyChamps);
        Rectangle enemyChamps = new Rectangle(point0LargMyChamps, point0AltArena, larguraMyChamps, alturaMyChamps);

        Rectangle myChamp1 = new Rectangle(point0LargMyChamps, point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp2 = new Rectangle(point0LargMyChamps + larguraMyChampsSlot, point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp3 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 2), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp4 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 3), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp5 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 4), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp6 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 5), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp7 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 6), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp8 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 7), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle myChamp9 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 8), point0AltMyChamps, larguraMyChampsSlot,  alturaMyChamps);
        Bancos.Add(myChamp1);
        Bancos.Add(myChamp2);
        Bancos.Add(myChamp3);
        Bancos.Add(myChamp4);
        Bancos.Add(myChamp5);
        Bancos.Add(myChamp6);
        Bancos.Add(myChamp7);
        Bancos.Add(myChamp8);
        Bancos.Add(myChamp9);

        Rectangle enemyChamp1 = new Rectangle(point0LargMyChamps, point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp2 = new Rectangle(point0LargMyChamps + larguraMyChampsSlot, point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp3 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 2), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp4 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 3), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp5 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 4), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp6 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 5), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp7 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 6), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp8 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 7), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);
        Rectangle enemyChamp9 = new Rectangle(point0LargMyChamps + (larguraMyChampsSlot * 8), point0AltArena, larguraMyChampsSlot,  alturaMyChamps);


        Rectangle myGold = new Rectangle(point0LargMyGold, point0AltMyGold, larguraMyGold, alturaMyGold - 4);
        Rectangle enemyGold = new Rectangle(point0LargArena + larguraArena, (alturaArena - alturaMyGold) / 2, larguraMyGold, alturaMyGold - 4);

        Rectangle myGold1 = new Rectangle(point0LargMyGold, point0AltMyGold , larguraMyGold, (alturaMyGold / 5));
        Rectangle myGold2 = new Rectangle(point0LargMyGold, point0AltMyGold + (alturaMyGold / 5), larguraMyGold, (alturaMyGold / 5));
        Rectangle myGold3 = new Rectangle(point0LargMyGold, point0AltMyGold + (alturaMyGold / 5) * 2, larguraMyGold, (alturaMyGold / 5));
        Rectangle myGold4 = new Rectangle(point0LargMyGold, point0AltMyGold + (alturaMyGold / 5) * 3, larguraMyGold, (alturaMyGold / 5));
        Rectangle myGold5 = new Rectangle(point0LargMyGold, point0AltMyGold + (alturaMyGold / 5) * 4, larguraMyGold, (alturaMyGold / 5));

        Rectangle enemyGold1 = new Rectangle(point0LargArena + larguraArena, point0AltMyGold , larguraMyGold, (alturaMyGold / 5));
        Rectangle enemyGold2 = new Rectangle(point0LargArena + larguraArena, point0AltMyGold + (alturaMyGold / 5), larguraMyGold, (alturaMyGold / 5));
        Rectangle enemyGold3 = new Rectangle(point0LargArena + larguraArena, point0AltMyGold + (alturaMyGold / 5) * 2, larguraMyGold, (alturaMyGold / 5));
        Rectangle enemyGold4 = new Rectangle(point0LargArena + larguraArena, point0AltMyGold + (alturaMyGold / 5) * 3, larguraMyGold, (alturaMyGold / 5));
        Rectangle enemyGold5 = new Rectangle(point0LargArena + larguraArena, point0AltMyGold + (alturaMyGold / 5) * 4, larguraMyGold, (alturaMyGold / 5));


        Rectangle shop = new Rectangle(point0LargShop, point0AltShop, larguraShop, alturaShop);
        
        Rectangle levelAndRoll = new Rectangle(point0LargShop, point0AltShop, larguraSlot + linha + 5, alturaSlot);
        Rectangle levelAndRollEdge = new Rectangle(point0LargShop + 5, point0AltShop + 5, larguraSlot, alturaSlot);

        Rectangle buyExp = new Rectangle(point0LargShop + linha, point0AltShop + linha, larguraExpAndRoll, alturaExpAndRoll);
        Rectangle roll = new Rectangle(point0LargShop + linha, point0AltShop + alturaExpAndRoll + 20, larguraExpAndRoll, alturaExpAndRoll);

        Rectangle slot1Total = new Rectangle(point0LargShop + larguraSlot + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot2Total  = new Rectangle(point0LargShop + (larguraSlot * 2) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot3Total  = new Rectangle(point0LargShop + (larguraSlot * 3) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot4Total  = new Rectangle(point0LargShop + (larguraSlot * 4) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot5Total  = new Rectangle(point0LargShop + (larguraSlot * 5) + linha, point0AltShop + 5, larguraSlot, alturaSlot);


        Rectangle statsArea = new Rectangle(point0LargShop - larguraStats, point0AltShop, larguraStats, alturaStats);
        Rectangle stats = new Rectangle(point0LargShop - larguraStats + 5, point0AltShop + 5, larguraStats - linha, alturaStats - linha);
        Rectangle statsLvl = new Rectangle(point0LargShop - larguraStats + 5,point0AltShop + 5, larguraStats - linha,(alturaStats - linha)/3);
        Rectangle statsLvlPreencher = new Rectangle(point0LargShop - larguraStats + 5 + 5,point0AltShop + 5 + 5, larguraStats - linha - 10,((alturaStats - linha)/3)-10);
        Rectangle statsLvlProgress = new Rectangle(point0LargShop - larguraStats + 5,point0AltShop + 5 + (alturaStats - linha)/3,larguraStats - linha,(alturaStats - linha)/3);
        Rectangle progress = new Rectangle(point0LargShop - larguraStats + 15,point0AltShop + 5 + (alturaStats - linha)/3,larguraStats - linha - 20,((alturaStats - linha)/3)/3);
        Rectangle statsGold = new Rectangle(point0LargShop - larguraStats + 5,point0AltShop + 5 + (((alturaStats - linha)/3)*2),larguraStats - linha,(alturaStats - linha)/3);
        Rectangle statsGoldPreencher = new Rectangle(point0LargShop - larguraStats + 5 + 5,point0AltShop + 5 + (((alturaStats - linha)/3)*2) + 5,larguraStats - linha - 10,((alturaStats - linha)/3) - 10);


        Rectangle lockShopArea = new Rectangle(point0LargShop + larguraShop, point0AltShop, larguraLockShop, alturaLockShop);
        Rectangle lockShop = new Rectangle(point0LargShop + larguraShop + 5, point0AltShop + 5, larguraLockShop - linha, alturaLockShop - linha);
        #endregion
        
        #region Preencher
        
        Rectangle expPreencher = new Rectangle(point0LargShop + linha + 3, point0AltShop + linha + 3,  larguraExpAndRoll - 5, alturaExpAndRoll - 5);
        Rectangle rollPreencher = new Rectangle(point0LargShop + linha + 3, point0AltShop + alturaExpAndRoll + 23, larguraExpAndRoll - 5, alturaExpAndRoll - 5);
        
        Rectangle myGold1Preencher = new Rectangle(point0LargMyGold + 5, point0AltMyGold +  5,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle myGold2Preencher = new Rectangle(point0LargMyGold + 5, point0AltMyGold + (alturaMyGold / 5) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle myGold3Preencher = new Rectangle(point0LargMyGold + 5, point0AltMyGold + ((alturaMyGold / 5) * 2) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle myGold4Preencher = new Rectangle(point0LargMyGold + 5, point0AltMyGold + ((alturaMyGold / 5) * 3) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle myGold5Preencher = new Rectangle(point0LargMyGold + 5, point0AltMyGold + ((alturaMyGold / 5) * 4) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);

        Rectangle enemyGold1Preencher = new Rectangle(point0LargArena + larguraArena + + 5, point0AltMyGold +  5,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle enemyGold2Preencher = new Rectangle(point0LargArena + larguraArena + 5, point0AltMyGold + (alturaMyGold / 5) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle enemyGold3Preencher = new Rectangle(point0LargArena + larguraArena + 5, point0AltMyGold + ((alturaMyGold / 5) * 2) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle enemyGold4Preencher = new Rectangle(point0LargArena + larguraArena + 5, point0AltMyGold + ((alturaMyGold / 5) * 3) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);
        Rectangle enemyGold5Preencher = new Rectangle(point0LargArena + larguraArena + 5, point0AltMyGold + ((alturaMyGold / 5) * 4) + 5 ,larguraMyGold - 10, (alturaMyGold / 5) - 10);

        Rectangle slot1 = new Rectangle(point0LargShop + larguraSlot + (linha * 2), point0AltShop + 5 + linha, larguraSlot - (linha * 2), alturaSlot - (linha * 2));
        Rectangle slot2 = new Rectangle(point0LargShop + (larguraSlot * 2) + (linha * 2), point0AltShop + 5 + linha, larguraSlot - (linha * 2), alturaSlot - (linha * 2));
        Rectangle slot3 = new Rectangle(point0LargShop + (larguraSlot * 3) + (linha * 2), point0AltShop + 5 + linha, larguraSlot - (linha * 2), alturaSlot - (linha * 2));
        Rectangle slot4 = new Rectangle(point0LargShop + (larguraSlot * 4) + (linha * 2), point0AltShop + 5 + linha, larguraSlot - (linha * 2), alturaSlot - (linha * 2));
        Rectangle slot5 = new Rectangle(point0LargShop + (larguraSlot * 5) + (linha * 2), point0AltShop + 5 + linha, larguraSlot - (linha * 2), alturaSlot - (linha * 2));
        Slots.Add(slot1);
        Slots.Add(slot2);
        Slots.Add(slot3);
        Slots.Add(slot4);                                                           
        Slots.Add(slot5);

        // Rectangle info1 = new Rectangle(point0LargShop + larguraSlot + (linha * 2),((point0AltShop + 5 + linha) + alturaSlot - (linha * 2)) - (alturaSlot - (linha * 2))/5, larguraSlot - (linha * 2), (alturaSlot - (linha * 2))/5);
        // Rectangle info2 = new Rectangle(point0LargShop + (larguraSlot * 2) + (linha * 2),(point0AltShop + 5 + linha) + alturaSlot - (linha * 2) - (alturaSlot - (linha * 2))/5, larguraSlot - (linha * 2), (alturaSlot - (linha * 2))/5);
        // Rectangle info3 = new Rectangle(point0LargShop + (larguraSlot * 3) + (linha * 2),(point0AltShop + 5 + linha) + alturaSlot - (linha * 2) - (alturaSlot - (linha * 2))/5, larguraSlot - (linha * 2), (alturaSlot - (linha * 2))/5);
        // Rectangle info4 = new Rectangle(point0LargShop + (larguraSlot * 4) + (linha * 2),(point0AltShop + 5 + linha) + alturaSlot - (linha * 2) - (alturaSlot - (linha * 2))/5, larguraSlot - (linha * 2), (alturaSlot - (linha * 2))/5);
        // Rectangle info5 = new Rectangle(point0LargShop + (larguraSlot * 5) + (linha * 2),(point0AltShop + 5 + linha) + alturaSlot - (linha * 2) - (alturaSlot - (linha * 2))/5, larguraSlot - (linha * 2), (alturaSlot - (linha * 2))/5);
        #endregion
       
        #region Escritas
        
        SolidBrush letraBranca = new SolidBrush(Color.White);
        SolidBrush letraPreta = new SolidBrush(Color.Black);

        StringFormat formatCenter = new StringFormat();
        formatCenter.Alignment = StringAlignment.Center;
        formatCenter.LineAlignment = StringAlignment.Center;

        StringFormat formatCenterTop = new StringFormat();
        formatCenterTop.Alignment = StringAlignment.Center;
        formatCenterTop.LineAlignment = StringAlignment.Near;

        StringFormat formatLeftDown = new StringFormat();
        formatLeftDown.Alignment = StringAlignment.Near;
        formatLeftDown.LineAlignment = StringAlignment.Far;

        StringFormat formatLeftCenter = new StringFormat();
        formatLeftCenter.Alignment = StringAlignment.Near;
        formatLeftCenter.LineAlignment = StringAlignment.Center;

        StringFormat formatRigthCenter = new StringFormat();
        formatRigthCenter.Alignment = StringAlignment.Far;
        formatRigthCenter.LineAlignment = StringAlignment.Center;

        StringFormat formatLeftTop = new StringFormat();
        formatLeftTop.Alignment = StringAlignment.Near;
        formatLeftTop.LineAlignment = StringAlignment.Near;

        String expText = "Comprar EXP 4";
        String rollText = "Atualizar 2";
        Font fontExpAndRoll = new Font("Arial", (int)(0.250 * alturaExpAndRoll));

        String devsQntTxt = "2";
        String devsNomeTxt = "Desenvolvedores";
        String devsBuffsTxt1 = "2";
        String devsBuffsTxt2 = "-";
        String devsBuffsTxt3 = "4";
        String devsBuffsTxt4 = "-";
        String devsBuffsTxt5 = "5";


        String instrutoresQntTxt = "3";
        String instrutoresNomeTxt = "Instrutores";
        String instrutoresBuffsTxt1 = "3";
        String instrutoresBuffsTxt2 = "-";
        String instrutoresBuffsTxt3 = "5";

        String mecanicosQntTxt = "1";
        String mecanicosNomeTxt = "Mecanicos";
        String mecanicosBuffsTxt1 = "1";
        String mecanicosBuffsTxt2 = "-";
        String mecanicosBuffsTxt3 = "2";
        String mecanicosBuffsTxt4 = "-";
        String mecanicosBuffsTxt5 = "3";

        String statsNv = "Nv. 6";
        String statsNvProgress = "6/30";
        String statsGd = $"Gold: {Convert.ToString(gold)}";
        

        Font fontQnt = new Font("Arial", (int)(0.300 * ((alturaComps/3) - 15)));
        Font fontNomeAndBuffs = new Font("Arial", ((int)(0.350 * ((alturaComps/3) - 15)) / 2));
        Font fontStats = new Font("Arial", ((int)(0.350 * alturaStats/3)));
        Font fontStatsProgress = new Font("Arial", ((int)(0.250 * alturaStats/3)));
        #endregion

        #region Layout

        if (lockShop.Contains(cursor) && isDown == true)
            updateMouseDown = true;
        
        if (lockShop.Contains(cursor) && !isDown && updateMouseDown)
        {
            updateMouseDown = false;
            locked = !locked;
        }
        
        if (locked)
            g.DrawImage(lockCloseImg, lockShop);
        else
            g.DrawImage(lockOpenImg, lockShop);

        
        g.DrawRectangle(canetaPreta, arena);

        g.FillRectangle(fundoShop, devs);
        g.DrawRectangle(canetaPreta, devs);
        g.DrawString(devsQntTxt, fontQnt, letraBranca, devsQnt, formatCenter);
        g.DrawString(devsNomeTxt, fontNomeAndBuffs, letraBranca, devsNome, formatLeftDown);
        g.DrawString(devsBuffsTxt1, fontNomeAndBuffs, letraBranca, devBuff1, formatLeftCenter);
        g.DrawString(devsBuffsTxt2, fontNomeAndBuffs, letraBranca, devBuff2, formatLeftCenter);
        g.DrawString(devsBuffsTxt3, fontNomeAndBuffs, letraBranca, devBuff3, formatLeftCenter);
        g.DrawString(devsBuffsTxt4, fontNomeAndBuffs, letraBranca, devBuff4, formatLeftCenter);
        g.DrawString(devsBuffsTxt5, fontNomeAndBuffs, letraBranca, devBuff5, formatLeftCenter);

        g.FillRectangle(fundoShop, instrutores);
        g.DrawRectangle(canetaPreta, instrutores);
        g.DrawString(instrutoresQntTxt, fontQnt, letraBranca, instrutoresQnt, formatCenter);
        g.DrawString(instrutoresNomeTxt, fontNomeAndBuffs, letraBranca, instrutoresNome, formatLeftDown);
        g.DrawString(instrutoresBuffsTxt1, fontNomeAndBuffs, letraBranca, instrutoresBuff1, formatLeftCenter);
        g.DrawString(instrutoresBuffsTxt2, fontNomeAndBuffs, letraBranca, instrutoresBuff2, formatLeftCenter);
        g.DrawString(instrutoresBuffsTxt3, fontNomeAndBuffs, letraBranca, instrutoresBuff3, formatLeftCenter);

        g.FillRectangle(fundoShop, mecanicos);
        g.DrawRectangle(canetaPreta, mecanicos);
        g.DrawString(mecanicosQntTxt, fontQnt, letraBranca, mecanicosQnt, formatCenter);
        g.DrawString(mecanicosNomeTxt, fontNomeAndBuffs, letraBranca, mecanicosNome, formatLeftDown);
        g.DrawString(mecanicosBuffsTxt1, fontNomeAndBuffs, letraBranca, mecanicosBuff1, formatLeftCenter);
        g.DrawString(mecanicosBuffsTxt2, fontNomeAndBuffs, letraBranca, mecanicosBuff2, formatLeftCenter);
        g.DrawString(mecanicosBuffsTxt3, fontNomeAndBuffs, letraBranca, mecanicosBuff3, formatLeftCenter);
        g.DrawString(mecanicosBuffsTxt4, fontNomeAndBuffs, letraBranca, mecanicosBuff4, formatLeftCenter);
        g.DrawString(mecanicosBuffsTxt5, fontNomeAndBuffs, letraBranca, mecanicosBuff5, formatLeftCenter);
  
        g.DrawRectangle(canetaPreta, round);

        g.FillRectangle(fundoAzul, timer);
        g.DrawRectangle(canetaPreta, timer);

        g.DrawRectangle(canetaPreta, myChamps);
        g.DrawRectangle(canetaPreta, enemyChamps);

        g.DrawRectangle(canetaPreta, myChamp1);
        g.DrawRectangle(canetaPreta, myChamp2);
        g.DrawRectangle(canetaPreta, myChamp3);
        g.DrawRectangle(canetaPreta, myChamp4);
        g.DrawRectangle(canetaPreta, myChamp5);
        g.DrawRectangle(canetaPreta, myChamp6);
        g.DrawRectangle(canetaPreta, myChamp7);
        g.DrawRectangle(canetaPreta, myChamp8);
        g.DrawRectangle(canetaPreta, myChamp9);

        g.DrawRectangle(canetaPreta, enemyChamp1);
        g.DrawRectangle(canetaPreta, enemyChamp2);
        g.DrawRectangle(canetaPreta, enemyChamp3);
        g.DrawRectangle(canetaPreta, enemyChamp4);
        g.DrawRectangle(canetaPreta, enemyChamp5);
        g.DrawRectangle(canetaPreta, enemyChamp6);
        g.DrawRectangle(canetaPreta, enemyChamp7);
        g.DrawRectangle(canetaPreta, enemyChamp8);
        g.DrawRectangle(canetaPreta, enemyChamp9);

        g.DrawRectangle(canetaPreta, myGold);
        g.DrawRectangle(canetaPreta, myGold1);
        g.DrawRectangle(canetaPreta, myGold2);
        g.DrawRectangle(canetaPreta, myGold3);
        g.DrawRectangle(canetaPreta, myGold4);
        g.DrawRectangle(canetaPreta, myGold5);

        if (gold >= 10 && gold < 20)
            g.DrawRectangle(canetaDourada, myGold5Preencher);
        else if (gold >= 20 && gold < 30)
        {
            g.DrawRectangle(canetaDourada, myGold5Preencher);
            g.DrawRectangle(canetaDourada, myGold4Preencher);
        }
        else if (gold >= 30 && gold < 40)
        {
            g.DrawRectangle(canetaDourada, myGold5Preencher);
            g.DrawRectangle(canetaDourada, myGold4Preencher);
            g.DrawRectangle(canetaDourada, myGold3Preencher);
        }
        else if (gold >= 40 && gold < 50)
        {
            g.DrawRectangle(canetaDourada, myGold5Preencher);
            g.DrawRectangle(canetaDourada, myGold4Preencher);
            g.DrawRectangle(canetaDourada, myGold3Preencher);
            g.DrawRectangle(canetaDourada, myGold2Preencher);
        }
        else if (gold >= 50)
        {   
            g.DrawRectangle(canetaDourada, myGold5Preencher);
            g.DrawRectangle(canetaDourada, myGold4Preencher);
            g.DrawRectangle(canetaDourada, myGold3Preencher);
            g.DrawRectangle(canetaDourada, myGold2Preencher);
            g.DrawRectangle(canetaDourada, myGold1Preencher);
        }
        
        g.DrawRectangle(canetaPreta, enemyGold);
        g.DrawRectangle(canetaPreta, enemyGold1);
        g.DrawRectangle(canetaPreta, enemyGold2);
        g.DrawRectangle(canetaPreta, enemyGold3);
        g.DrawRectangle(canetaPreta, enemyGold4);
        g.DrawRectangle(canetaPreta, enemyGold5);

        if (goldEnemy >= 10 && goldEnemy < 20)
            g.DrawRectangle(canetaDourada, enemyGold1Preencher);
        else if (goldEnemy >= 20 && goldEnemy < 30)
        {
            g.DrawRectangle(canetaDourada, enemyGold1Preencher);
            g.DrawRectangle(canetaDourada, enemyGold2Preencher);
        }
        else if (goldEnemy >= 30 && goldEnemy < 40)
        {
            g.DrawRectangle(canetaDourada, enemyGold1Preencher);
            g.DrawRectangle(canetaDourada, enemyGold2Preencher);
            g.DrawRectangle(canetaDourada, enemyGold3Preencher);
        }
        else if (goldEnemy >= 40 && goldEnemy < 50)
        {
            g.DrawRectangle(canetaDourada, enemyGold1Preencher);
            g.DrawRectangle(canetaDourada, enemyGold2Preencher);
            g.DrawRectangle(canetaDourada, enemyGold3Preencher);
            g.DrawRectangle(canetaDourada, enemyGold4Preencher);
        }
        else if (goldEnemy >= 50)
        {   
            g.DrawRectangle(canetaDourada, enemyGold1Preencher);
            g.DrawRectangle(canetaDourada, enemyGold2Preencher);
            g.DrawRectangle(canetaDourada, enemyGold3Preencher);
            g.DrawRectangle(canetaDourada, enemyGold4Preencher);
            g.DrawRectangle(canetaDourada, enemyGold5Preencher);
        }

        g.FillRectangle(fundoShop, shop);

        g.DrawRectangle(canetaPreta, levelAndRollEdge);

        if (gold >= 4)
            g.FillRectangle(fundoAzul, buyExp);
        else 
            g.FillRectangle(noGold, buyExp);
        
        if (gold >= 2)
            g.FillRectangle(rollBrush, roll);
        else
            g.FillRectangle(noGold, roll);

        g.DrawRectangle(canetaBranca, buyExp);
        g.DrawRectangle(canetaBranca, roll);

        g.DrawString(expText, fontExpAndRoll, letraBranca, expPreencher, formatCenter);
        g.DrawString(rollText, fontExpAndRoll, letraBranca, rollPreencher, formatCenter);


        g.DrawRectangle(canetaDourada, statsArea);
        g.DrawString(statsNv, fontStats, letraPreta, statsLvlPreencher, formatLeftCenter);
        g.DrawString(statsNvProgress, fontStatsProgress, letraPreta, statsLvlPreencher, formatRigthCenter);
        g.DrawRectangle(canetaPreta, progress);
        g.DrawString(statsGd, fontStats, letraPreta, statsGoldPreencher, formatLeftTop);
        g.DrawRectangle(canetaPreta, stats);

        g.DrawRectangle(canetaDourada, lockShopArea);
        g.DrawRectangle(canetaPreta, lockShop);

        g.DrawRectangle(canetaDourada, shop);
        #endregion

        if (roll.Contains(cursor) && isDown)
            updateMouseDown = true;
        
        if (roll.Contains(cursor) && !isDown && updateMouseDown)
        {
            updateMouseDown = false;
            OnRoll();
        }


        for (int i = 0; i < Slots.Count; i++)
        {
            if (Slots[i].Contains(cursor) && isDown)
                updateMouseDown = true;
        
            if (Slots[i].Contains(cursor) && !isDown && updateMouseDown)
            {
                updateMouseDown = false;
                comprar(i);
            }
        }
      
        void comprar(int i)
        {
            for (int j = 0; j < campeoes.Count; j++)
            {
                var champ = campeoes[j];
                if (champ.ActualSlot.Contains(Slots[i]))
                {
                    champ.ActualSlot.Clear();

                    var copy = champ.Clone();
                    copy.ActualBanco.Add(Bancos[bancoSize++]);
                    campeoes.Add(copy);
                    copy.ActualState = State.Banco;
                    return;
                }
            }
        }
    }

    public static event Action OnRoll;
    
}