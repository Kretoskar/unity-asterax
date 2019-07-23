#define DEBUG_PlayerShip_RespawnNotifications

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{

    private JumpsManager jumpsManager;

    // This is a somewhat protected private singleton for PlayerShip
    static private PlayerShip   _S;
    static public PlayerShip    S
    {
        get
        {
            return _S;
        }
        private set
        {
            if (_S != null)
            {
                Debug.LogWarning("Second attempt to set PlayerShip singleton _S.");
            }
            _S = value;
        }
    }

    [Header("Set in Inspector")]
    public float        shipSpeed = 10f;
    public float        secondsToRespawn = 3f;
    public GameObject   bulletPrefab;

    Rigidbody           rigid;


    void Awake()
    {
        jumpsManager = FindObjectOfType<JumpsManager>();

        S = this;

        // NOTE: We don't need to check whether or not rigid is null because of [RequireComponent()] above
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Using Horizontal and Vertical axes to set velocity
        float aX = CrossPlatformInputManager.GetAxis("Horizontal");
        float aY = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 vel = new Vector3(aX, aY);
        if (vel.magnitude > 1)
        {
            // Avoid speed multiplying by 1.414 when moving at a diagonal
            vel.Normalize();
        }

        rigid.velocity = vel * shipSpeed;

        // Mouse input for firing
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }


    void Fire()
    {
        // Get direction to the mouse
        Vector3 mPos = Input.mousePosition;
        mPos.z = -Camera.main.transform.position.z;
        Vector3 mPos3D = Camera.main.ScreenToWorldPoint(mPos);

        // Instantiate the Bullet and set its direction
        GameObject go = Instantiate<GameObject>(bulletPrefab);
        go.transform.position = transform.position;
        go.transform.LookAt(mPos3D);
    }

    static public float MAX_SPEED
    {
        get
        {
            return S.shipSpeed;
        }
    }
    
	static public Vector3 POSITION
    {
        get
        {
            return S.transform.position;
        }
    }

    /// <summary>
    /// Respawns player's ship in a safe place at the screen
    /// Safe place means a place, where there are no asteroids
    /// </summary>
    public void Respawn()
    {
        gameObject.SetActive(false);
        jumpsManager.Jumps--;
        Invoke("Spawn", secondsToRespawn);
    }

    /// <summary>
    /// Spawn the player ship
    /// </summary>
    private void Spawn()
    {
        gameObject.transform.position = CalculateSpawnPosition();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Calculate the safe position to spawn
    /// </summary>
    /// <returns>Safe position to spawn</returns>
    private Vector3 CalculateSpawnPosition()
    {
        int safeDistance = 5;
        Vector3 spawnPosition = Vector3.zero;
        foreach (Asteroid asteroid in FindObjectsOfType<Asteroid>()) {
            do
            {
                spawnPosition = RandomizeSpawnPosition();
            } while (Vector3.Distance(spawnPosition, asteroid.transform.position) <= safeDistance);
        }
        return spawnPosition;
    }

    /// <summary>
    /// Get a random spawn position in screen bounds
    /// </summary>
    /// <returns>Random vector3 in screen bounds</returns>
    private Vector3 RandomizeSpawnPosition()
    {
        float x = UnityEngine.Random.Range(-15, 15);
        float y = UnityEngine.Random.Range(-8, 8);
        return new Vector3(x, y, 0);
    }
}
