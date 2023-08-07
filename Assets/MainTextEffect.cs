using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainTextEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TextComponent;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextComponent.ForceMeshUpdate();
        var textInfo = TextComponent.textInfo;
        for (int i = 0; i < textInfo.characterCount; ++i) {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) {
                continue;
            }
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for (int j = 0; j < 4; ++j) {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 1f + orig.x * 0.01f) * 10f, 0);
            }
        }
        for (int i = 0; i < textInfo.meshInfo.Length; ++i) {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            TextComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
    Vector2 Wobble(float time) {
        Debug.Log("Hola");
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*2.5f));
    }
}
