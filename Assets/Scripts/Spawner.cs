using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;
    private float time = 3f;
    public Coroutine coroutine;
    public GameObject Fire;
    public GameObject SpawnPoint;
    [SerializeField] private int counter = 0;
    private Stack<GameObject> stack;
    // Start is called before the first frame update
    void Start()
    {
        if (spawner != null && spawner != this)
            Destroy(gameObject);
        spawner = this;
        stack = new Stack<GameObject>();
        coroutine = StartCoroutine(SpawnFire());
    }
    void Update()
    {
    }
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        stack.Push(obj);
    }
    public GameObject Pop()
    {
        GameObject obj = stack.Pop();
        obj.SetActive(true);
        obj.transform.position = SpawnPoint.transform.position;
        return obj;
    }
    public GameObject Peek()
    {
        return stack.Peek();
    }
    public void Stop()
    {
        StopCoroutine(SpawnFire());
    }
    IEnumerator SpawnFire()
    {
        if (stack.Count != 0)
        {
            Pop();
        }
        else
        {
            Instantiate(Fire, SpawnPoint.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        yield return SpawnFire();
    }
}
