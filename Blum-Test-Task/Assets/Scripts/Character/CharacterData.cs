using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [field:SerializeField]
    public int Life
    {
        get;
        private set;
    }

    [field: SerializeField]
    public float Speed
    {
        get;
        private set;
    }

    [field: SerializeField]
    public int JumpAmount
    {
        get;
        private set;
    }

    [field: SerializeField]
    public float Fall
    {
        get;
        private set;
    }

    [field: SerializeField]
    public float TimeAtacking
    {
        get;
        private set;
    }

}
