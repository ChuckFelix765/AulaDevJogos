using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {



    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Ball")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            /*
            if (this.gameObject.tag == "Block") GameManager.instance.AddPoints(10);

            */
            BlockController.instance.DecTLBlocks();
            Destroy(gameObject,2);
        }
    }
}