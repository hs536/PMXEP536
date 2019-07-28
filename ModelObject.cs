using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;
using SlimDX;

namespace PMXEP536
{
    public class ModelObject
    {
        private IPEConnector _connector;
        private IPXPmx _pmx;
        private IPEFormConnector _form;

        public IPXModelInfo       info;     //情報
        public IList<IPXMaterial> materials;//材質
        public IList<IPXBone>     bones;    //ボーン
        public IList<IPXMorph>    morphs;   //モーフ
        public IPXNode            nodes_root; //表示枠_[Root]
        public IPXNode            nodes_exp;  //表示枠_[表情]
        public IList<IPXNode>     nodes_bone; //表示枠_ボーン
        public IList<IPXBody>     bodies;   //剛体
        public IList<IPXJoint>    joints;   //Joint

        //---CONSTRUCTOR---//
        public ModelObject(IPEConnector connector)
        {
            _connector = connector;
            _pmx = _connector.Pmx.GetCurrentState();
            _form = _connector.Form;

            info = _pmx.ModelInfo;
            materials = _pmx.Material;
            bones = _pmx.Bone;
            morphs = _pmx.Morph;
            nodes_root = _pmx.RootNode;
            nodes_exp = _pmx.ExpressionNode;
            nodes_bone = _pmx.Node;
            bodies = _pmx.Body;
            joints = _pmx.Joint;
        }

        //デコンストラクタ(終了処理)
        //モデル描画の更新を行います
        // ~ModelObject()
        // {
        //  updateModelAndView();
        //  }

        public IPXPmx getPMX()
        {
            return _pmx;
        }
        
        //名前からボーンを取得
        public IPXBone getBoneByName(string bone_name)
        {
            int id = this.getBoneIndexByName(bone_name);
            if (id != -1)
            {
                return this._pmx.Bone[id];
            }
            throw new System.Exception(bone_name + "なんてボーン、無いみたいですよ？");
        }
        
        //名前からボーンIDを取得
        public int getBoneIndexByName(string bone_name)
        {
            for (int i = 0; i < _pmx.Bone.Count; i++)
            {
                if (bone_name.Equals(_pmx.Bone[i].Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool isExistsBone(string bone_name)
        {
            return getBoneIndexByName(bone_name) != -1;
        }

        public void addBoneIfNotExists(string bone_name)
        {
            if (!isExistsBone(bone_name))
            {
                IPXBone new_bone = PEStaticBuilder.Pmx.Bone();
//                Util.InitBone(new_bone);
                new_bone.Name = bone_name;
                bones.Add(new_bone);
            }
        }
    }
}
