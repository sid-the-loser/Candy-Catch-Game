using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    static Controls _controls;

    public static void Init(Player _player)
    {
        _controls = new Controls();

        _controls.Ingame.Enable();

        _controls.Ingame.LeftRight.performed += LR => { _player.SetMovementDir(LR.ReadValue<Vector2>()); };
    }
}
