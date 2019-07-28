using System;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace PMXEP536
{
    class Util
    {
        //角度->ラジアン
        public static float CalcToRadian(float angle)
        {
            return angle * (float)Math.PI / 180.0f;
        }
        
        //ラジアン->角度
        public static float CalcToAngle(float radian)
        {
            return radian * 180.0f / (float)Math.PI;
        }

        //intにパースできるか
        public static Boolean isInt(string num_str)
        {
            try
            {
                int.Parse(num_str);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

        //ボーン初期化
        public static void InitBone(IPXBone bone)
        {
            bone.Name = "";
            bone.NameE = "";

            //変形階層
            bone.Level = 0;
            bone.IsAfterPhysics = false;

            //位置
            bone.Position = new V3(0.0f, 0.0f, 0.0f);

            //性能
            bone.IsRotation = true;
            bone.IsTranslation = false;
            bone.IsIK = false;
            bone.Visible = true;
            bone.Controllable = true;

            //親ボーン
            bone.Parent = null;

            //表示先
            bone.ToOffset = new V3(0.0f, 0.0f, 0.0f);
            bone.ToBone = null;

            //回転付与
            bone.IsAppendRotation = false;
            bone.IsAppendTranslation = false;
            bone.AppendRatio = 1.0f;
            bone.AppendParent = null;

            //軸制限
            bone.IsFixAxis = false;
            bone.FixAxis = new V3(0.0f, 0.0f, 0.0f);

            //ローカル軸
            bone.IsLocalFrame = false;
            bone.SetLocalAxis(new V3(1.0f, 0.0f, 0.0f), new V3(0.0f, 0.0f, 1.0f));

            //IK
            bone.IK.Target = null;
            bone.IK.LoopCount = 0;
            bone.IK.Angle = 0.0f;
            bone.IK.Links.Clear();

            //外部親
            bone.IsExternal = false;
            bone.ExternalKey = 0;
        }
    }
}
