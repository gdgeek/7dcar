using UnityEngine;
using System.Collections;
namespace GDGeek{
	[ExecuteInEditMode]
	public class VoxelBuilder : MonoBehaviour {
		public TextAsset _voxFile = null;
		public bool _building = true;

		public VoxelTextAssetLoader _loader = null;	
		public VoxelModel _model = null;
		public VoxelMesh _mesh = null;


		// Use this for initialization
		void Start () {
		
		}

		private void initModel(){
			if(_model == null){
				_model = this.gameObject.GetComponent<VoxelModel>();
			}
			
			if(_model == null){
				this._model = this.gameObject.AddComponent<VoxelModelCache>();
			}
		}
		private void initLoader(){
			
			if(_loader == null){
				_loader  = this.gameObject.GetComponent<VoxelTextAssetLoader>();
			}
			
			
			if(_loader == null){
				_loader  = this.gameObject.AddComponent<VoxelTextAssetLoader>();
			}
			_loader._voxFile = this._voxFile;
			_loader._model = _model;
		}
		private void initShadow(){
			/*
			if(_shadow == null){
				_shadow  = this.gameObject.GetComponent<VoxelShadow>();
			}
			
			
			if(_shadow == null){
				_shadow  = this.gameObject.AddComponent<VoxelShadow>();
			}
			_shadow._material = _shadowMaterial;
			*/
		}
		
		void initMesh ()
		{
			if(_mesh == null){
				this._mesh = this.gameObject.GetComponent<VoxelMesh>();
			}
			if(_mesh == null){
				this._mesh = this.gameObject.AddComponent<VoxelMesh>();
				
			}
			
			
			if(this._mesh._material == null){
#if UNITY_EDITOR
				this._mesh._material = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>("Assets/Media/Material/VoxelMesh.mat");
#endif
			}
		}

		// Update is called once per frame
		void Update () {
			if (_building == true && _voxFile != null) {

	
				initModel();
				initLoader();
				initMesh();
				
				if(!_mesh.empty){
					_mesh.clear ();
				}	


				_loader.read();

				if(_mesh.empty){
					_mesh.build (_model.data);
					
					VoxelFunctionManager vf = _model.gameObject.GetComponent<VoxelFunctionManager>();
					if(vf != null){
						vf.build(_mesh);
					}
				}	
				
				_building = false;	
			}
		}
	}

}