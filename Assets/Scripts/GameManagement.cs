using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour 
{
    public int roundNum = 1;
    public int totalZombiesInRound = 10;
    public int totalZombiesSpawnedInRound = 0;
    float zombieSpawnTimer = 0;
    public GameObject enemyZombie;
    public static int playerScore = 0;
    public static int playerPoints = 0;

    //GUI
    //public GUISkin mySkin;
    public GameObject CountdownGUI;
    public static GameManagement canvas;
    public Text scoreValue;
    public Text pointsValue;

    //zombie rounds
    public static int remainingZombies = 10;
    float countDown = 0;

    //array of spawn points
    public Transform[] zombieSpawnPoints;

	// Use this for initialization
	void Start () 
    {
		
	}

    void Update()
    {
        //controls when we spawn zombies
        if((totalZombiesSpawnedInRound < totalZombiesInRound) && countDown == 0)
        {
            if(zombieSpawnTimer > 2)
            {
                SpawnZombie();
                zombieSpawnTimer = 0;
            }
            else
            {
                zombieSpawnTimer += Time.deltaTime;
            }
 
        }
        else if(remainingZombies == 0)
        {
            BeginNextRound();
        }

        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
            PlayerCanvas.canvas.SetCountdown(Mathf.RoundToInt(countDown));
        }
        else
        {
            countDown = 0;
            PlayerCanvas.canvas.SetCountdown(0);
            StartCoroutine(DelayedGUI());
            CountdownGUI.SetActive(false);
        }
    }

    IEnumerator DelayedGUI()
    {
        yield return new WaitForSeconds(1f);
    }

    void BeginNextRound()
    {
        totalZombiesInRound = roundNum * 10;
        remainingZombies = totalZombiesInRound;
        totalZombiesSpawnedInRound = 0;
        countDown = 10;
        roundNum++;
        PlayerCanvas.canvas.SetZombiesLeft(remainingZombies);
        PlayerCanvas.canvas.SetRound(roundNum);
        CountdownGUI.SetActive(true);
    }
	
    // Update is called once per frame (fixed is to ensure same time between each call)
    /*
	void FixedUpdate () 
    {
        if(totalZombiesSpawnedInRound < totalZombiesInRound)
        {
            if(zombieSpawnTimer > 3)
            {
                SpawnZombie();
                zombieSpawnTimer = 0;
            }
            else
            {
                zombieSpawnTimer++;
            }
        }
	}
 */   

    void SpawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)].position;
        Instantiate(enemyZombie, randomSpawnPoint, Quaternion.identity);
        totalZombiesSpawnedInRound++;
    }

    public static void AddPoints(int ptValue)
    {
        //need to change this later when adding buyable weapons
        //aka need to add functionality for subtracting points
        playerScore += ptValue;
        PlayerCanvas.canvas.SetScore(playerScore);
        playerPoints += ptValue;
        PlayerCanvas.canvas.SetPoints(playerPoints);
    }
        
    /*
    void OnGUI()
    {
        GUI.skin = mySkin;
        GUIStyle s1 = mySkin.customStyles[0];

        //points and score gui
        GUI.Label(new Rect(740, Screen.height - 70, 100, 60), " Score : ");
        GUI.Label(new Rect(820, Screen.height - 68, 160, 60), "" + playerScore, s1);
        GUI.Label(new Rect(740, Screen.height - 100, 100, 60), " Points : ");
        GUI.Label(new Rect(820, Screen.height - 98, 160, 60), "" + playerPoints, s1);

        //round gui
        GUI.Label(new Rect(Screen.width/2-50, Screen.height - 30, 160, 60), "Zombies Left: ");
        GUI.Label(new Rect(Screen.width/2+80, Screen.height - 30, 160, 60), "" + remainingZombies, s1);
        if(countDown != 0)
        {
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 - 80, 100, 60), "Next Round: ");
            GUI.Label(new Rect(Screen.width/2 + 50, Screen.height/2 - 80, 160, 60), "" + Mathf.RoundToInt(countDown), s1);
        }

        GUI.Label(new Rect(100, Screen.height-50, 100, 60), "Spawned: ");
        GUI.Label(new Rect(200, Screen.height-50, 160, 60), "" + totalZombiesSpawnedInRound,s1);
    }
    */
}
