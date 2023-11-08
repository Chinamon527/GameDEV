using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegeSystem : MonoBehaviour
{
    public static MessegeSystem intance;
    private void Awake()
    {
        intance = this;
    }

    [SerializeField] GameObject damageMassage;

    List<TMPro.TextMeshPro> messagePool;
    int objectCount = 10;
    int count;
    private void Start()
    {
        messagePool = new List<TMPro.TextMeshPro>();
        
        for (int i = 0; i < objectCount; i++)
        {
            Populate();
        }
    }
    public void Populate ()
    {
        GameObject go = Instantiate(damageMassage, transform);
        messagePool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }
    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count += 1;
        
        if(count >= objectCount)
        {
            count = 0;
        }
    }
}
