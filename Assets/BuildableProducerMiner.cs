using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildableProducerMiner : BuildableProducer
{
    public bool FoundDeposit { get; private set; }

    void Start()
    {
        Transform.FindObjectsOfType<Deposit>().ToList().ForEach(deposit =>
        {
            if (deposit.ResourceSo == BuildableSo.ProducesResources && 
            Vector3.Distance(transform.position, deposit.transform.position) < 10)
            {
                FoundDeposit = true;
            }
        });

        if (!FoundDeposit)
            ActivityMessage = "No Deposit";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Block working if there are no deposits nearby
        if(!FoundDeposit)
            IsWorking = false;
    }
}
