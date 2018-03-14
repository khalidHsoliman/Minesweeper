using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public Text timerDisplay;
    public Text endGameDisplay;

    public Button playAgain; 

    public bool gameIsOver;

    private float _timer; 

	void Start () {

        init();
	}
	
	void Update () {

        if (!gameIsOver)
        {
            _timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(_timer / 60F);
            int seconds = Mathf.FloorToInt(_timer - minutes * 60);
            string _time = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (timerDisplay)
                timerDisplay.text = _time;
        }
	}

    public void Win()
    {
        gameIsOver = true;
        endGameDisplay.text = "YOU WON!";
        endGameDisplay.color = Color.green;
        endGameDisplay.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(true);
    }
    
    public void Lose()
    {
        gameIsOver = true;
        endGameDisplay.text = "YOU LOST!";
        endGameDisplay.color = Color.red;
        endGameDisplay.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(true);
    }

    public void Restart()
    {
        init();
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void init()
    {
        gameIsOver = false; 

        _timer = 0f;

        if (timerDisplay)
            timerDisplay.gameObject.SetActive(true);

        if (endGameDisplay)
            endGameDisplay.gameObject.SetActive(false);

        if (playAgain)
            playAgain.gameObject.SetActive(false); 
    }

}
