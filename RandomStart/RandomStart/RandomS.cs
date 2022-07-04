using GTA;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RandomStart
{
    public class RandomS : Script
    {
        private bool bIsReady = true;
        private MenuPool MyMenuPool = new MenuPool();

        public RandomS()
        {
            Game.FadeScreenOut(1);
            DataStore.LoadUpDataStore();

            Tick += TickyTock;
            KeyDown += KeyPlunk;
            Interval = 1; 
        }
        private void TickyTock(object sender, EventArgs e)
        {

            if (bIsReady)
            {
                if (!Game.IsLoading)
                {
                    LoggerLight.Loggers("IsLoading");
                    Script.Wait(4000);
                    bIsReady = false;
                    RsActions.StartTheMod(0, true);
                    RsActions.AddTombStone();
                }
            }
            else if (DataStore.bMenuOpen)
            {
                if (MyMenuPool.IsAnyMenuOpen())
                    MyMenuPool.ProcessMenus();
                else
                    DataStore.bMenuOpen = false;
            }
            else
            {
                if (!DataStore.bDeadorArrest)
                    RsActions.EveryBodyDies();

                if (DataStore.bAllowControl)
                {
                    if (DataStore.iPostAction == 3)
                    {
                        if (DataStore.VehList[DataStore.VehList.Count() - 1].IsSeatFree(VehicleSeat.Driver))
                        {
                            if (Game.Player.Character.Position.DistanceTo(DataStore.VehList[DataStore.VehList.Count() - 1].Position) > 300.00f)
                            {
                                RsActions.CleanUpMess();
                                DataStore.bAllowControl = false;
                            }
                            else
                            {
                                Script.Wait(5000);
                                RsActions.CleanUpMess();
                                DataStore.bAllowControl = false;
                            }
                        }
                        else
                        {
                            if (Game.Player.Character.Position.DistanceTo(DataStore.VehList[DataStore.VehList.Count() - 1].Position) > 300.00f)
                            {
                                RsActions.CleanUpMess();
                                DataStore.bAllowControl = false;
                            }
                            else if (DataStore.VehList[DataStore.VehList.Count() - 1].GetPedOnSeat(VehicleSeat.Driver).IsDead)
                            {
                                Script.Wait(5000);
                                RsActions.CleanUpMess();
                                DataStore.bAllowControl = false;
                            }
                        }
                    }
                    else if (DataStore.iPostAction == 6)
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            if (DataStore.iActionTime < Game.GameTime)
                                RsActions.HeliFlyYou();
                        }
                        else
                        {
                            RsActions.CleanUpMess();
                            DataStore.bAllowControl = false;
                        }
                    }
                    else if (DataStore.iPostAction == 8)
                    {
                        if (DataStore.iWait4 < Game.GameTime)
                        {
                            DataStore.iPostAction = 0;
                            DataStore.bAllowControl = false;
                            RsActions.CleanUpMess();
                        }
                    }
                    else
                    {
                        RsActions.TopCornerUI(DataStore.MyLang.Langfile[92]);
                        if (RsReturns.WhileButtonDown(75, true))
                        {
                            RsActions.CleanUpMess();
                            DataStore.bAllowControl = false;
                        }
                        else if (DataStore.iPostAction == 4)
                        {
                            if (DataStore.iActionTime < Game.GameTime)
                                RsActions.YouJog();
                        }
                        else if (DataStore.iPostAction == 5)
                        {
                            if (DataStore.iActionTime < Game.GameTime)
                                RsActions.YouDrive();
                        }
                        else if (DataStore.iPostAction == 7)
                        {
                            if (DataStore.iActionTime < Game.GameTime)
                                RsActions.YouHeliTo();
                        }
                        else if (Game.Player.Character.IsInVehicle())
                        {
                            if (Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Planes)
                            {
                                if (Game.Player.Character.CurrentVehicle.LandingGear == VehicleLandingGear.Deployed)
                                {
                                    if (Game.Player.Character.CurrentVehicle.IsInAir)
                                        Game.Player.Character.CurrentVehicle.LandingGear = VehicleLandingGear.Closing;

                                }
                            }
                        }
                    }
                }

                if (DataStore.MySettingsXML.DisableRecord)
                {
                    if (Function.Call<bool>(Hash._IS_RECORDING))
                        Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                }

                if (DataStore.bDontStopMe)
                    RsActions.InRestrictedArea();
                else if (DataStore.bOpenDoors)
                    RsActions.OpeningDoors(DataStore.PeskyDoors[0], DataStore.PeskyDoors[1], DataStore.PeskyDoors[2]);
            }

        }
        private void KeyPlunk(object sender, KeyEventArgs e)
        {
            if (DataStore.bStart)
            {
                if (DataStore.bKeyFinder)
                {
                    DataStore.MySettingsXML.MenuKey = e.KeyCode;
                    UI.ShowSubtitle("~r~" + DataStore.MySettingsXML.MenuKey + "' ~w~" + DataStore.MyLang.Langfile[90]);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                    DataStore.bKeyFinder = false;
                }
                else if (e.KeyCode == DataStore.MySettingsXML.MenuKey)
                {
                    Game.FadeScreenIn(1);
                    if (DataStore.bAllowControl)
                        UI.Notify(DataStore.MyLang.Langfile[89]);
                    else
                    {
                        DataStore.bMenuOpen = true;
                        PedMenuMain();
                    }
                }
            }
        }
        private void PedMenuMain()
        {
            LoggerLight.Loggers("PedMenuMain");

            MyMenuPool = new MenuPool();
            var mainMenu = new UIMenu(DataStore.MyLang.Langfile[6], "");
            MyMenuPool.Add(mainMenu);
            RanPedMenu(mainMenu);
            SetLocate(mainMenu);
            SetChar(mainMenu);
            SetLoadWeps(mainMenu);
            SetMenuKey(mainMenu);
            SelectSaved(mainMenu);
            PedPosses(mainMenu);
            InstantReincarnate(mainMenu);
            DisRecord(mainMenu);
            AddBeachParty(mainMenu);
            SeatBeltON(mainMenu);
            Re_WriteLoadout(mainMenu);
            MyMenuPool.RefreshIndex();
            DataStore.bMenuOpen = true;
            mainMenu.Visible = !mainMenu.Visible;
        }
        private void CompileMenuTotals(List<dynamic> dList, int iTotal, int iBZero)
        {
            LoggerLight.Loggers("CompileMenuTotals");

            while (iBZero < iTotal)
            {
                dList.Add("- " + iBZero + " -");
                iBZero = iBZero + 1;
            }
        }
        private void CompileMenuTotalsFloats(List<dynamic> dList, int iLow, int iTotal)
        {
            LoggerLight.Loggers("CompileMenuTotalsFloats");

            int iUpC = iLow;
            while (iUpC < iTotal)
            {
                if (iUpC < -9)
                {
                    dList.Add("[ -0." + iUpC * -1 + " ]");
                }
                else if (iUpC < 0)
                {
                    dList.Add("[ -0.0" + iUpC * -1 + " ]");
                }
                else if (iUpC < 10)
                    dList.Add("[ 0.0" + iUpC + " ]");
                else
                    dList.Add("[ 0." + iUpC + " ]");
                iUpC = iUpC + 1;
            }
        }
        private void PedPosses(UIMenu XMen)
        {
            LoggerLight.Loggers("PedPosses");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[136], DataStore.MyLang.Langfile[137]);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    RsReturns.SelectingPeds(false);
                }
            };
        }
        private void SavePedMenu(UIMenu XMen)
        {
            LoggerLight.Loggers("SavePedMenu");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[8]);

            SetComponents(playermodelmenu);
            SetPedProps(playermodelmenu);
            ResetPedProps(playermodelmenu);
            SetHVoice(playermodelmenu);

            if (Game.Player.Character.Model == PedHash.Michael)
            {
                AddTatts(playermodelmenu, 1);
            }
            else if (Game.Player.Character.Model == PedHash.Franklin)
            {
                AddTatts(playermodelmenu, 2);
            }
            else if (Game.Player.Character.Model == PedHash.Trevor)
            {
                AddTatts(playermodelmenu, 3);
            }
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
            {
                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 4);
                SetFaceFeatures(playermodelmenu);
            }
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
            {

                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 5);
                SetFaceFeatures(playermodelmenu);
            }

            if (DataStore.iCurrentPed > 0)
                SaveMyPed(playermodelmenu);
            CreateNewPed(playermodelmenu);
            DeleteCurrentPed(playermodelmenu);
        }
        private void SelectSaved(UIMenu XMen)
        {
            LoggerLight.Loggers("SelectSaved");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[8]);

            DataStore.NewBank = RsReturns.BuildABank();
            RsActions.WritePedSave(DataStore.NewBank);

            List<dynamic> SavedPeds = new List<dynamic>();

            for (int i = 0; i < DataStore.MyPedCollection.Count; i++)
                SavedPeds.Add(DataStore.MyPedCollection[i].Name);

            var ThisShizle = new UIMenuListItem("", SavedPeds, 0);
            ThisShizle.Description = DataStore.MyLang.Langfile[98];
            if (DataStore.iCurrentPed != 0 && RsReturns.AreTheyTheSame(DataStore.iCurrentPed))
                ThisShizle.Index = DataStore.iCurrentPed;
            else
                DataStore.iCurrentPed = 0;
            playermodelmenu.AddItem(ThisShizle);
            playermodelmenu.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    DataStore.iCurrentPed = index;
                    RsActions.SavePedLoader(DataStore.iCurrentPed);
                }
            };
            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    playermodelmenu.Clear();
                    if (DataStore.iCurrentPed != 0)
                    {
                        DataStore.NewBank = DataStore.MyPedCollection[DataStore.iCurrentPed];
                        if (DataStore.MyPedCollection[DataStore.iCurrentPed].Overlay.Count < 12)
                            DataStore.NewBank = RsReturns.AddMissingOverlays(DataStore.NewBank);
                        if (DataStore.MyPedCollection[DataStore.iCurrentPed].FaceScale.Count < 19)
                            DataStore.NewBank = RsReturns.AddMissingFaces(DataStore.NewBank);
                    }
                    SavePedMenu(playermodelmenu);
                }
            };
        }
        private void SetHair01(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHair01");

            List<dynamic> Hair01 = new List<dynamic>();

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            CompileMenuTotals(Hair01, iCount, 0);
            var newitem = new UIMenuListItem(DataStore.MyLang.Langfile[9], Hair01, 0);
            newitem.Index = DataStore.NewBank.HairColour;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character.Handle, index, DataStore.NewBank.HairStreaks);
                    DataStore.NewBank.HairColour = index;
                }

            };
        }
        private void SetHair02(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHair02");

            List<dynamic> Hair02 = new List<dynamic>();

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            CompileMenuTotals(Hair02, iCount, 0);
            var newitem = new UIMenuListItem(DataStore.MyLang.Langfile[10], Hair02, 0);
            newitem.Index = DataStore.NewBank.HairStreaks;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character.Handle, DataStore.NewBank.HairColour, index);
                    DataStore.NewBank.HairStreaks = index;
                }
            };
        }
        private void SetHEyes(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHEyes");

            List<dynamic> Eyes = new List<dynamic>();

            int iCount = 32;
            CompileMenuTotals(Eyes, iCount, 0);

            var newitem = new UIMenuListItem(DataStore.MyLang.Langfile[11], Eyes, 0);
            newitem.Index = DataStore.NewBank.EyeColour;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_EYE_COLOR, Game.Player.Character.Handle, index);
                    DataStore.NewBank.EyeColour = index;
                }
            };
        }
        private void SetHVoice(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHVoice");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, "Voices");

            List<dynamic> Voices = new List<dynamic>();

            for (int i = 0; i < DataStore.ThemVoices.Count; i++)
            {
                Voices.Add(DataStore.ThemVoices[i]);
                var newitem = new UIMenuItem(DataStore.ThemVoices[i]);
                playermodelmenu.AddItem(newitem);
            }

            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                DataStore.NewBank.PedVoice = DataStore.ThemVoices[index];
                Function.Call(Hash.SET_AMBIENT_VOICE_NAME, Game.Player.Character.Handle, DataStore.NewBank.PedVoice);
                Function.Call((Hash)0x4ADA3F19BE4A6047, Game.Player.Character.Handle);
                UI.Notify("Voice set to " + DataStore.NewBank.PedVoice);
            };
        }
        private void SetOverLays(UIMenu XMen)
        {
            LoggerLight.Loggers("SetOverLays");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[12]);

            SetOvers(playermodelmenu, 0, DataStore.MyLang.Langfile[13], 23);
            SetOversColour(playermodelmenu, 1, DataStore.MyLang.Langfile[14], 28);
            SetOversColour(playermodelmenu, 2, DataStore.MyLang.Langfile[15], 33);
            SetOvers(playermodelmenu, 3, DataStore.MyLang.Langfile[16], 14);
            SetOvers(playermodelmenu, 4, DataStore.MyLang.Langfile[17], 74);
            SetOversColour(playermodelmenu, 5, DataStore.MyLang.Langfile[18], 6);
            SetOvers(playermodelmenu, 6, DataStore.MyLang.Langfile[19], 11);
            SetOvers(playermodelmenu, 7, DataStore.MyLang.Langfile[20], 10);
            SetOversColour(playermodelmenu, 8, DataStore.MyLang.Langfile[21], 9);
            SetOvers(playermodelmenu, 9, DataStore.MyLang.Langfile[22], 17);
            SetOversColour(playermodelmenu, 10, DataStore.MyLang.Langfile[23], 16);
            SetOvers(playermodelmenu, 11, DataStore.MyLang.Langfile[24], 11);
        }
        private void SetOvers(UIMenu XMen, int OverLayId, string sName, int iCount)
        {
            LoggerLight.Loggers("SetOvers");

            string sOpacity = "" + sName + DataStore.MyLang.Langfile[25];

            List<dynamic> Main = new List<dynamic>();
            int iZero = DataStore.NewBank.Overlay[OverLayId];
            if (iZero == 255)
                iZero = -1;
            CompileMenuTotals(Main, iCount, -1);
            var newitem = new UIMenuListItem(sName, Main, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Opacity = new List<dynamic>();
            iCount = 99;
            float fOvers = DataStore.NewBank.OverlayOpc[OverLayId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            CompileMenuTotalsFloats(Opacity, 0, iCount);
            var newitemOpac = new UIMenuListItem(sOpacity, Opacity, 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iOver = index - 1;
                    if (iOver == -1)
                        iOver = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, iOver, DataStore.NewBank.OverlayOpc[OverLayId]);
                    DataStore.NewBank.Overlay[OverLayId] = iOver;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character.Handle, OverLayId), fOpal);
                    DataStore.NewBank.OverlayOpc[OverLayId] = fOpal;
                }
            };
        }
        private void SetOversColour(UIMenu XMen, int OverLayId, string sName, int iCount)
        {
            LoggerLight.Loggers("SetOversColour");

            string sOpacity = "" + sName + DataStore.MyLang.Langfile[25];
            string sColour = "" + sName + DataStore.MyLang.Langfile[26];

            List<dynamic> Main = new List<dynamic>();
            int iZero = DataStore.NewBank.Overlay[OverLayId];
            if (iZero == 255)
                iZero = -1;
            CompileMenuTotals(Main, iCount, -1);
            var newitem = new UIMenuListItem(sName, Main, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Colour = new List<dynamic>();

            iCount = 64;
            CompileMenuTotals(Colour, iCount, 0);
            var newitem2 = new UIMenuListItem(sColour, Colour, 0);
            newitem2.Index = DataStore.NewBank.OverlayColour[OverLayId];
            XMen.AddItem(newitem2);

            List<dynamic> Opacity = new List<dynamic>();
            iCount = 99;
            float fOvers = DataStore.NewBank.OverlayOpc[OverLayId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            CompileMenuTotalsFloats(Opacity, 0, iCount);
            var newitemOpac = new UIMenuListItem(sOpacity, Opacity, 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iOver = index - 1;
                    if (iOver == -1)
                        iOver = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, iOver, DataStore.NewBank.OverlayOpc[OverLayId]);
                    DataStore.NewBank.Overlay[OverLayId] = iOver;
                }
                else if (item == newitem2)
                {
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Game.Player.Character.Handle, OverLayId, 1, index, 0);
                    DataStore.NewBank.OverlayColour[OverLayId] = index;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character.Handle, OverLayId), fOpal);
                    DataStore.NewBank.OverlayOpc[OverLayId] = fOpal;
                }
            };
        }
        private void SetComponents(UIMenu XMen)
        {
            LoggerLight.Loggers("SetComponents");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[27]);

            if (!RsReturns.GetMainChar())
                Componets(playermodelmenu, 0, DataStore.MyLang.Langfile[28]);
            Componets(playermodelmenu, 1, DataStore.MyLang.Langfile[29]);
            Componets(playermodelmenu, 2, DataStore.MyLang.Langfile[30]);
            Componets(playermodelmenu, 3, DataStore.MyLang.Langfile[31]);
            Componets(playermodelmenu, 4, DataStore.MyLang.Langfile[32]);
            Componets(playermodelmenu, 5, DataStore.MyLang.Langfile[33]);
            Componets(playermodelmenu, 6, DataStore.MyLang.Langfile[34]);
            Componets(playermodelmenu, 7, DataStore.MyLang.Langfile[35]);
            Componets(playermodelmenu, 8, DataStore.MyLang.Langfile[36]);
            Componets(playermodelmenu, 9, DataStore.MyLang.Langfile[37]);
            Componets(playermodelmenu, 10, DataStore.MyLang.Langfile[38]);
            Componets(playermodelmenu, 11, DataStore.MyLang.Langfile[39]);
        }
        private void Componets(UIMenu XMen, int CompId, string sName)
        {
            LoggerLight.Loggers("Componets");

            string sText = "" + sName + DataStore.MyLang.Langfile[40];

            List<dynamic> Comp = new List<dynamic>();

            int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, CompId) + 1;
            int iZero = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, CompId);
            CompileMenuTotals(Comp, iCount, -1);
            var newitem = new UIMenuListItem(sName, Comp, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Txture = new List<dynamic>();

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iZero) + 1;
            CompileMenuTotals(Txture, iTexTotal, 0);
            var newitem2 = new UIMenuListItem(sText, Txture, 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = index - 1;
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex) + 1;
                    newitem2.Items.Clear();
                    CompileMenuTotals(newitem2.Items, iTexTotal, 0);
                    newitem2.Index = 0;
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iDex, 0, 2);
                    DataStore.NewBank.ClothA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    int iAmComp = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iAmComp, index, 2);
                    DataStore.NewBank.ClothB[CompId] = index;
                }
            };
        }
        private void SetPedProps(UIMenu XMen)
        {

            LoggerLight.Loggers("SetPedProps");

            var playermodelmenu2 = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[41]);

            PedProps(playermodelmenu2, 0, DataStore.MyLang.Langfile[42]);
            PedProps(playermodelmenu2, 1, DataStore.MyLang.Langfile[43]);
            PedProps(playermodelmenu2, 2, DataStore.MyLang.Langfile[44]);
            PedProps(playermodelmenu2, 3, DataStore.MyLang.Langfile[45]);
        }
        private void PedProps(UIMenu XMen, int CompId, string sName)
        {
            LoggerLight.Loggers("PedProps");

            string sText = "" + sName + DataStore.MyLang.Langfile[40];

            List<dynamic> Comp = new List<dynamic>();

            int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, CompId) + 1;
            int iZero = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId);
            CompileMenuTotals(Comp, iCount, -1);
            var newitem = new UIMenuListItem(sName, Comp, 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            List<dynamic> Txture = new List<dynamic>();

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iZero) + 1;
            CompileMenuTotals(Txture, iTexTotal, 0);
            var newitem2 = new UIMenuListItem(sText, Txture, 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = index - 1;
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex) + 1;
                    newitem2.Items.Clear();
                    CompileMenuTotals(newitem2.Items, iTexTotal, 0);
                    newitem2.Index = 0;
                    if (iDex == -1)
                        Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, CompId);
                    else
                        Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iDex, 0, false);
                    DataStore.NewBank.ExtraA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    int iAmComp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iAmComp, index, false);
                    DataStore.NewBank.ExtraB[CompId] = index;
                }
            };
        }
        private void ResetPedProps(UIMenu XMen)
        {

            LoggerLight.Loggers("ResetPedProps");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[46], DataStore.MyLang.Langfile[47]);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, 0);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, 1);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, 2);
                    Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, 3);
                }
            };
        }
        private void AddTatts(UIMenu XMen, int iChar)
        {
            LoggerLight.Loggers("AddTatts");

            if (iChar == 1 || iChar == 2 || iChar == 3)
            {
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[109]);

                Tatty(playermodelmenu, iChar, 1, DataStore.MyLang.Langfile[100]);    //TORSO
                Tatty(playermodelmenu, iChar, 2, DataStore.MyLang.Langfile[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 3, DataStore.MyLang.Langfile[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 4, DataStore.MyLang.Langfile[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 5, DataStore.MyLang.Langfile[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 6, DataStore.MyLang.Langfile[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
            else
            {
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[109]);

                Tatty(playermodelmenu, iChar, 1, DataStore.MyLang.Langfile[99]);    //BACK
                Tatty(playermodelmenu, iChar, 2, DataStore.MyLang.Langfile[110]);   //CHEST
                Tatty(playermodelmenu, iChar, 3, DataStore.MyLang.Langfile[111]);   //STOMACH
                Tatty(playermodelmenu, iChar, 4, DataStore.MyLang.Langfile[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 5, DataStore.MyLang.Langfile[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 6, DataStore.MyLang.Langfile[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 7, DataStore.MyLang.Langfile[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 8, DataStore.MyLang.Langfile[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
        }
        private void Tatty(UIMenu XMen, int iChar, int iSkin, string sName)
        {
            LoggerLight.Loggers("Tatty");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, sName);

            List<string> sub_01 = RsReturns.TattoosList(iChar, iSkin);

            if (sub_01[0] != "No Tattoos Available")
            {
                for (int i = 0; i < sub_01.Count; i++)
                {
                    var item_ = new UIMenuItem(sub_01[i], "");
                    playermodelmenu.AddItem(item_);
                    if (DataStore.NewBank.Tattoo_Nam.Contains(DataStore.sTatName[i]))
                        item_.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);

                }

                playermodelmenu.OnItemSelect += (sender, item, index) =>
                {
                    RsReturns.TattoosList(iChar, iSkin);
                    if (sub_01[index] != "No Tattoos Available")
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);

                        if (!DataStore.NewBank.Tattoo_Nam.Contains(DataStore.sTatName[index]))
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);
                            DataStore.NewBank.Tattoo_COl.Add(DataStore.sTatBase[index]);
                            DataStore.NewBank.Tattoo_Nam.Add(DataStore.sTatName[index]);
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sTatBase[index]), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.sTatName[index]));
                        }
                        else
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.None);
                            int iAm = DataStore.NewBank.Tattoo_Nam.IndexOf(DataStore.sTatName[index]);
                            DataStore.NewBank.Tattoo_COl.RemoveAt(iAm);
                            DataStore.NewBank.Tattoo_Nam.RemoveAt(iAm);
                        }

                    }

                };
                playermodelmenu.OnMenuClose += (sender) =>
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                    for (int i = 0; i < DataStore.NewBank.Tattoo_COl.Count; i++)
                        Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.NewBank.Tattoo_COl[i]), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.NewBank.Tattoo_Nam[i]));
                };
            }
        }
        private void ClearTats(UIMenu XMen)
        {
            LoggerLight.Loggers("ClearTats");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[108], "");
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                    DataStore.NewBank.Tattoo_COl.Clear();
                    DataStore.NewBank.Tattoo_Nam.Clear();
                }
            };
        }
        private void SetFaceFeatures(UIMenu XMen)
        {
            LoggerLight.Loggers("SetFaceFeatures");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[134]);

            FaceFeatures(playermodelmenu, 0, DataStore.MyLang.Langfile[114]);
            FaceFeatures(playermodelmenu, 1, DataStore.MyLang.Langfile[115]);
            FaceFeatures(playermodelmenu, 2, DataStore.MyLang.Langfile[116]);
            FaceFeatures(playermodelmenu, 3, DataStore.MyLang.Langfile[117]);
            FaceFeatures(playermodelmenu, 4, DataStore.MyLang.Langfile[118]);
            FaceFeatures(playermodelmenu, 5, DataStore.MyLang.Langfile[119]);
            FaceFeatures(playermodelmenu, 6, DataStore.MyLang.Langfile[120]);
            FaceFeatures(playermodelmenu, 7, DataStore.MyLang.Langfile[121]);
            FaceFeatures(playermodelmenu, 8, DataStore.MyLang.Langfile[122]);
            FaceFeatures(playermodelmenu, 9, DataStore.MyLang.Langfile[123]);
            FaceFeatures(playermodelmenu, 10, DataStore.MyLang.Langfile[124]);
            FaceFeatures(playermodelmenu, 11, DataStore.MyLang.Langfile[125]);
            FaceFeatures(playermodelmenu, 12, DataStore.MyLang.Langfile[126]);
            FaceFeatures(playermodelmenu, 13, DataStore.MyLang.Langfile[127]);
            FaceFeatures(playermodelmenu, 14, DataStore.MyLang.Langfile[128]);
            FaceFeatures(playermodelmenu, 15, DataStore.MyLang.Langfile[129]);
            FaceFeatures(playermodelmenu, 16, DataStore.MyLang.Langfile[130]);
            FaceFeatures(playermodelmenu, 17, DataStore.MyLang.Langfile[131]);
            FaceFeatures(playermodelmenu, 18, DataStore.MyLang.Langfile[132]);
            FaceFeatures(playermodelmenu, 19, DataStore.MyLang.Langfile[133]);
        }
        private void FaceFeatures(UIMenu XMen, int CompId, string sName)
        {
            LoggerLight.Loggers("FaceFeatures");

            List<dynamic> FeatVar = new List<dynamic>();

            float fOvers = DataStore.NewBank.FaceScale[CompId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers) + 99;
            CompileMenuTotalsFloats(FeatVar, -99, 99);
            var newitem = new UIMenuListItem(sName, FeatVar, 99);
            XMen.AddItem(newitem);
            newitem.Index = iAM;

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    float fOpal = (int)index - 99;
                    fOpal = (fOpal / 100);
                    Function.Call(Hash._SET_PED_FACE_FEATURE, Game.Player.Character.Handle, CompId, fOpal);
                    DataStore.NewBank.FaceScale[CompId] = fOpal;
                }
            };

            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            //  void _SET_PED_FACE_FEATURE(Ped ped, int index, float scale) // 71A5C1DBA060049E
            //  Sets the various freemode face features, e.g.nose length, chin shape.Scale ranges from - 1.0 to 1.0.

            //Nose_Width                                0
            //Nose_Peak_Hight                           1
            //Nose_Peak_Lenght                          2
            //Nose_Bone_High                            3
            //Nose_Peak_Lowering                        4
            //Nose_Bone_Twist                           5
            //EyeBrown_High                             6
            //EyeBrown_Forward                          7
            //Cheeks_Bone_High                          8
            //Cheeks_Bone_Width                         9
            //Cheeks_Width                              10
            //Eyes_Openning                             11
            //Lips_Thickness                            12
            //Jaw_Bone_Width 'Bone size to sides        13
            //Jaw_Bone_Back_Lenght 'Bone size to back   14
            //Chimp_Bone_Lowering 'Go Down              15
            //Chimp_Bone_Lenght 'Go forward             16
            //Chimp_Bone_Width                          17
            //Chimp_Hole                                18
            //Neck_Thikness                             19
        }
        private void SaveMyPed(UIMenu XMen)
        {
            LoggerLight.Loggers("SaveMyPed");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[48], DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                    RsActions.WritePedSave(DataStore.NewBank);
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle("~g~" + DataStore.MyLang.Langfile[50] + DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
                    RsActions.PedPools();
                }
            };
        }
        private void CreateNewPed(UIMenu XMen)
        {
            LoggerLight.Loggers("CreateNewPed");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[112] + DataStore.MyLang.Langfile[48], DataStore.MyLang.Langfile[49]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    DataStore.NewBank.Name = Game.GetUserInput(255);
                    if (DataStore.NewBank.Name != "")
                    {
                        XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                        RsActions.WritePedSave(DataStore.NewBank);
                        UI.ShowSubtitle("~g~" + DataStore.MyLang.Langfile[50] + DataStore.NewBank.Name);
                        MyMenuPool.CloseAllMenus();
                        RsActions.PedPools();
                    }
                }
            };
        }
        private void SetLocate(UIMenu XMen)
        {
            LoggerLight.Loggers("SetLocate");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[51], DataStore.MyLang.Langfile[52]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.Locate)
                playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    DataStore.MySettingsXML.Locate = !DataStore.MySettingsXML.Locate;
                    if (DataStore.MySettingsXML.Locate)
                    {
                        RsActions.ReEnableScenarios();
                        playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    }
                    else
                        playermodelmenu.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    if (DataStore.MySettingsXML.Locate && DataStore.bLoadUpOnYacht)
                    {
                        DataStore.MySettingsXML.Locate = false;
                    }
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SetChar(UIMenu XMen)
        {

            LoggerLight.Loggers("SetChar");

            var SetCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[53], DataStore.MyLang.Langfile[54]);
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.Spawn)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);

            var SetSVSaveOpt = new UIMenuItem(DataStore.MyLang.Langfile[57], DataStore.MyLang.Langfile[58]);
            SetSVSaveOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.Saved)
                SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetSVSaveOpt);


            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    DataStore.MySettingsXML.Spawn = !DataStore.MySettingsXML.Spawn;
                    if (DataStore.MySettingsXML.Saved && DataStore.MySettingsXML.Spawn)
                    {
                        DataStore.MySettingsXML.Saved = false;
                        SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                    if (DataStore.MySettingsXML.Spawn)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                }
                else if (item == SetSVSaveOpt)
                {
                    if (DataStore.MyPedCollection.Count > 0)
                    {
                        DataStore.MySettingsXML.Saved = !DataStore.MySettingsXML.Saved;
                        if (DataStore.MySettingsXML.Saved && DataStore.MySettingsXML.Spawn)
                        {
                            DataStore.MySettingsXML.Spawn = false;
                            SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                        if (DataStore.MySettingsXML.Saved)
                            SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                        else
                            SetSVSaveOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    }
                }
                XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
            };
        }
        private void DisRecord(UIMenu XMen)
        {

            LoggerLight.Loggers("DisRecord");

            var SetCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[55], DataStore.MyLang.Langfile[56]);
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.DisableRecord)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    DataStore.MySettingsXML.DisableRecord = !DataStore.MySettingsXML.DisableRecord;
                    if (DataStore.MySettingsXML.DisableRecord)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SeatBeltON(UIMenu XMen)
        {
            LoggerLight.Loggers("SeatBeltON");

            var SetCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[96], "");
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, Game.Player.Character.Handle, 32, true) == DataStore.MySettingsXML.BeltUp)
                RsActions.PlayerBelter();
            if (DataStore.MySettingsXML.BeltUp)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    DataStore.MySettingsXML.BeltUp = !DataStore.MySettingsXML.BeltUp;
                    RsActions.PlayerBelter();
                    if (DataStore.MySettingsXML.BeltUp)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void InstantReincarnate(UIMenu XMen)
        {
            LoggerLight.Loggers("InstantReincarnate");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[140]);

            var Rand_01 = new UIMenuItem(DataStore.MyLang.Langfile[140], DataStore.MyLang.Langfile[141]);
            if (DataStore.MySettingsXML.Reincarn)
                Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_02 = new UIMenuItem(DataStore.MyLang.Langfile[142], "");
            if (DataStore.MySettingsXML.ReCritter)
                Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_03 = new UIMenuItem(DataStore.MyLang.Langfile[143], "");
            if (DataStore.MySettingsXML.ReSave)
                Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_04 = new UIMenuItem(DataStore.MyLang.Langfile[144], "");
            if (DataStore.MySettingsXML.ReCurr)
                Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            playermodelmenu.AddItem(Rand_01);
            playermodelmenu.AddItem(Rand_02);
            playermodelmenu.AddItem(Rand_03);
            playermodelmenu.AddItem(Rand_04);

            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Rand_01)
                {
                    DataStore.MySettingsXML.Reincarn = !DataStore.MySettingsXML.Reincarn;
                    if (DataStore.MySettingsXML.Reincarn)
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
                else if (item == Rand_02)
                {
                    DataStore.MySettingsXML.ReCritter = !DataStore.MySettingsXML.ReCritter;
                    if (DataStore.MySettingsXML.ReCritter)
                    {
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                        if (DataStore.MySettingsXML.ReSave)
                        {
                            DataStore.MySettingsXML.ReSave = !DataStore.MySettingsXML.ReSave;
                            Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                        if (DataStore.MySettingsXML.ReCurr)
                        {
                            DataStore.MySettingsXML.ReCurr = !DataStore.MySettingsXML.ReCurr;
                            Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                    }
                    else
                        Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
                else if (item == Rand_03)
                {
                    DataStore.MySettingsXML.ReSave = !DataStore.MySettingsXML.ReSave;
                    if (DataStore.MySettingsXML.ReSave)
                    {
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                        if (DataStore.MySettingsXML.ReCritter)
                        {
                            DataStore.MySettingsXML.ReCritter = !DataStore.MySettingsXML.ReCritter;
                            Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                        if (DataStore.MySettingsXML.ReCurr)
                        {
                            DataStore.MySettingsXML.ReCurr = !DataStore.MySettingsXML.ReCurr;
                            Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                    }
                    else
                        Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
                else if (item == Rand_04)
                {
                    DataStore.MySettingsXML.ReCurr = !DataStore.MySettingsXML.ReCurr;
                    if (DataStore.MySettingsXML.ReCurr)
                    {
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                        if (DataStore.MySettingsXML.ReCritter)
                        {
                            DataStore.MySettingsXML.ReCritter = !DataStore.MySettingsXML.ReCritter;
                            Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                        if (DataStore.MySettingsXML.ReSave)
                        {
                            DataStore.MySettingsXML.ReSave = !DataStore.MySettingsXML.ReSave;
                            Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.None);
                        }
                    }
                    else
                        Rand_04.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void AddBeachParty(UIMenu XMen)
        {
            LoggerLight.Loggers("AddBeachParty");

            var SetCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[97], "");
            SetCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.BeachPart)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    DataStore.MySettingsXML.BeachPart = !DataStore.MySettingsXML.BeachPart;
                    if (DataStore.MySettingsXML.BeachPart)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SetLoadWeps(UIMenu XMen)
        {
            LoggerLight.Loggers("SetLoadWeps");

            var SetSVCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[59], DataStore.MyLang.Langfile[60]);
            SetSVCharOpt.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            if (DataStore.MySettingsXML.KeepWeapons)
                SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetSVCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetSVCharOpt)
                {
                    DataStore.MySettingsXML.KeepWeapons = !DataStore.MySettingsXML.KeepWeapons;
                    if (DataStore.MySettingsXML.KeepWeapons)
                        SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetSVCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);
                    XmlReadWrite.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void Re_WriteLoadout(UIMenu XMen)
        {
            LoggerLight.Loggers("Re_WriteLoadout");

            var SetCharOpt = new UIMenuItem(DataStore.MyLang.Langfile[135], "");
            XMen.AddItem(SetCharOpt);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    MyMenuPool.CloseAllMenus();
                    DataStore.MySettingsXML.YourWeaps = DataStore.GetWeaps();
                }
            };
        }
        private void SetMenuKey(UIMenu XMen)
        {
            LoggerLight.Loggers("SetMenuKey");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[61], DataStore.MyLang.Langfile[62]);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle(DataStore.MyLang.Langfile[63]);
                    DataStore.bKeyFinder = true;
                }
            };
        }
        private void DeleteCurrentPed(UIMenu XMen)
        {
            LoggerLight.Loggers("DeleteCurrentPed");

            var playermodelmenu = new UIMenuItem(DataStore.MyLang.Langfile[64], DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
            playermodelmenu.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu && DataStore.iCurrentPed > 0)
                {
                    UI.ShowSubtitle("~g~" + DataStore.MyLang.Langfile[65] + " " + DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
                    DataStore.MyPedCollection.RemoveAt(DataStore.iCurrentPed);
                    RsActions.SetPedSaveXML();
                    MyMenuPool.CloseAllMenus();
                    DataStore.iCurrentPed = 0;
                }
            };
        }
        private void RanPedMenu(UIMenu XMen)
        {
            LoggerLight.Loggers("RanPedMenu");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.MyLang.Langfile[66]);
            //for (int i = 0; i < 1; i++) ;
            var Rand_01 = new UIMenuItem(DataStore.MyLang.Langfile[67], "");
            var Rand_02 = new UIMenuItem(DataStore.MyLang.Langfile[68], "");
            var Rand_03 = new UIMenuItem(DataStore.MyLang.Langfile[69], "");
            var Rand_04 = new UIMenuItem(DataStore.MyLang.Langfile[70], "");
            var Rand_05 = new UIMenuItem(DataStore.MyLang.Langfile[71], "");
            var Rand_06 = new UIMenuItem(DataStore.MyLang.Langfile[72], "");
            var Rand_07 = new UIMenuItem(DataStore.MyLang.Langfile[73], "");
            var Rand_08 = new UIMenuItem(DataStore.MyLang.Langfile[74], "");
            var Rand_09 = new UIMenuItem(DataStore.MyLang.Langfile[75], "");
            var Rand_10 = new UIMenuItem(DataStore.MyLang.Langfile[76], "");
            var Rand_11 = new UIMenuItem(DataStore.MyLang.Langfile[77], "");
            var Rand_12 = new UIMenuItem(DataStore.MyLang.Langfile[78], "");
            var Rand_13 = new UIMenuItem(DataStore.MyLang.Langfile[79], "");
            var Rand_14 = new UIMenuItem(DataStore.MyLang.Langfile[80], "");
            var Rand_15 = new UIMenuItem(DataStore.MyLang.Langfile[81], "");
            var Rand_16 = new UIMenuItem(DataStore.MyLang.Langfile[82], "");
            var Rand_17 = new UIMenuItem(DataStore.MyLang.Langfile[83], "");
            var Rand_18 = new UIMenuItem(DataStore.MyLang.Langfile[84], "");
            var Rand_19 = new UIMenuItem(DataStore.MyLang.Langfile[85], "");
            var Rand_20 = new UIMenuItem(DataStore.MyLang.Langfile[86], "");
            var Rand_21 = new UIMenuItem(DataStore.MyLang.Langfile[87], "");
            var Rand_22 = new UIMenuItem(DataStore.MyLang.Langfile[93], "");
            var Rand_23 = new UIMenuItem(DataStore.MyLang.Langfile[139], "");
            var Rand_24 = new UIMenuItem(DataStore.MyLang.Langfile[94], "");
            var Rand_25 = new UIMenuItem(DataStore.MyLang.Langfile[95], "");

            playermodelmenu.AddItem(Rand_01);
            playermodelmenu.AddItem(Rand_02);
            playermodelmenu.AddItem(Rand_03);
            playermodelmenu.AddItem(Rand_04);
            playermodelmenu.AddItem(Rand_05);
            playermodelmenu.AddItem(Rand_06);
            playermodelmenu.AddItem(Rand_07);
            playermodelmenu.AddItem(Rand_08);
            playermodelmenu.AddItem(Rand_09);
            playermodelmenu.AddItem(Rand_10);
            playermodelmenu.AddItem(Rand_11);
            playermodelmenu.AddItem(Rand_12);
            playermodelmenu.AddItem(Rand_13);
            playermodelmenu.AddItem(Rand_14);
            playermodelmenu.AddItem(Rand_15);
            playermodelmenu.AddItem(Rand_16);
            playermodelmenu.AddItem(Rand_17);
            playermodelmenu.AddItem(Rand_18);
            playermodelmenu.AddItem(Rand_19);
            playermodelmenu.AddItem(Rand_20);
            playermodelmenu.AddItem(Rand_21);
            playermodelmenu.AddItem(Rand_22);
            playermodelmenu.AddItem(Rand_23);
            playermodelmenu.AddItem(Rand_24);
            playermodelmenu.AddItem(Rand_25);

            playermodelmenu.OnItemSelect += (sender, item, index) =>
            {
                MyMenuPool.CloseAllMenus();
                DataStore.bMenuOpen = false;
                if (item == Rand_01)
                    RsActions.StartTheMod(1, false);
                else if (item == Rand_02)
                    RsActions.StartTheMod(2, false);
                else if (item == Rand_03)
                    RsActions.StartTheMod(3, false);
                else if (item == Rand_04)
                    RsActions.StartTheMod(4, false);
                else if (item == Rand_05)
                    RsActions.StartTheMod(5, false);
                else if (item == Rand_06)
                    RsActions.StartTheMod(6, false);
                else if (item == Rand_07)
                    RsActions.StartTheMod(7, false);
                else if (item == Rand_08)
                    RsActions.StartTheMod(8, false);
                else if (item == Rand_09)
                    RsActions.StartTheMod(9, false);
                else if (item == Rand_10)
                    RsActions.StartTheMod(10, false);
                else if (item == Rand_11)
                    RsActions.StartTheMod(11, false);
                else if (item == Rand_12)
                    RsActions.StartTheMod(12, false);
                else if (item == Rand_13)
                    RsActions.StartTheMod(13, false);
                else if (item == Rand_14)
                    RsActions.StartTheMod(14, false);
                else if (item == Rand_15)
                    RsActions.StartTheMod(15, false);
                else if (item == Rand_16)
                    RsActions.StartTheMod(16, false);
                else if (item == Rand_17)
                    RsActions.StartTheMod(17, false);
                else if (item == Rand_18)
                    RsActions.StartTheMod(18, false);
                else if (item == Rand_19)
                    RsActions.StartTheMod(19, false);
                else if (item == Rand_20)
                    RsActions.StartTheMod(20, false);
                else if (item == Rand_21)
                    RsActions.StartTheMod(21, false);
                else if (item == Rand_22)
                    RsActions.StartTheMod(22, false);
                else if (item == Rand_23)
                    RsActions.StartTheMod(23, false);
                else if (item == Rand_24)
                    RsActions.StartTheMod(24, false);
                else if (item == Rand_25)
                    RsActions.StartTheMod(25, false);
            };
        }
    }
}