using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [Space]
    [Header("MONEY")]
    public int moneyAfterLose;
    private int money;
    private int moneyForResult;

    [Space]
    [Header("Score Text")]
    public Text scoreText; // обьект текста
    public int score; // здесь хранится  рекорд
    //public GameObject scoretext; // нужно для трансформирования
    public Text gameOverText;
    public Text moneyAfterLoseText;
    [Space]
    [Header("Pause and Lose Menu")]
    public PauseInGame pause;
    private bool gameOver;
    private bool restartGame;

    [Header("Sound")]
    public Slider volumeSlider;
    AudioSource audio;
    [Space]
    [Header("HP")]
    private int maxHealthEnemy = 25;
    private int maxHP = 100;
    private int minHP = 0;
    public Slider sliderHP;

    private float currentHP;
    private int currentEnemyHP;
    private void Awake()
    {
        sliderHP.maxValue = maxHP + PlayerPrefs.GetInt("Health");
        sliderHP.value = maxHP + PlayerPrefs.GetInt("Health");
        
    }
    private void Start ()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        audio = GetComponent<AudioSource>();
        moneyForResult = 0;
        moneyAfterLoseText.text = "";
        gameOverText.text = "";



        gameOver = false;
        restartGame = false;
        


        score = 0;
        UpdateScore();
        maxHealthEnemy = 25;
}
    private void Update()
    {

        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);




    }
    
    public void AddMoney(int MoneyValues)
    {
        if (score > 2000 && score < 4000)
        {
            MoneyValues *= 5;
        }
        if (score > 4000 && score < 8000)
        {
            MoneyValues *= 10;
        }
        if (score > 8000 && score < 100000)
        {
            MoneyValues *= 20;
        }
        money = MoneyValues + PlayerPrefs.GetInt("Moneys");
        PlayerPrefs.SetInt("Moneys", money);
        moneyForResult += MoneyValues;
    }
    
    public void AddScore(int ScoreValues)
    {
        score += ScoreValues;             
        UpdateScore();        

        if (PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score); // Сохранять рекорд
        }
    }
   public void UpEnemy()
    {
        if (score > 2000 && score < 4000)
        {
            maxHealthEnemy = 50;
        }
        if (score > 4000 && score < 8000)
        {
            maxHealthEnemy = 75;
        }
        if (score > 8000 && score < 100000)
        {
            maxHealthEnemy = 150;
        }
    }
    public void DamageForPlayer(int damage, Collider other)
    {
        if (score > 2000 && score < 4000)
        {
            damage += 50;
        }
        else if (score > 4000 && score < 8000)
        {
            damage += 75;
        }
        else 
        {
            damage += 150;
        }
        currentHP = sliderHP.value - damage;
        sliderHP.value = currentHP;
        
        if (currentHP <= 0)
        {
            currentHP = 0;
            GameOver();
            Destroy(other.gameObject);
        }
    }
    public void DamageForEnemy(int damage, Collider other)
    {
        currentEnemyHP =  maxHealthEnemy - damage;
        maxHealthEnemy = currentEnemyHP;
        
        if (currentEnemyHP <= 0)
        {
            UpEnemy();
            //AddScore(100);
            AddMoney(10);
            UpEnemy();
            Destroy(other.gameObject);
        }
    } 


    void UpdateScore()
    {  
        
        scoreText.text = "Score: " + score; // Записывать рекорд во время игры

    }
   
    public void GameOver() 
    {
        gameOverText.text = "GAME OVER!"; // Выводим текст после смерти игрока
        
        gameOver = true;
        if (gameOver)
        {
            
            moneyAfterLoseText.text = "+" + moneyForResult + "$"; // Добавляем деньги, поделив заработанные очки на 10

            restartGame = true;
            
        }
       
    }

    
    public void RestartGame()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single); // перезагрузка игры после проигрыша
    }

}
