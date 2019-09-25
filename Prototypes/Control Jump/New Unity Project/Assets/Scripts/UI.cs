using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public ChargeJump chargeJump;
    public AirBorne airBorne;

    public Text jumpPressure;
    public Text hoverTime;

    public void Update()
    {
        jumpPressure.text = "Charge Jump: " + chargeJump.jumpPressure.ToString();
        hoverTime.text = "Hover Time: " + airBorne.timer.ToString();
    }
}
