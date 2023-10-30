using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour
{
    [SerializeField] private string TargetName;
    [SerializeField] private bool GainBool;
    public delegate void addJumpSplint(bool gainbool);
    public addJumpSplint AddSpintIndex;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroyTarget()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetName)
        {
            AddSpintIndex.Invoke(GainBool);
            OnDestroyTarget();
        }
    }
}
