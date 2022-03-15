using UnityEngine;


public class EnemyBolt : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameObject cloneExplosion;
    public int scoreValue;
    private GameController gameController;
    public GameObject mega_exp;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    private void Update()
    {
        explosion.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
        explosionPlayer.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }


    private void OnParticleCollision()
    {
        // Клонируем префаб взрыва
        cloneExplosion = (GameObject)Instantiate(mega_exp, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
        // Уничтожаем обьект, на котором висит этот скрипт
        Destroy(gameObject);
        // Уничтожаем клон взрыва, после того, как он отрбатол
        Destroy(cloneExplosion, 0.7f);
        // Насчитываем очки, за уничтожение вражекого обьекта
        gameController.AddScore(scoreValue);
        gameController.AddMoney(scoreValue / 10);
    }


    public void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().DecreaseHealth(50);
        }
      

    }

}
