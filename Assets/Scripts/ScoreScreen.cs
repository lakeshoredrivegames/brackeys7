using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    

    private Transform headlineContainer;
    private Transform headlineTemplate;

    [HideInInspector]
    public Texture2D image;
    private string headlines;
    private int numHeadlines = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    void Awake()
    {

        
    }


    public void Setup(int score, string headline)
    {
        headlineContainer = transform.Find("HeadlineContainer");
        headlineTemplate = headlineContainer.Find("HeadlineTemplate");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        this.gameObject.SetActive(true);

        headlines = PlayerPrefs.GetString("headline");
        numHeadlines = PlayerPrefs.GetInt("headlinesRemaining");

        
        headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = headline;
        //headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = PlayerPrefs.GetString("headline");
        headlineTemplate.Find("ScoreText").GetComponent<Text>().text = "Your Score: " + score.ToString();
        headlineTemplate.Find("NumberHeadlinesText").GetComponent<Text>().text = "Headlines Left: " + numHeadlines.ToString();
        //headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + PlayerPrefs.GetInt("score").ToString();
        headlineTemplate.Find("RawImage").GetComponent<RawImage>().texture = image;

    }

    public void RestartButton()
    {
        Debug.Log("scene: " + PlayerPrefs.GetString("_last_scene_"));
        //SceneManager.LoadScene(PlayerPrefs.GetString("_last_scene_"));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        this.gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
