using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandlerInitializer : MonoBehaviour
{
    [SerializeField] private PauseManager _pauseManager;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private SimplePlayerAttack _simplePlayerAttack;
    [SerializeField] private UltimatePlayerAttack _ultimatePlayerAttack;

    void Start()
    {
        _pauseManager.Register(new GamePauseBehaviour());
        _pauseManager.Register(_characterController);
        _pauseManager.Register(_simplePlayerAttack);
        _pauseManager.Register(_ultimatePlayerAttack);
    }
}
