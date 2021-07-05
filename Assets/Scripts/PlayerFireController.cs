using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public FireballScript fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //Left Click
        {
            Vector3 mouseP = Input.mousePosition;
            mouseP.z = Camera.main.nearClipPlane;
            Vector3 direction = (Camera.main.ScreenToWorldPoint(mouseP) - transform.position);
            Vector3 spawnPosition = transform.position;
            Instantiate(fireball,spawnPosition,Quaternion.identity);
        }
    }
}
