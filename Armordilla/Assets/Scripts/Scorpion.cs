using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorpion : MonoBehaviour
{
    public GameObject Armadillo;
    public Animator ArmadilloAnim;
    public bool OnScorpion = false;
    public float ScorpionCount;
    public float MaxSC = 1.5f;

    public ScorpionBar scorpionBar;
    public GameObject Point3;

    public ArmadilloMovement armadilloMovement;

    private void Start()
    {
        Armadillo = GameObject.FindGameObjectWithTag("Arm");
        ArmadilloAnim = Armadillo.GetComponent<Animator>();
        ScorpionCount = 0;
        scorpionBar.SetMaxOnSlider(MaxSC);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arm")
        {
            OnScorpion = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Arm")
        {
            OnScorpion = false;
        }
    }

    private void Update()
    {
        if (ArmadilloAnim.GetBool("Eat") == true && OnScorpion == true)
        {
            ScorpionCount += Time.deltaTime;
            scorpionBar.SetSlider(ScorpionCount);
        }

        if (ScorpionCount > MaxSC)
        {
            Instantiate(Point3, this.transform.position, this.transform.rotation);
            armadilloMovement.UpdateScore(3);
            Destroy(this.gameObject);
        }
    }

}
