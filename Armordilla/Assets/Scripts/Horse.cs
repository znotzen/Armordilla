using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public GameObject Arm;
    public GameObject Armadillo;
    public bool DoNotFace;
    public bool HorseMoving = false;

    void Update()
    {
        if(Armadillo.GetComponent<ArmadilloMovement>().score > 10)
        {
            HorseMoving = true;
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 5.5f * Time.deltaTime, this.gameObject.transform.position.y);
        }
        

        if (this.gameObject.transform.position.x >= 15)
        {
            this.gameObject.transform.position = new Vector3(-11.7f,-0.81f,0);
        }
        
        
    }


    //Lining up cowboy's arm when horse runs
    public void RiseArm()
    {
        Arm.transform.position = Arm.transform.position + new Vector3(0, 0.1f, 0);
    }
    public void LowerArm()
    {
        Arm.transform.position = Arm.transform.position - new Vector3(0, 0.1f, 0);
    }
}
