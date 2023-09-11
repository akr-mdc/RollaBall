using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class MoveBall : MonoBehaviour
{
	private Rigidbody rb;
	public float velocidade;
	public TextMeshProUGUI CountText;
	public TextMeshProUGUI WinText;
	private int count;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		WinText.text = "";
	}
	void Update()
	{
		float movimentoHorizontal = Input.GetAxis("Horizontal");
		float movimentoVertical = Input.GetAxis("Vertical");
		Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
		rb.AddForce(movimento * velocidade);

		if (movimento != Vector3.zero)
		{
			transform.forward = movimento;
		}
	}
	void SetCountText()
	{
		CountText.text = "Count: " + count.ToString();
		if (count >= 13)
		{
			WinText.text = "Vitória!";
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
			other.gameObject.SetActive(false);
		count = count + 1;

		SetCountText();
	}
}