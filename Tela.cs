using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
public static class Front
{
    public static void Desenhar(Bitmap bmp, Graphics g, Point cursor, bool isDown, int gold, int goldEnemy)
    {
        //Canetas
        Pen canetaPreta = new Pen(Brushes.Black, 5f);
        Pen canetaDourada = new Pen(Brushes.DarkGoldenrod, 5f);
        Pen canetaVermelha = new Pen(Brushes.Red, 5f);
        Pen canetaBranca = new Pen(Brushes.WhiteSmoke, 5f);

        //Pinceis
        SolidBrush fundoShop = new SolidBrush(Color.FromArgb(41, 41, 41));
        Brush expBrush = Brushes.DarkBlue;
        Brush rollBrush = Brushes.DarkGoldenrod;
        Brush noGold = Brushes.Gray;
        
        //  Brush GradientBotoes = new LinearGradientBrush(
        //     new Point(5, alturaMolduraMarrom + 25),
        //     new Point(5 + larguraBotao * 4, alturaMolduraMarrom + 25 + alturaBotao),
        //     Color.FromArgb(255,42,72,88),  
        //     Color.FromArgb(255,8,159,143));

        //Variaveis para tamanhos e posicionamentos
        int linha = 10;

        int larguraArena = (int)(0.700f * bmp.Width) - 3;
        int alturaArena = (int)(0.795f * bmp. Height);

        int larguraMyGold = (int)(0.030 * bmp. Width);
        int alturaMyGold = alturaArena / 2;

        int larguraMyChamps = larguraArena;
        int alturaMyChamps = (int)(0.100 * bmp. Height);

        int larguraMyChampsSlot = (larguraMyChamps/9);

        int point0LargArena = (bmp.Width - larguraArena) / 2;
        int point0AltArena = (int)(0.010 * bmp.Height);


        int point0LargMyGold = point0LargArena - larguraMyGold;
        int point0AltMyGold = (alturaArena - alturaMyGold) / 2;
        

        int larguraShop = larguraArena;
        int alturaShop = (int)(0.180f * bmp.Height);

        int point0LargShop = (bmp.Width - larguraShop) / 2;
        int point0AltShop =  bmp.Height - alturaShop - 3;

        int point0LargMyChamps = point0LargShop;
        int point0AltMyChamps = point0AltArena + alturaArena - alturaMyChamps;

        int larguraSlot = (larguraShop - 4 - linha) / 6;
        int alturaSlot = alturaShop - linha;

        int larguraExpAndRoll = larguraSlot - 10;
        int alturaExpAndRoll = (alturaSlot / 2) - 10;

        int larguraStats = larguraSlot;
        int alturaStats = alturaSlot;

        int larguraLockShop = larguraStats / 3;
        int alturaLockShop = alturaStats / 3;

        //Molduras 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Rectangle arena = new Rectangle(point0LargArena, point0AltArena, larguraArena, alturaArena);

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

        Rectangle slot1 = new Rectangle(point0LargShop + larguraSlot + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot2 = new Rectangle(point0LargShop + (larguraSlot * 2) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot3 = new Rectangle(point0LargShop + (larguraSlot * 3) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot4 = new Rectangle(point0LargShop + (larguraSlot * 4) + linha, point0AltShop + 5, larguraSlot, alturaSlot);
        Rectangle slot5 = new Rectangle(point0LargShop + (larguraSlot * 5) + linha, point0AltShop + 5, larguraSlot, alturaSlot);


        Rectangle statsArea = new Rectangle(point0LargShop - larguraStats, point0AltShop, larguraStats, alturaStats);
        Rectangle stats = new Rectangle(point0LargShop - larguraStats + 5, point0AltShop + 5, larguraStats - linha, alturaStats - linha);

        Rectangle lockShopArea = new Rectangle(point0LargShop + larguraShop, point0AltShop, larguraLockShop, alturaLockShop);
        Rectangle lockShop = new Rectangle(point0LargShop + larguraShop + 5, point0AltShop + 5, larguraLockShop - linha, alturaLockShop - linha);

        //Preencher
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Rectangle ShopPreencher = new Rectangle(point0LargShop , point0AltShop, larguraShop - 2, alturaShop);
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

        //Escritas//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SolidBrush letraBranca = new SolidBrush(Color.White);
        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        String expText = "Comprar EXP 4";
        String rollText = "Atualizar 2";
        Font fontExpAndRoll = new Font("Arial", (int)(0.250 * alturaExpAndRoll));

        //Layout//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        g.DrawRectangle(canetaPreta, arena);

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

        g.FillRectangle(fundoShop, ShopPreencher);

        g.DrawRectangle(canetaPreta, levelAndRollEdge);

        g.DrawRectangle(canetaPreta, slot1);
        g.DrawRectangle(canetaPreta, slot2);
        g.DrawRectangle(canetaPreta, slot3);
        g.DrawRectangle(canetaPreta, slot4);
        g.DrawRectangle(canetaPreta, slot5);

        g.DrawRectangle(canetaBranca, buyExp);
        g.DrawRectangle(canetaBranca, roll);

        if (gold >= 4)
            g.FillRectangle(expBrush, expPreencher);
        else 
            g.FillRectangle(noGold, expPreencher);
        
        if (gold >= 2)
            g.FillRectangle(rollBrush, rollPreencher);
        else
            g.FillRectangle(noGold, rollPreencher);

        g.DrawString(expText, fontExpAndRoll, letraBranca, expPreencher, format);
        g.DrawString(rollText, fontExpAndRoll, letraBranca, rollPreencher, format);

        g.DrawRectangle(canetaDourada, statsArea);
        g.DrawRectangle(canetaPreta, stats);

        g.DrawRectangle(canetaDourada, lockShopArea);
        g.DrawRectangle(canetaPreta, lockShop);

        g.DrawRectangle(canetaDourada, shop);




      

        // Exemplo para mudar de cor ao clicar/passar o mouse
            // g.DrawRectangle(canetaPreta, arena);
            // if (arena.Contains(cursor))
            // {
            //     g.FillRectangle(Brushes.Red, arena);
            //     if(arena.Contains(cursor) && isDown == true)
            //         g.FillRectangle(Brushes.Blue, arena);
            // }

    }
}