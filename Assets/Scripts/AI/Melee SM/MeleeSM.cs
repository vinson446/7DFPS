using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSM : StateMachine
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeState<MeleeCheckState>();
    }
}
