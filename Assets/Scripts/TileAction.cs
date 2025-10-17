using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;

public class TileAction : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public int point;
    public float fallSpeed = 500f;
    [SerializeField] float tapY = -2.65f;
    public float beatTargetY;
    public float beatTime;
    private bool tapped = false;
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (tapped) return;
            FindAnyObjectByType<SpawnAction>().tap.Play();
            float distance = Mathf.Abs(transform.position.y - tapY);
            string accuracy = "Miss";

            if (distance < 0.1f)
            {
                accuracy = "Perfect";
            }
            else if (distance < 0.25f)
            {
                accuracy = "Great";
            }
            else if (distance < 0.4f)
            {
                accuracy = "Good";
            }
            else
            {
                accuracy = "Miss";
            }


            tapped = true;

            FindAnyObjectByType<Score>().ScoreUpdate(accuracy == "Miss" ? 0 : point, accuracy);
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "border")
        {
            Debug.Log("Lose");
          //  FindAnyObjectByType<ClickingEvent>().OpenMenu();
        }
    }
}
