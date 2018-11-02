using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitTracker  {

    static bool haveHit=false;

    public static bool HaveHit
    {
        get { return haveHit; }
        set { haveHit = value; }
    }
}
