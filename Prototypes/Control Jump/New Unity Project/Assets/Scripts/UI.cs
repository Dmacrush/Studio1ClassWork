using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public ChargeJump chargeJump;
    public AirBorne airBorne;

    //public Text jumpPressure;
    public Text hoverTime;
    public Text forwardForce;

    private Vector3 currentEulerAngles;
    private Quaternion rot;

    public Slider jumpPressureBar;
    //public Slider angleBar;

    public void Start()
    {

        //angleBar.maxValue = chargeJump.maxForwardForce;
        jumpPressureBar.maxValue = chargeJump.maxJumpPressure;
        
    }
    public void Update()
    {
        currentEulerAngles = new Vector3(0, 0, chargeJump.forwardForce);
        rot.eulerAngles = currentEulerAngles;
        jumpPressureBar.transform.rotation = rot;
        //angleBar.maxValue = chargeJump.maxForwardForce;
        jumpPressureBar.maxValue = chargeJump.maxJumpPressure;
        forwardForce.text = "Forward Force: " + chargeJump.forwardForce.ToString("F0");
        //jumpPressure.text = "Charge Jump: " + chargeJump.jumpPressure.ToString("F0");
        hoverTime.text = "Hover Time: " + airBorne.timer.ToString("F1");

        //angleBar.value = chargeJump.forwardForce;
        jumpPressureBar.value = chargeJump.jumpPressure;
        
    }
}
