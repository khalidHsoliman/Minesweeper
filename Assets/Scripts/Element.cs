using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    public bool mine;

    public Sprite mineTexture;
    public Sprite[] emptyTextures; 

	void Start () {

        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        Grid.elements[x, y] = this; 
	}
	
    public void LoadTexture(int adjCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjCount];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }


    private void OnMouseUpAsButton()
    {
        if(mine)
        {
            Grid.UncoverMines(); 
        }

        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;

            LoadTexture(Grid.AdjacentMines(x, y)); 
        }
    }

}
