using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mouseP);
    }
}
