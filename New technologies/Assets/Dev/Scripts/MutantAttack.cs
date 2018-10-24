using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MutantAttack : MonoBehaviour
{

    public Transform player;
    Animator anim;
    Rigidbody rigidbody;
    public CapsuleCollider capCol;
    Vector3 spawnPoint;
    //public GameObject healthBar;
    public int currentHealth;
    public int maxHealth = 3;
    public int damageTaken = 1;
    private bool inDead = false;
    [SerializeField]
    private GameObject rabbit;
    [SerializeField]
    private GameObject explosion;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    //private UnityEngine.AI.NavMeshAgent navComponent;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Carrot":
                currentHealth = currentHealth - damageTaken;
                
                print("hit");
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        //navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {     

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 80 && angle < 140)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.2f);

            anim.SetBool("slime_idle", false);
            if (direction.magnitude > 2)
            {
                //Speed
                this.transform.Translate(0, 0, 0.01f);
                //navComponent.SetDestination(player.position);

                anim.SetBool("slime_move", true);
                anim.SetBool("slime_attack", false);

            }
            else
            {
                anim.SetBool("slime_move", false);
                anim.SetBool("slime_attack", true);
            }

        }
        else
        {
            //navComponent.SetDestination (this.transform.position);
            anim.SetBool("slime_idle", true);
            anim.SetBool("slime_move", false);
            anim.SetBool("slime_attack", false);

        }

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 
            if (!inDead)
            {
                StartCoroutine(dead());
            }


        }

    }

    IEnumerator dead()
    {
        inDead = true;
         //navComponent.SetDestination (this.transform.position);
        capCol.enabled = false;
        anim.SetBool("slime_die", true);
        anim.SetBool("slime_idle", false);
        anim.SetBool("slime_move", false);
        anim.SetBool("slime_attack", false);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        GameObject newEplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(newEplosion, 3f);
        Instantiate(rabbit, transform.position.normalized, transform.rotation);
        Destroy(rabbit, 4f);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

         StopCoroutine(dead());
         GameObject.FindGameObjectsWithTag("Enemy");
  
    }

}