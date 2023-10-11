class Rectangle
{
    public string id {  get; set; }
    int width;
    int height;
    int x;
    int y;
    public Rectangle(string id, int width, int height, int x, int y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }

    public bool check (Rectangle rectangle)
    {
        bool intersection = false;
        if (x <= rectangle.x + rectangle.width && y <= rectangle.y + rectangle.height && rectangle.x <= x + rectangle.width && rectangle.y <= x + rectangle.height)
        {
            intersection = true;
        }
        return intersection;
    } 
}

class Workspace
{
    static void Main(string[] args)
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            string id = line[0];
            int width = int.Parse(line[1]);
            int height = int.Parse(line[2]);
            int x = int.Parse(line[3]);
            int y = int.Parse(line[4]);
            rectangles.Add(new Rectangle(id, width, height, x, y));
        }
        
        for (int i = 0; i<m; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            int id1 = 0, id2 = 0;
            
            for (int j = 0; j < rectangles.Count; j++)
            {
               if (rectangles[j].id.Equals(line[0])) { id1 = j; }
               if (rectangles[j].id.Equals(line[1])) { id2 = j; }
            
            }
            Console.WriteLine(rectangles[id1].check(rectangles[id2]));
        }
    }
}