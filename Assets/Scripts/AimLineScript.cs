using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,player.transform.position); //Alreandy attached to the player object
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = Camera.main.nearClipPlane;
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Camera.main.ScreenToWorldPoint(mouseP) - player.transform.position);
        if (hit.collider != null)
        {
            float distanceHitPoint = Vector2.Distance(player.transform.position,hit.point);
            float distanceCursor = Vector2.Distance(player.transform.position,Camera.main.ScreenToWorldPoint(mouseP));
            if(distanceCursor > distanceHitPoint)
            {
                lineRenderer.SetPosition(1,hit.point);
            }
            else
            {
                lineRenderer.SetPosition(1,Camera.main.ScreenToWorldPoint(mouseP));
            }
        }
        else
        {
            lineRenderer.SetPosition(1,Camera.main.ScreenToWorldPoint(mouseP));
        }
    }
}
