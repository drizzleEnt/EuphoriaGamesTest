using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] protected UIScreen _nextScreen;

    public virtual void Init(int cubeCount, int sphereCount, int culinderCount)
    {

    }

    protected virtual void SwitchScreen()
    {
        _nextScreen.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
