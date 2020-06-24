using UnityEngine;
using System.Collections;

public class GlowEffectRayCaster : MonoBehaviour {
    private static GlowEffectRayCaster instance_;
    public static GlowEffectRayCaster Instance {
        get {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<GlowEffectRayCaster>();
            return instance_;
        }
    }

    Transform cam;
    RaycastHit hit;
    MeshRenderer lasthitted;
    SkinnedMeshRenderer smr;
    Collider hittedCollider = null;
    float distation;
    public Material glowMaterial;
    public MessageShow messageShow;
    [HideInInspector] public bool flaghelp = false;
    [HideInInspector] public bool flagraycasthit = false;
    readonly GameObject picked = null;
    [HideInInspector] public bool glow = false;
    Transform CursorImage;
	void Start () {
        messageShow = MessageShow.Instance;
        cam = Camera.main.transform;
        CursorImage = GameObject.Find("CursorImage").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3.5f) && hit.collider.tag == "ActiveObject")
        {
            distation = Vector3.Distance(GameObject.Find("Player").transform.position, hit.transform.position);
            if(distation<=2f)
            {
                MeshRenderer hitted = hit.collider.GetComponent<MeshRenderer>();
                SkinnedMeshRenderer hittedsmr = hit.collider.GetComponent<SkinnedMeshRenderer>();
                if (hitted != null && picked != hitted.gameObject)
                {
                    if (hitted != lasthitted)
                    {
                        RemoveLastMaterial(lasthitted);
                        lasthitted = hitted;
                        hittedCollider = hit.collider;
                        AddGlowMaterial(lasthitted);

                    }
                }

                if (hittedsmr != null && picked != hittedsmr.gameObject)
                {
                    if (smr != hittedsmr)
                    {
                        RemoveLastMaterial(smr);
                        smr = hittedsmr;
                        hittedCollider = hit.collider;
                        AddGlowMaterial(hittedsmr);
                    }
                }
           }
        }
        else
        { 
             RemoveLastMaterial(lasthitted);
             RemoveLastMaterial(smr);
             smr = null;
             hittedCollider = null;
             lasthitted = null;
             flagraycasthit = false;
        }
     }

    public void Refresh()
    {
        RemoveLastMaterial(lasthitted);
        RemoveLastMaterial(smr);
        smr = null;
        hittedCollider = null;
        lasthitted = null;
    }
    public GameObject GetCatchedObject()
    {
        if (lasthitted != null)
            return lasthitted.gameObject;
        else
            if (smr!=null)
            return smr.gameObject;
        return null;
    }

    public Collider GetHittedCollider()
    {
        return hittedCollider;
    }

    public void RemoveLastMaterial(MeshRenderer mRenderer)
    {
        if (mRenderer == null)
            return;
            Material[] mat = new Material[mRenderer.materials.Length -1];
            for (int i = 0; i < mat.Length; i++)
            {
                mat[i] = mRenderer.materials[i];
            }
            mRenderer.materials = mat;
    }

    public void RemoveLastMaterial(SkinnedMeshRenderer mRenderer)
    {
        if (mRenderer == null)
            return;
        Material[] mat = new Material[mRenderer.materials.Length - 1];
        for (int i = 0; i < mat.Length; i++)
        {
            mat[i] = mRenderer.materials[i];
        }
        mRenderer.materials = mat;
    }

    public void AddGlowMaterial(MeshRenderer mRenderer)
    {
       
            Material[] temp = new Material[mRenderer.materials.Length + 1];
            for (int i = 0; i < temp.Length - 1; i++)
                temp[i] = mRenderer.materials[i];
            temp[temp.Length - 1] = glowMaterial;
            glowMaterial.SetFloat("_Outline", mRenderer.GetComponent<InteractingController>().glowValue);
            mRenderer.materials = temp;
           
    }

    public void AddGlowMaterial(SkinnedMeshRenderer skinnedMRenderer)
    {
        Material[] temp = new Material[skinnedMRenderer.materials.Length + 1];
        for (int i = 0; i < temp.Length - 1; i++)
            temp[i] = skinnedMRenderer.materials[i];
        temp[temp.Length - 1] = glowMaterial;
        glowMaterial.SetFloat("_Outline", skinnedMRenderer.GetComponent<InteractingController>().glowValue);
        skinnedMRenderer.materials = temp;
    }
}
