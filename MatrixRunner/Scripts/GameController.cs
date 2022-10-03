using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 100;
    public int speed = 11;
    public float jumpIntensity = 7f;
    public int timer = 0;
    private int mockTime = 3;
    [SerializeField] private Text timerText;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private EndlessCharacterController characterController;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine("waiters");
    }
    void Start()
    {
        //speed = PlayerPrefs.GetInt("PlayerSpeed", 10);
        //health = PlayerPrefs.GetInt("PlayerHealth, 10);
        int level = 1;
        levelText.text = "Level: " + level.ToString();
        StartCoroutine("waiters");
        StartCoroutine("CountDown");
    }
    IEnumerator waiters()
    {
        yield return new WaitForSeconds(5);
    }
    IEnumerator CountDown()
    {

        while (timer <= 30)
        {
            // wait for 1 second
            if ( mockTime == 4)
            {
                characterController.godMode = false;
                mockTime = 0;
            }
            timerText.text = "Timer: " + timer;
            yield return new WaitForSeconds(1);
            timer++;
            mockTime++;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<EndlessCharacterController>().enabled = false;
        // pause the player, load the UI message
        yield return new WaitForSeconds(2);
        // Change multiple scenes here
        changeLevel();
    }
    //fOr when we want to load more scenes
    private void changeLevel() {
        PlayerPrefs.SetInt("Player", speed);
        PlayerPrefs.SetInt("Player", health);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 3);
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(health / 50f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER!!!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerSpeed");
    }
}