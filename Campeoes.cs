public class Campeao
{
    public TimeSpan AnimationSpeed { get; set; } = TimeSpan.FromMilliseconds(200);
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
    private Rectangle actualFrame;
    public State ActualState { get; set; } = State.Andando;
    private int index;

    public Campeao(string name, int value, string raridade, int life, int attackDamage, int attackSpeed, Classes[] classe, string path)
    {
        Name = name;
        Value = value;
        Raridade = raridade;
        Life = life;
        AttackDamage = attackDamage;
        AttackSpeed = attackSpeed;
        Classe = classe;

        this.Sprites = new Bitmap(path);
        this.Position = new Point(0, 0);

        setFrames();
    }

    private DateTime start = DateTime.Now;
    public void Update()
    {
        // Handle frames
        var time = DateTime.Now - start;
        var index = (int)(time / AnimationSpeed) % srcRect[ActualState].Count;
        actualFrame = srcRect[ActualState][index];
        // Handle frames
    }

    public void Draw(Graphics g)
    {
        g.DrawImage
        (
            Sprites,
            new Rectangle(500, 500, 200, 200),
            actualFrame,
            GraphicsUnit.Pixel
        );
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
    Batendo
}