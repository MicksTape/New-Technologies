using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class fpsAttack : MonoBehaviour {

	public int currentHealth = 10;
	public Slider healthbar;
	public Transform respawnPosition;
    public GameObject VR;

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Enemy")
        {
            print("hit");
            currentHealth -= 1;
            healthbar.value -= 1;

            if (currentHealth <= 0)
            {
                VR.transform.position = respawnPosition.position;
                healthbar.value = 10;
                currentHealth = 10;
            }
        }
	}
		
	// Use this for initialization
	void Start () 
	{
		respawnPosition = GameObject.FindGameObjectWithTag ("Respawn").transform;
	}

	// Update is called once per frame
	void Update ()
	{
		if (currentHealth <= 0) return;

	}


}

