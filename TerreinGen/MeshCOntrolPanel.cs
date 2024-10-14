using UnityEngine;
using UnityEngine.UI;

public class MeshControlPanel : MonoBehaviour
{
    public Text textXSize, textZSize, textNoiseIntensetive;
    MeshGenerator meshGen;
    void Start()
    {
        meshGen = this.GetComponent<MeshGenerator>();
        UpdateTextConvas();
    }

    void UpdateTextConvas()
    {
        textXSize.text = meshGen.xSize.ToString();
        textZSize.text = meshGen.zSize.ToString();
        textNoiseIntensetive.text = meshGen.NoiseIntensetive.ToString();

        int max = 10;
        if(meshGen.xSize > meshGen.zSize)
            max = meshGen.xSize;
        else
            max = meshGen.zSize;

        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, max, Camera.main.transform.position.z);
    }

    public void ButtonClickNext(int inf){
        switch (inf) {
            case 1: if(meshGen.xSize < 100) meshGen.xSize += 5; break;
            case 2: if (meshGen.zSize < 100) meshGen.zSize += 5;break;
            case 3: if (meshGen.NoiseIntensetive < 15) meshGen.NoiseIntensetive+=1f; break;
        }
        meshGen.OnUpdateMesh();
        UpdateTextConvas();
    }
    public void ButtonClickPrev(int inf){
        switch (inf)
        {
            case 1: if (meshGen.xSize > 10) meshGen.xSize -= 5; break;
            case 2: if (meshGen.zSize > 10) meshGen.zSize -= 5; break;
            case 3: if (meshGen.NoiseIntensetive > 2) meshGen.NoiseIntensetive -= 1f; break;
        }
        meshGen.OnUpdateMesh();
        UpdateTextConvas();
    }
}
