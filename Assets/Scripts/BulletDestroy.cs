using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public GameObject key;

    private float destroyTimer = 0.5f;

    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            GameObject keyClone = Instantiate(key, collision.gameObject.transform.GetChild(0).position, transform.rotation);
            keyClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 600f));
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Destroyable")){
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
