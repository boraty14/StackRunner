using UnityEngine;

namespace Utils
{
    public static class UnityUtils
    {
        public static Vector3 ScreenToWorldPosition(Camera camera, Vector3 screenPosition)
        {
            screenPosition.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(screenPosition);
        }
    }
}
