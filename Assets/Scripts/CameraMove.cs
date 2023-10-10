using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerpos;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = player.transform.position;
        pos = new Vector3(playerpos.x, playerpos.y, -10);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position;
        pos.x = playerpos.x;
        pos.y = playerpos.y; 
        transform.position = pos;
    }
}
