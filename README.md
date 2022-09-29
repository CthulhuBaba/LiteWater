# LiteWater
## LiteWater is a simple infinite water template for Flax Engine users.
Here is a quick preview:

![watergif](https://user-images.githubusercontent.com/31192693/193070133-55a794c4-e1a5-437b-b634-4554162b85fd.gif)

You can also take a closer look by watching the video below.

[![](https://img.youtube.com/vi/RNBocVNCjE8/0.jpg)](https://www.youtube.com/watch?v=RNBocVNCjE8)



## What does it offer?
- Good looking infinite and fully customizable sea with VTF.

### You can customize it as you wish. There are also 8 different instances ready.
![exp](https://user-images.githubusercontent.com/31192693/193071553-c4e54118-1362-4241-88ab-3f709a1e4526.jpg)




## Some important info:
- Does not include FFT. It is heightmap based.
- Projected Vertex method is not used, it is model/tesellation based.


## How To Integrate?

- Copy the "LiteWaterContent" folder into your project's "content" folder
- Copy "CustomDepth.cs", "CustomRefraction.cs" and "Water.cs" files, to your project's source/game folder. 
- Add Water model to your scene, then attach the "Water" script to the model. 
- Attach the "WaterShader" to the model.
- Be sure water model not casting any shadow.

![cast](https://user-images.githubusercontent.com/31192693/193108759-5083279b-9333-47cd-a3ac-8590b4ec0da0.jpg)

- Set the water layer as "Bullets" or another layer which you prefer.

![layer](https://user-images.githubusercontent.com/31192693/193108882-5456f906-b40d-49d6-afa7-32e9f7b3a767.jpg)

- Add a camera then attach the "Custom Depth" script to it. And under the "Render Layer Mask" uncheck the "Bullets" layer. 

![bullets](https://user-images.githubusercontent.com/31192693/193108952-74e18024-8223-4a8a-af56-f84ddbe40ecd.jpg)

- Add a camera then attach the "Custom refraction" script to it. And under the "Render Layer Mask" uncheck the "Bullets" layer. 
- Select one of the instances (lets say: "WaterSet4") from "Instances" folder and attach it to the water.
DONE!

If it seemed too complicated, you can watch the video below.

[![](https://img.youtube.com/vi/HEMd9PwBSAI/0.jpg)](https://www.youtube.com/watch?v=HEMd9PwBSAI)

## License

Feel free to use for your projects. Credit are welcome but not necessary. 

## Contact
You can reach me via pantharay@gmail.com. 
Have fun!

Emre
