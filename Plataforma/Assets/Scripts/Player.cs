using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    // Start is called before the first frame update
    private Animator animations;

    void Start(){
    }

    // Update is called once per frame
    void Update(){
        float Horizontali = Input.GetAxis("Horizontal");
        float Verticali = Input.GetAxis("Vertical");
        Vector3 direc = new Vector3(Horizontali, Verticali, 0);
        transform.Translate(direc * 5 * Time.deltaTime);
    }
}
