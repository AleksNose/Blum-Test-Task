using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> characters;

    private void Awake()
    {
        foreach (var character in characters)
        {
            if (character == null)
                continue;

            character.Setup();
        }
    }

    private void FixedUpdate()
    {
        foreach (var character in characters)
        {
            if (character == null)
                continue;

            character.MyUpdate();
        }
    }
}
