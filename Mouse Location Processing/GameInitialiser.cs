using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialiser : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ScreenUtils.Initialize();
    }
}
