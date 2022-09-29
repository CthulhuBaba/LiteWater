using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// Water Script.
    /// </summary>
    public class Water : Script
    {
        private MaterialBase wateract_material;
        private MaterialBase materialTerrain;
        public MaterialBase skybox_material;
        private Vector3 temppos;
        // public Actor targetact;
        //public Camera projcam;
        public Actor sun;
        private Vector3 sunpos;
        private Vector3 sundir;

        public PostFxVolume post;
        public MaterialBase postmaterial;
        private Color color_underwater = new Color(0.4745098f, 0.6039216f, 0.78039217f);
        private Color color_above = new Color(22.0f, 22.0f, 22.0f);
        bool post_active = false;

        public ExponentialHeightFog hfog;
        /// <inheritdoc/>
        public override void OnStart()
        {
            wateract_material = Actor.As<StaticModel>().GetMaterial(0, 0);
          
        }
        private Vector3 vec_rotate(Vector3 ang, Vector3 ang_center, float dist)
        {
            Vector3 tvec = new Vector3();

            tvec.X = ang_center.X - (Mathf.Sin(Mathf.DegreesToRadians * ang.X) * dist * Mathf.Cos(Mathf.DegreesToRadians * ang.Y) + 1);
            tvec.Y = ang_center.Y + (Mathf.Sin(Mathf.DegreesToRadians * ang.Y) * dist + 1);
            tvec.Z = ang_center.Z - (Mathf.Cos(Mathf.DegreesToRadians * ang.X) * dist * Mathf.Cos(Mathf.DegreesToRadians * ang.Y) + 1);
            return tvec;
        }
        /// <inheritdoc/>
        public override void OnEnable()
        {
           
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
           // Destroy(wateract_material);
            //Destroy(skybox_material);
           // Destroy(postmaterial);
           // Destroy(post);
            //Destroy(materialTerrain);
            //Destroy(hfog);

        }

        /// <inheritdoc/>
        public override void OnFixedUpdate()
        {

            if (Camera.MainCamera.Position.Y < Actor.Position.Y+10)
            {
                if (post_active == false)
                {
                    post.AddPostFxMaterial(postmaterial);
                    hfog.StartDistance = 30;
                    hfog.FogDensity = 1.0f;
                    hfog.FogInscatteringColor = color_underwater;
                
                    post_active = true;
                }
            }
            else
            {
                if (post_active == true)
                {
                    post.RemovePostFxMaterial(postmaterial);
                    hfog.StartDistance = 400000;
                    hfog.FogDensity = 0.09f;
                    hfog.FogInscatteringColor = color_above;
                    post_active = false;
                }
            }
            if (!Input.GetKey(KeyboardKeys.Spacebar))
            {
                temppos = Actor.Position;
                temppos = vec_rotate(new Vector3(Camera.MainCamera.EulerAngles.Y, 0, 0), new Vector3(Camera.MainCamera.Position.X, 0, Camera.MainCamera.Position.Z), -480);
                Actor.Position = temppos;
                //Actor.Rotation = Camera.MainCamera.Rotation;
                Actor.LocalOrientation = Quaternion.Euler(0, Camera.MainCamera.EulerAngles.Y, 0);
                //Actor.LocalOrientation = Quaternion.Euler(-5, Camera.MainCamera.EulerAngles.Y, 0);
                if (Camera.MainCamera.EulerAngles.X>89)
                {
                    Actor.LocalOrientation = Quaternion.Euler(0, Camera.MainCamera.EulerAngles.Y-180, 0);

                    temppos = Actor.Position;
                    temppos = vec_rotate(new Vector3(Camera.MainCamera.EulerAngles.Y, 0, 0), new Vector3(Camera.MainCamera.Position.X, 0, Camera.MainCamera.Position.Z), -280);
                    Actor.Position = temppos;
                }
             
             
                Vector3 actorpos = new Vector3(0, Actor.Position.Y, 0);
                Vector3 campos = new Vector3(0, Camera.MainCamera.Position.Y, 0);
                var dist = Vector3.Distance(actorpos,campos);
         

                Vector3 hede = new Vector3(Actor.Scale.X, Actor.Scale.Y, Actor.Scale.Z);
                Vector3 hede2 = new Vector3(1, 1,1);

                hede.X = 1.0f + (dist / 1000.0f);
                hede.Y = hede.X;
                hede.Z = hede.X;
                Actor.Scale = hede;

                wateract_material = Actor.As<StaticModel>().GetMaterial(0, 0);
                wateract_material.SetParameterValue("SunDir", -sun.Transform.Forward);
                skybox_material.SetParameterValue("SunDir", -sun.Transform.Forward);
          

            }




            // Here you can add code that needs to be called every frame
        }
    }
}
