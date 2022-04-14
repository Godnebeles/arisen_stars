using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int Damage{ get; private set; }
    public int Armor{ get; private set; }
    public float Speed{ get; private set; }
    
    private bool _isInitialized = false;

    public void Initialize(CharacteristicsDTO characteristicsDTO)
    {
        if (_isInitialized)
            return;

        MaxHealth = characteristicsDTO.maxHealth;
        Damage = characteristicsDTO.damage;
        Armor = characteristicsDTO.armor;
        Speed = characteristicsDTO.speed;
        
        _isInitialized = true;
    }
}
