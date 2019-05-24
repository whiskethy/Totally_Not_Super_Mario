using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject LevelStart;
    public GameObject LevelEnd;

    public GameObject LevelTop;
    public GameObject LevelBottom;

    float xMin;
    float xMax;

    float yMin;
    float yMax;

    float CamPos;
    float CamPosY;

    [Range(-20, 20)]public float xMinThreshold;
    [Range(-20, 20)]public float xMaxThreshold;
    [Range(-20, 20)]public float yMinThreshold;
    [Range(-20, 20)]public float yMaxThreshold;

    private void Start() {
        xMin = LevelStart.transform.position.x + xMinThreshold;
        xMax = LevelEnd.transform.position.x - xMaxThreshold;

        yMax = LevelTop.transform.position.y + yMaxThreshold;
        yMin = LevelBottom.transform.position.y - yMinThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if(player){
            CamPos = player.transform.position.x;
            CamPos = Mathf.Clamp(CamPos, xMin, xMax);

            CamPosY = player.transform.position.y;
            CamPosY = Mathf.Clamp(CamPosY, yMin, yMax);

            this.transform.position = new Vector3(CamPos, CamPosY, -10);
        }
        else
        {
            //Debug.Log("Player is not found");
        }
    }
}
