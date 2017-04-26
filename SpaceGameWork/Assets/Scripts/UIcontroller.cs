using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    [SerializeField]
    GameObject logPanel;
    [SerializeField]
    Text log;
    [SerializeField]
    Text textScore;
    [SerializeField]
    Text textHealth;
    [SerializeField]
    GameObject player;

    bool isActiveLog = false;
    bool first = true;
    int score = 0;
    int health = 15;

    void Awake()
    {
        // подписка
        Messenger.EnHit += OnEnemyHit;
        Messenger.ShipConMeteor += ShCoMe;
        Messenger.RocketDesMet += RoDeMe;        
        Messenger.ShipUsedPo += ShUsPo;
        
        
        // Вывод начальных значений 
        WriteHealth();
        WriteScore();
    }

    void Start()
    {
        Debug.Log("Start");
        if (PlayerPrefs.HasKey("first"))
            first = System.Convert.ToBoolean(PlayerPrefs.GetString("first"));


        // Загрузка значений
        if (!first)
        {
            if (PlayerPrefs.HasKey("log"))
            {
                SetLog(PlayerPrefs.GetString("log"));
            }
            if (PlayerPrefs.HasKey("Health"))
            {
                health = PlayerPrefs.GetInt("Health");
                textHealth.text = "HP: " + PlayerPrefs.GetInt("Health");

            }
            if (PlayerPrefs.HasKey("Score"))
            {
                score = PlayerPrefs.GetInt("Score");
                textScore.text = "Count: " + PlayerPrefs.GetInt("Score");
            }
        }
    }

    void OnDestroy()
    {
        // отписка
        Messenger.EnHit -= OnEnemyHit;
        Messenger.ShipConMeteor -= ShCoMe;
        Messenger.RocketDesMet -= RoDeMe;
        Messenger.ShipUsedPo -= ShUsPo;
    }
    

    // 3 метода для разделения ответствености 
    // и отказ от ветвления в коде
    // Отвечают за вывод инфы в лог
    void ShCoMe()
    {
        SetLog(GameEvent.SHIP_CONTACT_METEORITE);
        HitShip();
    }

    void RoDeMe()
    {
        SetLog(GameEvent.ROCKET_DESTROY_METEORITE);
    }

    void ShUsPo()
    {
        first = false;
        SetLog("Used teleport");

        SetLog(GameEvent.SHIP_USED_PORTAL);
        
        PlayerPrefs.SetString("first", first.ToString());
        // PlayerPrefs.SetString("log", log.text);
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Score", score);
    }

    // запись в лог
    void SetLog(string messenge)
    {
        log.text += ("\n" + messenge);
    }

    // Начисление очков
    void OnEnemyHit()
    {
        score++;
        WriteScore();

        if (score % 10 == 0)
        {
            health++;
            WriteHealth();
            Debug.Log("+++++++");

        }
    }

    void WriteScore()
    {
        textScore.text = "Count: " + score;
    }

    // Активация лога
    public void ActiveLog()
    {
        if(isActiveLog)
        {
            logPanel.SetActive(false);
            isActiveLog = false;
        }
        else
        {
            logPanel.SetActive(true);
            isActiveLog = true;
        }
    }

    // Удар об метеорит
    void HitShip()
    {
        health--;
        WriteHealth();
        SetLog("Удар -1 хп");
        if (health <= 0 )
        {
            SetLog("Вы мертвы!");
            Destroy(player.gameObject);
        }
    }

    void WriteHealth()
    {
        textHealth.text = "HP: " + health;
    }
}
