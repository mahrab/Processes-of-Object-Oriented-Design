using UnityEngine;
using System.Collections;

public class StatTracking : MonoBehaviour {
    public GameObject obj;
    public Transform spawn;
    public Texture2D back;
    public Texture2D front; 
    float maxHealth;
    float health;
    int xp;
    int healthBarHieght;
    int level;
    float healthRegen;
    float power;
    int[] Tree = { 125, 250, 500, 1000, 2000, 4000, 8000,16000,32000 };
	// Use this for initialization
	void Start () {
        obj.transform.position = spawn.position;
        health = maxHealth = 100.0f;
        xp = 0;
        level = 0;
        healthRegen = .75f;
        power = 1.00f;
        healthBarHieght = Screen.height / 3;
	}
    public float giveDamage()
    {
        return power + 25;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            StatTracking stat = col.gameObject.GetComponentInParent<StatTracking>();
            health -= stat.giveDamage();
        }
    }
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(0,0,32,healthBarHieght));
        GUI.Box(new Rect(0, 0, 32, healthBarHieght), back);
        GUI.BeginGroup(new Rect(0, 0, 32, (health / maxHealth)*healthBarHieght));
        GUI.Box(new Rect(0, 0, 32, healthBarHieght),front);
        GUI.EndGroup();
        GUI.EndGroup();
    }
	// Update is called once per frame
	void Update () {
        if (health <= 0.0f)
        {
            obj.transform.position = spawn.position;
            health = maxHealth;

        }
        if(xp == Tree[level])
        {
            level++;
            power += .25f;
            maxHealth += 25.0f;
        }
        if (health < maxHealth)
        {
            if (health < maxHealth - healthRegen)
            {
                health += healthRegen;
            }
            else
            {
                health = maxHealth;
            }
        }
	}
}
