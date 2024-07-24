
namespace EnemyLogic
{
    public interface IEnemy
    {
        int HP { get; set; }
        int ScorePoints { get; }
        float SpawnChance { get; }
        void TakeDamage(int damage);
    }
}
