using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RenderExtensions
{
    public static bool isVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

}
