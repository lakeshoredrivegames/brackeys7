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

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Setup(int score, string headline)
    {
        headlineContainer = transform.Find("HeadlineContainer");
        headlineTemplate = headlineContainer.Find("HeadlineTemplate");

        //player.GetComponent<FirstPersonController>().enabled = false;
        this.gameObject.SetActive(true);

        headlineTemplate.Find("HeadlineText").GetComponent<Text>().text = headline;
        headlineTemplate.Find("ClicksText").GetComponent<Text>().text = "clicks: " + score.ToString();
        headlineTemplate.Find("RawImage").GetComponent<RawImage>().texture = image;

    }

    public void RestartButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitButton()
    {

    }

}
