using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject LevelStart;
    public GameObject LevelEnd;

    float xMin;
    float xMax;

    float CamPos;

    private void Start() {
        xMin = LevelStart.transform.position.x + 7f;
        xMax = LevelEnd.transform.position.x - 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player){
            CamPos = player.transform.position.x;
            CamPos = Mathf.Clamp(CamPos, xMin, xMax);
            this.transform.position = new Vector3(CamPos, this.transform.position.y, -10);
        }
        else
        {
            //Debug.Log("Player is not found");
        }
    }
}
