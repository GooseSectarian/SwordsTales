﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxEffect : MonoBehaviour
{
    private float length, startpos;
    private SpriteRenderer _spriteRenderer;
    
    public GameObject cam;
    public float parallaxEffect;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _spriteRenderer.flipX = false;
        var position1 = cam.transform.position;
        float dist = position1.x * (1 - parallaxEffect) ;
        float temp = position1.x * parallaxEffect;
        
        var position = transform.position;
        position = new Vector3(startpos + dist, position.y, position.z);
        transform.position = position;
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
