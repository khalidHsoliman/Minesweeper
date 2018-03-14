using UnityEngine;

public class Element : MonoBehaviour {

    public bool mine;

    public Sprite mineTexture;
    public Sprite[] emptyTextures; 

	void Start () {

        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        Grid.Instance.elements[x, y] = this; 
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
        if (!GameManager.Instance.gameIsOver)
        {
            if (mine)
            {
                Grid.Instance.UncoverMines();

                GameManager.Instance.Lose();
            }

            else
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;

                LoadTexture(Grid.Instance.AdjacentMines(x, y));

                Grid.Instance.FloodFillAlgorithm(x, y, new bool[Grid.Instance.w, Grid.Instance.h]);

                if (Grid.Instance.IsFinished())
                {
                    GameManager.Instance.Win();
                }
            }
        }
    }
}
