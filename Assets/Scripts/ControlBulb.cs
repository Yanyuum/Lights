using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBulb : MonoBehaviour
{
    private  BulbFunctions Bulb;
    private Renderer rend;
    public GameObject target;
    public float EmissionMultiplier = 1;

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
        
        Bulb.ChangeEmission(gameObject,rend,relativeX,EmissionMultiplier); // change the emission value through method ChangeBrightness()
        
        Bulb.RotateToTarget(target,gameObject, 5.0f); // rotate to target object through mathod RotateToTarget()

        //Bulb.ChangeLightIntensity(lights,relativeX,1.0f);
        
        float redness = Bulb.Remap(relativeX,0,1,0,1);
        //Debug.Log(relativeX);

        Bulb.ChangeEmissionColor(gameObject,rend,redness,0,0);
        //Debug.Log(redness);
    }
}
