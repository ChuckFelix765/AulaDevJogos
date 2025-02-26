using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            /*
            if (this.gameObject.tag == "Block") GameController.instance.AddPoints(10);

            */
            BlockController.instance.DecTLBlocks();
            Destroy(gameObject,2);
        }
    }
}