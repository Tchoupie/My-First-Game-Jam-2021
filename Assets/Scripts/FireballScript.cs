using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float fireForce = 2;
    Vector3 direct;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = Camera.main.nearClipPlane;
        direct = (Camera.main.ScreenToWorldPoint(mouseP) - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += direction * (Time.deltaTime * fireForce);
        rb2D.velocity = (direct * fireForce);
    }

    public void fire(Vector3 d)
    {
        direct = d;
        // print(direction);
        //rb2D.AddForce(d * fireForce,ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player"))
        {
            Instantiate(ps,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        print("collision");
    }
}
