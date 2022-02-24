using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    private Transform headlineContainer;
    private Transform headlineTemplate;

    public Texture2D image;
    public string headlines;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    void Awake()
    {

        headlineContainer = transform.Find("HeadlineContainer");
        headlineTemplate = headlineContainer.Find("HeadlineTemplate");
        headlines = PlayerPrefs.GetString("headline");
        Debug.Log("headline on game over is " + headlines);
        //headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = headline;
        headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = PlayerPrefs.GetString("headline");
        //headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + score.ToString();
        headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + PlayerPrefs.GetInt("score").ToString();
        headlineTemplate.Find("RawImage").GetComponent<RawImage>().texture = image;
    }


    public void Setup(int score, string headline)
    {
        headlineContainer = transform.Find("HeadlineContainer");
        headlineTemplate = headlineContainer.Find("HeadlineTemplate");

        this.gameObject.SetActive(true);

        headlines = PlayerPrefs.GetString("headline");
        Debug.Log("headline on game over is " + headlines);
        headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = headline;
        
        headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + score.ToString();
        
        headlineTemplate.Find("RawImage").GetComponent<RawImage>().texture = image;

    }

    public void RestartButton()
    {
        Debug.Log("scene: " + PlayerPrefs.GetString("_last_scene_"));
        SceneManager.LoadScene(PlayerPrefs.GetString("_last_scene_"));
    }

    public void ExitButton()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
