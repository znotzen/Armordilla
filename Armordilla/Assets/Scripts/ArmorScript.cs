using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorScript : MonoBehaviour
{
    public Animator anim;

    void Update()
    {

        //E = Eat
        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("Eat", true);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            anim.SetBool("Eat", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Brace
            anim.SetBool("Brace", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //End Brace
            anim.SetBool("Brace", false);
        }

    }
}
