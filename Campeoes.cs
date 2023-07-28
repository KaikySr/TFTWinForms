public class Campeao
{
    public TimeSpan AnimationSpeed { get; set; } = TimeSpan.FromMilliseconds(200);
    public List<Rectangle> Slots { get; set; } = new List<Rectangle>();
    public List<Rectangle> Bancos { get; set; } = new List<Rectangle>();
    public Bitmap ShopImage { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public string Raridade { get; set; }
    public int Life { get; set; }
    public int AttackDamage { get; set;}
    public int AttackSpeed { get; set;}
    public Classes[] Classe { get; set; }
    public Point Position { get; set; }
    public Size size { get; set; }
    public Bitmap Sprites { get; set; }
    public Dictionary<State, List<Rectangle>> srcRect { get; set; } = new(); 
    public List<Rectangle> ActualSlot { get; set; } = new List<Rectangle>();
    public List<Rectangle> ActualBanco { get; set; } = new List<Rectangle>();
    private Rectangle actualFrame;
    public State ActualState { get; set; } = State.Andando;
    private string path;

    public Campeao Clone()
    {
        Campeao copy = new Campeao(
            path,
            Name,
            Value,
            Raridade,
            Life,
            AttackDamage,
            AttackSpeed,
            Classe,
            "",
            Slots,
            Bancos
        );
        return copy;
    }

    public Campeao(string pathImg, string name, int value, string raridade, int life, int attackDamage, int attackSpeed, Classes[] classe, string path, List<Rectangle> slots, List<Rectangle> bancos)
    {
        this.path = pathImg;
        ShopImage = new Bitmap(pathImg);
        Name = name;
        Value = value;
        Raridade = raridade;
        Life = life;
        AttackDamage = attackDamage;
        AttackSpeed = attackSpeed;
        Classe = classe;

        // this.Sprites = new Bitmap(path);
        this.Position = new Point(0, 0);
        this.Slots = slots;
        this.Bancos = bancos;

        // setFrames();
    }

    private DateTime start = DateTime.Now;
    
    public void Update()
    {
        // Handle frames
        // var time = DateTime.Now - start;
        // var index = (int)(time / AnimationSpeed) % srcRect[ActualState].Count;
        // actualFrame = srcRect[ActualState][index];
        // Handle frames
    }

    public void Draw(Graphics g)
    {
        if (ActualState == State.Shop)
        {
            foreach (var rect in ActualSlot)
                g.DrawImage(ShopImage, rect, new Rectangle(0, 0, ShopImage.Width, ShopImage.Height), GraphicsUnit.Pixel);
        }
        else if (ActualState == State.Banco)
        {
            foreach (var rect in ActualBanco)
                g.DrawImage(ShopImage, rect, new Rectangle(0, 0, ShopImage.Width, ShopImage.Height), GraphicsUnit.Pixel);
        }
        else
        {
            // foreach (var rect in ActualSlot)
            //     g.DrawImage(Sprites, rect, actualFrame, GraphicsUnit.Pixel);
        }
    }

    void setFrames()
    {
        List<Rectangle> rects = new List<Rectangle>();

        for (int i = 0; i < 7; i++)
        {
            rects.Add
            (
                new Rectangle(0 + ((Sprites.Width / 12) * i), 0, (Sprites.Width / 12), Sprites.Height / 10)
            );
        }
        srcRect.Add
        (
            State.Andando,
            rects
        );

        rects = new List<Rectangle>();

        for (int i = 0; i < 7; i++)
        {
            rects.Add
            (
                new Rectangle(0 + ((Sprites.Width / 12) * i), Sprites.Height / 10, (Sprites.Width / 12), Sprites.Height / 10)
            );
        }
        srcRect.Add
        (
            State.Batendo,
            rects
        );

        srcRect.Add
        (
            State.Banco,
            new List<Rectangle>(){
                new Rectangle(0, 0, 0, 0)
            }
        );

         srcRect.Add
        (
            State.Shop,
            new List<Rectangle>(){
                new Rectangle(0, 0, 0, 0)
            }
        );
    }

}

public enum Classes
{
    Desenvolvedores,
    Instrutores, 
    Mecanicos
}

public enum State
{
    Banco,
    Andando,
    Batendo,
    Shop
}