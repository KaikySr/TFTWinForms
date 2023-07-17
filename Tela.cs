using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
public static class Front
{
    public static void Desenhar(Bitmap bmp, Graphics g, Point cursor, bool isDown)
    {
       
        //Canetas
        Pen canetaPreta = new Pen(Brushes.Black, 10f);
        Pen canetaDourada = new Pen(Brushes.DarkGoldenrod, 10f);
        Pen canetaVermelha = new Pen(Brushes.Red, 5f);
        Pen canetaBranca = new Pen(Brushes.WhiteSmoke, 5f);
        //Pinceis
        SolidBrush fundoShop = new SolidBrush(Color.FromArgb(41, 41, 41));
   
        //Variaveis para tamanhos e posicionamentos
        int linha = 10;

        int maxLargTela = bmp.Width;
        int maxAltTela = bmp.Height;

        int larguraShop = (int)(0.800 * bmp.Width);
        int alturaShop = (int)(0.200f * bmp.Height);

        int point0LargShop = (bmp.Width - larguraShop - linha) / 2;
        int point0AltShop =  bmp.Height - alturaShop - linha;

        int larguraSlot = (larguraShop - 5 - linha) / 6;
        int alturaSlot = alturaShop - (linha * 2);

        int point0AltLevelAndRoll = bmp.Height - (linha * 2) - alturaSlot - (alturaSlot / 3);

        int larguraExpAndRoll = larguraSlot - 10;
        int alturaExpAndRoll = (alturaSlot / 2) - 10;



         
        //Molduras 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Rectangle borda = new Rectangle(0, 0, bmp.Width, bmp.Height);

        Rectangle shop = new Rectangle(point0LargShop, point0AltShop, larguraShop, alturaShop);
        
        Rectangle levelAndRoll = new Rectangle(point0LargShop, point0AltLevelAndRoll, larguraSlot + linha, alturaSlot + (alturaSlot / 3));
        Rectangle buyExp = new Rectangle(point0LargShop + linha, point0AltShop + linha, larguraExpAndRoll, alturaExpAndRoll);
        Rectangle roll = new Rectangle(point0LargShop + linha, bmp.Height - alturaExpAndRoll - (linha * 2), larguraExpAndRoll, alturaExpAndRoll);

        Rectangle slot1 = new Rectangle(point0LargShop + larguraSlot + linha, point0AltShop + linha, larguraSlot, alturaSlot);
        Rectangle slot2 = new Rectangle(point0LargShop + (larguraSlot * 2) + linha, point0AltShop + linha, larguraSlot, alturaSlot);
        Rectangle slot3 = new Rectangle(point0LargShop + (larguraSlot * 3) + linha, point0AltShop + linha, larguraSlot, alturaSlot);
        Rectangle slot4 = new Rectangle(point0LargShop + (larguraSlot * 4) + linha, point0AltShop + linha, larguraSlot, alturaSlot);
        Rectangle slot5 = new Rectangle(point0LargShop + (larguraSlot * 5) + linha, point0AltShop + linha, larguraSlot, alturaSlot);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Exemplo Preencher
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Rectangle ShopPreencher = new Rectangle(point0LargShop + 5, point0AltShop + 5, larguraShop - 8, alturaShop - linha);
        Rectangle levelAndRollPreencher = new Rectangle(point0LargShop + 5, point0AltLevelAndRoll + 5, larguraSlot, alturaSlot + (alturaSlot / 3) - 5);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        
        //Exemplos Decoração Extras//
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Rectangle Gradient = new Rectangle(5, alturaMolduraMarrom + 25, larguraBotao * 4, alturaBotao);
        // Brush GradientBotoes = new LinearGradientBrush(
        //     new Point(5, alturaMolduraMarrom + 25),
        //     new Point(5 + larguraBotao * 4, alturaMolduraMarrom + 25 + alturaBotao),
        //     Color.FromArgb(255,42,72,88),  
        //     Color.FromArgb(255,8,159,143)); 
        // Brush GradientBotaoTirarFoto = new LinearGradientBrush(
        //     new Point(5, alturaMolduraMarrom + 25),
        //     new Point(5 + larguraBotao * 4, alturaMolduraMarrom + 25 + alturaBotao),
        //     Color.FromArgb(255,8,159,143),
        //     Color.FromArgb(255,42,72,88)); 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //Escritas//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        String textoExemplo = "Exemplo";
        Font fontExemplo = new Font("Arial", (int)(0.100 * bmp.Height));
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        
        //Layout//
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        g.DrawRectangle(canetaPreta, borda);

        g.DrawRectangle(canetaDourada, shop);

        g.DrawRectangle(canetaDourada, levelAndRoll);
        
        g.DrawRectangle(canetaPreta, slot1);
        g.DrawRectangle(canetaPreta, slot2);
        g.DrawRectangle(canetaPreta, slot3);
        g.DrawRectangle(canetaPreta, slot4);
        g.DrawRectangle(canetaPreta, slot5);

        g.FillRectangle(fundoShop, ShopPreencher);
        g.FillRectangle(fundoShop, levelAndRollPreencher);

        g.DrawRectangle(canetaBranca, buyExp);
        g.DrawRectangle(canetaBranca, roll);

        // g.DrawString(textoExemplo, fontExemplo, drawBrush, exemploRetanguloPretoMenor, format);

        //Exemplo para mudar de cor ao clicar/passar o mouse
            // g.DrawRectangle(CanetaPreta, Desfazer);
            // if (PreenchimentoDesfazer.Contains(cursor))
            // {
            //     g.FillRectangle(Brushes.Red, PreenchimentoDesfazer);
            //     if(PreenchimentoDesfazer.Contains(cursor) && isDown == true)
            //         g.FillRectangle(Brushes.DarkRed, PreenchimentoDesfazer);
            // }

    }
}