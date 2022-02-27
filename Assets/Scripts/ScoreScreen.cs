using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.InputSystem;

public class ScoreScreen : MonoBehaviour
{
    

    private Transform headlineContainer;
    private Transform headlineTemplate;
    public GameObject player;

    [HideInInspector]
    public Texture2D image;
    private string headlines;
    private int numHeadlines = 0;
    private StarterAssetsInputs starterAssetsInput;


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
        Debug.Log("in score screen setup");

        
        //disablw player from looking around
        player = GameObject.FindWithTag("Player");
        starterAssetsInput = player.GetComponent<StarterAssetsInputs>();
        //starterAssetsInput.canLook = false;

        headlineContainer = transform.Find("HeadlineContainer");
        headlineTemplate = headlineContainer.Find("HeadlineTemplate");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        this.gameObject.SetActive(true);

        headlines = PlayerPrefs.GetString("headline");
        numHeadlines = PlayerPrefs.GetInt("headlinesRemaining");

        Debug.Log("number headline remaining on score screen: " + numHeadlines);
        
        headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = headline;
        //headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = PlayerPrefs.GetString("headline");
        headlineTemplate.Find("ScoreText").GetComponent<Text>().text = "Your Score: " + score.ToString();
        headlineTemplate.Find("NumberHeadlinesText").GetComponent<Text>().text = "Headlines Left: " + numHeadlines.ToString();
        //headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + PlayerPrefs.GetInt("score").ToString();
        headlineTemplate.Find("RawImage").GetComponent<RawImage>().texture = image;

        if(numHeadlines == 0)
        {
            GameObject.FindGameObjectWithTag("Button").SetActive(false);
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {

        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("GameOver");

    }

    public void RestartButton()
    {
        Debug.Log("scene: " + PlayerPrefs.GetString("_last_scene_"));
        //SceneManager.LoadScene(PlayerPrefs.GetString("_last_scene_"));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //starterAssetsInput.canLook = true;
        this.gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("quit game");
        Application.Quit();
    }

}
