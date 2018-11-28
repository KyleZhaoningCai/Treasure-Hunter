using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarrier : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Threat"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
