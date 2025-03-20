using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject inipre;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    private float tempo;


    // Start is called before the first frame update
    void Awake(){
        spawn();
    }

    // Update is called once per frame
    void Update(){
        tempo -= Time.deltaTime;

        if(tempo <= 0){
            Instantiate(inipre, transform.position, transform.rotation);
            spawn();
        }
    }

    private void spawn(){
        tempo = Random.Range(min, max);
    }
}
