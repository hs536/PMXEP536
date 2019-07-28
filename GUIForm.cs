using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.SDX;
using PEPlugin.Pmx;
using PEPlugin.Pmd;
using PEPlugin.Vmd;
using PEPlugin.Vme;
using PEPlugin.Form;
using PEPlugin.View;
using SlimDX;

namespace PMXEP536 {
    public partial class GUIForm : Form {

        private IPERunArgs args;
        private IPEPluginHost host;
        private IPEConnector connect;
        private IPXPmx PMX;

        private StringBuilder sb = new StringBuilder();
        private ModelObject mo;

        public GUIForm() {
            InitializeComponent();
        }

        /// <summary>
        /// プラグインからを値を受け渡す変数を受け取る関数
        /// </summary>
        /// <param name="args"></param>
        public void SetHostArgs(IPERunArgs args) {
            this.FormClosing += GUIForm_FormClosing;
            this.args = args;
        }


        private void button1_Click(object sender, EventArgs e) {
            mo = new ModelObject(args);
            if (checkBox1.Checked) {
                setFootIK();
            }
            if (checkBox2.Checked){
                setEye();
            }
            if (checkBox3.Checked){
                setMaterialCollor();
            }
            mo.updateModelAndView();
            sb.AppendLine("処理が終わったよ！");
            MessageBox.Show(sb.ToString(), EditUtil.SHOW_RESULT);
            sb.Clear();
        }

        private void GUIForm_Load(object sender, EventArgs e) {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { 

        }


        ///<summary>足IKのセットアップ</summary>
        private void setFootIK() {
            foreach (string key in mo.LR) {
                IPXBone tik = (IPXBone)mo.Bone(key + "つま先ＩＫ");
                tik.IsTranslation = true;
                tik.IsIK = true;
                tik.IK.Target = mo.Bone(key + "つま先");
                tik.IK.LoopCount = 3;
                tik.IK.Angle = 4f;
                mo.bone.addIKLink(tik, (IPXBone)mo.Bone(key + "足首"));

                IPXBone aik = (IPXBone)mo.Bone(key + "足ＩＫ");
                aik.IsTranslation = true;
                aik.IsIK = true;
                aik.IK.Target = mo.Bone(key + "足首");
                aik.IK.LoopCount = 40;
                aik.IK.Angle = 2f;
                V3 LL = new V3(-3.141592653589793f, 0.0f, 0.0f);
                V3 LH = new V3(-0.008726646259971648f, 0.0f, 0.0f);
                mo.bone.addIKLinkLimit(aik, mo.Bone(key + "ひざ"), LH, LL);
                mo.bone.addIKLink(aik, (IPXBone)mo.Bone(key + "足"));
            }
        }

        ///<summary>両目骨のセットアップ</summary>
        private void setEye() {
            IPXBone ryome = mo.Bone("両目");
            foreach (string key in mo.LR) {
                IPXBone me = mo.Bone(key + "目");
                me.IsAppendRotation = true;
                me.AppendRatio = 1;
                me.AppendParent = ryome;
            }
        }

        ///<summary>材質色のセットアップ</summary>
        private void setMaterialCollor() {
            int i=0;
            while(i<mo.material.getMaterialCount()){
                mo.Material(i).Diffuse=new V4(1.0f,1.0f,1.0f,1.0f);
                mo.Material(i).Specular=new V3(0.0f,0.0f,0.0f);
                mo.Material(i).Ambient = new V3(0.5f, 0.5f, 0.5f);
                i++;
            }
            mo.Material("肌").Toon = "";
        }

        /// <summary>
        /// フォームの閉じるボタンを押した際の関数
        /// ここではフォームを非表示にします。
        /// FormClosingにこの関数を設定してください。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUIForm_FormClosing(object sender, FormClosingEventArgs e) {
                e.Cancel = true;
                this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
