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
    public class FreePed
    {
        public static void MakeFaces(bool bMale, int iSelecta)
        {
            LoggerLight.Loggers("FreemodePed.MakeFaces");

            ClothBank myFixtures = new ClothBank();

            myFixtures.FreeMode = true;
            //****************FaceShape/Colour****************
            int shapeFirstID;
            int shapeSecondID;
            int shapeThirdID;
            int skinFirstID;
            int skinSecondID;
            int skinThirdID;
            float shapeMix;
            float skinMix;
            float thirdMix;

            if (bMale)
            {
                shapeFirstID = RandomNum.RandInt(0, 20);
                shapeSecondID = RandomNum.RandInt(0, 20);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
            }
            else
            {
                shapeFirstID = RandomNum.RandInt(21, 41);
                shapeSecondID = RandomNum.RandInt(21, 41);
                shapeThirdID = shapeFirstID;
                skinFirstID = shapeFirstID;
                skinSecondID = shapeSecondID;
                skinThirdID = shapeThirdID;
            }

            shapeMix = RandomNum.RandFlow(-0.9f, 0.9f);
            skinMix = RandomNum.RandFlow(0.9f, 0.99f);
            thirdMix = RandomNum.RandFlow(-0.9f, 0.9f);

            myFixtures.XshapeFirstID = shapeFirstID;
            myFixtures.XshapeSecondID = shapeSecondID;
            myFixtures.XshapeThirdID = shapeThirdID;
            myFixtures.XskinFirstID = skinFirstID;
            myFixtures.XskinSecondID = skinSecondID;
            myFixtures.XskinThirdID = skinThirdID;
            myFixtures.XshapeMix = shapeMix;
            myFixtures.XskinMix = skinMix;
            myFixtures.XthirdMix = thirdMix;

            //****************Face****************
            for (int i = 0; i < 12; i++)
            {
                int iColour = 0;
                int iChange = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HEAD_OVERLAY_VALUES, i));
                float fVar = RandomNum.RandFlow(0.45f, 0.99f);

                if (i == 0)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Blemishes
                else if (i == 1)
                {
                    if (bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Facial Hair
                else if (i == 2)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                    iColour = 1;
                }//Eyebrows
                else if (i == 3)
                {
                    iChange = 255;
                }//Ageing
                else if (i == 4)
                {
                    int iFace = RandomNum.RandInt(0, 50);
                    if (iFace < 30)
                    {
                        iChange = RandomNum.RandInt(0, 15);
                    }
                    else if (iFace < 45)
                    {
                        iChange = RandomNum.RandInt(0, iChange);
                        fVar = RandomNum.RandFlow(0.85f, 0.99f);
                    }
                    else
                        iChange = 255;
                }//Makeup
                else if (i == 5)
                {
                    if (!bMale)
                    {
                        iChange = RandomNum.RandInt(0, iChange);
                        fVar = RandomNum.RandFlow(0.15f, 0.39f);
                    }
                    else
                        iChange = 255;
                    iColour = 2;
                }//Blush
                else if (i == 6)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Complexion
                else if (i == 7)
                {
                    iChange = 255;
                }//Sun Damage
                else if (i == 8)
                {
                    if (!bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 2;
                }//Lipstick
                else if (i == 9)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Moles/Freckles
                else if (i == 10)
                {
                    if (bMale)
                        iChange = RandomNum.RandInt(0, iChange);
                    else
                        iChange = 255;
                    iColour = 1;
                }//Chest Hair
                else if (i == 11)
                {
                    iChange = RandomNum.RandInt(0, iChange);
                }//Body Blemishes

                int AddColour = 0;

                if (iColour > 0)
                    AddColour = RandomNum.RandInt(0, 64);

                myFixtures.Overlay.Add(iChange);
                myFixtures.OverlayColour.Add(AddColour);
                myFixtures.OverlayOpc.Add(fVar);
            }
            //****************Hair****************
            int iHairStyle;

            if (bMale)
                iHairStyle = RandomNum.RandInt(37, 76);
            else
                iHairStyle = RandomNum.RandInt(37, 80);

            int iHair = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));
            int iHair2 = RandomNum.RandInt(0, Function.Call<int>(Hash._GET_NUM_HAIR_COLORS));

            myFixtures.HairColour = iHair;
            myFixtures.HairStreaks = iHair2;

            //****************Clothing****************
            ClothX myCloth;

            myCloth = PickOutfit(bMale, iSelecta);

            myFixtures.ClothA = myCloth.ClothA;
            myFixtures.ClothB = myCloth.ClothB;
            myFixtures.ExtraA = myCloth.ExtraA;
            myFixtures.ExtraB = myCloth.ExtraB;

            myCloth.ClothA[2] = iHairStyle;

            OnlineDress(Game.Player.Character, myFixtures);

            if (myCloth.Title != "Body_Suit")
                OnlineFaces(Game.Player.Character, myFixtures);
        }
        public static void OnlineFaces(Ped Pedx, ClothBank pFixtures)
        {
            LoggerLight.Loggers("FreemodePed OnlineFace Loaded Fixtures");

            //****************FaceShape/Colour****************

            int shapeFirstID = pFixtures.XshapeFirstID;
            int shapeSecondID = pFixtures.XshapeSecondID;
            int shapeThirdID = pFixtures.XshapeThirdID;
            int skinFirstID = pFixtures.XskinFirstID;
            int skinSecondID = pFixtures.XskinSecondID;
            int skinThirdID = pFixtures.XskinThirdID;
            float shapeMix = pFixtures.XshapeMix;
            float skinMix = pFixtures.XskinMix;
            float thirdMix = pFixtures.XthirdMix;
            bool isParent = false;

            Function.Call(Hash.SET_PED_HEAD_BLEND_DATA, Pedx.Handle, shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix, isParent);

            //****************Face****************
            for (int i = 0; i < 12; i++)
            {
                int iColour = 0;

                if (i == 1)
                {
                    iColour = 1;
                }//Facial Hair
                else if (i == 2)
                {
                    iColour = 1;
                }//Eyebrows
                else if (i == 5)
                {
                    iColour = 2;
                }//Blush
                else if (i == 8)
                {
                    iColour = 2;
                }//Lipstick
                else if (i == 10)
                {
                    iColour = 1;
                }//Chest Hair

                int iChange = pFixtures.Overlay[i];
                int AddColour = pFixtures.OverlayColour[i];
                float fVar = pFixtures.OverlayOpc[i];

                Function.Call(Hash.SET_PED_HEAD_OVERLAY, Pedx.Handle, i, iChange, fVar);

                if (iColour > 0)
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Pedx.Handle, i, iColour, AddColour, 0);
            }
            //****************Hair****************
            //int iHairStyle = pFixtures.iHairCut;

            //Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, 2, iHairStyle, 0, 2);//hair

            int iHair = pFixtures.HairColour;
            int iHair2 = pFixtures.HairStreaks;

            Function.Call(Hash._SET_PED_HAIR_COLOR, Pedx.Handle, iHair, iHair2);
        }
        public static void OnlineDress(Ped Pedx, ClothBank MyCloths)
        {
            LoggerLight.Loggers("FreemodePed.OnlineSavedWard");

            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Pedx.Handle);

            for (int i = 0; i < MyCloths.ClothA.Count; i++)
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Pedx.Handle, i, MyCloths.ClothA[i], MyCloths.ClothB[i], 2);

            for (int i = 0; i < MyCloths.ExtraA.Count; i++)
                Function.Call(Hash.SET_PED_PROP_INDEX, Pedx.Handle, i, MyCloths.ExtraA[i], MyCloths.ExtraB[i], false);
        }
        public static ClothX PickOutfit(bool bMale, int iSyle)
        {
            LoggerLight.Loggers("FreemodePed.PickOutfit");

            List<ClothX> CBList = new List<ClothX>();

            int iText = 0;
            int iText2 = 0;
            int iText3 = 0;

            if (bMale)
            {
                if (iSyle == 1)
                {
                    iText = RandomNum.RandInt(0, 11);
                    iText2 = RandomNum.RandInt(0, 15);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Beach_0",
                        ClothA = new List<int> { 0, 0, -1, 15, 16, 0, 1, 16, -1, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomNum.RandInt(0, 15);
                    iText2 = RandomNum.RandInt(0, 11);
                    iText3 = RandomNum.RandInt(0, 5);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Beach_2",
                        ClothA = new List<int> { 0, 0, -1, 5, 15, 0, 16, 0, 15, 0, 0, 17 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, iText3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Beach_3",
                        ClothA = new List<int> { 0, 0, -1, 5, 18, 0, 16, 0, 15, 0, 0, 36 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText2, 0, iText2, 0, 0, 0, 0, iText3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                }
                else if (iSyle == 2)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Highclass_0",
                        ClothA = new List<int> { 0, 0, -1, 4, 20, 0, 40, 11, 35, 0, 0, 27 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 9, 2, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_Highclass_1",
                        ClothA = new List<int> { 0, 0, -1, 6, 83, 0, 29, 89, 15, 0, 0, 190 },
                        ClothB = new List<int> { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 96, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 6, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Highclass_2",
                        ClothA = new List<int> { 0, 0, -1, 4, 63, 0, 2, 0, 15, 0, 0, 139 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 3 },
                        ExtraA = new List<int> { -1, 3, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 9, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Highclass_3",
                        ClothA = new List<int> { 0, 0, -1, 4, 60, 0, 36, 0, 72, 0, 0, 108 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 3, 0, 3, 0, 0, 4 },
                        ExtraA = new List<int> { -1, 13, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_Highclass_4",
                        ClothA = new List<int> { 0, 0, -1, 12, 24, 0, 18, 29, 31, 0, 0, 29 },
                        ClothB = new List<int> { 0, 0, 0, 0, 5, 0, 0, 2, 0, 0, 0, 5 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "M_Highclass_5",
                        ClothA = new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 },
                        ClothB = new List<int> { 0, 0, 0, 0, 4, 0, 4, 1, 0, 0, 0, 4 },
                        ExtraA = new List<int> { 64, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 4, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "M_Highclass_6",
                        ClothA = new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 1, 2, 4, 0, 0, 1 },
                        ExtraA = new List<int> { 64, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "M_Highclass_7",
                        ClothA = new List<int> { 0, 0, -1, 12, 60, 0, 40, 24, 22, 0, 0, 120 },
                        ClothB = new List<int> { 0, 0, 0, 0, 11, 0, 11, 1, 4, 0, 0, 11 },
                        ExtraA = new List<int> { 64, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 11, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                }
                else if (iSyle == 3)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Midclass_0",
                        ClothA = new List<int> { 0, 0, -1, 8, 4, 0, 4, 0, 15, 0, 0, 38 },
                        ClothB = new List<int> { 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_Midclass_1",
                        ClothA = new List<int> { 0, 0, -1, 0, 0, 0, 1, 17, 15, 0, 0, 33 },
                        ClothB = new List<int> { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Midclass_2",
                        ClothA = new List<int> { 0, 0, -1, 12, 1, 0, 1, 0, 15, 0, 0, 41 },
                        ClothB = new List<int> { 0, 0, 0, 0, 14, 0, 4, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Midclass_3",
                        ClothA = new List<int> { 0, 0, -1, 0, 0, 0, 0, 0, 15, 0, 0, 1 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 10, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_Midclass_4",
                        ClothA = new List<int> { 0, 0, -1, 0, 1, 0, 1, 0, 15, 0, 0, 22 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "M_Midclass_5",
                        ClothA = new List<int> { 0, 0, -1, 0, 0, 0, 2, 0, 15, 0, 0, 0 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, 0, -1, -1 },
                        ExtraB = new List<int> { -1, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "M_Midclass_6",
                        ClothA = new List<int> { 0, 0, -1, 0, 43, 0, 57, 51, 81, 0, 0, 170 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 2, 0, 0, 3 },
                        ExtraA = new List<int> { -1, 18, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 3, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                }
                else if (iSyle == 4)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Buisness_0",
                        ClothA = new List<int> { 0, 0, -1, 4, 13, 0, 10, 115, 10, 0, 0, 28 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, 17, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 6, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_Buisness_1",
                        ClothA = new List<int> { 0, 0, -1, 4, 37, 0, 20, 38, 10, 0, 0, 142 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 5, 6, 2, 0, 0, 2 },
                        ExtraA = new List<int> { 29, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Buisness_2",
                        ClothA = new List<int> { 0, 0, -1, 4, 37, 0, 15, 28, 31, 0, 0, 140 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 10, 1, 0, 0, 0, 2 },
                        ExtraA = new List<int> { -1, 17, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 5, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Buisness_3",
                        ClothA = new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 2, 15, 0, 0, 0, 7 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_Buisness_4",
                        ClothA = new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 },
                        ClothB = new List<int> { 0, 0, 0, 0, 3, 0, 7, 14, 0, 0, 0, 8 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "M_Buisness_5",
                        ClothA = new List<int> { 0, 0, -1, 4, 37, 0, 40, 28, 31, 0, 0, 140 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 6, 13, 0, 0, 0, 13 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "M_Buisness_6",
                        ClothA = new List<int> { 0, 0, -1, 4, 60, 0, 23, 10, 10, 0, 0, 72 },
                        ClothB = new List<int> { 0, 0, 0, 0, 7, 0, 2, 2, 7, 0, 0, 2 },
                        ExtraA = new List<int> { 29, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "M_Buisness_7",
                        ClothA = new List<int> { 0, 0, -1, 4, 10, 0, 23, 21, 31, 0, 0, 106 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 3, 12, 3, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "M_Buisness_8",
                        ClothA = new List<int> { 0, 0, -1, 4, 10, 0, 10, 38, 10, 0, 0, 4 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 6, 4, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                }
                else if (iSyle == 5)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Epslon_0",
                        ClothA = new List<int> { 0, 0, 0, 8, 104, 0, 20, 129, 15, 0, 0, 272 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                }
                else if (iSyle == 6)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Jogger_0",
                        ClothA = new List<int> { 0, 0, -1, 0, 18, 0, 9, 0, 15, 0, 0, 39 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 7, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_Jogger_1",
                        ClothA = new List<int> { 0, 0, -1, 0, 5, 0, 2, 0, 15, 0, 0, 1 },
                        ClothB = new List<int> { 0, 0, 0, 0, 6, 0, 6, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Jogger_2",
                        ClothA = new List<int> { 0, 0, -1, 0, 6, 0, 9, 0, 15, 0, 0, 9 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Jogger_3",
                        ClothA = new List<int> { 0, 0, -1, 1, 3, 0, 7, 0, 41, 0, 0, 7 },
                        ClothB = new List<int> { 0, 0, 0, 0, 4, 0, 15, 0, 3, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_Jogger_4",
                        ClothA = new List<int> { 0, 0, -1, 8, 14, 0, 2, 0, 15, 0, 0, 38 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 13, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                }
                else if (iSyle == 7)
                {
                    iText = RandomNum.RandInt(0, 11);
                    iText2 = RandomNum.RandInt(0, 3);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Swim_14",
                        ClothA = new List<int> { 0, 0, -1, 15, 18, 0, 5, 0, 15, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                }
                else if (iSyle == 8)
                {
                    iText = RandomNum.RandInt(0, 10);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_BikeATV_0",
                        ClothA = new List<int> { 0, 0, -1, 17, 77, 0, 55, 0, 15, 0, 0, 178 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 91, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomNum.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_BikeATV_1",
                        ClothA = new List<int> { 0, 0, -1, 110, 67, 0, 47, 0, 15, 0, 0, 148 },
                        ClothB = new List<int> { 0, 0, 0, iText, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 62, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }
                else if (iSyle == 9)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_CayoPerico_0",
                        ClothA = new List<int> { 0, 0, 0, 184, 22, 0, 36, 0, 15, 0, 0, 355 },
                        ClothB = new List<int> { 0, 0, 0, 0, 8, 0, 2, 0, 0, 0, 0, 17 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_CayoPerico_1",
                        ClothA = new List<int> { 0, 0, 0, 11, 6, 0, 9, 0, 15, 0, 0, 354 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 13, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_CayoPerico_2",
                        ClothA = new List<int> { 0, 0, 0, 184, 0, 0, 1, 0, 141, 0, 0, 355 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_CayoPerico_3",
                        ClothA = new List<int> { 0, 0, 0, 11, 12, 0, 5, 0, 15, 0, 0, 354 },
                        ClothB = new List<int> { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 14 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_CayoPerico_4",
                        ClothA = new List<int> { 0, 0, 0, 4, 87, 0, 60, 148, 170, 0, 0, 221 },
                        ClothB = new List<int> { 0, 0, 0, 0, 6, 0, 0, 1, 6, 0, 0, 6 },
                        ExtraA = new List<int> { 150, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 14, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "M_CayoPerico_5",
                        ClothA = new List<int> { 0, 0, 0, 4, 87, 0, 60, 147, 170, 0, 0, 221 },
                        ClothB = new List<int> { 0, 0, 0, 0, 8, 0, 0, 1, 5, 0, 0, 8 },
                        ExtraA = new List<int> { 107, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 8, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "M_CayoPerico_6",
                        ClothA = new List<int> { 0, 0, 0, 4, 87, 0, 96, 148, 170, 0, 0, 220 },
                        ClothB = new List<int> { 0, 0, 0, 0, 15, 0, 0, 11, 9, 0, 0, 15 },
                        ExtraA = new List<int> { 104, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 15, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "M_CayoPerico_7",
                        ClothA = new List<int> { 0, 0, 0, 4, 87, 0, 96, 146, 170, 0, 0, 220 },
                        ClothB = new List<int> { 0, 0, 0, 0, 16, 0, 0, 4, 8, 0, 0, 16 },
                        ExtraA = new List<int> { 105, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 16, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "M_CayoPerico_8",
                        ClothA = new List<int> { 0, 0, 0, 11, 9, 0, 73, 0, 15, 0, 0, 222 },
                        ClothB = new List<int> { 0, 0, 0, 0, 7, 0, 6, 0, 0, 0, 0, 23 },
                        ExtraA = new List<int> { 142, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 19, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "M_CayoPerico_9",
                        ClothA = new List<int> { 0, 0, 0, 0, 0, 0, 59, 0, 171, 0, 0, 325 },
                        ClothB = new List<int> { 0, 0, 0, 0, 6, 0, 23, 0, 14, 0, 0, 12 },
                        ExtraA = new List<int> { 106, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 23, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB9);
                    ClothX myCB10 = new ClothX
                    {
                        Title = "M_CayoPerico_10",
                        ClothA = new List<int> { 0, 0, 0, 0, 122, 0, 54, 0, 171, 0, 0, 208 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 18 },
                        ExtraA = new List<int> { 60, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "M_CayoPerico_11",
                        ClothA = new List<int> { 0, 0, 0, 11, 122, 0, 71, 0, 15, 0, 0, 222 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 24 },
                        ExtraA = new List<int> { 107, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 24, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "M_CayoPerico_12",
                        ClothA = new List<int> { 0, 0, 0, 5, 86, 0, 61, 0, 15, 0, 0, 237 },
                        ClothB = new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "M_CayoPerico_13",
                        ClothA = new List<int> { 0, 0, 0, 15, 86, 0, 73, 0, 15, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, 17, 0, 6, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                    ClothX myCB14 = new ClothX
                    {
                        Title = "M_CayoPerico_14",
                        ClothA = new List<int> { 0, 0, 0, 15, 124, 0, 71, 0, 171, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, 19, 0, 1, 0, 8, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB14);
                    ClothX myCB15 = new ClothX
                    {
                        Title = "M_CayoPerico_15",
                        ClothA = new List<int> { 0, 0, 0, 2, 124, 0, 97, 0, 171, 0, 0, 238 },
                        ClothB = new List<int> { 0, 0, 0, 0, 16, 0, 0, 0, 2, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB15);
                    ClothX myCB16 = new ClothX
                    {
                        Title = "M_CayoPerico_16",
                        ClothA = new List<int> { 0, 185, 0, 174, 98, 0, 71, 0, 15, 0, 0, 253 },
                        ClothB = new List<int> { 0, 8, 0, 0, 1, 0, 4, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB16);
                    ClothX myCB17 = new ClothX
                    {
                        Title = "M_CayoPerico_17",
                        ClothA = new List<int> { 0, 52, 0, 174, 124, 0, 25, 0, 15, 0, 0, 336 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 },
                        ExtraA = new List<int> { 147, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB17);
                    ClothX myCB18 = new ClothX
                    {
                        Title = "M_CayoPerico_18",
                        ClothA = new List<int> { 0, 132, 0, 174, 125, 0, 73, 0, 15, 0, 0, 251 },
                        ClothB = new List<int> { 0, 8, 0, 0, 1, 0, 0, 0, 0, 0, 0, 25 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB18);
                    ClothX myCB19 = new ClothX
                    {
                        Title = "M_CayoPerico_19",
                        ClothA = new List<int> { 0, 185, 0, 174, 130, 0, 96, 0, 15, 0, 0, 328 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB19);
                    ClothX myCB20 = new ClothX
                    {
                        Title = "M_CayoPerico_20",
                        ClothA = new List<int> { 0, 0, 0, 12, 0, 0, 10, 0, 11, 0, 0, 338 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 12, 0, 7, 0, 0, 3 },
                        ExtraA = new List<int> { -1, 5, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB20);
                    ClothX myCB21 = new ClothX
                    {
                        Title = "M_CayoPerico_21",
                        ClothA = new List<int> { 0, 0, 0, 184, 1, 0, 4, 0, 141, 0, 0, 346 },
                        ClothB = new List<int> { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 24 },
                        ExtraA = new List<int> { -1, 7, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB21);
                    ClothX myCB22 = new ClothX
                    {
                        Title = "M_CayoPerico_22",
                        ClothA = new List<int> { 0, 0, 0, 12, 22, 0, 1, 0, 15, 0, 0, 12 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB22);
                    ClothX myCB23 = new ClothX
                    {
                        Title = "M_CayoPerico_23",
                        ClothA = new List<int> { 0, 0, 0, 184, 0, 0, 12, 0, 23, 0, 0, 346 },
                        ClothB = new List<int> { 0, 0, 0, 0, 12, 0, 6, 0, 1, 0, 0, 20 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB23);
                    ClothX myCB24 = new ClothX
                    {
                        Title = "M_CayoPerico_24",
                        ClothA = new List<int> { 0, 0, 0, 0, 4, 0, 4, 0, 172, 0, 0, 9 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 12, 0, 0, 14 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB24);
                    ClothX myCB25 = new ClothX
                    {
                        Title = "M_CayoPerico_25",
                        ClothA = new List<int> { 0, 186, 0, 0, 118, 0, 94, 0, 172, 0, 0, 9 },
                        ClothB = new List<int> { 0, 2, 0, 0, 0, 0, 1, 0, 1, 0, 0, 2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB25);
                    ClothX myCB26 = new ClothX
                    {
                        Title = "M_CayoPerico_26",
                        ClothA = new List<int> { 0, 0, 0, 4, 117, 0, 75, 0, 172, 0, 0, 305 },
                        ClothB = new List<int> { 0, 0, 0, 0, 9, 0, 21, 0, 2, 0, 0, 23 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB26);
                    ClothX myCB27 = new ClothX
                    {
                        Title = "M_CayoPerico_27",
                        ClothA = new List<int> { 0, 101, 0, 0, 117, 0, 31, 0, 172, 0, 0, 73 },
                        ClothB = new List<int> { 0, 11, 0, 0, 10, 0, 4, 0, 19, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB27);
                }
                else if (iSyle == 10)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Services_0",
                        ClothA = new List<int> { 0, 0, -1, 0, 35, 0, 25, 0, 58, 0, 0, 55 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_Services_1",
                        ClothA = new List<int> { 0, 0, -1, 0, 35, 0, 25, 0, 58, 0, 0, 55 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 46, 1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, 1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }//police
                else if (iSyle == 11)
                {
                    ClothX myCB2 = new ClothX
                    {
                        Title = "M_Services_2",
                        ClothA = new List<int> { 0, 0, -1, 85, 96, 0, 51, 127, 15, 0, 58, 250 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                        ExtraA = new List<int> { 122, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "M_Services_3",
                        ClothA = new List<int> { 0, 0, -1, 85, 96, 0, 51, 127, 15, 0, 58, 250 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 },
                        ExtraA = new List<int> { 122, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "M_Services_4",
                        ClothA = new List<int> { 0, 0, -1, 90, 96, 0, 51, 126, 15, 0, 57, 249 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 122, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "M_Services_5",
                        ClothA = new List<int> { 0, 0, -1, 90, 96, 0, 51, 126, 15, 0, 57, 249 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 122, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                }//Ambulance
                else if (iSyle == 12)
                {
                    ClothX myCB6 = new ClothX
                    {
                        Title = "M_Services_6",
                        ClothA = new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 137, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "M_Services_7",
                        ClothA = new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 138, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "M_Services_8",
                        ClothA = new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 15, 0, 64, 315 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 138, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "M_Services_9",
                        ClothA = new List<int> { 0, 0, 0, 4, 120, 0, 51, 0, 151, 0, 64, 314 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 137, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB9);
                }//fire
                else if (iSyle == 13)
                {
                    ClothX myCB10 = new ClothX
                    {
                        Title = "M_Services_10",
                        ClothA = new List<int> { 0, 0, 0, 1, 37, 0, 21, 38, 13, 54, 0, 59 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 2, 15, 0, 0, 0, 2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "M_Services_11",
                        ClothA = new List<int> { 0, 0, 0, 4, 10, 0, 20, 38, 10, 53, 0, 28 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, 8, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 5, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "M_Services_12",
                        ClothA = new List<int> { 0, 0, 0, 12, 28, 0, 10, 37, 11, 53, 0, 4 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, 8, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 6, -1, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "M_Services_13",
                        ClothA = new List<int> { 0, 0, 0, 4, 25, 0, 21, 21, 10, 55, 0, 23 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 11, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                }//fib
            }
            else
            {
                if (iSyle == 1)
                {
                    iText = RandomNum.RandInt(0, 11);
                    iText2 = RandomNum.RandInt(0, 11);
                    iText3 = RandomNum.RandInt(0, 4);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Beach_0",
                        ClothA = new List<int> { 0, 0, -1, 11, 17, 0, 16, 11, 3, 0, 0, 36 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 2, 0, 0, 0, iText3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomNum.RandInt(0, 15);
                    iText2 = RandomNum.RandInt(0, 15);
                    iText3 = RandomNum.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Beach_1",
                        ClothA = new List<int> { 0, 0, -1, 15, 12, 0, 3, 11, 3, 0, 0, 18 },
                        ClothB = new List<int> { 0, 0, 0, 0, 15, 0, 15, 1, 0, 0, 0, 11 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    iText = RandomNum.RandInt(0, 12);
                    iText2 = RandomNum.RandInt(0, 11);
                    iText3 = RandomNum.RandInt(0, 11);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_Beach_2",
                        ClothA = new List<int> { 0, 0, -1, 15, 25, 0, 16, 1, 3, 0, 0, 18 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 2, 0, 0, 0, iText3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                }
                else if (iSyle == 2)
                {
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_Highclass_3",
                        ClothA = new List<int> { 0, 0, -1, 36, 41, 0, 29, 0, 67, 0, 0, 107 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0 },
                        ExtraA = new List<int> { -1, 10, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_Highclass_4",
                        ClothA = new List<int> { 0, 0, -1, 7, 27, 0, 11, 0, 39, 0, 0, 66 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_Highclass_5",
                        ClothA = new List<int> { 0, 0, -1, 3, 43, 0, 4, 84, 65, 0, 0, 100 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 55, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 24, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_Highclass_6",
                        ClothA = new List<int> { 0, 0, -1, 3, 64, 0, 6, 23, 41, 0, 0, 58 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "F_Highclass_7",
                        ClothA = new List<int> { 0, 0, -1, 0, 85, 0, 31, 67, 3, 0, 0, 192 },
                        ClothB = new List<int> { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 95, -1, 13, -1, -1 },
                        ExtraB = new List<int> { 6, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "F_Highclass_8",
                        ClothA = new List<int> { 0, 0, -1, 3, 50, 0, 37, 0, 66, 0, 0, 104 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 5, 0, 0, 0 },
                        ExtraA = new List<int> { -1, 2, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "F_Highclass_9",
                        ClothA = new List<int> { 0, 0, -1, 7, 0, 0, 3, 85, 55, 0, 0, 66 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                        ExtraA = new List<int> { 58, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 2, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB9);
                    ClothX myCB10 = new ClothX
                    {
                        Title = "F_Highclass_10",
                        ClothA = new List<int> { 0, 0, -1, 36, 37, 0, 29, 0, 39, 0, 0, 65 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "F_Highclass_11",
                        ClothA = new List<int> { 0, 0, -1, 3, 63, 0, 41, 0, 76, 0, 0, 99 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 2, 0, 3, 0, 0, 2 },
                        ExtraA = new List<int> { -1, 2, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "F_Highclass_12",
                        ClothA = new List<int> { 0, 0, -1, 3, 37, 0, 0, 21, 38, 0, 0, 57 },
                        ClothB = new List<int> { 0, 0, 0, 0, 5, 0, 2, 0, 2, 0, 0, 5 },
                        ExtraA = new List<int> { -1, -1, 15, -1, -1 },
                        ExtraB = new List<int> { -1, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "F_Highclass_13",
                        ClothA = new List<int> { 0, 0, -1, 3, 41, 0, 39, 0, 14, 0, 0, 136 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                        ExtraA = new List<int> { -1, 4, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                    ClothX myCB14 = new ClothX
                    {
                        Title = "F_Highclass_14",
                        ClothA = new List<int> { 40, 0, -1, 3, 27, 0, 7, 0, 3, 0, 0, 98 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
                        ExtraA = new List<int> { -1, 7, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 2, -1, -1, -1 }
                    };
                    CBList.Add(myCB14);
                    ClothX myCB15 = new ClothX
                    {
                        Title = "F_Highclass_15",
                        ClothA = new List<int> { 0, 0, -1, 11, 21, 0, 0, 54, 3, 0, 0, 115 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 2 },
                        ExtraA = new List<int> { 54, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 7, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB15);
                    ClothX myCB16 = new ClothX
                    {
                        Title = "F_Highclass_16",
                        ClothA = new List<int> { 40, 0, -1, 3, 54, 0, 4, 0, 39, 0, 0, 92 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, 11, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 7, -1, -1, -1 }
                    };
                    CBList.Add(myCB16);
                    ClothX myCB17 = new ClothX
                    {
                        Title = "F_Highclass_17",
                        ClothA = new List<int> { 0, 0, -1, 3, 54, 0, 8, 0, 44, 0, 0, 66 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB17);
                }
                else if (iSyle == 3)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Midclass_0",
                        ClothA = new List<int> { 0, 0, -1, 2, 2, 0, 2, 5, 3, 0, 0, 2 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 4, 0, 0, 0, 6 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Midclass_1",
                        ClothA = new List<int> { 0, 0, -1, 0, 16, 0, 2, 2, 3, 0, 0, 0 },
                        ClothB = new List<int> { 0, 0, 0, 0, 4, 0, 5, 1, 0, 0, 0, 11 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_Midclass_2",
                        ClothA = new List<int> { 0, 0, -1, 9, 4, 0, 13, 1, 3, 0, 0, 9 },
                        ClothB = new List<int> { 0, 0, 0, 0, 9, 0, 12, 2, 0, 0, 0, 9 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_Midclass_3",
                        ClothA = new List<int> { 0, 0, -1, 3, 2, 0, 16, 2, 3, 0, 0, 3 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 6, 1, 0, 0, 0, 11 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_Midclass_4",
                        ClothA = new List<int> { 0, 0, -1, 2, 3, 0, 16, 1, 3, 0, 0, 2 },
                        ClothB = new List<int> { 0, 0, 0, 0, 7, 0, 11, 0, 0, 0, 0, 15 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_Midclass_5",
                        ClothA = new List<int> { 0, 0, -1, 3, 3, 0, 16, 1, 3, 0, 0, 3 },
                        ClothB = new List<int> { 0, 0, 0, 0, 11, 0, 1, 3, 0, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_Midclass_6",
                        ClothA = new List<int> { 0, 0, -1, 2, 0, 0, 10, 0, 2, 0, 0, 2 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, 0, -1, -1 },
                        ExtraB = new List<int> { -1, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB6);
                }
                else if (iSyle == 4)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Buisness_0",
                        ClothA = new List<int> { 0, 0, -1, 3, 41, 0, 29, 20, 39, 0, 0, 97 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 2, 5, 4, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Buisness_1",
                        ClothA = new List<int> { 0, 0, -1, 7, 54, 0, 0, 22, 38, 0, 0, 139 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 1, 6, 2, 0, 0, 2 },
                        ExtraA = new List<int> { 28, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 4, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_Buisness_2",
                        ClothA = new List<int> { 0, 0, -1, 3, 37, 0, 29, 22, 38, 0, 0, 7 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 6, 4, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_Buisness_3",
                        ClothA = new List<int> { 0, 0, -1, 1, 64, 0, 29, 0, 13, 0, 0, 137 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 7 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_Buisness_4",
                        ClothA = new List<int> { 0, 0, -1, 1, 50, 0, 29, 0, 13, 0, 0, 137 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 10, 0, 0, 8 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_Buisness_5",
                        ClothA = new List<int> { 0, 0, -1, 1, 64, 0, 29, 0, 13, 0, 0, 137 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 15, 0, 0, 13 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_Buisness_6",
                        ClothA = new List<int> { 40, 0, -1, 3, 54, 0, 1, 0, 39, 0, 0, 92 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 5, 0, 0, 1 },
                        ExtraA = new List<int> { -1, 11, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 2, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "F_Buisness_7",
                        ClothA = new List<int> { 0, 0, -1, 3, 37, 0, 0, 22, 38, 0, 0, 64 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 3, 0, 3, 0, 0, 2 },
                        ExtraA = new List<int> { 28, -1, 15, -1, -1 },
                        ExtraB = new List<int> { 3, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "F_Buisness_8",
                        ClothA = new List<int> { 0, 0, -1, 3, 37, 0, 6, 22, 38, 0, 0, 64 },
                        ClothB = new List<int> { 0, 0, 0, 0, 6, 0, 0, 12, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 28, -1, 15, -1, -1 },
                        ExtraB = new List<int> { 3, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "F_Buisness_9",
                        ClothA = new List<int> { 0, 0, -1, 3, 37, 0, 20, 22, 38, 0, 0, 64 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 7, 0, 0, 1 },
                        ExtraA = new List<int> { 28, -1, 15, -1, -1 },
                        ExtraB = new List<int> { 3, -1, 0, -1, -1 }
                    };
                    CBList.Add(myCB9);
                    ClothX myCB10 = new ClothX
                    {
                        Title = "F_Buisness_10",
                        ClothA = new List<int> { 40, 0, -1, 6, 8, 0, 8, 0, 22, 0, 0, 58 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "F_Buisness_11",
                        ClothA = new List<int> { 40, 0, -1, 6, 37, 0, 0, 0, 22, 0, 0, 57 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 8 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "F_Buisness_12",
                        ClothA = new List<int> { 40, 0, -1, 1, 27, 0, 7, 21, 38, 0, 0, 6 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "F_Buisness_13",
                        ClothA = new List<int> { 40, 0, -1, 7, 41, 0, 27, 0, 13, 0, 0, 7 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                    ClothX myCB14 = new ClothX
                    {
                        Title = "F_Buisness_14",
                        ClothA = new List<int> { 0, 0, -1, 6, 36, 0, 20, 6, 13, 0, 0, 25 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB14);
                    ClothX myCB15 = new ClothX
                    {
                        Title = "F_Buisness_15",
                        ClothA = new List<int> { 0, 0, -1, 6, 6, 0, 13, 6, 25, 0, 0, 7 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB15);
                    ClothX myCB16 = new ClothX
                    {
                        Title = "F_Buisness_16",
                        ClothA = new List<int> { 0, 0, -1, 0, 7, 0, 19, 1, 24, 0, 0, 28 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 9, 1, 3, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB16);
                }
                else if (iSyle == 5)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Epslon_1",
                        ClothA = new List<int> { 21, 0, 0, 3, 111, 0, 29, 99, 6, 0, 0, 285 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                }
                else if (iSyle == 6)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Jogger_0",
                        ClothA = new List<int> { 0, 0, -1, 14, 14, 0, 3, 3, 3, 0, 0, 14 },
                        ClothB = new List<int> { 0, 0, 0, 0, 8, 0, 1, 5, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Jogger_1",
                        ClothA = new List<int> { 0, 0, -1, 14, 2, 0, 10, 0, 3, 0, 0, 14 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 7 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_Jogger_2",
                        ClothA = new List<int> { 0, 0, -1, 7, 14, 0, 11, 2, 15, 0, 0, 10 },
                        ClothB = new List<int> { 0, 0, 0, 0, 9, 0, 0, 4, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_Jogger_3",
                        ClothA = new List<int> { 0, 0, -1, 11, 2, 0, 10, 3, 3, 0, 0, 11 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 2, 3, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_Jogger_4",
                        ClothA = new List<int> { 0, 0, -1, 14, 12, 0, 10, 3, 3, 0, 0, 14 },
                        ClothB = new List<int> { 0, 0, 0, 0, 8, 0, 3, 4, 0, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_Jogger_5",
                        ClothA = new List<int> { 0, 0, -1, 7, 2, 0, 11, 0, 16, 0, 0, 10 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 7 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_Jogger_6",
                        ClothA = new List<int> { 0, 0, -1, 7, 10, 0, 1, 1, 5, 0, 0, 10 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 13, 1, 0, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "F_Jogger_7",
                        ClothA = new List<int> { 0, 0, -1, 14, 12, 0, 4, 0, 3, 0, 0, 14 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                }
                else if (iSyle == 7)
                {
                    iText = RandomNum.RandInt(0, 11);
                    iText2 = RandomNum.RandInt(0, 4);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Swim_14",
                        ClothA = new List<int> { 0, 0, -1, 11, 17, 0, 35, 11, 3, 0, 0, 36 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, 0, 2, 0, 0, 0, iText2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomNum.RandInt(0, 11);
                    iText2 = RandomNum.RandInt(0, 10);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Swim_15",
                        ClothA = new List<int> { 0, 0, -1, 15, 17, 0, 35, 11, 3, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, 0, 2, 0, 0, 0, iText2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }
                else if (iSyle == 8)
                {
                    iText = RandomNum.RandInt(0, 10);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_BikeATV_3",
                        ClothA = new List<int> { 0, 0, -1, 18, 79, 0, 58, 0, 3, 0, 0, 180 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 90, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomNum.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_BikeATV_4",
                        ClothA = new List<int> { 0, 0, -1, 127, 69, 0, 48, 0, 14, 0, 0, 145 },
                        ClothB = new List<int> { 0, 0, 0, iText, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 62, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }
                else if (iSyle == 9)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_CayoPerico_0",
                        ClothA = new List<int> { 21, 0, 0, 229, 50, 0, 37, 0, 5, 0, 0, 373 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 17 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_CayoPerico_1",
                        ClothA = new List<int> { 21, 0, 0, 9, 14, 0, 4, 0, 14, 0, 0, 372 },
                        ClothB = new List<int> { 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_CayoPerico_2",
                        ClothA = new List<int> { 21, 0, 0, 229, 0, 0, 1, 0, 204, 0, 0, 373 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_CayoPerico_3",
                        ClothA = new List<int> { 21, 0, 0, 9, 14, 0, 5, 0, 14, 0, 0, 372 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_CayoPerico_4",
                        ClothA = new List<int> { 21, 0, 0, 3, 90, 0, 63, 117, 207, 0, 0, 231 },
                        ClothB = new List<int> { 0, 0, 0, 0, 6, 0, 0, 1, 6, 0, 0, 6 },
                        ExtraA = new List<int> { 149, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 14, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_CayoPerico_5",
                        ClothA = new List<int> { 21, 0, 0, 3, 90, 0, 63, 116, 207, 0, 0, 231 },
                        ClothB = new List<int> { 0, 0, 0, 0, 8, 0, 0, 1, 5, 0, 0, 8 },
                        ExtraA = new List<int> { 106, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 8, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_CayoPerico_6",
                        ClothA = new List<int> { 21, 0, 0, 3, 90, 0, 100, 117, 207, 0, 0, 230 },
                        ClothB = new List<int> { 0, 0, 0, 0, 15, 0, 0, 11, 9, 0, 0, 15 },
                        ExtraA = new List<int> { 103, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 15, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "F_CayoPerico_7",
                        ClothA = new List<int> { 21, 0, 0, 3, 90, 0, 100, 115, 207, 0, 0, 230 },
                        ClothB = new List<int> { 0, 0, 0, 0, 16, 0, 0, 4, 8, 0, 0, 16 },
                        ExtraA = new List<int> { 104, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 16, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "F_CayoPerico_8",
                        ClothA = new List<int> { 21, 0, 0, 9, 45, 0, 76, 0, 14, 0, 0, 232 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 6, 0, 0, 0, 0, 23 },
                        ExtraA = new List<int> { 141, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 19, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "F_CayoPerico_9",
                        ClothA = new List<int> { 21, 0, 0, 14, 1, 0, 62, 0, 208, 0, 0, 337 },
                        ClothB = new List<int> { 0, 0, 0, 0, 3, 0, 23, 0, 14, 0, 0, 12 },
                        ExtraA = new List<int> { 105, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 23, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB9);
                    ClothX myCB10 = new ClothX
                    {
                        Title = "F_CayoPerico_10",
                        ClothA = new List<int> { 21, 0, 0, 14, 128, 0, 55, 0, 208, 0, 0, 212 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 18 },
                        ExtraA = new List<int> { 60, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "F_CayoPerico_11",
                        ClothA = new List<int> { 21, 0, 0, 9, 128, 0, 74, 0, 14, 0, 0, 232 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 24 },
                        ExtraA = new List<int> { 106, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 24, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "F_CayoPerico_12",
                        ClothA = new List<int> { 21, 0, 0, 4, 89, 0, 64, 0, 3, 0, 0, 247 },
                        ClothB = new List<int> { 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "F_CayoPerico_13",
                        ClothA = new List<int> { 21, 0, 0, 4, 89, 0, 76, 0, 3, 0, 0, 5 },
                        ClothB = new List<int> { 0, 0, 0, 0, 17, 0, 23, 0, 0, 0, 0, 7 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                    ClothX myCB14 = new ClothX
                    {
                        Title = "F_CayoPerico_14",
                        ClothA = new List<int> { 21, 0, 0, 15, 130, 0, 25, 0, 208, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, 19, 0, 0, 0, 8, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB14);
                    ClothX myCB15 = new ClothX
                    {
                        Title = "F_CayoPerico_15",
                        ClothA = new List<int> { 21, 0, 0, 12, 130, 0, 101, 0, 208, 0, 0, 118 },
                        ClothB = new List<int> { 0, 0, 0, 0, 16, 0, 0, 0, 2, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB15);
                    ClothX myCB16 = new ClothX
                    {
                        Title = "F_CayoPerico_16",
                        ClothA = new List<int> { 21, 185, 0, 215, 101, 0, 74, 0, 14, 0, 0, 261 },
                        ClothB = new List<int> { 0, 8, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB16);
                    ClothX myCB17 = new ClothX
                    {
                        Title = "F_CayoPerico_17",
                        ClothA = new List<int> { 21, 52, 0, 215, 130, 0, 64, 0, 14, 0, 0, 351 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 },
                        ExtraA = new List<int> { 146, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB17);
                    ClothX myCB18 = new ClothX
                    {
                        Title = "F_CayoPerico_18",
                        ClothA = new List<int> { 21, 132, 0, 219, 131, 0, 76, 0, 14, 0, 0, 259 },
                        ClothB = new List<int> { 0, 8, 0, 0, 1, 0, 0, 0, 0, 0, 0, 25 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB18);
                    ClothX myCB19 = new ClothX
                    {
                        Title = "F_CayoPerico_19",
                        ClothA = new List<int> { 21, 185, 0, 215, 136, 0, 100, 0, 14, 0, 0, 343 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB19);
                    ClothX myCB20 = new ClothX
                    {
                        Title = "F_CayoPerico_20",
                        ClothA = new List<int> { 21, 0, 0, 3, 0, 0, 9, 0, 39, 0, 0, 353 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 7, 0, 0, 3 },
                        ExtraA = new List<int> { -1, 11, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB20);
                    ClothX myCB21 = new ClothX
                    {
                        Title = "F_CayoPerico_21",
                        ClothA = new List<int> { 21, 0, 0, 229, 1, 0, 3, 0, 204, 0, 0, 364 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 24 },
                        ExtraA = new List<int> { -1, 2, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB21);
                    ClothX myCB22 = new ClothX
                    {
                        Title = "F_CayoPerico_22",
                        ClothA = new List<int> { 21, 0, 0, 9, 23, 0, 1, 0, 3, 0, 0, 9 },
                        ClothB = new List<int> { 0, 0, 0, 0, 5, 0, 1, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB22);
                    ClothX myCB23 = new ClothX
                    {
                        Title = "F_CayoPerico_23",
                        ClothA = new List<int> { 21, 0, 0, 229, 4, 0, 13, 0, 4, 0, 0, 364 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 20 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB23);
                    ClothX myCB24 = new ClothX
                    {
                        Title = "F_CayoPerico_24",
                        ClothA = new List<int> { 21, 0, 0, 14, 0, 0, 3, 0, 209, 0, 0, 14 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 2, 0, 12, 0, 0, 4 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB24);
                    ClothX myCB25 = new ClothX
                    {
                        Title = "F_CayoPerico_25",
                        ClothA = new List<int> { 21, 186, 0, 14, 124, 0, 97, 0, 209, 0, 0, 14 },
                        ClothB = new List<int> { 0, 2, 0, 0, 0, 0, 1, 0, 1, 0, 0, 3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB25);
                    ClothX myCB26 = new ClothX
                    {
                        Title = "F_CayoPerico_26",
                        ClothA = new List<int> { 21, 0, 0, 3, 123, 0, 79, 0, 209, 0, 0, 316 },
                        ClothB = new List<int> { 0, 0, 0, 0, 9, 0, 21, 0, 2, 0, 0, 23 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB26);
                    ClothX myCB27 = new ClothX
                    {
                        Title = "F_CayoPerico_27",
                        ClothA = new List<int> { 21, 101, 0, 14, 123, 0, 32, 0, 209, 0, 0, 68 },
                        ClothB = new List<int> { 0, 11, 0, 0, 10, 0, 4, 0, 19, 0, 0, 10 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB27);
                }
                else if (iSyle == 10)
                {
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Services_0",
                        ClothA = new List<int> { 0, 0, -1, 14, 34, 0, 25, 0, 35, 0, 0, 48 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Services_1",
                        ClothA = new List<int> { 0, 0, -1, 14, 34, 0, 25, 0, 35, 0, 0, 48 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 45, 0, -1, -1, -1 },
                        ExtraB = new List<int> { 0, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }//police
                else if (iSyle == 11)
                {
                    ClothX myCB2 = new ClothX
                    {
                        Title = "F_Services_2",
                        ClothA = new List<int> { 0, 0, -1, 109, 99, 0, 52, 97, 3, 0, 66, 258 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 121, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX
                    {
                        Title = "F_Services_3",
                        ClothA = new List<int> { 0, 0, -1, 109, 99, 0, 52, 97, 3, 0, 66, 258 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 121, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB3);
                    ClothX myCB4 = new ClothX
                    {
                        Title = "F_Services_4",
                        ClothA = new List<int> { 0, 0, -1, 105, 99, 0, 52, 96, 3, 0, 65, 257 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 121, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB4);
                    ClothX myCB5 = new ClothX
                    {
                        Title = "F_Services_5",
                        ClothA = new List<int> { 0, 0, -1, 105, 99, 0, 52, 96, 3, 0, 65, 257 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 121, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB5);
                }//Ambulance
                else if (iSyle == 12)
                {
                    ClothX myCB6 = new ClothX
                    {
                        Title = "F_Services_6",
                        ClothA = new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 136, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB6);
                    ClothX myCB7 = new ClothX
                    {
                        Title = "F_Services_7",
                        ClothA = new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { 137, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB7);
                    ClothX myCB8 = new ClothX
                    {
                        Title = "F_Services_8",
                        ClothA = new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 3, 0, 73, 326 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 137, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB8);
                    ClothX myCB9 = new ClothX
                    {
                        Title = "F_Services_9",
                        ClothA = new List<int> { 21, 0, 0, 3, 126, 0, 52, 0, 187, 0, 73, 325 },
                        ClothB = new List<int> { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                        ExtraA = new List<int> { 136, -1, -1, -1, -1 },
                        ExtraB = new List<int> { 0, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB9);
                }//fire
                else if (iSyle == 13)
                {
                    ClothX myCB10 = new ClothX
                    {
                        Title = "F_Services_10",
                        ClothA = new List<int> { 21, 0, 0, 9, 6, 0, 29, 0, 3, 55, 0, 9 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4 },
                        ExtraA = new List<int> { -1, 11, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 3, -1, -1, -1 }
                    };
                    CBList.Add(myCB10);
                    ClothX myCB11 = new ClothX
                    {
                        Title = "F_Services_11",
                        ClothA = new List<int> { 21, 0, 0, 1, 6, 0, 29, 0, 69, 54, 0, 6 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4 },
                        ExtraA = new List<int> { -1, 11, -1, -1, -1 },
                        ExtraB = new List<int> { -1, 0, -1, -1, -1 }
                    };
                    CBList.Add(myCB11);
                    ClothX myCB12 = new ClothX
                    {
                        Title = "F_Services_12",
                        ClothA = new List<int> { 21, 0, 0, 3, 7, 0, 13, 0, 39, 53, 0, 57 },
                        ClothB = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB12);
                    ClothX myCB13 = new ClothX
                    {
                        Title = "F_Services_13",
                        ClothA = new List<int> { 21, 0, 0, 3, 37, 0, 13, 0, 39, 53, 0, 57 },
                        ClothB = new List<int> { 0, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB13);
                }//fib
            }

            return CBList[RandomNum.RandInt(0, CBList.Count)];
        }
        public static void PrintOutFit(int iNub)
        {
            string s = "F_Services_";
            if (Game.Player.Character.Gender == Gender.Male)
                s = "M_Services_";

            List<int> A1 = new List<int>();
            List<int> A2 = new List<int>();
            List<int> B1 = new List<int>();
            List<int> B2 = new List<int>();

            for (int i = 0; i < 12; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, i);
                A1.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character.Handle, i);
                if (iTextId == 255)
                    iTextId = 0;
                A2.Add(iTextId);
            }
            for (int i = 0; i < 5; i++)
            {
                int iDrawId = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, i);
                B1.Add(iDrawId);
                int iTextId = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character.Handle, i);
                if (iTextId == 255)
                    iTextId = 0;
                B2.Add(iTextId);
            }
            string sName = "myCB" + iNub;

            BackUpOut("ClothX " + sName + " = new ClothX");
            BackUpOut("{");
            BackUpOut("    Title = \"" + s + iNub + "\",");
            BackUpOut("    ClothA = new List<int> { " + A1[0] + ", " + A1[1] + ", " + A1[2] + ", " + A1[3] + ", " + A1[4] + ", " + A1[5] + ", " + A1[6] + ", " + A1[7] + ", " + A1[8] + ", " + A1[9] + ", " + A1[10] + ", " + A1[11] + " },");
            BackUpOut("    ClothB = new List<int> { " + A2[0] + ", " + A2[1] + ", " + A2[2] + ", " + A2[3] + ", " + A2[4] + ", " + A2[5] + ", " + A2[6] + ", " + A2[7] + ", " + A2[8] + ", " + A2[9] + ", " + A2[10] + ", " + A2[11] + " },");
            BackUpOut("    ExtraA = new List<int> { " + B1[0] + ", " + B1[1] + ", " + B1[2] + ", " + B1[3] + ", " + B1[4] + " },");
            BackUpOut("    ExtraB = new List<int> { " + B2[0] + ", " + B2[1] + ", " + B2[2] + ", " + B2[3] + ", " + B2[4] + " }");
            BackUpOut("};");
            BackUpOut("CBList.Add("+ sName + ");");
        }
        public static void WriteObj(string sLogs, TextWriter tEx)
        {
            try
            {
                tEx.WriteLine(sLogs);
            }
            catch
            {

            }
        }
        public static void BackUpOut(string myAss)
        {
            using (StreamWriter tEx = File.AppendText("" + Directory.GetCurrentDirectory() + "/Scripts/RandomStart/MyOut.txt"))
                WriteObj(myAss, tEx);
        }
    }
}