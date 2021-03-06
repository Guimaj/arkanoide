using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour
{
    private SpriteRenderer sr;
    public ParticleSystem DestroyEffect;
    public static Color color;
    public int colorType;

    public static event Action<Block> OnBlockDestruction;

    private void Awake()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ball")
        {
            OnBlockDestruction?.Invoke(this);
            SpawnDestroyEffect();

            BlockManager.points += GetPointByColor()[this.colorType];
            BlockManager.totalBlocks--;
            Destroy(this.gameObject);
        }
    }

    private void SpawnDestroyEffect()
    {
        Vector3 brickPos = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(brickPos.x, brickPos.y, brickPos.z - 0.2f);
        GameObject effect = Instantiate(DestroyEffect.gameObject, spawnPosition, Quaternion.identity);

        MainModule mm = effect.GetComponent<ParticleSystem>().main;
        mm.startColor = this.sr.color;
        color = this.sr.color;
        Destroy(effect, DestroyEffect.main.startLifetime.constant);
    }

    public void Init(Transform container, Sprite sprite, Color color, int colorType)
    {
        this.transform.SetParent(container);
        this.sr.sprite = sprite;
        this.sr.color = color;
        this.colorType = colorType;
    }

    private int[] GetPointByColor(){
        int[] points = {5, 10, 15, 20};
        return points;
    }
}
