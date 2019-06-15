using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDied = false;
    public bool isDefeat = false;
    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;
    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance { get => instance; set => instance = value; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("RetrunToTheMainMenu", 3);
            return;
        }
        if (isDied)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();
    }
    private void Recover()
    {
        if (lifeValue <= 0)
        {
            //play fail
            isDefeat = true;
            Invoke("RetrunToTheMainMenu", 3);
        }
        else
        {
            lifeValue--;
            //born in 
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDied = false;
        }
    }
    private void RetrunToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
