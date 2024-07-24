using BonusesLojic;
using PlayerCode;

namespace BonusLogic.Boosts
{
    public abstract class BoostTrigger : BonusTrigger
    {
        protected PlayerBoosts PlayerBoosts;
        public override void Initialize(Player player)
        {
            base.Initialize(player);
            PlayerBoosts = Player.PlayerBoosts;
        }
    }
}
