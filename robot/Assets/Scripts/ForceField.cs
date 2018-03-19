using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceField : MonoBehaviour {

    public GameObject forceField;
    public bool activated = false;

	public float maximum_shield = 200f;
    public float total_resistance = 200f;
    public float drain_rate = 0.5f;
    public float replenish_rate = 1f;

    public Vector3 maxSize = new Vector3(40f, 40f, 40f);
    public Vector3 minSize = new Vector3(0f, 0f, 0f);

	public Slider shieldBar;

    private bool isScaling = false;


    // Use this for initialization
    void Start () {
        this.transform.localScale = minSize;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.G))
        {
            activated = !activated;
        }

        //stop force field when is all used
        if(total_resistance < 0f)
        {
            activated = false;
        }

        // if the force field is activated
        if(activated)
        {
            if(!isScaling)
            {
                StartCoroutine(ScaleOverTime(0.5f, maxSize));
            }

            total_resistance -= drain_rate;


            //this.transform.localScale = maxSize
        }

        if (!activated)
        {
			if(!isScaling && this.transform.localScale != minSize)
            {
                StartCoroutine(ScaleOverTime(0.5f, minSize));
            }

			if(total_resistance < maximum_shield)
            {
                total_resistance += replenish_rate;
            }
            //this.transform.localScale = minSize;
        }
	
		shieldBar.value = calculateForceField ();
    }

	float calculateForceField()
	{
		return total_resistance / maximum_shield;
	}

    IEnumerator ScaleOverTime(float time, Vector3 finalSize)
    {
        float currentTime = 0f;

        Vector3 currentSize = this.transform.localScale;

        isScaling = true;

        do
        {
            this.transform.localScale = Vector3.Lerp(currentSize, finalSize, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        isScaling = false;

    }
}
