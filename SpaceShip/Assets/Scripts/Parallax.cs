using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float movingSpeed = 5f;
    public GameObject cam;
    public float parallaxEffect;
    public float slow = 1f;
    // Start is called before the first frame update
    void Start()
   {
       lenght = GetComponent<SpriteRenderer>().bounds.size.x;
   }


    // Update is called once per frame
    void Update(){
        transform.position += (Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect) * slow;
        if(transform.position.x <= -lenght ) {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }

}
