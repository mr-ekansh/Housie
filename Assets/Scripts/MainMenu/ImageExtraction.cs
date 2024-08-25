using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ImageExtraction : MonoBehaviour
{
    public RawImage[] images;
    public RawImage[] bigimages;
    private string imageUrl = "http://34.121.136.31/housiekings/extractprizeimages.php";
    [Serializable]
    public class imagesextract
    {
        public string image1;
        public string image2;
        public string image3;
        public string image4;
        public string image5;
        public string image6;
        public string image7;
        public string image8;
        public string image9;
        public string image10;
    }
    public void imagefetch()
    {
        StartCoroutine(Extractimages());
    }

    private IEnumerator Extractimages()
    {
        WWWForm form = new WWWForm();
    
        UnityWebRequest www = UnityWebRequest.Post(imageUrl, form);

        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("entered the loop.........");

            imagesextract Image = JsonUtility.FromJson<imagesextract>(www.downloadHandler.text);

            if (www.error != null)
            {
                Debug.Log(www.error);
            }
            else
            {
                StartCoroutine(fetchImages(Image.image1, images[0], bigimages[0]));
                StartCoroutine(fetchImages2(Image.image2, images[1], bigimages[1]));
                StartCoroutine(fetchImages3(Image.image3, images[2], bigimages[2]));
                StartCoroutine(fetchImages4(Image.image4, images[3], bigimages[3]));
                StartCoroutine(fetchImages5(Image.image5, images[4], bigimages[4]));
                StartCoroutine(fetchImages6(Image.image6, images[5], bigimages[5]));
                StartCoroutine(fetchImages7(Image.image7, images[6], bigimages[6]));
                StartCoroutine(fetchImages8(Image.image8, images[7], bigimages[7]));
                StartCoroutine(fetchImages9(Image.image9, images[8], bigimages[8]));
                StartCoroutine(fetchImages10(Image.image10, images[9], bigimages[9]));
            }
        }
    }

    private IEnumerator fetchImages(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages2(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages3(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages4(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages5(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages6(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages7(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages8(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages9(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }

    private IEnumerator fetchImages10(string link, RawImage y, RawImage z)
    {
        UnityWebRequest GameAvatar = UnityWebRequestTexture.GetTexture(link);
        
        yield return GameAvatar.SendWebRequest();

        if (GameAvatar.error != null)
        {
            Debug.Log(GameAvatar.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)GameAvatar.downloadHandler).texture;

            y.texture = img;
            z.texture = img;
        }
    }
}
