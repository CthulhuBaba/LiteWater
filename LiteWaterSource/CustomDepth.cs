using System;
using System.Collections.Generic;
using FlaxEngine;

public class CustomDepth : Script
{
    public List<Actor> Actors = new List<Actor>();
    private bool ismaterialset = false;
   // public Camera CamD;
    private MaterialBase _materialD;
    private MaterialBase _materialT;
    private GPUTexture _outputD;
    private SceneRenderTask _taskD;
    private bool texture_is_initialized = false;
    private Actor water_ent;

    public override void OnEnable()
    {

        water_ent = Actor.Scene.FindActor("water");

        if (_outputD == null)
            _outputD = new GPUTexture();
        // UpdateOutput();
        // Create rendering task
        if (_taskD == null)
            _taskD = new SceneRenderTask();
        _taskD.Render += OnRender; // RenderTask will call OnRender method during rendering
        _taskD.Order = -100; // Before the main scene rendering
                             //_taskD.ViewMode = ViewMode.Depth;
                             // Cam.FarPlane = 9000000;
                             //Cam.NearPlane = 10;
        _taskD.Camera = (Camera)Actor;
        // Cam.FieldOfView = 60;
        // Cam.UsePerspective = true;
        // _taskD.ViewMode = ViewMode.Depth;

        _taskD.Output = _outputD;
        _taskD.Enabled = true;

        //_taskD.ViewFlags = ViewFlags.Reflections;


    }
    public override void OnUpdate()
    {

        if (texture_is_initialized == false)
        {
            var desc = GPUTextureDescription.New2D((int)Screen.Size.X, (int)Screen.Size.Y, PixelFormat.D32_Float);
            _outputD.Init(ref desc);
            texture_is_initialized = true;
        }
        _taskD.Enabled = true;// Vector3.Distance(Actor.Position, MainRenderTask.Instance.View.Position) <= ViewDistance;
    }
    public override void OnFixedUpdate()
    {
        Actor.Position = Camera.MainCamera.Position;
        Actor.Orientation = Camera.MainCamera.Orientation;
    }

    private void OnRender(RenderTask task, GPUContext context)
    {

        //task = _taskD;
        // Profiler.BeginEventGPU("MyRenderScript");
        var desc = GPUTextureDescription.New2D((int)Screen.Size.X, (int)Screen.Size.Y, PixelFormat.D32_Float, GPUTextureFlags.DepthStencil | GPUTextureFlags.ShaderResource);
        var CustomDepth = RenderTargetPool.Get(ref desc);
        //task.Order = 10000;
        context.ClearDepth(CustomDepth.View());

        // Draw objects to depth buffer (use main rendering task to view)
        Renderer.DrawSceneDepth(context, _taskD, CustomDepth, Actors);

        RenderTargetPool.Release(CustomDepth);
       // if (ismaterialset == false)
       // {
           // var obj = Actor.Scene.FindActor("water");
            _materialD = water_ent.As<StaticModel>().GetMaterial(0, 0);
            _materialD.SetParameterValue("CustomDepth", CustomDepth);
            /*
            var obj2 = Actor.Scene.FindActor("terr");
            _materialT = obj2.As<StaticModel>().GetMaterial(0, 0);
            _materialT.SetParameterValue("CustomDepth", CustomDepth);
            */
          //  ismaterialset = true;
       // }

        //Profiler.EndEventGPU();
    }



    public override void OnDisable()
    {
        // Cleanup resources

        
        Destroy( _taskD);
       // Destroy( _materialD);
        Destroy( _outputD);
        

    }
}