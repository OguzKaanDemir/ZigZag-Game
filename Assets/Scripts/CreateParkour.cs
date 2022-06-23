using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParkour : MonoBehaviour
{
    public GameObject LastObj;
    public Move BallMove;
    private GameObject[] parkours;
    byte r, g, b;

    private void Awake()
    {
        BallMove = BallMove.GetComponent<Move>();

    }

    void Start()
    {
        for (int i = 0; i < 35; i++)
        {
            CreateObj();
        }
    }

    private void Update()
    {

        parkours = GameObject.FindGameObjectsWithTag("Platform");

        if (BallMove.clrPoint >= 10)
        {
            RandColor();

            for (int i = 0; i < parkours.Length; i++)
            {
                parkours[i].GetComponent<MeshRenderer>().material.color = new Color32(r, g, b, 120);
                BallMove.GetComponent<MeshRenderer>().material.color = new Color32(r, g, b, 255);
                BallMove.clrPoint = 0;
            }
        }
    }

    public void CreateObj()
    {
        Vector3 yon;
        if (Random.Range(0, 2) == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.forward;
        }
        LastObj = Instantiate(LastObj, LastObj.transform.position + yon, LastObj.transform.rotation);

        
    }

    void RandColor()
    {
        r = (byte)Random.Range(0, 256);
        g = (byte)Random.Range(0, 256);
        b = (byte)Random.Range(0, 256);
    }
}
