using UnityEngine;
using System.Collections;

public class TextureSwitcher : MonoBehaviour, IFadeable {

	public Texture lightTexture;
	public Texture darkTexture;
	public Vector2 size = new Vector2(1.0f, 1.0f);
	public float fadeState = 0.5f;

	MaterialPropertyBlock shaderParameters;

	Mesh MakeQuad() {
		Vector3[] vertices = new Vector3[4];
		Vector3[] normals = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		
		vertices [0] = new Vector3 (0.0f, 0.0f, 0.0f);
		uv [0] = new Vector2 (0.0f, 0.0f);
		normals [0] = Vector3.back;

		vertices [1] = new Vector3 (0.0f, size.y, 0.0f);
		uv [1] = new Vector2 (0.0f, 1.0f);
		normals [1] = Vector3.back;
		
		vertices [2] = new Vector3 (size.x, size.y, 0.0f);
		uv [2] = new Vector2 (1.0f, 1.0f);
		normals [2] = Vector3.back;
		
		vertices [3] = new Vector3 (size.x, 0.0f, 0.0f);
		uv [3] = new Vector2 (1.0f, 0.0f);
		normals [3] = Vector3.back;
		
		int[] indices = new int[6]; //2 triangles, 3 indices each
		
		indices [0] = 0;
		indices [1] = 1;
		indices [2] = 2;
		
		indices [3] = 0;
		indices [4] = 2;
		indices [5] = 3;
		
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.uv = uv;
		mesh.triangles = indices;
		mesh.RecalculateBounds ();
		return mesh;
	}

	// Use this for initialization
	void Start () {
		var renderer = GetComponent<MeshRenderer> ();

		var spriteShader = Shader.Find ("Custom/SpriteShader");
		renderer.material = new Material (spriteShader);

		shaderParameters = new MaterialPropertyBlock ();
		shaderParameters.AddTexture ("_MainTex", lightTexture);
		shaderParameters.AddTexture ("_DarkTex", darkTexture);
		shaderParameters.AddFloat ("_FadeState", fadeState);
		renderer.SetPropertyBlock (shaderParameters);
	}

	
	// Update is called once per frame
	void Update () {
	}

	public void SetFadeState(float value) {
		shaderParameters = new MaterialPropertyBlock ();
		shaderParameters.AddTexture ("_MainTex", lightTexture);
		shaderParameters.AddTexture ("_DarkTex", darkTexture);
		shaderParameters.AddFloat ("_FadeState", value);
		GetComponent<Renderer>().SetPropertyBlock (shaderParameters);
	}

}
