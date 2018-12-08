﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollisionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
}
