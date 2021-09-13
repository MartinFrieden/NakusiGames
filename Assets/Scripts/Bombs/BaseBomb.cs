using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBomb : MonoBehaviour
{
    public abstract int Damage { get; set; }

    List<GameObject> charactersOnFire = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        charactersOnFire.Clear();
        Explosion();

        foreach (var item in Physics.OverlapSphere(gameObject.transform.position, 10, LayerMask.GetMask("Character")))
        {
            if (item.GetComponent<CharacterView>() != null)
            {
                charactersOnFire.Add(item.gameObject);
            }
        }

        Debug.Log("CharCount" + charactersOnFire.Count);

        foreach (var item in charactersOnFire)
        {
            if (!Physics.Raycast(gameObject.transform.position + new Vector3(0,0.3f,0), item.transform.position - gameObject.transform.position, Vector3.Distance(gameObject.transform.position, item.transform.position), LayerMask.GetMask("Default")))
            {
                Debug.Log("DAMAGE");
                item.GetComponent<CharacterFacade>().TakeDamage(Damage);
                Debug.DrawRay(gameObject.transform.position, item.GetComponent<CharacterFacade>().Position - gameObject.transform.position, Color.red);
            }
        }

        Destroy(this.gameObject);
    }

    public abstract void Explosion();
}
