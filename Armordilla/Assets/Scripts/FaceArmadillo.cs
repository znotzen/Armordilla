using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceArmadillo : MonoBehaviour
{
    public GameObject Armadillo;
    public GameObject Gunner1;
    public GameObject Gunner2;
    public GameObject Gunner3;
    public GameObject Gunner4;
    public GameObject GunnerHorse;
    private void Start()
    {
        Armadillo = GameObject.FindGameObjectWithTag("Arm");
        Gunner1 = GameObject.FindGameObjectWithTag("Gunner1");
        Gunner2 = GameObject.FindGameObjectWithTag("Gunner2");
        Gunner3 = GameObject.FindGameObjectWithTag("Gunner3");
        Gunner4 = GameObject.FindGameObjectWithTag("Gunner4");
    }
    void Update()
    {
        //Debug.Log(DoNotFace);

        if (this.gameObject == Gunner1)
        {
            FaceArm(-90);
        }
        else if (this.gameObject == Gunner2)
        {
            FaceArm(-50);
        }
        else if (this.gameObject == Gunner3)
        {
            FaceArm(-50);
        }
        else if (this.gameObject == Gunner4)
        {
            FaceArm(20);
        }


    }
    void FaceArm(int offset)
    {
        var dx = this.transform.position.x - Armadillo.transform.position.x;
        var dy = this.transform.position.y - Armadillo.transform.position.y;
        var radians = Mathf.Atan2(dy, dx);
        var rotateZ = radians * 180 / Mathf.PI + offset;

        this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, rotateZ);
    }

}
