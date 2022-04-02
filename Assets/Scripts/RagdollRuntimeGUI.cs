using UnityEngine;

public class RagdollRuntimeGUI : MonoBehaviour
{
    [SerializeField]
    private RagdollEnabler[] Ragdolls;
    [SerializeField]
    private float ExplosiveForce = 5_000;
    [SerializeField]
    private float UpwardModifier = 2;
    [SerializeField]
    private float ExplosiveRadius = 2f;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 250, 30), "Enable Ragdoll"))
        {
            foreach(RagdollEnabler ragdoll in Ragdolls)
            {
                ragdoll.EnableRagdoll();
                Invoke("Explode", 0.25f);
            }
        }
        else if (GUI.Button(new Rect(10, 50, 250, 30), "Enable Animator"))
        {
            foreach (RagdollEnabler ragdoll in Ragdolls)
            {
                ragdoll.EnableAnimator();
            }
        }
        else if (GUI.Button(new Rect(10, 90, 250, 30), "Explode"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            foreach (Rigidbody rigidbody in ragdoll.Rigidbodies)
            {
                rigidbody.AddExplosionForce(ExplosiveForce, ragdoll.transform.position, ExplosiveRadius, UpwardModifier);
            }
        }
    }
}
