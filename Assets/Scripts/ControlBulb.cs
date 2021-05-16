using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBulb : MonoBehaviour
{
    private  BulbFunctions Bulb;
    private Renderer rend;
    public GameObject target;

    private Light lights;
    

    private void Awake() {
        rend = GetComponent<Renderer>();
        Bulb = new BulbFunctions();
        lights = gameObject.GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        //Bulb.TurnOnLight(gameObject , rend ,1);
        
        float relativeX = Bulb.getRelativePosition(target,gameObject); // set the value of "brightness" through method GetDeltaX()
        
        Bulb.ChangeBrightness(gameObject,rend,relativeX,1.0f); // change the emission value through mathod ChangeBrightness()
        
        Bulb.RotateToTarget(target,gameObject, 5.0f); // rotate to target object through mathod RotateToTarget()

        Bulb.ChangeLightIntensity(lights,relativeX,4.0f);

        //Bulb.ChangeLightColor(gameObject,rend,255,0,0);
    }
}
