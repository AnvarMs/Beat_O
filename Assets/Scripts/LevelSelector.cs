using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollStep = 0.1f; // Adjust the scroll step as needed
    int scene = 1;
    public void OnNextButtonPressed()
    {
        if (scene < 10)
        {
            scene++;
        }
        float newScrollPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition + scrollStep);
        scrollRect.horizontalNormalizedPosition = newScrollPosition;
    }

    public void OnPreviousButtonPressed()
    {
        if (scene > 1)
        {
            scene--;    
        }
        float newScrollPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition - scrollStep);
        scrollRect.horizontalNormalizedPosition = newScrollPosition;
    }
   
    public void playSelectedlevel()
    {
        SceneManager.LoadScene(scene);
    }
}
