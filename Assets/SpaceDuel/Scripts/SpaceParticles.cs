using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceParticles : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public float particleSize = 0.1f;
    public float chanceOfParticle = 0.3f;
    public float chanceOfColor = 0.1f;

    public float minDebth = -3f;
    public float maxDebth = 3f;

    public float minSize = 0.1f;
    public float maxSize = 0.2f;

    private float particleDebth;
    private float partSize;
    void Start()
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.velocity = Vector3.zero;
        emitParams.startLifetime = float.MaxValue;
        emitParams.startSize = particleSize;

        for (int x = -50; x <= 50; x++)
        {
            for (int z = -50; z <= 50; z++)
            {
                if (Random.value < chanceOfParticle)
                {
                    particleDebth = Random.value * (maxDebth - minDebth) + minDebth;

                    if (Random.value <= chanceOfColor)
                    {
                        emitParams.startColor = new Color(Random.value, Random.value, Random.value, 1f);
                    }

                    partSize = Random.value * (maxSize - minSize) + minSize;
                    emitParams.startSize = partSize;

                    emitParams.position = new Vector3(x + Random.value, particleDebth, z + Random.value);
                    _particleSystem.Emit(emitParams, 1);
                }
            }
        }
    }
}
