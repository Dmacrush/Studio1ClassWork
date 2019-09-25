using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : StateBase
{
    
    public override void Execute()
    {
        transform.localScale += new Vector3(-0.1f,-0.1f,-0.1f);
        base.Execute();
    }
}
