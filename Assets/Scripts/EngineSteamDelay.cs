using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSteamDelay : MonoBehaviour
{
    void Wait()
    {
        Waiting();
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
    }
}

