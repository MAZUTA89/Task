
using UnityEngine;

namespace DangerZoneCode
{
    public interface IDangerZoneFactory
    {
        DangerZone Create(Vector3 position);
    }
}
