using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScript : MonoBehaviour
{
    public Animator anim;

    void Update()
    {

        //E = Eat
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Eat", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("Eat", false);
        }

    }
}
