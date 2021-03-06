﻿using UnityEngine;
using System.Collections;

public class Dial : MonoBehaviour
{
    private float pos;
    private int targ;
    void Update()
    {
        float t = targ * 36 + 90;
        float diff = pos - t;
        if(diff <= -180) diff += 360; if(diff > 180) diff -= 360;

        float move = Time.deltaTime * 36 * 5; //takes 0.2s
        if(diff < 0) {
            if(-move < diff) pos = t;
            else {
                pos += move;
                if(pos >= 360) pos -= 360;
            }
        }
        else {
            if(move > diff) pos = t;
            else {
                pos -= move;
                if (pos < 0) pos += 360;
            }
        }

        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, pos));
    }
    
    public void Move(int target) {
        targ = target;
    }

    public void Decrement() {
        Move((targ + 9) % 10);
    }

    public void Increment() {
        Move((targ + 1) % 10);
    }

    public int GetValue() {
        float t = targ * 36 + 90;
        float diff = pos - t;
        if(diff != 0) return -1; //Dial is not ready

        return targ;
    }
}