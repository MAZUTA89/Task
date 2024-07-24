using UnityEngine;

public static class MouseExtention
{
    static Transform s_playerTransform;
    public static void Init(Transform playerTransform)
    {
        s_playerTransform = playerTransform;
    }

    public static Vector3 GetMousePosition()
    {
        Plane plane = new Plane(Vector3.up, s_playerTransform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);

            return targetPoint;

        }
        else
        {
            return s_playerTransform.forward;
        }
    }
}

