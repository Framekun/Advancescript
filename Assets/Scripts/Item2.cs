using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour, IUpgradeItem
{
    public void GiveUpgrade(PlayerMovement player)
    {
        if (player.gameObject.TryGetComponent(out PlayerAttack playerAttack))
        {
            playerAttack.EnableAttack();
        }
    }
}
