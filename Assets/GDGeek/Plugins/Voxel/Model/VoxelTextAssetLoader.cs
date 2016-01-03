using UnityEngine;
using System.Collections;
using System.IO;


namespace GDGeek{
	public class VoxelTextAssetLoader : VoxelLoader {
		//public bi
		public TextAsset _voxFile = null;
		public override void read () {
			if (_voxFile != null) {
				Stream sw = new MemoryStream(_voxFile.bytes);
				//System.IO.StringReader
				System.IO.BinaryReader br = new System.IO.BinaryReader (sw); 
				if(_model != null){
					_model.data = VoxelReader.FromMagica (br);
				}
			}
			
		}

		public override bool resource () {
			
			return _voxFile != null;
			
		}

	}
}
