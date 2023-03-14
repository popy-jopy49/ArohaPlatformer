using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    [SerializeField] private string collectableTag;
    int collectables = 0;
    List<GameObject> items = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(collectableTag))
            return;

        Useable comp = collision.GetComponent<Useable>();
        if (comp == null)
        {
            collectables++;
            Destroy(collision.gameObject);
            return;
        }

        comp.Use();
    }

    public void AddItem() => items.Add(gameObject);

}
