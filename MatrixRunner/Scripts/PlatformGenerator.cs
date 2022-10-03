using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float distanceThreshold;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;
    [SerializeField] private GameObject agentSmith;
    [SerializeField] private GameObject redPill;
    [SerializeField] private GameObject bluePill;
    private Vector3 nextPlatformPos = Vector3.zero;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(platform, nextPlatformPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(nextPlatformPos, player.transform.position) < distanceThreshold)
        {
            /* GameObject plat = Instantiate(platform, nextPlatformPos, Quaternion.identity);
             int binary = Random.Range(0, 2);
             obstacle1.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-20, -21));
             obstacle2.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-20, -21));
             obstacle3.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-20, -21));
             GameObject obs1 = Instantiate(obstacle1, nextPlatformPos + obstacle1.transform.position, Quaternion.identity);
             GameObject obs2 = Instantiate(obstacle2, nextPlatformPos + obstacle2.transform.position, Quaternion.identity);
             GameObject obs3 = Instantiate(obstacle3, nextPlatformPos + obstacle3.transform.position, Quaternion.identity);
             obs1.transform.parent = plat.transform;
             obs2.transform.parent = plat.transform;
             obs3.transform.parent = plat.transform;*/
            GameObject plat = Instantiate(platform, nextPlatformPos, Quaternion.identity);
            for (int i = 0; i < Random.Range(1,4); i++)
            {
                obstacle1.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-20, -21) * i + 1);
                obstacle2.transform.position = new Vector3(Random.Range(2, -3), 1, Random.Range(-20, -21) * i + 1);
                GameObject obs1 = Instantiate(obstacle1, nextPlatformPos + obstacle1.transform.position, Quaternion.identity);
                GameObject obs2 = Instantiate(obstacle2, nextPlatformPos + obstacle2.transform.position, Quaternion.identity);
                obs1.transform.parent = plat.transform;
                obs2.transform.parent = plat.transform;
            }
            for (int i = 0; i < Random.Range(0,3) ; i++)
            {
                agentSmith.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-19, -20) * i + 1);
                GameObject agent = Instantiate(agentSmith, nextPlatformPos + agentSmith.transform.position, Quaternion.identity);
                agent.transform.parent = plat.transform;
            }
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                bluePill.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-19, -20) * i + 1);
                GameObject bPill = Instantiate(bluePill, nextPlatformPos + bluePill.transform.position, Quaternion.identity);
                bPill.transform.parent = plat.transform;
            }
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                redPill.transform.position = new Vector3(Random.Range(-2, 3), 1, Random.Range(-19, -20) * i + 1);
                GameObject rPill = Instantiate(redPill, nextPlatformPos + redPill.transform.position, Quaternion.identity);
                rPill.transform.parent = plat.transform;
            }

            nextPlatformPos += new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), 55);

        }
    }
    private Vector3 generatePos()
    {
        int x, y, z;
        x = Random.Range(-2, 3);
        y = 1;
        z = Random.Range(Mathf.RoundToInt(platform.transform.position.z), Mathf.RoundToInt(nextPlatformPos.z));
        return new Vector3(x, y, z);
    }
}