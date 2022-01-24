using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;
    public HealthBar hb;
    public BoostBar bb;
    private float rotation = 0f;
    private float curVelocity = 0f;
    public LaserController lc;
    public float thrustMultiplyer = 300f;
    public float rotationSpeed = 150f;
    public float breakMultiplyer = 0.9944444f;
    public float maxVelocity = 10f;
    public float maxBoost = 100f;
    public float maxHealth = 100f;
    public float currHealth;
    public float currBoost;
    public GameObject laserpoint;
    public Text velocity;
    private bool IsDeadControls = false;
    private bool IsFiring = false;

    public ParticleSystem explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bb.Set_MaxBoost(maxBoost);
        hb.Set_MaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        rotation = rb.rotation.eulerAngles.y;
        curVelocity = rb.velocity.magnitude;
        currBoost = bb.Get_Boost();
        currHealth = hb.Get_Health();

        if (IsDeadControls)
        {
            return;
        }

        if (currBoost == 0)
        {
            bb.Show_Empty();
        }

        if (hb.Get_Health() <= 0f)
        {
            StartCoroutine("Death");
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustMultiplyer * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currBoost > 0)
            {
                StartCoroutine("BoostThrust");
            }
            else if (currBoost == 0)
            {
                bb.Show_Empty();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity *= breakMultiplyer;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotation -= rotationSpeed * Time.deltaTime;
            KillAngularVelocity();
            rb.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotation += rotationSpeed * Time.deltaTime;
            KillAngularVelocity();
            rb.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!IsFiring)
            {
                StartCoroutine("Fire");
            }
        }

        if (curVelocity > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        if (curVelocity < 0.01f)
        {
            rb.velocity = Vector3.zero;
        }

        if (hb.Get_Health() <= 0f)
        {
            StartCoroutine("Death");
        }
    }

    void FixedUpdate()
    {
        velocity.text = ((int)curVelocity).ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        hb.Set_Health(currHealth - 25f);
        rb.AddExplosionForce(20f, rb.position, 7f, 0f, ForceMode.Impulse);
        StartCoroutine("DeadControls");
    }

    IEnumerator DeadControls()
    {
        IsDeadControls = true;
        yield return new WaitForSeconds(.5f);
        IsDeadControls = false;
    }

    IEnumerator Fire()
    {
        IsFiring = true;
        Instantiate(lc, laserpoint.transform.position, rb.rotation);
        yield return new WaitForSeconds(.1f);
        IsFiring = false;
    }

    IEnumerator Death()
    {
        explosion.Play();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator BoostThrust()
    {
        if (currBoost > 0)
        {
            thrustMultiplyer = 800f;
            maxVelocity = 25f;
            yield return new WaitForSeconds(1f);
            thrustMultiplyer = 300f;
            maxVelocity = 10f;
            bb.Set_Boost(currBoost - 25f);
        }
        else if (currBoost == 0f)
        {
            bb.Show_Empty();
        }
    }

    void KillAngularVelocity()
    {
        rb.angularVelocity = Vector3.zero;
    }
}
