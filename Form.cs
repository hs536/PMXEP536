﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;
using SlimDX;
using System.Diagnostics;

namespace PMXEP536{
    public partial class Form : System.Windows.Forms.Form{
        private static string[] LR = new string[] { "左", "右" };

        private IPERunArgs _args;
        private IPEConnector _connector;
        private Form_ConsoleLog _console;

        //---CONSTRUCTOR---//
        public Form()
        {
            InitializeComponent();
            _console = new Form_ConsoleLog(this.console_box,this.console_box_filter);
            _console.debug("Initialized Form object.");
        }

        // Close Action
        private void Form_FormClosing(object sender, FormClosingEventArgs e) { 
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _console.debug("Form_FormClosing");
                e.Cancel = true;
                this.Visible = false;
            }
        }

        // プラグインからを値を受け渡す変数を受け取る関数
        public void SetHostArgs(IPERunArgs args){
            this.FormClosing += Form_FormClosing;
            _args = args;
            _connector = _args.Host.Connector;
            _console.debug("PMX:"+_args.Host.Connector.Pmx.ToString());
        }

        // 実行オネシャス
        private void execute(object sender, EventArgs e)
        {
            try { 
                _console.debug("開始：プラグイン処理");
               ModelObject model_object = new ModelObject(_connector);
                //■読み込み設定
                if (this.bone_rename.Checked)
                {
                    string proc_name = this.bone_rename.Text;
                    _console.info("開始：" + proc_name);
                    run_bone_rename(model_object);
                    this.bone_rename.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                if (this.bone_add_stdbone.Checked)
                {
                    string proc_name = this.bone_add_stdbone.Text;
                    _console.info("開始：" + proc_name);
                    run_bone_add_stdbone(model_object);
                    this.bone_add_stdbone.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                //■材質
                if (this.mat_default_setting.Checked)
                {
                    string proc_name = this.mat_default_setting.Text;
                    _console.info("開始：" + proc_name);
                    run_mat_default_setting(model_object);
                    this.mat_default_setting.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                //■ボーン
                if (this.bone_setup_eyes.Checked)
                {
                    string proc_name = this.bone_setup_eyes.Text;
                    _console.info("開始：" + proc_name);
                    run_bone_setup_eyes(model_object);
                    this.bone_setup_eyes.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                if (this.bone_setup_legIK.Checked)
                {
                    string proc_name = this.bone_setup_legIK.Text;
                    _console.info("開始：" + proc_name);
                    run_bone_setup_legIK(model_object);
                    this.bone_setup_legIK.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                if (this.bone_sort.Checked)
                {
                    string proc_name = this.bone_sort.Text;
                    _console.info("開始：" + proc_name);
                    run_bone_sort(model_object);
                    this.bone_sort.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                if (this.bone_visible.Checked)
				{
                    string proc_name = this.bone_visible.Text;
					_console.info("開始：" + proc_name);
                    run_bone_visible(model_object);
                    this.bone_visible.Checked = false;
					_console.info("完了：" + proc_name);

				}

				if (this.bone_setup_view.Checked)
				{
					string proc_name = this.bone_setup_view.Text;
					_console.info("開始：" + proc_name);
					run_bone_setup_view(model_object);
					this.bone_setup_view.Checked = false;
					_console.info("完了：" + proc_name);

				}
                //■モーフ
                if (this.mo_setup_view.Checked)
                {
                    string proc_name = this.mo_setup_view.Text;
                    _console.info("開始：" + proc_name);
                    run_mo_setup_view(model_object);
                    this.mo_setup_view.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                //■テスト
                if (this.test_invalid_value.Checked)
                {
                    string proc_name = this.test_invalid_value.Text;
                    _console.info("開始：" + proc_name);
                    run_test_invalid_value(model_object);
                    this.test_invalid_value.Checked = false;
                    _console.info("完了：" + proc_name);
                }
                updateModelAndView(model_object);
                _console.info("完了：プラグイン処理");
            }
            catch (Exception ex)
            {
                _console.error(ex.Message+ Environment.NewLine +ex.StackTrace);
            }
        }

        private void run_bone_rename(ModelObject model_object)
        {
            StreamReader BONE_MAP = new StreamReader(@"_plugin/User/BoneMap.csv",
                System.Text.Encoding.GetEncoding("UTF-8"));//No,PMX,PMX_en,Humanoid,VRM
            IDictionary<string, string> jamap = new Dictionary<string, string>();
            IDictionary<string, string> enmap = new Dictionary<string, string>();
            while (!BONE_MAP.EndOfStream)
            {
                string line = BONE_MAP.ReadLine();
                string[] values = line.Split(',');
                if ("-"!=values[3]){
                    jamap.Add(values[3], values[1]);
                    enmap.Add(values[3], values[2]);
                }
            }
            BONE_MAP.Close();
            foreach (IPXBone bone in model_object.bones)
            {
                string name = bone.Name;
                if (jamap.ContainsKey(name))
                {
                    _console.debug(new StringBuilder()
                        .Append("rename:").Append(bone.Name).Append("->").Append(jamap[name]).ToString());
                    bone.Name = jamap[name];
                    bone.NameE = enmap[name];
                }
                else
                { 
                    if (name.Contains(".L"))
                    {
                        string new_name = "左" + name.Replace(".L", "");
                        _console.debug(new StringBuilder().Append("rename:").Append(bone.Name).Append("->").Append(new_name).ToString());
                        bone.Name = new_name;
                        bone.NameE = name.Replace(".L", "_L");
                    }
                    else if (name.Contains(".R"))
                    {
                        string new_name = "右" + name.Replace(".R", "");
                        _console.debug(new StringBuilder().Append("rename:").Append(bone.Name).Append("->").Append(new_name).ToString());
                        bone.Name = new_name;
                        bone.NameE = name.Replace(".R", "_R");
                    }
                    name = bone.Name;
                    if (name.Contains("_Tip")) {
                        string new_name = name.Replace("_Tip", "先");
                        _console.debug(new StringBuilder().Append("rename:").Append(bone.Name).Append("->").Append(new_name).ToString());
                        bone.Name = new_name;
                        bone.NameE = name.Replace("_Tip", "_Tip");
                    }
                }
            }
			_console.debug("名前の変換 完了");

			//下半身ボーンの修正
			model_object.addBoneIfNotExists("下半身");
			IPXBone LowerBody = model_object.getBoneByName("下半身");
			model_object.addBoneIfNotExists("上半身");
            IPXBone UpperBody = model_object.getBoneByName("上半身");
            IPXBone Center = model_object.getBoneByName("センター");
            LowerBody.Parent = Center;
			LowerBody.Position = UpperBody.Position.Clone();
            LowerBody.ToBone = null;
            LowerBody.IsRotation = true;
            LowerBody.IsTranslation = false;
			LowerBody.ToOffset = new V3(0.0f,-1.0f,0.0f);
			_console.debug("Hips->下半身変換 完了");

            //つま先ボーン
            foreach (string str in LR) {
                IPXBone UpperLeg = model_object.getBoneByName(str + "足");
                IPXBone LowerLeg = model_object.getBoneByName(str + "ひざ");
                IPXBone Foot = model_object.getBoneByName(str + "足首");
                IPXBone Toe = model_object.getBoneByName(str + "つま先");
                IPXBone Toe_Ex = model_object.getBoneByName(str + "足先EX");
                IPXBone LegIK = model_object.getBoneByName(str + "足ＩＫ");
                IPXBone ToeIK = model_object.getBoneByName(str + "つま先ＩＫ");

                IPXBone UpperLeg_D = (IPXBone)UpperLeg.Clone();
                UpperLeg_D.Name = str + "足D";
                UpperLeg_D.NameE += "_D";
                UpperLeg_D.AppendParent = UpperLeg;
                UpperLeg_D.AppendRatio = 1.0f;
                UpperLeg_D.IsAppendRotation = true;
                UpperLeg_D.Visible = false;
                UpperLeg_D.Level = 1;
                IPXBone LowerLeg_D = (IPXBone)LowerLeg.Clone();
                LowerLeg_D.Name = str + "ひざD";
                LowerLeg_D.NameE += "_D";
                LowerLeg_D.AppendParent = LowerLeg;
                LowerLeg_D.AppendRatio = 1.0f;
                LowerLeg_D.IsAppendRotation = true;
                LowerLeg_D.Visible = false;
                LowerLeg_D.Level = 1;
                IPXBone Foot_D = (IPXBone)Foot.Clone();
                Foot_D.Name = str + "足首D";
                Foot_D.NameE += "_D";
                Foot_D.AppendParent = Foot;
                Foot_D.AppendRatio = 1.0f;
                Foot_D.IsAppendRotation = true;
                Foot_D.Visible = false;
                Foot_D.Level = 1;

                int index = model_object.bones.IndexOf(Toe_Ex);
                model_object.bones.Insert(index, UpperLeg_D);
                model_object.bones.Insert(index, LowerLeg_D);
                model_object.bones.Insert(index, Foot_D);
                Toe_Ex.Parent = Foot_D;
                Toe_Ex.ToOffset = new V3(0.0f, 0.0f, -1.0f);
                Toe_Ex.Level = 1;

                Toe.Parent = Foot;
                Foot.ToBone = Toe;
            }
		}

        private void run_bone_add_stdbone(ModelObject model_object)
        {
            model_object.addBoneIfNotExists("センター");
            IPXBone Center = model_object.getBoneByName("センター");
            Center.Position = new V3(0.0f, 8.0f, 0.0f);
            Center.ToOffset = new V3(0.0f, -8.0f, 0.0f);
            Center.IsTranslation = true;

            if (model_object.isExistsBone("上半身")) {
                IPXBone UpperBody = model_object.getBoneByName("上半身");
                UpperBody.Parent = Center;
            }
            if (model_object.isExistsBone("下半身"))
            {
                IPXBone LowerBody = model_object.getBoneByName("下半身");
                LowerBody.Parent = Center;
            }
            _console.debug("センターボーンの設定完了");

            model_object.addBoneIfNotExists("全ての親");
            IPXBone Master = model_object.getBoneByName("全ての親");
            Master.ToBone = Center;
            Master.IsTranslation = true;
            Center.Parent = Master;
            if (model_object.isExistsBone("右足ＩＫ")) { 
                IPXBone LegIK_R = model_object.getBoneByName("右足ＩＫ");
                LegIK_R.Parent = Master;
            }
            if (model_object.isExistsBone("左足ＩＫ"))
            {
                IPXBone LegIK_L = model_object.getBoneByName("左足ＩＫ");
                LegIK_L.Parent = Master;
            }
            _console.debug("全ての親ボーンの設定完了");
        }

        private void run_bone_sort(ModelObject model_object)
        {
            StreamReader BONE_MAP = new StreamReader(@"_plugin/User/BoneMap.csv",
                System.Text.Encoding.GetEncoding("UTF-8"));//No,PMX,PMX_en,Humanoid,VRM
            //rename
            IDictionary<string, string> name_map = new Dictionary<string, string>();
            IList<string> list = new List<string>();

            while (!BONE_MAP.EndOfStream)
            {
                string line = BONE_MAP.ReadLine();
                string[] values = line.Split(',');
                if (Util.isInt(values[0]))
                {
                    name_map.Add(values[1], new StringBuilder().Append(int.Parse(values[0]).ToString("D4"))
                        .Append("_").Append(values[1]).ToString());
                }
            }
            BONE_MAP.Close();
            foreach (IPXBone bone in model_object.bones)
            {
                string beforeName = bone.Name;
                if (name_map.ContainsKey(beforeName))
                {
                    bone.Name = name_map[beforeName];
                }
                else
                {
                    bone.Name = new StringBuilder().Append("9999_").Append(beforeName).ToString();
                }
            }
            //sort
            IList<IPXBone> bones = model_object.bones;
            IList<IPXBone> sorted = model_object.bones.OrderBy(x => x.Name).ToArray();

            foreach (IPXBone bone in sorted)
            {
//                _console.debug("bones.Add:" + bone.Name);
                bones.Add(bone);
                bones.RemoveAt(0);
            }
            //re-rename
            foreach (IPXBone bone in bones)
            {
                bone.Name = bone.Name.Substring(5);
            }
        }


        private void run_bone_visible(ModelObject model_object) 
        {
            StreamReader BONE_MAP = new StreamReader(@"_plugin/User/BoneMap.csv",
                   System.Text.Encoding.GetEncoding("UTF-8"));//No,PMX,PMX_en,Humanoid,VRM
            //rename
            IDictionary<string, string> visible_map = new Dictionary<string, string>();
            IList<string> list = new List<string>();

            while (!BONE_MAP.EndOfStream) {
                string line = BONE_MAP.ReadLine();
                string[] values = line.Split(',');
                if (Util.isInt(values[0])) {
                    visible_map.Add(values[1], values[7]);
                }
            }
            BONE_MAP.Close();
            foreach (IPXBone bone in model_object.bones) {
                String name = bone.Name;
                if (visible_map.ContainsKey(name)) {
                    bone.Visible = bool.Parse(visible_map[name]);
                }else if(name.Contains("先")){
                    bone.Visible = false;
                }
            }
        }

		private void run_bone_setup_view(ModelObject model_object)
		{
			IPXNode root_node = model_object.nodes_root;
			IList<IPXNode> nodes = model_object.nodes_bone;
            root_node.Items.Clear();
			nodes.Clear();
			IPXNode Center = PEStaticBuilder.Pmx.Node();
			Center.Name = "センター";
			Center.NameE = "Center";
			IPXNode IK = PEStaticBuilder.Pmx.Node();
            IK.Name = "ＩＫ";
			IK.NameE = "IK";
			IPXNode UpperBody = PEStaticBuilder.Pmx.Node();
			UpperBody.Name = "体(上)";
			UpperBody.NameE = "UpperBody";
			IPXNode Hair = PEStaticBuilder.Pmx.Node();
			Hair.Name = "髪";
			Hair.NameE = "Hair";
			IPXNode Arms = PEStaticBuilder.Pmx.Node();
			Arms.Name = "腕";
			Arms.NameE = "Arms";
			IPXNode Fingers = PEStaticBuilder.Pmx.Node();
			Fingers.Name = "指";
			Fingers.NameE = "Fingers";
			IPXNode LowerBody = PEStaticBuilder.Pmx.Node();
			LowerBody.Name = "体(下)";
			LowerBody.NameE = "LowerBody";
			IPXNode Legs = PEStaticBuilder.Pmx.Node();
			Legs.Name = "足";
			Legs.NameE = "Legs";
			IPXNode Etc = PEStaticBuilder.Pmx.Node();
			Etc.Name = "その他";
			Etc.NameE = "Etc";

            StreamReader BONE_MAP = new StreamReader(@"_plugin/User/BoneMap.csv",
                System.Text.Encoding.GetEncoding("UTF-8"));//No,PMX,PMX_en,Humanoid,VRM
            //rename
            IDictionary<string, string> name_map = new Dictionary<string, string>();
            IList<string> list = new List<string>();

            while (!BONE_MAP.EndOfStream)
            {
                string line = BONE_MAP.ReadLine();
                string[] values = line.Split(',');
                if (Util.isInt(values[0]))
                {
                    name_map.Add(values[1], values[6]);
                }
            }
            BONE_MAP.Close();

            foreach (IPXBone bone in model_object.bones) {
                String name = bone.Name;

                if (name_map.ContainsKey(name)) {
                    switch (name_map[name]) {
                        case "-":
                            break;
                        case "Root":
                            root_node.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "センター":
                            Center.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "ＩＫ":
                            IK.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "体(上)":
                            UpperBody.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "腕":
                            Arms.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "指":
                            Fingers.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "体(下)":
                            LowerBody.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                        case "足":
                            Legs.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                            break;
                    }
                } else if(name.EndsWith("先")){
                    continue;
                } else if ((name.Contains("髪") || name.ToLower().Contains("hair"))) {
                    Hair.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                } else {
                    Etc.Items.Add(PEStaticBuilder.Pmx.BoneNodeItem(bone));
                }
            }

			nodes.Add(Center);
			nodes.Add(IK);
			nodes.Add(UpperBody);
			nodes.Add(Hair);
			nodes.Add(Arms);
			nodes.Add(Fingers);
			nodes.Add(LowerBody);
			nodes.Add(Legs);
			nodes.Add(Etc);
		}

		private void run_mat_default_setting(ModelObject model_object)
        {
            foreach (IPXMaterial material in model_object.materials)
            {
                _console.debug(material.Name + "を処理中");
                material.Diffuse = new V4(1.0f, 1.0f, 1.0f, 1.0f); //拡散色・非透過度
                material.Specular = new V3(0.0f, 0.0f, 0.0f); //反射色
                material.Ambient = new V3(0.5f, 0.5f, 0.5f); //環境色
                material.Power = 3.2f;//反射強度
                material.Shadow = true;  //地面影
                material.SelfShadowMap = true; //セルフ影マップ
                material.SelfShadow = true; //セルフ影
                material.Edge = true;
                material.EdgeSize = 1.0f;
                material.EdgeColor = new V4(0.0f, 0.0f, 0.0f,1.0f);//RGBA
            }
        }

        private void run_bone_setup_eyes(ModelObject model_object)
        {
            model_object.addBoneIfNotExists("両目");
            IPXBone Eyes = model_object.getBoneByName("両目");
            Eyes.Parent = model_object.getBoneByName("頭");
            Eyes.Position = new V3(0.0f, 21.0f, -0.7f);
            Eyes.ToOffset = new V3(0.0f, 0.0f, -0.5f);

            if (model_object.isExistsBone("左目"))
            {
                IPXBone LeftEye = model_object.getBoneByName("左目");
                LeftEye.IsAppendRotation = true;
                LeftEye.AppendRatio = 1.0f;
                LeftEye.AppendParent = Eyes;
            }
            if (model_object.isExistsBone("右目"))
            {
                IPXBone RightEye = model_object.getBoneByName("右目");
                RightEye.IsAppendRotation = true;
                RightEye.AppendRatio = 1.0f;
                RightEye.AppendParent = Eyes;
            }
        }

        private void run_bone_setup_legIK(ModelObject model_object)
        {
            foreach (string str in LR) { 
                IPXBone UpperLeg = model_object.getBoneByName(str+"足");
                IPXBone LowerLeg = model_object.getBoneByName(str+ "ひざ");
                IPXBone Foot = model_object.getBoneByName(str+"足首");
                IPXBone Toe = model_object.getBoneByName(str+"つま先");

                IPXBone LegIK = model_object.getBoneByName(str+"足ＩＫ");
                IPXBone ToeIK = model_object.getBoneByName(str+ "つま先ＩＫ");

                LegIK.Position = Foot.Position.Clone();
                LegIK.IsIK = true;
                LegIK.IK.Target = Foot;
                LegIK.IK.LoopCount = 40;
                LegIK.IK.Angle = Util.CalcToRadian(114.5916f);
                LegIK.IK.Links.Clear();

				IPXIKLink LowerLegIKLink = (IPXIKLink)PEStaticBuilder.Pmx.IKLink();
				LowerLegIKLink.Bone = LowerLeg;
				LowerLegIKLink.IsLimit = true;
				LowerLegIKLink.Low = new V3(
					Util.CalcToRadian(-180.0f), 0.0f, 0.0f);
				LowerLegIKLink.High = new V3(
					Util.CalcToRadian(-0.5f), 0.0f, 0.0f);
				LegIK.IK.Links.Add(LowerLegIKLink);

				IPXIKLink UpperLegIKLink = (IPXIKLink)PEStaticBuilder.Pmx.IKLink();
                UpperLegIKLink.Bone = UpperLeg;
                LegIK.IK.Links.Add(UpperLegIKLink);
                _console.debug(str+"足IK設定完了");

                ToeIK.Position = Toe.Position.Clone();
                Toe.Level = 1;
                if(model_object.isExistsBone(str + "つま先ＩＫ先"))
                {
                    model_object.getBoneByName(str + "つま先ＩＫ先").Level=1;
                }
                ToeIK.Level = 1;
                ToeIK.IsIK = true;
                ToeIK.IK.Target = Toe;
                ToeIK.IK.LoopCount = 3;
                ToeIK.IK.Angle = Util.CalcToRadian(229.1831f);
                ToeIK.IK.Links.Clear();

                IPXIKLink FootIKLink = (IPXIKLink)PEStaticBuilder.Pmx.IKLink();
                FootIKLink.Bone = Foot;
                ToeIK.IK.Links.Add(FootIKLink);
                _console.debug(str + "つま先IK設定完了");
            }
        }

        private void run_mo_setup_view(ModelObject model_object)
        {
            StreamReader MORPH_MAP = new StreamReader(@"_plugin/User/MorphMap.csv",
                System.Text.Encoding.GetEncoding("UTF-8"));//No,PMX,PMX_en
            IDictionary<string, int> typemap = new Dictionary<string, int>();
            IDictionary<string, string> enmap = new Dictionary<string, string>();
            while (!MORPH_MAP.EndOfStream)
            {
                string line = MORPH_MAP.ReadLine();
                string[] values = line.Split(',');
                if(Util.isInt(values[1])){ 
                    typemap.Add(values[2], int.Parse(values[1]));
                    enmap.Add(values[2], values[3]);
                }
            }
            MORPH_MAP.Close();
            IList<IPXNodeItem> items = model_object.nodes_exp.Items;
            items.Clear();
            int enNameIndex = 0;
            foreach (IPXMorph morph in model_object.morphs)
            {
                if (typemap.ContainsKey(morph.Name))
                {
                    morph.NameE = enmap[morph.Name];
                    morph.Panel = typemap[morph.Name];
                }
                else
                {
                    morph.NameE = "NoEnName_" + enNameIndex;
                    morph.Panel = 4;
                    enNameIndex++;
                }
                IPXNodeItem item = PEStaticBuilder.Pmx.MorphNodeItem(morph);
                items.Add(item);
            }
        }

        private void run_test_invalid_value(ModelObject model_object)
        {
            _console.debug("ボーン順の検証：");
            IList<IPXBone> bones = model_object.bones;
            foreach (IPXBone bone in bones) {
                if (bones.IndexOf(bone.Parent) > bones.IndexOf(bone)) {
                    throw new System.Exception(
                        new StringBuilder().Append("子：").Append(bone.Name).Append("->親：")
                        .Append(bone.Parent.Name).Append("のボーン順が不正です").ToString());
                }
            }
            _console.info("ボーン順の検証：OK");
        }
        
        //モデル・画面を更新を行います
        private void updateModelAndView(ModelObject model_object)
        {
            _connector.Pmx.Update(model_object.getPMX());
            _connector.Form.UpdateList(UpdateObject.All);
            _connector.View.PMDView.UpdateModel();
            _connector.View.PMDView.UpdateView();
        }

        //コンソールクリア
        private void clear_console_click(object sender, EventArgs e)
        {
            _console.clear();
        }

        //for debug log
        public void debuglog(string message)
        {
            _console.debug(message);
        }
        
    }
}
