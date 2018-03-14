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
}
