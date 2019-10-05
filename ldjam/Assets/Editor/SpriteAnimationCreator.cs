using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using wuxingogo.Editor;

public class SpriteAnimationCreator : XBaseWindow
{
    [MenuItem("Tools/Utils/Create Selection Frame Animation ")]
    public static void CreateSelection(){
        if(Selection.objects == null || Selection.objects.Length == 0)
        {
            XLogger.Log("Selection objects must greater one!!");
            return;
        }
        
        List<Sprite> sprites = new List<Sprite>();
        List<Texture2D> textures = SelectionUtils.GetObjects<Texture2D>();
        
        List<Sprite> tex2Sprite = XUtils.ToList<Texture2D, Sprite>(textures, (v)=>{
            var objects = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(v));
            for (int i = 0; i < objects.Length; i++)
            {
                var o = objects[i];
                if(o is Sprite){
                    return o as Sprite;
                }
            }
            return null;
        }); 
        sprites = tex2Sprite;
        tex2Sprite.AddRange(SelectionUtils.GetObjects<Sprite>());
        if(sprites.Count == 0)
        {
            XLogger.Log("Selection sprites must greater one!!");
            return;
        }
        var creator = InitWindow<SpriteAnimationCreator>();
        creator.totalSprite = sprites;
        creator.InitPath();
    }
    
    public float delta = 1.0f;
    public List<Sprite> totalSprite = null;
    public string path = "";
    public override void OnXGUI(){
        base.OnXGUI();

        delta = CreateFloatField("Frame Delta", delta);

        CreateSpaceBox();
        for (int i = 0; i < totalSprite.Count; i++)
        {
            var sp = totalSprite[i];
            CreateObjectField(sp);
        }
        CreateSpaceBox();

        DoButton(path, OnChangePath);
        DoButton("Create", OnCreate);
    }
    public void InitPath(){
        path = SelectionUtils.GetAssetFolder( Selection.objects[0] ) + "/" + Selection.activeObject.name + ".anim";
    }
    public void OnChangePath(){
        var assetPath = SelectionUtils.GetAssetFolder( Selection.objects[0] );
        var path = EditorUtility.SaveFilePanel("Save Animation File", assetPath, Selection.activeObject.name , "anim");
        XLogger.Log("path : " + path);
        
        XLogger.Log("path : " + path);
    }
    public void OnCreate(){
        AnimationClip animClip = new AnimationClip();
        animClip.frameRate = 25;   // FPS
        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite"; 
        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[totalSprite.Count];
        for(int i = 0; i < (totalSprite.Count); i++) {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe();
            spriteKeyFrames[i].time = i * delta;
            spriteKeyFrames[i].value = totalSprite[i];
        }
        AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);

        if(path != null){
            //path = FileUtil.GetProjectRelativePath(path);
            XLogger.Log("File Path : " + path);
            AssetDatabase.CreateAsset(animClip, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        Close();
    }
}
