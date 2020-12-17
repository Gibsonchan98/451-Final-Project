﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelvinNodePrimitive : MonoBehaviour
{
    public Color MyColor = new Color(0.1f, 0.1f, 0.2f, 1.0f);
    public Vector3 Pivot;
    Matrix4x4 m;
    //public bool ShowRotation = false;
    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
    }


    public void LoadShaderMatrix(ref Matrix4x4 nodeMatrix)
    {
        Matrix4x4 p = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 invp = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
        m = nodeMatrix * p * trs * invp;
        GetComponent<Renderer>().material.SetMatrix("MyXformMat", m);
        GetComponent<Renderer>().material.SetColor("MyColor", MyColor);
    }

    public Matrix4x4 GetPosition()
    {
        return m;
    }
}
