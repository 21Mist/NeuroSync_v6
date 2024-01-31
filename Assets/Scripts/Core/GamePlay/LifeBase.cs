using TMPro;

public abstract class LifeBase : CardBase
{

    public int totalLife;
    private int currentLife;

    public TextMeshPro textLife;

    protected void Start()
    {
        base.Start();
        currentLife = totalLife;
        textLife.text = currentLife.ToString();
    }

    protected void Update()
    {
        base.Update();
    }

    public void ApplyDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
            OnDie();
    }


    public int GetCurrentLife()
    {
        return currentLife;
    }


    public abstract void OnDamage();
    public abstract void OnDie();



}
