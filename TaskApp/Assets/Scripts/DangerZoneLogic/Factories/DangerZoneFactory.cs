using PlayerCode;
using UnityEngine;

namespace DangerZoneCode
{
    public class DangerZoneFactory : IDangerZoneFactory
    {
        Player _player;
        DangerZone _template;
        public DangerZoneFactory(DangerZone template, Player player)
        {
            _player = player;
            _template = template;
        }
        public DangerZone Create(Vector3 position)
        {
            DangerZone zone = GameObject.Instantiate(_template, position,
                Quaternion.identity, null);
            zone.Initialize(_player);

            return zone;
        }
    }
}
