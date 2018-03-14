using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    public static int w = 10;
    public static int h = 13;

    public static Element[,] elements = new Element[w, h]; 

    public static void UncoverMines()
    {
        foreach(Element element in elements)
        {
            if (element.mine)
                element.LoadTexture(0);                  
        }
    }

    public static bool MineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
            return elements[x, y].mine;

        return false; 
    }

    public static int AdjacentMines(int x, int y)
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
}
