using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    public bool mine;

    public Sprite mineTexture;
    public Sprite[] emptyTextures; 

	// Use this for initialization
	void Start () {

        mine = Random.value < 0.15;         
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

}
