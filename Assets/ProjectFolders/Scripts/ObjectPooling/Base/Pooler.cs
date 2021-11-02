using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pooler", menuName = "ObjectPooling/Pooler")]
public class Pooler : ScriptableObject
{
    [SerializeField] private PooledItem pooledPrefab;
    private List<PooledItem> spawnedItems = new List<PooledItem>();

    ///<Summary> Position, rotation ve parent önemsenmeksizin spawn işlemi yapılmaktadır.
    /// Spawn edilecek objenin position değeri 0,0,0 dır, rotation değeri identitydir ve parenti yoktur.. </Summary>
    public void Spawn()
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            Respawn(pooledItem, Vector3.zero, Quaternion.identity, null);
            return;
        }
        
        InstantiatePrefab(Vector3.zero, Quaternion.identity, null);
    }

    ///<Summary> Spawn edilecek objenin sadece parenti bellidir.
    /// Spawn edilecek objenin position değeri 0,0,0 dır, rotation değeri identitydir. </Summary>
    public void Spawn(Transform parent)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            Respawn(pooledItem, Vector3.zero, Quaternion.identity, parent);
            return;
        }

        InstantiatePrefab(Vector3.zero, Quaternion.identity, parent);
    }

    ///<Summary> Position ve rotation değerleriyle spawn işlemi yapılmaktadır. Parent dahil değildir. 
    /// Obje World de belirtilen postion ve rotaion ile parentsız bir şekilde instantiate edilir. </Summary>
    public void Spawn(Vector3 position, Quaternion rotation)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            Respawn(pooledItem, position, rotation, null);
            return;
        }

        InstantiatePrefab(position, rotation, null);
    }

    ///<Summary> Spawn edilecek objenin position, rotaion ve parenti bellidir. Oraya spawn edilir. </Summary>
    public void Spawn(Vector3 position, Quaternion rotation, Transform parent)
    {
        PooledItem pooledItem = GetAvaiableItemInPool();
        if(spawnedItems.Count > 0 && pooledItem != null && !pooledItem.gameObject.activeInHierarchy)
        {
            //Release olmayı bekliyen objelerin taski iptal eilecek ve respawn edilecekler.
            Respawn(pooledItem, position, rotation, parent);
            return;
        }

        InstantiatePrefab(position, rotation, parent);
    }

    //Bu fonksiyonda uygun olan yani oyunda deactive olan ve ilk instantiate edilmiş olan pooledItem return edilmektedir.
    private PooledItem GetAvaiableItemInPool()
    {
        for(int i = 0; i < spawnedItems.Count; i++)
        {
            if(!spawnedItems[i].gameObject.activeInHierarchy)
            {
                
                return spawnedItems[i];
            } 
        }
        return null;
    }

    //Respawn Methodu bir obje eğer bundleına geri gönderilmediyse yani release edilmediyse, 
    // o objeyi tekrar kallanmak için çağırılacak fonksiyon.
    private void Respawn(PooledItem itemToRespawn,Vector3 position, Quaternion rotation, Transform parent)
    {
        Transform itemTransform = itemToRespawn.transform;

        itemTransform.position = position;
        itemTransform.rotation = rotation;
        itemTransform.SetParent(parent);
        itemToRespawn.gameObject.SetActive(true);
    }

    //Bu Fonksiyon prefabı instantiate edip queueya ekleme ve return fonksiyonunu register etme işlemi yapmaktadır.
    private void InstantiatePrefab(Vector3 position, Quaternion rotation, Transform parent)
    {
        PooledItem pooledItem = Instantiate(pooledPrefab, position, rotation, parent);
        pooledItem.onReturnToPool += ReturnToPool;
        spawnedItems.Add(pooledItem);
    }

    //Bu method objenin poola dönmesini sağlar.
    private void ReturnToPool(PooledItem itemToReturn)
    {
        itemToReturn.gameObject.SetActive(false);
    }

    private void OnDisable() 
    {
        spawnedItems.Clear();    
    }
}
