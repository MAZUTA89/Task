using UnityEngine;

public class FPS : MonoBehaviour 
{
    public int FrameRate = 60;

    private void OnValidate()
    {
        Application.targetFrameRate = FrameRate;
    }
}
