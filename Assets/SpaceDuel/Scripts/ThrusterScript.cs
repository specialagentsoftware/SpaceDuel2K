using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterScript : MonoBehaviour
{
    public ShipController sc;
    private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sc.currBoost > 0)
        {
            StartCoroutine("ChangeThruster");
        }
    }

    IEnumerator ChangeThruster()
    {
        tr.time = 0.11f;
        tr.startColor = Color.green;
        yield return new WaitForSeconds(1f);
        tr.time = 0.03f;
        tr.startColor = Color.yellow;
    }
}

