using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;
    public string trigger;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger(trigger);
        }
    }
}
