using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    [SerializeField] private string TargetName;
    [SerializeField] private bool GainBool;
    public delegate void addAttackIndex(bool gainbool);
    public addAttackIndex AddAttackIndex;
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
            AddAttackIndex.Invoke(GainBool);
            OnDestroyTarget();
        }
    }
}
