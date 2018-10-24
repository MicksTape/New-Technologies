using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {

    private AudioSource AS;
    public AudioClip HitSound;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy":
                AS.PlayOneShot(HitSound);

                print("EnemyHit");
                break;
        }
    }

}
