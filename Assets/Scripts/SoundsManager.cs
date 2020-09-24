using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public float timePlayerSound;
    private void Update()
    {
        if(timePlayerSound <= 0)
        {
            int random = Random.Range(0, this.transform.GetChild(1).childCount);
            timePlayerSound = this.transform.GetChild(1).GetChild(random).GetComponent<AudioSource>().clip.length;
            this.transform.GetChild(1).GetChild(random).GetComponent<AudioSource>().Play();
            Debug.Log(random);
        }
        else
        {
            timePlayerSound -= Time.deltaTime;
        }
    }
}
