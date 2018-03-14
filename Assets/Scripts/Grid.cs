
public class Grid : Singleton<Grid> {

    public int w = 10;
    public int h = 13;

    public Element[,] elements; 

    public Grid()
    {
        elements = new Element[w, h]; 
    }

    public void UncoverMines()
    {
        foreach(Element element in elements)
        {
            if (element.mine)
                element.LoadTexture(0);                  
        }
    }

    public bool MineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
            return elements[x, y].mine;

        return false; 
    }

    public int AdjacentMines(int x, int y)
    {
        int count = 0;

        if (MineAt (x    , y + 1)) count++; // top
        if (MineAt (x + 1, y + 1)) count++; // top right 
        if (MineAt (x - 1, y + 1)) count++; // top left 
        if (MineAt (x + 1, y    )) count++; // right 
        if (MineAt (x - 1, y    )) count++; // left 
        if (MineAt (x    , y - 1)) count++; // bottom 
        if (MineAt (x + 1, y - 1)) count++; // bottom right 
        if (MineAt (x - 1, y - 1)) count++; // bottom left

        return count; 
    }


    public void FloodFillAlgorithm(int x, int y, bool[,] visited)
    {
        if(x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
                return;

            elements[x, y].LoadTexture(AdjacentMines(x, y));

            if (AdjacentMines(x, y) > 0)
                return;

            visited[x, y] = true;

            FloodFillAlgorithm(x    , y + 1, visited); // top 
            FloodFillAlgorithm(x    , y - 1, visited); // bottom 
            FloodFillAlgorithm(x + 1, y    , visited); // right 
            FloodFillAlgorithm(x - 1, y    , visited); // left 

        }
    }

    public bool IsFinished()
    {
        foreach (Element element in elements)
            if (element.isCovered() && !element.mine)
                return false;

        return true; 
    }
}
