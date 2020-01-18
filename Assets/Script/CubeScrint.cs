using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScrint : MonoBehaviour
{
    public static CubeScrint current;

    private void OnMouseDown()
    {
        if(GetComponent<Renderer>().material.color != Color.blue)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        
    }
}
