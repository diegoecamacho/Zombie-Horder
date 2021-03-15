namespace Systems.Health_System
{
    public interface IDamagable
    { 
        void TakeDamage(float damage);
        void Destroy();
    }
}