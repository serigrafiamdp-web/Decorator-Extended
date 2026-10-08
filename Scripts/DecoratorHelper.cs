// DECORATOR EXTENDED
// Original mod: Decorator by Kaedius / KDS-KDS
// Extended modifications: DECORATOR EXTENDED BY RICO
// Unofficial fork - preserves the original MIT license.

using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop.Utility.AssetInjection;
using System.Collections.Generic;
using UnityEngine;
namespace Decorator
{
public static class DecoratorHelper
{
#region Public Methods
public static PlacedObjectData_v2 Parse(string key,Dictionary<string,string> dictionary)
{
PlacedObjectData_v2 data=new PlacedObjectData_v2();
if(!dictionary.TryGetValue(key,out data.name))
{
Debug.LogWarning("Could not find value of key in Parse");
return null;
}
else if(key=="-1")
return data;
int index=key.IndexOf(".");
if(index==-1)
data.modelID=(uint)int.Parse(key);
else
{
data.modelID=0;
string[] archiveRecord=key.Split('.');
data.archive=int.Parse(archiveRecord[0]);
data.record=int.Parse(archiveRecord[1]);
}
return data;
}
public static GameObject CreatePlacedObject(PlacedObjectData_v2 data,Transform parent,bool previewGo=false)
{
GameObject parentGo=new GameObject();
GameObject childGo;
parentGo.transform.parent=parent;
if(IsPixel(data.modelID))
childGo=CreatePixel(data.modelID,parentGo.transform);
else if(data.modelID==0)
{
childGo=MeshReplacement.ImportCustomFlatGameobject(data.archive,data.record,Vector3.zero,parentGo.transform);
if(childGo==null) childGo=GameObjectHelper.CreateDaggerfallBillboardGameObject(data.archive,data.record,parentGo.transform);
}
else
{
uint sourceID=data.modelID==2000000003u?41116u:data.modelID;
Matrix4x4 matrix=Matrix4x4.TRS(Vector3.zero,Quaternion.identity,Vector3.one);
childGo=MeshReplacement.ImportCustomGameobject(sourceID,parentGo.transform,matrix);
if(childGo==null)childGo=GameObjectHelper.CreateDaggerfallMeshGameObject(sourceID,parentGo.transform);
if(data.modelID==2000000003u)ApplyFireplace3(childGo,sourceID);
}
parentGo.transform.eulerAngles=Vector3.zero;
childGo.transform.eulerAngles=Vector3.zero;
if(previewGo)
data.isLight=true;
BoxCollider parentCollider=parentGo.AddComponent<BoxCollider>();
BoxCollider childCollider;
Bounds childBounds=new Bounds();
float buffer=0.02f;
if(childCollider=childGo.GetComponent<BoxCollider>())
{
childBounds.size=childCollider.size;
childBounds.center=childCollider.center;
GameObject.Destroy(childCollider);
}
else
{
MeshFilter meshFilter;
if(meshFilter=childGo.GetComponent<MeshFilter>())
childBounds=meshFilter.sharedMesh.bounds;
else
{
SkinnedMeshRenderer skinnedMeshRenderer;
if(skinnedMeshRenderer=parentGo.GetComponentInChildren<SkinnedMeshRenderer>())
childBounds=skinnedMeshRenderer.bounds;
}
}
parentCollider.size=GetColliderSizeAndCenter(childBounds.size,childGo,buffer);
parentCollider.center=GetColliderSizeAndCenter(childBounds.center,childGo);
parentCollider.isTrigger=true;
parentGo.AddComponent<PlacedObject>();
SetPlacedObject(data,parentGo);
return parentGo;
}
private static bool IsPixel(uint i){return i>=2000001001u&&i<=2000001010u;}
private static GameObject CreatePixel(uint id,Transform parent)
{
int slot=(int)(id-2000001000u);
GameObject go=new GameObject(string.Format("PIXEL {0:00}",slot)); go.transform.parent=parent;
Texture2D tex=null; string file=string.Format("PIXEL_{0:00}.png",slot);
TextureReplacement.TryImportTextureFromLooseFiles(file,true,false,out tex);
if(tex==null){tex=new Texture2D(2,2,TextureFormat.ARGB32,false);tex.SetPixels(new Color[]{Color.clear,Color.clear,Color.clear,Color.clear});tex.Apply(false,false);}
tex.filterMode=FilterMode.Point; tex.wrapMode=TextureWrapMode.Clamp; tex.anisoLevel=0;
float h=1f; float w=(tex.height>0)?((float)tex.width/(float)tex.height):1f;
Mesh mesh=new Mesh(); mesh.name=go.name+" Mesh";
mesh.vertices=new Vector3[]{new Vector3(-w*.5f,-h*.5f,0),new Vector3(w*.5f,-h*.5f,0),new Vector3(w*.5f,h*.5f,0),new Vector3(-w*.5f,h*.5f,0)};
mesh.uv=new Vector2[]{new Vector2(0,0),new Vector2(1,0),new Vector2(1,1),new Vector2(0,1)};
mesh.triangles=new int[]{0,1,2,2,3,0,2,1,0,0,3,2}; mesh.RecalculateBounds();
MeshFilter mf=go.AddComponent<MeshFilter>(); mf.sharedMesh=mesh; MeshRenderer mr=go.AddComponent<MeshRenderer>();
Shader sh=Shader.Find("Unlit/Transparent"); if(sh==null)sh=Shader.Find("Sprites/Default"); if(sh==null)sh=Shader.Find("Unlit/Texture");
Material mat=new Material(sh); mat.name=go.name+" Material"; mat.mainTexture=tex; mat.color=Color.white; if(mat.HasProperty("_Cull"))mat.SetInt("_Cull",0); mr.material=mat;
return go;
}
private static void ApplyFireplace3(GameObject g,uint id){MeshRenderer r=g.GetComponent<MeshRenderer>();if(r==null)return;CachedMaterial[] c;int[] k;bool an;DaggerfallUnity d=DaggerfallUnity.Instance;d.MeshReader.GetMesh(d,id,out c,out k,out an,d.MeshReader.AddMeshTangents,d.MeshReader.AddMeshLightmapUVs);foreach(AnimatedMaterial x in g.GetComponents<AnimatedMaterial>())Object.Destroy(x);Material[] m=r.materials;for(int i=0;i<c.Length&&i<m.Length;i++){int ar,rec,fr;MaterialReader.ReverseTextureKey(c[i].key,out ar,out rec,out fr,c[i].keyGroup);if(ar!=87||(rec!=0&&rec!=2))continue;List<Texture2D> f=new List<Texture2D>();int n=rec==0?4:1;for(int j=0;j<n;j++){Texture2D t;if(TextureReplacement.TryImportTextureFromLooseFiles(string.Format("DECORATOR_FIREPLACE3_{0}-{1}.png",rec,j),true,false,out t))f.Add(t);}if(f.Count==0)continue;m[i]=new Material(m[i]);m[i].mainTexture=f[0];if(rec==0){m[i].EnableKeyword("_EMISSION");m[i].SetColor("_EmissionColor",Color.white);m[i].SetTexture("_EmissionMap",f[0]);}if(f.Count>1){DecoratorMaterialAnimation x=g.AddComponent<DecoratorMaterialAnimation>();x.Target=m[i];x.Frames=f.ToArray();}}r.materials=m;MeshFilter q=g.GetComponent<MeshFilter>();if(q!=null){Vector3 z=q.sharedMesh.bounds.size;g.transform.localScale=new Vector3(.3826f*z.y/z.x,1f,.3816f*z.y/z.z);}}private static Vector3 GetColliderSizeAndCenter(Vector3 bounds,GameObject gameObject,float buffer=0.0f)
{
Vector3 size=new Vector3((bounds.x*gameObject.transform.localScale.x)+buffer,
(bounds.y*gameObject.transform.localScale.y)+buffer,
(bounds.z*gameObject.transform.localScale.z)+buffer);
return size;
}
public static void SetPlacedObject(PlacedObjectData_v2 data,GameObject placedObject)
{
placedObject.GetComponent<PlacedObject>().SetData(data);
SetLight(placedObject,data);
SetContainer(placedObject,data);
SetLayer(placedObject);
}
#endregion Public Methods
#region Private Methods
private static void SetLight(GameObject placedObject,PlacedObjectData_v2 data=null)
{
if(data==null)
data=placedObject.GetComponent<PlacedObject>().GetData();
if(data.isLight)
{
Light light;
DaggerfallLight dfLight;
GameObject lightGo;
if(placedObject.transform.childCount>1)
{
if(!(light=placedObject.transform.GetComponentInChildren<Light>()))
{
lightGo=new GameObject(data.name+" Light");
lightGo.transform.parent=placedObject.transform;
light=lightGo.AddComponent<Light>();
dfLight=lightGo.AddComponent<DaggerfallLight>();
}
else
{
lightGo=light.gameObject;
if(!(dfLight=lightGo.transform.GetComponent<DaggerfallLight>()))
dfLight=lightGo.AddComponent<DaggerfallLight>();
}
}
else
{
lightGo=new GameObject(data.name+" Light");
lightGo.transform.parent=placedObject.transform;
light=lightGo.AddComponent<Light>();
dfLight=lightGo.AddComponent<DaggerfallLight>();
}
dfLight.Animate=true;
dfLight.InteriorLight=true;
light.color=data.lightColor;
light.intensity=data.lightIntensity;
light.type=data.lightType;
light.spotAngle=data.lightSpotAngle;
if(!DaggerfallUnity.Settings.InteriorLightShadows)
light.shadows=LightShadows.None;
else
light.shadows=LightShadows.Soft;
light.enabled=true;
dfLight.enabled=true;
lightGo.transform.localPosition=Vector3.zero;
lightGo.transform.localEulerAngles=new Vector3(data.lightVerticalRotation,data.lightHorizontalRotation,0.0f);
}
else
{
if(placedObject.transform.childCount>1)
{
Light light=placedObject.GetComponentInChildren<Light>();
Object.Destroy(light.gameObject);
}
}
}
private static void SetContainer(GameObject placedObject,PlacedObjectData_v2 data=null)
{
if(data==null)
data=placedObject.GetComponent<PlacedObject>().GetData();
DaggerfallLoot loot;
SerializableLootContainer lootContainer;
if(data.isContainer)
{
if(!(loot=placedObject.GetComponent<DaggerfallLoot>()))
loot=placedObject.AddComponent<DaggerfallLoot>();
if(!(lootContainer=placedObject.GetComponent<SerializableLootContainer>()))
lootContainer=placedObject.AddComponent<SerializableLootContainer>();
if(data.lootData!=null)
lootContainer.RestoreSaveData(data.lootData);
loot.LoadID=0;
loot.ContainerType=LootContainerTypes.Nothing;
loot.ContainerImage=InventoryContainerImages.Shelves;
}
else
{
Object.Destroy(placedObject.GetComponent<DaggerfallLoot>());
Object.Destroy(placedObject.GetComponent<SerializableLootContainer>());
data.lootData=null;
}
}
private static void SetLayer(GameObject placedObject)
{
placedObject.layer=0;
if(placedObject.transform.childCount>0)
foreach(Transform child in placedObject.transform)
SetLayer(child.gameObject);
}
#endregion Private Methods
}
public class DecoratorMaterialAnimation:MonoBehaviour
{
public Material Target;public Texture2D[] Frames;int index;float nextFrame;
void LateUpdate(){if(Target==null||Frames==null||Frames.Length==0)return;if(Time.time>=nextFrame){index=(index+1)%Frames.Length;nextFrame=Time.time+0.125f;Target.mainTexture=Frames[index];if(Target.HasProperty("_EmissionMap"))Target.SetTexture("_EmissionMap",Frames[index]);}}
}
}
