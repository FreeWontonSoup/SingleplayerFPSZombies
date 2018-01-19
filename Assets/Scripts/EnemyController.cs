using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    NavMeshAgent nav;
    Transform player;
    Animator animController;
    public float health;
    GameManagement game;
    public CapsuleCollider capsuleCollider;
    Animator deadAnim;
    bool isDead = false;
    int ptValue = 10;

    //attacking
    public float maxDist;
    public float attackTimer;
    private Transform myTransform;
    public PlayerHealth ph;
    public int damage;
    public PlayerDeath c;
    public AudioClip[] attackSounds;
    public AudioClip[] deathSounds;
    public AudioSource audio;
    //AudioSource audio;
    //public Transform target;

	// Use this for initialization
	void Start () 
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animController = GetComponentInParent<Animator>();
        game = FindObjectOfType<GameManagement>();
        health = 20 + (10 * game.roundNum);
        deadAnim = GetComponent<Animator>();

        myTransform = transform;
        maxDist = 3;
        attackTimer = 0;
        damage = -1;

        ph = (PlayerHealth)player.GetComponent(typeof(PlayerHealth));
        c = (PlayerDeath)GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(PlayerDeath));

        //speed of our zombie
        nav.speed = 0.5f + Random.Range(0f, 3f);

	}
	
	// Update is called once per frame
	void Update () 
    {
        float distance = Vector3.Distance(player.position, myTransform.position);
        if(distance < maxDist)
        {
            Attack();
        }
        if(attackTimer > 0)
        {
            attackTimer = attackTimer * Time.deltaTime;
            //animController.SetBool("Attack", false);
        }
        else if(attackTimer < 0 || ph.currHealth <= 0)
        {
            //if player is dead
            attackTimer = -1;
            c.CamSwitch();
            animController.SetBool("Attack", false);
        }
        else
        {
            animController.SetBool("Attack", false);
        }

        if(!(isDead))
        {
            nav.SetDestination(player.position);
            animController.SetFloat("speed", Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
        }
    }

    void Attack()
    {
        if(!(animController.GetBool("Attack")))
        {
            //2 is number of attacks
            animController.SetFloat("AttackType", Random.Range(0, 2));
        }
        animController.SetBool("Attack", true);

        //play zombie attack sound
        if(!audio.isPlaying)
        {
            //Debug.Log("test");
            audio.clip = attackSounds[Random.Range(0, attackSounds.Length - 1)];
            audio.Play();
        }

        if(attackTimer == 0)
        {
            ph.changeHealth(damage);  
            attackTimer = 2;
        }
        //Debug.Log(ph.currHealth);
    }

    public void ApplyDmg(float dmg)
    {
        health -= dmg;
        if(!(isDead))
        {
            GameManagement.AddPoints(ptValue);
            if(health <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        isDead = true;
        nav.Stop();
        capsuleCollider.isTrigger = true;
        deadAnim.SetTrigger("isDead");
        audio.clip = deathSounds[Random.Range(0, deathSounds.Length - 1)];
        audio.Play();
        GameManagement.remainingZombies -= 1;
        Destroy(this.gameObject, 4f);
        PlayerCanvas.canvas.SetZombiesLeft(GameManagement.remainingZombies);
    }
}
