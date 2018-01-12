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
    //public Transform target;

	// Use this for initialization
	void Start () 
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animController = GetComponentInParent<Animator>();
        game = FindObjectOfType<GameManagement>();
        health = 20 + (1.25F * game.roundNum);
        deadAnim = GetComponent<Animator>();

        myTransform = transform;
        maxDist = 3;
        attackTimer = 0;
        damage = -10;

        ph = (PlayerHealth)player.GetComponent(typeof(PlayerHealth));
        c = (PlayerDeath)GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(PlayerDeath));

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
        }
        if(attackTimer < 0 || ph.currHealth <= 0)
        {
            //if player is dead
            attackTimer = -1;
            c.CamSwitch();
        }

        if(!(isDead))
        {
            nav.SetDestination(player.position);
            animController.SetFloat("speed", Mathf.Abs(nav.velocity.x) + Mathf.Abs(nav.velocity.z));
        }
    }

    void Attack()
    {
        if(attackTimer == 0)
        {
            ph.changeHealth(damage);  
            attackTimer = 2;
        }
        Debug.Log(ph.currHealth);
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
        Destroy(this.gameObject, 4f);
    }
}
