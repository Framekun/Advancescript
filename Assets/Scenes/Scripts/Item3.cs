using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour, IUpgradeItem
{
    public void GiveUpgrade(PlayerMovement player)
    {
        PlayerStatController.Instance.EnableSprint();

        /*
        if (player.gameObject.TryGetComponent(out PlayerSplint sprintAbility))
        {
            sprintAbility.EnableSprint();
        }
        */
    }
}
