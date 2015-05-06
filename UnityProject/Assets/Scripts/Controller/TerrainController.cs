using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TerrainController : MonoBehaviour
{
    public GameObject refCube;
    public GameObject[] blocks;
    public int step;
    public int vision;
    public GameObject startGameObject;

    private int currentLength;
    private Vector3 position;
    private IList<GameObject> createdTerrainPart;
    private GameObject player;
	// Use this for initialization
	void Start ()
	{
        createdTerrainPart = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        init();
        //createdTerrainPart.Add();
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; player != null && i < createdTerrainPart.Count(); i++)
	    {
	        GameObject o = createdTerrainPart[i];
            if (player != null && player.transform.position.z - o.transform.position.z > 40)
            {
                i = i - 1;
                Destroy(o);
                createdTerrainPart.Remove(o);
            }
	    }
	    if (player != null && (player.transform.position.z/refCube.transform.localScale.z) >= (currentLength - vision))
	    {
	        generateTerrain();
	    }
	}

    public void init()
    {
        currentLength = 4;
        createdTerrainPart.Clear();
        position = new Vector3(0, 0, currentLength * refCube.transform.localScale.z);
        createdTerrainPart.Add((GameObject)Instantiate(startGameObject, new Vector3(0, 0, 0), refCube.transform.rotation));
    }

    void generateTerrain()
    {
        position.z = currentLength*(refCube.transform.localScale.z);
        createdTerrainPart.Add((GameObject)Instantiate(blocks[Random.Range(0, blocks.Count()) % (3 + (currentLength / step))], position, refCube.transform.rotation));
        currentLength += 4;
    }
}
