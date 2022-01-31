using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _rotateLeft = KeyCode.E;
    [SerializeField] private KeyCode _rotateRight = KeyCode.Q;
    [SerializeField] private KeyCode _down = KeyCode.S;

    private ICommandHandler commandHandler;

    public void Init(ICommandHandler handler)
    {
        commandHandler = handler;
    }

    void  LateUpdate()
    {
        if (Input.GetKeyDown(_right))
        {
            commandHandler.HandleCommand(Command.Right);
        }
        else if (Input.GetKeyDown(_left))
        {
            commandHandler.HandleCommand(Command.Left);
        }
        else if (Input.GetKeyDown(_rotateLeft))
        {
            commandHandler.HandleCommand(Command.RotateLeft);
        }
        else if (Input.GetKeyDown(_rotateRight))
        {
            commandHandler.HandleCommand(Command.RotateRight);
        }
        else if (Input.GetKey(_down))
        {
            commandHandler.HandleCommand(Command.Down);
        }
    }
}

