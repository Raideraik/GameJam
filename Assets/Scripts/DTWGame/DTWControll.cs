using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTWControll : UIActivator
{
    public override void ActivateUI()
    {
        DTWUI.Instance.ActivateGame();
    }
}
