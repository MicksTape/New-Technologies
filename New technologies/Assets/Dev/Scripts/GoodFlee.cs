using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GoodFlee : MonoBehaviour
{

    public Transform flee;
    Animator anim;
    Rigidbody rigidbody;
    public CapsuleCollider capCol;
    Vector3 spawnPoint;
    //public GameObject healthBar;
    public int currentHealth;
    public int maxHealth = 3;
    public int damageTaken = 1;
    private bool inDead = false;

    void Awake()
    {
        currentHealth = maxHealth;
        Destroy(gameObject, 3f);
    }





    //private UnityEngine.AI.NavMeshAgent navComponent;

    // Use this for initialization
    void Start()
    {
        flee = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        //navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {     

        Vector3 direction = flee.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(flee.position, this.transform.position) < 80 && angle < 140)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.2f);

            if (direction.magnitude > 2)
            {
                //Speed
                this.transform.Translate(0, 0, 0.01f);
                //navComponent.SetDestination(player.position);

                anim.SetBool("rabbit_move", true);
            }
            else
            {
                anim.SetBool("rabbit_move", false);

            }

        }
        else
        {
            //navComponent.SetDestination (this.transform.position);
            anim.SetBool("rabbit_move", false);

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
        anim.SetBool("rabbit_move", false);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(2.999f);
        Destroy(gameObject);

         StopCoroutine(dead());
         GameObject.FindGameObjectsWithTag("Enemy");
  
    }

}