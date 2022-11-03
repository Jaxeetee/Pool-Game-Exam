using UnityEngine;
using System;
public class RollBall : MonoBehaviour
{
    private Rigidbody _rb;

    public static event Action onCollide;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            //add something upon collision

            onCollide?.Invoke();
            //change 10f value to something based from how hard the cue has been hit
            _rb.AddForce(-collision.transform.position.normalized * 20f, ForceMode.Impulse);
        }
    }
}
