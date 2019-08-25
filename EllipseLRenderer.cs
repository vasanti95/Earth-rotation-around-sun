using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineAlignment))]
public class EllipseLRenderer : MonoBehaviour {

    public LineRenderer lr;

    public Ellipse elipse;

    [Range(0, 100)]
    public int segments;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateElipse();
    }

    //Generate eliptical shape
    void CalculateElipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {

            Vector2 Pos2d = elipse.Evaluate((float)i / (float)segments);
            points[i] = new Vector3(Pos2d.x,0f, Pos2d.y);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    private void OnValidate()
    {
        if(Application.isPlaying && lr!=null)
        {
            CalculateElipse();
        }
       
    }


}
