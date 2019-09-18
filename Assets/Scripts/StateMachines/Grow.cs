using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : StateBase
{
    
   public override void Execute()
   {
      transform.localScale += new Vector3(0.1f,0.1f,0.1f);
      base.Execute();
   }
}
