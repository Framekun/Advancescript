using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour, IUpgradeItem
{
    public void GiveUpgrade(PlayerMovement player)
    {
        if (player.gameObject.TryGetComponent(out PlayerSplint sprintAbility))
        {
            sprintAbility.EnableSprint();
        }
    }
}
