using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretWeapon;
    public Transform target;

    public int Health;
    public int PointsGiven;
    public AudioSource explodeSFX;
    public AudioSource getHitSFX;

    float ShotTimer = 0f;
    public const float ShotReset = 1.0f;

    public float turretSpeed;

    private EnemyBase myEnemyBase;
    private Rigidbody myRigidbody;

    public GameObject Explosion;

    private void Start()
    {
        myEnemyBase = GetComponent<EnemyBase>();
        myRigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("Ship").transform;
        turretSpeed = GameObject.Find("Terrain Manager").GetComponent<TerrainManager>().terrainSpeed;
        ResetShotTimer();
    }

    private void FixedUpdate()
    {

        if (transform.position.z <= 500)
        {
            if (target != null)
            {
                turretWeapon.LookAt(target);
            }
        }
        
        if (myEnemyBase.Active)
        {
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            transform.Translate(-Vector3.forward * turretSpeed * Time.deltaTime);
        }
        else
        {
            myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
        if (transform.position.z < 0)
        {
            Despawn();
        }
    }

    private void Update()
    {
        if (transform.position.z <= 500)
        {
            ShotTimer -= Time.deltaTime;

            if (ShotTimer <= 0)
            {
                gameObject.GetComponent<Shoot>().Fire();
                ResetShotTimer();
            }
        }
    }

    private void ResetShotTimer()
    {
        ShotTimer = ShotReset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerLaser")
        {

            TakeDamage(collision.gameObject.GetComponent<Damage>().damage);
        }
    }

    private void TakeDamage(int damage)
    {
        getHitSFX.Play();
        Health -= damage;
        if (Health <= 0)
        {
            StartCoroutine("TurretDeathRoutine");
        }
    }

    private void Despawn()
    {
        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        Destroy(gameObject);
    }

    IEnumerator TurretDeathRoutine()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        gameObject.transform.position = new Vector3(10000, 10000, 10000);
        GameObject player = GameObject.Find("Ship");
        player.GetComponent<Combo>().Add();
        player.GetComponent<Score>().ScoreChange(PointsGiven);
        player.GetComponent<PowerUp>().Add(GetComponent<Charge>().charge);
        explodeSFX.Play();

        GameObject.Find("EventManager").GetComponent<EventManager>().EndLevelList.Remove(gameObject);
        yield return new WaitForSeconds(explodeSFX.clip.length);

        Destroy(gameObject);
    }
}
