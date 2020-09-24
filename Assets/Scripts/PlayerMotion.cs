using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class PlayerMotion : MonoBehaviour
{
    public float horizontal_Multiplier = 10;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private UnityArmatureComponent armatureComponent;
    private void Start()
    {
        armatureComponent = GetComponent<UnityArmatureComponent>();
        //spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        this.transform.position += new Vector3(UltimateJoystick.GetHorizontalAxis("Movement"), 0, 0) 
            * horizontal_Multiplier * Time.deltaTime;
        Debug.Log("Speed: " + UltimateJoystick.GetHorizontalAxis("Movement"));
        if(UltimateJoystick.GetHorizontalAxis("Movement") > 0.01f)
        {
            //spriteRenderer.flipX = false;
            string status = armatureComponent.armature.animation.lastAnimationName.ToString();
            if(status == "Idle")
            {
                armatureComponent.animation.GotoAndPlayByTime("Run");
            }
            
            armatureComponent.armature.flipX = false;
            //animator.SetBool("Run", true);
        }
        else if(UltimateJoystick.GetHorizontalAxis("Movement") < -0.01f)
        {
            //spriteRenderer.flipX = true;
            string status = armatureComponent.armature.animation.lastAnimationName.ToString();
            if(status == "Idle")
            {
                armatureComponent.animation.GotoAndPlayByTime("Run");
            }
            armatureComponent.armature.flipX = true;
            //animator.SetBool("Run", true);
        }
        else
        {
            string status = armatureComponent.armature.animation.lastAnimationName.ToString();
            if(status == "Run")
            {
                armatureComponent.animation.GotoAndPlayByTime("Idle");
            }
            //animator.SetBool("Run", false);
        }
    }
}
