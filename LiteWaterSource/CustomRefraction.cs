using System;
using FlaxEngine;

public class CustomRefraction : Script
{
    //public Camera Cam;


    //public float ViewDistance = 2000;
    private bool texture_is_initialized = false;

    private GPUTexture _output;
    private SceneRenderTask _task;
    private MaterialBase diffuse_act_material;
    private MaterialBase diffuse_act_material2;
    private Matrix projmatX;
    private Actor water_ent;
    private void UpdateOutput()
    {
        var desc = GPUTextureDescription.New2D(
            (int)1436,
            (int)965,
            PixelFormat.B8G8R8A8_UNorm);
        _output.Init(ref desc);
    }

    public override void OnEnable()
    {
        water_ent = Actor.Scene.FindActor("water");
        // Create backbuffer
        if (_output == null)
            _output = new GPUTexture();
        //UpdateOutput();

        // Create rendering task
        if (_task == null)
            _task = new SceneRenderTask();
        _task.Order = -100;
        //Cam.FarPlane = 9000000;
        // Cam.NearPlane = 10;
        _task.Camera = (Camera)Actor;// Cam;
   
        _task.Output = _output;
        _task.ViewMode = ViewMode.Diffuse;
        _task.ViewFlags =  ViewFlags.MotionBlur | ViewFlags.Reflections | ViewFlags.Decals | ViewFlags.AO | ViewFlags.GI | ViewFlags.DirectionalLights | ViewFlags.PointLights | ViewFlags.SpotLights | ViewFlags.SkyLights | ViewFlags.Shadows | ViewFlags.SpecularLight | ViewFlags.CustomPostProcess | ViewFlags.ToneMapping;
        
            var obj = Actor.Scene.FindActor("water");
        diffuse_act_material = water_ent.As<StaticModel>().GetMaterial(0, 0);
        diffuse_act_material.SetParameterValue("CustomSceneColor", _output);

        _task.Enabled = true;
    }

    public override void OnUpdate()
    {
        if (texture_is_initialized == false)
        {
            var desc = GPUTextureDescription.New2D((int)Screen.Size.X, (int)Screen.Size.Y,  PixelFormat.R8G8B8A8_UNorm);//R8G8B8A8_UNorm
            _output.Init(ref desc);
        
               texture_is_initialized = true;
        }
        diffuse_act_material = water_ent.As<StaticModel>().GetMaterial(0, 0);
        diffuse_act_material.SetParameterValue("CustomSceneColor", _output);
        _task.Enabled = true;// Vector3.Distance(Actor.Position, MainRenderTask.Instance.View.Position) <= ViewDistance;

    }
    public override void OnFixedUpdate()
    {
        Actor.Position = Camera.MainCamera.Position;
        Actor.Orientation = Camera.MainCamera.Orientation;

    }
    public override void OnDisable()
    {

        
        // Ensure to cleanup resources
        Destroy( _task);
        Destroy( _output);
       // Destroy(ref diffuse_act_material);
       // Destroy(ref diffuse_act_material2);
        
    }
}