using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour 
{
    public int roundNum = 1;
    public int totalZombiesInRound = 10;
    public int totalZombiesSpawnedInRound = 0;
    float zombieSpawnTimer = 0;
    public GameObject enemyZombie;
    static int playerScore = 0;
    static int playerPoints = 0;

    public GUISkin mySkin;

    //array of spawn points
    public Transform[] zombieSpawnPoints;

	// Use this for initialization
	void Start () {
		
	}
	
    // Update is called once per frame (fixed is to ensure same time between each call)
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

    void SpawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)].position;
        Instantiate(enemyZombie, randomSpawnPoint, Quaternion.identity);
        totalZombiesSpawnedInRound++;
    }

    public static void AddPoints(int ptValue)
    {
        playerScore += ptValue;
        playerPoints += ptValue;
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUIStyle s1 = mySkin.customStyles[0];

        GUI.Label(new Rect(740, Screen.height - 70, 100, 60), " Score : ");
        GUI.Label(new Rect(820, Screen.height - 68, 160, 60), "" + playerScore, s1);
        GUI.Label(new Rect(740, Screen.height - 100, 100, 60), " Points : ");
        GUI.Label(new Rect(820, Screen.height - 98, 160, 60), "" + playerPoints, s1);
    }
}
