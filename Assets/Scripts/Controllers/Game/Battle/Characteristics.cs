using UnityEngine;

public class Characteristics
{
    public int MaxHealthValue { get; private set; } = 200;
    public readonly int MinHealthValue = 0;
    public int Damage { get; private set; } = 50;
    public int Armor{ get; private set; }
    public float Speed{ get; private set; }
    
    private bool _isInitialized = false;

    public void Initialize(CharacteristicsDTO characteristicsDTO)
    {
        if (_isInitialized)
            return;

        MaxHealthValue = characteristicsDTO.maxHealth;
        Damage = characteristicsDTO.damage;
        Armor = characteristicsDTO.armor;
        Speed = characteristicsDTO.speed;
        
        _isInitialized = true;
    }
}
