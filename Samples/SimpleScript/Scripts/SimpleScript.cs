using System.Collections;
using ExpressoBits.Pools;
using UnityEngine;

public class SimpleScript : MonoBehaviour
{

    public GameObject prefab;
    private PoolData poolData;

    public IEnumerator Start()
    {
        poolData = new PoolData(new PoolSettings{ IncreaseSize = 10 },prefab);
        
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = this.InstantiateInPool(poolData,new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0f),Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(DelayToDestroy (obj,Random.Range(1f, 5f)));
        }
    }

    private IEnumerator DelayToDestroy(GameObject obj,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.DestroyInPool(obj,poolData);
    }
    
}
