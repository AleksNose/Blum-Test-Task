using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    public string TagEnemy { get; set; }
    private Mushroom enemy;

    public void Attack()
    {
        if (isEnemy)
        {
            enemy.GetPunch();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagEnemy)
        {
            isEnemy = true;
            enemy = collision.GetComponent<Mushroom>();
            return;
        }
        isEnemy = false;
    }
}
