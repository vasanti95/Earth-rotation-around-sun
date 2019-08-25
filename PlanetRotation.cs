using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

    public static PlanetRotation instance;

    public Transform orbitingObject;
    public Ellipse orbitPath;

    public float orbitSpeed;

    [Range(0,1)]
    public float orbitProgress=0;

    public float orbitPeriod;
    public static bool orbitActive;
    //public float planetDistance = 19.83f;


	//for Earth speed required to rotate around sun=(distance travelled/secound)/Time
	// Here we need timeperiod means orbit period
	// so Time=ditance/speed
	// time(orbitPeriod)=149.6*10^6(distance traveled by earth)/29.8(earth speed)
	// orbitSpeed=1f/orbitPeriod

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
        }
        else
        {
            orbitActive = true;
        }
        //set orbitingObject position
        SetOrbitingObjectPosition();
        //if(earthobject) start animation orbitingObject
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(-orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    public IEnumerator AnimateOrbit()
    {
        if (orbitPeriod <= 1f)
        {
            orbitPeriod = 0.1f;
        }
        orbitSpeed = (1f / orbitPeriod);

        Debug.Log("orbit active : "+orbitActive);

        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;
        }

    }

}
