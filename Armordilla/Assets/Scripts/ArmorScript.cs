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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Brace
            anim.SetBool("Brace", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //End Brace
            anim.SetBool("Brace", false);
        }

    }
}
