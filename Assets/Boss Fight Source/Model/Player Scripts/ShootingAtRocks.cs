using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Player interaction with rocks*/
public class ShootingAtRocks : MonoBehaviour
{
    public GunScript Gun;
    public GameObject RockWorld;
    Vector3 laserPositon;
    public List<Transform> rocks;
    bool stat; 
    // Start is called before the first frame update
    void Start()
    {
        stat = false;
    }

    // Update is called once per frame
    void Update()
    {
        laserPositon = Gun.getLaser().transform.position;
        
        for (int i = 0; i < rocks.Count; i++) {
            Vector3 temp = laserPositon - rocks[i].position;
            Debug.Log(temp);
            if (temp.magnitude < 5) {
                rocks[i].GetComponent<Renderer>().enabled = false;
            }

            if (rocks[i].GetComponent<Renderer>().enabled == false) {
                stat = true;
                rocks.RemoveAt(i);
            }
        }   
    }

    public bool hitRock() {
        return stat;
    }
}
