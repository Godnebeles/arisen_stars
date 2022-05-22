using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Money _money;
    [SerializeField] private Characteristics _playerCharacteristics;

    private void Awake()
    {
        //_playerHealth.OnDeathEvent += OnPlayerDeath;
    }

    private void SaveData()
    {
        SaveStorage saveStorage = new SaveStorage();

        PlayerDataDTO oldPlayerDataDto = saveStorage.Load();
        
        PlayerDataDTO newPlayerDataDto = new PlayerDataDTO()
        {
            playerCharacteristicsDTO = new CharacteristicsDTO()
            {
                maxHealth = _playerCharacteristics.MaxHealthValue,
                armor = _playerCharacteristics.Armor,
                damage = _playerCharacteristics.Damage,
            },
            maxScore = oldPlayerDataDto.maxScore < _score.ScoreValue ? _score.ScoreValue : oldPlayerDataDto.maxScore,
            money = oldPlayerDataDto.money != _money.MoneyValue ? _money.MoneyValue : oldPlayerDataDto.money
        };

        saveStorage.Save(newPlayerDataDto);
    }

    private void LoadData()
    {
        SaveStorage saveStorage = new SaveStorage();
        
        PlayerDataDTO playerDataDto = saveStorage.Load();
        
        _playerCharacteristics.Initialize(playerDataDto.playerCharacteristicsDTO);
        //_money.Initialize(playerDataDto.money);
        //_score.Initialize(playerDataDto.maxScore);
    }
}
