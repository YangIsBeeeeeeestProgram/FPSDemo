using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;


public class Enemy
{
    public GameObject obj;
    public int HP = 1;
    public int MOVESPEED = 1;
    public NavMeshAgent navMeshAgent;
    Player player;
    public float fightInterval = 1f;
    public int ATK = 10;
    private float lastTime = 0;
    private float tempInterval = 0;
    public bool isDie = false;
    private bool canFight = false;
    public Enemy(GameObject obj,int hp = 1,int speed = 1)
    {
        this.obj = obj;
        this.HP = hp;
        this.MOVESPEED = speed;
        this.navMeshAgent = obj.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void Move()
    {
        if (isDie)
            return;
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void Die()
    {
        navMeshAgent.isStopped = true;
        this.obj.SetActive(false);
        isDie = true;
        ScoreManager.Instance.AddScore(HP);
    }

    
    public void Fight()
    {
        float dis = Vector3.Distance(this.obj.transform.position, player.transform.position);

        tempInterval = Time.time - lastTime;

        if (tempInterval > fightInterval)
        {
            canFight = true;
            lastTime = Time.time;
        }

        if (canFight && dis <= 1)
        {
            Player.Instance.TakeDamage(this.ATK);
            canFight = false;
        }
    }
}

public class EnemyController: Singleton<EnemyController> {

    [SerializeField]
    GameObject cube;

    public float interval = 0.01f;

    ObjectPool<GameObject> enemyPool;
    private float lastTime;
    private float tempInterval = 0;
    public List<Enemy> enemies = new List<Enemy>();
    private void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(GenerateEnemy, 5);
    }


    GameObject GenerateEnemy()
    {
        GameObject newObj = Instantiate(cube, Vector3.zero, Quaternion.identity);
        newObj.SetActive(false);
        return newObj;
    }


    //获取一个随机位置
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-250, 251);
        float z = Random.Range(-250, 251);
        return new Vector3(x, 0.5f, z);
    }



    private void Update()
    {
        InstanceEnemy();
        UpdateEnemy();
    }


    void InstanceEnemy()
    {
        tempInterval = Time.time - lastTime;
        if (tempInterval > interval)
        {
            GameObject newEnemy = enemyPool.GetT();
            newEnemy.transform.position = GetRandomPosition();
            newEnemy.SetActive(true);
            lastTime = Time.time;
            enemies.Add(new Enemy(newEnemy));
        }
    }


    void UpdateEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            
            enemies[i].Move();
            enemies[i].Fight();
            
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isDie)
            {
                enemies.Remove(enemies[i]);
            }
        }
    }


}