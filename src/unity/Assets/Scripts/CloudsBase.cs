/*
The MIT License (MIT)

Copyright (c) 2015 Huw Bowles & Daniel Zimmermann

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Camera))]
public abstract class CloudsBase : UnityStandardAssets.ImageEffects.PostEffectsBase
{
	public Shader cloudsShader;
	protected Material cloudsMaterial = null;
	public Texture2D noiseTexture;

	public override bool CheckResources()
	{
		CheckSupport( true );
		
		cloudsMaterial = CheckShaderAndCreateMaterial( cloudsShader, cloudsMaterial );
		
		SetCameraFlag();
		
		if( !isSupported )
			ReportAutoDisable();

		return isSupported;
	}
	
	void OnEnable()
	{
		SetCameraFlag();
	}
	
	void SetCameraFlag()
	{
		GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
	}
	
	public static float halfFov_horiz_rad
	{
		get
		{
			return Camera.main.aspect * Camera.main.fieldOfView * Mathf.Deg2Rad / 2.0f;
		}
	}

	public static float halfFov_vert_rad
	{
		get
		{
			return Camera.main.fieldOfView * Mathf.Deg2Rad / 2.0f;
		}
	}

    protected virtual void RenderSetupInternal()
    {
    }
}
