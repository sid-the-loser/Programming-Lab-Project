using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    static Controls controls;

    public static void Init(Player player)
    {
        controls = new Controls();

        controls.Ingame.Move.performed += WASD => { player.setMoveDirection(WASD.ReadValue<Vector2>()); }; // Movement controlls

        controls.Ingame.Jump.performed += JUMP => { player.Jump(); }; // calls Jump function when space-bar is pressed

        controls.Ingame.Crouch.performed += CROUCH => { player.Crouch(); }; // calls Crouch function when Control is pressed

        controls.Permanent.Enable(); // Enables "Permanent" controls
    }

    public static void GameMode() // Function called to initiate GameMode controls and disabling UI controls
    {
        controls.Ingame.Enable();
        controls.UI.Disable();
    }

    public static void UIMode() // Function called to disable GameMode controls and enabling UI controls
    {
        controls.UI.Enable();
        controls.Ingame.Disable();
    }
}
