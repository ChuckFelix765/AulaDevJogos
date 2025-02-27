using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController1 : MonoBehaviour {
    [SerializeField]
    private GameObject[] blocks;
    private int tlBlocks;

    public static BlockController1 instance;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }
    void Start () {
        this.CreateBlock();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public int GetTLBlocks()
    {
        return tlBlocks;
    }

    public void DecTLBlocks()
    {
        tlBlocks--;
    }
    void CreateBlock()
    {
        float px = -10.5f;
        float py = 4.7f;
        tlBlocks = 0;
        for (int i = 0; i < 6; i++) //linha
        {
            px = -10.5f;
            for (int j = 0; j < 22; j++)
            {
                Vector3 pos = new Vector3(px, py, 0);
                //criar o block na tela
                Instantiate(blocks[i], pos, Quaternion.identity);
                px = px + 1;
                tlBlocks++;
            }
            py = py - 0.5f;
        }
    }
}