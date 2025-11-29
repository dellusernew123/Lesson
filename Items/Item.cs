using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private ParticleSystem _particle;

    public bool IsItemEquipped { get; protected set; } = false;

    private void Start()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
    }


    protected void ActivateParticle()
    {
        _particle.Play();
    }

    protected void ActivateSeparateParticle()
    {
        _particle.transform.parent = transform.parent;
        _particle.Play();
    }
    
    public abstract void Use(GameObject player);

    public void EquipItem()
    {
        IsItemEquipped = true;
    }
}
