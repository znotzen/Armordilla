using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorpion : MonoBehaviour
{

    public Animator ArmadilloAnim;
    public bool OnScorpion = false;
    public float ScorpionCount;
    public float MaxSC = 1.5f;

    public ScorpionBar scorpionBar;

    private void Start()
    {
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

        if(ScorpionCount > MaxSC)
        {
            Destroy(this.gameObject);
        }
    }

}
