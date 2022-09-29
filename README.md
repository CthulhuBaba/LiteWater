# LiteWater
## LiteWater is a simple water template for Flax Engine users.

![watergif](https://user-images.githubusercontent.com/31192693/193070133-55a794c4-e1a5-437b-b634-4554162b85fd.gif)

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
- Set the water layer as "Bullets" or another layer which you prefer.
- Add a camera then attach the "Custom Depth" script to it. And under the "Render Layer Mask" uncheck the "Bullets" layer. 
- Add a camera then attach the "Custom refraction" script to it. And under the "Render Layer Mask" uncheck the "Bullets" layer. 
- Select one of the instances (lets say: "WaterSet4") and attach it to the water.
DONE!

If it seemed too complicated, you can watch the video below.

[![](https://img.youtube.com/vi/HEMd9PwBSAI/0.jpg)](https://www.youtube.com/watch?v=YHEMd9PwBSAI)

## License?

Feel free to use for your projects. Credit are welcome but not necessary. 
