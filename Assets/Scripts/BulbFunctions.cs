using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbFunctions
{
    
    /* 
    public float GetDeltaX(GameObject target,GameObject self){  
        float targetX = target.transform.position.x;
        float deltaX = Mathf.Abs(targetX - self.transform.position.x);
        Debug.Log(deltaX);
        return deltaX;
    }
    */

    public float getRelativePosition(GameObject target, GameObject self) {
     Vector3 relativePosition = (target.transform.InverseTransformPoint(self.transform.position)).normalized;
     float temp = Mathf.Abs(relativePosition.x);
     float inverseDistance = 1 - temp;
     return inverseDistance;
     
     }

    public void RotateToTarget(GameObject target , GameObject self  , float turnRate){
        Vector3 targetDelta = target.transform.position - self.transform.position;
        float angleToTarget = Vector3.Angle(self.transform.forward, targetDelta);
        Vector3 turnAxis = Vector3.Cross(self.transform.forward, targetDelta);
        self.transform.RotateAround(self.transform.position, turnAxis, Time.deltaTime * turnRate * angleToTarget);
    }

    public void TurnOnLight(GameObject self , Renderer rend , int a){
        rend = self.GetComponent<Renderer>();
        
        rend.material.SetInt("_enableLight",a);
        /*if(a == 1 && a == 0){
            rend.material.SetInt("_enableLight",a);
        }
        else{
            rend.material.SetInt("_enableLight",0);
        }*/
    }

    public void ChangeBrightness(GameObject self, Renderer rend , float brightness , float multiplier){
        rend = self.GetComponent<Renderer>();
        rend.material.SetFloat("_intensity", brightness* multiplier ); 
    }

    public void ChangeLightColor(GameObject self , Renderer rend , float r, float g, float b ){
        rend = self.GetComponent<Renderer>();
        rend.material.SetColor("_emissionColor",new Color(r,g,b));    
    }

    /*public void GetLightChild(GameObject self){
        //GameObject light = self.GetChild(0).gameObject;
        //light  = GetComponent<Light>();
        //GameObject light = child.GetComponent.<Light>().color = Color.green;
    }*/

    public void ChangeLightIntensity(Light light , float intensityAmount,float multiplier){
        
        if (light != null && intensityAmount >= 0.02f){
            light.intensity = intensityAmount * multiplier;
        }
        else if(light != null && intensityAmount <0.02f){
            light.intensity = 0;
        }
        else{
            Debug.Log("Check Wheather the Child light is Attached");
        }


    }
}
