using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UiControler : MonoBehaviour
{
    public Text timeText,scoreText,timerText2;
    public float scnd;
    public int mint;
    public int ScoreValue = 100;
    public int timer;
    float count;
    int corentscene;
    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
        scnd = 0;
        mint = 0;
        Time.timeScale = 1f;
       corentscene =SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {

        if (count < 1)
        {
            count += Time.deltaTime;
        }
        else
        {
            count = 0;
            timer--;
            timerText2.text = timer.ToString();
        }
        if (scnd < 60)
        {
            
            if (scnd % 10 == 0)
            {
                ScoreValue -= 5;
            }
            
            scnd += Time.deltaTime;

        }
        else
        {
            mint++;
            scnd = 0;
        }
        
    }

  
    public void NextLeavel()
    {
        SceneManager.LoadScene(corentscene+1);
    } public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void SetFalse(GameObject Butte)
    {
        Butte.SetActive(false);
    }
    public void SetTrue(GameObject Butte)
    {
        Butte.SetActive(true);
    }
    public void PouseAndRestartGame(int scale)
    {
        Time.timeScale=scale;
    }
    public void UpdateThePopup()
    {
        int se =00 ;
        se += (int)scnd;
        int m = 00;
        m += mint;
        string st= m.ToString()+" : "+ se.ToString();
        timeText.text = st;
       StartCoroutine( AnimateScore(0,ScoreValue));


    }
    public void Restart()
    {
        SceneManager.LoadScene(corentscene);
    }
    private IEnumerator AnimateScore(int startValue, int endValue)
    {
        float elapsedTime = 0f;
        float animationDuration = 1f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            // Use Mathf.Lerp to calculate the float value, then cast it to int
            int currentScore = Mathf.RoundToInt(Mathf.Lerp(startValue, endValue, elapsedTime / animationDuration));
            scoreText.text = currentScore.ToString();
            yield return null;
        }

        // Ensure the final value is set
        scoreText.text = endValue.ToString();
    }

}
