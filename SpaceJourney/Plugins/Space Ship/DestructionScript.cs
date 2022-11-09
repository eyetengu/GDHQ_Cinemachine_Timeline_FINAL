using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionScript : MonoBehaviour {

	public GameObject Explosion;
	public float HP;
	public Transform particleParent;
    public float ExplosionScale = 10f;

	private bool dead;

	public bool Asteroid;
	public bool Metal;

	void Update () {
		if (!dead && HP <= 0f) {
			StartCoroutine (Death ());
			dead = true;
		}
	}

	IEnumerator Death(){
		if(SpaceshipController.instance!=null){
			if(SpaceshipController.instance.m_spaceship.enemies.Contains(gameObject)){
				SpaceshipController.instance.m_spaceship.enemies.Remove(gameObject);
			}
		}else{
			if(SpaceshipController2D.instance.m_spaceship.enemies.Contains(gameObject)){
				SpaceshipController2D.instance.m_spaceship.enemies.Remove(gameObject);
			}
		}

		if(GetComponent<BasicAI>()!=null){
			if(GetComponent<BasicAI>().shoot!=null){
				GetComponent<BasicAI>().StopCoroutine(GetComponent<BasicAI>().shoot);
			}
		}		
		GetComponent<Renderer> ().enabled = false;
		foreach (Transform child in transform) {
			if (child.GetComponent<Renderer> () != null) {
				child.GetComponent<Renderer> ().enabled = false;
			}
		}
		if (particleParent != null) {
			foreach (Transform child in particleParent) {
				child.gameObject.SetActive (false);
			}
		}
		GetComponent<Collider> ().enabled = false;
        if (Explosion != null)
        {
            GameObject firework = Instantiate(Explosion, transform.position, transform.rotation);
            firework.transform.localScale = firework.transform.localScale * ExplosionScale;
            //firework.transform.parent = gameObject.transform;
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            yield return new WaitForSeconds(2f);
            Destroy(firework);
            //Explosion.Play ();
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
