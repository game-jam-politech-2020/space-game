using UnityEngine;

public class BlackHole : MonoBehaviour
{
	public Material m_Mat = null;
	[Range(0.01f, 0.2f)] public float m_DarkRange = 0.1f;
	[Range(-2.5f, -1f)] public float m_Distortion = -2f;
	public float setPosX = 0f;
	public float setPosY = 0f;
	float startCamX = 0f;
	float startCamY = 0f;
	float m_MouseX = 0f;
	float m_MouseY = 0f;
	int m_ID_Center = 0;
	int m_ID_DarkRange = 0;
	int m_ID_Distortion = 0;

	void Start()
	{
		if (!SystemInfo.supportsImageEffects)
			enabled = false;
		m_MouseX = m_MouseY = 0.5f;
		m_ID_Center = Shader.PropertyToID("_Center");
		m_ID_DarkRange = Shader.PropertyToID("_DarkRange");
		m_ID_Distortion = Shader.PropertyToID("_Distortion");
		startCamX = Camera.main.transform.position.x;
		startCamY = Camera.main.transform.position.y;
	}
	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		m_Mat.SetVector(m_ID_Center, new Vector4(m_MouseX, m_MouseY, 0f, 0f));
		m_Mat.SetFloat(m_ID_DarkRange, m_DarkRange);
		m_Mat.SetFloat(m_ID_Distortion, m_Distortion);
		Graphics.Blit(sourceTexture, destTexture, m_Mat);
	}
	void Update()
	{
		if ((setPosX != 0f) && (setPosY != 0f))
		{
			m_MouseX = setPosX;
			m_MouseY = setPosY;
		}
		if ((Camera.main.transform.position.x - startCamX) != 0)
		{
			m_MouseX -= ((Camera.main.transform.position.x - startCamX) / Screen.width);
			m_MouseY -= ((Camera.main.transform.position.y - startCamY) / Screen.height);
		}
	}
}