﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
    public float speed =5;
    public float angularSpeed = 30;

    // add a player code, which helps to different controls.
    public float number =1;

    public AudioClip idelAudio;
    public AudioClip drivingAudio;
    private AudioSource audio;


    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start() {
        rigidbody = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        float v = Input.GetAxis("VerticalPlayer"+number);
        rigidbody.velocity= transform.forward*v*speed;

        float h = Input.GetAxis("HorizontalPlayer"+number);
        if(v>=0){
            rigidbody.angularVelocity = transform.up*h*angularSpeed;
        }else{
            rigidbody.angularVelocity = -transform.up*h*angularSpeed;
        }


        if(Mathf.Abs(h)>0.1||Mathf.Abs(v)>0.1){
            audio.clip=drivingAudio;
            if(audio.isPlaying==false)
                audio.Play();
        }else{
            audio.clip=idelAudio;
            audio.Play();
        }
    }
}
