using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : myceliaNet {

    private float counter;
    public float lineDrawSpeed = 6f;
    private LineRenderer lineRenderer;
    private float dist;
    public myceliaNet myce;
    Transform origin;
    Transform destination;
    int q = 1;

    // Update is called once per frame
    void Update() {
        if (myce.initTime > 1)
        {
            destination = myce.plantList[1].transform;
            origin = myce.plantList[0].transform;
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetWidth(2f, 2f);
            lineRenderer.SetVertexCount(myce.plantList.Count);
            dist = Vector3.Distance(origin.position, destination.position);
            myce.initTime = 0;
        }
        /*
        destination = myce.plantList[c + 1].transform;
        origin = myce.plantList[c].transform;
        dist = Vector3.Distance(origin.position, destination.position);
        Debug.Log("dist is : "+dist);
        if (c < myce.plantList.Count - 1)
        {
            Debug.Log("c is " + c);
            c++;
        }*/
        //Vector3 pointA = myce.plantList[c].transform.position;
        //Vector3 pointB = myce.plantList[c + 1].transform.position;
       /* if (counter < dist)
        {
            //int y = 0;
            destination = myce.plantList[c+1].transform;
            origin = myce.plantList[c].transform;
            dist = Vector3.Distance(origin.position, destination.position);
            Debug.Log("hi");
            counter += .1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            Vector3 pointAlongline = x * Vector3.Normalize(pointB - pointA) + pointA;
            c++;
            Debug.Log("hello");
            //lineRenderer.SetPosition(q, pointAlongline);
            //lineRenderer.SetPosition(q, pointAlongline);
            for( int k = 1; k < myce.plantList.Count; k++)
            {
                lineRenderer.SetPosition(k, pointAlongline);
            }
            



        }*/
        
        if (q == 1)
        { 
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(1, pointB);
            q++;
        }
        if (q == 2)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(2, pointB);
            q++;
        }
        if (q == 3)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(3, pointB);
            q++;
        }
        if (q == 4)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(4, pointB);
            q++;
        }
        if (q == 5)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(5, pointB);
            q++;
        }
        if (q == 6)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(6, pointB);
            q++;
        }
        if (q == 7)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(7, pointB);
            q++;
        }
        if (q == 8)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(8, pointB);
            q++;
        }
        if (q == 9)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(9, pointB);
            q++;
        }
        if (q == 10)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(10, pointB);
            q++;
        }
        if (q == 11)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(11, pointB);
            q++;
        }
        if (q == 12)
        {
            destination = myce.plantList[q + 1].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(12, pointB);
            q++;
        }
        if (q == 13)
        {
            destination = myce.plantList[0].transform;
            origin = myce.plantList[q].transform;
            Vector3 pointA = origin.transform.position;
            Vector3 pointB = destination.transform.position;
            lineRenderer.SetPosition(13, pointB);
            q++;
        }
    }
}
