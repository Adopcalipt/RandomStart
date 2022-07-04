using GTA;
using GTA.Math;
using GTA.Native;
using RandomStart.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RandomStart
{
    public class RsActions
    {
        public static void CleanUpMess()
        {
            LoggerLight.Loggers("CleanUpMess");

            DataStore.Shoaf = null;
            DataStore.pPilot = null;
            DataStore.RideThis = null;
            DataStore.bFallenOff = false;
            DataStore.bAllowControl = false;
            if (DataStore.iPostAction > 0)
                PostLaunchAct();

            if (!Game.Player.Character.IsInVehicle())
            {
                Game.Player.Character.HasCollision = true;
                Game.Player.Character.FreezePosition = false;
            }
            if (RsReturns.GetMainChar())
            {
                Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "director_mode");
                Game.Player.Character.Task.ClearAll();
            }
            DataStore.vPedTarget = new Vector3(0.00f, 0.00f, 0.00f);
            DataStore.vPlayerTarget = new Vector3(0.00f, 0.00f, 0.00f);
            DataStore.vAreaRest = new Vector3(0.00f, 0.00f, 0.00f);
            DataStore.vHeaven = new Vector3(0.00f, 0.00f, 0.00f);
            DataStore.sExitAn_01 = "";
            DataStore.sExitAn_02 = "";
            DataStore.RanLoc_01.Clear();
            CleanPeds();
            CleanProps();
            CleanVeh();
        }
        public static void PostLaunchAct()
        {
            LoggerLight.Loggers("PostLaunchAct, DataStore.iPostAction == " + DataStore.iPostAction);

            if (DataStore.iPostAction == 1)
            {
                Game.Player.Character.Task.ClearAll();
            }       //Player Driving/Flying
            else if (DataStore.iPostAction == 2)
            {
                if (DataStore.sExitAn_01 != "")
                {
                    ForceAnimOnce(Game.Player.Character, DataStore.sExitAn_01, DataStore.sExitAn_02, Game.Player.Character.Position, Game.Player.Character.Rotation);
                    Game.Player.Character.Detach();
                    while (Function.Call<bool>(Hash.GET_IS_TASK_ACTIVE, Game.Player.Character.Handle, 134))
                        Script.Wait(100);
                    Function.Call(Hash.STOP_ANIM_PLAYBACK, Game.Player.Character.Handle, 0, 0);
                    //Game.Player.Character.Task.ClearAllImmediately();
                }
                else
                    Game.Player.Character.Task.ClearAll();
            }       //Player Animation
            else if (DataStore.iPostAction == 3)
            {
                if (DataStore.iGrouping == 1)
                {
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"));
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"), DataStore.GP_Player);
                }
                else if (DataStore.iGrouping == 2)
                {
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"));
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"), DataStore.GP_Player);
                }
                else if (DataStore.iGrouping == 3)
                {
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"));
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"), DataStore.GP_Player);
                }
                else if (DataStore.iGrouping == 4)
                {
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"));
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"), DataStore.GP_Player);
                }
                else if (DataStore.iGrouping == 5)
                {
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"));
                    Function.Call(Hash.CLEAR_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"), DataStore.GP_Player);
                }
                DataStore.iGrouping = 0;
            }       //GangStar
            else if (DataStore.iPostAction == 4)
            {
                PedScenario(Game.Player.Character, "WORLD_HUMAN_JOG_STANDING", Game.Player.Character.Position, Game.Player.Character.Heading, false);
                Script.Wait(4000);
                Game.Player.Character.Task.ClearAll();
            }       //jogger
            else
            {
                Game.Player.Character.Task.ClearAll();
            }       //Atv-Bike
            DataStore.iPostAction = 0;
        }
        public static void CleanPeds()
        {
            LoggerLight.Loggers("CleanPeds");

            for (int i = 0; i < DataStore.PeddyList.Count; i++)
                DataStore.PeddyList[i].MarkAsNoLongerNeeded();
            DataStore.PeddyList.Clear();
        }
        public static void CleanProps()
        {

            LoggerLight.Loggers("CleanProps");

            for (int i = 0; i < DataStore.PropList.Count; i++)
            {
                DataStore.PropList[i].Detach();
                DataStore.PropList[i].MarkAsNoLongerNeeded();
            }
            DataStore.PropList.Clear();
        }
        public static void CleanVeh()
        {

            LoggerLight.Loggers("CleanVeh");

            for (int i = 0; i < DataStore.VehList.Count; i++)
            {
                DataStore.VehList[i].IsPersistent = false;
                DataStore.VehList[i].MarkAsNoLongerNeeded();
            }
            DataStore.VehList.Clear();
        }
        public static void SetPlayRellGrp()
        {
            LoggerLight.Loggers("SetPlayRellGrp");

            Function.Call(Hash.REMOVE_RELATIONSHIP_GROUP, DataStore.GP_Player);
            DataStore.GP_Player = Game.Player.Character.RelationshipGroup;

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Friend, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, DataStore.GP_Friend);

            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Attack, DataStore.GP_Player);
            Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 5, DataStore.GP_Player, DataStore.GP_Attack);
        }
        public static void ButtonDisabler(int LButt)
        {
            Function.Call(Hash.DISABLE_CONTROL_ACTION, 0, LButt, true);
        }
        public static void LockNLoad(int iAmmo, string sWeap, Ped Peddy)
        {
            Function.Call<bool>(Hash.SET_AMMO_IN_CLIP, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), Function.Call<int>(Hash.GET_MAX_AMMO_IN_CLIP, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), false));
            Function.Call(Hash.SET_PED_AMMO, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sWeap), iAmmo);
        }
        public static void ReturnWeaps()
        {
            LoggerLight.Loggers("ReturnWeaps");

            Ped Peddy = Game.Player.Character;

            if (Function.Call<int>(Hash.GET_PED_TYPE, Peddy.Handle) != 28)
            {
                for (int i = 0; i < DataStore.MySettingsXML.YourWeaps.Count; i++)
                {
                    Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MySettingsXML.YourWeaps[i].PlayWeaps), 0, false, true);

                    for (int ii = 0; ii < DataStore.MySettingsXML.YourWeaps[i].PlayCompsList.Count; ii++)
                    {
                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MySettingsXML.YourWeaps[i].PlayWeaps), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MySettingsXML.YourWeaps[i].PlayCompsList[ii])))
                        {
                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MySettingsXML.YourWeaps[i].PlayWeaps), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MySettingsXML.YourWeaps[i].PlayCompsList[ii]));
                        }
                    }
                    LockNLoad(DataStore.MySettingsXML.YourWeaps[i].Ammos, DataStore.MySettingsXML.YourWeaps[i].PlayWeaps, Peddy);
                }
                Function.Call(Hash.SET_PED_CURRENT_WEAPON_VISIBLE, Game.Player.Character.Handle, false, true, true, true);

            }
        }
        public static void AddTombStone()
        {
            Vector3 Vpos = new Vector3(-282.8405f, 2834.9153f, 53.3622f);
            Vector3 Vrot = new Vector3(0.00f, 0.00f, 151.3774f);
            RsReturns.MyPropBuild("prop_fib_3b_cover1", Vpos, Vrot, 0, false);
        }
        public static void StartTheMod(int iSelects, bool bLoading)
        {
            LoggerLight.Loggers("StartTheMod, iSelects == " + iSelects + ", bLoading == " + bLoading);

            if (DataStore.MyPedCollection.Count == 0)
            {
                DataStore.MySettingsXML.Saved = false;
                XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
            }

            Game.Player.WantedLevel = 0;
            Game.FadeScreenOut(1);
            Game.Player.Character.IsInvincible = true;

            if (bLoading)
            {
                if (!DataStore.bLoadUpOnYacht)
                {
                    Game.Player.Character.FreezePosition = false;
                    Game.Player.Character.HasCollision = true;
                }

                if (Game.Player.Character.Model == PedHash.Franklin)
                {
                    DataStore.sMainChar = "player_one";
                    DataStore.sFunChar01 = "player_zero";
                    DataStore.sFunChar02 = "player_two";
                }
                else if (Game.Player.Character.Model == PedHash.Michael)
                {
                    DataStore.sMainChar = "player_zero";
                    DataStore.sFunChar01 = "player_one";
                    DataStore.sFunChar02 = "player_two";
                }
                else if (Game.Player.Character.Model == PedHash.Trevor)
                {
                    DataStore.sMainChar = "player_two";
                    DataStore.sFunChar01 = "player_one";
                    DataStore.sFunChar02 = "player_zero";
                }
                else
                {
                    DataStore.sMainChar = "player_zero";
                    DataStore.sFunChar01 = "player_one";
                    DataStore.sFunChar02 = "player_two"; ;
                }

                int iRanSel = RsReturns.RandomSeletor();

                if (iRanSel != -1 && DataStore.MySettingsXML.Locate)               
                    RandomLocations(iRanSel);
                else
                {
                    if (DataStore.MySettingsXML.Spawn)
                    {
                        if (!RsReturns.GetMainChar())
                            YourRanPed(DataStore.sMainChar);
                        else
                            PlayerBelter();
                    }
                    else
                    {
                        if (DataStore.MySettingsXML.Saved)
                            YourSavedPed();
                    }
                    Game.Player.Character.IsInvincible = false;
                    Script.Wait(2000);
                    Game.FadeScreenIn(1000);
                    CleanUpMess();
                }
            }
            else
            {
                DataStore.bOpenDoors = false;

                if (DataStore.bInYankton && iSelects != 23)
                    Yankton(false);
                else if (DataStore.bInCayoPerico && iSelects != 24)
                    CayoPerico(false);

                if (DataStore.bDontStopMe)
                    BacktoBase(DataStore.bPrisHeli);

                if (DataStore.bMethActor)
                    MethEdd(true);

                if (iSelects == 0)
                    RandomLocations(RsReturns.FindRandom(2, 1, 23));
                else
                    RandomLocations(iSelects);
            }
        }
        public static void RandomLocations(int iSelect)
        {
            LoggerLight.Loggers("RandomLocations, iSelect == " + iSelect);

            List<float> fHeading = new List<float>();
            List<Vector3> Pos_01 = new List<Vector3>();
            List<Vector3> Pos_02 = new List<Vector3>();

            int iSubSet = 0;
            int iAction = 0;
            int iEnterVeh = 0;
            int iWeapons = 0;
            bool bRequestPB = false;

            if (iSelect == 1)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                if (RsReturns.FindRandom(16, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(84.15928f, 870.0395f, 196.9632f)); fHeading.Add(198.6257f);
                    Pos_01.Add(new Vector3(1085.424f, -623.1199f, 55.74931f)); fHeading.Add(231.864f);
                    Pos_01.Add(new Vector3(1935.267f, 138.6639f, 161.0021f)); fHeading.Add(252.3587f);
                    Pos_01.Add(new Vector3(-1545.141f, 5333.643f, 0.374609f)); fHeading.Add(252.4405f);
                    Pos_01.Add(new Vector3(191.4103f, 4008.992f, 30.16784f)); fHeading.Add(247.7711f);
                    Pos_01.Add(new Vector3(735.3177f, 3875.103f, 30.30095f)); fHeading.Add(250.4637f);
                    Pos_01.Add(new Vector3(1301.419f, 4081.359f, 30.85315f)); fHeading.Add(250.8063f);
                    Pos_01.Add(new Vector3(1890.581f, 4207.984f, 29.69297f)); fHeading.Add(254.4965f);
                    Pos_01.Add(new Vector3(3942.418f, 4520.72f, 0.04050386f)); fHeading.Add(254.2912f);
                    Pos_01.Add(new Vector3(1275.859f, 6781.243f, 1.875325f)); fHeading.Add(255.149f);
                    Pos_01.Add(new Vector3(817.8608f, 6868.745f, 0.6500905f)); fHeading.Add(254.5598f);
                    Pos_01.Add(new Vector3(555.2587f, 6948.927f, 2.070866f)); fHeading.Add(235.7191f);
                    Pos_01.Add(new Vector3(380.6453f, 7111.351f, 1.341785f)); fHeading.Add(103.1293f);
                    Pos_01.Add(new Vector3(-75.04967f, 7162.032f, 0.7809207f)); fHeading.Add(106.3162f);
                    Pos_01.Add(new Vector3(-136.6161f, 6985.519f, 2.248812f)); fHeading.Add(109.5711f);
                    Pos_01.Add(new Vector3(-217.6722f, 6772.711f, 0.7187195f)); fHeading.Add(112.3855f);
                    Pos_01.Add(new Vector3(-432.1755f, 6602.485f, -0.9444882f)); fHeading.Add(113.2111f);
                    Pos_01.Add(new Vector3(-711.3498f, 6438.557f, 1.175478f)); fHeading.Add(114.2294f);
                    Pos_01.Add(new Vector3(-783.0923f, 6179.819f, 1.159182f)); fHeading.Add(113.195f);
                    Pos_01.Add(new Vector3(-855.4564f, 6329.2f, 1.649986f)); fHeading.Add(112.0618f);
                    Pos_01.Add(new Vector3(-1105.409f, 6230.149f, 1.402328f)); fHeading.Add(106.5892f);
                    Pos_01.Add(new Vector3(-1041.873f, 5980.121f, 1.402047f)); fHeading.Add(102.712f);
                    Pos_01.Add(new Vector3(-1089.262f, 5718.566f, 2.109917f)); fHeading.Add(99.14839f);
                    Pos_01.Add(new Vector3(-1259.799f, 5542.388f, 1.329061f)); fHeading.Add(101.9638f);
                    Pos_01.Add(new Vector3(-2010.965f, 4706.432f, 0.2131054f)); fHeading.Add(98.64931f);
                    Pos_01.Add(new Vector3(-2289.724f, 4718.518f, 1.205942f)); fHeading.Add(100.3706f);
                    Pos_01.Add(new Vector3(-2620.681f, 4375.571f, 2.598233f)); fHeading.Add(102.3983f);
                    Pos_01.Add(new Vector3(-2752.379f, 3823.479f, 2.192016f)); fHeading.Add(108.3891f);
                    Pos_01.Add(new Vector3(-3094.804f, 3660.478f, 0.3773279f)); fHeading.Add(108.2939f);
                    Pos_01.Add(new Vector3(-3285.914f, 3382.975f, -0.6846119f)); fHeading.Add(111.7754f);
                    Pos_01.Add(new Vector3(-3106.192f, 3070.644f, 0.5554894f)); fHeading.Add(102.6006f);
                    Pos_01.Add(new Vector3(-2875.93f, 2896.969f, 1.137105f)); fHeading.Add(103.0204f);
                    Pos_01.Add(new Vector3(-3370.646f, 1288.255f, 1.050613f)); fHeading.Add(104.7735f);
                    Pos_01.Add(new Vector3(-3457.67f, 1109.7f, -0.8914479f)); fHeading.Add(86.42601f);
                    Pos_01.Add(new Vector3(-3358.214f, 755.0081f, 0.5048277f)); fHeading.Add(89.27978f);
                    Pos_01.Add(new Vector3(-3270.875f, 507.7149f, 1.220188f)); fHeading.Add(97.51931f);
                    Pos_01.Add(new Vector3(-3299.841f, 145.6124f, 1.549924f)); fHeading.Add(98.60503f);
                    Pos_01.Add(new Vector3(-3109.922f, -176.991f, 0.5766438f)); fHeading.Add(98.75866f);
                    Pos_01.Add(new Vector3(-2576.633f, -557.041f, 0.371466f)); fHeading.Add(96.98157f);
                    Pos_01.Add(new Vector3(-2186.475f, -772.5471f, 2.227773f)); fHeading.Add(98.03549f);
                    Pos_01.Add(new Vector3(-1997.154f, -1051.069f, 0.6151424f)); fHeading.Add(99.92389f);
                    Pos_01.Add(new Vector3(-1693.719f, -1348.646f, -0.7338865f)); fHeading.Add(314.2184f);
                    Pos_01.Add(new Vector3(-1604.932f, -1523.64f, -0.2957365f)); fHeading.Add(317.7053f);
                    Pos_01.Add(new Vector3(-1508.621f, -1717.438f, 2.088923f)); fHeading.Add(314.3288f);
                    Pos_01.Add(new Vector3(-1412.39f, -1908.503f, 1.763029f)); fHeading.Add(340.169f);
                    Pos_01.Add(new Vector3(-1564.309f, -2060.263f, 0.694436f)); fHeading.Add(337.7032f);

                    iAction = 1;

                    iEnterVeh = RsReturns.RandInt(1, 3);
                }
                else
                {
                    Pos_01.Add(new Vector3(-1586.421f, -1162.615f, 2.148071f)); fHeading.Add(169.5818f);
                    Pos_01.Add(new Vector3(-1528.565f, -1229.046f, 2.304519f)); fHeading.Add(346.878f);
                    Pos_01.Add(new Vector3(-1516.088f, -1253.902f, 2.428257f)); fHeading.Add(328.3608f);
                    Pos_01.Add(new Vector3(-1521.939f, -1260.365f, 2.188367f)); fHeading.Add(270.5981f);
                    Pos_01.Add(new Vector3(-1497.356f, -1299.038f, 2.420877f)); fHeading.Add(357.6385f);
                    Pos_01.Add(new Vector3(-1493.324f, -1315.754f, 2.520744f)); fHeading.Add(347.6972f);
                    Pos_01.Add(new Vector3(-1484.929f, -1348.339f, 2.574805f)); fHeading.Add(312.4344f);
                    Pos_01.Add(new Vector3(-1479.488f, -1363.246f, 2.578f)); fHeading.Add(246.9683f);
                    Pos_01.Add(new Vector3(-1468.606f, -1384.8f, 2.509771f)); fHeading.Add(310.6684f);
                    Pos_01.Add(new Vector3(-1469.201f, -1408.029f, 2.463026f)); fHeading.Add(347.6103f);
                    Pos_01.Add(new Vector3(-1463.954f, -1428.468f, 2.187906f)); fHeading.Add(290.5826f);
                    Pos_01.Add(new Vector3(-1435.296f, -1441.728f, 2.632148f)); fHeading.Add(359.6833f);
                    Pos_01.Add(new Vector3(-1426.745f, -1460.802f, 2.664341f)); fHeading.Add(325.3264f);
                    Pos_01.Add(new Vector3(-1422.999f, -1475.75f, 2.639942f)); fHeading.Add(325.3264f);
                    Pos_01.Add(new Vector3(-1415.703f, -1489.203f, 2.558141f)); fHeading.Add(353.3201f);
                    Pos_01.Add(new Vector3(-1415.128f, -1498.685f, 2.59455f)); fHeading.Add(345.1029f);
                    Pos_01.Add(new Vector3(-1400.996f, -1517.704f, 2.703964f)); fHeading.Add(351.7414f);
                    Pos_01.Add(new Vector3(-1408.302f, -1525.03f, 2.562711f)); fHeading.Add(341.0873f);
                    Pos_01.Add(new Vector3(-1402.26f, -1536.069f, 2.581975f)); fHeading.Add(306.2956f);
                    Pos_01.Add(new Vector3(-1388.75f, -1542.711f, 2.721804f)); fHeading.Add(331.3119f);
                    Pos_01.Add(new Vector3(-1387.059f, -1556.354f, 2.630548f)); fHeading.Add(28.35612f);
                    Pos_01.Add(new Vector3(-1379.348f, -1565.413f, 2.68825f)); fHeading.Add(323.7297f);
                    Pos_01.Add(new Vector3(-1369.724f, -1578.161f, 2.725863f)); fHeading.Add(331.198f);
                    Pos_01.Add(new Vector3(-1375.492f, -1584.465f, 2.564658f)); fHeading.Add(273.914f);
                    Pos_01.Add(new Vector3(-1371.115f, -1595.559f, 2.581006f)); fHeading.Add(304.458f);
                    Pos_01.Add(new Vector3(-1363.927f, -1608.285f, 2.532254f)); fHeading.Add(299.6023f);
                    Pos_01.Add(new Vector3(-1364.569f, -1601.117f, 2.679783f)); fHeading.Add(294.5104f);
                    Pos_01.Add(new Vector3(-1346.654f, -1630.882f, 2.597588f)); fHeading.Add(354.3592f);
                    Pos_01.Add(new Vector3(-1346.722f, -1639.003f, 2.568485f)); fHeading.Add(324.4639f);
                    Pos_01.Add(new Vector3(-1339.9f, -1652.533f, 2.579392f)); fHeading.Add(303.4597f);
                    Pos_01.Add(new Vector3(-1330.892f, -1664.46f, 2.575971f)); fHeading.Add(283.3677f);
                    Pos_01.Add(new Vector3(-1322.36f, -1663.263f, 2.638669f)); fHeading.Add(322.4428f);
                    Pos_01.Add(new Vector3(-1315.824f, -1679.906f, 2.557489f)); fHeading.Add(305.1698f);
                    Pos_01.Add(new Vector3(-1301.206f, -1686.862f, 2.715342f)); fHeading.Add(313.1601f);
                    Pos_01.Add(new Vector3(-1307.643f, -1692.448f, 2.611342f)); fHeading.Add(334.6165f);
                    Pos_01.Add(new Vector3(-1277.857f, -1739.297f, 2.930711f)); fHeading.Add(308.0513f);
                    Pos_01.Add(new Vector3(-1274.078f, -1764.758f, 2.119832f)); fHeading.Add(331.0865f);
                    Pos_01.Add(new Vector3(-1264.89f, -1759.778f, 2.590501f)); fHeading.Add(314.4068f);
                    Pos_01.Add(new Vector3(-1252.271f, -1761.727f, 2.55158f)); fHeading.Add(253.1007f);
                    Pos_01.Add(new Vector3(-1253.291f, -1774.201f, 2.608327f)); fHeading.Add(289.2869f);
                    Pos_01.Add(new Vector3(-2965.339f, 2.691767f, 6.472663f)); fHeading.Add(41.93862f);
                    Pos_01.Add(new Vector3(-2960.771f, -9.283625f, 5.146744f)); fHeading.Add(238.9136f);
                    Pos_01.Add(new Vector3(-2931.057f, -7.421918f, 6.923255f)); fHeading.Add(52.41067f);

                    iAction = 2;
                }
            }                 //Beach Ped
            else if (iSelect == 2)
            {
                World.Weather = Weather.Raining;

                if (RsReturns.FindRandom(17, 1, 4) < 2)
                {
                    World.CurrentDayTime = TimeSpan.FromHours(12);

                    Pos_01.Add(new Vector3(203.1747f, -1323.28f, 29.49488f)); fHeading.Add(193.3338f);
                    Pos_01.Add(new Vector3(208.8623f, -1112.774f, 29.48404f)); fHeading.Add(24.76219f);
                    Pos_01.Add(new Vector3(-275.8094f, -1454.74f, 31.61106f)); fHeading.Add(253.4336f);
                    Pos_01.Add(new Vector3(-693.1378f, -1577.24f, 18.84266f)); fHeading.Add(353.1736f);
                    Pos_01.Add(new Vector3(-800.6707f, -2524.994f, 14.12026f)); fHeading.Add(169.2693f);
                    Pos_01.Add(new Vector3(-394.2787f, -1808.287f, 21.73676f)); fHeading.Add(62.14956f);
                    Pos_01.Add(new Vector3(-442.7756f, -1421.596f, 29.47493f)); fHeading.Add(296.8138f);
                    Pos_01.Add(new Vector3(-749.0342f, -1104.87f, 10.93612f)); fHeading.Add(343.8803f);
                    Pos_01.Add(new Vector3(-970.386f, -417.4318f, 38.12127f)); fHeading.Add(58.37359f);
                    Pos_01.Add(new Vector3(-268.4693f, -369.2575f, 30.27961f)); fHeading.Add(35.20417f);
                    Pos_01.Add(new Vector3(-229.4433f, -57.87684f, 49.78816f)); fHeading.Add(327.3621f);
                    Pos_01.Add(new Vector3(-201.4504f, 259.4538f, 92.27294f)); fHeading.Add(317.8449f);

                    iAction = 3;
                }           //HoldSign Tramp
                else
                {
                    World.CurrentDayTime = TimeSpan.FromHours(3);

                    Pos_01.Add(new Vector3(351.7925f, -1188.58f, 29.48054f)); fHeading.Add(1.868855f);
                    Pos_01.Add(new Vector3(138.2023f, -1218.859f, 29.74356f)); fHeading.Add(149.2099f);
                    Pos_01.Add(new Vector3(18.54766f, -1213.865f, 29.78357f)); fHeading.Add(277.7195f);
                    Pos_01.Add(new Vector3(345.3155f, -1093.126f, 29.72063f)); fHeading.Add(329.6081f);
                    Pos_01.Add(new Vector3(466.7483f, -864.7038f, 27.09684f)); fHeading.Add(98.30646f);
                    Pos_01.Add(new Vector3(262.903f, -1114.465f, 29.64995f)); fHeading.Add(29.92652f);
                    Pos_01.Add(new Vector3(843.3406f, -852.6771f, 26.6483f)); fHeading.Add(335.358f);
                    iAction = 4;
                }
                iWeapons = 1;
            }            //Tramps
            else if (iSelect == 3)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(18, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(-1354.29f, -140.058f, 49.57456f));
                    Pos_01.Add(new Vector3(-1026.242f, 315.9842f, 66.88311f));
                    Pos_01.Add(new Vector3(-1026.074f, 360.7628f, 71.36153f));
                    Pos_01.Add(new Vector3(-892.2721f, 352.8219f, 85.47115f));
                    Pos_01.Add(new Vector3(-875.8641f, 315.7621f, 84.15994f));
                    Pos_01.Add(new Vector3(-819.4623f, 268.2599f, 86.38909f));
                    Pos_01.Add(new Vector3(-948.934f, 320.3693f, 71.35191f));
                    Pos_01.Add(new Vector3(-1037.066f, 207.9634f, 64.56448f));
                    Pos_01.Add(new Vector3(-949.5158f, 196.6293f, 67.39026f));
                    Pos_01.Add(new Vector3(-916.7498f, 203.2301f, 69.43185f));
                    Pos_01.Add(new Vector3(-993.275f, 162.2733f, 62.14541f));
                    Pos_01.Add(new Vector3(-971.3362f, 122.028f, 57.04857f));
                    Pos_01.Add(new Vector3(-923.2835f, 124.1776f, 55.53205f));
                    Pos_01.Add(new Vector3(-934.5027f, 3.251942f, 47.74643f));
                    Pos_01.Add(new Vector3(-896.5391f, -4.971326f, 43.79887f));
                    Pos_01.Add(new Vector3(-1878.568f, 214.5692f, 84.43929f));
                    Pos_01.Add(new Vector3(-1892.024f, 235.6097f, 86.25183f));
                    Pos_01.Add(new Vector3(-1921.954f, 308.4248f, 89.07661f));
                    Pos_01.Add(new Vector3(-1930.378f, 369.2367f, 93.78211f));
                    Pos_01.Add(new Vector3(-1941.7f, 386.0603f, 96.50709f));
                    Pos_01.Add(new Vector3(-1943.1f, 449.7197f, 102.9281f));
                    Pos_01.Add(new Vector3(-1939.811f, 534.4824f, 114.8257f));
                    Pos_01.Add(new Vector3(-1929.164f, 595.4424f, 122.2849f));
                    Pos_01.Add(new Vector3(-1897.366f, 642.0092f, 130.2086f));
                    Pos_01.Add(new Vector3(-1967.342f, 649.6359f, 122.5363f));
                    Pos_01.Add(new Vector3(-2000.012f, 613.8847f, 117.9034f));
                    Pos_01.Add(new Vector3(-2024.877f, 478.917f, 107.1619f));
                    Pos_01.Add(new Vector3(-2022.839f, 455.3822f, 105.753f));
                    Pos_01.Add(new Vector3(-2011.445f, 350.2057f, 94.4791f));
                    Pos_01.Add(new Vector3(-2009.404f, 289.1414f, 91.97834f));
                    Pos_01.Add(new Vector3(-1970.168f, 246.2813f, 87.81215f));
                    Pos_01.Add(new Vector3(-1960.694f, 212.0906f, 86.81219f));
                    Pos_01.Add(new Vector3(-1931.561f, 162.9542f, 84.65261f));
                    Pos_01.Add(new Vector3(-1906.881f, 141.3684f, 81.64087f));
                    Pos_01.Add(new Vector3(-479.2487f, 218.3924f, 83.69603f));
                    Pos_01.Add(new Vector3(-569.7756f, 169.5958f, 66.56587f));
                    Pos_01.Add(new Vector3(-511.6719f, 108.9022f, 63.79959f));
                    Pos_01.Add(new Vector3(-392.7119f, 151.4118f, 65.52414f));
                    Pos_01.Add(new Vector3(-208.1687f, 159.859f, 74.05302f));
                    Pos_01.Add(new Vector3(-149.0777f, 121.9784f, 70.22536f));
                    Pos_01.Add(new Vector3(-329.4156f, 97.45921f, 67.05153f));
                    Pos_01.Add(new Vector3(-355.3001f, 94.91445f, 70.5202f));
                    Pos_01.Add(new Vector3(-355.2776f, 15.46274f, 47.85473f));
                    Pos_01.Add(new Vector3(-314.8544f, 83.60764f, 71.66293f));
                    Pos_01.Add(new Vector3(-282.1409f, 12.98766f, 54.75249f));
                    Pos_01.Add(new Vector3(-219.1817f, -3.427589f, 52.36488f));
                    Pos_01.Add(new Vector3(-161.3873f, -3.951782f, 62.46285f));
                    Pos_01.Add(new Vector3(-117.107f, -37.25715f, 62.19587f));
                    Pos_01.Add(new Vector3(-77.88377f, 7.237984f, 70.25868f));
                    Pos_01.Add(new Vector3(-0.08573192f, -15.04306f, 71.10311f));
                }
                else
                {
                    Pos_01.Add(new Vector3(-1673.788f, 397.77f, 88.52644f)); fHeading.Add(64.57473f);
                    Pos_01.Add(new Vector3(-1752.39f, 364.5465f, 89.1705f)); fHeading.Add(116.9318f);
                    Pos_01.Add(new Vector3(-1793.994f, 348.2893f, 88.0877f)); fHeading.Add(61.06843f);
                    Pos_01.Add(new Vector3(-1855.511f, 326.3394f, 88.22096f)); fHeading.Add(11.76969f);
                    Pos_01.Add(new Vector3(-1889.329f, 625.9503f, 129.5342f)); fHeading.Add(136.4553f);
                    Pos_01.Add(new Vector3(-1973.023f, 623.2357f, 121.8878f)); fHeading.Add(245.8481f);
                    Pos_01.Add(new Vector3(-1939.265f, 582.2429f, 118.715f)); fHeading.Add(70.56753f);
                    Pos_01.Add(new Vector3(-1988.716f, 606.395f, 117.4611f)); fHeading.Add(258.2865f);
                    Pos_01.Add(new Vector3(-1941.78f, 551.6149f, 114.3409f)); fHeading.Add(337.9585f);
                    Pos_01.Add(new Vector3(-2013.584f, 485.0325f, 106.6326f)); fHeading.Add(259.0422f);
                    Pos_01.Add(new Vector3(-2009.889f, 454.6579f, 102.1945f)); fHeading.Add(284.8948f);
                    Pos_01.Add(new Vector3(-1952.689f, 447.425f, 100.5408f)); fHeading.Add(7.571787f);
                    Pos_01.Add(new Vector3(-1944.265f, 385.2967f, 95.9594f)); fHeading.Add(99.1428f);
                    Pos_01.Add(new Vector3(-2001.322f, 367.8698f, 94.0161f)); fHeading.Add(0.2865385f);
                    Pos_01.Add(new Vector3(-1935.729f, 361.8442f, 93.28986f)); fHeading.Add(176.5911f);
                    Pos_01.Add(new Vector3(-1993.105f, 294.0038f, 91.29748f)); fHeading.Add(197.3417f);
                    Pos_01.Add(new Vector3(-1922.19f, 283.8107f, 88.60562f)); fHeading.Add(100.6357f);
                    Pos_01.Add(new Vector3(-1976.696f, 260.4303f, 86.75058f)); fHeading.Add(288.7364f);
                    Pos_01.Add(new Vector3(-1903.89f, 239.3635f, 85.78407f)); fHeading.Add(26.79044f);
                    Pos_01.Add(new Vector3(-1936.075f, 183.7075f, 84.14386f)); fHeading.Add(308.4178f);
                    Pos_01.Add(new Vector3(-1875.329f, 186.7319f, 83.62743f)); fHeading.Add(127.5535f);
                    Pos_01.Add(new Vector3(-1893.187f, 136.2495f, 80.99354f)); fHeading.Add(37.06417f);
                    Pos_01.Add(new Vector3(-812.4685f, 807.1378f, 201.7596f)); fHeading.Add(17.88073f);
                    Pos_01.Add(new Vector3(-851.6611f, 790.9014f, 191.4005f)); fHeading.Add(6.430694f);
                    Pos_01.Add(new Vector3(-904.0649f, 782.9053f, 185.7406f)); fHeading.Add(6.035343f);
                    Pos_01.Add(new Vector3(-918.5698f, 808.3696f, 183.9496f)); fHeading.Add(182.1112f);
                    Pos_01.Add(new Vector3(-955.7166f, 800.1675f, 177.5815f)); fHeading.Add(183.1433f);
                    Pos_01.Add(new Vector3(-1000.894f, 785.6645f, 171.2225f)); fHeading.Add(293.5203f);
                    Pos_01.Add(new Vector3(-967.0729f, 762.8038f, 175.0238f)); fHeading.Add(46.42586f);
                    Pos_01.Add(new Vector3(-993.1129f, 814.3392f, 172.0806f)); fHeading.Add(148.2752f);
                    Pos_01.Add(new Vector3(-1041.432f, 795.7566f, 166.8573f)); fHeading.Add(201.332f);
                    Pos_01.Add(new Vector3(-1122.904f, 789.71f, 162.8375f)); fHeading.Add(233.6811f);
                    Pos_01.Add(new Vector3(-1244.859f, 667.4886f, 142.3025f)); fHeading.Add(158.0466f);
                    Pos_01.Add(new Vector3(-1286.737f, 649.2265f, 139.3441f)); fHeading.Add(198.2304f);
                    Pos_01.Add(new Vector3(-1289.239f, 624.079f, 138.3185f)); fHeading.Add(44.98028f);
                    Pos_01.Add(new Vector3(-1344.312f, 610.5362f, 133.2736f)); fHeading.Add(99.64004f);
                    Pos_01.Add(new Vector3(-1363.18f, 604.6163f, 133.3924f)); fHeading.Add(276.5648f);
                    Pos_01.Add(new Vector3(-1357.854f, 578.6238f, 130.9159f)); fHeading.Add(251.9284f);
                    Pos_01.Add(new Vector3(-1409.383f, 538.3973f, 122.3506f)); fHeading.Add(97.42818f);
                    Pos_01.Add(new Vector3(-1113.874f, 488.9058f, 81.69276f)); fHeading.Add(165.7216f);
                    Pos_01.Add(new Vector3(-1076.687f, 464.8525f, 77.17262f)); fHeading.Add(143.5085f);
                    Pos_01.Add(new Vector3(-1066.766f, 436.7162f, 73.34963f)); fHeading.Add(99.94284f);
                    Pos_01.Add(new Vector3(-1094.942f, 439.0531f, 74.79195f)); fHeading.Add(263.1792f);
                    Pos_01.Add(new Vector3(-1178.86f, 455.4537f, 86.16233f)); fHeading.Add(83.36571f);
                    Pos_01.Add(new Vector3(-1271.644f, 453.4395f, 94.54791f)); fHeading.Add(35.05694f);
                    Pos_01.Add(new Vector3(-1321.65f, 450.8088f, 99.1374f)); fHeading.Add(3.468128f);
                    Pos_01.Add(new Vector3(-1375.281f, 452.6062f, 104.4827f)); fHeading.Add(81.6608f);
                    Pos_01.Add(new Vector3(-1416.329f, 468.6403f, 108.4619f)); fHeading.Add(337.1019f);
                    Pos_01.Add(new Vector3(-1453.313f, 533.9914f, 118.43f)); fHeading.Add(256.1559f);
                    Pos_01.Add(new Vector3(-1470.98f, 512.717f, 116.9694f)); fHeading.Add(10.18582f);
                    Pos_01.Add(new Vector3(-1488.908f, 526.7175f, 117.4594f)); fHeading.Add(210.5038f);
                    Pos_01.Add(new Vector3(-1495.854f, 417.2953f, 110.295f)); fHeading.Add(45.96989f);
                    Pos_01.Add(new Vector3(-1540.106f, 427.4037f, 108.6132f)); fHeading.Add(272.4252f);
                    Pos_01.Add(new Vector3(-1590.182f, -59.71728f, 55.66955f)); fHeading.Add(269.1685f);
                    Pos_01.Add(new Vector3(-1585.631f, -86.23008f, 53.52139f)); fHeading.Add(267.4581f);
                    Pos_01.Add(new Vector3(-1461.92f, -31.88625f, 53.85183f)); fHeading.Add(40.65616f);
                    Pos_01.Add(new Vector3(-1615.562f, 17.31669f, 61.36497f)); fHeading.Add(331.047f);
                    Pos_01.Add(new Vector3(-1568.184f, 32.2366f, 58.26441f)); fHeading.Add(256.8505f);
                    Pos_01.Add(new Vector3(-1514.182f, 30.78186f, 55.27171f)); fHeading.Add(85.92268f);
                    Pos_01.Add(new Vector3(-1466.721f, 40.39627f, 53.11018f)); fHeading.Add(82.29241f);
                    Pos_01.Add(new Vector3(-1544.478f, 126.1857f, 55.96695f)); fHeading.Add(228.9657f);
                    Pos_01.Add(new Vector3(-907.0533f, 198.3592f, 69.12683f)); fHeading.Add(179.1594f);
                    Pos_01.Add(new Vector3(-936.0016f, 202.6086f, 67.08392f)); fHeading.Add(160.901f);
                    Pos_01.Add(new Vector3(-919.8449f, 108.8946f, 54.94579f)); fHeading.Add(79.66322f);
                    Pos_01.Add(new Vector3(-969.3384f, 103.1074f, 55.28952f)); fHeading.Add(305.5659f);
                    Pos_01.Add(new Vector3(-993.2735f, 144.3372f, 60.29063f)); fHeading.Add(290.562f);
                    Pos_01.Add(new Vector3(-1045.353f, 221.3312f, 63.38915f)); fHeading.Add(180.1422f);
                    Pos_01.Add(new Vector3(-928.8628f, 15.22822f, 47.38865f)); fHeading.Add(303.1562f);
                    Pos_01.Add(new Vector3(-891.0569f, -2.692925f, 43.06151f)); fHeading.Add(22.0157f);
                    Pos_01.Add(new Vector3(-879.8286f, -48.6999f, 37.6939f)); fHeading.Add(296.6208f);
                    Pos_01.Add(new Vector3(-834.5724f, 114.6378f, 54.93201f)); fHeading.Add(179.2774f);
                    Pos_01.Add(new Vector3(-825.395f, 271.9576f, 85.87788f)); fHeading.Add(349.0413f);
                    Pos_01.Add(new Vector3(-869.8893f, 306.2518f, 83.59718f)); fHeading.Add(152.2446f);
                    Pos_01.Add(new Vector3(-886.8126f, 364.8971f, 84.65531f)); fHeading.Add(1.787196f);
                    Pos_01.Add(new Vector3(-988.6418f, 418.2971f, 74.79593f)); fHeading.Add(200.8819f);
                    Pos_01.Add(new Vector3(-1017.659f, 357.3861f, 70.25055f)); fHeading.Add(335.9849f);
                    Pos_01.Add(new Vector3(-1042.106f, 319.8116f, 66.43107f)); fHeading.Add(301.8415f);
                    Pos_01.Add(new Vector3(-1186.364f, 286.2853f, 69.12206f)); fHeading.Add(216.3983f);
                    Pos_01.Add(new Vector3(-1132.066f, 381.8291f, 70.36998f)); fHeading.Add(238.2283f);
                    Pos_01.Add(new Vector3(-613.5519f, 677.818f, 149.0847f)); fHeading.Add(348.3205f);
                    Pos_01.Add(new Vector3(-559.5214f, 686.1437f, 144.7881f)); fHeading.Add(166.524f);
                    Pos_01.Add(new Vector3(-497.7785f, 745.8389f, 162.2046f)); fHeading.Add(242.2073f);
                    Pos_01.Add(new Vector3(-550.3578f, 831.1689f, 197.1528f)); fHeading.Add(339.137f);
                    Pos_01.Add(new Vector3(-608.5907f, 866.8416f, 212.8696f)); fHeading.Add(334.8934f);
                    Pos_01.Add(new Vector3(-661.0247f, 807.5721f, 198.7235f)); fHeading.Add(356.241f);
                    Pos_01.Add(new Vector3(-595.6389f, 806.8098f, 190.2512f)); fHeading.Add(149.1931f);
                    Pos_01.Add(new Vector3(-668.1514f, 752.6746f, 173.6188f)); fHeading.Add(0.7620906f);
                    Pos_01.Add(new Vector3(-668.8094f, 671.1213f, 149.9287f)); fHeading.Add(77.25645f);
                    Pos_01.Add(new Vector3(-710.4108f, 643.9869f, 154.6131f)); fHeading.Add(346.2415f);
                    Pos_01.Add(new Vector3(-808.8945f, 703.7688f, 146.5478f)); fHeading.Add(13.30845f);
                    Pos_01.Add(new Vector3(-862.9958f, 699.7191f, 148.4727f)); fHeading.Add(321.5082f);
                    Pos_01.Add(new Vector3(-951.4864f, 688.2122f, 153.0159f)); fHeading.Add(2.046261f);
                    Pos_01.Add(new Vector3(-1056.415f, 735.5481f, 164.8874f)); fHeading.Add(4.719154f);
                    Pos_01.Add(new Vector3(-1052.971f, 767.2552f, 167.0593f)); fHeading.Add(271.2393f);
                    Pos_01.Add(new Vector3(-1270.056f, 497.2365f, 96.60461f)); fHeading.Add(177.539f);
                    Pos_01.Add(new Vector3(-1237.144f, 487.832f, 92.70634f)); fHeading.Add(132.8591f);
                    Pos_01.Add(new Vector3(-1098.73f, 555.0469f, 102.1592f)); fHeading.Add(92.74675f);
                    Pos_01.Add(new Vector3(-1094.86f, 596.7789f, 102.5024f)); fHeading.Add(214.0652f);
                    Pos_01.Add(new Vector3(-941.9733f, 593.2686f, 100.6847f)); fHeading.Add(158.6948f);
                    Pos_01.Add(new Vector3(-952.6204f, 572.2911f, 101.0466f)); fHeading.Add(338.245f);
                    Pos_01.Add(new Vector3(-911.8775f, 587.877f, 100.6279f)); fHeading.Add(149.6929f);
                    Pos_01.Add(new Vector3(-908.5421f, 553.5905f, 95.87045f)); fHeading.Add(316.3625f);
                    Pos_01.Add(new Vector3(-845.8243f, 520.2244f, 90.02374f)); fHeading.Add(100.3152f);
                    Pos_01.Add(new Vector3(-845.8357f, 461.0065f, 87.09276f)); fHeading.Add(93.49643f);
                    Pos_01.Add(new Vector3(-964.0833f, 435.5407f, 79.3726f)); fHeading.Add(333.6538f);
                    Pos_01.Add(new Vector3(-976.3936f, 523.895f, 80.87231f)); fHeading.Add(146.8071f);
                    Pos_01.Add(new Vector3(-993.5677f, 489.7014f, 81.66727f)); fHeading.Add(11.83891f);
                    Pos_01.Add(new Vector3(-1011.735f, 489.8139f, 78.71857f)); fHeading.Add(2.953075f);
                    Pos_01.Add(new Vector3(-1045.763f, 500.1797f, 83.51974f)); fHeading.Add(215.8596f);
                    Pos_01.Add(new Vector3(-808.8355f, 425.0128f, 90.97233f)); fHeading.Add(349.3546f);
                    Pos_01.Add(new Vector3(-765.5538f, 465.7845f, 99.92818f)); fHeading.Add(213.3331f);
                    Pos_01.Add(new Vector3(-738.7115f, 443.4265f, 106.2674f)); fHeading.Add(26.59777f);
                    Pos_01.Add(new Vector3(-713.8804f, 495.2518f, 108.6712f)); fHeading.Add(206.0219f);
                    Pos_01.Add(new Vector3(-687.8669f, 502.1955f, 109.5336f)); fHeading.Add(198.9874f);
                    Pos_01.Add(new Vector3(-633.8344f, 527.5926f, 109.1043f)); fHeading.Add(190.9024f);
                    Pos_01.Add(new Vector3(-586.6672f, 528.7498f, 107.2383f)); fHeading.Add(218.2536f);
                    Pos_01.Add(new Vector3(-202.556f, 409.7411f, 109.9087f)); fHeading.Add(14.79766f);
                    Pos_01.Add(new Vector3(-304.7013f, 380.7583f, 109.7528f)); fHeading.Add(12.67552f);
                    Pos_01.Add(new Vector3(-381.2098f, 347.0158f, 108.5992f)); fHeading.Add(7.480639f);
                    Pos_01.Add(new Vector3(-404.1221f, 338.9637f, 108.1354f)); fHeading.Add(359.4413f);
                    Pos_01.Add(new Vector3(-473.5081f, 353.0821f, 103.3904f)); fHeading.Add(331.7446f);
                    Pos_01.Add(new Vector3(-449.2093f, 372.955f, 104.1925f)); fHeading.Add(88.32726f);
                    Pos_01.Add(new Vector3(-499.3677f, 428.2659f, 96.70379f)); fHeading.Add(133.329f);
                    Pos_01.Add(new Vector3(-515.5759f, 390.2937f, 93.14224f)); fHeading.Add(58.85709f);
                    Pos_01.Add(new Vector3(-603.5704f, 398.1809f, 101.1029f)); fHeading.Add(6.096045f);
                    Pos_01.Add(new Vector3(-574.8644f, 400.437f, 100.0821f)); fHeading.Add(21.19732f);
                    Pos_01.Add(new Vector3(-540.9546f, 481.944f, 102.4014f)); fHeading.Add(16.34741f);
                    Pos_01.Add(new Vector3(-527.3146f, 527.659f, 111.4062f)); fHeading.Add(44.40198f);
                    Pos_01.Add(new Vector3(-519.2817f, 574.8528f, 120.3787f)); fHeading.Add(280.6111f);
                    Pos_01.Add(new Vector3(-477.9099f, 597.2338f, 127.0411f)); fHeading.Add(91.77653f);
                    Pos_01.Add(new Vector3(-143.1443f, 596.1634f, 203.2704f)); fHeading.Add(3.014483f);
                    Pos_01.Add(new Vector3(-178.2738f, 585.178f, 197.0455f)); fHeading.Add(358.6667f);
                    Pos_01.Add(new Vector3(-226.1506f, 592.6992f, 189.5592f)); fHeading.Add(345.975f);
                    Pos_01.Add(new Vector3(-273.8918f, 600.2565f, 181.155f)); fHeading.Add(353.2928f);
                    Pos_01.Add(new Vector3(-464.1287f, 643.3572f, 143.6065f)); fHeading.Add(47.37784f);
                    Pos_01.Add(new Vector3(-395.2807f, 672.032f, 162.382f)); fHeading.Add(3.729914f);
                    Pos_01.Add(new Vector3(-343.1208f, 634.0641f, 171.7307f)); fHeading.Add(53.57518f);
                    Pos_01.Add(new Vector3(-345.2143f, 663.2159f, 168.9018f)); fHeading.Add(170.6592f);
                    Pos_01.Add(new Vector3(-302.5376f, 632.3251f, 175.0428f)); fHeading.Add(113.3986f);
                    Pos_01.Add(new Vector3(319.1369f, 495.9725f, 152.2041f)); fHeading.Add(284.5606f);
                    Pos_01.Add(new Vector3(229.6781f, 679.8453f, 189.1597f)); fHeading.Add(101.8786f);
                    Pos_01.Add(new Vector3(174.1774f, 471.3581f, 141.4379f)); fHeading.Add(351.6725f);
                    Pos_01.Add(new Vector3(108.1012f, 498.9342f, 146.6786f)); fHeading.Add(195.3518f);
                    Pos_01.Add(new Vector3(89.71058f, 488.3624f, 147.3414f)); fHeading.Add(206.6835f);
                    Pos_01.Add(new Vector3(-78.29935f, 496.4704f, 143.9985f)); fHeading.Add(339.5458f);
                    Pos_01.Add(new Vector3(-353.9483f, 474.0529f, 112.1987f)); fHeading.Add(288.0629f);
                    Pos_01.Add(new Vector3(-360.3586f, 514.3036f, 119.1824f)); fHeading.Add(139.8392f);
                    Pos_01.Add(new Vector3(-401.7088f, 511.3387f, 119.6189f)); fHeading.Add(333.415f);
                    Pos_01.Add(new Vector3(-407.652f, 561.3188f, 123.8938f)); fHeading.Add(153.9519f);
                    Pos_01.Add(new Vector3(1410.476f, 1118.693f, 114.1653f)); fHeading.Add(90.09675f);
                    Pos_01.Add(new Vector3(-1891.32f, 2045.54f, 140.1863f)); fHeading.Add(250.2802f);
                    Pos_01.Add(new Vector3(-2785.476f, 1433.886f, 100.2547f)); fHeading.Add(234.261f);
                    Pos_01.Add(new Vector3(-2995.756f, 721.6164f, 27.824f)); fHeading.Add(112.4172f);
                    Pos_01.Add(new Vector3(-2980.652f, 612.3025f, 19.50303f)); fHeading.Add(104.2501f);

                    iAction = 1;

                    iEnterVeh = RsReturns.RandInt(1, 2);
                }

                iWeapons = 2;
            }            //High class
            else if (iSelect == 4)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(19, 1, 4) < 2)
                {

                    Pos_01.Add(new Vector3(-356.741f, 16.12581f, 47.85474f));
                    Pos_01.Add(new Vector3(-362.0493f, 57.46016f, 54.4298f));
                    Pos_01.Add(new Vector3(-411.5159f, 152.6001f, 81.74309f));
                    Pos_01.Add(new Vector3(-384.4481f, 153.008f, 81.74698f));
                    Pos_01.Add(new Vector3(-303.3091f, 84.56718f, 76.66209f));
                    Pos_01.Add(new Vector3(-313.5391f, 83.60252f, 75.65311f));
                    Pos_01.Add(new Vector3(-332.7193f, 88.68687f, 71.21808f));
                    Pos_01.Add(new Vector3(-263.5449f, 98.93026f, 77.56315f));
                    Pos_01.Add(new Vector3(-188.5497f, 184.8336f, 88.60064f));
                    Pos_01.Add(new Vector3(-154.3215f, 214.6461f, 98.32927f));
                    Pos_01.Add(new Vector3(-143.7316f, 174.7767f, 93.62655f));
                    Pos_01.Add(new Vector3(-161.3621f, 161.0014f, 89.70206f));
                    Pos_01.Add(new Vector3(-206.0126f, -7.720617f, 60.62708f));
                    Pos_01.Add(new Vector3(-161.1083f, -4.599355f, 66.46642f));
                    Pos_01.Add(new Vector3(-102.2039f, -31.8603f, 70.44765f));
                    Pos_01.Add(new Vector3(-18.69028f, -68.38952f, 61.37531f));
                    Pos_01.Add(new Vector3(-27.58074f, -61.06355f, 67.59225f));
                    Pos_01.Add(new Vector3(-21.88984f, -23.86292f, 73.24532f));
                    Pos_01.Add(new Vector3(-14.02445f, -11.82469f, 79.34619f));
                    Pos_01.Add(new Vector3(20.95977f, 114.1915f, 87.27728f));
                    Pos_01.Add(new Vector3(107.7924f, 54.56335f, 81.77329f));
                    Pos_01.Add(new Vector3(189.1337f, 11.49182f, 81.41087f));
                    Pos_01.Add(new Vector3(212.0644f, 1.590603f, 79.19212f));
                    Pos_01.Add(new Vector3(188.576f, 40.0778f, 87.82249f));
                    Pos_01.Add(new Vector3(208.1531f, 73.78002f, 96.09595f));
                    Pos_01.Add(new Vector3(284.9831f, 47.12731f, 96.6929f));
                    Pos_01.Add(new Vector3(254.5233f, 25.36229f, 92.12718f));
                    Pos_01.Add(new Vector3(388.1746f, 2.197361f, 91.41467f));
                    Pos_01.Add(new Vector3(485.1955f, 212.3895f, 108.3095f));
                    Pos_01.Add(new Vector3(-1177.005f, -1073.163f, 5.906403f));
                    Pos_01.Add(new Vector3(-1183.198f, -1064.417f, 2.150418f));
                    Pos_01.Add(new Vector3(-1191.016f, -1054.863f, 2.150433f));
                    Pos_01.Add(new Vector3(-1188.258f, -1041.719f, 2.150275f));
                    Pos_01.Add(new Vector3(-1201.109f, -1031.956f, 2.150406f));
                    Pos_01.Add(new Vector3(-1204.234f, -1021.773f, 5.945113f));
                    Pos_01.Add(new Vector3(-1338.218f, -941.2662f, 15.35802f));
                    Pos_01.Add(new Vector3(-1353.765f, -908.0026f, 12.4705f));
                    Pos_01.Add(new Vector3(-1335.845f, -1146.224f, 6.731401f));
                    Pos_01.Add(new Vector3(-1252.488f, -1143.985f, 8.513974f));
                    Pos_01.Add(new Vector3(-1172.675f, -1260.892f, 14.90674f));
                    Pos_01.Add(new Vector3(-1229.549f, -1235.521f, 11.02771f));
                    Pos_01.Add(new Vector3(-1306.429f, -1229.076f, 8.980485f));
                    Pos_01.Add(new Vector3(-1317.88f, -1238.943f, 7.168704f));
                    Pos_01.Add(new Vector3(-1272.146f, -1295.553f, 8.285895f));
                    Pos_01.Add(new Vector3(-1246.816f, -1358.752f, 7.820462f));
                    Pos_01.Add(new Vector3(-1145.777f, -1466.309f, 7.690706f));
                    Pos_01.Add(new Vector3(-1156.229f, -1574.861f, 8.345174f));
                    Pos_01.Add(new Vector3(-1098.117f, -1673.513f, 8.39401f));
                    Pos_01.Add(new Vector3(-1059.984f, -1657.836f, 4.674311f));
                    Pos_01.Add(new Vector3(-1070.926f, -1636.006f, 8.194701f));
                    Pos_01.Add(new Vector3(-1076.572f, -1620.789f, 4.442664f));
                    Pos_01.Add(new Vector3(-1078.258f, -1616.337f, 4.428094f));
                    Pos_01.Add(new Vector3(-1093.088f, -1607.943f, 8.458809f));
                    Pos_01.Add(new Vector3(-1112.636f, -1577.709f, 8.679523f));
                    Pos_01.Add(new Vector3(-1148.522f, -1523.617f, 10.62805f));
                    Pos_01.Add(new Vector3(-1116.498f, -1506.122f, 4.403326f));
                    Pos_01.Add(new Vector3(-1110.924f, -1498.482f, 4.672343f));
                    Pos_01.Add(new Vector3(-1102.588f, -1492.073f, 4.887649f));
                    Pos_01.Add(new Vector3(-1108.559f, -1527.218f, 6.779534f));
                    Pos_01.Add(new Vector3(-1091.374f, -1517.666f, 4.792679f));
                    Pos_01.Add(new Vector3(-1086.088f, -1503.486f, 5.707945f));
                    Pos_01.Add(new Vector3(-1085.366f, -1558.724f, 4.489116f));
                    Pos_01.Add(new Vector3(-1077.584f, -1553.464f, 4.625066f));
                    Pos_01.Add(new Vector3(-1066.284f, -1545.243f, 4.902433f));
                    Pos_01.Add(new Vector3(-1057.291f, -1551.201f, 4.911008f));
                    Pos_01.Add(new Vector3(-1043.943f, -1579.937f, 5.03639f));
                    Pos_01.Add(new Vector3(-1048.449f, -1579.996f, 4.944197f));
                    Pos_01.Add(new Vector3(-1056.9f, -1587.358f, 4.613483f));
                    Pos_01.Add(new Vector3(-1038.341f, -1609.897f, 5.003761f));
                    Pos_01.Add(new Vector3(-956.5812f, -1432.736f, 7.679167f));
                    Pos_01.Add(new Vector3(-868.7635f, -1286.318f, 13.20004f));
                    Pos_01.Add(new Vector3(-936.1241f, -1310.397f, 9.70009f));
                    Pos_01.Add(new Vector3(-869.3542f, -1103.725f, 6.445571f));
                    Pos_01.Add(new Vector3(-903.3987f, -1005.532f, 2.150328f));
                    Pos_01.Add(new Vector3(-913.8767f, -989.0179f, 2.150327f));
                    Pos_01.Add(new Vector3(-908.3992f, -976.228f, 2.150325f));
                    Pos_01.Add(new Vector3(-942.7357f, -969.0355f, 2.150114f));
                    Pos_01.Add(new Vector3(-934.5264f, -939.1158f, 2.145313f));
                    Pos_01.Add(new Vector3(-947.3409f, -927.6057f, 2.145313f));
                    Pos_01.Add(new Vector3(-975.7267f, -909.0048f, 2.159486f));
                    Pos_01.Add(new Vector3(-1022.753f, -896.6989f, 5.41547f));
                    Pos_01.Add(new Vector3(-1023.957f, -912.3516f, 6.961076f));
                    Pos_01.Add(new Vector3(-1042.891f, -924.6329f, 3.154166f));
                    Pos_01.Add(new Vector3(-1053.634f, -929.9891f, 7.554896f));
                    Pos_01.Add(new Vector3(-1061.149f, -943.5154f, 2.182675f));
                    Pos_01.Add(new Vector3(-1091.015f, -925.9146f, 3.146876f));
                    Pos_01.Add(new Vector3(-1161.481f, -973.403f, 2.150194f));
                    Pos_01.Add(new Vector3(-1181.619f, -988.9208f, 2.150193f));
                    Pos_01.Add(new Vector3(-1204.326f, -943.4292f, 8.114918f));
                    Pos_01.Add(new Vector3(-1151.095f, -913.4648f, 6.628778f));
                    Pos_01.Add(new Vector3(-1042.812f, -1024.366f, 2.150358f));
                    Pos_01.Add(new Vector3(-1008.249f, -1036.944f, 2.150358f));
                    Pos_01.Add(new Vector3(-1000.026f, -1030.441f, 2.150311f));
                    Pos_01.Add(new Vector3(-997.8235f, -1012.419f, 2.150311f));
                    Pos_01.Add(new Vector3(-967.3852f, -1008.264f, 2.15031f));
                    Pos_01.Add(new Vector3(-978.1533f, -990.1673f, 4.545312f));
                    Pos_01.Add(new Vector3(-995.0858f, -966.8881f, 2.54532f));
                    Pos_01.Add(new Vector3(-1018.765f, -963.067f, 2.150194f));
                    Pos_01.Add(new Vector3(-1027.697f, -968.8497f, 2.1502f));
                    Pos_01.Add(new Vector3(-1035.725f, -984.0291f, 2.150194f));
                    Pos_01.Add(new Vector3(-1055.298f, -998.6008f, 6.410484f));
                    Pos_01.Add(new Vector3(-1130.638f, -1031.046f, 2.150357f));
                    Pos_01.Add(new Vector3(-1122.727f, -1027.076f, 2.150356f));
                    Pos_01.Add(new Vector3(-1113.141f, -1018.701f, 2.150358f));
                    Pos_01.Add(new Vector3(-1103.691f, -1013.49f, 2.150357f));
                    Pos_01.Add(new Vector3(-1101.415f, -1082.764f, 2.150356f));
                    Pos_01.Add(new Vector3(-1128.448f, -1080.953f, 4.222689f));
                    Pos_01.Add(new Vector3(-1064.395f, -1057.067f, 6.411655f));
                    Pos_01.Add(new Vector3(-1075.633f, -1026.472f, 4.545251f));
                    Pos_01.Add(new Vector3(-921.0966f, -1095.091f, 2.15031f));
                    Pos_01.Add(new Vector3(-946.3143f, -1050.763f, 2.171845f));
                    Pos_01.Add(new Vector3(-951.3636f, -1079.171f, 2.15031f));
                    Pos_01.Add(new Vector3(-960.2056f, -1109.441f, 2.150381f));
                    Pos_01.Add(new Vector3(-982.7823f, -1066.106f, 2.150313f));
                    Pos_01.Add(new Vector3(-982.4726f, -1083.512f, 2.545213f));
                    Pos_01.Add(new Vector3(-970.9428f, -1120.898f, 2.171845f));
                    Pos_01.Add(new Vector3(-991.4828f, -1103.666f, 2.150312f));
                    Pos_01.Add(new Vector3(-986.8842f, -1122.311f, 4.545273f));
                    Pos_01.Add(new Vector3(-1031.39f, -1109.176f, 2.1586f));
                    Pos_01.Add(new Vector3(-1004.998f, -1154.655f, 2.158741f));
                    Pos_01.Add(new Vector3(-1022.293f, -1160.524f, 2.1586f));
                    Pos_01.Add(new Vector3(-1031.984f, -1173.81f, 2.158597f));
                    Pos_01.Add(new Vector3(-1063.752f, -1132.606f, 2.158602f));
                    Pos_01.Add(new Vector3(-1091.859f, -1145.276f, 2.158598f));
                    Pos_01.Add(new Vector3(-1064.242f, -1159.144f, 2.159603f));
                    Pos_01.Add(new Vector3(-1068.306f, -1163.143f, 2.745344f));
                    Pos_01.Add(new Vector3(-1099.331f, -1210.65f, 2.538017f));
                    Pos_01.Add(new Vector3(-1094.835f, -1218.866f, 2.674695f));
                    Pos_01.Add(new Vector3(-1087.718f, -1230.778f, 2.91478f));
                    Pos_01.Add(new Vector3(-1126.017f, -1172.03f, 2.357591f));
                    Pos_01.Add(new Vector3(-1128.641f, -1162.314f, 6.494957f));
                    Pos_01.Add(new Vector3(-1128.47f, -1143.433f, 2.840051f));
                    Pos_01.Add(new Vector3(-1145.392f, -1127.529f, 6.503163f));
                    Pos_01.Add(new Vector3(-1142.907f, -1122.372f, 2.643049f));
                    Pos_01.Add(new Vector3(-1159.114f, -1100.559f, 6.531281f));
                    Pos_01.Add(new Vector3(-1469.499f, 23.98446f, 53.64318f));
                    Pos_01.Add(new Vector3(-1509.753f, 6.369807f, 56.06623f));
                    Pos_01.Add(new Vector3(-1579.321f, 12.67341f, 61.08215f));
                    Pos_01.Add(new Vector3(-1625.327f, 8.889999f, 62.53669f));
                    Pos_01.Add(new Vector3(-1599.91f, -33.59167f, 58.19274f));
                    Pos_01.Add(new Vector3(-1544.099f, -98.91996f, 54.52899f));
                    Pos_01.Add(new Vector3(-1481.332f, -41.2363f, 56.84435f));

                    Pos_01.Add(new Vector3(-3225.671f, 911.6782f, 13.99328f));
                    Pos_01.Add(new Vector3(-3238.209f, 922.1356f, 13.95989f));
                    Pos_01.Add(new Vector3(-3242.884f, 931.8699f, 17.22135f));
                    Pos_01.Add(new Vector3(-3237.128f, 952.9849f, 13.14549f));
                    Pos_01.Add(new Vector3(-3251.259f, 1027.374f, 11.75769f));
                    Pos_01.Add(new Vector3(-3254.493f, 1063.829f, 11.1462f));
                    Pos_01.Add(new Vector3(-3252.789f, 1077.478f, 11.03329f));
                    Pos_01.Add(new Vector3(-3228.171f, 1092.434f, 10.75639f));
                    Pos_01.Add(new Vector3(-3233.788f, 1110.743f, 10.57354f));
                    Pos_01.Add(new Vector3(-3220.034f, 1137.555f, 9.895407f));
                    Pos_01.Add(new Vector3(-3214.605f, 1149.277f, 9.895408f));
                    Pos_01.Add(new Vector3(-3205.43f, 1151.904f, 9.662267f));
                    Pos_01.Add(new Vector3(-3199.772f, 1165.077f, 9.654344f));
                    Pos_01.Add(new Vector3(-3205.8f, 1186.661f, 9.664678f));
                    Pos_01.Add(new Vector3(-3203.429f, 1206.695f, 12.82314f));
                    Pos_01.Add(new Vector3(-3193.675f, 1230.114f, 10.04832f));
                    Pos_01.Add(new Vector3(-3197.585f, 1274.163f, 12.66765f));
                    Pos_01.Add(new Vector3(-3181.797f, 1310.762f, 14.55494f));
                    Pos_01.Add(new Vector3(-3109.391f, 751.4032f, 24.70188f));
                    Pos_01.Add(new Vector3(-3106.902f, 719.2998f, 20.61939f));
                    Pos_01.Add(new Vector3(-3087.058f, 656.056f, 11.5886f));
                    Pos_01.Add(new Vector3(-3051.573f, 569.4459f, 7.823583f));
                    Pos_01.Add(new Vector3(-3044.509f, 564.0283f, 7.818895f));
                    Pos_01.Add(new Vector3(-3036.565f, 558.9866f, 7.507683f));
                    Pos_01.Add(new Vector3(-3036.482f, 544.608f, 7.507683f));
                    Pos_01.Add(new Vector3(-3041.9f, 523.9325f, 7.426294f));
                    Pos_01.Add(new Vector3(-3038.055f, 492.2998f, 6.767862f));
                    Pos_01.Add(new Vector3(-3053.02f, 487.0674f, 6.779647f));
                    Pos_01.Add(new Vector3(-3049.986f, 474.4078f, 6.779647f));
                    Pos_01.Add(new Vector3(-3069.546f, 454.4254f, 9.643095f));
                    Pos_01.Add(new Vector3(-3073.3f, 452.9189f, 6.357774f));
                    Pos_01.Add(new Vector3(-3080.653f, 406.0587f, 6.968522f));
                    Pos_01.Add(new Vector3(-3090.885f, 379.1903f, 7.112432f));
                    Pos_01.Add(new Vector3(-3102.068f, 367.1784f, 7.119124f));
                    Pos_01.Add(new Vector3(-3100.813f, 361.2336f, 7.59102f));
                    Pos_01.Add(new Vector3(-3110.472f, 335.3844f, 7.493347f));
                    Pos_01.Add(new Vector3(-3111.59f, 315.6106f, 8.38104f));
                    Pos_01.Add(new Vector3(-3115.084f, 303.729f, 8.38104f));
                    Pos_01.Add(new Vector3(-3115.483f, 294.5401f, 8.972106f));
                    Pos_01.Add(new Vector3(-3131.787f, 247.3237f, 12.492f));
                    Pos_01.Add(new Vector3(-3099.842f, 211.6886f, 14.0702f));
                    Pos_01.Add(new Vector3(-2973.217f, 600.1259f, 24.24677f));
                    Pos_01.Add(new Vector3(-2973.584f, 642.0483f, 25.79752f));
                    Pos_01.Add(new Vector3(-2995.112f, 682.2404f, 25.04422f));
                    Pos_01.Add(new Vector3(-2986.079f, 719.8495f, 28.49687f));
                    Pos_01.Add(new Vector3(-3018.052f, 746.3233f, 27.58763f));
                    Pos_01.Add(new Vector3(-1754.303f, -708.6591f, 10.39663f));
                    Pos_01.Add(new Vector3(-1764.108f, -708.2756f, 10.6142f));
                    Pos_01.Add(new Vector3(-1764.566f, -708.1951f, 14.04145f));
                    Pos_01.Add(new Vector3(-1764.033f, -708.2069f, 17.64467f));
                    Pos_01.Add(new Vector3(-1777.351f, -702.067f, 10.4848f));
                    Pos_01.Add(new Vector3(-1776.769f, -691.2233f, 16.97348f));
                    Pos_01.Add(new Vector3(-1780.731f, -680.2358f, 10.44997f));
                    Pos_01.Add(new Vector3(-1793.184f, -673.2136f, 10.57397f));
                    Pos_01.Add(new Vector3(-1803.759f, -662.3365f, 10.7237f));
                    Pos_01.Add(new Vector3(-1817.498f, -657.4927f, 13.81193f));
                    Pos_01.Add(new Vector3(-1827.267f, -652.1654f, 18.04963f));
                    Pos_01.Add(new Vector3(-1834.165f, -641.7821f, 11.47759f));
                    Pos_01.Add(new Vector3(-1836.708f, -631.6794f, 10.74891f));
                    Pos_01.Add(new Vector3(-1838.648f, -629.8493f, 11.0014f));
                    Pos_01.Add(new Vector3(-1879.679f, -606.2506f, 18.92933f));
                    Pos_01.Add(new Vector3(-1885.089f, -600.3168f, 11.89937f));
                    Pos_01.Add(new Vector3(-1885.209f, -600.2053f, 15.5457f));
                    Pos_01.Add(new Vector3(-1884.697f, -600.3395f, 19.14856f));
                    Pos_01.Add(new Vector3(-1890.028f, -592.5482f, 18.331f));
                    Pos_01.Add(new Vector3(-1901.561f, -586.2667f, 11.8717f));
                    Pos_01.Add(new Vector3(-1901.737f, -586.5366f, 15.50729f));
                    Pos_01.Add(new Vector3(-1901.345f, -586.4103f, 18.8586f));
                    Pos_01.Add(new Vector3(-1913.928f, -574.6428f, 11.43515f));
                    Pos_01.Add(new Vector3(-1920.347f, -570.4515f, 11.91194f));
                    Pos_01.Add(new Vector3(-1920.237f, -570.4377f, 14.7448f));
                    Pos_01.Add(new Vector3(-1915.89f, -565.7648f, 17.67347f));
                    Pos_01.Add(new Vector3(-1915.907f, -565.6242f, 20.47274f));
                    Pos_01.Add(new Vector3(-1923.306f, -559.0013f, 12.06105f));
                    Pos_01.Add(new Vector3(-1927.94f, -551.8524f, 11.84189f));
                    Pos_01.Add(new Vector3(-1946.505f, -548.1843f, 14.72549f));
                    Pos_01.Add(new Vector3(-1950.271f, -545.1097f, 14.72549f));
                    Pos_01.Add(new Vector3(-1958.221f, -538.7208f, 11.89937f));
                    Pos_01.Add(new Vector3(-1958.538f, -538.6161f, 15.55085f));
                    Pos_01.Add(new Vector3(-1957.957f, -538.9095f, 19.15357f));
                    Pos_01.Add(new Vector3(-1968.042f, -532.4321f, 12.17067f));
                    Pos_01.Add(new Vector3(-1976.333f, -525.4742f, 18.92434f));
                    Pos_01.Add(new Vector3(-1980.079f, -520.5913f, 11.894f));
                    Pos_01.Add(new Vector3(-1980.366f, -520.8674f, 14.7404f));
                    Pos_01.Add(new Vector3(-1976.356f, -516.4469f, 17.67827f));
                    Pos_01.Add(new Vector3(-1976.218f, -516.0389f, 20.4677f));

                    Pos_01.Add(new Vector3(1303.104f, -528.0761f, 71.46065f));// MyZone == "MIRR" 
                    Pos_01.Add(new Vector3(1328.005f, -536.041f, 72.44083f));
                    Pos_01.Add(new Vector3(1348.163f, -547.7917f, 73.89162f));
                    Pos_01.Add(new Vector3(1372.689f, -555.9731f, 74.68577f));
                    Pos_01.Add(new Vector3(1388.346f, -569.6031f, 74.49653f));
                    Pos_01.Add(new Vector3(1385.853f, -593.0632f, 74.48546f));
                    Pos_01.Add(new Vector3(1367.295f, -606.2516f, 74.71093f));
                    Pos_01.Add(new Vector3(1342f, -597.175f, 74.7008f));
                    Pos_01.Add(new Vector3(1323.486f, -582.6028f, 73.24638f));
                    Pos_01.Add(new Vector3(1301.144f, -573.8477f, 71.73234f));
                    Pos_01.Add(new Vector3(1203.279f, -557.5997f, 69.40067f));
                    Pos_01.Add(new Vector3(1201.368f, -578.7299f, 69.13488f));
                    Pos_01.Add(new Vector3(1203.674f, -599.1799f, 68.06352f));
                    Pos_01.Add(new Vector3(1206.905f, -619.9584f, 66.43616f));
                    Pos_01.Add(new Vector3(1221.432f, -668.447f, 63.50019f));
                    Pos_01.Add(new Vector3(1222.634f, -696.9823f, 60.80664f));
                    Pos_01.Add(new Vector3(1228.98f, -725.4678f, 60.79766f));
                    Pos_01.Add(new Vector3(1265.76f, -703.2062f, 64.56302f));
                    Pos_01.Add(new Vector3(1271.215f, -683.229f, 66.03163f));
                    Pos_01.Add(new Vector3(1265.496f, -648.1833f, 67.92143f));
                    Pos_01.Add(new Vector3(1243.872f, -634.2845f, 69.32861f));
                    Pos_01.Add(new Vector3(1233.232f, -593.3051f, 69.42253f));
                    Pos_01.Add(new Vector3(1242.479f, -565.8297f, 69.65738f));
                    Pos_01.Add(new Vector3(1239.262f, -513.1147f, 69.12914f));
                    Pos_01.Add(new Vector3(1251.532f, -494.2249f, 69.90682f));
                    Pos_01.Add(new Vector3(1260.101f, -479.5116f, 70.18879f));
                    Pos_01.Add(new Vector3(1266.084f, -458.3353f, 70.51691f));
                    Pos_01.Add(new Vector3(1262.461f, -429.394f, 70.01487f));
                    Pos_01.Add(new Vector3(999.6509f, -602.5077f, 59.24988f));
                    Pos_01.Add(new Vector3(1010.405f, -572.106f, 60.59447f));
                    Pos_01.Add(new Vector3(976.5464f, -580.268f, 59.85033f));
                    Pos_01.Add(new Vector3(965.8971f, -609.0874f, 59.49282f));
                    Pos_01.Add(new Vector3(919.8752f, -569.8582f, 58.36637f));
                    Pos_01.Add(new Vector3(965.7161f, -542.8255f, 59.35909f));
                    Pos_01.Add(new Vector3(988.0938f, -525.8449f, 60.69068f));
                    Pos_01.Add(new Vector3(1005.954f, -511.3791f, 60.83396f));
                    Pos_01.Add(new Vector3(1056.8f, -448.1799f, 66.25742f));
                    Pos_01.Add(new Vector3(1051.081f, -470.3268f, 64.29682f));
                    Pos_01.Add(new Vector3(1046.621f, -497.4203f, 64.07932f));
                    Pos_01.Add(new Vector3(1089.776f, -484.1317f, 65.66021f));
                    Pos_01.Add(new Vector3(1097.907f, -464.9969f, 67.3194f));
                    Pos_01.Add(new Vector3(1099.318f, -438.5551f, 67.7905f));
                    Pos_01.Add(new Vector3(1100.173f, -411.3625f, 67.55515f));
                    Pos_01.Add(new Vector3(1121.068f, -396.8421f, 68.32484f));
                    Pos_01.Add(new Vector3(1014.722f, -469.2599f, 64.50301f));
                    Pos_01.Add(new Vector3(970.1812f, -502.0331f, 62.1409f));
                    Pos_01.Add(new Vector3(946.805f, -518.6298f, 60.62551f));
                    Pos_01.Add(new Vector3(924.0212f, -525.62f, 59.78107f));
                    Pos_01.Add(new Vector3(892.7018f, -540.6726f, 58.50655f));
                    Pos_01.Add(new Vector3(979.9705f, -627.5128f, 59.23589f));
                    Pos_01.Add(new Vector3(989.3026f, -738.9448f, 57.46308f));
                    Pos_01.Add(new Vector3(979.4105f, -716.0731f, 58.22066f));
                    Pos_01.Add(new Vector3(970.9582f, -701.2431f, 58.48196f));
                    Pos_01.Add(new Vector3(944.2244f, -678.2466f, 58.44977f));
                    Pos_01.Add(new Vector3(939.8877f, -663.1575f, 58.01383f));
                    Pos_01.Add(new Vector3(929.2795f, -639.2144f, 58.24234f));
                    Pos_01.Add(new Vector3(903.2495f, -615.7738f, 58.45334f));
                    Pos_01.Add(new Vector3(874.7638f, -607.1186f, 58.21776f));
                    Pos_01.Add(new Vector3(862.0755f, -582.3646f, 58.15649f));
                    Pos_01.Add(new Vector3(846.4515f, -551.504f, 57.70799f));
                    Pos_01.Add(new Vector3(850.5616f, -532.464f, 57.92542f));
                    Pos_01.Add(new Vector3(861.998f, -509.8099f, 57.32896f));
                    Pos_01.Add(new Vector3(878.6312f, -498.1406f, 58.09062f));
                    Pos_01.Add(new Vector3(901.3936f, -472.5109f, 59.01522f));
                    Pos_01.Add(new Vector3(922.1134f, -478.2256f, 61.0836f));
                    Pos_01.Add(new Vector3(943.9189f, -463.2539f, 61.39602f));
                    Pos_01.Add(new Vector3(961.065f, -458.4801f, 62.39756f));
                    Pos_01.Add(new Vector3(988.1276f, -433.536f, 63.89075f));
                    Pos_01.Add(new Vector3(1004.812f, -414.8121f, 64.94271f));
                    Pos_01.Add(new Vector3(1029.585f, -409.1599f, 65.94939f));
                    Pos_01.Add(new Vector3(1060.76f, -378.5183f, 68.23116f));

                }
                else
                {
                    Pos_01.Add(new Vector3(980.3473f, -710.9542f, 57.41397f)); fHeading.Add(308.5104f);
                    Pos_01.Add(new Vector3(951.1602f, -653.2234f, 57.62613f)); fHeading.Add(309.0907f);
                    Pos_01.Add(new Vector3(986.1522f, -578.1168f, 58.99873f)); fHeading.Add(34.09512f);
                    Pos_01.Add(new Vector3(957.2338f, -550.9439f, 59.07236f)); fHeading.Add(210.6819f);
                    Pos_01.Add(new Vector3(872.2705f, -599.6787f, 57.93815f)); fHeading.Add(314.4709f);
                    Pos_01.Add(new Vector3(918.4536f, -528.7723f, 58.93024f)); fHeading.Add(24.60192f);
                    Pos_01.Add(new Vector3(946.8775f, -510.3125f, 59.94468f)); fHeading.Add(27.72393f);
                    Pos_01.Add(new Vector3(941.4748f, -467.9566f, 60.98221f)); fHeading.Add(213.9737f);
                    Pos_01.Add(new Vector3(991.3154f, -436.6387f, 63.49977f)); fHeading.Add(292.3408f);
                    Pos_01.Add(new Vector3(1050.35f, -380.3262f, 67.58309f)); fHeading.Add(220.8241f);
                    Pos_01.Add(new Vector3(1102.536f, -418.7316f, 66.88247f)); fHeading.Add(84.60035f);
                    Pos_01.Add(new Vector3(1099.123f, -472.7676f, 66.66756f)); fHeading.Add(76.10673f);
                    Pos_01.Add(new Vector3(1053.464f, -482.5084f, 63.65071f)); fHeading.Add(258.9618f);
                    Pos_01.Add(new Vector3(1275.668f, -672.356f, 65.69302f)); fHeading.Add(273.7066f);
                    Pos_01.Add(new Vector3(1256.901f, -623.048f, 69.11968f)); fHeading.Add(296.0141f);
                    Pos_01.Add(new Vector3(1244.003f, -578.5009f, 69.06626f)); fHeading.Add(269.2307f);
                    Pos_01.Add(new Vector3(1348.324f, -603.4979f, 74.08501f)); fHeading.Add(332.9796f);
                    Pos_01.Add(new Vector3(1365.435f, -548.1692f, 74.06761f)); fHeading.Add(157.7411f);
                    Pos_01.Add(new Vector3(1313.359f, -519.7322f, 71.04205f)); fHeading.Add(161.4133f);
                    Pos_01.Add(new Vector3(1248.07f, -521.2718f, 68.71279f)); fHeading.Add(257.4296f);
                    Pos_01.Add(new Vector3(1271.378f, -451.3935f, 69.2456f)); fHeading.Add(205.39f);
                    Pos_01.Add(new Vector3(134.1088f, -60.30129f, 67.40459f)); fHeading.Add(70.68098f);
                    Pos_01.Add(new Vector3(51.97826f, -44.58509f, 69.12391f)); fHeading.Add(161.6227f);
                    Pos_01.Add(new Vector3(25.30462f, 80.70065f, 74.44212f)); fHeading.Add(272.4667f);
                    Pos_01.Add(new Vector3(-0.9546741f, 1.660976f, 70.78655f)); fHeading.Add(343.9719f);
                    Pos_01.Add(new Vector3(-150.6478f, 155.427f, 77.23077f)); fHeading.Add(160.6391f);
                    Pos_01.Add(new Vector3(-129.3235f, 209.7725f, 92.76147f)); fHeading.Add(177.2645f);
                    Pos_01.Add(new Vector3(-265.9961f, 106.5787f, 68.79312f)); fHeading.Add(359.7277f);
                    Pos_01.Add(new Vector3(-371.1536f, 106.8769f, 65.63227f)); fHeading.Add(358.1223f);
                    Pos_01.Add(new Vector3(-442.6092f, 98.64981f, 62.88636f)); fHeading.Add(356.5314f);
                    Pos_01.Add(new Vector3(-590.1307f, 194.1433f, 71.05424f)); fHeading.Add(91.45513f);
                    Pos_01.Add(new Vector3(-1105.929f, -1048.931f, 1.880021f)); fHeading.Add(209.2422f);
                    Pos_01.Add(new Vector3(-1040.828f, -1005.86f, 1.879707f)); fHeading.Add(206.78f);
                    Pos_01.Add(new Vector3(-996.2587f, -1002.092f, 1.880063f)); fHeading.Add(28.29245f);
                    Pos_01.Add(new Vector3(-955.9408f, -1083.62f, 1.8798f)); fHeading.Add(210.9636f);
                    Pos_01.Add(new Vector3(-1048.461f, -1152.236f, 1.888209f)); fHeading.Add(29.82095f);
                    Pos_01.Add(new Vector3(-1067.682f, -1146.465f, 1.888404f)); fHeading.Add(211.2667f);
                    Pos_01.Add(new Vector3(-1116.791f, -1212.745f, 2.234075f)); fHeading.Add(121.5045f);
                    Pos_01.Add(new Vector3(-1149.541f, -1145.446f, 2.576422f)); fHeading.Add(120.0697f);
                    Pos_01.Add(new Vector3(-1189.255f, -1065.888f, 1.879975f)); fHeading.Add(117.4356f);
                    Pos_01.Add(new Vector3(-1316.356f, -937.4818f, 9.460288f)); fHeading.Add(17.90471f);
                    Pos_01.Add(new Vector3(-1366.617f, -899.1229f, 12.20018f)); fHeading.Add(34.71532f);
                    Pos_01.Add(new Vector3(-1438.836f, -884.637f, 10.52211f)); fHeading.Add(155.3602f);
                    Pos_01.Add(new Vector3(-1146.281f, -910.4403f, 2.425397f)); fHeading.Add(209.4387f);
                    Pos_01.Add(new Vector3(-1081.033f, -921.4058f, 3.200046f)); fHeading.Add(30.9758f);
                    Pos_01.Add(new Vector3(-1054.054f, -906.4894f, 4.082501f)); fHeading.Add(29.95465f);
                    Pos_01.Add(new Vector3(-1038.931f, -902.286f, 3.838736f)); fHeading.Add(299.978f);
                    Pos_01.Add(new Vector3(-1022.476f, -890.4183f, 5.411024f)); fHeading.Add(31.85677f);
                    Pos_01.Add(new Vector3(-1451.42f, -368.5674f, 43.2327f)); fHeading.Add(6.027711f);
                    Pos_01.Add(new Vector3(-1564.278f, -249.5717f, 48.00818f)); fHeading.Add(233.6664f);
                    Pos_01.Add(new Vector3(-1520.583f, -369.7206f, 42.50985f)); fHeading.Add(46.59896f);
                    Pos_01.Add(new Vector3(-1717.838f, -494.1353f, 37.80541f)); fHeading.Add(192.4317f);
                    Pos_01.Add(new Vector3(-1655.704f, -379.0948f, 45.06553f)); fHeading.Add(223.2271f);
                    Pos_01.Add(new Vector3(-1677.955f, -411.3374f, 43.70475f)); fHeading.Add(229.3771f);
                    Pos_01.Add(new Vector3(-1702.202f, -447.6067f, 41.35829f)); fHeading.Add(320.8422f);
                    Pos_01.Add(new Vector3(-1686.702f, -459.3974f, 40.13326f)); fHeading.Add(321.5975f);

                    iAction = 1;

                    iEnterVeh = RsReturns.RandInt(1, 2);
                }

                iWeapons = 3;
            }            //Mid class
            else if (iSelect == 5)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(20, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(1258.926f, -1761.398f, 49.67699f));
                    Pos_01.Add(new Vector3(1250.658f, -1734.747f, 52.03196f));
                    Pos_01.Add(new Vector3(1295.26f, -1739.837f, 54.27173f));
                    Pos_01.Add(new Vector3(1289.748f, -1711.345f, 55.27933f));
                    Pos_01.Add(new Vector3(1314.942f, -1732.162f, 54.70008f));
                    Pos_01.Add(new Vector3(1316.928f, -1699.868f, 57.83794f));
                    Pos_01.Add(new Vector3(1365.561f, -1720.873f, 65.63401f));
                    Pos_01.Add(new Vector3(1355.67f, -1690.747f, 60.49119f));
                    Pos_01.Add(new Vector3(1342.94f, -1579.568f, 54.0538f));
                    Pos_01.Add(new Vector3(1411.792f, -1490.745f, 60.65726f));
                    Pos_01.Add(new Vector3(1382.07f, -1544.12f, 57.10718f));
                    Pos_01.Add(new Vector3(1379.234f, -1515.886f, 58.02826f));
                    Pos_01.Add(new Vector3(1360.438f, -1555.744f, 56.34147f));
                    Pos_01.Add(new Vector3(1337.987f, -1525.484f, 54.17774f));
                    Pos_01.Add(new Vector3(1315.645f, -1526.977f, 51.80762f));
                    Pos_01.Add(new Vector3(1326.927f, -1552.963f, 54.05164f));
                    Pos_01.Add(new Vector3(1286.392f, -1603.538f, 54.82489f));
                    Pos_01.Add(new Vector3(1230.891f, -1591.095f, 53.76609f));
                    Pos_01.Add(new Vector3(1244.871f, -1626.249f, 53.28225f));
                    Pos_01.Add(new Vector3(1206.614f, -1608.26f, 50.34828f));
                    Pos_01.Add(new Vector3(1214.302f, -1643.783f, 48.64599f));
                    Pos_01.Add(new Vector3(1193.243f, -1622.892f, 45.22145f));
                    Pos_01.Add(new Vector3(1193.184f, -1656.018f, 43.02645f));  // (MyZone == "EBURO")

                    Pos_01.Add(new Vector3(297.2595f, -2097.519f, 17.66359f));
                    Pos_01.Add(new Vector3(295.5801f, -2093.154f, 17.66357f));
                    Pos_01.Add(new Vector3(293.3682f, -2087.566f, 17.66357f));
                    Pos_01.Add(new Vector3(293.0396f, -2086.144f, 17.66357f));
                    Pos_01.Add(new Vector3(289.6334f, -2077.022f, 17.66078f));
                    Pos_01.Add(new Vector3(287.9153f, -2072.455f, 17.66359f));
                    Pos_01.Add(new Vector3(279.6186f, -2042.905f, 19.76756f));
                    Pos_01.Add(new Vector3(280.6062f, -2041.752f, 19.76755f));
                    Pos_01.Add(new Vector3(287.0049f, -2034.633f, 19.76756f));
                    Pos_01.Add(new Vector3(289.5717f, -2031.132f, 19.76725f));
                    Pos_01.Add(new Vector3(313.9517f, -2040.767f, 20.93602f));
                    Pos_01.Add(new Vector3(317.11f, -2043.383f, 20.93639f));
                    Pos_01.Add(new Vector3(325.714f, -2050.058f, 20.9364f));
                    Pos_01.Add(new Vector3(334.11f, -2057.375f, 20.93613f));
                    Pos_01.Add(new Vector3(342.4112f, -2064.538f, 20.93642f));
                    Pos_01.Add(new Vector3(345.5887f, -2067.228f, 20.93641f));
                    Pos_01.Add(new Vector3(357.6005f, -2073.108f, 21.74449f));
                    Pos_01.Add(new Vector3(364.8902f, -2064.472f, 21.74449f));
                    Pos_01.Add(new Vector3(371.1835f, -2057.155f, 21.7445f));
                    Pos_01.Add(new Vector3(364.3695f, -2045.641f, 22.35371f));
                    Pos_01.Add(new Vector3(360.5106f, -2042.656f, 22.3543f));
                    Pos_01.Add(new Vector3(353.1429f, -2036.6f, 22.35431f));
                    Pos_01.Add(new Vector3(351.7538f, -2035.112f, 22.35429f));
                    Pos_01.Add(new Vector3(344.6013f, -2029.163f, 22.3543f));
                    Pos_01.Add(new Vector3(343.1128f, -2028.159f, 22.35431f));
                    Pos_01.Add(new Vector3(335.6897f, -2021.638f, 22.3543f));
                    Pos_01.Add(new Vector3(332.3005f, -2018.967f, 22.35416f));
                    Pos_01.Add(new Vector3(331.4324f, -1981.701f, 24.16728f));
                    Pos_01.Add(new Vector3(334.114f, -1978.607f, 24.16728f));
                    Pos_01.Add(new Vector3(324.9895f, -1989.26f, 24.16728f));
                    Pos_01.Add(new Vector3(383.8976f, -1994.846f, 24.23498f));
                    Pos_01.Add(new Vector3(374.5296f, -1991.047f, 24.235f));
                    Pos_01.Add(new Vector3(364f, -1987.414f, 24.23451f));
                    Pos_01.Add(new Vector3(405.9168f, -1751.467f, 29.71029f));
                    Pos_01.Add(new Vector3(430.7849f, -1741f, 29.60396f));
                    Pos_01.Add(new Vector3(430.6302f, -1725.376f, 29.60146f));
                    Pos_01.Add(new Vector3(443.4339f, -1707.119f, 29.70905f));
                    Pos_01.Add(new Vector3(490.0269f, -1714.521f, 29.70519f));
                    Pos_01.Add(new Vector3(479.9201f, -1736.504f, 29.15102f));
                    Pos_01.Add(new Vector3(472.2731f, -1774.885f, 29.07085f));
                    Pos_01.Add(new Vector3(513.6623f, -1780.66f, 28.91397f));
                    Pos_01.Add(new Vector3(495.4278f, -1823.095f, 28.86971f));
                    Pos_01.Add(new Vector3(368.6719f, -1896.409f, 25.17853f));
                    Pos_01.Add(new Vector3(385.4476f, -1881.849f, 26.03137f));
                    Pos_01.Add(new Vector3(399.448f, -1864.953f, 26.71635f));
                    Pos_01.Add(new Vector3(427.4836f, -1841.994f, 28.46345f));
                    Pos_01.Add(new Vector3(440.0391f, -1830.395f, 28.36186f));
                    Pos_01.Add(new Vector3(349.0762f, -1820.522f, 28.8941f));
                    Pos_01.Add(new Vector3(328.6295f, -1845.301f, 27.74807f));
                    Pos_01.Add(new Vector3(269.8459f, -1916.823f, 26.18237f));
                    Pos_01.Add(new Vector3(250.4847f, -1935.005f, 24.69927f));
                    Pos_01.Add(new Vector3(324.2186f, -1938.26f, 25.01898f));
                    Pos_01.Add(new Vector3(295.8637f, -1972.111f, 22.90082f));
                    Pos_01.Add(new Vector3(280.3494f, -1993.836f, 20.8038f));
                    Pos_01.Add(new Vector3(256.7441f, -2023.586f, 19.26635f));    // (MyZone == "RANCHO")

                    Pos_01.Add(new Vector3(-50.39761f, -1783.597f, 28.30082f));
                    Pos_01.Add(new Vector3(-20.35306f, -1858.548f, 25.40867f));
                    Pos_01.Add(new Vector3(-10.39145f, -1883.942f, 24.14204f));
                    Pos_01.Add(new Vector3(5.216082f, -1884.246f, 23.69726f));
                    Pos_01.Add(new Vector3(45.92031f, -1864.545f, 23.27833f));
                    Pos_01.Add(new Vector3(23.177f, -1896.414f, 22.96589f));
                    Pos_01.Add(new Vector3(54.39722f, -1873.642f, 22.80583f));
                    Pos_01.Add(new Vector3(39.40047f, -1911.863f, 21.9535f));
                    Pos_01.Add(new Vector3(76.59599f, -1948.475f, 21.17416f));
                    Pos_01.Add(new Vector3(85.55811f, -1958.879f, 21.12167f));
                    Pos_01.Add(new Vector3(114.092f, -1961.006f, 21.33425f));
                    Pos_01.Add(new Vector3(100.4846f, -1912.679f, 21.40742f));
                    Pos_01.Add(new Vector3(104.29f, -1885.105f, 24.31878f));
                    Pos_01.Add(new Vector3(130.2774f, -1853.328f, 25.23479f));
                    Pos_01.Add(new Vector3(128.0303f, -1896.44f, 23.6742f));
                    Pos_01.Add(new Vector3(171.1915f, -1871.533f, 24.40023f));
                    Pos_01.Add(new Vector3(192.1942f, -1883.464f, 25.05676f));
                    Pos_01.Add(new Vector3(179.1025f, -1924.555f, 21.37102f));
                    Pos_01.Add(new Vector3(149.0806f, -1960.494f, 19.45883f));    // (MyZone == "DAVIS")

                    Pos_01.Add(new Vector3(-212.6789f, -1669.577f, 34.4632f));
                    Pos_01.Add(new Vector3(-213.5734f, -1608.434f, 34.86931f));
                    Pos_01.Add(new Vector3(-170.9348f, -1538.064f, 35.1156f));
                    Pos_01.Add(new Vector3(-117.0381f, -1477.216f, 33.8227f));
                    Pos_01.Add(new Vector3(-158.1097f, -1680.082f, 33.83337f));
                    Pos_01.Add(new Vector3(-141.8925f, -1693.16f, 32.87245f));
                    Pos_01.Add(new Vector3(-147.9179f, -1688.423f, 32.87242f));
                    Pos_01.Add(new Vector3(-142.2503f, -1693.109f, 36.1673f));
                    Pos_01.Add(new Vector3(-147.5f, -1688.599f, 36.16715f));
                    Pos_01.Add(new Vector3(-158.2306f, -1679.633f, 36.96638f));
                    Pos_01.Add(new Vector3(-116.7299f, -1660.611f, 32.56437f));
                    Pos_01.Add(new Vector3(-80.86539f, -1612.877f, 31.48242f));
                    Pos_01.Add(new Vector3(-138.0755f, -1590.171f, 34.24369f));   // (MyZone == "CHAMH") 

                    Pos_01.Add(new Vector3(-491.3341f, -705.1888f, 29.66495f));
                    Pos_01.Add(new Vector3(-818.8256f, -575.5591f, 30.27625f));
                    Pos_01.Add(new Vector3(-1006.886f, -729.0814f, 21.52976f));
                    Pos_01.Add(new Vector3(-796.8664f, -684.7003f, 29.54898f));
                    Pos_01.Add(new Vector3(-668.2699f, -971.0567f, 22.34084f));
                    Pos_01.Add(new Vector3(-667.4276f, -1105.683f, 14.68489f));
                    Pos_01.Add(new Vector3(-699.7384f, -1032.83f, 16.10666f));
                    Pos_01.Add(new Vector3(-759.088f, -1047.608f, 13.5029f));
                    Pos_01.Add(new Vector3(-601.835f, -1127.903f, 22.32424f));
                    Pos_01.Add(new Vector3(-729.3005f, -879.8181f, 22.71092f));
                    Pos_01.Add(new Vector3(-693.7856f, -810.1913f, 24.01492f));
                    Pos_01.Add(new Vector3(-471.3071f, -865.2595f, 23.96403f));
                    Pos_01.Add(new Vector3(-598.7448f, -930.2391f, 23.86363f));
                    Pos_01.Add(new Vector3(-546.7633f, -810.2938f, 30.7459f));
                    Pos_01.Add(new Vector3(-580.7145f, -778.4678f, 25.01723f));    // MyZone == "KOREAT" 
                }
                else
                {
                    Pos_01.Add(new Vector3(-38.7114f, -1447.691f, 31.23018f)); fHeading.Add(181.1343f);
                    Pos_01.Add(new Vector3(-57.70175f, -1492.996f, 31.52412f)); fHeading.Add(138.4025f);
                    Pos_01.Add(new Vector3(-219.6123f, -1692.897f, 33.66856f)); fHeading.Add(178.4189f);
                    Pos_01.Add(new Vector3(-28.47212f, -1852.85f, 25.43836f)); fHeading.Add(318.8471f);
                    Pos_01.Add(new Vector3(9.621632f, -1834.356f, 24.49837f)); fHeading.Add(47.81367f);
                    Pos_01.Add(new Vector3(40.60149f, -1854.341f, 22.56051f)); fHeading.Add(132.9123f);
                    Pos_01.Add(new Vector3(53.74987f, -1877.572f, 22.03157f)); fHeading.Add(133.118f);
                    Pos_01.Add(new Vector3(87.4607f, -1968.682f, 20.47694f)); fHeading.Add(322.3264f);
                    Pos_01.Add(new Vector3(167.47f, -1926.777f, 20.74203f)); fHeading.Add(230.3746f);
                    Pos_01.Add(new Vector3(187.1324f, -1877.092f, 24.31138f)); fHeading.Add(156.3198f);
                    Pos_01.Add(new Vector3(163.3907f, -1866.596f, 23.78651f)); fHeading.Add(156.9318f);
                    Pos_01.Add(new Vector3(137.9566f, -1893.429f, 23.1057f)); fHeading.Add(342.2924f);
                    Pos_01.Add(new Vector3(104.8897f, -1880.365f, 23.69134f)); fHeading.Add(317.687f);
                    Pos_01.Add(new Vector3(243.6653f, -1673.326f, 29.05488f)); fHeading.Add(229.2046f);
                    Pos_01.Add(new Vector3(267.9462f, -1722.845f, 29.00331f)); fHeading.Add(48.58075f);
                    Pos_01.Add(new Vector3(224.9899f, -1708.252f, 29.01782f)); fHeading.Add(218.028f);
                    Pos_01.Add(new Vector3(281.1054f, -1980.919f, 20.91549f)); fHeading.Add(230.9107f);
                    Pos_01.Add(new Vector3(241.316f, -2030.528f, 18.03692f)); fHeading.Add(232.2638f);
                    Pos_01.Add(new Vector3(361.9613f, -1901.825f, 24.51496f)); fHeading.Add(229.1611f);
                    Pos_01.Add(new Vector3(401.7927f, -1855.425f, 26.53039f)); fHeading.Add(224.8978f);
                    Pos_01.Add(new Vector3(428.8149f, -1828.597f, 27.70844f)); fHeading.Add(221.0777f);
                    Pos_01.Add(new Vector3(1302.794f, -1707.352f, 54.83981f)); fHeading.Add(201.2906f);
                    Pos_01.Add(new Vector3(1149.551f, -1643.361f, 36.06015f)); fHeading.Add(210.5101f);
                    Pos_01.Add(new Vector3(1228.379f, -1606.012f, 51.44364f)); fHeading.Add(212.9986f);
                    Pos_01.Add(new Vector3(1352.271f, -1575.337f, 53.73643f)); fHeading.Add(215.7542f);
                    Pos_01.Add(new Vector3(1373.983f, -1524.358f, 56.62693f)); fHeading.Add(198.9957f);
                    Pos_01.Add(new Vector3(1346.941f, -1550.501f, 53.38363f)); fHeading.Add(39.08664f);

                    iAction = 1;

                    iEnterVeh = RsReturns.RandInt(1, 3);
                }

                iWeapons = 3;
            }            //Low class
            else if (iSelect == 6)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(21, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(-122.6672f, -863.2216f, 33.33057f)); fHeading.Add(104.0432f);
                    Pos_01.Add(new Vector3(-209.1611f, -785.0453f, 30.45403f)); fHeading.Add(250.6104f);
                    Pos_01.Add(new Vector3(-296.5672f, -829.0057f, 32.41154f)); fHeading.Add(214.424f);
                    Pos_01.Add(new Vector3(-262.2707f, -902.109f, 32.30236f)); fHeading.Add(25.94688f);
                    Pos_01.Add(new Vector3(-270.4421f, -706.5453f, 38.26569f)); fHeading.Add(289.103f);
                    Pos_01.Add(new Vector3(-317.5008f, -609.5009f, 33.55332f)); fHeading.Add(247.4754f);
                    Pos_01.Add(new Vector3(-129.8538f, -597.3844f, 48.23175f)); fHeading.Add(222.6407f);
                    Pos_01.Add(new Vector3(-12.27154f, -676.7337f, 49.47276f)); fHeading.Add(30.79782f);
                    Pos_01.Add(new Vector3(205.6318f, -678.3058f, 43.13748f)); fHeading.Add(48.80375f);
                    Pos_01.Add(new Vector3(-175.5412f, -759.5623f, 44.22504f)); fHeading.Add(235.1201f);
                    Pos_01.Add(new Vector3(6.524668f, -933.7928f, 29.90014f)); fHeading.Add(130.7768f);
                }
                else
                {
                    int iRanLand = RsReturns.FindRandom(11, 1, 5);
                    if (iRanLand == 1)
                    {
                        Pos_01.Add(new Vector3(142.9556f, -418.5663f, 357.813f)); fHeading.Add(146.1803f);
                        Pos_01.Add(new Vector3(44.47088f, -588.145f, 394.3559f)); fHeading.Add(144.694f);
                        Pos_01.Add(new Vector3(-25.96486f, -697.7151f, 377.8641f)); fHeading.Add(156.5938f);
                        Pos_01.Add(new Vector3(-75.85501f, -815.7902f, 332.1805f)); fHeading.Add(235.7576f);
                        Pos_01.Add(new Vector3(-75.94235f, -818.4665f, 326.8517f)); fHeading.Add(235.0135f);
                    }
                    else if (iRanLand == 2)
                    {
                        Pos_01.Add(new Vector3(89.14077f, -349.5265f, 220.1292f)); fHeading.Add(95.45492f);
                        Pos_01.Add(new Vector3(-16.09307f, -416.3289f, 237.257f)); fHeading.Add(140.269f);
                        Pos_01.Add(new Vector3(-91.02924f, -495.4232f, 240.5292f)); fHeading.Add(172.6681f);
                        Pos_01.Add(new Vector3(-150.6743f, -586.1757f, 221.0396f)); fHeading.Add(217.9597f);
                        Pos_01.Add(new Vector3(-145.5026f, -593.9283f, 211.6755f)); fHeading.Add(208.2894f);
                    }
                    else if (iRanLand == 3)
                    {
                        Pos_01.Add(new Vector3(-1244.733f, -556.331f, 121.6263f)); fHeading.Add(73.09602f);
                        Pos_01.Add(new Vector3(-1314.872f, -510.2231f, 110.942f)); fHeading.Add(71.39652f);
                        Pos_01.Add(new Vector3(-1376.537f, -482.3608f, 103.3186f)); fHeading.Add(59.46054f);
                        Pos_01.Add(new Vector3(-1391.658f, -478.108f, 91.15266f)); fHeading.Add(92.62007f);
                    }
                    else if (iRanLand == 4)
                    {
                        Pos_01.Add(new Vector3(-1635.331f, -427.2587f, 152.3197f)); fHeading.Add(205.1928f);
                        Pos_01.Add(new Vector3(-1618.455f, -484.9288f, 142.6794f)); fHeading.Add(194.5483f);
                        Pos_01.Add(new Vector3(-1606.263f, -525.6398f, 134.5537f)); fHeading.Add(212.709f);
                        Pos_01.Add(new Vector3(-1593.082f, -555.8522f, 133.8456f)); fHeading.Add(235.4698f);
                        Pos_01.Add(new Vector3(-1581.926f, -568.9014f, 116.2295f)); fHeading.Add(258.0362f);
                    }
                    else if (iRanLand == 5)
                    {
                        Pos_01.Add(new Vector3(-1039.769f, -207.1729f, 178.472f)); fHeading.Add(248.8822f);
                        Pos_01.Add(new Vector3(-1038.105f, -237.4486f, 182.4304f)); fHeading.Add(223.7983f);
                        Pos_01.Add(new Vector3(-948.4437f, -340.3582f, 150.6296f)); fHeading.Add(232.3982f);
                        Pos_01.Add(new Vector3(-924.1201f, -365.4526f, 149.5871f)); fHeading.Add(225.095f);
                        Pos_01.Add(new Vector3(-912.637f, -378.214f, 137.8069f)); fHeading.Add(170.1538f);

                    }

                    iAction = 9;

                    DataStore.RanLoc_01 = Pos_01;
                    DataStore.fHeads = fHeading;
                }

                iWeapons = 2;
            }            //Buisness
            else if (iSelect == 7)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                Pos_01.Add(new Vector3(-1197.88f, -1568.177f, 4.049531f)); fHeading.Add(305.7955f);//BenchPress
                Pos_01.Add(new Vector3(-1253.458f, -1601.687f, 4.145141f)); fHeading.Add(217.3408f);
                Pos_01.Add(new Vector3(-1464.325f, -1063.733f, 3.817513f)); fHeading.Add(272.4313f);//pull ups
                Pos_01.Add(new Vector3(-1208.286f, -1559.48f, 4.609246f)); fHeading.Add(300.789f);
                Pos_01.Add(new Vector3(-1202.085f, -1572.774f, 4.607903f)); fHeading.Add(353.9804f);
                Pos_01.Add(new Vector3(-1259.167f, -1615.391f, 4.126909f)); fHeading.Add(303.0038f);
                Pos_01.Add(new Vector3(-1236.495f, -1574.453f, 4.145737f)); fHeading.Add(221.2573f);
                Pos_01.Add(new Vector3(-1413.208f, -1067.924f, 3.928926f)); fHeading.Add(18.29077f);
                Pos_01.Add(new Vector3(-1432.567f, -1048.669f, 4.555942f)); fHeading.Add(231.4996f);
                Pos_01.Add(new Vector3(-1208.97f, -1574.327f, 4.607889f)); fHeading.Add(121.9219f);//all else
                iAction = 5;
            }            //Body builder
            else if (iSelect == 8)
            {
                RandomWeatherTime();

                iSubSet = RsReturns.FindRandom(9, 1, 11);
                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-272.6266f, 325.0637f, 93.25459f)); fHeading.Add(102.7661f);
                    Pos_01.Add(new Vector3(-281.3045f, 324.4917f, 93.26128f)); fHeading.Add(109.3759f);
                    Pos_01.Add(new Vector3(-275.9741f, 324.7222f, 93.27049f)); fHeading.Add(185.5619f);
                    Pos_01.Add(new Vector3(-274.2349f, 312.5389f, 93.25461f)); fHeading.Add(61.95487f);
                    Pos_01.Add(new Vector3(-284.3914f, 311.4577f, 93.25461f)); fHeading.Add(11.21089f);//peds
                }           //Import Ex-- West Vine wood-- Vs. Polynesian.
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-450.9772f, -1725.333f, 18.68914f)); fHeading.Add(276.2404f);
                    Pos_01.Add(new Vector3(-449.4881f, -1724.789f, 18.68327f)); fHeading.Add(110.7676f);
                    Pos_01.Add(new Vector3(-417.3922f, -1702.755f, 19.50922f)); fHeading.Add(110.1307f);
                    Pos_01.Add(new Vector3(-469.3246f, -1701.666f, 18.65455f)); fHeading.Add(288.1841f);
                    Pos_01.Add(new Vector3(-467.9238f, -1696.069f, 18.82708f)); fHeading.Add(167.8869f); //peds
                }           //Armenian -- Rogers Salvage and Scrap in La Puerta.-- Vs Police 
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(115.3598f, -1947.014f, 20.60158f)); fHeading.Add(217.1962f);
                    Pos_01.Add(new Vector3(115.2621f, -1944.061f, 20.63267f)); fHeading.Add(322.8773f);
                    Pos_01.Add(new Vector3(116.2385f, -1942.619f, 20.60547f)); fHeading.Add(129.2276f);
                    Pos_01.Add(new Vector3(117.9724f, -1940.25f, 20.62111f)); fHeading.Add(106.1278f);
                    Pos_01.Add(new Vector3(118.3578f, -1939.102f, 20.64555f)); fHeading.Add(88.98208f); //peds
                }           //Ballas-- Davis, Vs --Families 
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(458.827f, -737.6528f, 27.35774f)); fHeading.Add(332.2838f);
                    Pos_01.Add(new Vector3(463.1091f, -739.5256f, 27.36115f)); fHeading.Add(167.9439f);
                    Pos_01.Add(new Vector3(462.527f, -742.2394f, 27.3605f)); fHeading.Add(21.53196f);
                    Pos_01.Add(new Vector3(461.8431f, -734.8542f, 27.35998f)); fHeading.Add(132.3374f);
                    Pos_01.Add(new Vector3(466.5947f, -730.8536f, 27.36218f)); fHeading.Add(101.3915f);//peds
                }           //Chinese textile city, Vs-- korean
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-225.4482f, -1490.504f, 31.45079f)); fHeading.Add(310.6292f);
                    Pos_01.Add(new Vector3(-222.5614f, -1488.412f, 31.2943f)); fHeading.Add(228.3047f);
                    Pos_01.Add(new Vector3(-221.2482f, -1488.211f, 31.29151f)); fHeading.Add(102.181f);
                    Pos_01.Add(new Vector3(-221.4105f, -1490.208f, 31.28293f)); fHeading.Add(17.52296f);
                    Pos_01.Add(new Vector3(-223.3837f, -1490.498f, 31.28734f)); fHeading.Add(336.8165f);//peds
                }           //Families --Strawberry--Chamberlain Hills, Vs  Ballas
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(-742.5094f, -1041.155f, 12.51869f)); fHeading.Add(12.97545f);
                    Pos_01.Add(new Vector3(-739.5043f, -1040.927f, 12.5031f)); fHeading.Add(68.58642f);
                    Pos_01.Add(new Vector3(-741.374f, -1040.158f, 12.54656f)); fHeading.Add(143.1764f);
                    Pos_01.Add(new Vector3(-743.769f, -1047.43f, 12.28089f)); fHeading.Add(341.5395f);
                    Pos_01.Add(new Vector3(-744.7137f, -1045.582f, 12.3123f)); fHeading.Add(312.4333f); //peds
                }            //Korean --K-town, Vs Chinesse
                else if (iSubSet == 7)
                {
                    Pos_01.Add(new Vector3(333.0477f, -2041.747f, 20.9505f)); fHeading.Add(78.31051f);
                    Pos_01.Add(new Vector3(335.6685f, -2038.63f, 21.16848f)); fHeading.Add(175.0418f);
                    Pos_01.Add(new Vector3(337.3491f, -2039.961f, 21.20797f)); fHeading.Add(143.0706f);
                    Pos_01.Add(new Vector3(337.0323f, -2041.932f, 21.12964f)); fHeading.Add(29.95985f);
                    Pos_01.Add(new Vector3(334.4699f, -2041.716f, 21.02297f)); fHeading.Add(251.7424f); //peds
                }           //Mexican --Rancho--Central Cypress Flats, Vs Salvadoran
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(-750.9026f, 5539.973f, 33.48567f)); fHeading.Add(47.66533f);
                    Pos_01.Add(new Vector3(-753.6173f, 5539.024f, 33.48567f)); fHeading.Add(354.5756f);
                    Pos_01.Add(new Vector3(-755.5646f, 5540.3f, 33.48567f)); fHeading.Add(315.5447f);
                    Pos_01.Add(new Vector3(-753.6513f, 5542.839f, 33.48567f)); fHeading.Add(170.8908f);
                    Pos_01.Add(new Vector3(-750.5474f, 5542.514f, 33.48567f)); fHeading.Add(125.0001f);//peds
                }           //Polynesian -- ? -- Lost
                else if (iSubSet == 9)
                {
                    Pos_01.Add(new Vector3(1161.041f, -1646.738f, 36.91954f)); fHeading.Add(48.9831f);
                    Pos_01.Add(new Vector3(1160.423f, -1644.621f, 36.92954f)); fHeading.Add(161.1805f);
                    Pos_01.Add(new Vector3(1158.195f, -1645.382f, 36.93469f)); fHeading.Add(227.3338f);
                    Pos_01.Add(new Vector3(1158.133f, -1647.429f, 36.91374f)); fHeading.Add(299.3054f);
                    Pos_01.Add(new Vector3(1159.598f, -1648.531f, 36.91959f)); fHeading.Add(17.60314f);//peds
                }           //"Salvadoran --El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal, Vs Mexican
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(975.9936f, -126.8484f, 74.16551f)); fHeading.Add(348.0559f);
                    Pos_01.Add(new Vector3(977.2745f, -124.7848f, 74.1376f)); fHeading.Add(214.7823f);
                    Pos_01.Add(new Vector3(963.3976f, -123.7268f, 74.35315f)); fHeading.Add(338.3762f);
                    Pos_01.Add(new Vector3(968.5342f, -118.6646f, 74.35315f)); fHeading.Add(121.6418f);
                    Pos_01.Add(new Vector3(974.248f, -113.7502f, 74.35315f)); fHeading.Add(90.07847f); //peds
                }           //Lost ... Vs Impex
                else
                {
                    Pos_01.Add(new Vector3(83.97136f, 260.0858f, 108.9136f)); fHeading.Add(154.9512f);
                    Pos_01.Add(new Vector3(1581.418f, 6453.026f, 25.31714f)); fHeading.Add(152.6169f);
                    Pos_01.Add(new Vector3(-1189.455f, -877.1514f, 13.6739f)); fHeading.Add(32.68035f);
                    Pos_01.Add(new Vector3(-1550.502f, -439.1086f, 40.51901f)); fHeading.Add(222.9146f);
                    Pos_01.Add(new Vector3(-593.3647f, -863.3263f, 25.92446f)); fHeading.Add(17.25182f);
                    Pos_01.Add(new Vector3(-1175.367f, -1267.867f, 6.164357f)); fHeading.Add(135.6286f);
                    Pos_01.Add(new Vector3(-856.694f, -1140.941f, 6.942525f)); fHeading.Add(218.6946f);
                    Pos_01.Add(new Vector3(-136.9821f, -260.9609f, 42.97683f)); fHeading.Add(243.6652f);
                    Pos_01.Add(new Vector3(1137.357f, -960.7468f, 47.58101f)); fHeading.Add(329.7662f);
                    Pos_01.Add(new Vector3(104.028f, -1421.119f, 29.30048f)); fHeading.Add(301.8356f);
                    Pos_01.Add(new Vector3(-189.5329f, -1430.544f, 31.51664f)); fHeading.Add(59.90533f);
                    Pos_01.Add(new Vector3(3.255534f, -1605.107f, 29.27947f)); fHeading.Add(64.94491f);
                    Pos_01.Add(new Vector3(281.5654f, -1515.604f, 29.29159f)); fHeading.Add(242.0782f);
                }           //Street Punk-- Vs Old Ladys

                iAction = 6;

                iWeapons = 5;
            }            //GangStars             
            else if (iSelect == 9)
            {
                RandomWeatherTime();

                Pos_01.Add(new Vector3(-673.7844f, 76.16772f, 69.68565f)); fHeading.Add(267.2886f);
                Pos_01.Add(new Vector3(-719.2163f, 43.45778f, 65.19431f)); fHeading.Add(177.8458f);
                Pos_01.Add(new Vector3(-708.9506f, 70.23295f, 69.68565f)); fHeading.Add(154.9646f);
                Pos_01.Add(new Vector3(-698.1004f, 46.26298f, 44.03382f)); fHeading.Add(217.7002f);
                Pos_01.Add(new Vector3(-672.0215f, 88.88709f, 55.85543f)); fHeading.Add(210.2695f);
            }            //Epslon
            else if (iSelect == 10)
            {
                RandomWeatherTime();

                int iPosX = RsReturns.FindRandom(3, 1, 6);
                int iSelectmDrops = RsReturns.FindRandom(4, 1, 5);

                if (iPosX == 1)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(228.6289f, -1394.52f, 30.494f));
                        Pos_01.Add(new Vector3(252.5324f, -1400.599f, 30.53424f));
                        Pos_01.Add(new Vector3(273.3281f, -1378.727f, 31.95101f));
                        Pos_01.Add(new Vector3(273.2798f, -1359.458f, 31.93511f));
                        Pos_01.Add(new Vector3(250.2143f, -1339.669f, 31.92071f));
                        Pos_01.Add(new Vector3(235.2781f, -1346.481f, 30.5051f));
                        Pos_01.Add(new Vector3(219.2509f, -1365.954f, 30.56017f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(-227.1508f, -2023.395f, 27.75543f));
                        Pos_01.Add(new Vector3(-222.3802f, -2007.24f, 27.75543f));
                        Pos_01.Add(new Vector3(-219.4253f, -1989.297f, 27.75542f));
                        Pos_01.Add(new Vector3(-221.2715f, -1971.702f, 27.75571f));
                        Pos_01.Add(new Vector3(-224.2942f, -1960.297f, 27.75689f));
                        Pos_01.Add(new Vector3(-240.3955f, -1966.939f, 29.94605f));
                        Pos_01.Add(new Vector3(-239.069f, -1973.878f, 29.94605f));
                        Pos_01.Add(new Vector3(-237.4634f, -1992.5f, 29.94605f));
                        Pos_01.Add(new Vector3(-240.9862f, -2009.94f, 29.94605f));
                        Pos_01.Add(new Vector3(-249.9569f, -2026.076f, 29.94605f));
                        Pos_01.Add(new Vector3(-263.3784f, -2040.735f, 29.94605f));
                        Pos_01.Add(new Vector3(-277.9292f, -2048.336f, 29.94605f));
                        Pos_01.Add(new Vector3(-273.3261f, -2064.927f, 27.75543f));
                        Pos_01.Add(new Vector3(-246.0456f, -2048.949f, 27.75543f));
                        Pos_01.Add(new Vector3(-235.4299f, -2037.349f, 27.75543f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-924.767f, -2571.403f, 13.97616f));
                        Pos_01.Add(new Vector3(-943.3739f, -2565.557f, 13.93645f));
                        Pos_01.Add(new Vector3(-961.3f, -2544.967f, 13.98062f));
                        Pos_01.Add(new Vector3(-967.3834f, -2523.3f, 13.98103f));
                        Pos_01.Add(new Vector3(-965.3172f, -2502.885f, 13.98098f));
                        Pos_01.Add(new Vector3(-960.5615f, -2492.263f, 13.98057f));
                        Pos_01.Add(new Vector3(-947.3313f, -2478.542f, 13.9807f));
                        Pos_01.Add(new Vector3(-932.3168f, -2470.56f, 13.9807f));
                        Pos_01.Add(new Vector3(-913.9728f, -2467.62f, 13.98073f));
                        Pos_01.Add(new Vector3(-889.0792f, -2472.986f, 13.98049f));
                        Pos_01.Add(new Vector3(-872.939f, -2489.196f, 13.98072f));
                        Pos_01.Add(new Vector3(-866.3092f, -2501.952f, 13.98075f));
                        Pos_01.Add(new Vector3(-863.3466f, -2512.478f, 13.98059f));
                        Pos_01.Add(new Vector3(-863.6301f, -2528.947f, 13.98072f));
                        Pos_01.Add(new Vector3(-869.4406f, -2546.69f, 13.97835f));
                        Pos_01.Add(new Vector3(-884.2811f, -2561.323f, 13.98074f));
                        Pos_01.Add(new Vector3(-896.1907f, -2568.416f, 13.98074f));
                        Pos_01.Add(new Vector3(-903.6213f, -2570.235f, 13.98074f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-287.7649f, -1638.534f, 31.84882f));
                        Pos_01.Add(new Vector3(-298.8279f, -1656.257f, 31.84881f));
                        Pos_01.Add(new Vector3(-317.5655f, -1644.264f, 31.85344f));
                        Pos_01.Add(new Vector3(-303.9065f, -1622.695f, 31.84882f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(1476.682f, -1984.691f, 70.69158f));
                        Pos_01.Add(new Vector3(1453.445f, -1972.131f, 70.44451f));
                        Pos_01.Add(new Vector3(1434.379f, -1986.595f, 65.75795f));
                        Pos_01.Add(new Vector3(1423.388f, -2007.92f, 61.90174f));
                        Pos_01.Add(new Vector3(1433.237f, -2031.683f, 57.47531f));
                        Pos_01.Add(new Vector3(1469.974f, -2042.295f, 57.02632f));
                        Pos_01.Add(new Vector3(1478.932f, -2002.187f, 68.38514f));
                    }
                }
                else if (iPosX == 2)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(129.9129f, -988.9407f, 29.32248f));
                        Pos_01.Add(new Vector3(169.9703f, -880.6992f, 30.55882f));
                        Pos_01.Add(new Vector3(174.1833f, -881.5703f, 30.89416f));
                        Pos_01.Add(new Vector3(186.1561f, -849.1542f, 31.16665f));
                        Pos_01.Add(new Vector3(193.5296f, -847.7554f, 30.91245f));
                        Pos_01.Add(new Vector3(263.498f, -872.455f, 29.17216f));
                        Pos_01.Add(new Vector3(211.1392f, -1018.212f, 29.30549f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(356.3345f, 160.7301f, 103.0043f));
                        Pos_01.Add(new Vector3(222.6689f, 208.8755f, 105.5123f));
                        Pos_01.Add(new Vector3(266.2624f, 328.2007f, 105.5289f));
                        Pos_01.Add(new Vector3(339.1058f, 311.9287f, 104.5361f));
                        Pos_01.Add(new Vector3(404.6719f, 292.2426f, 102.9655f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-68.89455f, -402.1517f, 37.29737f));
                        Pos_01.Add(new Vector3(-103.1039f, -389.6021f, 36.63163f));
                        Pos_01.Add(new Vector3(-108.889f, -409.1098f, 35.77497f));
                        Pos_01.Add(new Vector3(-127.2451f, -411.5541f, 34.58294f));
                        Pos_01.Add(new Vector3(-139.3882f, -421.2568f, 33.74562f));
                        Pos_01.Add(new Vector3(-148.7219f, -435.5255f, 33.47985f));
                        Pos_01.Add(new Vector3(-153.0547f, -451.4209f, 33.79173f));
                        Pos_01.Add(new Vector3(-145.8188f, -464.7188f, 33.17519f));
                        Pos_01.Add(new Vector3(-132.132f, -472.3099f, 33.07674f));
                        Pos_01.Add(new Vector3(-121.9619f, -474.8518f, 33.34896f));
                        Pos_01.Add(new Vector3(-89.17182f, -474.3718f, 34.96899f));
                        Pos_01.Add(new Vector3(-77.55576f, -466.7515f, 36.39326f));
                        Pos_01.Add(new Vector3(-67.24388f, -449.3546f, 38.11158f));
                        Pos_01.Add(new Vector3(-64.59761f, -437.8882f, 38.43552f));
                        Pos_01.Add(new Vector3(-64.19228f, -419.8323f, 38.09665f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-736.3101f, 90.46006f, 55.58132f));
                        Pos_01.Add(new Vector3(-737.0633f, 69.59921f, 54.30896f));
                        Pos_01.Add(new Vector3(-734.0124f, 47.01559f, 47.47584f));
                        Pos_01.Add(new Vector3(-728.4005f, 29.74567f, 42.26787f));
                        Pos_01.Add(new Vector3(-703.6444f, 36.59576f, 43.22058f));
                        Pos_01.Add(new Vector3(-681.6513f, 46.41314f, 43.09964f));
                        Pos_01.Add(new Vector3(-661.1816f, 46.04203f, 41.12265f));
                        Pos_01.Add(new Vector3(-658.776f, 85.53405f, 52.46266f));
                        Pos_01.Add(new Vector3(-662.4477f, 103.3301f, 56.80659f));
                        Pos_01.Add(new Vector3(-662.0488f, 119.3575f, 57.01698f));
                        Pos_01.Add(new Vector3(-675.6852f, 115.9964f, 56.75283f));
                        Pos_01.Add(new Vector3(-709.5087f, 98.95238f, 56.07108f));
                        Pos_01.Add(new Vector3(-718.9947f, 95.15092f, 55.8739f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1765.645f, -1149.159f, 13.07916f));
                        Pos_01.Add(new Vector3(-1837.407f, -1227.053f, 13.01728f));
                        Pos_01.Add(new Vector3(-1869.622f, -1210.43f, 13.01711f));
                        Pos_01.Add(new Vector3(-1831.916f, -1162.537f, 13.01727f));
                        Pos_01.Add(new Vector3(-1806.807f, -1181.257f, 13.01744f));
                        Pos_01.Add(new Vector3(-1797.633f, -1177.67f, 13.01751f));
                        Pos_01.Add(new Vector3(-1786.751f, -1169.576f, 13.01768f));
                        Pos_01.Add(new Vector3(-1660.035f, -1023.637f, 13.01778f));
                        Pos_01.Add(new Vector3(-1652.489f, -1014.507f, 13.01739f));
                        Pos_01.Add(new Vector3(-1659.945f, -1009.417f, 13.01739f));
                        Pos_01.Add(new Vector3(-1709.898f, -1070.201f, 13.01735f));
                        Pos_01.Add(new Vector3(-1709.359f, -1083.783f, 13.10089f));
                    }
                }
                else if (iPosX == 3)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(-2891.325f, -8.690169f, 7.963134f));
                        Pos_01.Add(new Vector3(-2910.282f, -37.03131f, 3.024998f));
                        Pos_01.Add(new Vector3(-2999.717f, 0.8205602f, 4.733732f));
                        Pos_01.Add(new Vector3(-2997.566f, 30.52503f, 7.300454f));
                        Pos_01.Add(new Vector3(-2995.444f, 36.81783f, 7.95881f));
                        Pos_01.Add(new Vector3(-2992.152f, 35.16978f, 8.5967f));
                        Pos_01.Add(new Vector3(-2987.468f, 42.83352f, 11.6085f));
                        Pos_01.Add(new Vector3(-2939.735f, 20.68083f, 11.60792f));
                        Pos_01.Add(new Vector3(-2943.227f, 12.65156f, 11.60476f));
                        Pos_01.Add(new Vector3(-2918.954f, 1.69491f, 11.60532f));
                        Pos_01.Add(new Vector3(-2891.381f, -6.391256f, 11.60316f));
                        Pos_01.Add(new Vector3(-2888.387f, 2.114674f, 11.608f));
                        Pos_01.Add(new Vector3(-2886.561f, 0.7008348f, 11.608f));
                        Pos_01.Add(new Vector3(-2888.892f, -7.902122f, 7.959469f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(-1486.228f, 875.5378f, 182.6471f));
                        Pos_01.Add(new Vector3(-1478.33f, 831.1494f, 181.7178f));
                        Pos_01.Add(new Vector3(-1514.694f, 814.3276f, 181.9242f));
                        Pos_01.Add(new Vector3(-1521.786f, 816.0013f, 181.8818f));
                        Pos_01.Add(new Vector3(-1532.458f, 826.3513f, 181.4863f));
                        Pos_01.Add(new Vector3(-1543.011f, 817.2687f, 182.2451f));
                        Pos_01.Add(new Vector3(-1549.201f, 782.2504f, 188.5506f));
                        Pos_01.Add(new Vector3(-1558.725f, 777.4117f, 189.1925f));
                        Pos_01.Add(new Vector3(-1584.688f, 765.293f, 189.1942f));
                        Pos_01.Add(new Vector3(-1592.872f, 784.2383f, 189.194f));
                        Pos_01.Add(new Vector3(-1578.12f, 790.5488f, 189.1929f));
                        Pos_01.Add(new Vector3(-1585.357f, 804.7038f, 185.9943f));
                        Pos_01.Add(new Vector3(-1575.385f, 809.5252f, 185.9944f));
                        Pos_01.Add(new Vector3(-1578.809f, 818.0173f, 185.9939f));
                        Pos_01.Add(new Vector3(-1534.582f, 848.1694f, 181.7705f));
                        Pos_01.Add(new Vector3(-1521.602f, 854.8638f, 181.5947f));
                        Pos_01.Add(new Vector3(-1496.966f, 870.4911f, 181.9422f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-1893.8f, 1974.631f, 143.1386f));
                        Pos_01.Add(new Vector3(-1929.31f, 1969.096f, 148.8142f));
                        Pos_01.Add(new Vector3(-1966.108f, 1968.237f, 154.9804f));
                        Pos_01.Add(new Vector3(-1982.965f, 1961.467f, 160.8532f));
                        Pos_01.Add(new Vector3(-1987.9f, 1950.067f, 167.1869f));
                        Pos_01.Add(new Vector3(-1982.987f, 1941.103f, 171.1532f));
                        Pos_01.Add(new Vector3(-1945.131f, 1917.294f, 173.789f));
                        Pos_01.Add(new Vector3(-1938.31f, 1890.808f, 179.907f));
                        Pos_01.Add(new Vector3(-1954.827f, 1842.859f, 180.2473f));
                        Pos_01.Add(new Vector3(-1957.488f, 1830.848f, 178.8064f));
                        Pos_01.Add(new Vector3(-1945.764f, 1820.129f, 172.0853f));
                        Pos_01.Add(new Vector3(-1937.965f, 1823.133f, 170.6982f));
                        Pos_01.Add(new Vector3(-1920.848f, 1840.997f, 166.5749f));
                        Pos_01.Add(new Vector3(-1899.503f, 1851.748f, 160.8903f));
                        Pos_01.Add(new Vector3(-1879.112f, 1865.361f, 156.9021f));
                        Pos_01.Add(new Vector3(-1841.115f, 1891.895f, 146.2764f));
                        Pos_01.Add(new Vector3(-1836.474f, 1901.321f, 145.8237f));
                        Pos_01.Add(new Vector3(-1839.368f, 1912.564f, 147.3022f));
                        Pos_01.Add(new Vector3(-1853.069f, 1930.572f, 150.2391f));
                        Pos_01.Add(new Vector3(-1878.708f, 1956.751f, 145.8794f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-319.6601f, 2786.814f, 59.43f));
                        Pos_01.Add(new Vector3(-337.5543f, 2800.789f, 58.15808f));
                        Pos_01.Add(new Vector3(-338.9051f, 2804.992f, 58.13386f));
                        Pos_01.Add(new Vector3(-327.3314f, 2822.454f, 58.19631f));
                        Pos_01.Add(new Vector3(-317.4219f, 2826.94f, 58.47928f));
                        Pos_01.Add(new Vector3(-312.7925f, 2831.25f, 58.25769f));
                        Pos_01.Add(new Vector3(-310.0566f, 2831.212f, 58.38048f));
                        Pos_01.Add(new Vector3(-297.7459f, 2823.444f, 59.15673f));
                        Pos_01.Add(new Vector3(-299.6138f, 2818.963f, 59.19112f));
                        Pos_01.Add(new Vector3(-295.6808f, 2811.254f, 58.98975f));
                        Pos_01.Add(new Vector3(-308.6064f, 2790.959f, 59.41709f));
                        Pos_01.Add(new Vector3(-316.4038f, 2787.014f, 59.56699f));
                        Pos_01.Add(new Vector3(-323.0881f, 2789.975f, 59.20899f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-2768.271f, 2695.774f, 1.370201f));
                        Pos_01.Add(new Vector3(-2755.266f, 2703.515f, 1.416718f));
                        Pos_01.Add(new Vector3(-2735.553f, 2738.595f, 1.462122f));
                        Pos_01.Add(new Vector3(-2730.177f, 2799.426f, 1.757612f));
                        Pos_01.Add(new Vector3(-2717.147f, 2824.657f, 1.186048f));
                        Pos_01.Add(new Vector3(-2730.011f, 2855.175f, 1.459975f));
                        Pos_01.Add(new Vector3(-2720.936f, 2897.158f, 1.232428f));
                        Pos_01.Add(new Vector3(-2723.055f, 2915.156f, 1.214248f));
                        Pos_01.Add(new Vector3(-2717.156f, 2934.323f, 1.675791f));
                        Pos_01.Add(new Vector3(-2736.917f, 2953.923f, 2.776649f));
                        Pos_01.Add(new Vector3(-2746.004f, 2954.125f, 2.354859f));
                        Pos_01.Add(new Vector3(-2751.835f, 2943.838f, 2.075438f));
                        Pos_01.Add(new Vector3(-2752.229f, 2914.945f, 1.281913f));
                        Pos_01.Add(new Vector3(-2752.62f, 2887.3f, 1.572614f));
                        Pos_01.Add(new Vector3(-2756.117f, 2854.283f, 1.468493f));
                        Pos_01.Add(new Vector3(-2764.645f, 2779.508f, 2.047434f));
                        Pos_01.Add(new Vector3(-2769.536f, 2743.653f, 2.138904f));
                        Pos_01.Add(new Vector3(-2776.014f, 2720.484f, 2.238141f));
                    }
                }
                else if (iPosX == 4)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(1061.091f, -558.9828f, 59.28479f));
                        Pos_01.Add(new Vector3(1066.203f, -597.2649f, 56.83318f));
                        Pos_01.Add(new Vector3(1062.106f, -610.6114f, 56.76826f));
                        Pos_01.Add(new Vector3(1022.904f, -655.5869f, 58.68858f));
                        Pos_01.Add(new Vector3(1020.39f, -657.876f, 58.61199f));
                        Pos_01.Add(new Vector3(1020.476f, -698.0944f, 56.81086f));
                        Pos_01.Add(new Vector3(1056.699f, -719.1822f, 56.815f));
                        Pos_01.Add(new Vector3(1088.558f, -738.0333f, 56.76314f));
                        Pos_01.Add(new Vector3(1132.372f, -738.0198f, 56.74362f));
                        Pos_01.Add(new Vector3(1143.484f, -710.3257f, 56.80364f));
                        Pos_01.Add(new Vector3(1127.766f, -660.5972f, 56.68017f));
                        Pos_01.Add(new Vector3(1126.506f, -644.8978f, 56.77164f));
                        Pos_01.Add(new Vector3(1119.372f, -633.5688f, 56.78326f));
                        Pos_01.Add(new Vector3(1118.719f, -612.4344f, 56.74827f));
                        Pos_01.Add(new Vector3(1124.979f, -604.9899f, 56.74682f));
                        Pos_01.Add(new Vector3(1139.324f, -591.7932f, 56.75398f));
                        Pos_01.Add(new Vector3(1142.248f, -582.8869f, 56.75351f));
                        Pos_01.Add(new Vector3(1133.203f, -563.3502f, 56.99999f));
                        Pos_01.Add(new Vector3(1125.851f, -551.4424f, 56.93082f));
                        Pos_01.Add(new Vector3(1105.572f, -540.5275f, 57.76503f));
                        Pos_01.Add(new Vector3(1105.599f, -540.5577f, 57.76052f));
                        Pos_01.Add(new Vector3(1100.637f, -540.5255f, 57.95548f));
                        Pos_01.Add(new Vector3(1100.362f, -527.494f, 63.07243f));
                        Pos_01.Add(new Vector3(1073.51f, -530.7902f, 62.03668f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(1163.911f, 280.2455f, 82.19042f));
                        Pos_01.Add(new Vector3(991.5728f, -11.44712f, 81.85177f));
                        Pos_01.Add(new Vector3(993.7879f, -40.10574f, 81.92294f));
                        Pos_01.Add(new Vector3(1011.639f, -65.61469f, 82.19008f));
                        Pos_01.Add(new Vector3(1038.523f, -82.89301f, 82.19008f));
                        Pos_01.Add(new Vector3(1072.831f, -82.7739f, 82.16786f));
                        Pos_01.Add(new Vector3(1095.682f, -69.53146f, 82.08484f));
                        Pos_01.Add(new Vector3(1265.938f, 178.9096f, 81.98807f));
                        Pos_01.Add(new Vector3(1273.632f, 195.978f, 81.91003f));
                        Pos_01.Add(new Vector3(1274.658f, 222.6223f, 81.90385f));
                        Pos_01.Add(new Vector3(1261.318f, 257.1254f, 82.07339f));
                        Pos_01.Add(new Vector3(1235.155f, 278.5591f, 82.08091f));
                        Pos_01.Add(new Vector3(1209.412f, 284.0538f, 82.0095f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(2493.767f, -317.9808f, 92.99265f));
                        Pos_01.Add(new Vector3(2465.75f, -331.269f, 92.99268f));
                        Pos_01.Add(new Vector3(2445.703f, -353.545f, 92.98891f));
                        Pos_01.Add(new Vector3(2446.853f, -417.4889f, 92.99274f));
                        Pos_01.Add(new Vector3(2474.773f, -444.7306f, 92.99303f));
                        Pos_01.Add(new Vector3(2480.923f, -437.5063f, 92.99287f));
                        Pos_01.Add(new Vector3(2479.751f, -420.7701f, 93.73516f));
                        Pos_01.Add(new Vector3(2481.842f, -406.8932f, 93.73528f));
                        Pos_01.Add(new Vector3(2494.202f, -390.2369f, 94.11994f));
                        Pos_01.Add(new Vector3(2493.491f, -374.688f, 94.11996f));
                        Pos_01.Add(new Vector3(2481.127f, -358.7106f, 93.73526f));
                        Pos_01.Add(new Vector3(2481.344f, -341.2011f, 93.00871f));
                        Pos_01.Add(new Vector3(2480.642f, -324.369f, 92.99266f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(1443.998f, 1032.925f, 114.2406f));
                        Pos_01.Add(new Vector3(1507.861f, 1033.247f, 114.2185f));
                        Pos_01.Add(new Vector3(1514.412f, 1043.134f, 114.2258f));
                        Pos_01.Add(new Vector3(1514.912f, 1101.076f, 114.2287f));
                        Pos_01.Add(new Vector3(1502.632f, 1178.213f, 114.2156f));
                        Pos_01.Add(new Vector3(1484.8f, 1185.216f, 114.1505f));
                        Pos_01.Add(new Vector3(1434.625f, 1186.282f, 114.1913f));
                        Pos_01.Add(new Vector3(1433.847f, 1092.753f, 114.2267f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(2692.736f, 1705.75f, 24.68079f));
                        Pos_01.Add(new Vector3(2806.105f, 1705.584f, 24.68113f));
                        Pos_01.Add(new Vector3(2818.727f, 1704.424f, 24.69106f));
                        Pos_01.Add(new Vector3(2823.846f, 1699.423f, 24.71452f));
                        Pos_01.Add(new Vector3(2824.438f, 1696.413f, 24.69556f));
                        Pos_01.Add(new Vector3(2824.696f, 1647.154f, 24.64242f));
                        Pos_01.Add(new Vector3(2782.65f, 1647.183f, 24.60208f));
                        Pos_01.Add(new Vector3(2780.294f, 1653.693f, 24.53028f));
                        Pos_01.Add(new Vector3(2711.461f, 1654.09f, 24.53372f));
                        Pos_01.Add(new Vector3(2711.587f, 1647.229f, 24.60396f));
                        Pos_01.Add(new Vector3(2698.269f, 1646.656f, 24.60472f));
                        Pos_01.Add(new Vector3(2695.426f, 1649.674f, 24.61012f));
                        Pos_01.Add(new Vector3(2694.013f, 1653.814f, 24.62069f));
                        Pos_01.Add(new Vector3(2694.363f, 1691.255f, 24.69635f));
                        Pos_01.Add(new Vector3(2696.989f, 1695.163f, 24.7006f));
                        Pos_01.Add(new Vector3(2702.095f, 1696.548f, 24.66678f));
                    }
                }
                else if (iPosX == 5)
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(1623.121f, 3228.294f, 40.41154f));
                        Pos_01.Add(new Vector3(1548.318f, 3147.528f, 40.53161f));
                        Pos_01.Add(new Vector3(1099.019f, 3015.776f, 40.56151f));
                        Pos_01.Add(new Vector3(1074.616f, 3035.108f, 41.24891f));
                        Pos_01.Add(new Vector3(1085.017f, 3076.249f, 40.42923f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(1090.78f, 3566.191f, 34.09589f));
                        Pos_01.Add(new Vector3(1091.477f, 3610.838f, 33.05823f));
                        Pos_01.Add(new Vector3(1047.076f, 3610.903f, 33.11738f));
                        Pos_01.Add(new Vector3(1012.615f, 3597.394f, 33.21322f));
                        Pos_01.Add(new Vector3(1017.906f, 3568.242f, 33.92956f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(73.27388f, 3633.642f, 39.70792f));
                        Pos_01.Add(new Vector3(27.01976f, 3700.822f, 39.70713f));
                        Pos_01.Add(new Vector3(28.15174f, 3713.856f, 39.71289f));
                        Pos_01.Add(new Vector3(35.53751f, 3726.467f, 39.65743f));
                        Pos_01.Add(new Vector3(73.20634f, 3740.686f, 39.71008f));
                        Pos_01.Add(new Vector3(83.90422f, 3739.935f, 39.69468f));
                        Pos_01.Add(new Vector3(99.68319f, 3726.861f, 39.67576f));
                        Pos_01.Add(new Vector3(102.9181f, 3719.429f, 39.70041f));
                        Pos_01.Add(new Vector3(82.71038f, 3679.274f, 39.71919f));
                        Pos_01.Add(new Vector3(81.40222f, 3636.785f, 39.69534f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(1041.883f, 2191.695f, 44.96709f));
                        Pos_01.Add(new Vector3(1066.888f, 2213.252f, 46.80863f));
                        Pos_01.Add(new Vector3(1031.368f, 2213.759f, 51.05772f));
                        Pos_01.Add(new Vector3(989.4823f, 2218.621f, 47.55013f));
                        Pos_01.Add(new Vector3(997.8649f, 2204.891f, 46.05443f));
                        Pos_01.Add(new Vector3(1021.423f, 2190.472f, 45.28568f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(2440.191f, 4837.629f, 36.53263f));
                        Pos_01.Add(new Vector3(2428.567f, 4921.247f, 43.66103f));
                        Pos_01.Add(new Vector3(2472.179f, 4965.375f, 45.16649f));
                        Pos_01.Add(new Vector3(2480.896f, 4990.179f, 46.22219f));
                        Pos_01.Add(new Vector3(2478.137f, 5002.943f, 45.85592f));
                        Pos_01.Add(new Vector3(2466.199f, 5016.405f, 45.56878f));
                        Pos_01.Add(new Vector3(2416.468f, 4969.382f, 46.13856f));
                        Pos_01.Add(new Vector3(2386.791f, 4938.182f, 42.70732f));
                        Pos_01.Add(new Vector3(2363.594f, 4912.43f, 41.9899f));
                        Pos_01.Add(new Vector3(2373.377f, 4895.569f, 41.92224f));
                        Pos_01.Add(new Vector3(2394.373f, 4874.57f, 40.84945f));
                    }
                }
                else
                {
                    if (iSelectmDrops == 1)
                    {
                        Pos_01.Add(new Vector3(234.6885f, 6418.486f, 30.96218f));
                        Pos_01.Add(new Vector3(248.8196f, 6415.337f, 31.88116f));
                        Pos_01.Add(new Vector3(269.739f, 6414.965f, 32.11745f));
                        Pos_01.Add(new Vector3(288.8002f, 6420.939f, 31.35575f));
                        Pos_01.Add(new Vector3(298.797f, 6432.084f, 31.80929f));
                        Pos_01.Add(new Vector3(301.9339f, 6444.203f, 32.29673f));
                        Pos_01.Add(new Vector3(306.1744f, 6493.814f, 29.37009f));
                        Pos_01.Add(new Vector3(250.2143f, 6489.353f, 30.67807f));
                        Pos_01.Add(new Vector3(171.8803f, 6482.01f, 31.94304f));
                        Pos_01.Add(new Vector3(175.2863f, 6475.943f, 31.89293f));
                    }
                    else if (iSelectmDrops == 2)
                    {
                        Pos_01.Add(new Vector3(157.3289f, 7044.97f, 1.865713f));
                        Pos_01.Add(new Vector3(102.7529f, 7073.901f, 1.931986f));
                        Pos_01.Add(new Vector3(52.24357f, 7079.25f, 2.17193f));
                        Pos_01.Add(new Vector3(23.56722f, 7052.823f, 1.409035f));
                        Pos_01.Add(new Vector3(31.16364f, 7023.305f, 7.387625f));
                        Pos_01.Add(new Vector3(41.1493f, 7013.06f, 8.625368f));
                        Pos_01.Add(new Vector3(36.24067f, 6995.254f, 8.021345f));
                        Pos_01.Add(new Vector3(73.45621f, 6951.467f, 11.52127f));
                        Pos_01.Add(new Vector3(76.90339f, 6968.756f, 10.14844f));
                        Pos_01.Add(new Vector3(96.15324f, 6976.542f, 9.490364f));
                        Pos_01.Add(new Vector3(144.0458f, 6980.392f, 8.019959f));
                        Pos_01.Add(new Vector3(157.614f, 6990.637f, 4.969121f));
                        Pos_01.Add(new Vector3(158.9223f, 7011.254f, 3.681879f));
                    }
                    else if (iSelectmDrops == 3)
                    {
                        Pos_01.Add(new Vector3(-576.4569f, 5452.922f, 60.71923f));
                        Pos_01.Add(new Vector3(-560.6669f, 5474.996f, 61.77381f));
                        Pos_01.Add(new Vector3(-552.685f, 5494.2f, 59.80086f));
                        Pos_01.Add(new Vector3(-550.2758f, 5515.276f, 59.87648f));
                        Pos_01.Add(new Vector3(-572.0354f, 5544.016f, 52.74706f));
                        Pos_01.Add(new Vector3(-601.4049f, 5515.799f, 49.60851f));
                        Pos_01.Add(new Vector3(-620.7578f, 5506.275f, 51.13645f));
                        Pos_01.Add(new Vector3(-634.4025f, 5477.448f, 53.29848f));
                        Pos_01.Add(new Vector3(-637.6897f, 5453.631f, 52.85682f));
                        Pos_01.Add(new Vector3(-595.5697f, 5458.982f, 59.10485f));
                    }
                    else if (iSelectmDrops == 4)
                    {
                        Pos_01.Add(new Vector3(-334.3983f, 6183.464f, 31.42284f));
                        Pos_01.Add(new Vector3(-305.0548f, 6212.236f, 31.45675f));
                        Pos_01.Add(new Vector3(-302.0125f, 6213.075f, 31.39697f));
                        Pos_01.Add(new Vector3(-284.0596f, 6234.494f, 31.49339f));
                        Pos_01.Add(new Vector3(-237.9272f, 6281.979f, 31.45799f));
                        Pos_01.Add(new Vector3(-252.1601f, 6297.677f, 31.45717f));
                        Pos_01.Add(new Vector3(-301.6298f, 6251.044f, 31.51244f));
                        Pos_01.Add(new Vector3(-305.8697f, 6247.805f, 31.43438f));
                        Pos_01.Add(new Vector3(-318.1996f, 6232.045f, 31.48331f));
                        Pos_01.Add(new Vector3(-322.5253f, 6227.77f, 31.46884f));
                        Pos_01.Add(new Vector3(-360.4957f, 6191.922f, 31.48243f));
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1445.911f, 4228.153f, 49.88695f));
                        Pos_01.Add(new Vector3(-1437.855f, 4232.769f, 48.72689f));
                        Pos_01.Add(new Vector3(-1414.334f, 4225.317f, 42.9243f));
                        Pos_01.Add(new Vector3(-1406.202f, 4234.257f, 39.57491f));
                        Pos_01.Add(new Vector3(-1398.107f, 4235.384f, 37.1693f));
                        Pos_01.Add(new Vector3(-1381.473f, 4242.933f, 32.96693f));
                        Pos_01.Add(new Vector3(-1379.1f, 4227.457f, 27.85471f));
                        Pos_01.Add(new Vector3(-1375.508f, 4221.704f, 26.20435f));
                        Pos_01.Add(new Vector3(-1371.023f, 4221.62f, 24.55573f));
                        Pos_01.Add(new Vector3(-1369.318f, 4234.283f, 21.74896f));
                        Pos_01.Add(new Vector3(-1365.844f, 4237.374f, 20.58922f));
                        Pos_01.Add(new Vector3(-1362.55f, 4222.789f, 18.0125f));
                        Pos_01.Add(new Vector3(-1357.766f, 4223.158f, 16.33216f));
                        Pos_01.Add(new Vector3(-1355.488f, 4230.613f, 14.08321f));
                        Pos_01.Add(new Vector3(-1349.775f, 4261.309f, 7.204568f));
                        Pos_01.Add(new Vector3(-1350.807f, 4280.167f, 3.489815f));
                        Pos_01.Add(new Vector3(-1366.992f, 4291.422f, 2.879005f));
                        Pos_01.Add(new Vector3(-1375.258f, 4295.798f, 2.808748f));
                        Pos_01.Add(new Vector3(-1409.907f, 4301.811f, 5.031199f));
                        Pos_01.Add(new Vector3(-1511.659f, 4307.015f, 5.628844f));
                        Pos_01.Add(new Vector3(-1585.516f, 4343.747f, 3.159351f));
                        Pos_01.Add(new Vector3(-1610.404f, 4373.366f, 2.441379f));
                        Pos_01.Add(new Vector3(-1644.269f, 4431.979f, 3.232418f));
                        Pos_01.Add(new Vector3(-1677.754f, 4452.332f, 2.484089f));
                        Pos_01.Add(new Vector3(-1734.826f, 4452.425f, 4.763266f));
                        Pos_01.Add(new Vector3(-1783.387f, 4475.105f, 11.17609f));
                        Pos_01.Add(new Vector3(-1815.323f, 4479.708f, 17.87292f));
                        Pos_01.Add(new Vector3(-1842.674f, 4500.0f, 22.1328f));
                        Pos_01.Add(new Vector3(-1855.061f, 4500.765f, 22.36915f));
                        Pos_01.Add(new Vector3(-1878.805f, 4481.325f, 26.10547f));
                        Pos_01.Add(new Vector3(-1912.77f, 4482.177f, 29.16429f));
                        Pos_01.Add(new Vector3(-1927.905f, 4460.231f, 34.65511f));
                        Pos_01.Add(new Vector3(-1905.194f, 4437.292f, 42.7122f));
                        Pos_01.Add(new Vector3(-1870.033f, 4417.005f, 48.25819f));
                        Pos_01.Add(new Vector3(-1739.497f, 4344.018f, 62.30252f));
                        Pos_01.Add(new Vector3(-1701.276f, 4303.689f, 69.18857f));
                        Pos_01.Add(new Vector3(-1659.563f, 4215.886f, 82.93988f));
                        Pos_01.Add(new Vector3(-1637.42f, 4205.126f, 84.06075f));
                        Pos_01.Add(new Vector3(-1587.657f, 4200.398f, 81.1502f));
                        Pos_01.Add(new Vector3(-1567.076f, 4205.095f, 78.5675f));
                        Pos_01.Add(new Vector3(-1566.948f, 4205.121f, 78.53695f));
                        Pos_01.Add(new Vector3(-1489.583f, 4226.147f, 57.02686f));
                        Pos_01.Add(new Vector3(-1461.699f, 4225.801f, 52.18763f));
                    }
                }

                iAction = 7;
            }           //Jogger
            else if (iSelect == 11)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                if (RsReturns.FindRandom(22, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(-1364.786f, 88.02513f, 60.62911f)); fHeading.Add(4.459937f);//no cart
                    Pos_01.Add(new Vector3(-1341.147f, 58.34372f, 55.24565f)); fHeading.Add(255.8883f);
                    Pos_01.Add(new Vector3(-1288.279f, 1.371114f, 50.11296f)); fHeading.Add(75.64562f);
                    Pos_01.Add(new Vector3(-1274.725f, 34.73936f, 49.62621f)); fHeading.Add(338.932f);
                    Pos_01.Add(new Vector3(-1175.636f, -65.13375f, 45.69381f)); fHeading.Add(139.9237f);
                    Pos_01.Add(new Vector3(-1114.52f, -104.372f, 41.82968f)); fHeading.Add(90.15023f);
                    Pos_01.Add(new Vector3(-983.2661f, -102.9894f, 40.56398f)); fHeading.Add(126.2475f);
                    Pos_01.Add(new Vector3(-956.8571f, -89.0538f, 40.23488f)); fHeading.Add(152.8323f);
                    Pos_01.Add(new Vector3(-1046.63f, 5.216981f, 50.38495f)); fHeading.Add(192.7493f);
                    Pos_01.Add(new Vector3(-1139.543f, -3.184531f, 48.97698f)); fHeading.Add(259.1323f);
                    Pos_01.Add(new Vector3(-1098.178f, 5.847201f, 50.7424f)); fHeading.Add(301.1844f);
                    Pos_01.Add(new Vector3(-1222.79f, 112.2568f, 58.0234f)); fHeading.Add(202.7297f);
                    Pos_01.Add(new Vector3(-1249.355f, 119.8463f, 56.71364f)); fHeading.Add(267.9071f);
                    Pos_01.Add(new Vector3(-1317.202f, 127.7053f, 57.40704f)); fHeading.Add(246.1611f);
                    Pos_01.Add(new Vector3(-1239.579f, 110.9363f, 56.97162f)); fHeading.Add(331.1595f);
                    iAction = 1;

                    iEnterVeh = 9;
                }
                else
                {
                    Pos_01.Add(new Vector3(-1107.049f, 156.9751f, 63.03234f)); fHeading.Add(122.5306f);
                    Pos_01.Add(new Vector3(-1115.922f, 217.6304f, 64.90271f)); fHeading.Add(353.1153f);
                    Pos_01.Add(new Vector3(-1331.825f, 180.7175f, 58.57675f)); fHeading.Add(279.2617f);
                    Pos_01.Add(new Vector3(-1338.933f, 39.00248f, 60.45947f)); fHeading.Add(269.2881f);
                    Pos_01.Add(new Vector3(-1341.403f, 77.53231f, 60.54446f)); fHeading.Add(272.9171f);
                }

                iWeapons = 6;
            }           //Golf
            else if (iSelect == 12)
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                Pos_01.Add(new Vector3(2720.672f, 5199.552f, 46.27291f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2963.182f, 5326.022f, 100.778f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2949.531f, 5438.373f, 162.5469f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2992.025f, 5621.749f, 232.6244f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2879.819f, 5899.114f, 365.6005f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2593.217f, 6181.326f, 166.5712f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2878.431f, 6306.65f, 61.58187f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(3088.869f, 5976.871f, 142.4146f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(3343.402f, 5605.421f, 20.52476f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2396.466f, 3537.57f, 73.30798f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2312.362f, 3462.918f, 63.92526f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2283.617f, 3717.97f, 37.76125f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2616.046f, 3664.323f, 102.1026f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(283.5832f, 947.1102f, 210.7036f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(348.7232f, 931.5547f, 203.4314f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(373.0858f, 779.3486f, 185.2447f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(948.7731f, 1037.539f, 261.536f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(700.1483f, 1207.633f, 325.3834f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(387.6657f, 1040.978f, 237.5461f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-14.01058f, 1159.781f, 245.6257f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-20.51055f, 1325.732f, 272.8569f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-185.2845f, 1296.065f, 303.9481f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-288.8628f, 1453.615f, 337.2819f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-378.9312f, 1239.677f, 326.7248f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-252.5762f, 1563.565f, 336.6067f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-426.8705f, 1592.102f, 356.4857f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-2272.792f, -23.2073f, 112.7793f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-2200.135f, 109.4031f, 164.6617f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-840.225f, 4182.86f, 215.2899f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-690.8635f, 4176.191f, 154.5896f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-524.2221f, 4194.03f, 193.7312f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-206.6364f, 4332.957f, 31.91346f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-526.2425f, 4505.556f, 79.13145f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-893.4651f, 4529.192f, 115.0835f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1129.78f, 4593.836f, 141.6974f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1282.924f, 4608.878f, 122.7074f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1640.868f, 4556.064f, 43.19655f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1850.567f, 4794.448f, 4.776535f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1496.777f, 4969.285f, 63.59271f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1640.963f, 4732.36f, 53.54873f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-1311.3f, 4852.929f, 143.8367f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-964.3344f, 4723.415f, 270.2252f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-943.7798f, 4610.354f, 238.8457f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-291.9144f, 4670.902f, 243.5815f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-587.2416f, 4754.331f, 212.2155f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(-565.4411f, 4879.412f, 168.1732f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(112.5606f, 5108.352f, 511.6148f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(230.4509f, 5247.983f, 601.9519f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(971.1742f, 5642.117f, 634.5059f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(501.2652f, 5605.104f, 797.9101f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2280.013f, 5789.094f, 155.2191f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2326.279f, 5665.603f, 99.50616f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(1793.711f, 5425.402f, 257.2485f)); fHeading.Add(122.5306f);
                Pos_01.Add(new Vector3(2397.77f, 5316.37f, 96.5042f)); fHeading.Add(122.5306f);
            }           //Hiker
            else if (iSelect == 13)
            {
                RandomWeatherTime();

                Pos_01.Add(new Vector3(1444.053f, 3749.468f, 31.92976f)); fHeading.Add(327.8784f);
                Pos_01.Add(new Vector3(1548.64f, 3513.32f, 35.98967f)); fHeading.Add(272.104f);
                Pos_01.Add(new Vector3(1533.76f, 3587.345f, 38.87133f)); fHeading.Add(114.6104f);
                Pos_01.Add(new Vector3(1628.359f, 3656.295f, 35.1298f)); fHeading.Add(336.5864f);
                Pos_01.Add(new Vector3(1636.128f, 3672.148f, 34.49414f)); fHeading.Add(115.8842f);
                Pos_01.Add(new Vector3(1542.536f, 3801.337f, 38.26442f)); fHeading.Add(174.2905f);
                Pos_01.Add(new Vector3(-177.5078f, 6151.445f, 42.63219f)); fHeading.Add(146.5759f);
                Pos_01.Add(new Vector3(66.09401f, 6663.828f, 31.7822f)); fHeading.Add(106.9903f);
                Pos_01.Add(new Vector3(-1096.575f, 318.6839f, 66.57769f)); fHeading.Add(76.68429f);
                Pos_01.Add(new Vector3(1416.632f, 6359.68f, 23.9975f)); fHeading.Add(211.194f);
                iAction = 11;
                iWeapons = 4;
            }           //Meth
            else if (iSelect == 14)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(23, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(606.2311f, 6460.72f, 30.36371f)); fHeading.Add(5.789507f);
                    Pos_01.Add(new Vector3(320.5405f, 6446.443f, 31.04944f)); fHeading.Add(270.2463f);
                    Pos_01.Add(new Vector3(290.7818f, 6630.841f, 29.3664f)); fHeading.Add(90.56525f);
                    Pos_01.Add(new Vector3(2888.594f, 4678.878f, 48.91417f)); fHeading.Add(194.4243f);
                    Pos_01.Add(new Vector3(2570.12f, 4376.354f, 40.19937f)); fHeading.Add(221.7568f);
                    Pos_01.Add(new Vector3(2558.896f, 4476.233f, 38.08518f)); fHeading.Add(315.5452f);
                    Pos_01.Add(new Vector3(2594.646f, 4650.071f, 33.75171f)); fHeading.Add(136.7592f);
                    Pos_01.Add(new Vector3(2494.011f, 4804.704f, 35.34127f)); fHeading.Add(175.9323f);
                    Pos_01.Add(new Vector3(2325.911f, 4943.582f, 41.73738f)); fHeading.Add(222.2322f);
                    Pos_01.Add(new Vector3(2255.547f, 5126.423f, 52.96769f)); fHeading.Add(227.4431f);
                    Pos_01.Add(new Vector3(2162.245f, 5100.812f, 46.41386f)); fHeading.Add(308.368f);
                    Pos_01.Add(new Vector3(2048.374f, 4850.952f, 41.61911f)); fHeading.Add(315.2769f);
                    Pos_01.Add(new Vector3(1862.38f, 4848.723f, 44.41615f)); fHeading.Add(308.6472f);
                    Pos_01.Add(new Vector3(1908.713f, 4948.124f, 50.11693f)); fHeading.Add(246.5423f);
                    Pos_01.Add(new Vector3(2008.261f, 4949.729f, 41.91264f)); fHeading.Add(133.3243f);
                    Pos_01.Add(new Vector3(430.6846f, 6468.167f, 28.74771f)); fHeading.Add(50.51311f);
                    Pos_01.Add(new Vector3(173.5756f, 2281.659f, 92.56126f)); fHeading.Add(263.4358f);
                    Pos_01.Add(new Vector3(-128.4896f, 1935.452f, 195.7328f)); fHeading.Add(0.565784f);
                    Pos_01.Add(new Vector3(851.4491f, 2197.121f, 51.95424f)); fHeading.Add(0.72941f);
                    Pos_01.Add(new Vector3(1510.296f, 2203.938f, 79.86816f)); fHeading.Add(89.00253f);
                    Pos_01.Add(new Vector3(2915.768f, 4706.488f, 49.70249f)); fHeading.Add(289.0847f);
                    Pos_01.Add(new Vector3(2544.22f, 4665.709f, 34.05292f)); fHeading.Add(9.306635f);
                    Pos_01.Add(new Vector3(1959.184f, 4648.749f, 40.72918f)); fHeading.Add(251.9252f);
                    Pos_01.Add(new Vector3(1800.967f, 4583.435f, 36.61988f)); fHeading.Add(3.34992f);
                    Pos_01.Add(new Vector3(1722.527f, 4706.51f, 42.44329f)); fHeading.Add(283.467f);
                    Pos_01.Add(new Vector3(1690.262f, 4787.966f, 41.89737f)); fHeading.Add(88.87373f);
                    Pos_01.Add(new Vector3(1661.02f, 4856.334f, 41.85426f)); fHeading.Add(185.8731f);

                    iEnterVeh = 1;

                    iAction = 1;
                }
                else
                {
                    Pos_01.Add(new Vector3(-106.8555f, 1909.862f, 197.0744f)); fHeading.Add(268.5506f);
                    Pos_01.Add(new Vector3(2222.35f, 5577.166f, 53.84396f)); fHeading.Add(276.1251f);
                    Pos_01.Add(new Vector3(1912.766f, 4822.175f, 45.52872f)); fHeading.Add(228.9311f);
                    Pos_01.Add(new Vector3(2247.639f, 4774.398f, 39.89716f)); fHeading.Add(344.2038f);
                    Pos_01.Add(new Vector3(1872.865f, 5055.132f, 51.92373f)); fHeading.Add(309.9024f);
                    Pos_01.Add(new Vector3(1784.382f, 5000.532f, 52.79548f)); fHeading.Add(128.8428f);
                    Pos_01.Add(new Vector3(340.2533f, 6625.122f, 28.87183f)); fHeading.Add(23.61716f);
                    Pos_01.Add(new Vector3(518.1836f, 6496.691f, 30.03387f)); fHeading.Add(191.6541f);
                }

                iWeapons = 4;
            }           //Rural
            else if (iSelect == 15)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                iSubSet = RsReturns.FindRandom(5, 1, 7);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-1831.184f, 812.9753f, 138.7346f)); fHeading.Add(311.9534f);
                    Pos_01.Add(new Vector3(-1764.571f, 820.3898f, 140.6735f)); fHeading.Add(224.452f);
                    Pos_01.Add(new Vector3(-1703.508f, 863.8099f, 146.1381f)); fHeading.Add(329.4052f);
                    Pos_01.Add(new Vector3(-1616.284f, 1302.846f, 135.705f)); fHeading.Add(347.8204f);
                    Pos_01.Add(new Vector3(-1486.132f, 1480.176f, 116.4422f)); fHeading.Add(348.227f);
                    Pos_01.Add(new Vector3(-1441.415f, 1967.07f, 70.34432f)); fHeading.Add(27.66854f);
                    Pos_01.Add(new Vector3(-1533.887f, 2206.239f, 55.41714f)); fHeading.Add(355.8203f);
                    Pos_01.Add(new Vector3(-1660.077f, 2391.279f, 34.17039f)); fHeading.Add(44.57704f);
                    Pos_01.Add(new Vector3(-1751.416f, 2434.735f, 31.05655f)); fHeading.Add(109.2942f);
                    Pos_01.Add(new Vector3(-2023.357f, 2341.409f, 33.70339f)); fHeading.Add(108.7265f);
                    Pos_01.Add(new Vector3(-2061.96f, 2275.943f, 41.02344f)); fHeading.Add(267.6714f);
                    Pos_01.Add(new Vector3(-1675.041f, 2222.344f, 85.92983f)); fHeading.Add(242.9998f);
                    Pos_01.Add(new Vector3(-1866.669f, 2028.195f, 138.2143f)); fHeading.Add(135.3699f);
                    Pos_01.Add(new Vector3(-1920.531f, 1768.664f, 172.25f)); fHeading.Add(107.3471f);
                    Pos_01.Add(new Vector3(-2207.551f, 1929.131f, 187.8876f)); fHeading.Add(114.3961f);
                    Pos_01.Add(new Vector3(-2545.024f, 1883.435f, 166.6029f)); fHeading.Add(204.0507f);
                    Pos_01.Add(new Vector3(-2638.612f, 1611.174f, 126.6342f)); fHeading.Add(155.5314f);
                    Pos_01.Add(new Vector3(-2633.305f, 1457.598f, 127.2729f)); fHeading.Add(184.6736f);
                    Pos_01.Add(new Vector3(-2194.78f, 1038.959f, 192.1174f)); fHeading.Add(220.2004f);
                    Pos_01.Add(new Vector3(-1931.807f, 725.5128f, 140.8996f)); fHeading.Add(309.9311f);
                }       //Racer
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-1098.633f, -1707.841f, 3.88987f)); fHeading.Add(90.94658f);
                    Pos_01.Add(new Vector3(-1159.836f, -1675.204f, 3.896749f)); fHeading.Add(113.9283f);
                    Pos_01.Add(new Vector3(-1290.18f, -1653.48f, 3.943152f)); fHeading.Add(35.13303f);
                    Pos_01.Add(new Vector3(-1364.189f, -1481.239f, 3.893025f)); fHeading.Add(14.74119f);
                    Pos_01.Add(new Vector3(-1376.141f, -1363.218f, 3.025539f)); fHeading.Add(303.6996f);
                    Pos_01.Add(new Vector3(-1414.212f, -1251.127f, 3.946122f)); fHeading.Add(35.59299f);
                    Pos_01.Add(new Vector3(-1509.133f, -1073.262f, 3.942042f)); fHeading.Add(69.98211f);
                    Pos_01.Add(new Vector3(-1682.818f, -955.2328f, 7.185737f)); fHeading.Add(74.90568f);
                    Pos_01.Add(new Vector3(-1721.408f, -886.7053f, 7.388651f)); fHeading.Add(317.7188f);
                    Pos_01.Add(new Vector3(-1703.534f, -778.4359f, 9.642578f)); fHeading.Add(48.75169f);
                    Pos_01.Add(new Vector3(-1835.261f, -665.6154f, 9.865945f)); fHeading.Add(50.18934f);
                    Pos_01.Add(new Vector3(-2067.342f, -468.4766f, 11.15151f)); fHeading.Add(50.04951f);
                    Pos_01.Add(new Vector3(-2056.839f, -428.9153f, 11.02667f)); fHeading.Add(320.5753f);
                    Pos_01.Add(new Vector3(-2075.677f, -461.2531f, 11.15421f)); fHeading.Add(235.472f);
                    Pos_01.Add(new Vector3(-1886.761f, -619.9555f, 11.02383f)); fHeading.Add(230.0587f);
                    Pos_01.Add(new Vector3(-1672.096f, -805.3911f, 9.649653f)); fHeading.Add(229.8522f);
                    Pos_01.Add(new Vector3(-1718.168f, -922.6528f, 7.201679f)); fHeading.Add(212.6043f);
                    Pos_01.Add(new Vector3(-1594.58f, -1008.036f, 6.960374f)); fHeading.Add(230.1252f);
                    Pos_01.Add(new Vector3(-1421.424f, -1200.432f, 2.879864f)); fHeading.Add(174.2845f);
                    Pos_01.Add(new Vector3(-1363.745f, -1354.689f, 3.734038f)); fHeading.Add(116.6605f);
                    Pos_01.Add(new Vector3(-1373.53f, -1462.265f, 3.899288f)); fHeading.Add(207.7464f);
                    Pos_01.Add(new Vector3(-1188.865f, -1696.42f, 3.944314f)); fHeading.Add(302.5409f);
                    Pos_01.Add(new Vector3(-1119.958f, -1689.427f, 3.891113f)); fHeading.Add(208.4599f);
                }
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-1017.562f, 5106.583f, 143.565f)); fHeading.Add(143.8827f);
                    Pos_01.Add(new Vector3(-1071.64f, 5061.932f, 166.1416f)); fHeading.Add(174.5619f);
                    Pos_01.Add(new Vector3(-1035.021f, 4968.975f, 200.3412f)); fHeading.Add(211.0696f);
                    Pos_01.Add(new Vector3(-1010.414f, 4957.312f, 195.5821f)); fHeading.Add(313.6152f);
                    Pos_01.Add(new Vector3(-969.2093f, 5008.816f, 180.9947f)); fHeading.Add(31.7368f);
                    Pos_01.Add(new Vector3(-912.714f, 5157.586f, 154.868f)); fHeading.Add(258.4962f);
                    Pos_01.Add(new Vector3(-731.6442f, 5088.924f, 137.6509f)); fHeading.Add(242.9037f);
                    Pos_01.Add(new Vector3(-655.4277f, 5090.802f, 132.4683f)); fHeading.Add(250.5016f);
                    Pos_01.Add(new Vector3(-649.8322f, 5126.122f, 125.6041f)); fHeading.Add(46.66806f);
                    Pos_01.Add(new Vector3(-754.5825f, 5187.835f, 110.7141f)); fHeading.Add(62.56298f);
                    Pos_01.Add(new Vector3(-824.0505f, 5177.887f, 111.9148f)); fHeading.Add(101.8079f);
                    Pos_01.Add(new Vector3(-893.9097f, 5209.729f, 112.5179f)); fHeading.Add(80.07652f);
                    Pos_01.Add(new Vector3(-988.9006f, 5185.046f, 121.5435f)); fHeading.Add(132.7849f);
                }       //Mountain
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(-90.27805f, 1530.019f, 285.9787f)); fHeading.Add(69.38036f);
                    Pos_01.Add(new Vector3(-181.8039f, 1542.743f, 312.8849f)); fHeading.Add(103.2741f);
                    Pos_01.Add(new Vector3(-224.489f, 1560.842f, 325.914f)); fHeading.Add(63.67017f);
                    Pos_01.Add(new Vector3(-267.6929f, 1545.163f, 335.6747f)); fHeading.Add(132.9373f);
                    Pos_01.Add(new Vector3(-289.0792f, 1456.778f, 336.3503f)); fHeading.Add(170.9723f);
                    Pos_01.Add(new Vector3(-327.6443f, 1350.852f, 344.5363f)); fHeading.Add(167.0383f);
                    Pos_01.Add(new Vector3(-375.376f, 1247.601f, 326.4334f)); fHeading.Add(139.2814f);
                    Pos_01.Add(new Vector3(-387.3534f, 1230.396f, 325.1447f)); fHeading.Add(147.9483f);
                    Pos_01.Add(new Vector3(-388.1032f, 1176.121f, 325.1177f)); fHeading.Add(249.1379f);
                    Pos_01.Add(new Vector3(-229.2232f, 1291.04f, 306.4082f)); fHeading.Add(300.9233f);
                    Pos_01.Add(new Vector3(-186.1638f, 1292.394f, 303.1103f)); fHeading.Add(235.3964f);
                    Pos_01.Add(new Vector3(-122.8801f, 1312.186f, 297.1616f)); fHeading.Add(290.4021f);
                    Pos_01.Add(new Vector3(-16.56782f, 1320.053f, 271.3388f)); fHeading.Add(250.8344f);
                    Pos_01.Add(new Vector3(35.19429f, 1292.053f, 262.6383f)); fHeading.Add(250.6078f);
                    Pos_01.Add(new Vector3(111.7312f, 1261.334f, 253.0591f)); fHeading.Add(249.888f);
                    Pos_01.Add(new Vector3(192.726f, 1286.057f, 244.9456f)); fHeading.Add(286.535f);
                    Pos_01.Add(new Vector3(218.4447f, 1324.374f, 239.0383f)); fHeading.Add(349.563f);
                    Pos_01.Add(new Vector3(189.5349f, 1361.092f, 244.0261f)); fHeading.Add(50.20052f);
                    Pos_01.Add(new Vector3(-35.94518f, 1482.559f, 276.2757f)); fHeading.Add(47.98716f);
                }
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(1131.343f, 2220.968f, 48.44126f)); fHeading.Add(243.5716f);
                    Pos_01.Add(new Vector3(1159.706f, 2217.349f, 50.82573f)); fHeading.Add(258.8792f);
                    Pos_01.Add(new Vector3(1166.896f, 2162.989f, 53.84629f)); fHeading.Add(169.9953f);
                    Pos_01.Add(new Vector3(1098.576f, 2155.015f, 52.69805f)); fHeading.Add(73.61179f);
                    Pos_01.Add(new Vector3(1090.835f, 2211.467f, 48.93021f)); fHeading.Add(9.747736f);
                    Pos_01.Add(new Vector3(1044.372f, 2192.271f, 44.4439f)); fHeading.Add(118.0097f);
                    Pos_01.Add(new Vector3(993.3459f, 2211.962f, 46.28838f)); fHeading.Add(41.27867f);
                    Pos_01.Add(new Vector3(928.5845f, 2252.565f, 44.727f)); fHeading.Add(65.21915f);
                    Pos_01.Add(new Vector3(898.9063f, 2299.954f, 45.55281f)); fHeading.Add(1.079976f);
                    Pos_01.Add(new Vector3(893.9247f, 2367.798f, 51.03556f)); fHeading.Add(9.637207f);
                    Pos_01.Add(new Vector3(890.4763f, 2458.718f, 50.12368f)); fHeading.Add(344.7286f);
                    Pos_01.Add(new Vector3(946.5344f, 2481.687f, 49.33643f)); fHeading.Add(244.823f);
                    Pos_01.Add(new Vector3(987.7492f, 2452.002f, 48.93232f)); fHeading.Add(244.9161f);
                    Pos_01.Add(new Vector3(1041.457f, 2437.304f, 44.44455f)); fHeading.Add(260.0757f);
                    Pos_01.Add(new Vector3(1079.171f, 2446.667f, 48.99023f)); fHeading.Add(308.1842f);
                    Pos_01.Add(new Vector3(1119.289f, 2479.278f, 50.80782f)); fHeading.Add(276.7901f);
                    Pos_01.Add(new Vector3(1158.328f, 2469.449f, 53.44667f)); fHeading.Add(220.5749f);
                    Pos_01.Add(new Vector3(1165.507f, 2273.166f, 50.33825f)); fHeading.Add(175.9661f);
                    Pos_01.Add(new Vector3(1125.515f, 2274.496f, 48.946f)); fHeading.Add(24.32979f);
                    Pos_01.Add(new Vector3(1114.623f, 2402.528f, 49.40758f)); fHeading.Add(7.477652f);
                    Pos_01.Add(new Vector3(1057.731f, 2410.765f, 49.92449f)); fHeading.Add(93.07478f);
                    Pos_01.Add(new Vector3(1008.178f, 2407.365f, 51.17159f)); fHeading.Add(96.8075f);
                    Pos_01.Add(new Vector3(927.653f, 2374.892f, 46.21589f)); fHeading.Add(143.9296f);
                    Pos_01.Add(new Vector3(974.15f, 2347.133f, 48.14143f)); fHeading.Add(229.5057f);
                    Pos_01.Add(new Vector3(976.75f, 2319.152f, 47.77378f)); fHeading.Add(136.5242f);
                    Pos_01.Add(new Vector3(937.3336f, 2297.426f, 45.63793f)); fHeading.Add(157.523f);
                    Pos_01.Add(new Vector3(966.1271f, 2274.494f, 46.90409f)); fHeading.Add(249.9637f);
                    Pos_01.Add(new Vector3(1012.06f, 2256.639f, 44.98619f)); fHeading.Add(273.5895f);
                    Pos_01.Add(new Vector3(1074.876f, 2257.516f, 43.97958f)); fHeading.Add(269.696f);
                    Pos_01.Add(new Vector3(1119.866f, 2237.699f, 48.11778f)); fHeading.Add(205.3962f);
                }       //BMX
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(709.8904f, -1209.633f, 24.15573f)); fHeading.Add(271.7742f);
                    Pos_01.Add(new Vector3(725.6425f, -1209.393f, 24.15294f)); fHeading.Add(264.8582f);
                    Pos_01.Add(new Vector3(727.7066f, -1226.787f, 24.16752f)); fHeading.Add(176.0324f);
                    Pos_01.Add(new Vector3(711.7754f, -1230.785f, 26.01836f)); fHeading.Add(89.38039f);
                    Pos_01.Add(new Vector3(695.2515f, -1233.058f, 24.22271f)); fHeading.Add(99.51613f);
                    Pos_01.Add(new Vector3(691.3087f, -1221.595f, 24.2079f)); fHeading.Add(1.18434f);
                    Pos_01.Add(new Vector3(710.1845f, -1218.317f, 24.13501f)); fHeading.Add(271.655f);
                }
                else
                {
                    Pos_01.Add(new Vector3(-851.1493f, -856.7646f, 18.77589f)); fHeading.Add(358.0621f);
                    Pos_01.Add(new Vector3(-906.5968f, -968.0899f, 1.743039f)); fHeading.Add(210.8783f);
                    Pos_01.Add(new Vector3(-1348.573f, -1115.726f, 3.962325f)); fHeading.Add(299.9897f);
                    Pos_01.Add(new Vector3(-659.8745f, -959.2974f, 20.91997f)); fHeading.Add(263.4982f);
                    Pos_01.Add(new Vector3(-241.4375f, -1584.557f, 33.22305f)); fHeading.Add(187.4465f);
                    Pos_01.Add(new Vector3(270.0584f, -1683.841f, 28.84942f)); fHeading.Add(297.7897f);
                    Pos_01.Add(new Vector3(473.6976f, -1815.705f, 27.51255f)); fHeading.Add(129.6885f);
                    Pos_01.Add(new Vector3(986.9617f, -676.3321f, 56.99862f)); fHeading.Add(24.37898f);
                    Pos_01.Add(new Vector3(1061.91f, -410.1332f, 66.65007f)); fHeading.Add(306.7592f);
                    Pos_01.Add(new Vector3(-3227.214f, 985.9169f, 12.22838f)); fHeading.Add(3.493601f);
                    Pos_01.Add(new Vector3(-181.3568f, 6463.39f, 30.20193f)); fHeading.Add(323.6627f);
                    Pos_01.Add(new Vector3(1665.24f, 4906.476f, 41.67233f)); fHeading.Add(354.5847f);
                }       //Cruser

                iAction = 8;

                iEnterVeh = 1;
            }           //Cycles
            else if (iSelect == 16)
            {
                World.CurrentDayTime = TimeSpan.FromHours(21);

                Pos_01.Add(new Vector3(-555.8153f, 204.4809f, 82.72643f)); fHeading.Add(252.7766f);
                Pos_01.Add(new Vector3(-237.4932f, 207.43f, 84.30554f)); fHeading.Add(303.6445f);
                Pos_01.Add(new Vector3(224.884f, 302.908f, 105.5358f)); fHeading.Add(247.2323f);
            }           //LGBTWXYZ
            else if (iSelect == 17)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                Pos_01.Add(new Vector3(-3045.812f, 55.64172f, 8.627448f)); fHeading.Add(191.5956f);
                Pos_01.Add(new Vector3(-2943.079f, 655.5176f, 22.39165f)); fHeading.Add(32.5262f);
                Pos_01.Add(new Vector3(-2962.768f, 703.4619f, 26.46712f)); fHeading.Add(164.4944f);
                Pos_01.Add(new Vector3(-2964.547f, 731.1447f, 27.88261f)); fHeading.Add(84.45402f);
                Pos_01.Add(new Vector3(-2983.335f, 751.6773f, 25.11157f)); fHeading.Add(111.447f);
                Pos_01.Add(new Vector3(-2795.803f, 1452.367f, 99.25223f)); fHeading.Add(66.35561f);
                Pos_01.Add(new Vector3(-2634.445f, 1880.577f, 158.3878f)); fHeading.Add(153.5368f);
                Pos_01.Add(new Vector3(3096.864f, 6025.98f, 121.8479f)); fHeading.Add(336.2496f);
                Pos_01.Add(new Vector3(2563.98f, 6153.684f, 161.2354f)); fHeading.Add(346.2019f);
                Pos_01.Add(new Vector3(-1859.59f, 228.4411f, 82.96251f)); fHeading.Add(127.7508f);
                Pos_01.Add(new Vector3(-1877.686f, 259.271f, 84.43298f)); fHeading.Add(51.80576f);
                Pos_01.Add(new Vector3(-1881.919f, 295.7777f, 87.72468f)); fHeading.Add(250.4356f);
                Pos_01.Add(new Vector3(-1847.838f, 282.9479f, 87.24543f)); fHeading.Add(240.6522f);
                Pos_01.Add(new Vector3(-1775.012f, 322.7032f, 87.18047f)); fHeading.Add(197.6634f);
                Pos_01.Add(new Vector3(-1710.577f, 367.765f, 88.29889f)); fHeading.Add(106.1305f);
                Pos_01.Add(new Vector3(-1678.33f, 364.0826f, 83.0807f)); fHeading.Add(119.0709f);
                Pos_01.Add(new Vector3(-1893.09f, 357.7369f, 91.81727f)); fHeading.Add(89.98589f);
                Pos_01.Add(new Vector3(-1906.691f, 389.7257f, 95.27182f)); fHeading.Add(70.20741f);
                Pos_01.Add(new Vector3(-1917.88f, 442.0487f, 101.2374f)); fHeading.Add(23.85498f);
                Pos_01.Add(new Vector3(-1775.343f, 437.326f, 125.9239f)); fHeading.Add(279.1228f);
                Pos_01.Add(new Vector3(-1919.291f, 127.1571f, 80.51678f)); fHeading.Add(248.5568f);
                Pos_01.Add(new Vector3(-1955.446f, 141.1171f, 83.02171f)); fHeading.Add(15.4176f);
                Pos_01.Add(new Vector3(-1988.662f, 239.2818f, 85.75612f)); fHeading.Add(317.5026f);
                Pos_01.Add(new Vector3(-1997.83f, 324.9079f, 89.55524f)); fHeading.Add(300.8342f);
                Pos_01.Add(new Vector3(-2033.305f, 356.9896f, 92.78632f)); fHeading.Add(259.0774f);
                Pos_01.Add(new Vector3(-2017.061f, 419.425f, 100.7554f)); fHeading.Add(104.0086f);
                Pos_01.Add(new Vector3(-2042.502f, 510.5439f, 105.0207f)); fHeading.Add(201.5715f);
                Pos_01.Add(new Vector3(-2019.332f, 607.6757f, 116.0399f)); fHeading.Add(176.9692f);
                Pos_01.Add(new Vector3(-1906.127f, 597.2462f, 121.0427f)); fHeading.Add(133.3996f);
                Pos_01.Add(new Vector3(-2004.849f, 647.3167f, 120.8392f)); fHeading.Add(179.2453f);
                Pos_01.Add(new Vector3(-1864.729f, 667.7847f, 128.7296f)); fHeading.Add(120.8827f);
                Pos_01.Add(new Vector3(-994.6255f, -1503.056f, 3.619596f)); fHeading.Add(286.6233f);
                Pos_01.Add(new Vector3(-1303.983f, -1042.059f, 11.07695f)); fHeading.Add(95.69601f);
                Pos_01.Add(new Vector3(-1418.43f, -993.3387f, 18.16207f)); fHeading.Add(113.1817f);
                Pos_01.Add(new Vector3(-1347.12f, -928.1561f, 10.38993f)); fHeading.Add(280.809f);
                Pos_01.Add(new Vector3(-1127.6f, -368.2942f, 47.66271f)); fHeading.Add(2.678566f);
                Pos_01.Add(new Vector3(-1194.313f, -238.2115f, 36.40221f)); fHeading.Add(302.0073f);
                Pos_01.Add(new Vector3(-1655.04f, -423.9619f, 39.99371f)); fHeading.Add(215.616f);
                Pos_01.Add(new Vector3(-1701.476f, -466.6209f, 39.99554f)); fHeading.Add(79.94219f);
                Pos_01.Add(new Vector3(-1996.455f, -271.146f, 30.81234f)); fHeading.Add(161.3845f);
                Pos_01.Add(new Vector3(-1197.041f, 313.4686f, 67.751f)); fHeading.Add(239.0723f);
                Pos_01.Add(new Vector3(-1337.581f, 350.9042f, 62.31931f)); fHeading.Add(289.1602f);
                Pos_01.Add(new Vector3(-1492.492f, -56.38963f, 53.43258f)); fHeading.Add(256.6854f);
                Pos_01.Add(new Vector3(-1540.042f, -109.9774f, 52.42807f)); fHeading.Add(335.4102f);
                Pos_01.Add(new Vector3(-1611.778f, -16.5292f, 56.53456f)); fHeading.Add(226.6901f);
                Pos_01.Add(new Vector3(-1639.233f, -9.076792f, 59.92145f)); fHeading.Add(4.578232f);
                Pos_01.Add(new Vector3(-1586.684f, 4.038853f, 59.26731f)); fHeading.Add(98.43343f);
                Pos_01.Add(new Vector3(-1529.05f, -5.181115f, 54.84669f)); fHeading.Add(332.3435f);
                Pos_01.Add(new Vector3(-1479.162f, 14.24485f, 52.43146f)); fHeading.Add(311.0717f);
                Pos_01.Add(new Vector3(-1461.813f, 179.0799f, 54.75267f)); fHeading.Add(268.7966f);
                Pos_01.Add(new Vector3(-788.2491f, -788.2381f, 26.32391f)); fHeading.Add(347.4677f);
                Pos_01.Add(new Vector3(-552.5022f, -783.8768f, 29.30106f)); fHeading.Add(186.7736f);
                Pos_01.Add(new Vector3(-724.062f, -1001.766f, 16.71691f)); fHeading.Add(75.74413f);
                Pos_01.Add(new Vector3(-1029.607f, 290.339f, 65.11586f)); fHeading.Add(78.66148f);
                Pos_01.Add(new Vector3(-1053.091f, 365.7118f, 68.35947f)); fHeading.Add(165.9629f);
                Pos_01.Add(new Vector3(-878.9501f, 340.3165f, 83.47378f)); fHeading.Add(320.597f);
                Pos_01.Add(new Vector3(-887.8083f, 327.1554f, 82.18018f)); fHeading.Add(180.3041f);
                Pos_01.Add(new Vector3(-831.8134f, 248.9689f, 77.22815f)); fHeading.Add(273.1329f);
                Pos_01.Add(new Vector3(-893.313f, 169.0273f, 67.68666f)); fHeading.Add(93.2482f);
                Pos_01.Add(new Vector3(-954.7523f, 220.4424f, 65.75686f)); fHeading.Add(136.6233f);
                Pos_01.Add(new Vector3(-1010.184f, 226.0269f, 63.68847f)); fHeading.Add(38.22365f);
                Pos_01.Add(new Vector3(-1017.759f, 148.1357f, 56.12671f)); fHeading.Add(293.8944f);
                Pos_01.Add(new Vector3(-1000.254f, 121.9075f, 53.94715f)); fHeading.Add(270.1829f);
                Pos_01.Add(new Vector3(-888.7141f, 101.3723f, 53.14249f)); fHeading.Add(87.43171f);
                Pos_01.Add(new Vector3(-787.3904f, 123.0227f, 54.69615f)); fHeading.Add(80.05839f);
                Pos_01.Add(new Vector3(-952.6634f, 53.73639f, 48.71432f)); fHeading.Add(208.2334f);
                Pos_01.Add(new Vector3(-895.5533f, -37.63317f, 36.60196f)); fHeading.Add(233.8345f);
                Pos_01.Add(new Vector3(-1024.37f, 432.2284f, 71.08146f)); fHeading.Add(154.1581f);
                Pos_01.Add(new Vector3(-995.2686f, 438.8302f, 78.33302f)); fHeading.Add(334.0864f);
                Pos_01.Add(new Vector3(-1000.844f, 463.134f, 77.19495f)); fHeading.Add(104.392f);
                Pos_01.Add(new Vector3(-980.0664f, 463.8022f, 79.73483f)); fHeading.Add(46.73758f);
                Pos_01.Add(new Vector3(-927.5062f, 487.5936f, 82.77666f)); fHeading.Add(170.0165f);
                Pos_01.Add(new Vector3(-936.8797f, 501.3094f, 79.72826f)); fHeading.Add(53.92431f);
                Pos_01.Add(new Vector3(-1013.338f, 539.5078f, 77.79255f)); fHeading.Add(282.0752f);
                Pos_01.Add(new Vector3(-1066.973f, 497.7644f, 83.94453f)); fHeading.Add(220.1158f);
                Pos_01.Add(new Vector3(-1117.826f, 512.5352f, 80.53722f)); fHeading.Add(231.0205f);
                Pos_01.Add(new Vector3(-1160.468f, 509.6538f, 84.52025f)); fHeading.Add(279.801f);
                Pos_01.Add(new Vector3(-1193.058f, 491.3557f, 96.80259f)); fHeading.Add(331.3968f);
                Pos_01.Add(new Vector3(-1303.943f, 492.6552f, 96.08507f)); fHeading.Add(225.8883f);
                Pos_01.Add(new Vector3(-1392.492f, 601.5625f, 129.8707f)); fHeading.Add(353.5048f);
                Pos_01.Add(new Vector3(-1413.317f, 588.257f, 125.1205f)); fHeading.Add(217.9151f);
                Pos_01.Add(new Vector3(-1386.419f, 505.1083f, 119.582f)); fHeading.Add(105.1062f);
                Pos_01.Add(new Vector3(-1326.583f, 540.5914f, 122.6075f)); fHeading.Add(269.3641f);
                Pos_01.Add(new Vector3(-1298.875f, 577.9588f, 128.2203f)); fHeading.Add(178.3084f);
                Pos_01.Add(new Vector3(-1271.058f, 596.7078f, 137.4534f)); fHeading.Add(247.1871f);
                Pos_01.Add(new Vector3(-1233.919f, 615.423f, 137.1098f)); fHeading.Add(289.2881f);
                Pos_01.Add(new Vector3(-1136.452f, 713.3501f, 153.7498f)); fHeading.Add(201.2598f);
                Pos_01.Add(new Vector3(-1107.412f, 732.3629f, 157.4969f)); fHeading.Add(143.5177f);
                Pos_01.Add(new Vector3(-1087.713f, 750.5551f, 167.9281f)); fHeading.Add(164.4328f);
                Pos_01.Add(new Vector3(-1025.926f, 770.5267f, 169.6798f)); fHeading.Add(211.2749f);
                Pos_01.Add(new Vector3(-977.2301f, 735.5602f, 172.0218f)); fHeading.Add(265.5352f);
                Pos_01.Add(new Vector3(-909.6926f, 740.3763f, 180.0956f)); fHeading.Add(81.82249f);
                Pos_01.Add(new Vector3(-868.6624f, 752.2235f, 189.9032f)); fHeading.Add(7.877455f);
                Pos_01.Add(new Vector3(-814.408f, 783.7341f, 200.6464f)); fHeading.Add(29.9381f);
                Pos_01.Add(new Vector3(-752.7916f, 777.5481f, 211.9392f)); fHeading.Add(194.7471f);
                Pos_01.Add(new Vector3(-909.4453f, 843.1014f, 184.2988f)); fHeading.Add(140.1425f);
                Pos_01.Add(new Vector3(-971.9465f, 842.3605f, 175.6778f)); fHeading.Add(54.60799f);
                Pos_01.Add(new Vector3(-1022.66f, 842.3872f, 170.6267f)); fHeading.Add(244.5529f);
                Pos_01.Add(new Vector3(-1066.097f, 839.69f, 164.9688f)); fHeading.Add(217.0195f);
                Pos_01.Add(new Vector3(-1094.515f, 836.8392f, 166.7997f)); fHeading.Add(226.6554f);
                Pos_01.Add(new Vector3(-1159.052f, 807.4681f, 165.6994f)); fHeading.Add(247.5676f);
                Pos_01.Add(new Vector3(-1336.202f, 429.5737f, 98.90172f)); fHeading.Add(10.91781f);
                Pos_01.Add(new Vector3(-1209.78f, 434.0115f, 83.63775f)); fHeading.Add(79.56482f);
                Pos_01.Add(new Vector3(-1146.08f, 437.287f, 84.84669f)); fHeading.Add(213.0582f);
                Pos_01.Add(new Vector3(-1461.746f, 478.9407f, 114.6442f)); fHeading.Add(294.9983f);
                Pos_01.Add(new Vector3(-1474.807f, 432.7327f, 110.9154f)); fHeading.Add(211.9605f);
                Pos_01.Add(new Vector3(-1518.777f, 391.6364f, 106.1265f)); fHeading.Add(187.5404f);
                Pos_01.Add(new Vector3(-1062.276f, 567.8226f, 100.8951f)); fHeading.Add(14.25475f);
                Pos_01.Add(new Vector3(-907.7054f, 504.5181f, 91.1715f)); fHeading.Add(343.916f);
                Pos_01.Add(new Vector3(-900.4271f, 478.245f, 87.10304f)); fHeading.Add(240.5481f);
                Pos_01.Add(new Vector3(-814.1697f, 454.6563f, 88.76468f)); fHeading.Add(97.29221f);
                Pos_01.Add(new Vector3(-834.1874f, 492.4228f, 88.93082f)); fHeading.Add(302.3769f);
                Pos_01.Add(new Vector3(-845.0479f, 545.5221f, 93.45917f)); fHeading.Add(20.59651f);
                Pos_01.Add(new Vector3(-887.1305f, 575.8942f, 99.39474f)); fHeading.Add(305.7055f);
                Pos_01.Add(new Vector3(-937.6163f, 612.3262f, 108.1101f)); fHeading.Add(114.1795f);
                Pos_01.Add(new Vector3(-1125.642f, 604.6667f, 102.6665f)); fHeading.Add(23.63789f);
                Pos_01.Add(new Vector3(-1175.469f, 604.4519f, 101.4761f)); fHeading.Add(220.994f);
                Pos_01.Add(new Vector3(-685.0389f, 794.5554f, 197.2649f)); fHeading.Add(238.0637f);
                Pos_01.Add(new Vector3(-614.069f, 759.4872f, 187.0014f)); fHeading.Add(221.4456f);
                Pos_01.Add(new Vector3(-649.715f, 743.8446f, 172.4775f)); fHeading.Add(87.59254f);
                Pos_01.Add(new Vector3(-613.1782f, 621.3754f, 149.7904f)); fHeading.Add(164.7444f);
                Pos_01.Add(new Vector3(-634.371f, 659.1119f, 148.6696f)); fHeading.Add(22.42731f);
                Pos_01.Add(new Vector3(-661.1744f, 616.6246f, 146.1949f)); fHeading.Add(199.2662f);
                Pos_01.Add(new Vector3(-729.4888f, 685.0509f, 155.9513f)); fHeading.Add(180.7433f);
                Pos_01.Add(new Vector3(-734.0542f, 652.4131f, 154.2377f)); fHeading.Add(167.3811f);
                Pos_01.Add(new Vector3(-839.3329f, 693.5334f, 145.2106f)); fHeading.Add(154.7381f);
                Pos_01.Add(new Vector3(-1064.972f, 701.9827f, 163.6349f)); fHeading.Add(353.3205f);
                Pos_01.Add(new Vector3(-1601.946f, 770.3289f, 187.6154f)); fHeading.Add(101.8007f);
                Pos_01.Add(new Vector3(-674.3577f, 866.253f, 223.6916f)); fHeading.Add(351.8296f);
                Pos_01.Add(new Vector3(-621.1686f, 832.4181f, 204.3554f)); fHeading.Add(326.4169f);
                Pos_01.Add(new Vector3(-544.7578f, 793.3355f, 195.8609f)); fHeading.Add(177.7308f);
                Pos_01.Add(new Vector3(-554.5526f, 612.8793f, 136.0247f)); fHeading.Add(192.0421f);
                Pos_01.Add(new Vector3(-570.2823f, 544.6909f, 108.9361f)); fHeading.Add(196.9023f);
                Pos_01.Add(new Vector3(-571.0569f, 580.2227f, 113.3992f)); fHeading.Add(304.4825f);
                Pos_01.Add(new Vector3(-623.428f, 555.0164f, 110.5005f)); fHeading.Add(256.445f);
                Pos_01.Add(new Vector3(-661.4534f, 551.3612f, 109.9831f)); fHeading.Add(274.937f);
                Pos_01.Add(new Vector3(-662.6475f, 520.2614f, 108.8628f)); fHeading.Add(35.55315f);
                Pos_01.Add(new Vector3(-760.3415f, 495.6663f, 105.6227f)); fHeading.Add(197.768f);
                Pos_01.Add(new Vector3(-792.6409f, 488.0746f, 98.77155f)); fHeading.Add(239.2353f);
                Pos_01.Add(new Vector3(-557.361f, 410.2712f, 98.9854f)); fHeading.Add(103.8872f);
                Pos_01.Add(new Vector3(-622.6409f, 452.2882f, 107.0253f)); fHeading.Add(21.81733f);
                Pos_01.Add(new Vector3(-654.8201f, 443.7271f, 108.8958f)); fHeading.Add(98.25793f);
                Pos_01.Add(new Vector3(-707.8818f, 434.7238f, 105.3034f)); fHeading.Add(206.2419f);
                Pos_01.Add(new Vector3(-793.0532f, 408.5196f, 90.11823f)); fHeading.Add(317.7177f);
                Pos_01.Add(new Vector3(-429.6884f, 433.9929f, 111.3882f)); fHeading.Add(142.4591f);
                Pos_01.Add(new Vector3(-470.8019f, 431.3893f, 101.4715f)); fHeading.Add(65.82205f);
                Pos_01.Add(new Vector3(-485.7001f, 446.8537f, 95.78496f)); fHeading.Add(143.3383f);
                Pos_01.Add(new Vector3(-526.5187f, 455.3444f, 101.9223f)); fHeading.Add(82.61566f);
                Pos_01.Add(new Vector3(-502.1317f, 483.4032f, 105.871f)); fHeading.Add(353.9517f);
                Pos_01.Add(new Vector3(-467.4027f, 505.9088f, 120.1588f)); fHeading.Add(152.0833f);
                Pos_01.Add(new Vector3(-446.5811f, 507.9971f, 118.1903f)); fHeading.Add(237.8992f);
                Pos_01.Add(new Vector3(-400.2415f, 479.6264f, 118.3372f)); fHeading.Add(194.5138f);
                Pos_01.Add(new Vector3(-377.3803f, 442.6701f, 112.4488f)); fHeading.Add(352.5979f);
                Pos_01.Add(new Vector3(-315.0863f, 523.4f, 120.1131f)); fHeading.Add(172.5486f);
                Pos_01.Add(new Vector3(-343.7807f, 556.3951f, 125.0126f)); fHeading.Add(58.56496f);
                Pos_01.Add(new Vector3(-462.3269f, 570.8691f, 125.009f)); fHeading.Add(198.8191f);
                Pos_01.Add(new Vector3(-433.771f, 698.8554f, 151.4797f)); fHeading.Add(104.4336f);
                Pos_01.Add(new Vector3(-246.2313f, 658.5173f, 186.7893f)); fHeading.Add(78.76883f);
                Pos_01.Add(new Vector3(-202.4824f, 662.7463f, 199.0307f)); fHeading.Add(206.3775f);
                Pos_01.Add(new Vector3(-442.3546f, 621.9311f, 141.2312f)); fHeading.Add(94.32441f);
                Pos_01.Add(new Vector3(-409.7963f, 626.1968f, 156.7769f)); fHeading.Add(294.2011f);
                Pos_01.Add(new Vector3(-328.9471f, 602.281f, 170.6802f)); fHeading.Add(186.9233f);
                Pos_01.Add(new Vector3(-280.7156f, 567.8633f, 172.5188f)); fHeading.Add(153.9769f);
                Pos_01.Add(new Vector3(-244.0822f, 565.3209f, 183.8785f)); fHeading.Add(164.9493f);
                Pos_01.Add(new Vector3(-174.8147f, 565.8653f, 188.8128f)); fHeading.Add(166.2484f);
                Pos_01.Add(new Vector3(-122.5135f, 571.5621f, 194.6613f)); fHeading.Add(180.1518f);
                Pos_01.Add(new Vector3(298.9084f, 463.998f, 141.1974f)); fHeading.Add(177.8186f);
                Pos_01.Add(new Vector3(283.5058f, 501.5374f, 146.2818f)); fHeading.Add(272.0558f);
                Pos_01.Add(new Vector3(294.0867f, 530.4378f, 150.9946f)); fHeading.Add(147.5757f);
                Pos_01.Add(new Vector3(242.9051f, 639.3737f, 184.2167f)); fHeading.Add(174.0911f);
                Pos_01.Add(new Vector3(184.7669f, 551.7874f, 178.1748f)); fHeading.Add(161.2797f);
                Pos_01.Add(new Vector3(91.22596f, 535.8976f, 171.8904f)); fHeading.Add(191.2823f);
                Pos_01.Add(new Vector3(52.97155f, 533.974f, 173.7988f)); fHeading.Add(98.56342f);
                Pos_01.Add(new Vector3(223.5663f, 481.628f, 138.9433f)); fHeading.Add(186.0741f);
                Pos_01.Add(new Vector3(154.6444f, 479.0873f, 140.5918f)); fHeading.Add(229.5701f);
                Pos_01.Add(new Vector3(150.1482f, 456.2213f, 139.5088f)); fHeading.Add(192.9131f);
                Pos_01.Add(new Vector3(100.1431f, 439.8868f, 140.4936f)); fHeading.Add(240.5627f);
                Pos_01.Add(new Vector3(24.01077f, 431.562f, 141.2572f)); fHeading.Add(191.9438f);
                Pos_01.Add(new Vector3(-72.6179f, 465.5805f, 135.9239f)); fHeading.Add(76.12296f);
                Pos_01.Add(new Vector3(-123.3051f, 484.7867f, 135.2343f)); fHeading.Add(277.5651f);
                Pos_01.Add(new Vector3(-181.1604f, 481.0771f, 132.1258f)); fHeading.Add(173.1447f);
                Pos_01.Add(new Vector3(-240.873f, 462.7502f, 124.9531f)); fHeading.Add(265.0873f);
                Pos_01.Add(new Vector3(-280.4801f, 455.5736f, 108.9758f)); fHeading.Add(11.24059f);
                Pos_01.Add(new Vector3(-151.0757f, 397.4683f, 109.3303f)); fHeading.Add(102.5608f);
                Pos_01.Add(new Vector3(-195.848f, 375.325f, 107.4195f)); fHeading.Add(118.4353f);
                Pos_01.Add(new Vector3(-250.1479f, 349.482f, 108.4312f)); fHeading.Add(257.0241f);
                Pos_01.Add(new Vector3(-312.6213f, 338.596f, 108.3876f)); fHeading.Add(270.0114f);
                Pos_01.Add(new Vector3(-305.1698f, 404.4672f, 107.9418f)); fHeading.Add(19.61601f);
                Pos_01.Add(new Vector3(-361.4859f, 388.3761f, 110.2353f)); fHeading.Add(296.8794f);
                Pos_01.Add(new Vector3(-427.2299f, 374.5766f, 106.6869f)); fHeading.Add(346.4425f);
                Pos_01.Add(new Vector3(-495.9285f, 379.7473f, 100.1044f)); fHeading.Add(110.8691f);
                Pos_01.Add(new Vector3(259.914f, 768.7663f, 198.1667f)); fHeading.Add(171.6786f);
                Pos_01.Add(new Vector3(-82.69418f, 951.5432f, 231.5304f)); fHeading.Add(4.040697f);
                Pos_01.Add(new Vector3(-53.98798f, 801.733f, 225.2128f)); fHeading.Add(198.7475f);
                Pos_01.Add(new Vector3(-158.4015f, 872.744f, 231.239f)); fHeading.Add(281.8446f);
                Pos_01.Add(new Vector3(-203.0339f, 993.9344f, 229.9067f)); fHeading.Add(170.5246f);
                Pos_01.Add(new Vector3(261.3582f, 53.34766f, 86.86005f)); fHeading.Add(112.5693f);
                Pos_01.Add(new Vector3(-9.255273f, -33.10223f, 67.3112f)); fHeading.Add(170.3541f);
                Pos_01.Add(new Vector3(-118.0738f, 15.28374f, 67.68005f)); fHeading.Add(185.8164f);
                Pos_01.Add(new Vector3(-55.54819f, 112.7238f, 79.84457f)); fHeading.Add(36.34098f);
                Pos_01.Add(new Vector3(-16.14182f, 348.6998f, 111.2587f)); fHeading.Add(185.8422f);
                Pos_01.Add(new Vector3(512.7614f, 214.5401f, 102.8892f)); fHeading.Add(79.30675f);
                Pos_01.Add(new Vector3(-303.4641f, 163.318f, 86.68427f)); fHeading.Add(195.2101f);
                Pos_01.Add(new Vector3(-477.1502f, 182.252f, 82.03768f)); fHeading.Add(79.51382f);
                Pos_01.Add(new Vector3(-96.92668f, -342.335f, 40.3636f)); fHeading.Add(227.6679f);
                Pos_01.Add(new Vector3(96.90714f, -246.5079f, 45.79247f)); fHeading.Add(219.79f);
                Pos_01.Add(new Vector3(78.0203f, -240.652f, 46.40194f)); fHeading.Add(253.2796f);
                Pos_01.Add(new Vector3(333.0154f, -195.3859f, 52.50391f)); fHeading.Add(224.6233f);
                Pos_01.Add(new Vector3(955.6845f, -687.8796f, 55.86848f)); fHeading.Add(146.0258f);
                Pos_01.Add(new Vector3(912.7341f, -654.8762f, 56.21679f)); fHeading.Add(275.1885f);
                Pos_01.Add(new Vector3(903.1922f, -641.8429f, 56.5079f)); fHeading.Add(73.38454f);
                Pos_01.Add(new Vector3(873.175f, -613.0998f, 56.6581f)); fHeading.Add(357.458f);
                Pos_01.Add(new Vector3(839.5805f, -580.3686f, 55.49578f)); fHeading.Add(321.4151f);
                Pos_01.Add(new Vector3(825.0772f, -521.6014f, 54.95789f)); fHeading.Add(119.8508f);
                Pos_01.Add(new Vector3(896.8047f, -466.8496f, 57.32214f)); fHeading.Add(207.8782f);
                Pos_01.Add(new Vector3(917.1431f, -457.6846f, 59.27655f)); fHeading.Add(119.2411f);
                Pos_01.Add(new Vector3(932.3779f, -448.6634f, 59.52022f)); fHeading.Add(296.9828f);
                Pos_01.Add(new Vector3(954.8691f, -441.865f, 61.23558f)); fHeading.Add(47.42667f);
                Pos_01.Add(new Vector3(968.7847f, -432.1448f, 62.18409f)); fHeading.Add(211.815f);
                Pos_01.Add(new Vector3(1425.48f, 1154.443f, 113.2876f)); fHeading.Add(90.80857f);
            }           //Pool Peds   
            else if (iSelect == 18)
            {
                RandomWeatherTime();

                iSubSet = RsReturns.FindRandom(6, 1, 23);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(1138.573f, -785.1884f, 57.59872f)); fHeading.Add(167.1082f);
                    Pos_01.Add(new Vector3(544.0156f, -173.4207f, 54.48134f)); fHeading.Add(340.1063f);
                    Pos_01.Add(new Vector3(2515.484f, 4217.121f, 39.929f)); fHeading.Add(144.665f);
                    Pos_01.Add(new Vector3(-67.9494f, 6432.331f, 31.48058f)); fHeading.Add(326.9482f);
                    Pos_01.Add(new Vector3(255.0459f, 2582.047f, 45.13689f)); fHeading.Add(307.621f);
                    Pos_01.Add(new Vector3(1993.807f, 3793.491f, 32.18077f)); fHeading.Add(215.6984f);
                    Pos_01.Add(new Vector3(1688.451f, 3286.147f, 41.14651f)); fHeading.Add(66.41962f);
                    Pos_01.Add(new Vector3(2343.264f, 3114.95f, 48.2087f)); fHeading.Add(152.7309f);
                    Pos_01.Add(new Vector3(-82.67906f, -1325.488f, 29.27505f)); fHeading.Add(339.8256f);
                    Pos_01.Add(new Vector3(-22.95398f, -1674.278f, 29.49172f)); fHeading.Add(324.6906f);
                    Pos_01.Add(new Vector3(1181.487f, 2636.379f, 37.7949f)); fHeading.Add(147.4034f);
                    Pos_01.Add(new Vector3(107.9624f, 6629.401f, 31.78723f)); fHeading.Add(34.92216f);
                }       //"Autoshop Worker 2"); 
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-3022.146f, 39.75996f, 10.11778f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1982.751f, 3053.365f, 47.21507f)); fHeading.Add(237.2689f);
                }       //"Waiter") ; 
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(1736.674f, -1609.645f, 112.4697f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1561.137f, -2133.279f, 77.4785f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1459.511f, -1935.92f, 71.30696f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1455.132f, -1682.857f, 66.06307f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1193.554f, -1240.154f, 36.32576f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1122.821f, -1303.704f, 34.71646f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(994.2419f, -1555.895f, 30.75485f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(918.1321f, -1516.955f, 30.96606f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(903.4687f, -1590.887f, 30.22392f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(804.6454f, -1666.87f, 30.86449f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(746.9606f, -1862.089f, 29.29224f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1025.895f, -1686.251f, 33.57116f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(928.8152f, -1726.541f, 32.15963f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(897.4868f, -1864.518f, 30.61937f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1087.357f, -1970.058f, 31.01467f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(973.9832f, -1978.706f, 30.63801f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(890.3286f, -2001.457f, 30.61759f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(953.8917f, -2117.238f, 30.55156f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(879.512f, -2166.26f, 32.27139f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(840.3463f, -2292.076f, 30.51253f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(864.4549f, -2361.586f, 31.51551f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(943.5316f, -2169.565f, 30.5664f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1002.891f, -2161.235f, 30.55158f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1041.598f, -2170.343f, 31.50933f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1019.803f, -2381.706f, 30.49956f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1095.563f, -2227.028f, 31.304f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1091.22f, -2279.994f, 30.14508f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1083.314f, -2413.066f, 30.23936f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(923.9042f, -2533.111f, 28.30268f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1211.444f, -3103.413f, 6.027918f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(1195.812f, -3254.429f, 7.095187f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(755.6094f, -3181.837f, 7.405778f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(821.003f, -3196.436f, 5.900819f)); fHeading.Add(251.9171f);
                    Pos_01.Add(new Vector3(814.2813f, -2982.313f, 6.02089f)); fHeading.Add(251.9171f);
                }       //"Sweatshop Worker  
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(1727.791f, 6415.5f, 35.03722f)); fHeading.Add(236.6747f);
                    Pos_01.Add(new Vector3(1697.339f, 4923.185f, 42.06368f)); fHeading.Add(320.4615f);
                    Pos_01.Add(new Vector3(1959.632f, 3740.195f, 32.34374f)); fHeading.Add(296.0751f);
                    Pos_01.Add(new Vector3(2677.702f, 3279.555f, 55.23104f)); fHeading.Add(354.9082f);
                    Pos_01.Add(new Vector3(1392.897f, 3606.55f, 34.98093f)); fHeading.Add(181.8305f);
                    Pos_01.Add(new Vector3(549.17f, 2671.394f, 42.15946f)); fHeading.Add(80.96091f);
                    Pos_01.Add(new Vector3(1165.094f, 2711.289f, 38.15771f)); fHeading.Add(167.705f);
                    Pos_01.Add(new Vector3(2557.217f, 380.7556f, 108.6229f)); fHeading.Add(349.9854f);
                    Pos_01.Add(new Vector3(-3039.342f, 584.2296f, 7.908843f)); fHeading.Add(18.4436f);
                    Pos_01.Add(new Vector3(-2965.881f, 391.8284f, 15.04331f)); fHeading.Add(84.51514f);
                    Pos_01.Add(new Vector3(-1819.316f, 793.3266f, 138.0849f)); fHeading.Add(128.9414f);
                    Pos_01.Add(new Vector3(-1220.953f, -908.2629f, 12.32635f)); fHeading.Add(31.62823f);
                    Pos_01.Add(new Vector3(-706.053f, -914.5494f, 19.21514f)); fHeading.Add(82.03596f);
                    Pos_01.Add(new Vector3(-47.39658f, -1758.836f, 29.42102f)); fHeading.Add(28.16017f);
                    Pos_01.Add(new Vector3(24.2935f, -1347.371f, 29.48629f)); fHeading.Add(278.3273f);
                    Pos_01.Add(new Vector3(372.4779f, 326.4888f, 103.5664f)); fHeading.Add(251.1972f);
                    Pos_01.Add(new Vector3(1165.163f, -323.1492f, 69.20242f)); fHeading.Add(101.1147f);
                    Pos_01.Add(new Vector3(1133.975f, -983.3416f, 46.4158f)); fHeading.Add(285.5776f);
                }       //"Shopkeeper (Male)"); 
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-498.4334f, -336.1266f, 34.50177f)); fHeading.Add(260.0309f);
                    Pos_01.Add(new Vector3(-448.8101f, -340.8905f, 34.50174f)); fHeading.Add(71.48569f);
                    Pos_01.Add(new Vector3(-444.4344f, -360.8369f, 33.49535f)); fHeading.Add(202.3012f);
                    Pos_01.Add(new Vector3(-507.7543f, -350.8057f, 35.20736f)); fHeading.Add(175.4921f);
                    Pos_01.Add(new Vector3(299.0754f, -584.7549f, 43.26083f)); fHeading.Add(31.88034f);
                    Pos_01.Add(new Vector3(355.4822f, -596.1416f, 28.77366f)); fHeading.Add(243.7838f);
                    Pos_01.Add(new Vector3(343.2381f, -1398.023f, 32.50926f)); fHeading.Add(56.42395f);
                    Pos_01.Add(new Vector3(295.1708f, -1449.108f, 29.9666f)); fHeading.Add(342.1343f);
                    Pos_01.Add(new Vector3(391.0455f, -1432.821f, 29.43532f)); fHeading.Add(246.2128f);
                    Pos_01.Add(new Vector3(1102.689f, -1529.41f, 34.89371f)); fHeading.Add(191.0677f);
                    Pos_01.Add(new Vector3(1151.229f, -1529.005f, 35.18423f)); fHeading.Add(319.4206f);
                    Pos_01.Add(new Vector3(1816.119f, 3679.592f, 34.27674f)); fHeading.Add(46.59311f);
                    Pos_01.Add(new Vector3(1827.241f, 3692.945f, 34.22424f)); fHeading.Add(30.81271f);
                    Pos_01.Add(new Vector3(-246.6019f, 6331.854f, 32.42619f)); fHeading.Add(215.443f);
                }       //"Doctor"); 
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(74.20151f, -1028.342f, 29.47368f)); fHeading.Add(213.4145f);
                    Pos_01.Add(new Vector3(-775.8405f, -2235.184f, 5.935775f)); fHeading.Add(59.81636f);
                    Pos_01.Add(new Vector3(-821.5007f, -2103.311f, 8.960504f)); fHeading.Add(353.6512f);
                    Pos_01.Add(new Vector3(-70.87366f, 358.9036f, 112.4451f)); fHeading.Add(227.5854f);
                    Pos_01.Add(new Vector3(-33.33993f, 363.8051f, 113.908f)); fHeading.Add(136.6148f);
                    Pos_01.Add(new Vector3(18.42962f, 341.8936f, 115.3874f)); fHeading.Add(144.6268f);
                    Pos_01.Add(new Vector3(-1275.37f, 374.1922f, 77.58377f)); fHeading.Add(355.0824f);
                }       //"Maid
                else if (iSubSet == 7)
                {
                    Pos_01.Add(new Vector3(-117.671f, 6448.627f, 31.05948f)); fHeading.Add(134.7083f);
                    Pos_01.Add(new Vector3(2550.519f, 342.6139f, 108.0741f)); fHeading.Add(87.43266f);
                    Pos_01.Add(new Vector3(1064.405f, -1728.37f, 35.19252f)); fHeading.Add(200.746f);
                    Pos_01.Add(new Vector3(952.5815f, -2080.921f, 30.33508f)); fHeading.Add(83.92099f);
                    Pos_01.Add(new Vector3(163.1477f, -1608.789f, 28.95174f)); fHeading.Add(301.8476f);
                    Pos_01.Add(new Vector3(-1252.114f, -865.7639f, 11.98873f)); fHeading.Add(217.2558f);
                    Pos_01.Add(new Vector3(-2201.217f, -356.3726f, 12.75363f)); fHeading.Add(266.5727f);
                    Pos_01.Add(new Vector3(-1073.944f, -182.7193f, 37.54315f)); fHeading.Add(242.3141f);
                    Pos_01.Add(new Vector3(-742.4987f, -262.4792f, 36.55564f)); fHeading.Add(21.95997f);
                    Pos_01.Add(new Vector3(-302.9223f, -372.287f, 29.59321f)); fHeading.Add(233.3253f);
                    Pos_01.Add(new Vector3(96.73369f, -167.1032f, 54.54427f)); fHeading.Add(71.51151f);
                    Pos_01.Add(new Vector3(173.5536f, -846.8428f, 30.61277f)); fHeading.Add(339.7813f);
                    iEnterVeh = 9;

                    iAction = 1;
                }       //"Armoured Van Security 2"); 
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(2572.041f, 2718.056f, 42.16391f)); fHeading.Add(129.5934f);
                    Pos_01.Add(new Vector3(1219.512f, 2393.812f, 65.47562f)); fHeading.Add(172.7095f);
                    Pos_01.Add(new Vector3(818.2979f, 2367.369f, 51.38051f)); fHeading.Add(166.84f);
                    Pos_01.Add(new Vector3(2676.273f, 1611.337f, 23.99239f)); fHeading.Add(270.9893f);
                    Pos_01.Add(new Vector3(-129.5193f, -2175.594f, 9.808171f)); fHeading.Add(107.5226f);
                    Pos_01.Add(new Vector3(126.0953f, -2537.874f, 5.492153f)); fHeading.Add(90.73464f);
                    Pos_01.Add(new Vector3(641.3249f, -3010.168f, 5.719178f)); fHeading.Add(1.711147f);
                    Pos_01.Add(new Vector3(817.7762f, -3144.448f, 5.393185f)); fHeading.Add(184.152f);
                    Pos_01.Add(new Vector3(1894.648f, -1021.06f, 78.08004f)); fHeading.Add(168.9922f);
                    iEnterVeh = 1;

                    iAction = 1;
                }       //"Security Guard"); 
                else if (iSubSet == 9)
                {
                    Pos_01.Add(new Vector3(2137.336f, 2906.663f, 59.76971f)); fHeading.Add(55.80349f);
                    Pos_01.Add(new Vector3(2122.384f, 2921.195f, 50.91202f)); fHeading.Add(320.7472f);
                    Pos_01.Add(new Vector3(2078.61f, 2945.86f, 56.4167f)); fHeading.Add(181.6763f);
                    Pos_01.Add(new Vector3(2044.698f, 2944.561f, 60.02338f)); fHeading.Add(282.4404f);
                    Pos_01.Add(new Vector3(2008.205f, 2932.849f, 59.47688f)); fHeading.Add(259.2144f);
                    Pos_01.Add(new Vector3(1965.265f, 2918.207f, 56.1685f)); fHeading.Add(159.0523f);
                }        //"Scientist");  
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(2751.409f, 1467.832f, 49.05055f)); fHeading.Add(70.61932f);
                    Pos_01.Add(new Vector3(2794.029f, 1673.659f, 20.78217f)); fHeading.Add(172.1612f);
                    Pos_01.Add(new Vector3(2733.363f, 1581.026f, 66.53803f)); fHeading.Add(3.543856f);
                    Pos_01.Add(new Vector3(2739.592f, 1544.221f, 42.89051f)); fHeading.Add(237.7711f);
                    Pos_01.Add(new Vector3(2748.854f, 1505.891f, 38.28401f)); fHeading.Add(152.154f);
                    Pos_01.Add(new Vector3(2664.208f, 1477.163f, 35.2615f)); fHeading.Add(34.45109f);
                    Pos_01.Add(new Vector3(2702.427f, 1483.406f, 44.4654f)); fHeading.Add(81.48576f);
                    Pos_01.Add(new Vector3(2716.197f, 1500.537f, 42.24483f)); fHeading.Add(179.7581f);
                    Pos_01.Add(new Vector3(2772.207f, 1518.493f, 30.77918f)); fHeading.Add(257.5858f);
                    Pos_01.Add(new Vector3(2801.599f, 1454.122f, 34.34266f)); fHeading.Add(111.4636f);
                }       //"Chemical Plant Worker");  
                else if (iSubSet == 11)
                {
                    if (RsReturns.FindRandom(24, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(2368.954f, 2191.936f, 142.1283f)); fHeading.Add(177.7558f);
                        Pos_01.Add(new Vector3(941.1194f, 2420.352f, 80.66275f)); fHeading.Add(354.4607f);
                        Pos_01.Add(new Vector3(1063.921f, 2295.801f, 79.65724f)); fHeading.Add(54.34263f);
                        Pos_01.Add(new Vector3(1132.265f, 2170.632f, 87.40754f)); fHeading.Add(148.2799f);
                        Pos_01.Add(new Vector3(-119.0797f, -977.1749f, 304.2491f)); fHeading.Add(195.5221f);
                        Pos_01.Add(new Vector3(-130.3379f, -995.1433f, 73.26834f)); fHeading.Add(6.456776f);
                        Pos_01.Add(new Vector3(-207.2522f, -1116.536f, 65.29741f)); fHeading.Add(127.4257f);
                        Pos_01.Add(new Vector3(-471.007f, -1082.965f, 69.37054f)); fHeading.Add(2.687505f);
                        Pos_01.Add(new Vector3(-461.0444f, -975.177f, 77.44084f)); fHeading.Add(24.04421f);
                        Pos_01.Add(new Vector3(-662.969f, 216.808f, 156.3536f)); fHeading.Add(277.3127f);
                        Pos_01.Add(new Vector3(46.32523f, -459.1702f, 107.9676f)); fHeading.Add(47.79955f);
                        Pos_01.Add(new Vector3(140.8991f, -344.787f, 102.6311f)); fHeading.Add(158.7348f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-450.5587f, -1036.252f, 23.09341f)); fHeading.Add(39.48218f);
                        Pos_01.Add(new Vector3(-490.6296f, -942.8484f, 23.51029f)); fHeading.Add(147.3915f);
                        Pos_01.Add(new Vector3(-149.3207f, -959.513f, 20.82236f)); fHeading.Add(160.9155f);
                        Pos_01.Add(new Vector3(-132.5916f, -1098.141f, 21.23154f)); fHeading.Add(132.2186f);
                        Pos_01.Add(new Vector3(98.88792f, -450.8947f, 41.56817f)); fHeading.Add(342.08f);
                        Pos_01.Add(new Vector3(104.5644f, -349.3134f, 41.93143f)); fHeading.Add(94.52675f);
                        iEnterVeh = 9;

                        iAction = 1;
                    }
                }       //"construction Worker 2"); 
                else if (iSubSet == 12)
                {
                    if (RsReturns.FindRandom(25, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(944.6815f, -2933.804f, 49.12353f)); fHeading.Add(289.2962f);
                        Pos_01.Add(new Vector3(1011.372f, -2896.42f, 39.15219f)); fHeading.Add(172.0232f);
                        Pos_01.Add(new Vector3(970.7809f, -2933.85f, 49.11639f)); fHeading.Add(91.70227f);
                        Pos_01.Add(new Vector3(1157.055f, -2860.837f, 43.28324f)); fHeading.Add(1.263969f);
                        Pos_01.Add(new Vector3(1227.453f, -2903.619f, 13.32729f)); fHeading.Add(58.2732f);
                        Pos_01.Add(new Vector3(1289.939f, -3100.061f, 26.75886f)); fHeading.Add(181.0756f);
                        Pos_01.Add(new Vector3(1296.828f, -3301.1f, 24.38335f)); fHeading.Add(187.5255f);
                        Pos_01.Add(new Vector3(1137.943f, -3191.236f, 24.14786f)); fHeading.Add(185.3562f);
                        Pos_01.Add(new Vector3(905.3866f, -3279.862f, 24.22781f)); fHeading.Add(173.9265f);
                        Pos_01.Add(new Vector3(839.6215f, -3086.641f, 23.10469f)); fHeading.Add(196.4139f);
                        Pos_01.Add(new Vector3(951.5082f, -2964.539f, 23.07471f)); fHeading.Add(54.88553f);
                        Pos_01.Add(new Vector3(1056.643f, -3033.763f, 23.08432f)); fHeading.Add(280.4692f);
                        Pos_01.Add(new Vector3(1170.038f, -2963.04f, 19.98134f)); fHeading.Add(1.24316f);
                        Pos_01.Add(new Vector3(1167.413f, -3020.839f, 24.18315f)); fHeading.Add(348.2981f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-326.8799f, -2617.591f, 5.603117f)); fHeading.Add(135.2283f);
                        Pos_01.Add(new Vector3(-505.1059f, -2765.766f, 5.612922f)); fHeading.Add(314.6254f);
                        Pos_01.Add(new Vector3(-301.3838f, -2419.142f, 5.613175f)); fHeading.Add(146.1276f);
                        Pos_01.Add(new Vector3(-117.8903f, -2660.294f, 5.618917f)); fHeading.Add(358.9177f);
                        Pos_01.Add(new Vector3(266.0363f, -2996.771f, 5.346468f)); fHeading.Add(171.727f);
                        Pos_01.Add(new Vector3(517.1625f, -2951.327f, 5.654205f)); fHeading.Add(268.6839f);
                        Pos_01.Add(new Vector3(924.679f, -3009.876f, 5.503459f)); fHeading.Add(270.0103f);
                        Pos_01.Add(new Vector3(1031.972f, -2914.75f, 5.50889f)); fHeading.Add(79.1702f);
                        Pos_01.Add(new Vector3(1261.785f, -3094.253f, 5.51305f)); fHeading.Add(34.06389f);
                        Pos_01.Add(new Vector3(1044.572f, -3237.142f, 5.503559f)); fHeading.Add(91.10924f);
                        iEnterVeh = 9;

                        iAction = 1;
                    }
                }       //"Dock Worker");  
                else if (iSubSet == 13)
                {
                    Pos_01.Add(new Vector3(-1260.416f, -2465.789f, 13.53846f)); fHeading.Add(150.3708f);
                    Pos_01.Add(new Vector3(-1136.307f, -2565.843f, 13.54877f)); fHeading.Add(239.837f);
                    Pos_01.Add(new Vector3(-1247.719f, -2759.173f, 13.5597f)); fHeading.Add(150.0197f);
                    Pos_01.Add(new Vector3(-1774.23f, -2806.793f, 13.54927f)); fHeading.Add(153.7328f);
                    Pos_01.Add(new Vector3(-1647.934f, -3128.432f, 13.60499f)); fHeading.Add(285.4133f);
                    Pos_01.Add(new Vector3(-1262.489f, -3376.311f, 13.55233f)); fHeading.Add(330.3223f);
                    Pos_01.Add(new Vector3(-965.5756f, -3007.905f, 13.5535f)); fHeading.Add(28.93888f);
                    iEnterVeh = 9;

                    iAction = 1;
                    bRequestPB = true;
                }       //Airport
                else if (iSubSet == 14)
                {
                    Pos_01.Add(new Vector3(-304.5138f, -1544.802f, 25.85103f)); fHeading.Add(154.0407f);
                    iAction = 1;
                    iEnterVeh = 10;
                }       //"Garbage Worker");  
                else if (iSubSet == 15)
                {
                    Pos_01.Add(new Vector3(833.5146f, -280.2225f, 66.37661f)); fHeading.Add(239.6148f);
                    Pos_01.Add(new Vector3(1075.906f, -684.5606f, 57.71888f)); fHeading.Add(30.70767f);
                    Pos_01.Add(new Vector3(-916.4821f, -111.1297f, 37.96105f)); fHeading.Add(295.2327f);
                    Pos_01.Add(new Vector3(-114.3289f, -394.8227f, 35.97801f)); fHeading.Add(252.818f);
                    Pos_01.Add(new Vector3(-1670.235f, -600.6372f, 33.82233f)); fHeading.Add(66.71965f);
                    Pos_01.Add(new Vector3(-809.2332f, -915.7718f, 18.17719f)); fHeading.Add(346.4547f);
                    Pos_01.Add(new Vector3(-900.3068f, -860.772f, 16.3537f)); fHeading.Add(214.3627f);
                    Pos_01.Add(new Vector3(-1714.627f, -258.9235f, 52.60183f)); fHeading.Add(141.2126f);
                    iAction = 5;
                }       //"Latino Handyman Male"); 
                else if (iSubSet == 16)
                {
                    Pos_01.Add(new Vector3(117.6408f, -1729.686f, 30.11062f)); fHeading.Add(145.3675f);
                    Pos_01.Add(new Vector3(-207.5786f, -1017.771f, 30.13827f)); fHeading.Add(137.811f);
                    Pos_01.Add(new Vector3(-500.6882f, -660.5969f, 20.03399f)); fHeading.Add(176.1281f);
                    Pos_01.Add(new Vector3(-1340.413f, -459.3785f, 23.27035f)); fHeading.Add(118.5435f);
                    Pos_01.Add(new Vector3(-810.3533f, -148.9955f, 28.17534f)); fHeading.Add(18.19424f);
                    Pos_01.Add(new Vector3(-306.8699f, -329.439f, 18.28813f)); fHeading.Add(276.2242f);
                    Pos_01.Add(new Vector3(247.4429f, -1204.116f, 38.92488f)); fHeading.Add(293.6903f);
                    Pos_01.Add(new Vector3(-533.9517f, -1267.302f, 26.9016f)); fHeading.Add(140.6523f);
                    Pos_01.Add(new Vector3(-871.7253f, -2321.781f, -3.507766f)); fHeading.Add(55.49453f);
                    Pos_01.Add(new Vector3(-1093.533f, -2709.069f, 0.8148932f)); fHeading.Add(232.3231f);
                }       //"LS Metro Worker Male");  
                else if (iSubSet == 17)
                {
                    Pos_01.Add(new Vector3(772.4866f, -941.0552f, 25.69374f)); fHeading.Add(174.2538f);
                    Pos_01.Add(new Vector3(784.7866f, -778.5135f, 26.37265f)); fHeading.Add(359.7194f);
                    Pos_01.Add(new Vector3(805.5536f, -1353.864f, 26.34939f)); fHeading.Add(1.794775f);
                    Pos_01.Add(new Vector3(438.6497f, -2028.266f, 23.40673f)); fHeading.Add(222.4093f);
                    Pos_01.Add(new Vector3(-252.9165f, -881.4698f, 30.71332f)); fHeading.Add(250.5484f);
                    Pos_01.Add(new Vector3(-562.1918f, -844.0425f, 27.27311f)); fHeading.Add(268.5222f);
                    Pos_01.Add(new Vector3(-1166.271f, -401.646f, 35.44949f)); fHeading.Add(98.17386f);
                    Pos_01.Add(new Vector3(-1483.472f, -634.3616f, 30.36706f)); fHeading.Add(305.0129f);
                    Pos_01.Add(new Vector3(-1407.018f, -570.2193f, 30.32949f)); fHeading.Add(118.4672f);
                    Pos_01.Add(new Vector3(-1523.434f, -465.9171f, 35.33706f)); fHeading.Add(121.1337f);
                    Pos_01.Add(new Vector3(-741.6723f, -753.1192f, 26.65259f)); fHeading.Add(1.035129f);
                    Pos_01.Add(new Vector3(-709.4644f, -828.9621f, 23.4892f)); fHeading.Add(87.2354f);
                    Pos_01.Add(new Vector3(-693.6379f, -667.7115f, 30.77847f)); fHeading.Add(267.3748f);
                    Pos_01.Add(new Vector3(-507.1399f, -667.337f, 33.0463f)); fHeading.Add(269.1283f);
                    Pos_01.Add(new Vector3(118.4946f, -786.554f, 31.31796f)); fHeading.Add(68.02338f);
                    Pos_01.Add(new Vector3(459.9696f, -634.295f, 28.49378f)); fHeading.Add(32.34509f);
                    iEnterVeh = 3;
                    iAction = 1;
                }       //"Transport Worker Male");  
                else if (iSubSet == 18)
                {
                    Pos_01.Add(new Vector3(139.4768f, -3103.723f, 5.89631f)); fHeading.Add(353.8674f);
                }       //"Pest Control");  
                else if (iSubSet == 19)
                {
                    if (RsReturns.FindRandom(26, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(126.8316f, 217.908f, 107.2581f)); fHeading.Add(250.0984f);
                        Pos_01.Add(new Vector3(-63.64765f, 38.78681f, 72.05331f)); fHeading.Add(246.6971f);
                        Pos_01.Add(new Vector3(-306.1648f, 253.3288f, 87.87576f)); fHeading.Add(286.7962f);
                        Pos_01.Add(new Vector3(-433.5657f, 5.962925f, 46.09057f)); fHeading.Add(86.90429f);
                        Pos_01.Add(new Vector3(-630.7167f, 752.2339f, 178.5925f)); fHeading.Add(66.96705f);
                        Pos_01.Add(new Vector3(-1191.528f, -1263.148f, 6.772604f)); fHeading.Add(19.49872f);
                        Pos_01.Add(new Vector3(-996.5602f, -1131.017f, 2.042427f)); fHeading.Add(31.10395f);
                        iEnterVeh = 1;

                        iAction = 1;
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(85.46738f, 107.2592f, 79.16206f)); fHeading.Add(28.6738f);
                    }
                }       //"Postal Worker Male 2");  
                else if (iSubSet == 20)
                {
                    if (RsReturns.FindRandom(27, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(775.7664f, -983.2467f, 26.1865f)); fHeading.Add(179.6391f);
                        Pos_01.Add(new Vector3(970.2875f, -1458.307f, 31.24547f)); fHeading.Add(357.9949f);
                        Pos_01.Add(new Vector3(908.9388f, -1758.108f, 30.55537f)); fHeading.Add(82.37654f);
                        Pos_01.Add(new Vector3(708.7218f, -2064.523f, 29.24054f)); fHeading.Add(266.0231f);
                        Pos_01.Add(new Vector3(899.3294f, -2427.047f, 28.41091f)); fHeading.Add(170.9303f);
                        Pos_01.Add(new Vector3(626.4791f, -2650.233f, 6.002013f)); fHeading.Add(25.25125f);
                        Pos_01.Add(new Vector3(171.0083f, -2567.712f, 5.877536f)); fHeading.Add(134.8465f);
                        Pos_01.Add(new Vector3(6.724895f, -2075.361f, 10.17716f)); fHeading.Add(357.7553f);
                        iEnterVeh = 1;

                        iAction = 1;
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-421.5688f, 6136.129f, 31.87731f)); fHeading.Add(151.091f);
                        Pos_01.Add(new Vector3(1194.111f, -3249.756f, 7.095187f)); fHeading.Add(24.04957f);
                        Pos_01.Add(new Vector3(-470.9116f, -2826.893f, 7.295931f)); fHeading.Add(111.9151f);
                    }
                }       //"UPS Driver 2");
                else if (iSubSet == 21)
                {
                    Pos_01.Add(new Vector3(-1692.355f, -1136.184f, 13.1523f)); fHeading.Add(7.620972f);
                    Pos_01.Add(new Vector3(-1682.627f, -1124.328f, 13.15217f)); fHeading.Add(156.3842f);
                    Pos_01.Add(new Vector3(-1638.467f, -1083.328f, 13.07891f)); fHeading.Add(250.2687f);
                    Pos_01.Add(new Vector3(-1630.095f, -1075.994f, 13.06109f)); fHeading.Add(170.5576f);
                    Pos_01.Add(new Vector3(-1693.571f, -1072.634f, 13.01736f)); fHeading.Add(40.26046f);
                    Pos_01.Add(new Vector3(-1720.081f, -1103.823f, 13.01784f)); fHeading.Add(88.03056f);
                    Pos_01.Add(new Vector3(-1772.086f, -1160.577f, 13.01805f)); fHeading.Add(113.3456f);
                    Pos_01.Add(new Vector3(-1784.682f, -1175.788f, 13.01775f)); fHeading.Add(52.88898f);
                    Pos_01.Add(new Vector3(-1835.216f, -1233.972f, 13.01727f)); fHeading.Add(10.32578f);
                    Pos_01.Add(new Vector3(-1856.75f, -1224.386f, 13.01728f)); fHeading.Add(322.1722f);
                }       //"Street Vendor Young");  
                else if (iSubSet == 22)
                {
                    Pos_01.Add(new Vector3(-663.5873f, -183.1233f, 37.67239f)); fHeading.Add(130.6762f);
                }       //"Valet");  
                else
                {
                    Pos_01.Add(new Vector3(-74.24763f, -837.0442f, 318.9297f)); fHeading.Add(167.2113f);
                    Pos_01.Add(new Vector3(-148.4851f, -611.0936f, 204.009f)); fHeading.Add(36.52973f);
                    Pos_01.Add(new Vector3(-100.5659f, -548.9984f, 173.528f)); fHeading.Add(326.2725f);
                    Pos_01.Add(new Vector3(162.6209f, -730.3214f, 255.4475f)); fHeading.Add(158.5101f);
                    Pos_01.Add(new Vector3(129.6409f, -720.5817f, 263.644f)); fHeading.Add(353.4834f);
                    Pos_01.Add(new Vector3(102.8595f, -643.2682f, 263.6401f)); fHeading.Add(261.434f);
                }       //"Window Cleaner");  
            }           //Workers  
            else if (iSelect == 19)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                Pos_01.Add(new Vector3(212.627f, 3630.045f, 29.9478f)); fHeading.Add(165.2639f);
                Pos_01.Add(new Vector3(3424.472f, 5193.411f, 0.6613104f)); fHeading.Add(275.3657f);
                Pos_01.Add(new Vector3(3067.812f, 638.7896f, 0.3254618f)); fHeading.Add(354.6844f);
                Pos_01.Add(new Vector3(628.3226f, -2122.594f, -0.06220001f)); fHeading.Add(174.2746f);
                iAction = 1;

                iEnterVeh = 9;
            }           //jet ski Male                  
            else if (iSelect == 20)
            {
                World.Weather = Weather.ExtraSunny;

                World.CurrentDayTime = TimeSpan.FromHours(12);

                iSubSet = RsReturns.FindRandom(7, 1, 4);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-1573.766f, 3090.736f, 30.70401f)); fHeading.Add(7.923703f);
                    Pos_01.Add(new Vector3(-1612.333f, 3194.164f, 29.70836f)); fHeading.Add(24.25381f);
                    Pos_01.Add(new Vector3(-1627.943f, 3187.001f, 29.59254f)); fHeading.Add(169.4351f);
                    Pos_01.Add(new Vector3(-1596.471f, 3146.43f, 29.75003f)); fHeading.Add(216.409f);
                    Pos_01.Add(new Vector3(-1578.321f, 2938.288f, 32.46555f)); fHeading.Add(193.4308f);
                    Pos_01.Add(new Vector3(-1447.88f, 2741.831f, 11.2647f)); fHeading.Add(197.5895f);
                    Pos_01.Add(new Vector3(-1501.37f, 2684.001f, 3.191243f)); fHeading.Add(88.94603f);
                    Pos_01.Add(new Vector3(-1627.528f, 2710.553f, 5.176663f)); fHeading.Add(103.4545f);
                    Pos_01.Add(new Vector3(-1725.799f, 2748.991f, 5.00828f)); fHeading.Add(104.025f);
                    Pos_01.Add(new Vector3(-2160.634f, 2730.127f, 3.995766f)); fHeading.Add(50.44249f);
                    Pos_01.Add(new Vector3(-2584.121f, 2877.74f, 3.796169f)); fHeading.Add(68.0451f);
                    Pos_01.Add(new Vector3(-2884.217f, 3187.55f, 10.46736f)); fHeading.Add(41.10115f);
                    Pos_01.Add(new Vector3(-2899.272f, 3182.975f, 10.81549f)); fHeading.Add(226.0815f);
                    Pos_01.Add(new Vector3(-2812.017f, 3118.884f, 8.932123f)); fHeading.Add(233.299f);
                    Pos_01.Add(new Vector3(-2657.327f, 2986.998f, 8.475378f)); fHeading.Add(205.1365f);
                    Pos_01.Add(new Vector3(-2557.48f, 2865.591f, 2.521069f)); fHeading.Add(240.187f);
                    Pos_01.Add(new Vector3(-2356.98f, 2841.752f, 3.348562f)); fHeading.Add(267.1766f);
                    Pos_01.Add(new Vector3(-2166.792f, 2736.821f, 4.362955f)); fHeading.Add(223.5836f);
                    Pos_01.Add(new Vector3(-1844.768f, 2690.219f, 3.537222f)); fHeading.Add(271.2152f);
                    Pos_01.Add(new Vector3(-1555.259f, 2712.102f, 4.116089f)); fHeading.Add(236.3789f);
                    Pos_01.Add(new Vector3(-1459.733f, 2684.367f, 3.303248f)); fHeading.Add(274.8381f);
                    Pos_01.Add(new Vector3(-1438.947f, 2728.815f, 9.611741f)); fHeading.Add(20.52527f);
                    Pos_01.Add(new Vector3(-1482.055f, 2850.693f, 26.6391f)); fHeading.Add(34.27589f);
                    Pos_01.Add(new Vector3(-1581.356f, 3036.075f, 32.53102f)); fHeading.Add(353.6025f);
                }
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-462.391f, 3022.21f, 28.40036f)); fHeading.Add(313.114f);
                    Pos_01.Add(new Vector3(-272.8297f, 3095.584f, 34.38621f)); fHeading.Add(302.639f);
                    Pos_01.Add(new Vector3(12.49784f, 3269.169f, 40.96146f)); fHeading.Add(335.1027f);
                    Pos_01.Add(new Vector3(107.1125f, 3397.141f, 36.66495f)); fHeading.Add(8.812644f);
                    Pos_01.Add(new Vector3(134.8132f, 3415.844f, 40.02129f)); fHeading.Add(243.3611f);
                    Pos_01.Add(new Vector3(227.9139f, 3344.033f, 39.13525f)); fHeading.Add(194.6835f);
                    Pos_01.Add(new Vector3(221.3962f, 3280.408f, 40.68347f)); fHeading.Add(169.897f);
                    Pos_01.Add(new Vector3(181.2409f, 3240.672f, 41.41757f)); fHeading.Add(141.7103f);
                    Pos_01.Add(new Vector3(26.04806f, 3041.013f, 40.35786f)); fHeading.Add(126.7756f);
                    Pos_01.Add(new Vector3(-172.475f, 2963.227f, 30.90143f)); fHeading.Add(101.0182f);
                    Pos_01.Add(new Vector3(-336.0371f, 2956.438f, 26.28792f)); fHeading.Add(97.28018f);
                    Pos_01.Add(new Vector3(-463.7291f, 2973.831f, 25.10873f)); fHeading.Add(73.1357f);
                }
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-246.7437f, 4227.788f, 44.22093f)); fHeading.Add(88.70379f);
                    Pos_01.Add(new Vector3(-442.6657f, 4310.995f, 60.11999f)); fHeading.Add(47.96756f);
                    Pos_01.Add(new Vector3(-542.5441f, 4358.369f, 64.7117f)); fHeading.Add(101.0533f);
                    Pos_01.Add(new Vector3(-734.0334f, 4413.731f, 20.70769f)); fHeading.Add(77.96465f);
                    Pos_01.Add(new Vector3(-882.9547f, 4387.652f, 19.15052f)); fHeading.Add(122.8844f);
                    Pos_01.Add(new Vector3(-1094.925f, 4381.365f, 12.11559f)); fHeading.Add(85.9125f);
                    Pos_01.Add(new Vector3(-1274.828f, 4355.382f, 6.493629f)); fHeading.Add(100.2827f);
                    Pos_01.Add(new Vector3(-1362.314f, 4303.132f, 2.091456f)); fHeading.Add(110.5179f);
                    Pos_01.Add(new Vector3(-1624.499f, 4405.334f, 1.869654f)); fHeading.Add(28.06654f);
                    Pos_01.Add(new Vector3(-1853.843f, 4502.354f, 21.63335f)); fHeading.Add(109.9912f);
                    Pos_01.Add(new Vector3(-1912.896f, 4482.269f, 28.62659f)); fHeading.Add(93.04143f);
                    Pos_01.Add(new Vector3(-1893.607f, 4428.335f, 44.1927f)); fHeading.Add(242.4966f);
                    Pos_01.Add(new Vector3(-1614.563f, 4200.422f, 82.80534f)); fHeading.Add(265.1578f);
                    Pos_01.Add(new Vector3(-1420.428f, 4199.886f, 47.63276f)); fHeading.Add(229.7081f);
                    Pos_01.Add(new Vector3(-1352.643f, 4125.354f, 62.40678f)); fHeading.Add(257.9967f);
                    Pos_01.Add(new Vector3(-1108.262f, 4283.507f, 91.09012f)); fHeading.Add(242.1806f);
                    Pos_01.Add(new Vector3(-976.4009f, 4143.866f, 127.7988f)); fHeading.Add(284.5882f);
                    Pos_01.Add(new Vector3(-659.5837f, 4012.206f, 127.7423f)); fHeading.Add(265.3335f);
                    Pos_01.Add(new Vector3(-345.1731f, 4009.185f, 46.76369f)); fHeading.Add(289.7841f);
                    Pos_01.Add(new Vector3(-264.4113f, 3932.506f, 41.40203f)); fHeading.Add(220.5557f);
                    Pos_01.Add(new Vector3(-219.4442f, 3958.519f, 36.85928f)); fHeading.Add(346.6211f);
                    Pos_01.Add(new Vector3(-218.2338f, 4161.347f, 41.95908f)); fHeading.Add(342.4479f);
                }
                else
                {
                    Pos_01.Add(new Vector3(2737.655f, 2743.196f, 41.08186f)); fHeading.Add(300.0414f);
                    Pos_01.Add(new Vector3(2880.482f, 2745.462f, 68.57726f)); fHeading.Add(229.783f);
                    Pos_01.Add(new Vector3(2994.119f, 2681.638f, 74.66668f)); fHeading.Add(313.514f);
                    Pos_01.Add(new Vector3(3068.115f, 2773.374f, 76.51849f)); fHeading.Add(6.837749f);
                    Pos_01.Add(new Vector3(3055.643f, 2876.528f, 85.3677f)); fHeading.Add(304.5084f);
                    Pos_01.Add(new Vector3(3073.354f, 2980.721f, 91.20333f)); fHeading.Add(13.69699f);
                    Pos_01.Add(new Vector3(2987.849f, 2990.086f, 86.409f)); fHeading.Add(158.836f);
                    Pos_01.Add(new Vector3(2872.208f, 2913.032f, 77.55762f)); fHeading.Add(42.19868f);
                    Pos_01.Add(new Vector3(2708.277f, 2962.484f, 36.27277f)); fHeading.Add(98.92899f);
                    Pos_01.Add(new Vector3(2601.988f, 2862.675f, 35.80437f)); fHeading.Add(178.1778f);
                    Pos_01.Add(new Vector3(2697.39f, 2847.054f, 38.85565f)); fHeading.Add(268.2838f);
                    Pos_01.Add(new Vector3(2742.297f, 2911.1f, 35.81622f)); fHeading.Add(57.11665f);
                    Pos_01.Add(new Vector3(2627.528f, 2909.389f, 36.02975f)); fHeading.Add(317.5483f);
                    Pos_01.Add(new Vector3(2718.012f, 2945.823f, 35.64244f)); fHeading.Add(261.9158f);
                    Pos_01.Add(new Vector3(2808.185f, 2827.385f, 41.43419f)); fHeading.Add(160.7458f);
                    Pos_01.Add(new Vector3(2786.199f, 2792.07f, 39.8413f)); fHeading.Add(126.6713f);
                    Pos_01.Add(new Vector3(2744.489f, 2747.907f, 41.75266f)); fHeading.Add(298.9925f);

                }

                iAction = 8;

                iEnterVeh = 1;
            }           //Bike/ATV Male
            else if (iSelect == 21)
            {
                RandomWeatherTime();

                iSubSet = RsReturns.FindRandom(8, 1, 11);

                if (iSubSet == 1)
                {
                    World.Weather = Weather.ExtraSunny;
                    World.CurrentDayTime = TimeSpan.FromHours(12);

                    if (RsReturns.FindRandom(28, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(-2006.46f, -557.0941f, 12.88623f)); fHeading.Add(131.999f);
                        Pos_01.Add(new Vector3(-1904.047f, -710.8903f, 8.832588f)); fHeading.Add(142.1092f);
                        Pos_01.Add(new Vector3(-1796.982f, -858.4172f, 8.988594f)); fHeading.Add(109.4991f);
                        Pos_01.Add(new Vector3(-1560.853f, -1155.617f, 3.91121f)); fHeading.Add(110.4863f);
                        Pos_01.Add(new Vector3(-1518.387f, -1273.357f, 3.459239f)); fHeading.Add(68.08511f);
                        Pos_01.Add(new Vector3(-1467.155f, -1387.716f, 4.138116f)); fHeading.Add(93.4029f);
                        Pos_01.Add(new Vector3(-1426.954f, -1510.442f, 3.710497f)); fHeading.Add(192.444f);
                        Pos_01.Add(new Vector3(-1373.184f, -1623.852f, 3.725399f)); fHeading.Add(38.85428f);
                        Pos_01.Add(new Vector3(-1290.262f, -1752.792f, 3.713808f)); fHeading.Add(113.0197f);
                        Pos_01.Add(new Vector3(-1203.31f, -1785.278f, 15.62175f)); fHeading.Add(56.26437f);
                        Pos_01.Add(new Vector3(-1496.039f, -1031.543f, 10.52018f)); fHeading.Add(130.5046f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1175.706f, -1774.746f, 3.363378f)); fHeading.Add(304.6927f);
                        Pos_01.Add(new Vector3(-1287.01f, -1759.955f, 1.672546f)); fHeading.Add(295.8521f);
                        Pos_01.Add(new Vector3(-1367.334f, -1629.258f, 1.649302f)); fHeading.Add(120.9917f);
                        Pos_01.Add(new Vector3(-1428.135f, -1518.865f, 1.663456f)); fHeading.Add(296.1766f);
                        Pos_01.Add(new Vector3(-1457.268f, -1386.405f, 2.275759f)); fHeading.Add(199.2531f);
                        Pos_01.Add(new Vector3(-1524.885f, -1273.191f, 1.530929f)); fHeading.Add(278.7048f);
                        Pos_01.Add(new Vector3(-1553.199f, -1151.16f, 1.866233f)); fHeading.Add(223.5885f);
                        Pos_01.Add(new Vector3(-1805.487f, -861.1481f, 6.189745f)); fHeading.Add(202.9933f);
                        Pos_01.Add(new Vector3(-1893.655f, -714.954f, 6.738693f)); fHeading.Add(140.5407f);
                        Pos_01.Add(new Vector3(-1998.289f, -552.5966f, 11.23209f)); fHeading.Add(234.004f);
                        iEnterVeh = 9;
                        iAction = 1;
                    }
                }            //"Baywatch 
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(1900.911f, 4210.698f, 31.12156f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(456.3666f, 3941.582f, 29.83598f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(-274.0639f, -3168.564f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(1919.113f, -3195.016f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3095.027f, -2285.647f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3324.883f, -928.3412f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3462.442f, 669.5615f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3461.571f, 1551.177f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4046.482f, 2779.351f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4252.938f, 3943.124f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(4028.5f, 5284.229f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(3197.774f, 6780.198f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(2577.655f, 6975.242f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(1584.373f, 7135.975f, 1.20f)); fHeading.Add(234.004f);
                    Pos_01.Add(new Vector3(752.0983f, 7195.581f, 1.20f)); fHeading.Add(234.004f);
                    iEnterVeh = 2;
                    iAction = 1;
                }       //"US Coastguard
                else if (iSubSet == 3)
                {
                    if (RsReturns.FindRandom(29, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(358.6237f, -1583.362f, 29.29193f)); fHeading.Add(327.5265f);
                        Pos_01.Add(new Vector3(824.7567f, -1288.554f, 28.24066f)); fHeading.Add(87.50066f);
                        Pos_01.Add(new Vector3(-1059.216f, -825.3883f, 19.21697f)); fHeading.Add(303.7586f);
                        Pos_01.Add(new Vector3(427.7636f, -978.7175f, 30.71008f)); fHeading.Add(88.30321f);
                        Pos_01.Add(new Vector3(221.1342f, -890.8514f, 30.692f)); fHeading.Add(147.9018f);
                        Pos_01.Add(new Vector3(641.4783f, -4.073126f, 82.7884f)); fHeading.Add(226.4207f);
                        Pos_01.Add(new Vector3(104.8719f, -193.8214f, 54.75231f)); fHeading.Add(247.8596f);
                        Pos_01.Add(new Vector3(-566.6926f, -132.4973f, 37.94614f)); fHeading.Add(199.6771f);
                        Pos_01.Add(new Vector3(-695.9104f, -821.5554f, 23.85311f)); fHeading.Add(269.5868f);
                        Pos_01.Add(new Vector3(-1311.33f, -1521.909f, 4.41676f)); fHeading.Add(157.7447f);
                        Pos_01.Add(new Vector3(-1361.757f, -1126.886f, 4.270231f)); fHeading.Add(184.5965f);
                        Pos_01.Add(new Vector3(-2022.764f, -497.6946f, 11.63673f)); fHeading.Add(229.2497f);
                        Pos_01.Add(new Vector3(1855.582f, 3682.823f, 34.26752f)); fHeading.Add(204.1647f);
                        Pos_01.Add(new Vector3(-256.3628f, 6293.579f, 31.45917f)); fHeading.Add(134.4056f);
                        Pos_01.Add(new Vector3(-442.6062f, 6016.88f, 31.71221f)); fHeading.Add(313.0559f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(885.5582f, -2615.697f, 50.64429f)); fHeading.Add(278.7308f);
                        Pos_01.Add(new Vector3(203.3962f, -2666.317f, 17.77028f)); fHeading.Add(269.1859f);
                        Pos_01.Add(new Vector3(-373.5676f, -2359.221f, 62.95405f)); fHeading.Add(234.2403f);
                        Pos_01.Add(new Vector3(-416.3635f, -1002.121f, 36.88079f)); fHeading.Add(180.3557f);
                        Pos_01.Add(new Vector3(-142.9952f, -489.4464f, 28.90267f)); fHeading.Add(90.18279f);
                        Pos_01.Add(new Vector3(263.6426f, -504.648f, 33.6673f)); fHeading.Add(89.44656f);
                        Pos_01.Add(new Vector3(658.7974f, -572.0912f, 35.72264f)); fHeading.Add(62.07106f);
                        Pos_01.Add(new Vector3(1298.609f, 597.3955f, 79.88807f)); fHeading.Add(136.4441f);
                        Pos_01.Add(new Vector3(1744.206f, 1860.102f, 74.69196f)); fHeading.Add(174.4608f);
                        Pos_01.Add(new Vector3(2644.47f, 3147.029f, 50.34586f)); fHeading.Add(135.5797f);
                        Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                        Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                        Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                        Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                        Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                        Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                        Pos_01.Add(new Vector3(-2387.44f, 3921.145f, 24.41055f)); fHeading.Add(340.2222f);
                        Pos_01.Add(new Vector3(-2629.613f, 2777.201f, 16.40953f)); fHeading.Add(352.1142f);
                        Pos_01.Add(new Vector3(-2983.182f, 427.1111f, 14.73897f)); fHeading.Add(356.4609f);
                        Pos_01.Add(new Vector3(-2408.366f, -246.0178f, 15.25864f)); fHeading.Add(61.36377f);
                        Pos_01.Add(new Vector3(-712.5493f, -489.1255f, 24.75532f)); fHeading.Add(88.78899f);
                        Pos_01.Add(new Vector3(-398.3365f, -892.6438f, 36.99687f)); fHeading.Add(2.379511f);
                        Pos_01.Add(new Vector3(349.1497f, -1179.372f, 38.40684f)); fHeading.Add(89.36625f);
                        Pos_01.Add(new Vector3(881.6455f, -1168.795f, 42.78446f)); fHeading.Add(92.00111f);
                        Pos_01.Add(new Vector3(620.7553f, -584.2747f, 35.70321f)); fHeading.Add(241.3658f);
                        Pos_01.Add(new Vector3(35.09534f, -522.4681f, 33.79306f)); fHeading.Add(271.1531f);
                        Pos_01.Add(new Vector3(-580.5308f, -536.8923f, 24.96111f)); fHeading.Add(270.6866f);
                        Pos_01.Add(new Vector3(-1164.99f, -682.7447f, 10.80028f)); fHeading.Add(300.4947f);
                        Pos_01.Add(new Vector3(-1938.348f, -501.9031f, 11.5878f)); fHeading.Add(230.8896f);
                        Pos_01.Add(new Vector3(-2511.576f, -202.5297f, 18.51174f)); fHeading.Add(240.959f);
                        Pos_01.Add(new Vector3(-3107.269f, 1229.96f, 19.99887f)); fHeading.Add(173.2392f);
                        Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                        Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                        Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                        Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                        Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                        Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                        Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);
                        Pos_01.Add(new Vector3(2803.914f, 3404.103f, 55.59621f)); fHeading.Add(335.1538f);
                        Pos_01.Add(new Vector3(2159.228f, 2692.351f, 48.39897f)); fHeading.Add(310.3872f);
                        Pos_01.Add(new Vector3(2274.467f, 1177.887f, 77.4653f)); fHeading.Add(41.29153f);
                        Pos_01.Add(new Vector3(2615.018f, 295.7539f, 97.67361f)); fHeading.Add(351.01f);
                        Pos_01.Add(new Vector3(1743.362f, -889.3596f, 69.89281f)); fHeading.Add(302.4699f);
                        Pos_01.Add(new Vector3(1070.263f, -1189.859f, 55.55549f)); fHeading.Add(273.7319f);
                        Pos_01.Add(new Vector3(266.552f, -1222.569f, 38.0509f)); fHeading.Add(269.8226f);
                        iEnterVeh = 12;
                        DataStore.bFound = false;
                        iAction = 1;
                    }
                }       //><!--Cops
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                    Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                    Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                    Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                    Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                    Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                    Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                    Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                    Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                    Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                    Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                    Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                    Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);

                    iEnterVeh = 12;
                    DataStore.bFound = false;
                    iAction = 1;
                }       //><!-- PoliceBike
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(-1493.802f, 4979.706f, 62.91706f)); fHeading.Add(351.3716f);
                    Pos_01.Add(new Vector3(-1564.614f, 4385.387f, 4.26155f)); fHeading.Add(26.0204f);
                    Pos_01.Add(new Vector3(-889.2991f, 4427.76f, 20.53571f)); fHeading.Add(69.94745f);
                    Pos_01.Add(new Vector3(-773.6549f, 4520.953f, 93.5034f)); fHeading.Add(267.5718f);
                    Pos_01.Add(new Vector3(-1035.605f, 4576.456f, 122.0881f)); fHeading.Add(207.1876f);
                    Pos_01.Add(new Vector3(-1280.47f, 4608.851f, 122.7791f)); fHeading.Add(261.6023f);
                    Pos_01.Add(new Vector3(-1127.258f, 4682.028f, 240.7662f)); fHeading.Add(169.1925f);
                    Pos_01.Add(new Vector3(-1008.586f, 4706.519f, 246.7317f)); fHeading.Add(65.47046f);
                    Pos_01.Add(new Vector3(-1290.714f, 4936.681f, 152.4774f)); fHeading.Add(174.5883f);
                    Pos_01.Add(new Vector3(-1031.845f, 4916.573f, 205.4106f)); fHeading.Add(133.588f);
                    Pos_01.Add(new Vector3(-596.4041f, 5025.744f, 140.5351f)); fHeading.Add(353.1016f);
                    iEnterVeh = 9;
                    iAction = 1;
                }       //><!-- Ranger
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(885.5582f, -2615.697f, 50.64429f)); fHeading.Add(278.7308f);
                    Pos_01.Add(new Vector3(203.3962f, -2666.317f, 17.77028f)); fHeading.Add(269.1859f);
                    Pos_01.Add(new Vector3(-373.5676f, -2359.221f, 62.95405f)); fHeading.Add(234.2403f);
                    Pos_01.Add(new Vector3(-416.3635f, -1002.121f, 36.88079f)); fHeading.Add(180.3557f);
                    Pos_01.Add(new Vector3(-142.9952f, -489.4464f, 28.90267f)); fHeading.Add(90.18279f);
                    Pos_01.Add(new Vector3(263.6426f, -504.648f, 33.6673f)); fHeading.Add(89.44656f);
                    Pos_01.Add(new Vector3(658.7974f, -572.0912f, 35.72264f)); fHeading.Add(62.07106f);
                    Pos_01.Add(new Vector3(1298.609f, 597.3955f, 79.88807f)); fHeading.Add(136.4441f);
                    Pos_01.Add(new Vector3(1744.206f, 1860.102f, 74.69196f)); fHeading.Add(174.4608f);
                    Pos_01.Add(new Vector3(2644.47f, 3147.029f, 50.34586f)); fHeading.Add(135.5797f);
                    Pos_01.Add(new Vector3(2820.983f, 4262.163f, 49.99089f)); fHeading.Add(201.1554f);
                    Pos_01.Add(new Vector3(2542.731f, 5371.196f, 44.30971f)); fHeading.Add(192.7441f);
                    Pos_01.Add(new Vector3(905.6749f, 6484.458f, 21.066f)); fHeading.Add(266.5843f);
                    Pos_01.Add(new Vector3(-287.8203f, 6080.083f, 30.98392f)); fHeading.Add(315.2855f);
                    Pos_01.Add(new Vector3(-822.1944f, 5455.459f, 33.60496f)); fHeading.Add(302.0413f);
                    Pos_01.Add(new Vector3(-1990.362f, 4519.978f, 56.79668f)); fHeading.Add(313.5679f);
                    Pos_01.Add(new Vector3(-2387.44f, 3921.145f, 24.41055f)); fHeading.Add(340.2222f);
                    Pos_01.Add(new Vector3(-2629.613f, 2777.201f, 16.40953f)); fHeading.Add(352.1142f);
                    Pos_01.Add(new Vector3(-2983.182f, 427.1111f, 14.73897f)); fHeading.Add(356.4609f);
                    Pos_01.Add(new Vector3(-2408.366f, -246.0178f, 15.25864f)); fHeading.Add(61.36377f);
                    Pos_01.Add(new Vector3(-712.5493f, -489.1255f, 24.75532f)); fHeading.Add(88.78899f);
                    Pos_01.Add(new Vector3(-398.3365f, -892.6438f, 36.99687f)); fHeading.Add(2.379511f);
                    Pos_01.Add(new Vector3(349.1497f, -1179.372f, 38.40684f)); fHeading.Add(89.36625f);
                    Pos_01.Add(new Vector3(881.6455f, -1168.795f, 42.78446f)); fHeading.Add(92.00111f);
                    Pos_01.Add(new Vector3(620.7553f, -584.2747f, 35.70321f)); fHeading.Add(241.3658f);
                    Pos_01.Add(new Vector3(35.09534f, -522.4681f, 33.79306f)); fHeading.Add(271.1531f);
                    Pos_01.Add(new Vector3(-580.5308f, -536.8923f, 24.96111f)); fHeading.Add(270.6866f);
                    Pos_01.Add(new Vector3(-1164.99f, -682.7447f, 10.80028f)); fHeading.Add(300.4947f);
                    Pos_01.Add(new Vector3(-1938.348f, -501.9031f, 11.5878f)); fHeading.Add(230.8896f);
                    Pos_01.Add(new Vector3(-2511.576f, -202.5297f, 18.51174f)); fHeading.Add(240.959f);
                    Pos_01.Add(new Vector3(-3107.269f, 1229.96f, 19.99887f)); fHeading.Add(173.2392f);
                    Pos_01.Add(new Vector3(-2246.985f, 4275.212f, 46.0254f)); fHeading.Add(145.9837f);
                    Pos_01.Add(new Vector3(-1787.779f, 4738.555f, 56.77055f)); fHeading.Add(135.9421f);
                    Pos_01.Add(new Vector3(-487.1145f, 5868.34f, 33.32526f)); fHeading.Add(148.7284f);
                    Pos_01.Add(new Vector3(1645.693f, 6401.292f, 29.01801f)); fHeading.Add(70.58336f);
                    Pos_01.Add(new Vector3(2542.887f, 5440.158f, 44.27225f)); fHeading.Add(18.48835f);
                    Pos_01.Add(new Vector3(2720.861f, 4745.983f, 44.15805f)); fHeading.Add(12.34523f);
                    Pos_01.Add(new Vector3(2893.44f, 4158.5f, 49.99942f)); fHeading.Add(18.04636f);
                    Pos_01.Add(new Vector3(2803.914f, 3404.103f, 55.59621f)); fHeading.Add(335.1538f);
                    Pos_01.Add(new Vector3(2159.228f, 2692.351f, 48.39897f)); fHeading.Add(310.3872f);
                    Pos_01.Add(new Vector3(2274.467f, 1177.887f, 77.4653f)); fHeading.Add(41.29153f);
                    Pos_01.Add(new Vector3(2615.018f, 295.7539f, 97.67361f)); fHeading.Add(351.01f);
                    Pos_01.Add(new Vector3(1743.362f, -889.3596f, 69.89281f)); fHeading.Add(302.4699f);
                    Pos_01.Add(new Vector3(1070.263f, -1189.859f, 55.55549f)); fHeading.Add(273.7319f);
                    Pos_01.Add(new Vector3(266.552f, -1222.569f, 38.0509f)); fHeading.Add(269.8226f);
                    iEnterVeh = 12;
                    DataStore.bFound = false;
                    iAction = 1;
                }       //><!-- Sherif
                else if (iSubSet == 7)
                {
                    if (RsReturns.FindRandom(30, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(142.8676f, -721.2127f, 42.02895f)); fHeading.Add(38.59577f);
                        Pos_01.Add(new Vector3(180.8606f, -698.6846f, 47.07698f)); fHeading.Add(305.9764f);
                        Pos_01.Add(new Vector3(185.0671f, -782.6472f, 47.07693f)); fHeading.Add(205.7225f);
                        Pos_01.Add(new Vector3(102.9597f, -745.4732f, 45.75473f)); fHeading.Add(73.5444f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(124.8999f, -720.1405f, 32.75769f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(132.8888f, -722.7589f, 32.75735f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(140.2559f, -725.1739f, 32.75784f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(148.2134f, -727.7819f, 32.75822f)); fHeading.Add(340.4963f);
                        Pos_01.Add(new Vector3(151.4105f, -730.2962f, 32.75987f)); fHeading.Add(159.6303f);
                        Pos_01.Add(new Vector3(143.8329f, -727.6848f, 32.7599f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(136.2731f, -725.0797f, 32.75871f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(128.5793f, -722.4284f, 32.76021f)); fHeading.Add(159.6304f);
                        Pos_01.Add(new Vector3(120.7546f, -719.5478f, 32.75972f)); fHeading.Add(161.0089f);
                        Pos_01.Add(new Vector3(113.7038f, -716.8285f, 32.76033f)); fHeading.Add(161.0155f);
                        Pos_01.Add(new Vector3(110.3745f, -714.157f, 32.75887f)); fHeading.Add(340.0062f);
                        Pos_01.Add(new Vector3(103.6866f, -694.1055f, 32.74104f)); fHeading.Add(160.5572f);
                        Pos_01.Add(new Vector3(107.0196f, -695.1913f, 32.74342f)); fHeading.Add(160.5571f);
                        Pos_01.Add(new Vector3(111.1312f, -696.534f, 32.74039f)); fHeading.Add(160.5572f);
                        Pos_01.Add(new Vector3(114.4097f, -697.6046f, 32.74321f)); fHeading.Add(160.5571f);
                        Pos_01.Add(new Vector3(118.619f, -698.9508f, 32.74128f)); fHeading.Add(160.905f);
                        Pos_01.Add(new Vector3(122.539f, -700.1477f, 32.74237f)); fHeading.Add(161.6465f);
                        Pos_01.Add(new Vector3(125.8455f, -702.1788f, 32.74369f)); fHeading.Add(161.686f);
                        Pos_01.Add(new Vector3(129.9737f, -703.5176f, 32.74564f)); fHeading.Add(160.6104f);
                        Pos_01.Add(new Vector3(133.7075f, -704.7408f, 32.74757f)); fHeading.Add(160.6105f);
                        Pos_01.Add(new Vector3(145.1564f, -699.0904f, 32.75421f)); fHeading.Add(250.3092f);
                        Pos_01.Add(new Vector3(146.2141f, -695.4435f, 32.75328f)); fHeading.Add(252.3628f);
                        Pos_01.Add(new Vector3(148.6901f, -688.0548f, 32.75203f)); fHeading.Add(249.764f);
                        Pos_01.Add(new Vector3(149.8707f, -684.3236f, 32.75465f)); fHeading.Add(251.1089f);
                        Pos_01.Add(new Vector3(155.8789f, -682.1313f, 32.75422f)); fHeading.Add(160.3401f);
                        Pos_01.Add(new Vector3(159.394f, -683.2919f, 32.75308f)); fHeading.Add(160.3402f);
                        Pos_01.Add(new Vector3(163.1044f, -684.5927f, 32.75218f)); fHeading.Add(159.2708f);
                        Pos_01.Add(new Vector3(169.2833f, -686.3806f, 32.75238f)); fHeading.Add(160.0061f);
                        Pos_01.Add(new Vector3(173.0347f, -687.5805f, 32.74957f)); fHeading.Add(160.8067f);
                        Pos_01.Add(new Vector3(179.2498f, -695.2624f, 32.75071f)); fHeading.Add(72.96658f);
                        Pos_01.Add(new Vector3(178.1708f, -698.6674f, 32.75278f)); fHeading.Add(71.0178f);
                        Pos_01.Add(new Vector3(175.3772f, -706.3841f, 32.75247f)); fHeading.Add(71.30013f);
                        Pos_01.Add(new Vector3(174.2273f, -709.7647f, 32.75602f)); fHeading.Add(69.83701f);
                        Pos_01.Add(new Vector3(165.253f, -733.755f, 32.75826f)); fHeading.Add(70.5134f);
                        Pos_01.Add(new Vector3(164.3231f, -737.161f, 32.75834f)); fHeading.Add(70.5134f);
                        Pos_01.Add(new Vector3(162.8038f, -740.7974f, 32.75814f)); fHeading.Add(69.8709f);
                        Pos_01.Add(new Vector3(161.4511f, -744.9138f, 32.75976f)); fHeading.Add(74.06393f);
                        Pos_01.Add(new Vector3(155.2419f, -748.9347f, 32.75949f)); fHeading.Add(339.7729f);
                        Pos_01.Add(new Vector3(151.0513f, -747.5115f, 32.75947f)); fHeading.Add(340.5012f);
                        Pos_01.Add(new Vector3(148.0087f, -746.1507f, 32.75831f)); fHeading.Add(340.5012f);
                        Pos_01.Add(new Vector3(141.0646f, -743.7266f, 32.75826f)); fHeading.Add(338.631f);
                        Pos_01.Add(new Vector3(137.5325f, -742.0901f, 32.75802f)); fHeading.Add(339.5825f);
                        Pos_01.Add(new Vector3(133.8466f, -740.9481f, 32.75931f)); fHeading.Add(338.8475f);
                        Pos_01.Add(new Vector3(119.1344f, -735.6913f, 32.7584f)); fHeading.Add(339.97f);
                        Pos_01.Add(new Vector3(115.5711f, -734.0814f, 32.75903f)); fHeading.Add(340.7244f);
                        Pos_01.Add(new Vector3(108.545f, -731.7458f, 32.75801f)); fHeading.Add(340.7243f);
                        Pos_01.Add(new Vector3(104.27f, -730.391f, 32.75842f)); fHeading.Add(343.5851f);
                        Pos_01.Add(new Vector3(100.4326f, -728.9741f, 32.75946f)); fHeading.Add(340.1993f);
                        Pos_01.Add(new Vector3(96.46036f, -727.2465f, 32.75974f)); fHeading.Add(342.7584f);
                        Pos_01.Add(new Vector3(93.8289f, -720.4455f, 32.75797f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(95.17917f, -716.4265f, 32.75877f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(96.42334f, -712.7228f, 32.75986f)); fHeading.Add(250.9863f);
                        Pos_01.Add(new Vector3(97.63802f, -708.955f, 32.76009f)); fHeading.Add(249.8051f);

                        iEnterVeh = 3;

                        iAction = 1;
                    }
                }       //><!-- fib
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(-119.9115f, 6434.275f, 31.11884f)); fHeading.Add(76.0892f);
                    Pos_01.Add(new Vector3(-2985.351f, 481.0876f, 14.88591f)); fHeading.Add(340.2791f);
                    Pos_01.Add(new Vector3(213.41f, 185.9918f, 105.2675f)); fHeading.Add(42.60518f);
                    iEnterVeh = 3;

                    iAction = 1;
                }       //><!-- swat
                else if (iSubSet == 9)
                {
                    if (RsReturns.FindRandom(31, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(-2348.52f, 3270.065f, 32.81076f)); fHeading.Add(332.1701f);
                        Pos_01.Add(new Vector3(-2352.183f, 3263.234f, 32.81076f)); fHeading.Add(130.7586f);
                        Pos_01.Add(new Vector3(-2359.573f, 3242.599f, 92.90372f)); fHeading.Add(157.5246f);
                        Pos_01.Add(new Vector3(-2350.698f, 3253.426f, 92.90375f)); fHeading.Add(337.057f);
                        Pos_01.Add(new Vector3(-2358.584f, 3249.421f, 101.4507f)); fHeading.Add(153.4097f);
                        Pos_01.Add(new Vector3(-1741.393f, 3241.755f, 32.79575f)); fHeading.Add(78.55652f);
                        Pos_01.Add(new Vector3(-1804.59f, 3196.451f, 32.82647f)); fHeading.Add(182.0171f);
                        Pos_01.Add(new Vector3(-1805.791f, 3276.147f, 32.8152f)); fHeading.Add(321.533f);
                        Pos_01.Add(new Vector3(-1846.772f, 3299.44f, 32.81537f)); fHeading.Add(237.3338f);
                        Pos_01.Add(new Vector3(-1891.602f, 3248.149f, 36.84936f)); fHeading.Add(60.9971f);
                        Pos_01.Add(new Vector3(-2304.231f, 3388.183f, 31.25652f)); fHeading.Add(69.23507f);
                        Pos_01.Add(new Vector3(-2215.307f, 3335.828f, 49.68368f)); fHeading.Add(213.1394f);
                        Pos_01.Add(new Vector3(-2499.535f, 3299.237f, 91.96436f)); fHeading.Add(250.5922f);
                        Pos_01.Add(new Vector3(-2445.342f, 2922.033f, 32.9602f)); fHeading.Add(251.9464f);
                        Pos_01.Add(new Vector3(-2441.134f, 2951.473f, 34.84854f)); fHeading.Add(334.34f);
                        Pos_01.Add(new Vector3(-2439.48f, 3000.529f, 33.06071f)); fHeading.Add(296.1235f);
                        Pos_01.Add(new Vector3(-1850.713f, 2896.427f, 32.81028f)); fHeading.Add(304.653f);
                        Pos_01.Add(new Vector3(-1838.236f, 3124.419f, 32.81024f)); fHeading.Add(149.3089f);
                        Pos_01.Add(new Vector3(-1774.784f, 3045.097f, 32.81818f)); fHeading.Add(324.3441f);
                        Pos_01.Add(new Vector3(-1785.799f, 3145.48f, 33.06939f)); fHeading.Add(344.5996f);
                        Pos_01.Add(new Vector3(-1709.335f, 3005.007f, 33.19464f)); fHeading.Add(277.5203f);
                        Pos_01.Add(new Vector3(-1591.394f, 2796.617f, 17.07146f)); fHeading.Add(210.1899f);
                        Pos_01.Add(new Vector3(-2148.929f, 3299.234f, 38.73254f)); fHeading.Add(164.7554f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1899.622f, 3229.268f, 33.47933f)); fHeading.Add(240.4016f);
                        Pos_01.Add(new Vector3(-1803.691f, 3296.952f, 33.47214f)); fHeading.Add(59.49804f);
                        Pos_01.Add(new Vector3(-1987.941f, 3114.901f, 33.3334f)); fHeading.Add(238.1281f);
                        Pos_01.Add(new Vector3(-2298.659f, 3301.444f, 33.35372f)); fHeading.Add(98.11511f);
                        Pos_01.Add(new Vector3(-2175.917f, 3364.38f, 33.65299f)); fHeading.Add(267.6297f);

                        iEnterVeh = 3;

                        iAction = 1;
                    }

                    bRequestPB = true;
                }       //military
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(-480.4834f, -350.4613f, 34.13201f)); fHeading.Add(169.3226f);
                    Pos_01.Add(new Vector3(375.7192f, -583.7938f, 28.5012f)); fHeading.Add(268.1963f);
                    Pos_01.Add(new Vector3(314.8461f, -1448.607f, 29.57309f)); fHeading.Add(231.6201f);
                    Pos_01.Add(new Vector3(1128.826f, -1507.548f, 34.46217f)); fHeading.Add(267.5413f);
                    Pos_01.Add(new Vector3(1842.941f, 3706.448f, 33.35268f)); fHeading.Add(348.876f);
                    Pos_01.Add(new Vector3(-239.1304f, 6332.855f, 32.16411f)); fHeading.Add(224.5303f);
                    iEnterVeh = 2;

                    iAction = 1;
                }      //medic
                else
                {
                    Pos_01.Add(new Vector3(-370.2138f, 6128.188f, 31.52059f)); fHeading.Add(43.32635f);
                    Pos_01.Add(new Vector3(1696.062f, 3588.495f, 35.69079f)); fHeading.Add(203.5357f);
                    Pos_01.Add(new Vector3(209.5965f, -1646.76f, 29.87245f)); fHeading.Add(318.9238f);
                    Pos_01.Add(new Vector3(1204.332f, -1469.507f, 34.92859f)); fHeading.Add(357.4668f);
                    Pos_01.Add(new Vector3(-640.5964f, -101.5987f, 38.10654f)); fHeading.Add(127.0878f);

                    iEnterVeh = 3;

                    iAction = 1;
                }      //fireman

                iWeapons = 5;
            }           //Services 
            else if (iSelect == 22)
            {
                RandomWeatherTime();

                iSubSet = RsReturns.FindRandom(10, 1, 4);

                if (iSubSet == 1)
                {
                    if (RsReturns.FindRandom(32, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(-3376.623f, 7834.382f, 1500.00f)); fHeading.Add(217.4295f);
                        Pos_01.Add(new Vector3(4364.612f, -4151.208f, 1500.00f)); fHeading.Add(42.93307f);
                        Pos_01.Add(new Vector3(-3292.792f, -4034.441f, 1500.00f)); fHeading.Add(311.4861f);
                        Pos_01.Add(new Vector3(3585.601f, 7976.706f, 1500.00f)); fHeading.Add(140.3225f);
                        DataStore.vPlayerTarget = new Vector3(-2352.11f, 2274.94f, 1500.0f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-1669.021f, -2788.412f, 22.72314f)); fHeading.Add(330.7915f);
                        DataStore.vPlayerTarget = new Vector3(144.6707f, 411.1093f, 562.7795f);
                        bRequestPB = true;
                    }
                    iAction = 1;

                    iEnterVeh = 1;
                }       //civilian
                else if (iSubSet == 2)
                {
                    if (RsReturns.FindRandom(33, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(-3376.623f, 7834.382f, 700.00f)); fHeading.Add(217.4295f);
                        Pos_01.Add(new Vector3(4364.612f, -4151.208f, 700.00f)); fHeading.Add(42.93307f);
                        Pos_01.Add(new Vector3(-3292.792f, -4034.441f, 700.00f)); fHeading.Add(311.4861f);
                        Pos_01.Add(new Vector3(3585.601f, 7976.706f, 700.00f)); fHeading.Add(140.3225f);
                        DataStore.vPlayerTarget = new Vector3(-2352.11f, 2274.94f, 1500.0f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(-2668.141f, 3239.957f, 33.58316f)); fHeading.Add(240.3811f);
                        DataStore.vPlayerTarget = new Vector3(-1316.467f, 2441.465f, 418.8308f);
                        bRequestPB = true;
                    }
                    iAction = 1;

                    iEnterVeh = 1;
                }       //milatary
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-745.0335f, -1434.13f, 5.675035f)); fHeading.Add(49.38052f);
                    Pos_01.Add(new Vector3(-744.5621f, -1434.631f, 45.5694f)); fHeading.Add(43.56923f);
                    Pos_01.Add(new Vector3(-943.0097f, -1372.587f, 88.47835f)); fHeading.Add(76.8955f);
                    Pos_01.Add(new Vector3(-1380.798f, -1231.121f, 120.3375f)); fHeading.Add(64.56821f);
                    Pos_01.Add(new Vector3(-1937.764f, -718.4302f, 124.1025f)); fHeading.Add(41.56572f);
                    Pos_01.Add(new Vector3(-2005.697f, -10.6858f, 183.4718f)); fHeading.Add(350.5649f);
                    Pos_01.Add(new Vector3(-1887.984f, 252.9273f, 219.2129f)); fHeading.Add(332.1073f);
                    Pos_01.Add(new Vector3(-1440.777f, 532.8215f, 241.145f)); fHeading.Add(289.4188f);
                    Pos_01.Add(new Vector3(-824.9135f, 722.5916f, 296.2533f)); fHeading.Add(284.8902f);
                    Pos_01.Add(new Vector3(-489.9325f, 952.3074f, 396.2867f)); fHeading.Add(329.8929f);
                    Pos_01.Add(new Vector3(-140.4692f, 1033.914f, 412.1446f)); fHeading.Add(256.8935f);
                    Pos_01.Add(new Vector3(516.86f, 1063.885f, 403.47f)); fHeading.Add(279.1731f);
                    Pos_01.Add(new Vector3(620.8156f, 13.97498f, 298.2937f)); fHeading.Add(164.5377f);
                    Pos_01.Add(new Vector3(402.175f, -584.6495f, 256.7945f)); fHeading.Add(155.1357f);
                    Pos_01.Add(new Vector3(173.9926f, -954.7323f, 237.2449f)); fHeading.Add(138.4467f);
                    Pos_01.Add(new Vector3(-284.1717f, -1343.872f, 140.4055f)); fHeading.Add(133.4898f);
                    Pos_01.Add(new Vector3(-528.8258f, -1504.724f, 124.409f)); fHeading.Add(89.10454f);
                    Pos_01.Add(new Vector3(-714.8882f, -1458.062f, 42.30001f)); fHeading.Add(58.55215f);
                    iAction = 10;

                    iEnterVeh = 3;
                }       //helitours
                else
                {
                    Pos_01.Add(new Vector3(-286.1589f, 6130.172f, 32.13292f)); fHeading.Add(275.265f);
                    Pos_01.Add(new Vector3(-286.3647f, 6130.907f, 65.98f)); fHeading.Add(281.1871f);
                    Pos_01.Add(new Vector3(-235.833f, 6276.704f, 110.6021f)); fHeading.Add(353.3344f);
                    Pos_01.Add(new Vector3(23.64182f, 6835.598f, 86.64565f)); fHeading.Add(320.9841f);
                    Pos_01.Add(new Vector3(284.416f, 6887.176f, 101.6019f)); fHeading.Add(226.6046f);
                    Pos_01.Add(new Vector3(763.9923f, 6577.445f, 93.83253f)); fHeading.Add(252.6691f);
                    Pos_01.Add(new Vector3(1505.827f, 6548.389f, 108.8764f)); fHeading.Add(272.7405f);
                    Pos_01.Add(new Vector3(1802.909f, 6568.977f, 149.3561f)); fHeading.Add(279.932f);
                    Pos_01.Add(new Vector3(2484.531f, 6498.886f, 200.3775f)); fHeading.Add(250.4998f);
                    Pos_01.Add(new Vector3(3039.205f, 6285.432f, 198.2972f)); fHeading.Add(247.7497f);
                    Pos_01.Add(new Vector3(3278.987f, 5914.606f, 227.383f)); fHeading.Add(185.5986f);
                    Pos_01.Add(new Vector3(3275.25f, 5330.985f, 118.3367f)); fHeading.Add(176.5877f);
                    Pos_01.Add(new Vector3(3189.232f, 5115.614f, 95.28926f)); fHeading.Add(118.7072f);
                    Pos_01.Add(new Vector3(2804.662f, 5091.914f, 127.3515f)); fHeading.Add(83.45394f);
                    Pos_01.Add(new Vector3(2266.839f, 5147.165f, 131.4157f)); fHeading.Add(85.08824f);
                    Pos_01.Add(new Vector3(1800.733f, 5002.501f, 145.9994f)); fHeading.Add(125.2208f);
                    Pos_01.Add(new Vector3(1480.974f, 4630.318f, 183.4221f)); fHeading.Add(143.8588f);
                    Pos_01.Add(new Vector3(901.9067f, 4327.457f, 197.9002f)); fHeading.Add(108.8094f);
                    Pos_01.Add(new Vector3(171.0265f, 4324.955f, 207.0748f)); fHeading.Add(82.35104f);
                    Pos_01.Add(new Vector3(-279.3649f, 4390.429f, 196.3075f)); fHeading.Add(82.40254f);
                    Pos_01.Add(new Vector3(-852.1649f, 4395.291f, 184.6133f)); fHeading.Add(96.01467f);
                    Pos_01.Add(new Vector3(-1271.238f, 4444.289f, 164.0461f)); fHeading.Add(73.29852f);
                    Pos_01.Add(new Vector3(-1553.718f, 4725.6f, 175.09f)); fHeading.Add(21.14607f);
                    Pos_01.Add(new Vector3(-1528.674f, 5186.567f, 162.9194f)); fHeading.Add(313.75f);
                    Pos_01.Add(new Vector3(-1104.559f, 5507.558f, 144.9734f)); fHeading.Add(301.4052f);
                    Pos_01.Add(new Vector3(-600.4811f, 5832.47f, 156.2213f)); fHeading.Add(309.3331f);
                    Pos_01.Add(new Vector3(-360.4607f, 6078.532f, 136.8584f)); fHeading.Add(301.1647f);
                    Pos_01.Add(new Vector3(-316.0546f, 6116.282f, 64.80506f)); fHeading.Add(281.8811f);
                    iAction = 10;

                    iEnterVeh = 3;
                }      //PaletoHeli
            }           //Pilot
            else if (iSelect == 23)
            {
                RandomWeatherTime();

                if (DataStore.MySettingsXML.Spawn || DataStore.MySettingsXML.Saved)
                    iSubSet = RsReturns.FindRandom(14, 1, 11);
                else
                    iSubSet = RsReturns.FindRandom(13, 1, 14);

                float fRando = RsReturns.RandInt(0, 360);

                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(-457.3879f, 5553.581f, 73.99891f)); fHeading.Add(170.4394f);
                    Pos_01.Add(new Vector3(-494.3865f, 5189.813f, 89.39753f)); fHeading.Add(324.6375f);
                    Pos_01.Add(new Vector3(-695.0361f, 5464.335f, 46.07887f)); fHeading.Add(22.68201f);
                    Pos_01.Add(new Vector3(1635.211f, 4946.255f, 42.4776f)); fHeading.Add(309.0715f);
                    Pos_01.Add(new Vector3(1222.848f, 4495.256f, 49.80619f)); fHeading.Add(159.4206f);
                    Pos_01.Add(new Vector3(1058.898f, 4241.627f, 37.00926f)); fHeading.Add(231.3649f);
                    Pos_01.Add(new Vector3(287.0659f, 4261.199f, 39.60912f)); fHeading.Add(275.8864f);
                    Pos_01.Add(new Vector3(31.35694f, 4340.92f, 42.37447f)); fHeading.Add(144.4754f);
                    Pos_01.Add(new Vector3(-368.3591f, 4368.038f, 52.54329f)); fHeading.Add(353.8307f);
                    Pos_01.Add(new Vector3(2193.633f, 4682.529f, 34.95401f)); fHeading.Add(225.1884f);
                }           //a_c_boar
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(-489.1449f, 6272.717f, 13.33084f)); fHeading.Add(146.1511f);
                    Pos_01.Add(new Vector3(-298.5837f, 6300.868f, 31.47709f)); fHeading.Add(310.8734f);
                    Pos_01.Add(new Vector3(-253.243f, 6228.751f, 31.4237f)); fHeading.Add(136.6564f);
                    Pos_01.Add(new Vector3(-170.8394f, 6410.968f, 36.1613f)); fHeading.Add(309.1762f);
                    Pos_01.Add(new Vector3(-7.483267f, 6582.724f, 31.45495f)); fHeading.Add(307.8637f);
                    Pos_01.Add(new Vector3(-69.15816f, 6407.708f, 31.48155f)); fHeading.Add(119.0731f);
                    Pos_01.Add(new Vector3(1649.878f, 4867.57f, 41.90494f)); fHeading.Add(270.5852f);
                    Pos_01.Add(new Vector3(-1323.155f, -1175.789f, 4.86331f)); fHeading.Add(6.297443f);
                    Pos_01.Add(new Vector3(-1264.917f, -1121.156f, 7.457192f)); fHeading.Add(9.68405f);
                    Pos_01.Add(new Vector3(-1567.084f, -438.8763f, 36.95732f)); fHeading.Add(342.0412f);
                    Pos_01.Add(new Vector3(-1663.211f, -403.2176f, 44.65012f)); fHeading.Add(328.2743f);
                    Pos_01.Add(new Vector3(-1482.063f, -335.0168f, 45.90718f)); fHeading.Add(222.3334f);
                    Pos_01.Add(new Vector3(-1411.828f, -254.482f, 46.37918f)); fHeading.Add(198.0449f);
                    Pos_01.Add(new Vector3(-1412.658f, -461.7616f, 34.48635f)); fHeading.Add(120.2687f);
                    Pos_01.Add(new Vector3(-1306.679f, -403.2025f, 36.41523f)); fHeading.Add(296.8628f);
                    Pos_01.Add(new Vector3(-1324.421f, -582.2607f, 29.36177f)); fHeading.Add(208.0897f);
                    Pos_01.Add(new Vector3(-1404.671f, -633.0682f, 28.66234f)); fHeading.Add(190.164f);
                    Pos_01.Add(new Vector3(-1191.879f, -917.8907f, 6.633331f)); fHeading.Add(177.2337f);
                    Pos_01.Add(new Vector3(-964.8581f, -893.8589f, 2.145377f)); fHeading.Add(122.1884f);
                    Pos_01.Add(new Vector3(-1094.882f, -1638.895f, 4.398429f)); fHeading.Add(218.6515f);
                    Pos_01.Add(new Vector3(-695.9647f, -1148.954f, 10.81242f)); fHeading.Add(123.7849f);
                    Pos_01.Add(new Vector3(-573.2047f, -780.1418f, 30.67539f)); fHeading.Add(82.87112f);
                    Pos_01.Add(new Vector3(-467.4827f, -721.5107f, 32.72823f)); fHeading.Add(270.6811f);
                    Pos_01.Add(new Vector3(-603.4603f, 175.6338f, 65.03928f)); fHeading.Add(107.3593f);
                    Pos_01.Add(new Vector3(-480.6446f, 72.93433f, 58.3337f)); fHeading.Add(102.4298f);
                    Pos_01.Add(new Vector3(-160.9944f, 206.0385f, 90.54567f)); fHeading.Add(85.81742f);
                    Pos_01.Add(new Vector3(-134.6189f, -13.40307f, 58.43617f)); fHeading.Add(346.3363f);
                    Pos_01.Add(new Vector3(56.63927f, -62.42125f, 67.63075f)); fHeading.Add(174.5408f);
                    Pos_01.Add(new Vector3(52.52608f, -102.7701f, 56.30117f)); fHeading.Add(241.1132f);
                    Pos_01.Add(new Vector3(224.4882f, 90.73195f, 92.99115f)); fHeading.Add(242.7487f);
                    Pos_01.Add(new Vector3(178.0649f, 7.548378f, 73.42571f)); fHeading.Add(69.11054f);
                    Pos_01.Add(new Vector3(145.3046f, -95.86935f, 64.55049f)); fHeading.Add(252.004f);
                    Pos_01.Add(new Vector3(68.41623f, -87.2534f, 62.48888f)); fHeading.Add(67.16145f);
                    Pos_01.Add(new Vector3(-28.27929f, -42.18899f, 68.96458f)); fHeading.Add(67.99091f);
                    Pos_01.Add(new Vector3(-160.5599f, 12.8439f, 64.55468f)); fHeading.Add(64.67293f);
                    Pos_01.Add(new Vector3(154.9679f, 299.9555f, 109.2783f)); fHeading.Add(272.365f);
                    Pos_01.Add(new Vector3(306.7009f, 272.5739f, 105.6552f)); fHeading.Add(158.6221f);
                    Pos_01.Add(new Vector3(105.6946f, -244.0652f, 51.39948f)); fHeading.Add(56.58199f);
                    Pos_01.Add(new Vector3(33.62473f, -1415.058f, 29.3807f)); fHeading.Add(273.1532f);
                    Pos_01.Add(new Vector3(-143.623f, -1435.251f, 30.98906f)); fHeading.Add(137.5871f);
                    Pos_01.Add(new Vector3(-124.3528f, -1617.652f, 31.98614f)); fHeading.Add(310.5232f);
                    Pos_01.Add(new Vector3(-239.9151f, -1644.622f, 33.54083f)); fHeading.Add(193.2142f);
                    Pos_01.Add(new Vector3(57.41949f, -1831.992f, 24.27117f)); fHeading.Add(58.92987f);
                    Pos_01.Add(new Vector3(207.5628f, -1693.97f, 29.21246f)); fHeading.Add(48.28707f);
                    Pos_01.Add(new Vector3(262.2509f, -1761.088f, 28.73582f)); fHeading.Add(47.30854f);
                    Pos_01.Add(new Vector3(356.5831f, -1868.168f, 26.89423f)); fHeading.Add(140.4836f);
                    Pos_01.Add(new Vector3(365.5281f, -2089.871f, 21.04716f)); fHeading.Add(315.9386f);
                    Pos_01.Add(new Vector3(1232.821f, -644.1865f, 66.87959f)); fHeading.Add(11.07453f);
                    Pos_01.Add(new Vector3(1019.167f, -500.7501f, 60.69093f)); fHeading.Add(19.97879f);
                    Pos_01.Add(new Vector3(809.7609f, -126.2644f, 77.24301f)); fHeading.Add(56.15232f);
                }      //cats/dogs
                else if (iSubSet == 3)
                {
                    Pos_01.Add(new Vector3(-1798.327f, -367.8435f, 63.32634f)); fHeading.Add(193.4475f);
                    Pos_01.Add(new Vector3(-1754.362f, -398.6084f, 61.47853f)); fHeading.Add(271.401f);
                    Pos_01.Add(new Vector3(-1699.881f, -447.604f, 51.85827f)); fHeading.Add(284.0296f);
                    Pos_01.Add(new Vector3(-1648.967f, -364.9341f, 57.85902f)); fHeading.Add(90.00666f);
                    Pos_01.Add(new Vector3(-1500.419f, -365.9177f, 53.64492f)); fHeading.Add(270.9501f);
                    Pos_01.Add(new Vector3(-1556.568f, -222.7807f, 61.25249f)); fHeading.Add(272.3614f);
                    Pos_01.Add(new Vector3(-1482.511f, -194.8814f, 61.88908f)); fHeading.Add(242.8922f);
                    Pos_01.Add(new Vector3(-1351.707f, -207.7835f, 56.73883f)); fHeading.Add(254.2633f);
                    Pos_01.Add(new Vector3(-1131.186f, -338.4612f, 49.96766f)); fHeading.Add(267.795f);
                    Pos_01.Add(new Vector3(-1154.988f, -370.9339f, 60.99239f)); fHeading.Add(82.19715f);
                    Pos_01.Add(new Vector3(-1170.928f, -469.0142f, 63.362f)); fHeading.Add(170.2042f);
                    Pos_01.Add(new Vector3(-1432.225f, -700.3183f, 34.43598f)); fHeading.Add(266.5981f);
                    Pos_01.Add(new Vector3(-1260.698f, -773.0103f, 28.08051f)); fHeading.Add(288.7174f);
                    Pos_01.Add(new Vector3(-1277.13f, -1036.979f, 30.61119f)); fHeading.Add(276.1534f);
                    Pos_01.Add(new Vector3(-1250.884f, -1349.212f, 11.00681f)); fHeading.Add(271.3377f);
                    Pos_01.Add(new Vector3(-1036.955f, -1564.975f, 13.71508f)); fHeading.Add(115.3018f);
                    Pos_01.Add(new Vector3(-174.3833f, -1286.126f, 51.57734f)); fHeading.Add(191.2564f);
                    Pos_01.Add(new Vector3(-68.70186f, -1329.357f, 39.16204f)); fHeading.Add(204.9683f);
                    Pos_01.Add(new Vector3(-16.61767f, -1551.997f, 37.85777f)); fHeading.Add(236.8366f);
                    Pos_01.Add(new Vector3(196.3551f, -1878.706f, 29.22336f)); fHeading.Add(91.73615f);
                    Pos_01.Add(new Vector3(472.7628f, -1890.018f, 31.78282f)); fHeading.Add(291.9175f);
                }     //a_c_pigeon
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(461.2985f, -3104.381f, 6.070058f)); fHeading.Add(291.4764f);
                    Pos_01.Add(new Vector3(-1199.754f, -2704.224f, 13.95425f)); fHeading.Add(223.3566f);
                    Pos_01.Add(new Vector3(-347.7987f, -2661.436f, 6.000296f)); fHeading.Add(359.5485f);
                    Pos_01.Add(new Vector3(-76.08307f, -2666.825f, 6.00089f)); fHeading.Add(65.05595f);
                    Pos_01.Add(new Vector3(-443.0275f, -2180.255f, 10.31819f)); fHeading.Add(100.1932f);
                    Pos_01.Add(new Vector3(875.7438f, -1351.802f, 26.31284f)); fHeading.Add(262.73f);
                    Pos_01.Add(new Vector3(682.5385f, -1213.703f, 24.96063f)); fHeading.Add(181.9295f);
                    Pos_01.Add(new Vector3(690.9706f, -1016.897f, 22.62444f)); fHeading.Add(1.884157f);
                    Pos_01.Add(new Vector3(727.1188f, -927.6669f, 24.61855f)); fHeading.Add(53.66885f);
                    Pos_01.Add(new Vector3(1143.96f, -785.0414f, 57.58156f)); fHeading.Add(250.645f);
                    Pos_01.Add(new Vector3(1536.905f, 3798.235f, 34.45097f)); fHeading.Add(115.1182f);
                    Pos_01.Add(new Vector3(2055.688f, 3172.045f, 45.16896f)); fHeading.Add(199.4242f);
                    Pos_01.Add(new Vector3(2192.997f, 5600.538f, 53.66485f)); fHeading.Add(321.3761f);
                    Pos_01.Add(new Vector3(66.26553f, 6663.012f, 31.78686f)); fHeading.Add(11.51797f);
                }     //a_c_rat
                else if (iSubSet == 5)
                {
                    List<Vector3> vCenter = new List<Vector3>
                    {
                        new Vector3(417.9343f, 6478.052f, 28.8074f),
                        new Vector3(2227.181f, 4911.849f, 40.6702f),
                        new Vector3(2213.208f, 4925.513f, 40.74488f),
                        new Vector3(2239.021f, 4903.998f, 40.64403f),
                        new Vector3(2254.72f, 4882.05f, 40.87927f),
                        new Vector3(2502.236f, 4731.86f, 34.30383f),
                        new Vector3(2496.951f, 4737.613f, 34.30383f),
                        new Vector3(2488.061f, 4745.833f, 34.30383f),
                        new Vector3(2478.211f, 4743.216f, 34.30384f),
                        new Vector3(2462.051f, 4734.207f, 34.30384f),
                        new Vector3(2465.021f, 4726.047f, 34.30384f),
                        new Vector3(2472.982f, 4713.502f, 34.30384f),
                        new Vector3(2452.201f, 4742.365f, 34.30384f),
                        new Vector3(2457.568f, 4754.12f, 34.30385f),
                        new Vector3(2441.434f, 4759.145f, 34.3058f),
                        new Vector3(2442.434f, 4767.811f, 34.30868f),
                        new Vector3(2421.559f, 4778.803f, 34.47688f),
                        new Vector3(2415.927f, 4809.829f, 35.71259f),
                        new Vector3(2397.146f, 4804.948f, 36.39542f),
                        new Vector3(2382.756f, 4787.905f, 35.70205f),
                        new Vector3(1355.888f, 1253.27f, 105.045f),
                        new Vector3(1421.018f, 1292.063f, 111.9903f),
                        new Vector3(1414.824f, 1338.969f, 107.1353f),
                        new Vector3(1433.681f, 1385.947f, 106.8216f),
                        new Vector3(1388.754f, 1428.129f, 104.5997f)
                    };

                    Vector3 MyRandV = vCenter[RsReturns.RandInt(0, vCenter.Count - 1)];
                    Vector3 MyVec = MyRandV.Around(4.00f);
                    MyVec.Z = MyRandV.Z + 0.5f;

                    Pos_01.Add(MyVec); fHeading.Add(fRando);
                }      //a_c_cow
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(1781.178f, 3067.974f, 62.37364f)); fHeading.Add(123.2384f);
                    Pos_01.Add(new Vector3(1572.388f, 2910.075f, 56.93121f)); fHeading.Add(247.4637f);
                    Pos_01.Add(new Vector3(1448.025f, 2790.733f, 52.44666f)); fHeading.Add(63.9786f);
                    Pos_01.Add(new Vector3(1172.84f, 2728.583f, 37.99408f)); fHeading.Add(283.2423f);
                    Pos_01.Add(new Vector3(1120.176f, 2626.74f, 37.98522f)); fHeading.Add(128.8985f);
                    Pos_01.Add(new Vector3(1019.712f, 2651.524f, 39.56373f)); fHeading.Add(218.314f);
                    Pos_01.Add(new Vector3(971.1495f, 2725.413f, 39.47706f)); fHeading.Add(196.6791f);
                    Pos_01.Add(new Vector3(563.2943f, 2804.677f, 42.179f)); fHeading.Add(235.5823f);
                    Pos_01.Add(new Vector3(562.98f, 2668.865f, 42.0967f)); fHeading.Add(9.277174f);
                    Pos_01.Add(new Vector3(390.2578f, 2571.469f, 43.49282f)); fHeading.Add(356.8945f);
                    Pos_01.Add(new Vector3(353.8606f, 2558.211f, 43.48626f)); fHeading.Add(33.24611f);
                    Pos_01.Add(new Vector3(191.44f, 3073.951f, 43.05728f)); fHeading.Add(351.493f);
                    Pos_01.Add(new Vector3(245.3919f, 3176.349f, 42.6951f)); fHeading.Add(328.9407f);
                    Pos_01.Add(new Vector3(923.3562f, 3653.927f, 32.49792f)); fHeading.Add(149.906f);
                    Pos_01.Add(new Vector3(1379.035f, 3617.868f, 34.88105f)); fHeading.Add(224.4082f);
                    Pos_01.Add(new Vector3(1905.982f, 3734.859f, 32.41202f)); fHeading.Add(48.93122f);
                    Pos_01.Add(new Vector3(1965.386f, 3758.618f, 32.22155f)); fHeading.Add(229.2195f);
                }      //a_c_coyote
                else if (iSubSet == 7)
                {
                    Pos_01.Add(new Vector3(-1778.111f, -240.8525f, 51.25969f)); fHeading.Add(89.9939f);
                    Pos_01.Add(new Vector3(-1780.717f, -199.4209f, 55.69526f)); fHeading.Add(270.0832f);
                    Pos_01.Add(new Vector3(-1681.285f, -149.9413f, 59.02122f)); fHeading.Add(269.9794f);
                    Pos_01.Add(new Vector3(-1636.64f, -130.9335f, 58.81951f)); fHeading.Add(151.6588f);
                    Pos_01.Add(new Vector3(-290.1838f, 2854.484f, 54.41695f)); fHeading.Add(128.2115f);
                    Pos_01.Add(new Vector3(405.3126f, -1486.106f, 34.87928f)); fHeading.Add(4.64691f);
                }      //a_c_crow
                else if (iSubSet == 8)
                {
                    Pos_01.Add(new Vector3(-540.7523f, 5979.117f, 34.85002f)); fHeading.Add(32.85591f);
                    Pos_01.Add(new Vector3(-546.3254f, 5891.349f, 33.02752f)); fHeading.Add(89.67336f);
                    Pos_01.Add(new Vector3(-619.1426f, 5787.263f, 28.79116f)); fHeading.Add(172.7761f);
                    Pos_01.Add(new Vector3(-762.7892f, 5932.308f, 20.22102f)); fHeading.Add(115.5313f);
                    Pos_01.Add(new Vector3(-874.0002f, 6013.388f, 35.57697f)); fHeading.Add(114.3561f);
                    Pos_01.Add(new Vector3(-687.7157f, 5653.694f, 32.24801f)); fHeading.Add(194.4881f);
                    Pos_01.Add(new Vector3(-522.7726f, 5578.903f, 65.4232f)); fHeading.Add(266.7195f);
                    Pos_01.Add(new Vector3(-465.5789f, 5699.212f, 68.66573f)); fHeading.Add(47.65134f);
                    Pos_01.Add(new Vector3(-486.9351f, 5534.415f, 75.63812f)); fHeading.Add(58.07087f);
                    Pos_01.Add(new Vector3(-732.8253f, 5365.237f, 60.18141f)); fHeading.Add(107.3803f);
                    Pos_01.Add(new Vector3(-782.1372f, 5289.694f, 86.45531f)); fHeading.Add(160.2472f);
                    Pos_01.Add(new Vector3(-904.5177f, 5279.477f, 84.45411f)); fHeading.Add(166.775f);
                    Pos_01.Add(new Vector3(-1148.836f, 5169.071f, 95.37173f)); fHeading.Add(115.7366f);
                    Pos_01.Add(new Vector3(-1257.694f, 4941.357f, 169.565f)); fHeading.Add(248.0916f);
                    Pos_01.Add(new Vector3(-1414.645f, 4898.25f, 112.3443f)); fHeading.Add(114.9287f);
                    Pos_01.Add(new Vector3(-1608.565f, 4678.01f, 39.21826f)); fHeading.Add(240.4865f);
                    Pos_01.Add(new Vector3(-1481.673f, 4627.572f, 48.55896f)); fHeading.Add(270.5523f);
                    Pos_01.Add(new Vector3(-1591.385f, 4496.293f, 20.21319f)); fHeading.Add(188.9801f);
                    Pos_01.Add(new Vector3(-1425.511f, 4407.443f, 47.12846f)); fHeading.Add(316.8277f);
                    Pos_01.Add(new Vector3(-1214.433f, 4439.974f, 29.94384f)); fHeading.Add(37.86443f);
                    Pos_01.Add(new Vector3(-614.5055f, 4903.279f, 186.1149f)); fHeading.Add(52.75925f);
                    Pos_01.Add(new Vector3(-446.6541f, 4806.495f, 230.9601f)); fHeading.Add(263.0022f);
                    Pos_01.Add(new Vector3(-137.5665f, 4567.001f, 118.2301f)); fHeading.Add(218.6852f);
                    Pos_01.Add(new Vector3(59.70969f, 4681.479f, 179.562f)); fHeading.Add(55.75858f);
                    Pos_01.Add(new Vector3(479.309f, 4487.017f, 126.7762f)); fHeading.Add(332.2285f);
                    Pos_01.Add(new Vector3(1531.167f, 4834.677f, 72.88008f)); fHeading.Add(154.3012f);
                    Pos_01.Add(new Vector3(1479.59f, 5205.152f, 183.1102f)); fHeading.Add(304.9509f);
                    Pos_01.Add(new Vector3(1703.529f, 5239.249f, 125.6967f)); fHeading.Add(346.0668f);
                    Pos_01.Add(new Vector3(1913.865f, 5449.821f, 176.0958f)); fHeading.Add(123.9867f);
                    Pos_01.Add(new Vector3(2583.419f, 6176.759f, 164.7064f)); fHeading.Add(42.45876f);
                    Pos_01.Add(new Vector3(2643.596f, 6337.706f, 114.4633f)); fHeading.Add(330.2474f);
                    Pos_01.Add(new Vector3(2987.127f, 6255.812f, 76.31998f)); fHeading.Add(155.676f);
                    Pos_01.Add(new Vector3(3137.004f, 6084.535f, 92.65406f)); fHeading.Add(96.80786f);
                    Pos_01.Add(new Vector3(3374.18f, 5445.407f, 15.87068f)); fHeading.Add(157.421f);
                    Pos_01.Add(new Vector3(3727.86f, 3611.223f, 32.58834f)); fHeading.Add(194.4491f);
                    Pos_01.Add(new Vector3(3061.042f, 2373.278f, 66.70252f)); fHeading.Add(89.79482f);
                    Pos_01.Add(new Vector3(2958.032f, 2108.912f, 28.74703f)); fHeading.Add(129.394f);
                    Pos_01.Add(new Vector3(2710.875f, 1067.349f, 21.40227f)); fHeading.Add(172.1084f);
                    Pos_01.Add(new Vector3(2940.977f, 798.3766f, 25.40315f)); fHeading.Add(163.4013f);
                    Pos_01.Add(new Vector3(2815.99f, 666.3555f, 42.62372f)); fHeading.Add(36.26171f);
                    Pos_01.Add(new Vector3(2387.526f, -1109.01f, 59.21403f)); fHeading.Add(20.22232f);
                    Pos_01.Add(new Vector3(2275.714f, -1407.633f, 111.9474f)); fHeading.Add(78.67244f);
                    Pos_01.Add(new Vector3(2444.656f, -1688.364f, 46.02353f)); fHeading.Add(203.4291f);
                    Pos_01.Add(new Vector3(2550.898f, -1880.101f, 32.41238f)); fHeading.Add(87.75346f);
                    Pos_01.Add(new Vector3(2322.274f, -1954.51f, 54.69868f)); fHeading.Add(328.8488f);
                    Pos_01.Add(new Vector3(2016.918f, -1877.154f, 116.3597f)); fHeading.Add(353.763f);
                    Pos_01.Add(new Vector3(1892.684f, -2575.366f, 34.31363f)); fHeading.Add(188.3276f);
                    Pos_01.Add(new Vector3(1607.339f, -2589.137f, 55.9791f)); fHeading.Add(17.28388f);
                    Pos_01.Add(new Vector3(-2235.257f, -79.56699f, 109.7868f)); fHeading.Add(14.99429f);
                    Pos_01.Add(new Vector3(-374.6635f, 1128.37f, 321.9959f)); fHeading.Add(279.0736f);
                    Pos_01.Add(new Vector3(439.5944f, 1023.119f, 233.4403f)); fHeading.Add(239.8481f);
                    Pos_01.Add(new Vector3(423.6472f, 756.1078f, 190.3729f)); fHeading.Add(127.0718f);
                    Pos_01.Add(new Vector3(509.3311f, 576.3101f, 159.4695f)); fHeading.Add(207.3073f);
                }      //a_c_deer/a_c_rabbit_01
                else if (iSubSet == 9)
                {
                    List<Vector3> vCenter = new List<Vector3>
                    {
                        new Vector3(3294.645f, 5188.46f, 18.41536f),
                        new Vector3(2234.094f, 5608.012f, 54.64093f),
                        new Vector3(2256.062f, 5158.674f, 57.96902f),
                        new Vector3(1697.929f, 4874.469f, 42.03117f),
                        new Vector3(1648.552f, 4781.981f, 42.11193f),
                        new Vector3(1717.678f, 4679.414f, 43.65579f),
                        new Vector3(1667.145f, 4680.101f, 43.05535f),
                        new Vector3(1677.29f, 4653.63f, 43.37117f),
                        new Vector3(1364.512f, 4359.951f, 44.4988f),
                        new Vector3(740.5996f, 4170.04f, 41.0878f),
                        new Vector3(1366.07f, 3648.678f, 33.78039f),
                        new Vector3(1441.558f, 3630.086f, 34.97598f),
                        new Vector3(1424.652f, 3665.129f, 39.72842f),
                        new Vector3(1503.234f, 3699.392f, 39.05916f),
                        new Vector3(1641.75f, 3729.399f, 35.06714f),
                        new Vector3(1648.607f, 3810.293f, 38.65067f),
                        new Vector3(1669.977f, 3743.251f, 34.86417f),
                        new Vector3(1745.342f, 3700.265f, 34.34354f),
                        new Vector3(1779.095f, 3642.883f, 34.47246f),
                        new Vector3(1782.287f, 3745.965f, 34.65663f),
                        new Vector3(1746.644f, 3785.375f, 34.83487f),
                        new Vector3(1778.128f, 3802.267f, 38.36934f),
                        new Vector3(1811.733f, 3853.763f, 34.53526f),
                        new Vector3(1719.855f, 3851.263f, 34.79908f),
                        new Vector3(1712.258f, 3844.736f, 35.09302f),
                        new Vector3(1737.591f, 3899.409f, 35.559f),
                        new Vector3(1781.677f, 3907.481f, 39.80395f),
                        new Vector3(1815.851f, 3907.366f, 37.2175f),
                        new Vector3(1885.031f, 3911.95f, 33.09767f),
                        new Vector3(1920.32f, 3890.656f, 32.65907f),
                        new Vector3(1903.048f, 3876.147f, 32.4305f),
                        new Vector3(1859.193f, 3852.417f, 33.03402f),
                        new Vector3(1871.298f, 3806.77f, 32.64043f),
                        new Vector3(1894.649f, 3785.76f, 32.77509f),
                        new Vector3(1947.112f, 3803.384f, 32.03712f),
                        new Vector3(1915.621f, 3822.773f, 32.43993f),
                        new Vector3(1939.32f, 3851.287f, 32.16716f),
                        new Vector3(1975.69f, 3814.874f, 33.42525f),
                        new Vector3(2184.301f, 3503.538f, 45.41576f),
                        new Vector3(2190.204f, 3340.191f, 45.70337f),
                        new Vector3(2152.329f, 3390.411f, 45.40681f),
                        new Vector3(2168.019f, 3379.724f, 46.43439f),
                        new Vector3(2379.093f, 3350.109f, 47.95228f),
                        new Vector3(2484.173f, 3446.39f, 51.06676f),
                        new Vector3(2482.338f, 3722.635f, 43.92163f),
                        new Vector3(2412.371f, 4034.768f, 36.81679f),
                        new Vector3(2552.169f, 4281.502f, 41.61633f),
                        new Vector3(2637.038f, 4245.829f, 44.80367f),
                        new Vector3(2726.922f, 4143.099f, 44.28887f),
                        new Vector3(2734.81f, 4274.33f, 48.5205f),
                        new Vector3(1541.871f, 2239.158f, 77.69897f),
                        new Vector3(1379.956f, 2164.427f, 97.81518f),
                        new Vector3(768.7703f, 2177.563f, 52.37225f),
                        new Vector3(730.4855f, 2332.482f, 50.53867f),
                        new Vector3(-264.924f, 2206.832f, 130.0993f),
                        new Vector3(-33.62269f, 1943.332f, 190.1862f),
                        new Vector3(201.6048f, 2437.004f, 60.46714f),
                        new Vector3(380.8315f, 2574.337f, 43.51957f),
                        new Vector3(470.6082f, 2607.824f, 44.47719f),
                        new Vector3(498.1459f, 2605.617f, 43.69965f),
                        new Vector3(995.9922f, 2719.427f, 40.08806f),
                        new Vector3(982.1971f, 2669.811f, 40.06126f),
                        new Vector3(1582.44f, 2906.777f, 56.95695f)
                    };

                    Vector3 MyVec = vCenter[RsReturns.RandInt(0, vCenter.Count - 1)];

                    Pos_01.Add(MyVec); fHeading.Add(fRando);
                }     //a_c_hen                
                else if (iSubSet == 10)
                {
                    Pos_01.Add(new Vector3(661.5698f, 5612.078f, 716.1574f)); fHeading.Add(231.2322f);
                    Pos_01.Add(new Vector3(985.664f, 5640.936f, 628.7191f)); fHeading.Add(264.3497f);
                    Pos_01.Add(new Vector3(722.2346f, 5274.907f, 553.4761f)); fHeading.Add(204.2183f);
                    Pos_01.Add(new Vector3(136.9531f, 5172.29f, 553.2682f)); fHeading.Add(135.7912f);
                    Pos_01.Add(new Vector3(83.88232f, 5684.837f, 493.1975f)); fHeading.Add(40.70573f);
                    Pos_01.Add(new Vector3(773.9695f, 5948.048f, 450.6795f)); fHeading.Add(329.4138f);
                    Pos_01.Add(new Vector3(2876.706f, 5910.7f, 369.5696f)); fHeading.Add(279.8868f);
                    Pos_01.Add(new Vector3(2783.151f, 6002.458f, 357.2812f)); fHeading.Add(39.0136f);
                    Pos_01.Add(new Vector3(2934.188f, 5614.261f, 243.6154f)); fHeading.Add(148.7178f);
                    Pos_01.Add(new Vector3(-1214.425f, 3848.331f, 490.2165f)); fHeading.Add(177.0983f);
                    Pos_01.Add(new Vector3(-966.5247f, 3824.745f, 427.8647f)); fHeading.Add(277.0794f);
                    Pos_01.Add(new Vector3(-2357.528f, 1282.13f, 330.8891f)); fHeading.Add(225.1253f);
                }     //a_c_mtlion-mountain lion
                else if (iSubSet == 11)
                {
                    List<Vector3> vCenter = new List<Vector3>
                    {
                        new Vector3(434.6616f, 6509.293f, 28.37131f),
                        new Vector3(2155.208f, 5002.346f, 41.37879f),
                        new Vector3(2150.277f, 4997.573f, 41.36464f),
                        new Vector3(2146.562f, 4994.063f, 41.35011f),
                        new Vector3(2141.951f, 4989.576f, 41.39429f),
                        new Vector3(2184.549f, 4977.354f, 41.39772f),
                        new Vector3(2180.546f, 4972.885f, 41.33164f),
                        new Vector3(2176.846f, 4968.851f, 41.31844f),
                        new Vector3(2173.024f, 4964.73f, 41.3524f),
                        new Vector3(2174.25f, 4960.258f, 41.34821f),
                        new Vector3(2167.813f, 4965.707f, 41.37321f),
                        new Vector3(2383.506f, 5057.748f, 46.44459f),
                        new Vector3(2383.948f, 5051.404f, 46.4409f),
                        new Vector3(2378.454f, 5048.563f, 46.44463f),
                        new Vector3(2374.309f, 5054.471f, 46.44463f),
                        new Vector3(-49.16756f, 2875.243f, 58.92621f),
                        new Vector3(-143.4491f, 1912.423f, 197.3212f),
                        new Vector3(1953.505f, 3806.679f, 32.30476f),
                        new Vector3(1581.271f, 2167.549f, 79.28706f)
                    };

                    Vector3 MyRandV = vCenter[RsReturns.RandInt(0, vCenter.Count - 1)];
                    Vector3 MyVec = MyRandV.Around(4.00f);
                    MyVec.Z = MyRandV.Z + 0.5f;

                    Pos_01.Add(MyVec); fHeading.Add(fRando);
                }     //a_c_pig
                else if (iSubSet == 12)
                {
                    Pos_01.Add(new Vector3(1829.751f, -2962.983f, -41.09711f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(881.9769f, -3480.864f, -12.39751f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(271.4858f, -2290.783f, -8.27566f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-199.2741f, -2862.99f, -11.28995f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-1892.526f, -1307.415f, -35.69325f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-2843.658f, -574.4394f, -44.94706f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-3189.769f, 3026.521f, -30.46286f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-3252.511f, 3681.582f, -23.06396f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-3374.703f, 504.2789f, -24.57951f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-3163.912f, 3003.868f, -38.98509f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(2655.749f, -1395.955f, -12.85984f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(3164.551f, -364.2288f, -19.23776f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(3886.64f, 3041.357f, -16.14589f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(4279.323f, 2971.412f, -170.3207f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(4218.59f, 3616.418f, -34.40534f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(3401.174f, 6310.327f, -44.94764f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(3269.4f, 6419.564f, -46.06504f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(2649.136f, 6661.476f, -17.16622f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(747.8029f, 7393.903f, -108.1086f)); fHeading.Add(fRando);
                    Pos_01.Add(new Vector3(-951.4739f, 6692.083f, -32.37279f)); fHeading.Add(fRando);
                }      //Fish/sharks
                else if (iSubSet == 13)
                {
                    List<Vector3> vCenter = new List<Vector3>
                    {
                        new Vector3(-2505.106f, 757.7692f, 402.0063f),
                        new Vector3(-2338.906f, 1359.295f, 434.8655f),
                        new Vector3(-1208.171f, 1196.468f, 393.5298f),
                        new Vector3(-917.9607f, 1425.409f, 398.0696f),
                        new Vector3(-465.1019f, 1526.887f, 491.0108f),
                        new Vector3(758.509f, 1274.176f, 546.1901f),
                        new Vector3(1789.931f, 686.2056f, 367.2453f),
                        new Vector3(2215.134f, 245.5946f, 359.8406f),
                        new Vector3(2046.679f, -1554.435f, 343.4529f),
                        new Vector3(2900.099f, 2383.188f, 270.8425f),
                        new Vector3(3293.974f, 3141.153f, 353.1701f),
                        new Vector3(3444.243f, 4197.86f, 340.2985f),
                        new Vector3(2877.255f, 5911.345f, 469.6395f),
                        new Vector3(450.718f, 5566.614f, 906.1833f),
                        new Vector3(-1213.257f, 3848.571f, 590.4387f)
                    };

                    Vector3 MyRandV = vCenter[RsReturns.RandInt(0, vCenter.Count - 1)];
                    Vector3 MyVec = MyRandV.Around(75.00f);
                    MyVec.Z = MyRandV.Z + 0.5f;

                    Pos_01.Add(MyVec); fHeading.Add(fRando);
                }      //a_c_chickenhawk
                else
                {
                    Pos_01.Add(new Vector3(-647.1717f, 6381.847f, 55.23498f)); fHeading.Add(116.049f);
                    Pos_01.Add(new Vector3(-996.1914f, 6127.102f, 65.05244f)); fHeading.Add(134.0498f);
                    Pos_01.Add(new Vector3(-1386.921f, 5662.692f, 47.45169f)); fHeading.Add(144.4735f);
                    Pos_01.Add(new Vector3(-1762.023f, 5236.699f, 55.13129f)); fHeading.Add(131.9612f);
                    Pos_01.Add(new Vector3(-2233.242f, 4773.679f, 45.847f)); fHeading.Add(141.0407f);
                    Pos_01.Add(new Vector3(-2531.957f, 4265.873f, 47.47537f)); fHeading.Add(155.767f);
                    Pos_01.Add(new Vector3(-2917.601f, 3701.053f, 38.22935f)); fHeading.Add(142.8838f);
                    Pos_01.Add(new Vector3(-2998.329f, 3139.244f, 74.07671f)); fHeading.Add(213.4786f);
                    Pos_01.Add(new Vector3(-2752.106f, 2674.014f, 26.49481f)); fHeading.Add(181.8097f);
                    Pos_01.Add(new Vector3(-2876.323f, 2343.454f, 32.5507f)); fHeading.Add(141.9623f);
                    Pos_01.Add(new Vector3(-3161.823f, 1995.468f, 46.15065f)); fHeading.Add(162.9095f);
                    Pos_01.Add(new Vector3(-3308.383f, 1324.952f, 24.35565f)); fHeading.Add(170.2323f);
                    Pos_01.Add(new Vector3(-3257.926f, 801.7152f, 19.8493f)); fHeading.Add(208.8283f);
                    Pos_01.Add(new Vector3(-3165.103f, 389.472f, 21.80201f)); fHeading.Add(178.8124f);
                    Pos_01.Add(new Vector3(-3060.918f, 39.02373f, 41.1531f)); fHeading.Add(225.9778f);
                    Pos_01.Add(new Vector3(-2584.827f, -262.5694f, 20.47069f)); fHeading.Add(240.8913f);
                    Pos_01.Add(new Vector3(-1946.684f, -760.1068f, 17.09371f)); fHeading.Add(227.7444f);
                    Pos_01.Add(new Vector3(-1756.316f, -1033.566f, 48.26628f)); fHeading.Add(208.7735f);
                    Pos_01.Add(new Vector3(-1576.124f, -1275.015f, 56.18793f)); fHeading.Add(226.497f);
                    Pos_01.Add(new Vector3(-1365.415f, -1603.034f, 22.2108f)); fHeading.Add(204.662f);
                    Pos_01.Add(new Vector3(-1285.784f, -2006.483f, 29.93159f)); fHeading.Add(141.3346f);
                    Pos_01.Add(new Vector3(-1678.79f, -2464.347f, 31.70895f)); fHeading.Add(138.5401f);
                    Pos_01.Add(new Vector3(-1955.164f, -3219.351f, 27.96449f)); fHeading.Add(229.7054f);
                    Pos_01.Add(new Vector3(-1491.28f, -3433.852f, 24.46868f)); fHeading.Add(255.0693f);
                    Pos_01.Add(new Vector3(-450.818f, -2932.367f, 59.03496f)); fHeading.Add(315.9116f);
                    Pos_01.Add(new Vector3(-170.4312f, -2751.726f, 35.55687f)); fHeading.Add(281.9165f);
                    Pos_01.Add(new Vector3(84.32108f, -3011.168f, 38.66256f)); fHeading.Add(186.9482f);
                    Pos_01.Add(new Vector3(381.5255f, -3088.718f, 43.53959f)); fHeading.Add(184.7814f);
                    Pos_01.Add(new Vector3(810.2408f, -3349.875f, 76.97131f)); fHeading.Add(255.1599f);
                    Pos_01.Add(new Vector3(1011.955f, -2818.816f, 67.02275f)); fHeading.Add(275.2491f);
                    Pos_01.Add(new Vector3(1381.353f, -2785.423f, 25.2271f)); fHeading.Add(275.3469f);
                    Pos_01.Add(new Vector3(1899.568f, -2698.206f, 29.57582f)); fHeading.Add(290.0086f);
                    Pos_01.Add(new Vector3(2253.048f, -2338.232f, 22.41039f)); fHeading.Add(327.0099f);
                    Pos_01.Add(new Vector3(2695.794f, -1842.093f, 60.28313f)); fHeading.Add(350.8695f);
                    Pos_01.Add(new Vector3(2617.608f, -1242.502f, 42.30254f)); fHeading.Add(353.048f);
                    Pos_01.Add(new Vector3(2812.688f, -885.5068f, 39.93338f)); fHeading.Add(336.1742f);
                    Pos_01.Add(new Vector3(3090.899f, -303.8704f, 28.63768f)); fHeading.Add(331.2384f);
                    Pos_01.Add(new Vector3(3137.391f, 290.1704f, 31.95886f)); fHeading.Add(10.3887f);
                    Pos_01.Add(new Vector3(2952.225f, 871.7095f, 49.21233f)); fHeading.Add(27.73952f);
                    Pos_01.Add(new Vector3(3045.487f, 1832.076f, 51.5413f)); fHeading.Add(328.3755f);
                    Pos_01.Add(new Vector3(3373.457f, 2541.495f, 30.65476f)); fHeading.Add(342.1697f);
                    Pos_01.Add(new Vector3(3592.438f, 2930.6f, 55.46889f)); fHeading.Add(321.836f);
                    Pos_01.Add(new Vector3(3891.745f, 3392.547f, 49.76966f)); fHeading.Add(337.126f);
                    Pos_01.Add(new Vector3(3812.255f, 3768.048f, 42.65887f)); fHeading.Add(308.2817f);
                    Pos_01.Add(new Vector3(3995.321f, 4042.65f, 28.32089f)); fHeading.Add(353.3696f);
                    Pos_01.Add(new Vector3(3945.367f, 4453.691f, 21.29278f)); fHeading.Add(24.97192f);
                    Pos_01.Add(new Vector3(3637.679f, 4847.447f, 11.86491f)); fHeading.Add(35.3928f);
                    Pos_01.Add(new Vector3(3398.107f, 5422.701f, 35.40386f)); fHeading.Add(282.6931f);
                    Pos_01.Add(new Vector3(3462.258f, 5879.85f, 29.49525f)); fHeading.Add(359.8459f);
                    Pos_01.Add(new Vector3(3425.451f, 6118.301f, 37.708f)); fHeading.Add(22.10388f);
                    Pos_01.Add(new Vector3(3049.092f, 6444.611f, 35.03535f)); fHeading.Add(62.56868f);
                    Pos_01.Add(new Vector3(2403.384f, 6718.95f, 39.0113f)); fHeading.Add(69.30715f);
                    Pos_01.Add(new Vector3(1678.953f, 6731.902f, 71.92032f)); fHeading.Add(96.16738f);
                    Pos_01.Add(new Vector3(622.5536f, 6737.898f, 21.04184f)); fHeading.Add(47.28201f);
                    Pos_01.Add(new Vector3(145.2582f, 7054.913f, 40.39904f)); fHeading.Add(76.91423f);
                    Pos_01.Add(new Vector3(-147.7463f, 6729.933f, 13.17056f)); fHeading.Add(153.3098f);
                }      //a_c_cormorant
                iWeapons = 0;
            }           //Animals
            else if (iSelect == 24)
            {
                RandomWeatherTime();

                if (RsReturns.FindRandom(34, 1, 4) < 2)
                {
                    Pos_01.Add(new Vector3(5308.355f, -5222.566f, 83.51822f)); fHeading.Add(177.7005f);
                    Pos_01.Add(new Vector3(4473.773f, -5041.711f, 112.4676f)); fHeading.Add(3.755754f);
                    Pos_01.Add(new Vector3(3154.248f, -4841.147f, 111.8988f)); fHeading.Add(351.9035f);
                    Pos_01.Add(new Vector3(3271.483f, -4582.126f, 118.072f)); fHeading.Add(183.05f);
                    Pos_01.Add(new Vector3(3558.263f, -4684.025f, 114.5897f)); fHeading.Add(102.3436f);
                }
                else
                {
                    Pos_01.Add(new Vector3(3222.979f, -4692.7f, 112.7545f)); fHeading.Add(174.2392f);
                    Pos_01.Add(new Vector3(3238.098f, -4839.443f, 111.9102f)); fHeading.Add(266.6948f);
                    Pos_01.Add(new Vector3(3341.186f, -4876.17f, 111.7968f)); fHeading.Add(354.3529f);
                    Pos_01.Add(new Vector3(3521.893f, -4851.566f, 111.7791f)); fHeading.Add(164.9078f);
                    Pos_01.Add(new Vector3(3799.094f, -4997.383f, 111.8013f)); fHeading.Add(246.7712f);
                    Pos_01.Add(new Vector3(4389.065f, -5176.559f, 110.9251f)); fHeading.Add(353.9681f);
                    Pos_01.Add(new Vector3(4738.257f, -5103.999f, 106.8863f)); fHeading.Add(357.4206f);
                    iAction = 1;

                    iEnterVeh = RsReturns.RandInt(1, 2);
                }

                iWeapons = 5;

                if (!DataStore.bInYankton)
                    Yankton(true);
            }           //North Yankton
            else
            {
                World.CurrentDayTime = TimeSpan.FromHours(12);
                World.Weather = Weather.ExtraSunny;

                iSubSet = RsReturns.FindRandom(12, 1, 6);
                if (iSubSet == 1)
                {
                    Pos_01.Add(new Vector3(4979.349f, -5764.603f, 20.87796f)); fHeading.Add(45.00f);
                    DataStore.bOpenDoors = true;
                }       //A_C_Panther
                else if (iSubSet == 2)
                {
                    Pos_01.Add(new Vector3(4893.338f, -4903.796f, 3.486674f)); fHeading.Add(179.7596f);
                    Pos_01.Add(new Vector3(4898.212f, -4913.461f, 3.362877f)); fHeading.Add(62.6438f);
                    Pos_01.Add(new Vector3(4889.125f, -4913.463f, 3.364484f)); fHeading.Add(243.0125f);
                    Pos_01.Add(new Vector3(4886.227f, -4922.317f, 3.370104f)); fHeading.Add(156.813f);
                    Pos_01.Add(new Vector3(4889.59f, -4928.318f, 3.380038f)); fHeading.Add(314.8568f);
                    Pos_01.Add(new Vector3(4898.494f, -4931.63f, 3.367776f)); fHeading.Add(95.74232f);
                    Pos_01.Add(new Vector3(4870.61f, -4930.148f, 2.789379f)); fHeading.Add(333.0222f);
                    Pos_01.Add(new Vector3(4874.745f, -4925.462f, 3.178774f)); fHeading.Add(132.1784f);
                    Pos_01.Add(new Vector3(4869.804f, -4927.207f, 2.743952f)); fHeading.Add(247.7478f);
                    iAction = 12;
                }       //A_F_Y_Beach_02
                else if (iSubSet == 3)
                {
                    if (RsReturns.FindRandom(35, 1, 4) < 2)
                    {
                        Pos_01.Add(new Vector3(4877.928f, -4488.06f, 26.93383f)); fHeading.Add(7.88381f);
                        Pos_01.Add(new Vector3(5032.213f, -4630.636f, 21.68462f)); fHeading.Add(75.61213f);
                        Pos_01.Add(new Vector3(5153.693f, -4933.251f, 30.87342f)); fHeading.Add(142.8952f);
                        Pos_01.Add(new Vector3(5148.306f, -5053.395f, 20.39156f)); fHeading.Add(85.7536f);
                        Pos_01.Add(new Vector3(5465.802f, -5236.399f, 43.96178f)); fHeading.Add(184.7819f);
                        Pos_01.Add(new Vector3(5360.864f, -5437.077f, 66.17649f)); fHeading.Add(221.3451f);
                        Pos_01.Add(new Vector3(5125.446f, -5526.457f, 70.9704f)); fHeading.Add(199.5584f);
                        Pos_01.Add(new Vector3(4887.5f, -5458.02f, 47.52377f)); fHeading.Add(182.3656f);
                        Pos_01.Add(new Vector3(5042.819f, -5114.771f, 22.94463f)); fHeading.Add(88.81671f);
                        Pos_01.Add(new Vector3(5140.625f, -5243.813f, 26.29192f)); fHeading.Add(253.1926f);
                    }
                    else
                    {
                        Pos_01.Add(new Vector3(5233.419f, -5043.578f, 14.87521f)); fHeading.Add(43.09966f);
                        Pos_01.Add(new Vector3(5165.328f, -5169.925f, 1.41904f)); fHeading.Add(176.6293f);
                        Pos_01.Add(new Vector3(4941.741f, -5249.38f, 1.856673f)); fHeading.Add(191.2316f);
                        Pos_01.Add(new Vector3(4971.292f, -5701.965f, 19.36028f)); fHeading.Add(38.00845f);
                        Pos_01.Add(new Vector3(5255.248f, -5503.7f, 50.02805f)); fHeading.Add(289.521f);
                        Pos_01.Add(new Vector3(5383.012f, -5666.684f, 49.45168f)); fHeading.Add(348.699f);
                        Pos_01.Add(new Vector3(5250.007f, -5268.963f, 24.84689f)); fHeading.Add(50.79947f);
                        Pos_01.Add(new Vector3(5044.055f, -4904.506f, 14.52278f)); fHeading.Add(277.0196f);
                        Pos_01.Add(new Vector3(4953.167f, -4745.344f, 7.760445f)); fHeading.Add(340.7749f);
                        Pos_01.Add(new Vector3(4928.463f, -4485.532f, 7.438392f)); fHeading.Add(56.79505f);
                        Pos_01.Add(new Vector3(4500.685f, -4494.414f, 3.665595f)); fHeading.Add(287.3625f);
                        iAction = 1;

                        iEnterVeh = RsReturns.RandInt(1, 2);
                    }

                    iWeapons = 5;
                }       //Guard
                else if (iSubSet == 4)
                {
                    Pos_01.Add(new Vector3(4904.958f, -4941.593f, 3.378354f)); fHeading.Add(37.49379f);
                }       //Bar
                else if (iSubSet == 5)
                {
                    Pos_01.Add(new Vector3(5170.325f, -4675.89f, 2.435122f)); fHeading.Add(66.67837f);
                    Pos_01.Add(new Vector3(5179.303f, -4649.774f, 2.530395f)); fHeading.Add(64.63232f);
                    Pos_01.Add(new Vector3(5127.161f, -4613.125f, 2.567649f)); fHeading.Add(134.3626f);
                    Pos_01.Add(new Vector3(5403.269f, -5174.491f, 31.46002f)); fHeading.Add(30.90309f);
                    Pos_01.Add(new Vector3(5408.926f, -5216.411f, 34.45446f)); fHeading.Add(232.4724f);
                    Pos_01.Add(new Vector3(5382.5f, -5255.195f, 34.15533f)); fHeading.Add(168.2274f);
                    Pos_01.Add(new Vector3(5327.994f, -5265.26f, 33.17245f)); fHeading.Add(216.49f);
                    Pos_01.Add(new Vector3(5312.92f, -5200.948f, 31.73465f)); fHeading.Add(43.35777f);
                    Pos_01.Add(new Vector3(5283.029f, -5239.302f, 30.83397f)); fHeading.Add(226.2264f);
                    Pos_01.Add(new Vector3(5211.092f, -5125.889f, 6.214875f)); fHeading.Add(297.0678f);
                    Pos_01.Add(new Vector3(5182.966f, -5148.639f, 3.549981f)); fHeading.Add(93.57137f);
                    Pos_01.Add(new Vector3(5117.133f, -5172.37f, 2.296359f)); fHeading.Add(90.88295f);
                    Pos_01.Add(new Vector3(5012.493f, -5201.086f, 2.517188f)); fHeading.Add(332.5578f);
                    Pos_01.Add(new Vector3(4957.826f, -5133.129f, 2.44458f)); fHeading.Add(126.1573f);
                    Pos_01.Add(new Vector3(4902.437f, -5180.579f, 2.445158f)); fHeading.Add(256.659f);
                    Pos_01.Add(new Vector3(4949.478f, -5319.582f, 8.065354f)); fHeading.Add(190.8848f);
                    Pos_01.Add(new Vector3(5310.973f, -5600.635f, 64.51008f)); fHeading.Add(298.4847f);
                }       //worker
                else if (iSubSet == 6)
                {
                    Pos_01.Add(new Vector3(4499.6f, -4523.962f, 4.412367f)); fHeading.Add(276.4212f);
                    iAction = 13;
                }       //pilot
                else
                {
                    Pos_01.Add(new Vector3(4877.928f, -4488.06f, 26.93383f)); fHeading.Add(7.88381f);
                }       //randomOther??

                if (!DataStore.bInCayoPerico)
                    CayoPerico(true);
            }           //Cayo Perico

            if (DataStore.MySettingsXML.Spawn)
            {
                if (!RsReturns.GetMainChar())
                    YourRanPed(DataStore.sMainChar);
                else
                    PlayerBelter();
            }
            else
            {
                if (DataStore.MySettingsXML.Saved)
                    YourSavedPed();
                else
                    YourRanPed(RsReturns.BuildRandomPed(iSelect, iSubSet));
            }

            if (iAction > 0)
            {
                DataStore.bAllowControl = true;

                if (iAction == 1)
                {
                    int iPlace = Pos_01.Count();
                    if (iPlace < 1)
                    {
                        UI.Notify("~r~Debug ~w~No Pos_01's");
                    }
                    else
                    {
                        if (iPlace == 1)
                            iPlace = 0;
                        else
                            iPlace = RsReturns.RandInt(0, iPlace - 1);
                        AddVeh(RsReturns.BuildRandVeh(iSelect, iSubSet), Pos_01[iPlace], fHeading[iPlace], iEnterVeh, iSelect, iSubSet);
                        DataStore.iPostAction = 1;
                    }
                }            //drive
                else if (iAction == 2)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);

                    Game.Player.Character.Position = Pos_01[iPlace];
                    Game.Player.Character.Heading = fHeading[iPlace];

                    PedScenario(Game.Player.Character, "WORLD_HUMAN_SUNBATHE_BACK", Pos_01[iPlace], fHeading[iPlace], false);

                    DataStore.iPostAction = 1;
                }       //Sunbath
                else if (iAction == 3)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    List<string> sPropers = new List<string>();

                    sPropers.Add("prop_beggers_sign_01");
                    sPropers.Add("prop_beggers_sign_02");
                    sPropers.Add("prop_beggers_sign_03");
                    sPropers.Add("prop_beggers_sign_04");
                    string sProper = sPropers[RsReturns.RandInt(0, 3)];
                    ForceAnim(Game.Player.Character, "amb@lo_res_idles@", "world_human_bum_freeway_lo_res_base", Pos_01[iPlace], new Vector3(0.00f, 0.00f, fHeading[iPlace]));

                    DataStore.sExitAn_01 = "amb@prop_human_bum_bin@exit";
                    DataStore.sExitAn_02 = "exit";

                    RsReturns.MyPropBuild(sProper, Pos_01[iPlace], Vector3.Zero, 1, true);

                    DataStore.iPostAction = 2;
                }       //TrampSign
                else if (iAction == 4)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    ForceAnim(Game.Player.Character, "switch@trevor@scares_tramp", "trev_scares_tramp_idle_tramp", Pos_01[iPlace], new Vector3(0.00f, 0.00f, fHeading[iPlace]));
                    DataStore.sExitAn_01 = "switch@trevor@scares_tramp";
                    DataStore.sExitAn_02 = "trev_scares_tramp_exit_tramp";
                    DataStore.iPostAction = 2;
                }       //TrampSleap
                else if (iAction == 5)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];
                    Game.FadeScreenIn(1);
                    Script.Wait(2);

                    if (iSelect == 7)
                    {
                        if (iPlace == 0)
                            PedScenario(Game.Player.Character, "PROP_HUMAN_SEAT_MUSCLE_BENCH_PRESS", Pos_01[iPlace], fHeading[iPlace], false);
                        else if (iPlace < 3)
                            PedScenario(Game.Player.Character, "PROP_HUMAN_MUSCLE_CHIN_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                        else
                        {
                            int iPose = RsReturns.RandInt(0, 30);
                            if (iPose < 10)
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_SIT_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                            else if (iPose < 20)
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_MUSCLE_FREE_WEIGHTS", Pos_01[iPlace], fHeading[iPlace], false);
                            else
                                PedScenario(Game.Player.Character, "WORLD_HUMAN_PUSH_UPS", Pos_01[iPlace], fHeading[iPlace], false);
                        }
                    }
                    else
                        PedScenario(Game.Player.Character, "WORLD_HUMAN_GARDENER_PLANT", Pos_01[iPlace], fHeading[iPlace], false);
                    DataStore.iPostAction = 1;
                }       //MuscleBeach
                else if (iAction == 6)
                {
                    DataStore.iPostAction = 3;

                    if (iSubSet == 1)
                    {
                        DataStore.vPedTarget = new Vector3(-302.166f, 317.6619f, 92.68359f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-286.2027f, 311.9702f, 92.69145f);
                        float fRot = 358.9505f;
                        AddVeh("VIRGO2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-282.5865f, 324.6772f, 92.68803f);
                        fRot = 183.9263f;
                        AddVeh("CHINO2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-274.7456f, 324.9384f, 92.69529f);
                        fRot = 179.5375f;
                        AddVeh("FACTION3", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-275.7558f, 312.8728f, 92.68794f);
                        fRot = 19.96654f;
                        AddVeh("BUCCANEER2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-305.226f, 274.3028f, 87.31434f);
                        fRot = 19.96654f;
                        AddVeh("MINIVAN2", VPos, fRot, 7, iSelect, 8);
                    }           //Import Ex-- West Vine wood-- Vs. Polynesian.
                    else if (iSubSet == 2)
                    {
                        DataStore.vPedTarget = new Vector3(-450.5249f, -1704.782f, 18.8604f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-458.0122f, -1719.43f, 18.08753f);
                        float fRot = 336.3535f;
                        AddVeh("SULTAN", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-424.3365f, -1688.027f, 18.49347f);
                        fRot = 162.8363f;
                        AddVeh("FORKLIFT", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-390.9916f, -1693.444f, 18.16406f);
                        fRot = 151.6561f;
                        AddVeh("FBI2", VPos, fRot, 7, 21, 7);
                    }           //Armenian -- Rogers Salvage and Scrap in La Puerta.-- Vs Police 
                    else if (iSubSet == 3)
                    {
                        DataStore.vPedTarget = new Vector3(88.2571f, -1926.898f, 19.9731f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(100.9958f, -1929.075f, 19.88203f);
                        float fRot = 160.4151f;
                        AddVeh("EMPEROR", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(113.7581f, -1939.326f, 19.91485f);
                        fRot = 116.716f;
                        AddVeh("PEYOTE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(106.8031f, -1949.032f, 19.91415f);
                        fRot = 15.96025f;
                        AddVeh("MANANA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(97.78821f, -1944.386f, 19.94981f);
                        fRot = 312.7894f;
                        AddVeh("VOODOO", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(94.26853f, -1859.033f, 23.66001f);
                        fRot = 141.1448f;
                        AddVeh("BALLER", VPos, fRot, 7, iSelect, 5);

                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"), DataStore.GP_Player);
                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_BALLAS"));

                        DataStore.iGrouping = 1;
                    }           //Ballas-- Davis, Vs --Families 
                    else if (iSubSet == 4)
                    {
                        DataStore.vPedTarget = new Vector3(455.9662f, -728.9713f, 26.54497f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Game.Player.Character.Position = new Vector3(458.5448f, -735.9688f, 27.35763f);
                        Game.Player.Character.Heading = 204.9358f;

                        Vector3 VPos = new Vector3(452.4408f, -682.1255f, 27.24649f);
                        float fRot = 192.9981f;
                        AddVeh("BURRITO", VPos, fRot, 7, iSelect, 6);

                    }           //Chinese textile city, Vs-- korean
                    else if (iSubSet == 5)
                    {
                        DataStore.vPedTarget = new Vector3(-213.9494f, -1467.139f, 30.95105f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-224.047f, -1487.307f, 30.99617f);
                        float fRot = 140.3711f;
                        AddVeh("BALLER", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-218.7061f, -1491.246f, 30.95563f);
                        fRot = 139.3282f;
                        AddVeh("TORNADO2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-301.5466f, -1441.86f, 30.96148f);
                        fRot = 273.4159f;
                        AddVeh("EMPEROR", VPos, fRot, 7, iSelect, 3);

                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"), DataStore.GP_Player);
                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_FAMILY"));
                        DataStore.iGrouping = 2;
                    }           //Families --Strawberry--Chamberlain Hills, Vs  Ballas
                    else if (iSubSet == 6)
                    {
                        DataStore.vPedTarget = new Vector3(-741.7715f, -1069.828f, 11.82483f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-755.6411f, -1035.036f, 12.59574f);
                        float fRot = 118.859f;
                        AddVeh("KURUMA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-737.267f, -1032.804f, 12.42186f);
                        fRot = 299.1285f;
                        AddVeh("ELEGY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-751.9888f, -1041.709f, 12.31588f);
                        fRot = 116.6273f;
                        AddVeh("FUTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-741.7025f, -1045.407f, 12.05153f);
                        fRot = 23.04387f;
                        AddVeh("FUTO", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-696.5001f, -1061.766f, 14.30107f);
                        fRot = 125.0344f;
                        AddVeh("DUBSTA2", VPos, fRot, 7, iSelect, 4);
                    }            //Korean --K-town, Vs Chinesse
                    else if (iSubSet == 7)
                    {
                        DataStore.vPedTarget = new Vector3(312.4672f, -2021.409f, 20.13354f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(323.1364f, -2023.899f, 20.57834f);
                        float fRot = 143.4038f;
                        AddVeh("ELEGY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(320.1991f, -2034.714f, 20.33097f);
                        fRot = 323.2342f;
                        AddVeh("FUTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(329.5031f, -2030.321f, 20.78702f);
                        fRot = 141.8689f;
                        AddVeh("KURUMA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(336.029f, -2037.448f, 20.90948f);
                        fRot = 90.30424f;
                        AddVeh("Z190", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(274.7089f, -2033.892f, 18.23305f);
                        fRot = 316.9213f;
                        AddVeh("RUMPO3", VPos, fRot, 7, iSelect, 9);

                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"), DataStore.GP_Player);
                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_MEXICAN"));
                        DataStore.iGrouping = 3;
                    }           //Mexican --Rancho--Central Cypress Flats, Vs Salvadoran
                    else if (iSubSet == 8)
                    {
                        DataStore.vPedTarget = new Vector3(-768.7001f, 5539.55f, 33.00449f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(-753.3419f, 5531.84f, 33.00214f);
                        float fRot = 31.34572f;
                        AddVeh("PANTO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-747.302f, 5535.622f, 33.00214f);
                        fRot = 28.5319f;
                        AddVeh("RHAPSODY", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-759.3707f, 5547.82f, 33.00235f);
                        fRot = 177.4559f;
                        AddVeh("BRIOSO", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(-752.3031f, 5547.335f, 33.00233f);
                        fRot = 177.423f;
                        AddVeh("BLISTA3", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(-773.9064f, 5511.155f, 34.17496f);
                        fRot = 28.73141f;
                        AddVeh("SLAMVAN2", VPos, fRot, 7, iSelect, 10);
                    }           //Polynesian -- ? -- Lost
                    else if (iSubSet == 9)
                    {
                        DataStore.vPedTarget = new Vector3(1165.813f, -1671.361f, 35.95022f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(1166.919f, -1643.647f, 36.44419f);
                        float fRot = 177.7492f;
                        AddVeh("MANANA", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1154.781f, -1657.428f, 36.08745f);
                        fRot = 116.5546f;
                        AddVeh("REBEL", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1157.266f, -1661.953f, 36.12128f);
                        fRot = 117.0901f;
                        AddVeh("PEYOTE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(1153.491f, -1650.302f, 36.03091f);
                        fRot = 28.40678f;
                        AddVeh("TORNADO2", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(1223.305f, -1684.305f, 39.15781f);
                        fRot = 115.6373f;
                        AddVeh("RUMPO3", VPos, fRot, 7, iSelect, 7);

                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"), DataStore.GP_Player);
                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_SALVA"));
                        DataStore.iGrouping = 4;
                    }           //"Salvadoran --El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal, Vs Mexican
                    else if (iSubSet == 10)
                    {
                        DataStore.vPedTarget = new Vector3(990.1187f, -170.0182f, 71.56162f);//veh end

                        for (int i = 0; i < Pos_01.Count; i++)
                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), Pos_01[i], fHeading[i], 1, 5, null, true);

                        Vector3 VPos = new Vector3(981.2489f, -128.9782f, 73.09866f);
                        float fRot = 63.50796f;
                        AddVeh("DAEMON2", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(965.4485f, -119.1682f, 73.82195f);
                        fRot = 216.7741f;
                        AddVeh("GARGOYLE", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(971.0372f, -115.0153f, 73.82298f);
                        fRot = 218.4778f;
                        AddVeh("CLIFFHANGER", VPos, fRot, 13, iSelect, iSubSet);

                        VPos = new Vector3(979.4431f, -133.8394f, 72.97166f);
                        fRot = 62.28038f;
                        AddVeh("DAEMON", VPos, fRot, 11, iSelect, iSubSet);

                        VPos = new Vector3(961.9417f, -137.4299f, 73.6806f);
                        fRot = 322.8134f;
                        AddVeh("MOONBEAM2", VPos, fRot, 7, iSelect, 1);

                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"), DataStore.GP_Player);
                        Function.Call(Hash.SET_RELATIONSHIP_BETWEEN_GROUPS, 0, DataStore.GP_Player, Function.Call<int>(Hash.GET_HASH_KEY, "AMBIENT_GANG_LOST"));
                        DataStore.iGrouping = 5;
                    }           //Lost ... Vs Impex
                    else if (iSubSet == 11)
                    {
                        int iLocate = RsReturns.RandInt(0, Pos_01.Count() - 1);

                        Game.Player.Character.Position = Pos_01[iLocate];
                        Game.Player.Character.Heading = fHeading[iLocate];

                        Script.Wait(1000);
                        FindReplacePed(1, Pos_01[iLocate], 55.00f, RsReturns.RandInt(3, 6), 2, 1, false);

                        DataStore.iWait4 = Game.GameTime + 8000;
                        DataStore.iPostAction = 8;
                    }           //Street Punk-- Vs Old Ladys
                }       //GangStar--Fixup..
                else if (iAction == 7)
                {
                    DataStore.RanLoc_01.Clear();
                    DataStore.RanLoc_01 = Pos_01;

                    DataStore.iPath = RsReturns.RandInt(1, DataStore.RanLoc_01.Count() - 1);
                    Game.Player.Character.Position = DataStore.RanLoc_01[DataStore.iPath];

                    DataStore.iPostAction = 4;
                }       //JogOn
                else if (iAction == 8)
                {
                    if (iSubSet == 7)
                    {
                        int iPlace = Pos_01.Count();
                        if (iPlace < 1)
                        {
                            UI.Notify("~r~Debug ~w~No Pos_01's");
                        }
                        else
                        {
                            if (iPlace == 1)
                                iPlace = 0;
                            else
                                iPlace = RsReturns.RandInt(0, iPlace - 1);
                            AddVeh(RsReturns.BuildRandVeh(iSelect, iSubSet), Pos_01[iPlace], fHeading[iPlace], 1, iSelect, iSubSet);
                            DataStore.iPostAction = 1;
                        }
                    }
                    else
                    {
                        DataStore.RanLoc_01.Clear();
                        DataStore.RanLoc_01 = Pos_01;

                        DataStore.iPath = RsReturns.RandInt(1, DataStore.RanLoc_01.Count() - 1);
                        DataStore.vPlayerTarget = DataStore.RanLoc_01[DataStore.iPath];
                        AddVeh(RsReturns.BuildRandVeh(iSelect, iSubSet), DataStore.vPlayerTarget, fHeading[DataStore.iPath], iEnterVeh, iSelect, iSubSet);

                        DataStore.iPostAction = 5;
                    }
                }       //Cycles
                else if (iAction == 9)
                {
                    AddVeh(RsReturns.BuildRandVeh(iSelect, iSubSet), Pos_01[Pos_01.Count() - 1], fHeading[Pos_01.Count() - 1], 10, iSelect, iSubSet);
                    DataStore.iPostAction = 6;
                }       //HelihathNoFury
                else if (iAction == 10)
                {
                    DataStore.RanLoc_01.Clear();
                    DataStore.RanLoc_01 = Pos_01;
                    DataStore.fHeads = fHeading;

                    DataStore.iPath = RsReturns.RandInt(1, DataStore.RanLoc_01.Count() - 1);
                    DataStore.vPlayerTarget = Pos_01[DataStore.iPath];
                    AddVeh(RsReturns.BuildRandVeh(iSelect, iSubSet), DataStore.vPlayerTarget, fHeading[DataStore.iPath], iEnterVeh, 3, 0);
                    DataStore.iPostAction = 7;
                }      //Helitour
                else if (iAction == 11)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);

                    Game.Player.Character.Position = Pos_01[iPlace];

                    if (fHeading.Count() == Pos_01.Count())
                        Game.Player.Character.Heading = fHeading[iPlace];
                    else
                        Game.Player.Character.Heading = (float)RsReturns.RandInt(0, 360);

                    if (iSelect > 5)
                    {
                        for (int i = 0; i < RsReturns.RandInt(2, 5); i++)
                        {
                            Vector3 vRonud = Pos_01[iPlace].Around(10.00f);
                            vRonud.Z = World.GetGroundHeight(vRonud) + 0.50f;

                            NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), vRonud, (float)RsReturns.RandInt(0, 360), 1, 0, null, true);
                        }
                    }

                    MethEdd(false);
                    DataStore.iWait4 = Game.GameTime + 8000;
                    DataStore.iPostAction = 8;
                }      //MethActing
                else if (iAction == 12)
                {
                    int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);
                    Game.Player.Character.Position = Pos_01[iPlace];

                    List<string> DanceSteps = new List<string>();
                    if (Game.Player.Character.Gender == Gender.Male)
                        DanceSteps = RsReturns.DanceList(true, RsReturns.RandInt(1, 3));
                    else
                        DanceSteps = RsReturns.DanceList(false, RsReturns.RandInt(1, 3));

                    if (DanceSteps.Count() > 0)
                        ForceAnim(Game.Player.Character, DanceSteps[0], DanceSteps[1], Game.Player.Character.Position, new Vector3(0.00f, 0.00f, fHeading[iPlace]));

                    DataStore.sExitAn_01 = "";
                    DataStore.sExitAn_02 = "";
                    DataStore.iPostAction = 2;
                }      //Dancing
                else if (iAction == 13)
                {
                    string sChair = "prop_table_03_chr";
                    bool bSeated = false;
                    Game.Player.Character.Position = Pos_01[0];
                    Game.Player.Character.Heading = fHeading[0];
                    Script.Wait(1000);

                    Prop[] PChair = World.GetNearbyProps(Pos_01[0], 2.00f);

                    for (int i = 0; i < PChair.Count(); i++)
                    {
                        if (PChair[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sChair) && !bSeated)
                        {
                            Vector3 CHpos = new Vector3(PChair[i].Position.X, PChair[i].Position.Y, PChair[i].Position.Z + 0.50f) - (PChair[i].ForwardVector * 0.15f);
                            PedScenario(Game.Player.Character, "PROP_HUMAN_SEAT_CHAIR", CHpos, PChair[i].Heading - 180.00f, true);

                            bSeated = true;
                            break;
                        }
                    }
                    DataStore.iPostAction = 1;
                }      //Sitting

                Script.Wait(2000);
                Game.FadeScreenIn(1000);
                Script.Wait(1000);
                Game.Player.Character.IsInvincible = false;
            }
            else
            {
                int iPlace = RsReturns.RandInt(0, Pos_01.Count() - 1);

                Game.Player.Character.Position = Pos_01[iPlace];

                if (fHeading.Count() == Pos_01.Count())
                    Game.Player.Character.Heading = fHeading[iPlace];
                else
                    Game.Player.Character.Heading = (float)RsReturns.RandInt(0, 360);

                if (iSelect > 5 && iSelect != 24)
                {
                    for (int i = 0; i < RsReturns.RandInt(2, 5); i++)
                    {
                        Vector3 vRonud = Pos_01[iPlace].Around(10.00f);
                        vRonud.Z = World.GetGroundHeight(vRonud) + 0.50f;

                        NPCSpawn(RsReturns.BuildRandomPed(iSelect, iSubSet), vRonud, (float)RsReturns.RandInt(0, 360), 1, 0, null, true);
                    }
                }

                Script.Wait(2000);
                Game.FadeScreenIn(1000);
                CleanUpMess();
                Script.Wait(1000);
                Game.Player.Character.IsInvincible = false;
            }

            if (bRequestPB)
            {
                DataStore.vAreaRest = Game.Player.Character.Position;
                AccessAllAreas();
            }

            if (DataStore.bInCayoPerico)
            {
                Function.Call(Hash.SET_VEHICLE_POPULATION_BUDGET, 3);
                Function.Call(Hash.SET_PED_POPULATION_BUDGET, 3);
            }

            if (!DataStore.MySettingsXML.KeepWeapons)
            {
                Game.Player.Character.Weapons.RemoveAll();

                if (iWeapons != 0)
                    PedWeapons(Game.Player.Character, iWeapons);
            }
        }
        public static void YourRanPed(string PedName)
        {
            LoggerLight.Loggers("YourRanPed, PedName == " + PedName);
            DataStore.iCurrentPed = 0;
            var model = new Model(PedName);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                DataStore.iAmModelHash = model.Hash;
                while (!model.IsLoaded)
                    Script.Wait(1);
                Game.Player.ChangeModel(model);

                if (RsReturns.GetMainChar())
                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
                else
                    Function.Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, Game.Player.Character.Handle, false);

                int iHats = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, 0);
                Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, 0, RsReturns.RandInt(-1, iHats), 0, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);
            }
            if (DataStore.MySettingsXML.KeepWeapons)
                ReturnWeaps();

            PlayerBelter();

            if (DataStore.GP_Player != Game.Player.Character.RelationshipGroup)
                SetPlayRellGrp();
        }
        public static void YourPickedPed(Ped ThisPed)
        {
            LoggerLight.Loggers("YourPickedPed");
            if (ThisPed != null)
            {
                DataStore.iCurrentPed = 0;
                DataStore.iAmModelHash = ThisPed.Model.Hash;
                Ped CurrentPlayer = Game.Player.Character;

                Function.Call(Hash.CHANGE_PLAYER_PED, Function.Call<int>(Hash.PLAYER_ID), ThisPed.Handle, true, true);

                if (CurrentPlayer != Game.Player.Character)
                    CurrentPlayer.MarkAsNoLongerNeeded();

                if (DataStore.MySettingsXML.KeepWeapons)
                    ReturnWeaps();

                PlayerBelter();

                if (DataStore.GP_Player != Game.Player.Character.RelationshipGroup)
                    SetPlayRellGrp();
            }
        }
        public static void YourSavedPed()
        {
            LoggerLight.Loggers("YourSavedPed");

            if (DataStore.MyPedCollection.Count > 0)
            {
                DataStore.iCurrentPed = RsReturns.RandInt(1, DataStore.MyPedCollection.Count - 1);
                SavePedLoader(DataStore.iCurrentPed);
            }
            else
                DataStore.MySettingsXML.Saved = false;
        }
        public static void SavePedLoader(int iBe)
        {
            LoggerLight.Loggers("SavePedLoader, ");

            NewClothBank MyWoven = DataStore.MyPedCollection[iBe];

            var model = new Model(MyWoven.ModelX);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                DataStore.iAmModelHash = model.Hash;

                while (!model.IsLoaded)
                    Script.Wait(1);
                Game.Player.ChangeModel(model);

                DataStore.sFirstName = MyWoven.Name;
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                FillMyPed(MyWoven);
            }
            if (DataStore.MySettingsXML.KeepWeapons)
                ReturnWeaps();

            PlayerBelter();

            if (DataStore.GP_Player != Game.Player.Character.RelationshipGroup)
                SetPlayRellGrp();
        }
        public static void FillMyPed(NewClothBank MyWoven)
        {
            LoggerLight.Loggers("FillMyPed, ");
            Ped Peddy = Game.Player.Character;
            for (int i = 0; i < MyWoven.ClothA.Count; i++)
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Peddy.Handle, i, MyWoven.ClothA[i], MyWoven.ClothB[i], 2);

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Peddy.Handle);

            for (int i = 0; i < MyWoven.ExtraA.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Peddy.Handle, i, MyWoven.ExtraA[i], MyWoven.ExtraB[i], false);

            for (int i = 0; i < MyWoven.Tattoo_COl.Count; i++)
                Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, MyWoven.Tattoo_COl[i]), Function.Call<int>(Hash.GET_HASH_KEY, MyWoven.Tattoo_Nam[i]));

            if (MyWoven.PedVoice != "")
                Function.Call(Hash.SET_AMBIENT_VOICE_NAME, Game.Player.Character.Handle, MyWoven.PedVoice);

            if (MyWoven.FreeMode)
            {
                Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Peddy.Handle, MyWoven.XshapeFirstID, MyWoven.XshapeSecondID, MyWoven.XshapeThirdID, MyWoven.XskinFirstID, MyWoven.XskinSecondID, MyWoven.XskinThirdID, MyWoven.XshapeMix, MyWoven.XskinMix, MyWoven.XthirdMix, false);

                Function.Call(Hash._SET_PED_HAIR_COLOR, Peddy.Handle, MyWoven.HairColour, MyWoven.HairStreaks);
                Function.Call(Hash._SET_PED_EYE_COLOR, Peddy.Handle, MyWoven.EyeColour);

                for (int i = 0; i < MyWoven.Overlay.Count; i++)
                {
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Peddy.Handle, i, MyWoven.Overlay[i], MyWoven.OverlayOpc[i]);

                    if (i == 1 || i == 2 || i == 10)
                        Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Peddy.Handle, i, 1, MyWoven.OverlayColour[i], 0);
                    else if (i == 5 || i == 8)
                        Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Peddy.Handle, i, 2, MyWoven.OverlayColour[i], 0);
                }

                for (int i = 0; i < MyWoven.FaceScale.Count; i++)
                    Function.Call(Hash._SET_PED_FACE_FEATURE, Game.Player.Character.Handle, i, MyWoven.FaceScale[i]);
            }
        }
        public static void AddVeh(string sVehic, Vector3 Vpos, float fHead, int iEnterV, int iPedtype, int iSubType)
        {

            LoggerLight.Loggers("AddVeh, sVehic == " + sVehic + ", iEnterV == " + iEnterV + ", iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            int iVehHash = Function.Call<int>(Hash.GET_HASH_KEY, sVehic);

            if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iVehHash) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, iVehHash))
            {
                Function.Call(Hash.REQUEST_MODEL, iVehHash);
                while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iVehHash))
                    Script.Wait(1);
                Vehicle Vehic = Function.Call<Vehicle>(Hash.CREATE_VEHICLE, iVehHash, Vpos.X, Vpos.Y, Vpos.Z, fHead, true, true);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iVehHash);
                Vehic.IsPersistent = true;
                DataStore.VehList.Add(new Vehicle(Vehic.Handle));

                MaxMods(Vehic);

                if (iEnterV > 0)
                    EnterVeh(Vehic, iEnterV, iPedtype, iSubType);

            }
            else
            {
                Script.Wait(500);
                AddVeh(RsReturns.BuildRandVeh(iPedtype, iSubType), Vpos, fHead, iEnterV, iPedtype, iSubType);
            }
        }
        public static void MaxMods(Vehicle Vehic)
        {

            LoggerLight.Loggers("MaxMods");

            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Vehic.Handle, 0);
            bool bMotoBike = Vehic.ClassType == VehicleClass.Motorcycles;
            for (int i = 0; i < 50; i++)
            {
                int iSpoilher = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Vehic.Handle, i);

                if (i == 11 || i == 12 || i == 13 || i == 15 || i == 16)
                    Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, iSpoilher - 1, true);
                else if (i == 18 || i == 22)
                {

                }
                else if (i == 24)
                {
                    if (bMotoBike)
                        Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, Function.Call<int>(Hash.GET_VEHICLE_MOD, Vehic.Handle, 23), true);
                }
                else
                {
                    if (iSpoilher != 0)
                        Function.Call(Hash.SET_VEHICLE_MOD, Vehic.Handle, i, RsReturns.RandInt(0, iSpoilher - 1), true);
                }
            }
            if (Vehic.ClassType != VehicleClass.Cycles || Vehic.ClassType != VehicleClass.Helicopters || Vehic.ClassType != VehicleClass.Boats || Vehic.ClassType != VehicleClass.Planes)
            {
                Vehic.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Vehic.ToggleMod(VehicleToggleMod.Turbo, true);
            }
        }
        public static void EnterVeh(Vehicle Vehic, int iEnterV, int iPedtype, int iSubType)
        {

            LoggerLight.Loggers("EnterVeh, iEnterV == " + iEnterV + ", iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            Vector3 V3 = Vehic.Position + (Vehic.RightVector * 3.50f);

            if (iEnterV == 1)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = DataStore.vPlayerTarget.X - Vehic.Position.X;
                    float dy = DataStore.vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);

                    if (DataStore.vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, DataStore.vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }
            }       //Player Only
            else if (iEnterV == 2)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = DataStore.vPlayerTarget.X - Vehic.Position.X;
                    float dy = DataStore.vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    if (DataStore.vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, DataStore.vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }

                if (Vehic.PassengerSeats > 0)
                    NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 4, 0, Vehic, true);
            }      //Player One Passenger
            else if (iEnterV == 3)
            {
                if (Vehic.ClassType == VehicleClass.Planes)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    Function.Call(Hash.TASK_PLANE_MISSION﻿, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, 100.0f, 0.0f, 90.0f, 0, 600.0f);
                }
                else if (Vehic.ClassType == VehicleClass.Helicopters)
                {
                    Game.Player.Character.Position = V3;
                    YouTheDriver(Vehic, Game.Player.Character);
                    Script.Wait(500);
                    float HeliSpeed = 75.00f;

                    float dx = DataStore.vPlayerTarget.X - Vehic.Position.X;
                    float dy = DataStore.vPlayerTarget.Y - Vehic.Position.Y;
                    float HeliDirect = Function.Call<float>(Hash.GET_HEADING_FROM_VECTOR_2D, dx, dy) - 180.00f;
                    Function.Call(Hash.TASK_HELI_MISSION, Game.Player.Character.Handle, Vehic.Handle, 0, 0, DataStore.vPlayerTarget.X, DataStore.vPlayerTarget.Y, DataStore.vPlayerTarget.Z, 4, HeliSpeed, 0, HeliDirect, -1, -1, -1, 0);
                }
                else
                {
                    Game.Player.Character.Position = V3;
                    while (!Game.Player.Character.IsInVehicle())
                    {
                        YouTheDriver(Vehic, Game.Player.Character);
                        Script.Wait(10);
                    }
                    if (DataStore.vPlayerTarget != Vector3.Zero)
                        Game.Player.Character.Task.DriveTo(Vehic, DataStore.vPlayerTarget, 3.00f, 35.00f);
                    else
                        Game.Player.Character.Task.CruiseWithVehicle(Vehic, 35.00f);
                }
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 4, 0, true);
            }      //Player + full vehicle
            else if (iEnterV == 4)
            {
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 3, 0, Vehic, true);
            }      //Rand Ped
            else if (iEnterV == 5)
            {
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 3, 0, Vehic, true);
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 4, 0, true);
            }      //Rand Ped + Fill Veh
            else if (iEnterV == 6)
            {
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 5, 5, Vehic, false);
            }      //Rand Ped --Attacker
            else if (iEnterV == 7)
            {
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 5, 0, Vehic, false);
                FillthisVeh(Vehic, iPedtype, iSubType, V3, 6, 5, false);
            }      //Rand Ped --Attacker + Fill Veh
            else if (iEnterV == 8)
            {
                Vehic.AddBlip();
                Vehic.CurrentBlip.Sprite = BlipSprite.HelicopterAnimated;
                DataStore.PrisEscape = Vehic;
                DataStore.bPrisHeli = true;
            }      //Prison Heli
            else if (iEnterV == 9)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);
                DataStore.bAllowControl = false;
                Script.Wait(4000);
                CleanUpMess();
            }      //Golf Cart
            else if (iEnterV == 10)
            {
                DataStore.Shoaf = Vehic;
                Vehic.EngineRunning = true;
                if (Vehic.ClassType == VehicleClass.Helicopters)
                    NPCSpawn(RsReturns.BuildRandomPed(22, 4), V3, 0.00f, 8, 0, Vehic, true);
                else
                    NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 9, 0, Vehic, true);
                while (!Game.Player.Character.IsInVehicle(Vehic))
                {
                    Game.Player.Character.Task.WarpIntoVehicle(Vehic, VehicleSeat.RightRear);
                    Script.Wait(10);
                }
            }      //Player is Passenger
            else if (iEnterV == 11)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);
            }      //Player Driver no driving
            else if (iEnterV == 12)
            {
                Game.Player.Character.Position = V3;
                YouTheDriver(Vehic, Game.Player.Character);

                if (Vehic.PassengerSeats > 0)
                    NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 4, 0, Vehic, true);

                FindCrimo(V3, 125.00f, 10.00f);

                Script.Wait(500);
            }      //Cop Chase
            else if (iEnterV == 13)
            {
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), V3, 0.00f, 11, 0, Vehic, true);
            }      //Ped Wait in Vehicle
        }
        public static void FillthisVeh(Vehicle Vehic, int iPedtype, int iSubType, Vector3 vPos, int iTask, int iWeapons, bool bFriend)
        {

            LoggerLight.Loggers("FillthisVeh, iPedtype == " + iPedtype + ", iSubType == " + iSubType + ", iTask == " + iTask);

            for (int i = 0; i < Vehic.PassengerSeats; i++)
                NPCSpawn(RsReturns.BuildRandomPed(iPedtype, iSubType), vPos, 0.00f, iTask, iWeapons, Vehic, bFriend);
        }
        public static void PropTasks(Prop Popp, int iPopTask)
        {

            LoggerLight.Loggers("PropTasks, iPopTask == " + iPopTask);

            if (iPopTask == 1)
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Popp.Handle, Game.Player.Character.Handle, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);
            else if (iPopTask == 2)
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, Popp.Handle, Game.Player.Character.Handle, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, false, false, true, false, 2, true);
        }
        public static void CayoNPCSpawn(string sPed, Prop pMyChair, Vector3 Vpos, float fAce, int iTask)
        {

            LoggerLight.Loggers("CayoNPCSpawn, sPed == " + sPed + ", iTask == " + iTask);

            Vector3 vLocal = Vpos;
            float fDir = fAce;
            if (pMyChair != null)
            {
                vLocal = pMyChair.Position;
                fDir = pMyChair.Heading - 180.00f;
            }
            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Script.Wait(1);
                Ped Peddy = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fDir, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (pMyChair != null)
                {
                    List<string> SitVArs = new List<string>();

                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_DRINK");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_DRINK_BEER");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_FOOD");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_UPRIGHT");
                    SitVArs.Add("PROP_HUMAN_SEAT_CHAIR_MP_PLAYER");

                    PedScenario(Peddy, SitVArs[RsReturns.RandInt(0, SitVArs.Count() - 1)], pMyChair.Position, pMyChair.Heading - 180.00f, true);
                }
                else
                {
                    if (iTask > 0)
                        PedTasks(Peddy, iTask, null);
                }

                DataStore.PedParty.Add(new Ped(Peddy.Handle));
            }
        }
        public static void NPCSpawn(string sPed, Vector3 vLocal, float fAce, int iTask, int iWeapons, Vehicle Vehicary, bool bFriend)
        {

            LoggerLight.Loggers("NPCSpawn, sPed == " + sPed + ", iTask == " + iTask);

            var model = new Model(sPed);
            model.Request();    // Check if the model is valid
            if (model.IsInCdImage && model.IsValid)
            {
                while (!model.IsLoaded)
                    Script.Wait(1);
                Ped Peddy = Function.Call<Ped>(Hash.CREATE_PED, 4, model, vLocal.X, vLocal.Y, vLocal.Z, fAce, false, false);
                Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model.Hash);

                if (iWeapons > 0)
                    PedWeapons(Peddy, iWeapons);
                if (iTask > 0)
                    PedTasks(Peddy, iTask, Vehicary);

                if (bFriend)
                    Peddy.RelationshipGroup = DataStore.GP_Friend;
                else
                    Peddy.RelationshipGroup = DataStore.GP_Attack;
                DataStore.PeddyList.Add(new Ped(Peddy.Handle));
            }
        }
        public static void PedTasks(Ped Peddy, int iTask, Vehicle Vehicary)
        {

            LoggerLight.Loggers("NPCSpawn, iTask == " + iTask);

            if (iTask == 1)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = DataStore.GP_Friend;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 1);
            }            //FriendPed
            else if (iTask == 2)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Peddy.Task.FightAgainst(Game.Player.Character);
                Peddy.AlwaysKeepTask = true;
            }       //EnemyPed
            else if (iTask == 3)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = DataStore.GP_Friend;

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.Wait(-1);
                }
            }       //FriendDriver
            else if (iTask == 4)
            {
                if (Vehicary != null)
                    PedFindMeASeat(Vehicary, Peddy);
            }       //FriendPassenger
            else if (iTask == 5)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);
                Peddy.Task.FightAgainst(Game.Player.Character);

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);

                    if (DataStore.vPedTarget != Vector3.Zero)
                        Peddy.Task.DriveTo(Vehicary, DataStore.vPedTarget, 3.00f, 35.00f);
                    else
                        Peddy.Task.CruiseWithVehicle(Vehicary, 35.00f);

                    Peddy.AlwaysKeepTask = true;
                }
            }       //EnemyDriver
            else if (iTask == 6)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Peddy.Task.FightAgainst(Game.Player.Character);

                if (Vehicary != null)
                    PedFindMeASeat(Vehicary, Peddy);
            }       //EnemyPassenger
            else if (iTask == 7)
            {
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.TASK_SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, Peddy.Handle, true);

                ForceAnim(Peddy, "amb@world_human_bum_standing@depressed@base", "base", Peddy.Position, Peddy.Rotation);
            }       //SolomPriest
            else if (iTask == 8)
            {
                DataStore.pPilot = Peddy;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    DataStore.iPath = 0;
                    DataStore.iPostAction = 6;
                    Vehicary.Position = DataStore.RanLoc_01[DataStore.iPath];
                    DataStore.iPath += 1;
                    FlyHeliHere(DataStore.RanLoc_01[DataStore.iPath], DataStore.fHeads[DataStore.iPath], Vehicary, DataStore.pPilot, false);
                }
            }       //HeliPilot
            else if (iTask == 9)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = DataStore.GP_Friend;

                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.CruiseWithVehicle(Vehicary, 12.00f);
                }
            }       //FriendDriver--Driving
            else if (iTask == 10)
            {
                Peddy.Accuracy = 55;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.IsEnemy = true;
                Peddy.CanBeTargette﻿d﻿ = true;
                Peddy.RelationshipGroup = DataStore.GP_Attack;
                if (Vehicary != null)
                {
                    YouTheDriver(Vehicary, Peddy);
                    Peddy.Task.FleeFrom(Game.Player.Character);
                }
            }       //EnemyDriverfleeing
            else if (iTask == 11)
            {
                Peddy.Accuracy = 75;
                Peddy.MaxHealth = 150;
                Peddy.Health = 150;
                Peddy.CanBeTargette﻿d﻿ = false;
                Peddy.RelationshipGroup = DataStore.GP_Friend;
                Function.Call(Hash.SET_PED_FLEE_ATTRIBUTES, Peddy.Handle, 0, true);
                Function.Call(Hash.SET_PED_COMBAT_MOVEMENT, Peddy.Handle, 1);
                if (Vehicary != null)
                    YouTheDriver(Vehicary, Peddy);
            }       //PedWait
            else if (iTask == 12)
            {
                List<string> DanceSteps = new List<string>();
                if (Peddy.Gender == Gender.Male)
                    DanceSteps = RsReturns.DanceList(true, RsReturns.RandInt(1, 3));
                else
                    DanceSteps = RsReturns.DanceList(false, RsReturns.RandInt(1, 3));

                if (DanceSteps.Count() > 0)
                    ForceAnim(Peddy, DanceSteps[0], DanceSteps[1], Peddy.Position, Peddy.Rotation);
            }       //PedDance-fast?
            else if (iTask == 13)
            {

            }       //Blank
            else if (iTask == 14)
            {
                List<string> DanceSteps = new List<string>();
                if (Peddy.Gender == Gender.Male)
                    DanceSteps = RsReturns.DanceList(true, RsReturns.RandInt(1, 3));
                else
                    DanceSteps = RsReturns.DanceList(false, RsReturns.RandInt(1, 3));

                if (DanceSteps.Count() > 0)
                    ForceAnim(Peddy, DanceSteps[0], DanceSteps[1], Peddy.Position, Peddy.Rotation);
            }       //SLow Dance
            else if (iTask == 15)
            {
                if (Peddy.Gender == Gender.Male)
                    ForceAnim(Peddy, "amb@world_human_sunbathe@male@back@base", "base", Peddy.Position, Peddy.Rotation);
                else
                    ForceAnim(Peddy, "amb@world_human_sunbathe@female@back@base", "base", Peddy.Position, Peddy.Rotation);
            }       //sun back
            else if (iTask == 16)
            {
                if (Peddy.Gender == Gender.Male)
                    ForceAnim(Peddy, "amb@world_human_sunbathe@male@front@base", "base", Peddy.Position, Peddy.Rotation);
                else
                    ForceAnim(Peddy, "amb@world_human_sunbathe@female@front@base", "base", Peddy.Position, Peddy.Rotation);
            }       //sun front
        }
        public static void PedWeapons(Ped Peddy, int iWeapons)
        {
            LoggerLight.Loggers("PedWeapons, iWeapons == " + iWeapons);

            if (iWeapons == 1)
            {
                string sYourWeap = DataStore.sWeapList[RsReturns.RandInt(0, 17)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Melee
            else if (iWeapons == 2)
            {
                string sYourWeap = DataStore.sWeapList[RsReturns.RandInt(18, 33)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Hand
            else if (iWeapons == 3)
            {
                string sYourWeap = DataStore.sWeapList[RsReturns.RandInt(55, 64)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just Assult
            else if (iWeapons == 4)
            {
                string sYourWeap = DataStore.sWeapList[RsReturns.RandInt(45, 54)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //Just ShotGun
            else if (iWeapons == 5)
            {
                string sYourWeap = DataStore.sWeapList[RsReturns.RandInt(0, 17)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = DataStore.sWeapList[RsReturns.RandInt(18, 33)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = DataStore.sWeapList[RsReturns.RandInt(45, 54)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);

                sYourWeap = DataStore.sWeapList[RsReturns.RandInt(55, 64)];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //RandomCombos
            else
            {
                string sYourWeap = DataStore.sWeapList[6];
                Function.Call(Hash.GIVE_WEAPON_TO_PED, Peddy.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sYourWeap), RsReturns.MaxAmmo(sYourWeap, Peddy), false, true);
            }       //GolfClub
        }
        public static void PedFindMeASeat(Vehicle Vhick, Ped Peddy)
        {

            LoggerLight.Loggers("PedFindMeASeat");

            while (!Peddy.IsInVehicle())
            {
                Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, Peddy.Handle, Vhick.Handle, -2);
                Script.Wait(10);
            }
        }
        public static void YouTheDriver(Vehicle Vhick, Ped Peddy)
        {

            LoggerLight.Loggers("YouTheDriver");

            while (!Peddy.IsInVehicle())
            {
                Function.Call(Hash.TASK_ENTER_VEHICLE, Peddy.Handle, Vhick.Handle, -1, -1, 2.00f, 16, 0);
                Script.Wait(10);
            }
        }
        public static void FindReplacePed(int iAnyPedList, Vector3 vZone, float fRadius, int iCountEm, int iTask, int iWeapons, bool bFriend)
        {

            LoggerLight.Loggers("FindReplacePed, iCountEm == " + iCountEm + ", iTask == " + iTask);

            Ped[] MadPeds = World.GetNearbyPeds(vZone, fRadius);
            for (int i = 0; i < MadPeds.Count(); i++)
            {
                if (iCountEm > 0)
                {
                    Ped MadP = MadPeds[i];
                    if (!MadP.IsOnScreen && !MadP.IsInVehicle() && Function.Call<int>(Hash.GET_PED_TYPE, MadP.Handle) != 28 && MadP != Game.Player.Character && !MadP.IsPersistent)
                    {
                        iCountEm -= 1;
                        NPCSpawn(RsReturns.AddAnyPed(iAnyPedList), MadP.Position, MadP.Heading, iTask, iWeapons, null, bFriend);
                        MadP.Delete();
                    }
                }
                else
                    break;
            }
            if (iCountEm > 0)
            {
                Script.Wait(500);
                FindReplacePed(iAnyPedList, vZone, 100.00f, iCountEm, iTask, iWeapons, bFriend);
            }
        }
        public static void RandomWeatherTime()
        {
            LoggerLight.Loggers("RandomWeatherTime");

            int iTimes = RsReturns.FindRandom(0, 0, 23);
            double dTime = (int)iTimes;
            int iRain = RsReturns.FindRandom(15, 0, 9);
            World.Weather = DataStore.WetherBe[iRain];
            World.CurrentDayTime = TimeSpan.FromHours(dTime);
        }
        public static void SetTimeWeather(Weather TheWeather, double TheTime)
        {
            World.Weather = TheWeather;
            World.CurrentDayTime = TimeSpan.FromHours(TheTime);
        }
        public static void DeathArrestCont(bool bDead, bool bMenuPause)
        {
            LoggerLight.Loggers("DeathArrestCont bProg == " + bDead);

            bool bMale = false;

            if (Game.Player.Character.Gender == Gender.Male)
                bMale = true;
            Game.Player.Character.IsVisible = true;
            Game.Player.Character.HasCollision = true;

            if (bMenuPause)
            {
                if (bDead)
                {
                    while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING))
                        Script.Wait(100);

                    Vector3 VMep = Game.Player.Character.Position;
                    while (!Function.Call<bool>(Hash.IS_PED_MODEL, Game.Player.Character.Handle, DataStore.iAmModelHash) && Game.Player.Character.Position.DistanceTo(VMep) < 45.00f)
                        Script.Wait(100);

                    if (DataStore.MySettingsXML.Reincarn)
                        Game.Player.Character.Position = DataStore.vHeaven;
                    else
                        YourRanPed(DataStore.sMainChar);

                    YouDied(bMale);
                }
                else
                {
                    while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING))
                        Script.Wait(100);

                    Vector3 VMep = Game.Player.Character.Position;
                    while (!Function.Call<bool>(Hash.IS_PED_MODEL, Game.Player.Character.Handle, DataStore.iAmModelHash) && Game.Player.Character.Position.DistanceTo(VMep) < 45.00f)
                        Script.Wait(100);

                    YouArrest();
                }
            }
            else
            {
                if (bDead)
                {
                    if (Game.Player.Character.Position.Z < -1.00f)
                    {
                        while (!Function.Call<bool>(Hash.IS_PLAYER_PLAYING))
                            Script.Wait(100);
                    }
                    Function.Call(Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, Game.Player.Character.Handle);
                    Function.Call(Hash.NETWORK_RESURRECT_LOCAL_PLAYER, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, 0.0, 0.0, 0.0);
                    Function.Call(Hash._RESET_LOCALPLAYER_STATE);
                    Function.Call(Hash.SET_FADE_OUT_AFTER_DEATH, false);

                    if (!DataStore.MySettingsXML.Reincarn)
                        YourRanPed(DataStore.sMainChar);
                    YouDied(bMale);

                    if (DataStore.bDontStopMe)
                    {
                        Game.Player.IgnoredByPolice = false;
                        Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character.Handle, true);
                        Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
                        Function.Call(Has﻿h.REQUEST_SCRIPT, "re_armybase");
                        Script.Wait(100);

                        if (DataStore.bPrisHeli)
                        {
                            DataStore.bPrisHeli = false;
                            DataStore.PrisEscape.CurrentBlip.Remove();
                            DataStore.PrisEscape.MarkAsNoLongerNeeded();
                        }
                        DataStore.bDontStopMe = false;
                    }
                }
                else
                {
                    while (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                        Script.Wait(100);
                    Function.Call(Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, Game.Player.Character.Handle);
                    Function.Call(Hash.RESET_PLAYER_ARREST_STATE, Game.Player.Character.Handle);
                    Function.Call(Hash._RESET_LOCALPLAYER_STATE);
                    Function.Call(Hash.SET_FADE_OUT_AFTER_ARREST, false);

                    YouArrest();
                }

                Function.Call(Hash.DISPLAY_HUD, true);
                Game.Player.Character.FreezePosition = false;
            }

            if (DataStore.bInYankton)
                Yankton(false);
            else if (DataStore.bInCayoPerico)
                CayoPerico(false);
        }
        public static void PlayerBelter()
        {
            Function.Call(Hash.SET_PED_CONFIG_FLAG, Game.Player.Character.Handle, 32, !DataStore.MySettingsXML.BeltUp);
        }
        public static void EveryBodyDies()
        {
            DataStore.DeadWeather = World.Weather;
            DataStore.DeadTime = World.CurrentDayTime.Hours;
            DataStore.vHell = Game.Player.Character.Position;
            DataStore.vHeaven = World.GetNextPositionOnSidewalk(Game.Player.Character.Position);

            if (RsReturns.GetMainChar())
            {
                if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED) || Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                {
                    if (DataStore.bInYankton)
                        Yankton(false);
                    else if (DataStore.bInCayoPerico)
                        CayoPerico(false);
                }
                else if (Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, "director_mode"))
                {
                    Script.Wait(500);
                    Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "director_mode");
                }
            }
            else if (DataStore.bMenyooZZ)
            {
                if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                {
                    if (DataStore.bAllowControl)
                        CleanUpMess();
                    DataStore.bDeadorArrest = true;
                    DeathArrestCont(false, true);
                }
                else if (Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                {
                    if (DataStore.bAllowControl)
                        CleanUpMess();
                    DataStore.bDeadorArrest = true;
                    DeathArrestCont(true, true);
                }
            }
            else
            {
                if (Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, "director_mode"))
                {
                    if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED))
                    {
                        Script.Wait(5000);
                        Game.FadeScreenOut(1);

                        if (DataStore.bAllowControl)
                            CleanUpMess();
                        DataStore.bDeadorArrest = true;
                        DeathArrestCont(false, false);
                    }
                    else if (Function.Call<bool>(Hash.IS_PLAYER_DEAD))
                    {
                        Script.Wait(5000);
                        Game.FadeScreenOut(1);

                        if (DataStore.bAllowControl)
                            CleanUpMess();
                        DataStore.bDeadorArrest = true;
                        DeathArrestCont(true, false);
                    }
                }
                else
                {
                    Script.Wait(500);
                    Function.Call(Hash.REQUEST_SCRIPT, "director_mode");
                }
            }
        }
        public static void YouDied(bool bMale)
        {
            LoggerLight.Loggers("YouDied");

            if (DataStore.bMethActor)
                MethEdd(true);

            if (DataStore.MySettingsXML.Reincarn && !DataStore.bInYankton && !DataStore.bInCayoPerico)
            {
                int iFail = 25;
                if (DataStore.vHell.Z > -1 && World.GetZoneNameLabel(DataStore.vHell) != "JAIL" && World.GetZoneNameLabel(DataStore.vHell) != "ARMYB")
                {
                    while (!RsReturns.SelectingPeds(true) && iFail > 0)
                    {
                        Script.Wait(100);
                        iFail -= 1;
                    }

                    if (iFail < 1)
                        Reicarnations(true);
                    else
                        Reicarnations(false);
                }
                else
                    Reicarnations(true);
            }
            else
            {
                if (DataStore.bInYankton)
                    Yankton(false);
                else if (DataStore.bInCayoPerico)
                    CayoPerico(false);

                SetTimeWeather(Weather.Clear, 12);

                Game.FadeScreenIn(1000);
                RsReturns.MyPropBuild("prop_coffin_01", new Vector3(-278.3422f, 2844.4617f, 52.8818f), new Vector3(-4.20f, 1.015f, -30.6686f), 0, true);

                Vector3 vPriest = new Vector3(-276.5638f, 2844.45f, 53.75225f);
                float fPriest = 134.9461f;
                NPCSpawn("ig_priest", vPriest, fPriest, 7, 0, null, true);

                Vector3 vMorn02 = new Vector3(-281.5462f, 2844.153f, 54.07914f);
                float fMorn02 = 279.358f;
                NPCSpawn(DataStore.sFunChar01, vMorn02, fMorn02, 7, 0, null, true);

                Vector3 vMorn01 = new Vector3(-276.7029f, 2841.419f, 53.96595f);
                float fMorn01 = 29.87679f;
                NPCSpawn(DataStore.sFunChar02, vMorn01, fMorn01, 7, 0, null, true);

                Vector3 vPlayer = new Vector3(-281.0132f, 2840.851f, 54.34494f);
                float fPlayer = 320.0452f;

                Game.Player.Character.Position = vPlayer;
                Game.Player.Character.Heading = fPlayer;

                if (DataStore.sFirstName == "PlayerX" || DataStore.sFirstName == "Current")
                {
                    if (Game.Player.Character.Gender == Gender.Male)
                        DataStore.sFirstName = DataStore.MyNames.MaleName[RsReturns.RandInt(0, DataStore.MyNames.MaleName.Count() - 1)];
                    else
                        DataStore.sFirstName = DataStore.MyNames.FemaleName[RsReturns.RandInt(0, DataStore.MyNames.FemaleName.Count() - 1)];
                }

                int iNameSir = DataStore.MyNames.SurnName.Count();
                if (iNameSir > 0)
                {
                    if (iNameSir == 1)
                    {
                        if (bMale)
                            UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " " + DataStore.MyNames.SurnName[0] + DataStore.MyLang.Langfile[3]);
                        else
                            UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " " + DataStore.MyNames.SurnName[0] + DataStore.MyLang.Langfile[4]);
                    }
                    else
                    {
                        iNameSir = RsReturns.RandInt(0, iNameSir - 1);
                        if (bMale)
                            UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " " + DataStore.MyNames.SurnName[iNameSir] + DataStore.MyLang.Langfile[3]);
                        else
                            UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " " + DataStore.MyNames.SurnName[iNameSir] + DataStore.MyLang.Langfile[4]);
                    }
                }
                else
                {
                    if (bMale)
                        UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " Davis. " + DataStore.MyLang.Langfile[3]);
                    else
                        UI.Notify(DataStore.MyLang.Langfile[2] + DataStore.sFirstName + " Davis. " + DataStore.MyLang.Langfile[4]);
                }

                ReturnWeaps();

                Script.Wait(7000);
                CleanUpMess();
            }
            DataStore.bDeadorArrest = false;
        }
        public static void Reicarnations(bool bDeadZoneEmpty)
        {
            if (bDeadZoneEmpty)
            {
                Script.Wait(10000);
                Game.Player.Character.Task.ClearAll();
                YourRanPed("cs_chrisformage");
                Game.FadeScreenIn(1000);
            }
            else
            {
                SetTimeWeather(DataStore.DeadWeather, DataStore.DeadTime);
                Game.FadeScreenIn(1000);
            }                        
            DataStore.Ahhhhhh.Play();
            Vector3 Campo = Game.Player.Character.Position;
            Vector3 Camro = new Vector3(-90.00f, 0.00f, 0.00f);
            Function.Call(Hash.DISPLAY_RADAR, false);
            Campo.Z += 155.00f;
            Camera cCams = World.CreateCamera(Campo, Camro, 150.00f);
            Function.Call(Hash.RENDER_SCRIPT_CAMS, 1, 1, cCams.Handle, 0, 0);
            Script.Wait(3000);
            while (cCams.Position.Z > Game.Player.Character.Position.Z + 2.00f)
            {
                Campo.Z -= 1.00f;
                cCams.Position = Campo;
                Script.Wait(1);
            }
            Function.Call(Hash.RENDER_SCRIPT_CAMS, 0, 1, 0, 0, 0);
            cCams.Destroy();
            Function.Call(Hash.DISPLAY_RADAR, true);
        }
        public static void YouArrest()
        {
            LoggerLight.Loggers("YouArrest");

            Game.FadeScreenIn(2000);

            if (DataStore.bInYankton)
                Yankton(false);
            else if (DataStore.bInCayoPerico)
                CayoPerico(false);

            AccessAllAreas();
            Vector3 HeliPos = new Vector3(1635.97f, 2628.04f, 44.55f);
            DataStore.vAreaRest = HeliPos;
            float HeliRot = -150.75f;
            AddVeh("POLMAV", HeliPos, HeliRot, 8, 0, 0);

            UI.Notify(DataStore.MyLang.Langfile[5]);
            Vector3 vPlayer = new Vector3(1658.052f, 2543.221f, 45.56487f);
            Game.Player.Character.Position = vPlayer;

            Script.Wait(500);
            Vector3 Pris_01 = new Vector3(1688.322f, 2501.858f, 45.55706f);
            NPCSpawn("s_m_y_prisoner_01", Pris_01, 0.00f, 2, 1, null, false);
            Vector3 Pris_02 = new Vector3(1644.637f, 2526.352f, 45.55979f);
            NPCSpawn("s_m_y_prismuscl_01", Pris_02, 0.00f, 2, 1, null, false);
            Vector3 Pris_03 = new Vector3(1628.55f, 2552.414f, 45.55986f);
            NPCSpawn("s_m_m_prisguard_01", Pris_03, 0.00f, 2, 1, null, false);
            DataStore.bAllowControl = false;

            LoggerLight.Loggers("PrisTime, bDontStopMe == " + DataStore.bDontStopMe + ", Pris Heli == " + DataStore.bPrisHeli);
        }
        public static void YouJog()
        {

            LoggerLight.Loggers("YouJog");

            DataStore.iActionTime = Game.GameTime + 100;

            if (Game.Player.Character.Position.DistanceTo(DataStore.RanLoc_01[DataStore.iPath]) < 3.75f)
            {
                DataStore.iPath += 1;
                if (DataStore.iPath == DataStore.RanLoc_01.Count())
                    DataStore.iPath = 0;
                Game.Player.Character.Task.RunTo(DataStore.RanLoc_01[DataStore.iPath]);
            }
        }
        public static void YouDrive()
        {

            LoggerLight.Loggers("YouDrive");

            DataStore.iActionTime = Game.GameTime + 100;

            if (DataStore.bFallenOff)
            {
                if (!Game.Player.Character.IsInVehicle(DataStore.RideThis))
                {
                    Game.Player.Character.Task.EnterVehicle(DataStore.RideThis, VehicleSeat.Driver, -1, 2.00f);
                    DataStore.iActionTime = Game.GameTime + 3000;
                }
                else
                {
                    Game.Player.Character.Task.DriveTo(DataStore.RideThis, DataStore.RanLoc_01[DataStore.iPath], 5.00f, 35.00f);
                    DataStore.bFallenOff = false;
                }
            }
            else if (Game.Player.Character.IsInVehicle())
            {
                if (Game.Player.Character.Position.DistanceTo(DataStore.RanLoc_01[DataStore.iPath]) < 2.50f)
                {
                    if (DataStore.RideThis == null)
                        DataStore.RideThis = Game.Player.Character.CurrentVehicle;

                    DataStore.iPath += 1;
                    if (DataStore.iPath == DataStore.RanLoc_01.Count())
                        DataStore.iPath = 0;
                    Game.Player.Character.Task.DriveTo(DataStore.RideThis, DataStore.RanLoc_01[DataStore.iPath], 5.00f, 35.00f);
                }
            }
            else if (DataStore.RideThis != null)
            {
                Game.Player.Character.Task.EnterVehicle(DataStore.RideThis, VehicleSeat.Driver, -1, 2.00f);
                DataStore.bFallenOff = true;
            }
        }
        public static void YouHeliTo()
        {
            DataStore.iActionTime = Game.GameTime + 100;

            if (Game.Player.Character.IsInVehicle())
            {
                if (DataStore.iPath == 0)
                {
                    if (!Game.Player.Character.CurrentVehicle.IsInAir)
                    {
                        DataStore.iActionTime = Game.GameTime + 6000;
                        DataStore.iPath += 1;
                    }
                }
                else if (Game.Player.Character.Position.DistanceTo(DataStore.RanLoc_01[DataStore.iPath]) < 5.00f)
                {
                    DataStore.iPath += 1;
                    if (DataStore.iPath == DataStore.RanLoc_01.Count())
                    {
                        FlyHeliHere(DataStore.RanLoc_01[0], DataStore.fHeads[0], Game.Player.Character.CurrentVehicle, Game.Player.Character, true);
                        DataStore.iPath = 0;
                    }
                    else
                        FlyHeliHere(DataStore.RanLoc_01[DataStore.iPath], DataStore.fHeads[DataStore.iPath], Game.Player.Character.CurrentVehicle, Game.Player.Character, false);
                }
                else if (DataStore.iPath == 1)
                {
                    DataStore.iActionTime = Game.GameTime + 1000;
                    FlyHeliHere(DataStore.RanLoc_01[DataStore.iPath], DataStore.fHeads[DataStore.iPath], Game.Player.Character.CurrentVehicle, Game.Player.Character, false);
                }
            }
        }
        public static void HeliFlyYou()
        {
            DataStore.iActionTime = Game.GameTime + 100;

            if (DataStore.iPath < DataStore.RanLoc_01.Count() - 1)
            {
                if (DataStore.Shoaf.Position.DistanceTo(DataStore.RanLoc_01[DataStore.iPath]) < 10.00f)
                {
                    DataStore.iPath += 1;
                    FlyHeliHere(DataStore.RanLoc_01[DataStore.iPath], DataStore.fHeads[DataStore.iPath], DataStore.Shoaf, DataStore.pPilot, false);
                }
            }
            else
            {
                FlyHeliHere(DataStore.RanLoc_01[DataStore.RanLoc_01.Count() - 1], DataStore.fHeads[DataStore.fHeads.Count() - 1], DataStore.Shoaf, DataStore.pPilot, true);
                DataStore.bAllowControl = false;
                while (Game.Player.Character.IsInVehicle())
                    Script.Wait(100);
                DataStore.Shoaf.EngineRunning = false;
                CleanUpMess();
            }
        }
        public static void PedScenario(Ped Peddy, string sCenario, Vector3 Vpos, float fHeadings, bool bSeated)
        {

            LoggerLight.Loggers("PedScenario sCenario == " + sCenario);

            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, Peddy.Handle, sCenario, Vpos.X, Vpos.Y, Vpos.Z, fHeadings, 0, 0, 1);
        }
        public static void Yankton(bool bLoadIn)
        {
            LoggerLight.Loggers("Yankton");

            List<string> YanktonIPLs = new List<string>
            {
                "plg_01",
                "prologue01",
                "prologue01_lod",
                "prologue01c",
                "prologue01c_lod",
                "prologue01d",
                "prologue01d_lod",
                "prologue01e",
                "prologue01e_lod",
                "prologue01f",
                "prologue01f_lod",
                "prologue01g",
                "prologue01h",
                "prologue01h_lod",
                "prologue01i",
                "prologue01i_lod",
                "prologue01j",
                "prologue01j_lod",
                "prologue01k",
                "prologue01k_lod",
                "prologue01z",
                "prologue01z_lod",
                "plg_02",
                "prologue02",
                "prologue02_lod",
                "plg_03",
                "prologue03",
                "prologue03_lod",
                "prologue03b",
                "prologue03b_lod",
                "prologue03_grv_dug",
                "prologue03_grv_dug_lod",
                "prologue_grv_torch",
                "plg_04",
                "prologue04",
                "prologue04_lod",
                "prologue04b",
                "prologue04b_lod",
                "prologue04_cover",
                "des_protree_end",
                "des_protree_start",
                "des_protree_start_lod",
                "plg_05",
                "prologue05",
                "prologue05_lod",
                "prologue05b",
                "prologue05b_lod",
                "plg_06",
                "prologue06",
                "prologue06_lod",
                "prologue06b",
                "prologue06b_lod",
                "prologue06_int",
                "prologue06_int_lod",
                "prologue06_pannel",
                "prologue06_pannel_lod",
                "prologue_m2_door",
                "prologue_m2_door_lod",
                "plg_occl_00",
                "prologue_occl",
                "plg_rd",
                "prologuerd",
                "prologuerdb",
                "prologuerd_lod"
            };

            if (bLoadIn)
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, false);
                Function.Call((Hash)0x9133955F1A2DA957, true);

                for (int i = 0; i < YanktonIPLs.Count; i++)
                    Function.Call(Hash.REQUEST_IPL, YanktonIPLs[i]);

                DataStore.bInYankton = true;
            }
            else
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call((Hash)0x9133955F1A2DA957, false);

                Function.Call(Hash._LOAD_MP_DLC_MAPS);

                Function.Call((Hash)0x9BAE5AD2508DF078, false);

                for (int i = 0; i < YanktonIPLs.Count; i++)
                    Function.Call(Hash.REMOVE_IPL, YanktonIPLs[i]);

                DataStore.bInYankton = false;
            }
        }
        public static void CayoPerico(bool bLoadIn)
        {
            LoggerLight.Loggers("CayoPerico");

            List<string> CayoPericoIPLs = new List<string>
            {
                "h4_islandairstrip",
                "h4_islandairstrip_props",
                "h4_islandx_mansion",
                "h4_islandx_mansion_props",
                "h4_islandx_props",
                "h4_islandxdock",
                "h4_islandxdock_props",
                "h4_islandxdock_props_2",
                "h4_islandxtower",
                "h4_islandx_maindock",
                "h4_islandx_maindock_props",
                "h4_islandx_maindock_props_2",
                "h4_IslandX_Mansion_Vault",
                "h4_islandairstrip_propsb",
                "h4_islandx_barrack_props",
                "h4_islandx_checkpoint",
                "h4_islandx_checkpoint_props",
                "h4_islandx_Mansion_Office",
                "h4_islandx_Mansion_LockUp_01",
                "h4_islandx_Mansion_LockUp_02",
                "h4_islandx_Mansion_LockUp_03",
                "h4_islandairstrip_hangar_props",
                "h4_IslandX_Mansion_B",
                "h4_islandairstrip_doorsclosed",
                "h4_Underwater_Gate_Closed",
                "h4_mansion_gate_closed",
                "h4_aa_guns",
                "h4_IslandX_Mansion_GuardFence",
                "h4_IslandX_Mansion_Entrance_Fence",
                "h4_IslandX_Mansion_B_Side_Fence",
                "h4_IslandX_Mansion_Lights",
                "h4_islandxcanal_props",
                "h4_islandX_Terrain_props_06_a",
                "h4_islandX_Terrain_props_06_b",
                "h4_islandX_Terrain_props_06_c",
                "h4_islandX_Terrain_props_05_a",
                "h4_islandX_Terrain_props_05_b",
                "h4_islandX_Terrain_props_05_c",
                "h4_islandX_Terrain_props_05_d",
                "h4_islandX_Terrain_props_05_e",
                "h4_islandX_Terrain_props_05_f",
                "H4_islandx_terrain_01",
                "H4_islandx_terrain_02",
                "H4_islandx_terrain_03",
                "H4_islandx_terrain_04",
                "H4_islandx_terrain_05",
                "H4_islandx_terrain_06",
                "h4_ne_ipl_00",
                "h4_ne_ipl_01",
                "h4_ne_ipl_02",
                "h4_ne_ipl_03",
                "h4_ne_ipl_04",
                "h4_ne_ipl_05",
                "h4_ne_ipl_06",
                "h4_ne_ipl_07",
                "h4_ne_ipl_08",
                "h4_ne_ipl_09",
                "h4_nw_ipl_00",
                "h4_nw_ipl_01",
                "h4_nw_ipl_02",
                "h4_nw_ipl_03",
                "h4_nw_ipl_04",
                "h4_nw_ipl_05",
                "h4_nw_ipl_06",
                "h4_nw_ipl_07",
                "h4_nw_ipl_08",
                "h4_nw_ipl_09",
                "h4_se_ipl_00",
                "h4_se_ipl_01",
                "h4_se_ipl_02",
                "h4_se_ipl_03",
                "h4_se_ipl_04",
                "h4_se_ipl_05",
                "h4_se_ipl_06",
                "h4_se_ipl_07",
                "h4_se_ipl_08",
                "h4_se_ipl_09",
                "h4_sw_ipl_00",
                "h4_sw_ipl_01",
                "h4_sw_ipl_02",
                "h4_sw_ipl_03",
                "h4_sw_ipl_04",
                "h4_sw_ipl_05",
                "h4_sw_ipl_06",
                "h4_sw_ipl_07",
                "h4_sw_ipl_08",
                "h4_sw_ipl_09",
                "h4_islandx_mansion",
                "h4_islandxtower_veg",
                "h4_islandx_sea_mines",
                "h4_islandx",
                "h4_islandx_barrack_hatch",
                "h4_islandxdock_water_hatch",

                "h4_beach",
                "h4_beach_props",
                "h4_beach_bar_props",
                "h4_beach_props_party",
                "h4_beach_party"
            };
            //sPropAttach.Add("h4_prop_battle_analoguemixer_01a");//Dj Deck-  02

            if (bLoadIn)
            {
                Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
                Function.Call((Hash)0x9A9D1BA639675CF1, "HeistIsland", 1);
                Function.Call((Hash)0x5E1460624D194A38, 1);

                Function.Call((Hash)0xF74B1FFA4A15FBEA, true);
                Function.Call((Hash)0x53797676AD34A9AA, false);

                Function.Call((Hash)0xF8DEE0A5600CBB93, true);

                for (int i = 0; i < CayoPericoIPLs.Count; i++)
                    Function.Call(Hash.REQUEST_IPL, CayoPericoIPLs[i]);

                if (DataStore.MySettingsXML.BeachPart)
                {
                    List<Vector3> vPartays = new List<Vector3>();
                    List<Vector3> vPartB = new List<Vector3>();
                    List<float> vPartBHead = new List<float>();

                    vPartays.Add(new Vector3(4894.263f, -4913.141f, 3.36446f));     //Dance Rad == 5    00
                    vPartays.Add(new Vector3(4890.318f, -4923.923f, 3.368097f));    //Dance Rad == 8    01
                    vPartays.Add(new Vector3(4900.574f, -4923.098f, 3.36113f));     //Sit  Rad == 3     02
                    vPartays.Add(new Vector3(4883.7f, -4916.323f, 3.368711f));      //Sit  Rad == 3     03
                    vPartays.Add(new Vector3(4888.34f, -4933.511f, 3.367885f));     //Sit  Rad == 3     04
                    vPartays.Add(new Vector3(4882.221f, -4933.872f, 3.37767f));     //Sit  Rad == 3     05
                    vPartays.Add(new Vector3(4897.382f, -4938.688f, 3.362702f));    //Sit  Rad == 3     06
                    vPartays.Add(new Vector3(4901.941f, -4935.71f, 3.363577f));     //Sit  Rad == 3     07
                    vPartays.Add(new Vector3(4908.562f, -4934.384f, 3.367695f));    //Sit  Rad == 3     08

                    vPartB.Add(new Vector3(4878.054f, -4948.04f, 3.556281f)); vPartBHead.Add(91.67182f);
                    vPartB.Add(new Vector3(4875.837f, -4950.161f, 3.629188f)); vPartBHead.Add(351.4073f);
                    vPartB.Add(new Vector3(4874.032f, -4947.307f, 3.575044f)); vPartBHead.Add(242.7412f);
                    vPartB.Add(new Vector3(4876.772f, -4946.251f, 3.520398f)); vPartBHead.Add(146.6341f);//Fire Pit

                    vPartB.Add(new Vector3(4872.481f, -4911.394f, 3.003824f)); vPartBHead.Add(294.576f);
                    vPartB.Add(new Vector3(4872.82f, -4917.226f, 2.915241f)); vPartBHead.Add(271.9123f);
                    vPartB.Add(new Vector3(4871.187f, -4917.283f, 2.847157f)); vPartBHead.Add(341.5042f);//sun back

                    vPartB.Add(new Vector3(4871.44f, -4910.393f, 2.946956f)); vPartBHead.Add(288.3906f);
                    vPartB.Add(new Vector3(4872.479f, -4911.321f, 3.003426f)); vPartBHead.Add(119.555f);
                    vPartB.Add(new Vector3(4866.439f, -4906.744f, 2.577915f)); vPartBHead.Add(106.9248f);
                    vPartB.Add(new Vector3(4867.695f, -4910.954f, 2.650635f)); vPartBHead.Add(110.5905f);
                    vPartB.Add(new Vector3(4867.171f, -4909.43f, 2.605493f)); vPartBHead.Add(101.497f);
                    vPartB.Add(new Vector3(4868.493f, -4913.752f, 2.716372f)); vPartBHead.Add(283.9765f);
                    vPartB.Add(new Vector3(4869.915f, -4921.263f, 2.879118f)); vPartBHead.Add(278.9364f);
                    vPartB.Add(new Vector3(4868.144f, -4943.559f, 2.709443f)); vPartBHead.Add(246.9356f);
                    vPartB.Add(new Vector3(4862.854f, -4956.314f, 2.491656f)); vPartBHead.Add(64.97399f);
                    vPartB.Add(new Vector3(4863.502f, -4955.183f, 2.544171f)); vPartBHead.Add(78.42456f);//sun front

                    Game.Player.Character.Position = vPartays[1];
                    Script.Wait(1000);
                    int iRan = RsReturns.RandInt(4, 7);

                    for (int i = 0; i < iRan; i++)
                    {
                        Vector3 vDance = vPartays[0].Around(5.00f);
                        vDance.Z = vPartays[0].Z;
                        CayoNPCSpawn(RsReturns.AddAnyPed(2), null, vDance, RsReturns.RandInt(0, 360), 12);
                    }

                    iRan = RsReturns.RandInt(7, 13);

                    for (int i = 0; i < iRan; i++)
                    {
                        Vector3 vDance = vPartays[1].Around(8.00f);
                        vDance.Z = vPartays[1].Z;
                        CayoNPCSpawn(RsReturns.AddAnyPed(2), null, vDance, RsReturns.RandInt(0, 360), 12);
                    }

                    for (int i = 2; i < vPartays.Count; i++)
                    {
                        Prop[] PSit = World.GetNearbyProps(vPartays[i], 3.00f);
                        for (int ii = 0; ii < PSit.Count(); ii++)
                        {
                            if (PSit[ii].Model == Function.Call<int>(Hash.GET_HASH_KEY, "h4_prop_h4_couch_01a") || PSit[ii].Model == Function.Call<int>(Hash.GET_HASH_KEY, "h4_prop_h4_chair_01a"))
                            {
                                if (RsReturns.RandInt(0, 20) < 10)
                                    CayoNPCSpawn(RsReturns.AddAnyPed(2), PSit[ii], Vector3.Zero, RsReturns.RandInt(0, 360), 12);
                            }
                        }
                    }

                    for (int i = 0; i < 4; i++)
                        CayoNPCSpawn(RsReturns.AddAnyPed(2), null, vPartB[i], vPartBHead[i], 12);


                    for (int i = 4; i < 6; i++)
                    {
                        if (RsReturns.RandInt(0, 20) < 10)
                            CayoNPCSpawn(RsReturns.AddAnyPed(2), null, vPartB[i], vPartBHead[i], 15);
                    }

                    for (int i = 6; i < vPartB.Count; i++)
                    {
                        if (RsReturns.RandInt(0, 20) < 10)
                            CayoNPCSpawn(RsReturns.AddAnyPed(2), null, vPartB[i], vPartBHead[i], 16);
                    }

                    Vector3 vDj = new Vector3(4893.571f, -4905.296f, 3.481121f);
                    Vector3 vBar = new Vector3(4902.647f, -4943.707f, 3.392626f);

                    CayoNPCSpawn("IG_SSS", null, vDj, 192.4766f, 12);
                    CayoNPCSpawn("S_F_Y_BeachBarStaff_01", null, vBar, 46.24336f, 12);

                    DanceFloor(true);
                }

                DataStore.bInCayoPerico = true;
            }
            else
            {
                Function.Call((Hash)0x9A9D1BA639675CF1, "HeistIsland", 0);
                Function.Call((Hash)0x5E1460624D194A38, 0);

                Function.Call((Hash)0xF74B1FFA4A15FBEA, false);
                Function.Call((Hash)0x53797676AD34A9AA, true);

                LoadOnlineIps();

                for (int i = 0; i < CayoPericoIPLs.Count; i++)
                    Function.Call(Hash.REMOVE_IPL, CayoPericoIPLs[i]);

                for (int i = 0; i < DataStore.PedParty.Count; i++)
                    DataStore.PedParty[i].Delete();

                DataStore.PedParty.Clear();
                DanceFloor(false);
                DataStore.bInCayoPerico = false;
                DataStore.bOpenDoors = false;
            }
        }
        public static void DanceFloor(bool bOn)
        {
            LoggerLight.Loggers("DanceFloor, bOn == " + bOn);

            if (bOn)
            {
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_left", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_04_reverb", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_03_reverb", true);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", true);

            }
            else
            {
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_01_left", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_04_reverb", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_03_reverb", false);
                Function.Call(Hash.SET_STATIC_EMITTER_ENABLED, "se_dlc_hei4_island_beach_party_music_new_02_right", false);
            }
        }
        public static void LoadOnlineIps()
        {

            LoggerLight.Loggers("LoadOnlineIps");

            List<string> sAddIpl = new List<string>();

            Function.Call(Hash._ENABLE_MP_DLC_MAPS, true);
            Function.Call(Hash._LOAD_MP_DLC_MAPS);

            Function.Call((Hash)0x9BAE5AD2508DF078, false);

            sAddIpl.Add("vw_casino_billboard_lod");
            sAddIpl.Add("vw_casino_billboard_lod(1)");
            sAddIpl.Add("vw_casino_billboard");
            sAddIpl.Add("hei_dlc_windows_casino_lod");
            sAddIpl.Add("hei_dlc_windows_casino");
            sAddIpl.Add("hei_dlc_casino_door_lod");
            sAddIpl.Add("hei_dlc_casino_door");
            sAddIpl.Add("hei_dlc_casino_aircon_lod");
            sAddIpl.Add("hei_dlc_casino_aircon");

            for (int i = 0; i < sAddIpl.Count; i++)
            {
                if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, sAddIpl[i]))
                    Function.Call(Hash.REQUEST_IPL, sAddIpl[i]);
            }
        }
        public static void FlyHeliHere(Vector3 Vloc, float fHeadin, Vehicle Heli, Ped Plot, bool bLand)
        {

            LoggerLight.Loggers("FlyHeliHere, bLand == " + bLand);

            float HeliDesX = Vloc.X;
            float HeliDesY = Vloc.Y;
            float HeliDesZ = Vloc.Z;
            float HeliSpeed = 50.00f;
            float HeliLandArea = 0.00f;
            float HeliDirect = fHeadin;

            if (bLand)
                Function.Call(Hash.TASK_HELI_MISSION, Plot.Handle, Heli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, 15.00f, 4.50f, HeliDirect, -1, -1, -1, 32);
            else
                Function.Call(Hash.TASK_HELI_MISSION, Plot.Handle, Heli.Handle, 0, 0, HeliDesX, HeliDesY, HeliDesZ, 4, HeliSpeed, HeliLandArea, HeliDirect, -1, -1, -1, 0);
        }
        public static void MethEdd(bool bOver)
        {

            LoggerLight.Loggers("MethEdd, bOver == " + bOver);

            if (bOver)
            {
                DataStore.bMethActor = false;
                Function.Call(Hash.CLEAR_TIMECYCLE_MODIFIER);
                if (DataStore.bMethFail)
                    Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, Game.Player.Character.Handle, 0.00f);
                DataStore.bMethFail = false;
            }
            else
            {
                DataStore.bMethFail = false;
                int iTenPass = 10;
                DataStore.bMethActor = true;
                Function.Call(Hash.SET_TIMECYCLE_MODIFIER, "DRUG_gas_huffin");
                while (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk") || iTenPass < 0)
                {
                    iTenPass -= 1;
                    Function.Call(Hash.REQUEST_ANIM_SET, "move_m@drunk@moderatedrunk");
                    Script.Wait(100);
                }
                if (Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, "move_m@drunk@moderatedrunk"))
                {
                    DataStore.bMethFail = true;
                    Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, Game.Player.Character.Handle, "move_m@drunk@moderatedrunk", 1.00f);
                }

            }
        }
        public static void YouDrive(Vehicle Vhick)
        {
            LoggerLight.Loggers("YouDrive");

            Vector3 V3ME = Vhick.Position + (Vhick.ForwardVector * 45.00f);
            Game.Player.Character.Task.DriveTo(Vhick, V3ME, 2.00f, 45.00f);
        }
        public static void AccessAllAreas()
        {
            LoggerLight.Loggers("AccessAllAreas");

            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
            DataStore.bDontStopMe = true;
            DataStore.bDeadorArrest = false;
        }
        public static void InRestrictedArea()
        {
            Game.Player.WantedLevel = 0;
            Game.Player.IgnoredByPolice = true;
            Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character.Handle, false);
            //Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "respawn_controller");
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_prison");
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_lossantosintl");
            Function.Call(Hash.STOP_ALARM, "PRISON_ALARMS", 0);
            Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_GENERAL", 0);
            Function.Call(Hash.CLEAR_AMBIENT_ZONE_STATE, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_WARNING", 0);

            if (DataStore.bPrisHeli)
            {
                if (Game.Player.Character.IsInVehicle(DataStore.PrisEscape) || Game.Player.Character.Position.DistanceTo(DataStore.vAreaRest) > 2000.00f)
                {
                    DataStore.bPrisHeli = false;
                    DataStore.bDontStopMe = false;
                    BacktoBase(true);
                }
            }
            else if (Game.Player.Character.Position.DistanceTo(DataStore.vAreaRest) > 1500.00f)
            {
                DataStore.bDontStopMe = false;
                BacktoBase(false);
            }

        }
        public static void OpeningDoors(Vector3 Vtarg01, Vector3 Vtarg02, Vector3 Vtarg03)
        {
            int iLockBreak = 0;
            if (DataStore.iUnlock < Game.GameTime)
            {
                DataStore.iUnlock = Game.GameTime + 1000;
                if (Game.Player.Character.Position.DistanceTo(Vtarg01) < 3.00f)
                    iLockBreak = 1;
                else if (Game.Player.Character.Position.DistanceTo(Vtarg02) < 3.00f)
                    iLockBreak = 2;
                else if (Game.Player.Character.Position.DistanceTo(Vtarg03) < 3.00f)
                    iLockBreak = 3;
            }
            if (iLockBreak > 0)
            {
                string sGate = "";
                Vector3 vMyGate = Vector3.Zero;
                if (iLockBreak == 1)
                {
                    sGate = "h4_prop_h4_gate_04a";
                    vMyGate = Vtarg01;
                }
                else if (iLockBreak == 2)
                {
                    sGate = "h4_prop_h4_gate_r_03a";
                    vMyGate = Vtarg02;
                }
                else if (iLockBreak == 3)
                {
                    sGate = "h4_prop_h4_gate_l_03a ";
                    vMyGate = Vtarg03;
                    DataStore.bOpenDoors = false;
                }
                Prop[] PList = World.GetNearbyProps(vMyGate, 12.00f);

                for (int i = 0; i < PList.Count(); i++)
                {
                    if (PList[i].Model == Function.Call<int>(Hash.GET_HASH_KEY, sGate))
                    {
                        Function.Call(Hash._DOOR_CONTROL, Function.Call<int>(Hash.GET_HASH_KEY, sGate), PList[i].Position.X, PList[i].Position.Y, PList[i].Position.Z, 0, 0.0f, 50.0f, 0.0f);
                        PList[i].FreezePosition = false;
                    }
                }
            }
        }
        public static void BacktoBase(bool bPrisHel)
        {
            LoggerLight.Loggers("BacktoBase, bPrisHel == " + bPrisHel);

            if (bPrisHel)
            {
                Game.Player.WantedLevel = 3;
                DataStore.PrisEscape.FreezePosition = false;
                DataStore.PrisEscape.CurrentBlip.Remove();
                DataStore.PrisEscape.MarkAsNoLongerNeeded();
                DataStore.PrisEscape = null;
                DataStore.bPrisHeli = false;
            }
            Game.Player.IgnoredByPolice = false;
            Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, Game.Player.Character.Handle, true);
            Function.Call(Has﻿h.REQUEST_SCRIPT, "restrictedareas");
            Function.Call(Has﻿h.REQUEST_SCRIPT, "re_armybase");
            Function.Call(Has﻿h.REQUEST_SCRIPT, "re_lossantosintl");
            DataStore.bDontStopMe = false;
        }
        public static void FindCrimo(Vector3 Vec3, float fRadi, float fMinRadi)
        {
            LoggerLight.Loggers("FindCrimo");

            Vehicle[] CarSpot = World.GetNearbyVehicles(Vec3, fRadi);
            int iFind = CarSpot.Count();

            for (int i = 0; i < iFind; i++)
            {
                if (!DataStore.bFound)
                {
                    if (CarSpot[i].IsPersistent == false && CarSpot[i].Position.DistanceTo(Game.Player.Character.Position) > fMinRadi && CarSpot[i] != Game.Player.Character.CurrentVehicle)
                    {
                        if (CarSpot[i].ClassType != VehicleClass.Boats && CarSpot[i].ClassType != VehicleClass.Cycles && CarSpot[i].ClassType != VehicleClass.Helicopters && CarSpot[i].ClassType != VehicleClass.Planes && CarSpot[i].ClassType != VehicleClass.Trains)
                        {
                            if (!CarSpot[i].IsSeatFree(VehicleSeat.Driver) && CarSpot[i].EngineRunning)
                            {
                                if (CarSpot[i].Exists())
                                {
                                    DataStore.bFound = true;
                                    CarSpot[i].IsPersistent = true;
                                    CarSpot[i].Driver.IsPersistent = true;
                                    CopsNRobbers(CarSpot[i], CarSpot[i].Driver);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (!DataStore.bFound)
            {
                Game.FadeScreenIn(1000);
                Game.Player.Character.Task.CruiseWithVehicle(Game.Player.Character.CurrentVehicle, 35.00f);
                Script.Wait(1000);
                FindCrimo(Vec3, fRadi, fMinRadi);
            }
        }
        public static void CopsNRobbers(Vehicle vGetAway, Ped pDriver)
        {
            LoggerLight.Loggers("CopsNRobbers");

            Game.Player.Character.CurrentVehicle.SirenActive = true;
            pDriver.Task.FleeFrom(Game.Player.Character);
            Game.Player.Character.Task.VehicleChase(pDriver);
            for (int i = 0; i < vGetAway.PassengerSeats; i++)
            {
                if (!vGetAway.IsSeatFree(DataStore.Vseats[i]))
                {
                    if (vGetAway.GetPedOnSeat(DataStore.Vseats[i]) != pDriver)
                        vGetAway.GetPedOnSeat(DataStore.Vseats[i]).Delete();
                }
            }
            DataStore.VehList.Add(new Vehicle(vGetAway.Handle));
            DataStore.PeddyList.Add(new Ped(pDriver.Handle));
            Vector3 V3 = vGetAway.Position + (vGetAway.RightVector * 4);
            FillthisVeh(vGetAway, 2, 0, V3, 6, 2, false);
        }
        public static void AddChars(NewClothBank MyNewChar)
        {
            bool bOverWrite = true;
            for (int i = 0; i < DataStore.MyPedCollection.Count; i++)
            {
                if (bOverWrite)
                {
                    if (DataStore.MyPedCollection[i].Name == MyNewChar.Name)
                    {
                        DataStore.MyPedCollection[i].ModelX = MyNewChar.ModelX;

                        DataStore.MyPedCollection[i].ClothA = new List<int>(MyNewChar.ClothA);
                        DataStore.MyPedCollection[i].ClothB = new List<int>(MyNewChar.ClothB);

                        DataStore.MyPedCollection[i].ExtraA = new List<int>(MyNewChar.ExtraA);
                        DataStore.MyPedCollection[i].ExtraB = new List<int>(MyNewChar.ExtraB);

                        DataStore.MyPedCollection[i].FreeMode = MyNewChar.FreeMode;

                        DataStore.MyPedCollection[i].XshapeFirstID = MyNewChar.XshapeFirstID;
                        DataStore.MyPedCollection[i].XshapeSecondID = MyNewChar.XshapeSecondID;
                        DataStore.MyPedCollection[i].XshapeThirdID = MyNewChar.XshapeThirdID;
                        DataStore.MyPedCollection[i].XskinFirstID = MyNewChar.XskinFirstID;
                        DataStore.MyPedCollection[i].XskinSecondID = MyNewChar.XskinSecondID;
                        DataStore.MyPedCollection[i].XskinThirdID = MyNewChar.XskinThirdID;
                        DataStore.MyPedCollection[i].XshapeMix = MyNewChar.XshapeMix;
                        DataStore.MyPedCollection[i].XskinMix = MyNewChar.XskinMix;
                        DataStore.MyPedCollection[i].XthirdMix = MyNewChar.XthirdMix;
                        DataStore.MyPedCollection[i].XisParent = MyNewChar.XisParent;

                        DataStore.MyPedCollection[i].HairColour = MyNewChar.HairColour;
                        DataStore.MyPedCollection[i].HairStreaks = MyNewChar.HairStreaks;
                        DataStore.MyPedCollection[i].EyeColour = MyNewChar.EyeColour;

                        DataStore.MyPedCollection[i].Overlay = new List<int>(MyNewChar.Overlay);
                        DataStore.MyPedCollection[i].OverlayColour = new List<int>(MyNewChar.OverlayColour);
                        DataStore.MyPedCollection[i].OverlayOpc = new List<float>(MyNewChar.OverlayOpc);

                        DataStore.MyPedCollection[i].Tattoo_COl = new List<string>(MyNewChar.Tattoo_COl);
                        DataStore.MyPedCollection[i].Tattoo_Nam = new List<string>(MyNewChar.Tattoo_Nam);

                        DataStore.MyPedCollection[i].FaceScale = new List<float>(MyNewChar.FaceScale);

                        DataStore.MyPedCollection[i].PedVoice = MyNewChar.PedVoice;

                        bOverWrite = false;

                        break;
                    }
                }
            }

            if (bOverWrite)
                DataStore.MyPedCollection.Add(MyNewChar);

            SetPedSaveXML();
        }
        public static void PedPools()
        {
            LoggerLight.Loggers("PedPool");

            if (File.Exists(DataStore.sSavedFile))
            {
                ClothBankist ClothXML = new ClothBankist();
                ClothXML = XmlReadWrite.LoadChars(DataStore.sSavedFile);
                DataStore.MyPedCollection = new List<NewClothBank>(ClothXML.FreeChars);
            }
            else
            {
                WritePedSave(RsReturns.BuildABank());
            }
        }
        public static void SetPedSaveXML()
        {
            ClothBankist ClothXML = new ClothBankist
            {
                FreeChars = new List<NewClothBank>(DataStore.MyPedCollection)
            };

            XmlReadWrite.SaveChars(ClothXML, DataStore.sSavedFile);
        }
        public static void WritePedSave(NewClothBank ThisPedB)
        {
            string sPed = ThisPedB.Name;
            LoggerLight.Loggers("WritePedSave, sPed == " + sPed);

            AddChars(ThisPedB);
        }
        public static void ForceAnim(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.Loggers("ForceAnim, sAnimName == " + sAnimName);

            peddy.Task.ClearAll();
            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(1);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 1, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ForceAnimOnce(Ped peddy, string sAnimDict, string sAnimName, Vector3 AnPos, Vector3 AnRot)
        {
            LoggerLight.Loggers("ForceAnimOnce, sAnimName == " + sAnimName);

            Function.Call(Hash.REQUEST_ANIM_DICT, sAnimDict);
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, sAnimDict))
                Script.Wait(100);
            Function.Call(Hash.TASK_PLAY_ANIM_ADVANCED, peddy.Handle, sAnimDict, sAnimName, AnPos.X, AnPos.Y, AnPos.Z, AnRot.X, AnRot.Y, AnRot.Z, 8.0f, 0.00f, -1, 0, 0.01f, 0, 0);
            Function.Call(Hash.REMOVE_ANIM_DICT, sAnimDict);
        }
        public static void ReEnableScenarios()
        {
            DataStore.MySettingsXML.BeachPed = true;
            DataStore.MySettingsXML.Tramps = true;
            DataStore.MySettingsXML.Highclass = true;
            DataStore.MySettingsXML.Midclass = true;
            DataStore.MySettingsXML.Lowclass = true;
            DataStore.MySettingsXML.Business = true;
            DataStore.MySettingsXML.Bodybuilder = true;
            DataStore.MySettingsXML.GangStars = true;
            DataStore.MySettingsXML.Epsilon = true;
            DataStore.MySettingsXML.Jogger = true;
            DataStore.MySettingsXML.Golfer = true;
            DataStore.MySettingsXML.Hiker = true;
            DataStore.MySettingsXML.Methaddict = true;
            DataStore.MySettingsXML.Rural = true;
            DataStore.MySettingsXML.Cyclist = true;
            DataStore.MySettingsXML.LGBTWXYZ = true;
            DataStore.MySettingsXML.PoolPeds = true;
            DataStore.MySettingsXML.Workers = true;
            DataStore.MySettingsXML.Jetski = true;
            DataStore.MySettingsXML.BikeATV = true;
            DataStore.MySettingsXML.Services = true;
            DataStore.MySettingsXML.Pilot = true;
            DataStore.MySettingsXML.Animals = true;
            DataStore.MySettingsXML.Yankton = true;
            DataStore.MySettingsXML.Cayo = true;
        }
        public static void TopCornerUI(string sText)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, sText);
            Function.Call(Hash._0x238FFE5C7B0498A6, 0, 0, 1, -1);
        }
    }
}