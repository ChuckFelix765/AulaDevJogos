using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour {

    // Verifica colisões da bola nas paredes
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            GameManager.instance.SubVida(1);
            hitInfo.gameObject.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            if(GameManager.instance.vidas == 0){
                GameManager.instance.LoadEndGame(GameState.GameOver);
            }
            
        }
    }
}
