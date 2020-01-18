using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtonScript : MonoBehaviour
{
    public GameObject obj;
    public Button bt;
    public Color cl;

    private string data;

    private void Awake()
    {
        data = File.ReadAllText("Save/" + gameObject.GetInstanceID() + ".txt");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }

    private void Update()
    {
        if(obj.GetComponent<Renderer>().material.color == Color.white)
        {
            bt.GetComponentInChildren<Text>().text = "White";
        }
        else
        {
            bt.GetComponentInChildren<Text>().text = "Blue";
        }
    }

    public void OnButtonDown()
    {
        if (obj.GetComponent<Renderer>().material.color != Color.blue)
        {
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            obj.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void CollectInfo()
    {
        cl = obj.GetComponent<Renderer>().material.color;
    }

    private void SetInfo()
    {
        obj.GetComponent<Renderer>().material.color = cl;
    }

    private void OnApplicationQuit()
    {
        CollectInfo();
        data = JsonUtility.ToJson(this);
        File.WriteAllText("Save/" + gameObject.GetInstanceID() + ".txt", data);
    }
}
