
public interface IHealth
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; }

    public void IncreaseHealth(float value);
    public void ReduceHealth(float value);
}