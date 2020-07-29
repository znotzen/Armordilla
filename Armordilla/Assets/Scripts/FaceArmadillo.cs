using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceArmadillo : MonoBehaviour
{
    public GameObject Armadillo;
    private void Start()
    {
        Armadillo = GameObject.FindGameObjectWithTag("Arm");
    }
    void Update()
    {
        FaceArm();
    }
    void FaceArm()
    {
        Vector3 ArmPosition = Armadillo.transform.position;
        ArmPosition = Camera.main.ScreenToWorldPoint(ArmPosition);

        Vector2 direction = new Vector2(
            ArmPosition.x + this.transform.position.x,
            ArmPosition.y + this.transform.position.y
            );

        //transform.up     = direction;
    }
}
