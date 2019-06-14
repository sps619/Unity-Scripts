using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    #region Fields
    // For Boundary Checking
    static float screenLeft, screenRight, screenTop, screenBottom;

    #endregion

    #region  properties
    // <summary>
    // Gets the left edge of the screen
    // </summary>
    // <value>left edge of the screen</value>
    public static float ScreenLeft
    {
        get { return screenLeft; }
    }
    // <summary>
    // Gets the right edge of the screen
    // </summary>
    // <value> right edge of the screen</value>
    public static float ScreenRight
    {
        get { return screenRight; }
    }
    // <summary>
    // Gets the top edge of the screen
    // </summary>
    // <value>top edge of the screen</value>
    public static float ScreenTop
    {
        get { return screenTop; }
    }
    // <summary>
    // Gets the bottom edge of the screen
    // </summary>
    // <value>bottom edge of the screen</value>
    public static float ScreenBottom
    {
        get { return screenBottom; }
    }

    #endregion
    
    #region Methods
    // <summary>
    // Initialises the screen utilities
    public static void Initialize()
{
// save screen edges in world coordinates
		float screenZ = -Camera.main.transform.position.z;
		Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
		Vector3 upperRightCornerScreen = new Vector3(
			Screen.width, Screen.height, screenZ);
		Vector3 lowerLeftCornerWorld = 
			Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
		Vector3 upperRightCornerWorld = 
			Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
		screenLeft = lowerLeftCornerWorld.x;
		screenRight = upperRightCornerWorld.x;
		screenTop = upperRightCornerWorld.y;
		screenBottom = lowerLeftCornerWorld.y;
}
#endregion
}
