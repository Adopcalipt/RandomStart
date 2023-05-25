using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using RandomStart.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RandomStart
{
    public class RSMain : Script
    {
        private bool bIsReady = true;
        private int iSlowDown = 0;

        private MenuPool MyMenuPool = new MenuPool();

        private List<HairSets> MHairsets = new List<HairSets>
        {
            new HairSets(0, 0, "H_FMM_0_0", "Close Shave", -1, -1),
            new HairSets(1, 0, "H_FMM_1_0", "Buzzcut Dark Brown", -1, -1),
            new HairSets(1, 1, "H_FMM_1_1", "Buzzcut Light Brown", -1, -1),
            new HairSets(1, 2, "H_FMM_1_2", "Buzzcut Auburn", -1, -1),
            new HairSets(1, 3, "H_FMM_1_3", "Buzzcut Blond", -1, -1),
            new HairSets(1, 4, "H_FMM_1_4", "Buzzcut Black", -1, -1),
            new HairSets(2, 0, "H_FMM_2_0", "Faux Hawk Dark Brown", -1, -1),
            new HairSets(2, 1, "H_FMM_2_1", "Faux Hawk Light Brown", -1, -1),
            new HairSets(2, 2, "H_FMM_2_2", "Faux Hawk Auburn", -1, -1),
            new HairSets(2, 3, "H_FMM_2_3", "Faux Hawk Blond", -1, -1),
            new HairSets(2, 4, "H_FMM_2_4", "Faux Hawk Black", -1, -1),
            new HairSets(2, 5, "H_FMM_2_5", "Faux Hawk Purple", -1, -1),
            new HairSets(3, 0, "H_FMM_3_0", "Hipster Shaved Dark Brown", -1, -1),
            new HairSets(3, 1, "H_FMM_3_1", "Hipster Shaved Light Brown", -1, -1),
            new HairSets(3, 2, "H_FMM_3_2", "Hipster Shaved Auburn", -1, -1),
            new HairSets(3, 3, "H_FMM_3_3", "Hipster Shaved Blond", -1, -1),
            new HairSets(3, 4, "H_FMM_3_4", "Hipster Shaved Black", -1, -1),
            new HairSets(3, 5, "H_FMM_3_5", "Hipster Shaved Red", -1, -1),
            new HairSets(4, 0, "H_FMM_4_0", "Side Parting Spiked Dark Brown", -1, -1),
            new HairSets(4, 1, "H_FMM_4_1", "Side Parting Spiked Light Brown", -1, -1),
            new HairSets(4, 2, "H_FMM_4_2", "Side Parting Spiked Auburn", -1, -1),
            new HairSets(4, 3, "H_FMM_4_3", "Side Parting Spiked Blond", -1, -1),
            new HairSets(4, 4, "H_FMM_4_4", "Side Parting Spiked Black", -1, -1),
            new HairSets(4, 6, "H_FMM_4_6", "Side Parting Spiked Blue", -1, -1),
            new HairSets(5, 0, "H_FMM_5_0", "Shorter Cut Dark Brown", -1, -1),
            new HairSets(5, 1, "H_FMM_5_1", "Shorter Cut Light Brown", -1, -1),
            new HairSets(5, 2, "H_FMM_5_2", "Shorter Cut Auburn", -1, -1),
            new HairSets(5, 3, "H_FMM_5_3", "Shorter Cut Blond", -1, -1),
            new HairSets(5, 4, "H_FMM_5_4", "Shorter Cut Black", -1, -1),
            new HairSets(5, 5, "H_FMM_5_5", "Shorter Cut Green", -1, -1),
            new HairSets(6, 0, "H_FMM_6_0", "Biker Dark Brown", -1, -1),
            new HairSets(6, 1, "H_FMM_6_1", "Biker Light Brown", -1, -1),
            new HairSets(6, 2, "H_FMM_6_2", "Biker Auburn", -1, -1),
            new HairSets(6, 3, "H_FMM_6_3", "Biker Blond", -1, -1),
            new HairSets(6, 4, "H_FMM_6_4", "Biker Black", -1, -1),
            new HairSets(6, 5, "H_FMM_6_5", "Biker Purple Fade", -1, -1),
            new HairSets(7, 0, "H_FMM_7_0", "Ponytail Dark Brown", -1, -1),
            new HairSets(7, 1, "H_FMM_7_1", "Ponytail Light Brown", -1, -1),
            new HairSets(7, 2, "H_FMM_7_2", "Ponytail Auburn", -1, -1),
            new HairSets(7, 3, "H_FMM_7_3", "Ponytail Blond", -1, -1),
            new HairSets(7, 4, "H_FMM_7_4", "Ponytail Black", -1, -1),
            new HairSets(7, 6, "H_FMM_7_6", "Ponytail Purple", -1, -1),
            new HairSets(8, 0, "H_FMM_8_0", "Cornrows Dark Brown", -1, -1),
            new HairSets(8, 1, "H_FMM_8_1", "Cornrows Light Brown", -1, -1),
            new HairSets(8, 2, "H_FMM_8_2", "Cornrows Auburn", -1, -1),
            new HairSets(8, 3, "H_FMM_8_3", "Cornrows Blond", -1, -1),
            new HairSets(8, 4, "H_FMM_8_4", "Cornrows Black", -1, -1),
            new HairSets(9, 0, "H_FMM_9_0", "Slicked Dark Brown", -1, -1),
            new HairSets(9, 1, "H_FMM_9_1", "Slicked Light Brown", -1, -1),
            new HairSets(9, 2, "H_FMM_9_2", "Slicked Auburn", -1, -1),
            new HairSets(9, 3, "H_FMM_9_3", "Slicked Blond", -1, -1),
            new HairSets(9, 4, "H_FMM_9_4", "Slicked Black", -1, -1),
            new HairSets(9, 6, "H_FMM_9_6", "Slicked Red", -1, -1),
            new HairSets(10, 0, "H_FMM_10_0", "Short Brushed Dark Brown", -1, -1),
            new HairSets(10, 1, "H_FMM_10_1", "Short Brushed Light Brown", -1, -1),
            new HairSets(10, 2, "H_FMM_10_2", "Short Brushed Auburn", -1, -1),
            new HairSets(10, 3, "H_FMM_10_3", "Short Brushed Blond", -1, -1),
            new HairSets(10, 4, "H_FMM_10_4", "Short Brushed Black", -1, -1),
            new HairSets(11, 0, "H_FMM_11_0", "Spikey Dark Brown", -1, -1),
            new HairSets(11, 1, "H_FMM_11_1", "Spikey Light Brown", -1, -1),
            new HairSets(11, 2, "H_FMM_11_2", "Spikey Auburn", -1, -1),
            new HairSets(11, 3, "H_FMM_11_3", "Spikey Blond", -1, -1),
            new HairSets(11, 4, "H_FMM_11_4", "Spikey Black", -1, -1),
            new HairSets(11, 5, "H_FMM_11_5", "Spikey Blue", -1, -1),
            new HairSets(12, 0, "H_FMM_12_0", "Caesar Dark Brown", -1, -1),
            new HairSets(12, 1, "H_FMM_12_1", "Caesar Light Brown", -1, -1),
            new HairSets(12, 2, "H_FMM_12_2", "Caesar Auburn", -1, -1),
            new HairSets(12, 3, "H_FMM_12_3", "Caesar Blond", -1, -1),
            new HairSets(12, 4, "H_FMM_12_4", "Caesar Black", -1, -1),
            new HairSets(13, 0, "H_FMM_13_0", "Chopped Dark Brown", -1, -1),
            new HairSets(13, 1, "H_FMM_13_1", "Chopped Light Brown", -1, -1),
            new HairSets(13, 2, "H_FMM_13_2", "Chopped Auburn", -1, -1),
            new HairSets(13, 3, "H_FMM_13_3", "Chopped Blond", -1, -1),
            new HairSets(13, 4, "H_FMM_13_4", "Chopped Black", -1, -1),
            new HairSets(13, 5, "H_FMM_13_5", "Chopped Green", -1, -1),
            new HairSets(14, 0, "H_FMM_14_0", "Dreads Dark Brown", -1, -1),
            new HairSets(14, 1, "H_FMM_14_1", "Dreads Light Brown", -1, -1),
            new HairSets(14, 2, "H_FMM_14_2", "Dreads Auburn", -1, -1),
            new HairSets(14, 3, "H_FMM_14_3", "Dreads Blond", -1, -1),
            new HairSets(14, 4, "H_FMM_14_4", "Dreads Black", -1, -1),
            new HairSets(15, 0, "H_FMM_15_0", "Long Hair Dark Brown", -1, -1),
            new HairSets(15, 1, "H_FMM_15_1", "Long Hair Light Brown", -1, -1),
            new HairSets(15, 2, "H_FMM_15_2", "Long Hair Auburn", -1, -1),
            new HairSets(15, 3, "H_FMM_15_3", "Long Hair Blond", -1, -1),
            new HairSets(15, 4, "H_FMM_15_4", "Long Hair Black", -1, -1),
            new HairSets(15, 5, "H_FMM_15_5", "Long Hair Purple Fade", -1, -1),
            new HairSets(16, 0, "CLO_BBM_H_00", "Shaggy Curls Dark Brown", -1, -1),
            new HairSets(16, 1, "CLO_BBM_H_01", "Shaggy Curls Light Brown", -1, -1),
            new HairSets(16, 2, "CLO_BBM_H_02", "Shaggy Curls Auburn", -1, -1),
            new HairSets(16, 3, "CLO_BBM_H_03", "Shaggy Curls Blonde", -1, -1),
            new HairSets(16, 4, "CLO_BBM_H_04", "Shaggy Curls Black", -1, -1),
            new HairSets(17, 0, "CLO_BBM_H_05", "Surfer Dude Dark Brown", -1, -1),
            new HairSets(17, 1, "CLO_BBM_H_06", "Surfer Dude Light Brown", -1, -1),
            new HairSets(17, 2, "CLO_BBM_H_07", "Surfer Dude Auburn", -1, -1),
            new HairSets(17, 3, "CLO_BBM_H_08", "Surfer Dude Blonde", -1, -1),
            new HairSets(17, 4, "CLO_BBM_H_09", "Surfer Dude Black", -1, -1),
            new HairSets(18, 0, "CLO_BUS_H_0_0", "Short Side Part Dark Brown", -2086773, 224730392),
            new HairSets(18, 1, "CLO_BUS_H_0_1", "Short Side Part Light Brown", -2086773, 1988816738),
            new HairSets(18, 2, "CLO_BUS_H_0_2", "Short Side Part Auburn", -2086773, 736778786),
            new HairSets(18, 3, "CLO_BUS_H_0_3", "Short Side Part Blonde", -2086773, 439629494),
            new HairSets(18, 4, "CLO_BUS_H_0_4", "Short Side Part Black", -2086773, 1048444745),
            new HairSets(19, 0, "CLO_BUS_H_1_0", "High Slicked Sides Dark Brown", -2086773, 2140603469),
            new HairSets(19, 1, "CLO_BUS_H_1_1", "High Slicked Sides Light Brown", -2086773, -681528353),
            new HairSets(19, 2, "CLO_BUS_H_1_2", "High Slicked Sides Auburn", -2086773, 1006238992),
            new HairSets(19, 3, "CLO_BUS_H_1_3", "High Slicked Sides Blonde", -2086773, 214245031),
            new HairSets(19, 4, "CLO_BUS_H_1_4", "High Slicked Sides Black", -2086773, 689952604),
            new HairSets(20, 0, "CLO_HP_HR_0_0", "Long Slicked Dark Brown", -1398869298, 965649655),
            new HairSets(20, 1, "CLO_HP_HR_0_1", "Long Slicked Light Brown", -1398869298, 718800778),
            new HairSets(20, 2, "CLO_HP_HR_0_2", "Long Slicked Auburn", -1398869298, 1959959422),
            new HairSets(20, 3, "CLO_HP_HR_0_3", "Long Slicked Blonde", -1398869298, 1200177388),
            new HairSets(20, 4, "CLO_HP_HR_0_4", "Long Slicked Black", -1398869298, -1874439579),
            new HairSets(21, 0, "CLO_HP_HR_1_0", "Hipster Youth Dark Brown", -1398869298, -1679505893),
            new HairSets(21, 1, "CLO_HP_HR_1_1", "Hipster Youth Blonde", -1398869298, -1976229188),
            new HairSets(21, 2, "CLO_HP_HR_1_2", "Hipster Youth Auburn", -1398869298, 2037875009),
            new HairSets(21, 3, "CLO_HP_HR_1_3", "Hipster Youth Light Brown", -1398869298, -235146664),
            new HairSets(21, 4, "CLO_HP_HR_1_4", "Hipster Youth Black", -1398869298, -441853516),
            new HairSets(22, 0, "CLO_IND_H_0_0", "Mullet Dark Brown", -1, -1),
            new HairSets(22, 1, "CLO_IND_H_0_1", "Mullet Light Brown", -1, -1),
            new HairSets(22, 2, "CLO_IND_H_0_2", "Mullet Auburn", -1, -1),
            new HairSets(22, 3, "CLO_IND_H_0_3", "Mullet Blonde", -1, -1),
            new HairSets(22, 4, "CLO_IND_H_0_4", "Mullet Black", -1, -1),
            new HairSets(24, 0, "CLO_S1M_H_0_0", "Classic Cornrows", 62137527, 534771589),
            new HairSets(25, 0, "CLO_S1M_H_1_0", "Palm Cornrows", 62137527, -1340139519),
            new HairSets(26, 0, "CLO_S1M_H_2_0", "Lightning Cornrows", 62137527, -849980761),
            new HairSets(27, 0, "CLO_S1M_H_3_0", "Whipped Cornrows", 62137527, -551553478),
            new HairSets(28, 0, "CLO_S2M_H_0_0", "Zig Zag Cornrows", 1529191571, -1431204514),
            new HairSets(29, 0, "CLO_S2M_H_1_0", "Snail Cornrows", 1529191571, -1133334304),
            new HairSets(30, 0, "CLO_S2M_H_2_0", "Hightop", 1529191571, -1809784771),
            new HairSets(31, 0, "CLO_BIM_H_0_0", "Loose Swept Back", -240234547, 1431846777),
            new HairSets(32, 0, "CLO_BIM_H_1_0", "Undercut Swept Back", -240234547, -460168116),
            new HairSets(33, 0, "CLO_BIM_H_2_0", "Undercut Swept Side", -240234547, -311245907),
            new HairSets(34, 0, "CLO_BIM_H_3_0", "Spiked Mohawk", -240234547, -942031335),
            new HairSets(35, 0, "CLO_BIM_H_4_0", "Mod", -240234547, -644503216),
            new HairSets(36, 0, "CLO_BIM_H_5_0", "Layered Mod", -240234547, 211198653),
            new HairSets(37, 0, "CC_M_HS_1", "Buzzcut", 598190139, 739308497),
            new HairSets(38, 0, "CC_M_HS_2", "Faux Hawk", 598190139, 495343292),
            new HairSets(39, 0, "CC_M_HS_3", "Hipster", 598190139, -1686711653),
            new HairSets(40, 0, "CC_M_HS_4", "Side Parting", 598190139, 1187457341),
            new HairSets(41, 0, "CC_M_HS_5", "Shorter Cut", 598190139, 956403122),
            new HairSets(42, 0, "CC_M_HS_6", "Biker", 598190139, 1647042566),
            new HairSets(43, 0, "CC_M_HS_7", "Ponytail", 598190139, -461478743),
            new HairSets(44, 0, "CC_M_HS_8", "Cornrows", 598190139, -1883325653),
            new HairSets(45, 0, "CC_M_HS_9", "Slicked", 598190139, -2114248796),
            new HairSets(46, 0, "CC_M_HS_10", "Short Brushed", 598190139, 314228205),
            new HairSets(47, 0, "CC_M_HS_11", "Spikey", 598190139, 1503775674),
            new HairSets(48, 0, "CC_M_HS_12", "Caesar", 598190139, 1862399610),
            new HairSets(49, 0, "CC_M_HS_13", "Chopped", 598190139, 708472048),
            new HairSets(50, 0, "CC_M_HS_14", "Dreads", 598190139, -1207367545),
            new HairSets(51, 0, "CC_M_HS_15", "Long Hair", 598190139, 111650251),
            new HairSets(52, 0, "CLO_BBM_H_00", "Shaggy Curls Dark Brown", -1, -1),
            new HairSets(53, 0, "CLO_BBM_H_05", "Surfer Dude Dark Brown", -1, -1),
            new HairSets(54, 0, "CLO_BUS_H_0_0", "Short Side Part Dark Brown", -2086773, 224730392),
            new HairSets(55, 0, "CLO_BUS_H_1_0", "High Slicked Sides Dark Brown", -2086773, 2140603469),
            new HairSets(56, 0, "CLO_HP_HR_0_0", "Long Slicked Dark Brown", -1398869298, 965649655),
            new HairSets(57, 0, "CLO_HP_HR_1_0", "Hipster Youth Dark Brown", -1398869298, -1679505893),
            new HairSets(58, 0, "CLO_IND_H_0_0", "Mullet Dark Brown", -1, -1),
            new HairSets(59, 0, "CLO_S1M_H_0_0", "Classic Cornrows", 62137527, 534771589),
            new HairSets(60, 0, "CLO_S1M_H_1_0", "Palm Cornrows", 62137527, -1340139519),
            new HairSets(61, 0, "CLO_S1M_H_2_0", "Lightning Cornrows", 62137527, -849980761),
            new HairSets(62, 0, "CLO_S1M_H_3_0", "Whipped Cornrows", 62137527, -551553478),
            new HairSets(63, 0, "CLO_S2M_H_0_0", "Zig Zag Cornrows", 1529191571, -1431204514),
            new HairSets(64, 0, "CLO_S2M_H_1_0", "Snail Cornrows", 1529191571, -1133334304),
            new HairSets(65, 0, "CLO_S2M_H_2_0", "Hightop", 1529191571, -1809784771),
            new HairSets(66, 0, "CLO_BIM_H_0_0", "Loose Swept Back", -240234547, 1431846777),
            new HairSets(67, 0, "CLO_BIM_H_1_0", "Undercut Swept Back", -240234547, -460168116),
            new HairSets(68, 0, "CLO_BIM_H_2_0", "Undercut Swept Side", -240234547, -311245907),
            new HairSets(69, 0, "CLO_BIM_H_3_0", "Spiked Mohawk", -240234547, -942031335),
            new HairSets(70, 0, "CLO_BIM_H_4_0", "Mod", -240234547, -644503216),
            new HairSets(71, 0, "CLO_BIM_H_5_0", "Layered Mod", -240234547, 211198653),
            new HairSets(72, 0, "CLO_GRM_H_0_0", "Flattop", 1616273011, -1119221482),
            new HairSets(73, 0, "CLO_GRM_H_1_0", "Military Buzzcut", 1616273011, -1642199958),
            new HairSets(74, 0, "CLO_VWM_H_0_0", "Impotent Rage", 1347816957, -599666460),
            new HairSets(75, 0, "CLO_TRM_H_0_0", "Afro Faded", -1970774728, -416636904),
            new HairSets(76, 0, "CLO_FXM_H_0_0", "Top Knot", 601646824, 1334100948),
            new HairSets(77, 0, "CLO_SBM_H_0_0", "Two Block", 987639353, -1927370417),
            new HairSets(78, 0, "CLO_SBM_H_1_0", "Shaggy Mullet", 987639353, -1088161005)
        };
        private List<HairSets> FHairsets = new List<HairSets>
        {
            new HairSets(0, 0, "H_FMF_0_0","Close Shave", -1, -1),
            new HairSets(1, 0, "H_FMF_1_0","Short Chestnut", -1, -1),
            new HairSets(1, 1, "H_FMF_1_1","Short Blonde", -1, -1),
            new HairSets(1, 2, "H_FMF_1_2","Short Auburn", -1, -1),
            new HairSets(1, 3, "H_FMF_1_3","Short Black", -1, -1),
            new HairSets(1, 4, "H_FMF_1_4","Short Brown", -1, -1),
            new HairSets(1, 5, "H_FMF_1_5","Short Purple", -1, -1),

            new HairSets(2, 0, "H_FMF_2_0","Layered Bob Chestnut", -1, -1),
            new HairSets(2, 1, "H_FMF_2_1","Layered Bob Blonde", -1, -1),
            new HairSets(2, 2, "H_FMF_2_2","Layered Bob Auburn", -1, -1),
            new HairSets(2, 3, "H_FMF_2_3","Layered Bob Black", -1, -1),
            new HairSets(2, 4, "H_FMF_2_4","Layered Bob Brown", -1, -1),
            new HairSets(2, 5, "H_FMF_2_5","Layered Bob Green", -1, -1),

            new HairSets(3, 0, "H_FMF_3_0","Pigtails Chestnut", -1, -1),
            new HairSets(3, 1, "H_FMF_3_1","Pigtails Blonde", -1, -1),
            new HairSets(3, 2, "H_FMF_3_2","Pigtails Auburn", -1, -1),
            new HairSets(3, 3, "H_FMF_3_3","Pigtails Black", -1, -1),
            new HairSets(3, 4, "H_FMF_3_4","Pigtails Brown", -1, -1),

            new HairSets(4, 0, "H_FMF_4_0","Ponytail Chestnut", -1, -1),
            new HairSets(4, 1, "H_FMF_4_1","Ponytail Blonde", -1, -1),
            new HairSets(4, 2, "H_FMF_4_2","Ponytail Auburn", -1, -1),
            new HairSets(4, 3, "H_FMF_4_3","Ponytail Black", -1, -1),
            new HairSets(4, 4, "H_FMF_4_4","Ponytail Brown", -1, -1),
            new HairSets(4, 5, "H_FMF_4_5","Ponytail Blue", -1, -1),

            new HairSets(5, 0, "H_FMF_5_0","Braided Mohawk Chestnut", -1, -1),
            new HairSets(5, 1, "H_FMF_5_1","Braided Mohawk Blonde", -1, -1),
            new HairSets(5, 2, "H_FMF_5_2","Braided Mohawk Auburn", -1, -1),
            new HairSets(5, 3, "H_FMF_5_3","Braided Mohawk Black", -1, -1),
            new HairSets(5, 4, "H_FMF_5_4","Braided Mohawk Brown", -1, -1),
            new HairSets(5, 5, "H_FMF_5_5","Braided Mohawk Pink", -1, -1),

            new HairSets(6, 0, "H_FMF_6_0","Braids Chestnut", -1, -1),
            new HairSets(6, 1, "H_FMF_6_1","Braids Blonde", -1, -1),
            new HairSets(6, 2, "H_FMF_6_2","Braids Auburn", -1, -1),
            new HairSets(6, 3, "H_FMF_6_3","Braids Black", -1, -1),
            new HairSets(6, 4, "H_FMF_6_4","Braids Brown", -1, -1),

            new HairSets(7, 0, "H_FMF_7_0","Bob Chestnut", -1, -1),
            new HairSets(7, 1, "H_FMF_7_1","Bob Blonde", -1, -1),
            new HairSets(7, 2, "H_FMF_7_2","Bob Auburn", -1, -1),
            new HairSets(7, 3, "H_FMF_7_3","Bob Black", -1, -1),
            new HairSets(7, 4, "H_FMF_7_4","Bob Brown", -1, -1),
            new HairSets(7, 5, "H_FMF_7_5","Bob Purple Fade", -1, -1),

            new HairSets(8, 0, "H_FMF_8_0","Faux Hawk Chestnut", -1, -1),
            new HairSets(8, 1, "H_FMF_8_1","Faux Hawk Blonde", -1, -1),
            new HairSets(8, 2, "H_FMF_8_2","Faux Hawk Auburn", -1, -1),
            new HairSets(8, 3, "H_FMF_8_3","Faux Hawk Black", -1, -1),
            new HairSets(8, 4, "H_FMF_8_4","Faux Hawk Brown", -1, -1),
            new HairSets(8, 5, "H_FMF_8_5","Faux Hawk Pink", -1, -1),

            new HairSets(9, 0, "H_FMF_9_0","French Twist Chestnut", -1, -1),
            new HairSets(9, 1, "H_FMF_9_1","French Twist Blonde", -1, -1),
            new HairSets(9, 2, "H_FMF_9_2","French Twist Auburn", -1, -1),
            new HairSets(9, 3, "H_FMF_9_3","French Twist Black", -1, -1),
            new HairSets(9, 4, "H_FMF_9_4","French Twist Brown", -1, -1),

            new HairSets(10, 0, "H_FMF_10_0","Long Bob Chestnut", -1, -1),
            new HairSets(10, 1, "H_FMF_10_1","Long Bob Blonde", -1, -1),
            new HairSets(10, 2, "H_FMF_10_2","Long Bob Auburn", -1, -1),
            new HairSets(10, 3, "H_FMF_10_3","Long Bob Black", -1, -1),
            new HairSets(10, 4, "H_FMF_10_4","Long Bob Brown", -1, -1),
            new HairSets(10, 6, "H_FMF_10_6","Long Bob Purple Fade", -1, -1),

            new HairSets(11, 0, "H_FMF_11_0","Loose Tied Chestnut", -1, -1),
            new HairSets(11, 1, "H_FMF_11_1","Loose Tied Blonde", -1, -1),
            new HairSets(11, 2, "H_FMF_11_2","Loose Tied Auburn", -1, -1),
            new HairSets(11, 3, "H_FMF_11_3","Loose Tied Black", -1, -1),
            new HairSets(11, 4, "H_FMF_11_4","Loose Tied Brown", -1, -1),
            new HairSets(11, 6, "H_FMF_11_6","Loose Tied Green", -1, -1),

            new HairSets(12, 0, "H_FMF_12_0","Pixie Chestnut", -1, -1),
            new HairSets(12, 1, "H_FMF_12_1","Pixie Blonde", -1, -1),
            new HairSets(12, 2, "H_FMF_12_2","Pixie Auburn", -1, -1),
            new HairSets(12, 3, "H_FMF_12_3","Pixie Black", -1, -1),
            new HairSets(12, 4, "H_FMF_12_4","Pixie Brown", -1, -1),
            new HairSets(12, 5, "H_FMF_12_5","Pixie Blue", -1, -1),

            new HairSets(13, 0, "H_FMF_13_0","Shaved Bangs Chestnut", -1, -1),
            new HairSets(13, 1, "H_FMF_13_1","Shaved Bangs Blonde", -1, -1),
            new HairSets(13, 2, "H_FMF_13_2","Shaved Bangs Auburn", -1, -1),
            new HairSets(13, 3, "H_FMF_13_3","Shaved Bangs Black", -1, -1),
            new HairSets(13, 4, "H_FMF_13_4","Shaved Bangs Brown", -1, -1),
            new HairSets(13, 5, "H_FMF_13_5","Shaved Bangs Blue Fade", -1, -1),

            new HairSets(14, 0, "H_FMF_14_0","Top Knot Chestnut", -1, -1),
            new HairSets(14, 1, "H_FMF_14_1","Top Knot Blonde", -1, -1),
            new HairSets(14, 2, "H_FMF_14_2","Top Knot Auburn", -1, -1),
            new HairSets(14, 3, "H_FMF_14_3","Top Knot Black", -1, -1),
            new HairSets(14, 4, "H_FMF_14_4","Top Knot Brown", -1, -1),

            new HairSets(15, 0, "H_FMF_15_0","Wavy Bob Chestnut", -1, -1),
            new HairSets(15, 1, "H_FMF_15_1","Wavy Bob Blonde", -1, -1),
            new HairSets(15, 2, "H_FMF_15_2","Wavy Bob Auburn", -1, -1),
            new HairSets(15, 3, "H_FMF_15_3","Wavy Bob Black", -1, -1),
            new HairSets(15, 4, "H_FMF_15_4","Wavy Bob Brown", -1, -1),
            new HairSets(15, 6, "H_FMF_15_6","Wavy Bob Red Fade", -1, -1),

            new HairSets(16, 0, "CLO_BBF_H_00","Pin Up Girl Chestnut", -1, -1),
            new HairSets(16, 1, "CLO_BBF_H_01","Pin Up Girl Blonde", -1, -1),
            new HairSets(16, 2, "CLO_BBF_H_02","Pin Up Girl Auburn", -1, -1),
            new HairSets(16, 3, "CLO_BBF_H_03","Pin Up Girl Black", -1, -1),
            new HairSets(16, 4, "CLO_BBF_H_04","Pin Up Girl Brown", -1, -1),

            new HairSets(17, 0, "CLO_BBF_H_05","Messy Bun Chestnut", -1398869298, -811206225),
            new HairSets(17, 1, "CLO_BBF_H_06","Messy Bun Blonde", -1398869298, -1586815686),
            new HairSets(17, 2, "CLO_BBF_H_07","Messy Bun Auburn", -1398869298, -1423429452),
            new HairSets(17, 3, "CLO_BBF_H_08","Messy Bun Black", -1398869298, -1697869815),
            new HairSets(17, 4, "CLO_BBF_H_09","Messy Bun Brown", -1398869298, -1470846183),

            new HairSets(18, 0, "CLO_VALF_H_0_0","Flapper Bob Chestnut", -1, -1),
            new HairSets(18, 1, "CLO_VALF_H_0_1","Flapper Bob Blonde", -1, -1),
            new HairSets(18, 2, "CLO_VALF_H_0_2","Flapper Bob Auburn", -1, -1),
            new HairSets(18, 3, "CLO_VALF_H_0_3","Flapper Bob Black", -1, -1),
            new HairSets(18, 4, "CLO_VALF_H_0_4","Flapper Bob Brown", -1, -1),
            new HairSets(18, 5, "CLO_VALF_H_0_5","Flapper Bob Blue", -1, -1),

            new HairSets(19, 0, "CLO_BUS_F_H_0_0","Tight Bun Black", -2086773, -1816086813),
            new HairSets(19, 1, "CLO_BUS_F_H_0_1","Tight Bun Brown", -2086773, -2113006722),
            new HairSets(19, 2, "CLO_BUS_F_H_0_2","Tight Bun Auburn", -2086773, -1398740829),
            new HairSets(19, 3, "CLO_BUS_F_H_0_3","Tight Bun Chestnut", -2086773, -131530830),
            new HairSets(19, 4, "CLO_BUS_F_H_0_4","Tight Bun Blonde", -2086773, -1101886458),

            new HairSets(20, 0, "CLO_BUS_F_H_1_0","Twisted Bob Chestnut", -1398869298, 558694786),
            new HairSets(20, 1, "CLO_BUS_F_H_1_1","Twisted Bob Black", -1398869298, 569279177),
            new HairSets(20, 2, "CLO_BUS_F_H_1_2","Twisted Bob Auburn", -1398869298, 544309199),
            new HairSets(20, 3, "CLO_BUS_F_H_1_3","Twisted Bob Brown", -1398869298, 1190448341),
            new HairSets(20, 4, "CLO_BUS_F_H_1_4","Twisted Bob Blonde", -1398869298, 885139568),

            new HairSets(21, 0, "CLO_HP_F_HR_0_0","Big Bangs Chestnut", -1, -1),
            new HairSets(21, 1, "CLO_HP_F_HR_0_1","Big Bangs Blonde", -1, -1),
            new HairSets(21, 2, "CLO_HP_F_HR_0_2","Big Bangs Auburn", -1, -1),
            new HairSets(21, 3, "CLO_HP_F_HR_0_3","Big Bangs Black", -1, -1),
            new HairSets(21, 4, "CLO_HP_F_HR_0_4","Big Bangs Brown", -1, -1),

            new HairSets(22, 0, "CLO_HP_F_HR_1_0","Braided Top Knot Chestnut", -1398869298, -1845683606),
            new HairSets(22, 1, "CLO_HP_F_HR_1_1","Braided Top Knot Blonde", -1398869298, -1555317497),
            new HairSets(22, 2, "CLO_HP_F_HR_1_2","Braided Top Knot Auburn", -1398869298, 1704673699),
            new HairSets(22, 3, "CLO_HP_F_HR_1_3","Braided Top Knot Black", -1398869298, 1993401358),
            new HairSets(22, 4, "CLO_HP_F_HR_1_4","Braided Top Knot Brown", -1398869298, 1227065524),

            new HairSets(23, 0, "CLO_INDF_H_0_0","Mullet Chestnut", -1, -1),
            new HairSets(23, 1, "CLO_INDF_H_0_1","Mullet Blonde", -1, -1),
            new HairSets(23, 2, "CLO_INDF_H_0_2","Mullet Auburn", -1, -1),
            new HairSets(23, 3, "CLO_INDF_H_0_3","Mullet Black", -1, -1),
            new HairSets(23, 4, "CLO_INDF_H_0_4","Mullet Brown", -1, -1),

            new HairSets(25, 0, "CLO_S1F_H_0_0","Pinched Cornrows", 62137527, -1325458477),
            new HairSets(26, 0, "CLO_S1F_H_1_0","Leaf Cornrows", 62137527, -566725051),
            new HairSets(27, 0, "CLO_S1F_H_2_0","Zig Zag Cornrows", 62137527, -787850263),
            new HairSets(28, 0, "CLO_S1F_H_3_0","Pigtail Bangs", 1529191571, 2039295216),
            new HairSets(29, 0, "CLO_S2F_H_0_0","Wave Braids", 1529191571, 2039295216),
            new HairSets(30, 0, "CLO_S2F_H_1_0","Coil Braids", 1529191571, 1800147054),
            new HairSets(31, 0, "CLO_S2F_H_2_0","Rolled Quiff", 1529191571, -2019505897),
            new HairSets(32, 0, "CLO_BIF_H_0_0","Loose Swept Back", -240234547, -328340062),
            new HairSets(33, 0, "CLO_BIF_H_1_0","Undercut Swept Back", -240234547, 1657725123),
            new HairSets(34, 0, "CLO_BIF_H_2_0","Undercut Swept Side", -240234547, -1517964336),
            new HairSets(35, 0, "CLO_BIF_H_3_0","Spiked Mohawk", -240234547, 1677522529),
            new HairSets(36, 0, "CLO_BIF_H_4_0","Bandana and Braid", 598190139, -1362677538),
            new HairSets(37, 0, "CLO_BIF_H_6_0","Skinbyrd", -240234547, 1841934566),
            new HairSets(38, 0, "CLO_BIF_H_5_0","Layered Mod", -240234547, 1742494019),
            new HairSets(39, 0, "CC_F_HS_1","Short", 598190139, 104062694),
            new HairSets(40, 0, "CC_F_HS_2","Layered Bob", 598190139, 869579299),
            new HairSets(41, 0, "CC_F_HS_3","Pigtails", 598190139, 1201332655),
            new HairSets(42, 0, "CC_F_HS_4","Ponytail", 598190139, 1028967715),
            new HairSets(43, 0, "CC_F_HS_5","Braided Mohawk", 598190139, -1651634800),
            new HairSets(44, 0, "CC_F_HS_6","Braids", 598190139, -892278763),
            new HairSets(45, 0, "CC_F_HS_7","Bob", 598190139, -1032005779),
            new HairSets(46, 0, "CC_F_HS_8","Faux Hawk", 598190139, -255675400),
            new HairSets(47, 0, "CC_F_HS_9","French Twist", 598190139, 1890137027),
            new HairSets(48, 0, "CC_F_HS_10","Long Bob", 598190139, -406805808),
            new HairSets(49, 0, "CC_F_HS_11","Loose Tied", 598190139, -592540500),
            new HairSets(50, 0, "CC_F_HS_12","Pixie", 598190139, 205417419),
            new HairSets(51, 0, "CC_F_HS_13","Shaved Bangs", 598190139, -2127276619),
            new HairSets(52, 0, "CC_F_HS_14","Top Knot", 598190139, -1362677538),
            new HairSets(53, 0, "CC_F_HS_15","Wavy Bob", 598190139, -1549722990),
            new HairSets(54, 0, "CLO_BBF_H_05","Messy Bun Chestnut", -1398869298, -811206225),
            new HairSets(55, 0, "CLO_BBF_H_00","Pin Up Girl Chestnut", -1, -1),
            new HairSets(56, 0, "CLO_BUS_F_H_0_0","Tight Bun Black", -2086773, -1816086813),
            new HairSets(57, 0, "CLO_BUS_F_H_1_0","Twisted Bob Chestnut", -1398869298, 558694786),
            new HairSets(58, 0, "CLO_VALF_H_0_0","Flapper Bob Chestnut", -1, -1),
            new HairSets(59, 0, "CLO_HP_F_HR_0_0","Big Bangs Chestnut", -1, -1),
            new HairSets(60, 0, "CLO_HP_F_HR_1_0","Braided Top Knot Chestnut", -1398869298, -1845683606),
            new HairSets(61, 0, "CLO_INDF_H_0_0","Mullet Chestnut", -1, -1),
            new HairSets(62, 0, "CLO_S1F_H_0_0","Pinched Cornrows", 62137527, -1325458477),
            new HairSets(63, 0, "CLO_S1F_H_1_0","Leaf Cornrows", 62137527, -566725051),
            new HairSets(64, 0, "CLO_S1F_H_2_0","Zig Zag Cornrows", 62137527, -787850263),
            new HairSets(65, 0, "CLO_S1F_H_3_0","Pigtail Bangs", 1529191571, 2039295216),
            new HairSets(66, 0, "CLO_S2F_H_0_0","Wave Braids", 1529191571, 2039295216),
            new HairSets(67, 0, "CLO_S2F_H_1_0","Coil Braids", 1529191571, 1800147054),
            new HairSets(68, 0, "CLO_S2F_H_2_0","Rolled Quiff", 1529191571, -2019505897),
            new HairSets(69, 0, "CLO_BIF_H_0_0","Loose Swept Back", -240234547, -328340062),
            new HairSets(70, 0, "CLO_BIF_H_1_0","Undercut Swept Back", -240234547, 1657725123),
            new HairSets(71, 0, "CLO_BIF_H_2_0","Undercut Swept Side", -240234547, -1517964336),
            new HairSets(72, 0, "CLO_BIF_H_3_0","Spiked Mohawk", -240234547, 1677522529),
            new HairSets(73, 0, "CLO_BIF_H_4_0","Bandana and Braid", 598190139, -1362677538),
            new HairSets(74, 0, "CLO_BIF_H_5_0","Layered Mod", -240234547, 1742494019),
            new HairSets(75, 0, "CLO_BIF_H_6_0","Skinbyrd", -240234547, 1841934566),
            new HairSets(76, 0, "CLO_GRF_H_0_0","Neat Bun", 1616273011, 687338866),
            new HairSets(77, 0, "CLO_GRF_H_1_0","Short Bob", 1616273011, 1827923343),
            new HairSets(78, 0, "CLO_VWF_H_0_0","Impotent Rage", 1347816957, 987747946),
            new HairSets(79, 0, "CLO_TRF_H_0_0","Afro", -1970774728, -2025496493),
            new HairSets(80, 0, "CLO_FXF_H_0_0","Pixie Wavy", 601646824, -974054285),
            new HairSets(81, 0, "CLO_SBF_H_0_0","Short Tucked Bob", 987639353, -606892013),
            new HairSets(82, 0, "CLO_SBF_H_1_0","Shaggy Mullet", 987639353, -1514684318),
            new HairSets(83, 0, "CLO_X6F_H_0_0","Buzzcut", 1841427399, 606012624)
        };
        //Hair list was taken from https://github.com/root-cause/v-clothingnames
        private List<string> MVoices = new List<string>
        {
            "Default",
            "ANDY_MOON", //B51D1921", //3038583073", //"1256384223
            "ANTON", //ED9B229C", //3986367132", //"308600164
            "AVI", //EF7A6BDE", //4017777630", //"277189666
            "AGENCYJANITOR", //5288D370", //1384698736", //1384698736
            "AIRCRAFT_WARNING_MALE_01", //A65A6402", //2790941698", //"1504025598
            "AIRDUMMER", //798D01B5", //2039284149", //2039284149
            "AIRGUITARIST", //A1D7351A", //2715235610", //"1579731686
            "AIRPIANIST", //B98B1513", //3112899859", //"1182067437
            "AIRPORT_PA_MALE", //4BA3E2F7", //1269031671", //1269031671
            "ALIENS", //EB86F769", //3951490921", //"343476375
            "AMMUCITY", //D4503291", //3562025617", //"732941679
            "APT_BEAST", //14F37BC9", //351501257", //351501257
            "BALLASOG", //AAE4ECF8", //2867129592", //"1427837704
            "BANK", //3A15DB98", //974511000", //974511000
            "BANKWM1", //CED9042B", //3470328875", //"824638421
            "BANKWM2", //9C9B9FB1", //2627444657", //"1667522639
            "BAYGOR", //7BF7A5D6", //2079827414", //2079827414
            "BENNY", //F1EB2693", //4058719891", //"236247405
            "BEVERLY", //79D862EA", //2044224234", //2044224234
            "BIKE_MECHANIC", //573287EB", //1462929387", //1462929387
            "BILLBINDER", //4E43F344", //1313076036", //1313076036
            "BJPILOT_CANAL", //B75951F4", //3076084212", //"1218883084
            "BJPILOT_TRAIN", //0FACABE0", //262974432", //262974432
            "BRAD", //57360243", //1463157315", //1463157315
            "BREATHING_FRANKLIN_01", //777E9106", //2004783366", //2004783366
            "BREATHING_MICHAEL_01", //CAB2CFFB", //3400716283", //"894251013
            "BREATHING_TEST_01", //D75E8754", //3613296468", //"681670828
            "BREATHING_TREVOR_01", //18092047", //403251271", //403251271
            "BUSINESSMAN", //3ECBA7BD", //1053534141", //1053534141
            "CASEY", //908C67DC", //2425120732", //"1869846564
            "CHAR_INTRO_FRANKLIN_01", //420FF5A0", //1108342176", //1108342176
            "CHAR_INTRO_MICHAEL_01", //E4A08B92", //3835726738", //"459240558
            "CHAR_INTRO_TREVOR_01", //8F52758F", //2404545935", //"1890421361
            "CHEF", //BF59CC9A", //3210333338", //"1084633958
            "CHENG", //65BBBE48", //1706802760", //1706802760
            "CLETUS", //9B00816A", //2600501610", //"1694465686
            "CLINTON", //2B502F45", //726675269", //726675269
            "CLOWNS", //D8088180", //3624436096", //"670531200
            "COOK", //5673232D", //1450386221", //1450386221
            "DAVE", //B1F68A9D", //2985724573", //"1309242723
            "DOM", //BBF2D511", //3153253649", //"1141713647
            "EDDIE", //C5FB1FF5", //3321569269", //"973398027
            "EXECPA_MALE", //0C5C69CC", //207382988", //207382988
            "EXT1HELIPILOT", //EF004581", //4009772417", //"285194879
            "FACILITY_ANNOUNCER", //A9F8234D", //2851611469", //"1443355827
            "FLOYD", //5E69D958", //1583995224", //1583995224
            "FM", //FFE20CE1", //4293004513", //"1962783
            "FM_TH", //2640742C", //641758252", //641758252
            "GARDENER", //4260B7F4", //1113634804", //1113634804
            "GAYMILITARY", //212EBC3B", //556710971", //556710971
            "GERALD", //07DCC381", //131908481", //131908481
            "GROOM", //4A735AF1", //1249073905", //1249073905
            "GUSTAVO", //E5A7195C", //3852933468", //"442033828
            "HAO", //5F91F8AE", //1603401902", //1603401902
            "HEISTMANAGER", //3F3FAB0F", //1061137167", //1061137167
            "HUGH", //F4EE78A9", //4109269161", //"185698135
            "IMPOTENT_RAGE", //BE080ED8", //3188199128", //"1106768168
            "INFERNUS", //18F25AC7", //418536135", //418536135
            "JEROME", //D982DA50", //3649231440", //"645735856
            "JESSE", //916BB095", //2439753877", //"1855213419
            "JIMMY_DRUNK", //43C1EB55", //1136782165", //1136782165
            "JIMMY_NORMAL", //95810242", //2508259906", //"1786707390
            "JOE", //07CC375A", //130824026", //130824026
            "JOSEF", //F63ED80C", //4131313676", //"163653620
            "JOSH", //F4DDE967", //4108183911", //"186783385
            "KARIM", //DB158746", //3675621190", //"619346106
            "KARL", //D29BCDFD", //3533426173", //"761541123
            "LAMAR", //EA22BC4D", //3928144973", //"366822323
            "LAMAR_1_NORMAL", //35FE7226", //905867814", //905867814
            "LAMAR_2_NORMAL", //25068D1D", //621186333", //621186333
            "LAMAR_DRUNK", //648A554F", //1686787407", //1686787407
            "LAMAR_NORMAL", //9D861581", //2642810241", //"1652157055
            "LESTER", //8DB38846", //2377353286", //"1917614010
            "LIENGINEER", //BD5D1E88", //3176996488", //"1117970808
            "LIENGINEER2", //3A58B62B", //978892331", //978892331
            "LI_GEORGE_01", //F22854E3", //4062729443", //"232237853
            "LI_LOBBY_01", //3DB175B5", //1035040181", //1035040181
            "LI_MALE_01", //9CF88EB5", //2633535157", //"1661432139
            "LI_MALE_02", //AAB22A28", //2863802920", //"1431164376
            "MALE_STRIP_DJ_WHITE", //54825131", //1417826609", //1417826609
            "MANI", //9A9B1CC9", //2593856713", //"1701110583
            "MELVIN", //558B495C", //1435191644", //1435191644
            "MELVINSCIENTIST", //E90C6953", //3909904723", //"385062573
            "MIME", //5B25DA1F", //1529207327", //1529207327
            "MISTERK", //FF37663A", //4281820730", //"13146566
            "MPCT", //FF02D40E", //4278375438", //"16591858
            "MP_RESIDENT", //844127A9", //2218862505", //"2076104791
            "NERVOUSRON", //20251950", //539302224", //539302224
            "NIGEL", //F95E18F2", //4183693554", //"111273742
            "NIGHT_OUT_MALE_01", //41EC4175", //1106002293", //1106002293
            "NIGHT_OUT_MALE_02", //C428C5EC", //3291006444", //"1003960852
            "NORM", //AE21D168", //2921451880", //"1373515416
            "NO_VOICE", //87BFF09A", //2277503130", //"2017464166
            "PACKIE", //B8791A2F", //3094944303", //"1200022993
            "PACKIE_AI_NORM_PART1_BOOTH", //E0D1A809", //3771836425", //"523130871
            "PANIC_WALLA", //14DEB561", //350139745", //350139745
            "PIER_ANNOUNCE_MALE", //9567A0E1", //2506596577", //"1788370719
            "PIER_FOLEY", //58EA9491", //1491768465", //1491768465
            "PRISONER", //7EA26372", //2124571506", //2124571506
            "PRISON_ANNOUNCER", //9BEE7F20", //2616098592", //"1678868704
            "PRISON_TANNOY", //E5DCB564", //3856446820", //"438520476
            "REDOCASTRO", //CED55457", //3470087255", //"824880041
            "REDR1DRUNK1", //4184DA81", //1099225729", //1099225729
            "REDR1DRUNK1_AI_DRUNK", //2B10FBD7", //722533335", //722533335
            "REDR2DRUNKM", //51408669", //1363183209", //1363183209
            "REHH2HIKER", //92977683", //2459399811", //"1835567485
            "REHH3HIPSTER", //C0147C2B", //3222567979", //"1072399317
            "SECUROMECH", //9C7CE8C0", //2625431744", //"1669535552
            "SHOPASSISTANT", //53912D70", //1402023280", //1402023280
            "SIMEON", //82816017", //2189516823", //"2105450473
            "SOL1ACTOR", //4B0CAD83", //1259122051", //1259122051
            "SPACE_RANGER", //21D80107", //567804167", //567804167
            "STEVE", //CE95B9A9", //3465918889", //"829048407
            "STRETCH", //8B13F083", //2333339779", //"1961627517
            "SUBWAY_ANNOUNCER", //1C2F9BF2", //472882162", //472882162
            "TOM", //97CBE769", //2546722665", //"1748244631
            "TRANSLATOR", //EAC3FECB", //3938713291", //"356254005
            "VULTURES", //18219991", //404855185", //404855185
            "WADE", //7DD049A4", //2110802340", //2110802340
            "WHISTLINGJANITOR", //168D3E8E", //378355342", //378355342
            "YACHTCAPTAIN", //71C9A806", //1909041158", //1909041158
            "ZOMBIE", //22666A99", //577137305", //577137305
            "BTL_DAVE_PVG",
            "HS4_RAMPA_PVG",
            "HS4_ANDME_PVG",
            "HS4_ADAM_PVG",
            "HS4_PTRAX_PVG",
            "HS4_MOODY_PVG",
            "HS4_PRODUCER_PVG",
            "HS4_POOH_PVG",
            "HS4_BUSINESS_PVG",
            "HS4_CELEB1_PVG",
            "HS4_GUSTAVO_PVG",
            "HS4_PAVEL_PVG",
            "HS4_ELRUBIO_PVG",
            "HS4_MIGUEL_PVG",
            "HS4_ENTRYPILOT1_PVG",
            "HS4_OLDRICHGUY_PVG",
            "MALE_CLUB_R2PVG",
            "MALE_GENERICCHEAPWORKER_LATINO_PVG",
            "HS4_BODYGUARD1_PVG",
            "IGUARD_PVG",
            "AFFLUENT_SUBURBAN_MALE_01", //85FA12FF", //2247758591", //"2047208705
            "AFFLUENT_SUBURBAN_MALE_02", //A4394F7D", //2755219325", //"1539747971
            "A_M_M_AFRIAMER_01_BLACK_FULL_01", //43367BD1", //1127644113", //1127644113
            "A_M_M_BEACH_01_BLACK_MINI_01", //D01013F6", //3490714614", //"804252682
            "A_M_M_BEACH_01_LATINO_FULL_01", //26669A41", //644258369", //644258369
            "A_M_M_BEACH_01_LATINO_MINI_01", //FB444157", //4215554391", //"79412905
            "A_M_M_BEACH_01_WHITE_FULL_01", //30CB4589", //818627977", //818627977
            "A_M_M_BEACH_01_WHITE_MINI_02", //A8E033BD", //2833265597", //"1461701699
            "A_M_M_BEACH_02_BLACK_FULL_01", //BCACE696", //3165447830", //"1129519466
            "A_M_M_BEACH_02_WHITE_FULL_01", //E8314D57", //3895545175", //"399422121
            "A_M_M_BEACH_02_WHITE_MINI_01", //AE3CFC05", //2923232261", //"1371735035
            "A_M_M_BEACH_02_WHITE_MINI_02", //4717ADD8", //1192734168", //1192734168
            "A_M_M_BEVHILLS_01_BLACK_FULL_01", //457F9C3D", //1165990973", //1165990973
            "A_M_M_BEVHILLS_01_BLACK_MINI_01", //29323F4A", //691158858", //691158858
            "A_M_M_BevHills_01_WHITE_FULL_01", //DBCAE12A", //3687506218", //"607461078
            "A_M_M_BEVHILLS_01_WHITE_MINI_01", //D19FFBCA", //3516922826", //"778044470
            "A_M_M_BEVHILLS_02_BLACK_FULL_01", //5370D897", //1399904407", //1399904407
            "A_M_M_BEVHILLS_02_BLACK_MINI_01", //25983C23", //630733859", //630733859
            "A_M_M_BEVHILLS_02_WHITE_FULL_01", //6BB97FD6", //1807318998", //1807318998
            "A_M_M_BEVHILLS_02_WHITE_MINI_01", //B509F09C", //3037327516", //"1257639780
            "A_M_M_BUSINESS_01_BLACK_FULL_01", //4F3C06EB", //1329333995", //1329333995
            "A_M_M_BUSINESS_01_BLACK_MINI_01", //9C4ACF39", //2622148409", //"1672818887
            "A_M_M_BUSINESS_01_WHITE_FULL_01", //CE2B65BC", //3458950588", //"836016708
            "A_M_M_BUSINESS_01_WHITE_MINI_01", //F3AD48DE", //4088219870", //"206747426
            "A_M_M_EASTSA_01_LATINO_FULL_01", //BE01DD94", //3187793300", //"1107173996
            "A_M_M_EASTSA_01_LATINO_MINI_01", //6BF8BF2C", //1811463980", //1811463980
            "A_M_M_EASTSA_02_LATINO_FULL_01", //9CB34BA8", //2628996008", //"1665971288
            "A_M_M_EASTSA_02_LATINO_MINI_01", //CDF2AD27", //3455233319", //"839733977
            "A_M_M_FARMER_01_WHITE_MINI_01", //24689D1A", //610835738", //610835738
            "A_M_M_FARMER_01_WHITE_MINI_02", //4ED1F1EC", //1322381804", //1322381804
            "A_M_M_FARMER_01_WHITE_MINI_03", //F7F4C433", //4160013363", //"134953933
            "A_M_M_FATLATIN_01_LATINO_FULL_01", //2F04A30B", //788833035", //788833035
            "A_M_M_FATLATIN_01_LATINO_MINI_01", //4AED8689", //1257080457", //1257080457
            "A_M_M_GENERICMALE_01_WHITE_MINI_01", //13EFDE7E", //334487166", //334487166
            "A_M_M_GENERICMALE_01_WHITE_MINI_02", //221A7AD3", //572160723", //572160723
            "A_M_M_GENERICMALE_01_WHITE_MINI_03", //5AA26BD6", //1520593878", //1520593878
            "A_M_M_GENERICMALE_01_WHITE_MINI_04", //FD0AB0B4", //4245336244", //"49631052
            "A_M_M_GENFAT_01_LATINO_FULL_01", //E53DAB11", //3846023953", //"448943343
            "A_M_M_GENFAT_01_LATINO_MINI_01", //4C00FC14", //1275132948", //1275132948
            "A_M_M_GOLFER_01_BLACK_FULL_01", //65B984D1", //1706656977", //1706656977
            "A_M_M_GOLFER_01_WHITE_FULL_01", //57DD2744", //1474111300", //1474111300
            "A_M_M_GOLFER_01_WHITE_MINI_01", //CA82D279", //3397571193", //"897396103
            "A_M_M_HASJEW_01_WHITE_MINI_01", //31B413DD", //833885149", //833885149
            "A_M_M_HILLBILLY_01_WHITE_MINI_01", //342FA137", //875536695", //875536695
            "A_M_M_HILLBILLY_01_WHITE_MINI_02", //EEB2964E", //4004681294", //"290286002
            "A_M_M_HILLBILLY_01_WHITE_MINI_03", //62B97E4A", //1656323658", //1656323658
            "A_M_M_HILLBILLY_02_WHITE_MINI_01", //9E428A7D", //2655160957", //"1639806339
            "A_M_M_HILLBILLY_02_WHITE_MINI_02", //ACECA7D1", //2901190609", //"1393776687
            "A_M_M_HILLBILLY_02_WHITE_MINI_03", //7A9EC332", //2057225010", //2057225010
            "A_M_M_HILLBILLY_02_WHITE_MINI_04", //14C3777D", //348354429", //348354429
            "A_M_M_INDIAN_01_INDIAN_MINI_01", //0D92701D", //227700765", //227700765
            "A_M_M_KTOWN_01_KOREAN_FULL_01", //CEB967A9", //3468257193", //"826710103
            "A_M_M_KTOWN_01_KOREAN_MINI_01", //9D5568DD", //2639620317", //"1655346979
            "A_M_M_MALIBU_01_BLACK_FULL_01", //704A0828", //1883899944", //1883899944
            "A_M_M_MALIBU_01_LATINO_FULL_01", //C446CD11", //3292974353", //"1001992943
            "A_M_M_MALIBU_01_LATINO_MINI_01", //23A05D0D", //597712141", //597712141
            "A_M_M_MALIBU_01_WHITE_FULL_01", //ABCCBA7C", //2882321020", //"1412646276
            "A_M_M_MALIBU_01_WHITE_MINI_01", //B71E2A9D", //3072207517", //"1222759779
            "A_M_M_POLYNESIAN_01_POLYNESIAN_FULL_01", //68887F5A", //1753775962", //1753775962
            "A_M_M_POLYNESIAN_01_POLYNESIAN_MINI_01", //CDB20C91", //3450997905", //"843969391
            "A_M_M_SALTON_01_WHITE_FULL_01", //C4B4C301", //3300180737", //"994786559
            "A_M_M_SALTON_02_WHITE_FULL_01", //AAD2C80E", //2865940494", //"1429026802
            "A_M_M_SALTON_02_WHITE_MINI_01", //47C9EC4A", //1204415562", //1204415562
            "A_M_M_SALTON_02_WHITE_MINI_02", //6D9837E6", //1838692326", //1838692326
            "A_M_M_SKATER_01_BLACK_FULL_01", //256B9C01", //627809281", //627809281
            "A_M_M_SKATER_01_WHITE_FULL_01", //011E5DF9", //18767353", //18767353
            "A_M_M_SKATER_01_WHITE_MINI_01", //990DB923", //2567813411", //"1727153885
            "A_M_M_SKIDROW_01_BLACK_FULL_01", //A9B4316E", //2847158638", //"1447808658
            "A_M_M_SOCENLAT_01_LATINO_FULL_01", //06291B43", //103357251", //103357251
            "A_M_M_SOCENLAT_01_LATINO_MINI_01", //E9A5A98F", //3919948175", //"375019121
            "A_M_M_SOUCENT_01_BLACK_FULL_01", //15D5484D", //366299213", //366299213
            "A_M_M_SOUCENT_02_BLACK_FULL_01", //465792F9", //1180144377", //1180144377
            "A_M_M_SOUCENT_03_BLACK_FULL_01", //19DD2A37", //433924663", //433924663
            "A_M_M_SOUCENT_04_BLACK_FULL_01", //3712F629", //923989545", //923989545
            "A_M_M_SOUCENT_04_BLACK_MINI_01", //7BDBD27A", //2078003834", //2078003834
            "A_M_M_STLAT_02_LATINO_FULL_01", //27BC1008", //666636296", //666636296
            "A_M_M_TENNIS_01_BLACK_MINI_01", //74745D9B", //1953783195", //1953783195
            "A_M_M_TENNIS_01_WHITE_MINI_01", //A7AD9A25", //2813172261", //"1481795035
            "A_M_M_TOURIST_01_WHITE_MINI_01", //4B87E962", //1267198306", //1267198306
            "A_M_M_TRAMPBEAC_01_BLACK_FULL_01", //126F2EEF", //309276399", //309276399
            "A_M_M_TRAMP_01_BLACK_FULL_01", //EBC7775E", //3955717982", //"339249314
            "A_M_M_TRAMP_01_BLACK_MINI_01", //7924B380", //2032448384", //2032448384
            "A_M_M_TRANVEST_01_WHITE_MINI_01", //98921800", //2559711232", //"1735256064
            "A_M_M_TRANVEST_02_LATINO_FULL_01", //659F48E4", //1704937700", //1704937700
            "A_M_M_TRANVEST_02_LATINO_MINI_01", //F9BFF521", //4190106913", //"104860383
            "A_M_O_BEACH_01_WHITE_FULL_01", //7FBF0F4A", //2143227722", //2143227722
            "A_M_O_BEACH_01_WHITE_MINI_01", //B21E181B", //2988316699", //"1306650597
            "A_M_O_GENSTREET_01_WHITE_FULL_01", //BB6B9D57", //3144392023", //"1150575273
            "A_M_O_GENSTREET_01_WHITE_MINI_01", //10EE4E6A", //284053098", //284053098
            "A_M_O_SALTON_01_WHITE_FULL_01", //5DBB7560", //1572566368", //1572566368
            "A_M_O_SALTON_01_WHITE_MINI_01", //AEA39902", //2929957122", //"1365010174
            "A_M_O_SOUCENT_01_BLACK_FULL_01", //8F45DF82", //2403721090", //"1891246206
            "A_M_O_SOUCENT_02_BLACK_FULL_01", //C195B582", //3247814018", //"1047153278
            "A_M_O_SOUCENT_03_BLACK_FULL_01", //9CE751AB", //2632405419", //"1662561877
            "A_M_O_TRAMP_01_BLACK_FULL_01", //ABAB17E1", //2880116705", //"1414850591
            "A_M_Y_BEACHVESP_01_CHINESE_FULL_01", //D5130E1F", //3574795807", //"720171489
            "A_M_Y_BEACHVESP_01_CHINESE_MINI_01", //B0C6E699", //2965825177", //"1329142119
            "A_M_Y_BEACHVESP_01_LATINO_MINI_01", //3F13D91C", //1058265372", //1058265372
            "A_M_Y_BEACHVESP_01_WHITE_FULL_01", //3CE0CB56", //1021365078", //1021365078
            "A_M_Y_BEACHVESP_01_WHITE_MINI_01", //AAD5FF3F", //2866151231", //"1428816065
            "A_M_Y_BEACHVESP_02_WHITE_FULL_01", //4C19F4DE", //1276769502", //1276769502
            "A_M_Y_BEACHVESP_02_WHITE_MINI_01", //7F7BB4CC", //2138813644", //2138813644
            "A_M_Y_BEACH_01_CHINESE_FULL_01", //14611348", //341906248", //341906248
            "A_M_Y_BEACH_01_CHINESE_MINI_01", //6A55B403", //1784001539", //1784001539
            "A_M_Y_BEACH_01_WHITE_FULL_01", //1C2149A7", //471943591", //471943591
            "A_M_Y_BEACH_01_WHITE_MINI_01", //912C1ADE", //2435586782", //"1859380514
            "A_M_Y_BEACH_02_LATINO_FULL_01", //DBF1B32E", //3690050350", //"604916946
            "A_M_Y_BEACH_02_WHITE_FULL_01", //0B3E6275", //188637813", //188637813
            "A_M_Y_BEACH_03_BLACK_FULL_01", //18519A78", //408001144", //408001144
            "A_M_Y_BEACH_03_BLACK_MINI_01", //5C219040", //1545703488", //1545703488
            "A_M_Y_BEACH_03_WHITE_FULL_01", //187DBBE4", //410893284", //410893284
            "A_M_Y_BEVHILLS_01_BLACK_FULL_01", //BB7823E2", //3145212898", //"1149754398
            "A_M_Y_BevHills_01_WHITE_FULL_01", //FBF34319", //4227023641", //"67943655
            "A_M_Y_BEVHILLS_01_WHITE_MINI_01", //7C5C68C5", //2086430917", //2086430917
            "A_M_Y_BevHills_02_Black_FULL_01", //7FDB40A6", //2145075366", //2145075366
            "A_M_Y_BEVHILLS_02_WHITE_FULL_01", //D4FC2A78", //3573295736", //"721671560
            "A_M_Y_BEVHILLS_02_WHITE_MINI_01", //E24573FE", //3796202494", //"498764802
            "A_M_Y_BUSICAS_01_WHITE_MINI_01", //AE353C51", //2922724433", //"1372242863
            "A_M_Y_BUSINESS_01_BLACK_FULL_01", //14EA502A", //350900266", //350900266
            "A_M_Y_BUSINESS_01_BLACK_MINI_01", //3EE0C0FD", //1054916861", //1054916861
            "A_M_Y_BUSINESS_01_CHINESE_FULL_01", //2AF37A7A", //720599674", //720599674
            "A_M_Y_BUSINESS_01_CHINESE_MINI_01", //BBE9D5F6", //3152664054", //"1142303242
            "A_M_Y_BUSINESS_01_WHITE_FULL_01", //A3B29220", //2746389024", //"1548578272
            "A_M_Y_BUSINESS_01_WHITE_MINI_02", //D5230A76", //3575843446", //"719123850
            "A_M_Y_BUSINESS_02_BLACK_FULL_01", //455E1156", //1163792726", //1163792726
            "A_M_Y_BUSINESS_02_BLACK_MINI_01", //728E84E0", //1921942752", //1921942752
            "A_M_Y_BUSINESS_02_WHITE_FULL_01", //21BD5DCB", //566058443", //566058443
            "A_M_Y_BUSINESS_02_WHITE_MINI_01", //DF04F10C", //3741643020", //"553324276
            "A_M_Y_BUSINESS_02_WHITE_MINI_02", //D1405583", //3510654339", //"784312957
            "A_M_Y_BUSINESS_03_BLACK_FULL_01", //63CAEDDD", //1674243549", //1674243549
            "A_M_Y_BUSINESS_03_WHITE_MINI_01", //5161018C", //1365311884", //1365311884
            "A_M_Y_DOWNTOWN_01_BLACK_FULL_01", //5C59E524", //1549395236", //1549395236
            "A_M_Y_EASTSA_01_LATINO_FULL_01", //4D091B2B", //1292442411", //1292442411
            "A_M_Y_EASTSA_01_LATINO_MINI_01", //90006FB0", //2415947696", //"1879019600
            "A_M_Y_EASTSA_02_LATINO_FULL_01", //71EFEA69", //1911548521", //1911548521
            "A_M_Y_EPSILON_01_BLACK_FULL_01", //3C737DA3", //1014201763", //1014201763
            "A_M_Y_EPSILON_01_KOREAN_FULL_01", //C5901506", //3314554118", //"980413178
            "A_M_Y_EPSILON_01_WHITE_FULL_01", //8B5E6BA1", //2338220961", //"1956746335
            "A_M_Y_EPSILON_02_WHITE_MINI_01", //5929B31B", //1495905051", //1495905051
            "A_M_Y_GAY_01_BLACK_FULL_01", //D66B6510", //3597362448", //"697604848
            "A_M_Y_GAY_01_LATINO_FULL_01", //56EA4F8A", //1458196362", //1458196362
            "A_M_Y_GAY_02_WHITE_MINI_01", //F31D141C", //4078769180", //"216198116
            "A_M_Y_GENSTREET_01_CHINESE_FULL_01", //FBD60609", //4225107465", //"69859831
            "A_M_Y_GENSTREET_01_CHINESE_MINI_01", //68B1C2E6", //1756480230", //1756480230
            "A_M_Y_GenStreet_01_White_FULL_01", //CCC8E124", //3435716900", //"859250396
            "A_M_Y_GENSTREET_01_WHITE_MINI_01", //0EA63482", //245773442", //245773442
            "A_M_Y_GENSTREET_02_BLACK_FULL_01", //A05521B9", //2689933753", //"1605033543
            "A_M_Y_GENSTREET_02_LATINO_FULL_01", //8A23EC00", //2317609984", //"1977357312
            "A_M_Y_GENSTREET_02_LATINO_MINI_01", //71BDAFD1", //1908256721", //1908256721
            "A_M_Y_GOLFER_01_WHITE_FULL_01", //DB7324F1", //3681756401", //"613210895
            "A_M_Y_GOLFER_01_WHITE_MINI_01", //0F36AC80", //255241344", //255241344
            "A_M_Y_HASJEW_01_WHITE_MINI_01", //C4E78448", //3303507016", //"991460280
            "A_M_Y_HIPPY_01_WHITE_FULL_01", //72E9121E", //1927877150", //1927877150
            "A_M_Y_HIPPY_01_WHITE_MINI_01", //A92E6392", //2838389650", //"1456577646
            "A_M_Y_HIPSTER_01_BLACK_FULL_01", //4D67AAB4", //1298639540", //1298639540
            "A_M_Y_HIPSTER_01_WHITE_FULL_01", //93896827", //2475255847", //"1819711449
            "A_M_Y_HIPSTER_01_WHITE_MINI_01", //B4EB0EBF", //3035303615", //"1259663681
            "A_M_Y_HIPSTER_02_WHITE_FULL_01", //742FB44D", //1949283405", //1949283405
            "A_M_Y_HIPSTER_02_WHITE_MINI_01", //521933C3", //1377383363", //1377383363
            "A_M_Y_HIPSTER_03_WHITE_FULL_01", //E694D959", //3868514649", //"426452647
            "A_M_Y_HIPSTER_03_WHITE_MINI_01", //B22C563F", //2989250111", //"1305717185
            "A_M_Y_KTOWN_01_KOREAN_FULL_01", //285D1B2F", //677190447", //677190447
            "A_M_Y_KTOWN_01_KOREAN_MINI_01", //D97AF207", //3648713223", //"646254073
            "A_M_Y_KTOWN_02_KOREAN_FULL_01", //7B3CEC0F", //2067590159", //2067590159
            "A_M_Y_KTOWN_02_KOREAN_MINI_01", //77B4E675", //2008344181", //2008344181
            "A_M_Y_LATINO_01_LATINO_MINI_01", //26ED66AF", //653092527", //653092527
            "A_M_Y_LATINO_01_LATINO_MINI_02", //C2429D5B", //3259145563", //"1035821733
            "A_M_Y_MEXTHUG_01_LATINO_FULL_01", //5756D257", //1465307735", //1465307735
            "A_M_Y_MUSCLBEAC_01_BLACK_FULL_01", //C1B61E52", //3249938002", //"1045029294
            "A_M_Y_MUSCLBEAC_01_WHITE_FULL_01", //0225E2F9", //36037369", //36037369
            "A_M_Y_MUSCLBEAC_01_WHITE_MINI_01", //977DC3C1", //2541601729", //"1753365567
            "A_M_Y_MUSCLBEAC_02_CHINESE_FULL_01", //A6F52D1E", //2801085726", //"1493881570
            "A_M_Y_MUSCLBEAC_02_LATINO_FULL_01", //67CCA113", //1741463827", //1741463827
            "A_M_Y_POLYNESIAN_01_POLYNESIAN_FULL_01", //121DA55B", //303932763", //303932763
            "A_M_Y_RACER_01_WHITE_MINI_01", //F64541B5", //4131733941", //"163233355
            "A_M_Y_ROLLERCOASTER_01_MINI_01", //7DB0EDFB", //2108747259", //2108747259
            "A_M_Y_ROLLERCOASTER_01_MINI_02", //678FC1B9", //1737474489", //1737474489
            "A_M_Y_ROLLERCOASTER_01_MINI_03", //A3F33A7F", //2750626431", //"1544340865
            "A_M_Y_ROLLERCOASTER_01_MINI_04", //962B9EF0", //2519441136", //"1775526160
            "A_M_Y_RUNNER_01_WHITE_FULL_01", //F85796B7", //4166489783", //"128477513
            "A_M_Y_RUNNER_01_WHITE_MINI_01", //6816D078", //1746325624", //1746325624
            "A_M_Y_SALTON_01_WHITE_MINI_01", //488C6273", //1217159795", //1217159795
            "A_M_Y_SALTON_01_WHITE_MINI_02", //5E6F8E25", //1584369189", //1584369189
            "A_M_Y_SKATER_01_WHITE_FULL_01", //1E6F76CB", //510621387", //510621387
            "A_M_Y_SKATER_01_WHITE_MINI_01", //41386857", //1094215767", //1094215767
            "A_M_Y_SKATER_02_BLACK_FULL_01", //46B9D99F", //1186584991", //1186584991
            "A_M_Y_SOUCENT_01_BLACK_FULL_01", //7ADB7C56", //2061204566", //2061204566
            "A_M_Y_SOUCENT_02_BLACK_FULL_01", //BA7414D7", //3128169687", //"1166797609
            "A_M_Y_SOUCENT_03_BLACK_FULL_01", //997A83C0", //2574943168", //"1720024128
            "A_M_Y_SOUCENT_04_BLACK_FULL_01", //97BA1740", //2545555264", //"1749412032
            "A_M_Y_SOUCENT_04_BLACK_MINI_01", //E3DE23A6", //3822986150", //"471981146
            "A_M_Y_STBLA_01_BLACK_FULL_01", //80372D5A", //2151099738", //"2143867558
            "A_M_Y_STBLA_02_BLACK_FULL_01", //B77F38D5", //3078568149", //"1216399147
            "A_M_Y_STLAT_01_LATINO_FULL_01", //AF739934", //2943588660", //"1351378636
            "A_M_Y_STLAT_01_LATINO_MINI_01", //CDC7408D", //3452387469", //"842579827
            "A_M_Y_STWHI_01_WHITE_FULL_01", //51843C65", //1367620709", //1367620709
            "A_M_Y_STWHI_01_WHITE_MINI_01", //283E7635", //675182133", //675182133
            "A_M_Y_STWHI_02_WHITE_FULL_01", //32F459E7", //854874599", //854874599
            "A_M_Y_STWHI_02_WHITE_MINI_01", //D94A1B14", //3645512468", //"649454828
            "A_M_Y_SUNBATHE_01_BLACK_FULL_01", //523A66C3", //1379559107", //1379559107
            "A_M_Y_SUNBATHE_01_WHITE_FULL_01", //0CEA2526", //216671526", //216671526
            "A_M_Y_SUNBATHE_01_WHITE_MINI_01", //C31ADD04", //3273317636", //"1021649660
            "A_M_Y_TRIATHLON_01_MINI_01", //55B488C4", //1437894852", //1437894852
            "A_M_Y_TRIATHLON_01_MINI_02", //87746C43", //2272554051", //"2022413245
            "A_M_Y_TRIATHLON_01_MINI_03", //BB49D3ED", //3142177773", //"1152789523
            "A_M_Y_TRIATHLON_01_MINI_04", //ED26B7A6", //3978737574", //"316229722
            "A_M_Y_VINEWOOD_01_BLACK_FULL_01", //8567F85C", //2238183516", //"2056783780
            "A_M_Y_VINEWOOD_01_BLACK_MINI_01", //0C746F67", //208957287", //208957287
            "A_M_Y_VINEWOOD_02_WHITE_FULL_01", //0A626D28", //174222632", //174222632
            "A_M_Y_VINEWOOD_02_WHITE_MINI_01", //C370059E", //3278898590", //"1016068706
            "A_M_Y_Vinewood_03_Latino_FULL_01", //F450D2AC", //4098937516", //"196029780
            "A_M_Y_VINEWOOD_03_LATINO_MINI_01", //9FDD31FF", //2682073599", //"1612893697
            "A_M_Y_VINEWOOD_03_WHITE_FULL_01", //852D3A8F", //2234333839", //"2060633457
            "A_M_Y_VINEWOOD_03_WHITE_MINI_01", //3A84F91E", //981793054", //981793054
            "A_M_Y_VINEWOOD_04_WHITE_FULL_01", //77B21017", //2008158231", //2008158231
            "A_M_Y_VINEWOOD_04_WHITE_MINI_01", //99DA0ADA", //2581203674", //"1713763622
            "G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_01", //F840ABA3", //4164987811", //"129979485
            "G_M_M_ARMBOSS_01_WHITE_ARMENIAN_MINI_02", //DD7F7641", //3716118081", //"578849215
            "G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_01", //9B88EB80", //2609441664", //"1685525632
            "G_M_M_ARMLIEUT_01_WHITE_ARMENIAN_MINI_02", //8BCF4C0D", //2345618445", //"1949348851
            "G_M_M_CHIBOSS_01_CHINESE_MINI_01", //FD2B8068", //4247486568", //"47480728
            "G_M_M_CHIBOSS_01_CHINESE_MINI_02", //6EF5E41B", //1861608475", //1861608475
            "G_M_M_CHIGOON_01_CHINESE_MINI_01", //E8CB59DD", //3905640925", //"389326371
            "G_M_M_CHIGOON_01_CHINESE_MINI_02", //F8FCFA40", //4177328704", //"117638592
            "G_M_M_CHIGOON_02_CHINESE_MINI_01", //93D6B240", //2480321088", //"1814646208
            "G_M_M_CHIGOON_02_CHINESE_MINI_02", //2138CD06", //557370630", //557370630
            "G_M_M_KORBOSS_01_KOREAN_MINI_01", //049ADD23", //77258019", //77258019
            "G_M_M_KORBOSS_01_KOREAN_MINI_02", //9DB98F56", //2646183766", //"1648783530
            "G_M_M_MEXBOSS_01_LATINO_MINI_01", //121AC997", //303745431", //303745431
            "G_M_M_MEXBOSS_01_LATINO_MINI_02", //A86BF63B", //2825647675", //"1469319621
            "G_M_M_MEXBOSS_02_LATINO_MINI_01", //FCB3B4DF", //4239635679", //"55331617
            "G_M_M_MEXBOSS_02_LATINO_MINI_02", //59FC6F6F", //1509715823", //1509715823
            "G_M_M_X17_RSO_01", //7B4E71E9", //2068738537", //2068738537
            "G_M_M_X17_RSO_02", //0518057E", //85460350", //85460350
            "G_M_M_X17_RSO_03", //16232794", //371402644", //371402644
            "G_M_M_X17_RSO_04", //09AF0EA8", //162467496", //162467496
            "G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_01", //F98339EA", //4186126826", //"108840470
            "G_M_Y_ARMGOON_02_WHITE_ARMENIAN_MINI_02", //91C4EA6B", //2445601387", //"1849365909
            "G_M_Y_BALLAEAST_01_BLACK_FULL_01", //9CFAAA5C", //2633673308", //"1661293988
            "G_M_Y_BALLAEAST_01_BLACK_FULL_02", //8F2D0EC1", //2402094785", //"1892872511
            "G_M_Y_BALLAEAST_01_BLACK_MINI_01", //2C0FCD9F", //739233183", //739233183
            "G_M_Y_BALLAEAST_01_BLACK_MINI_02", //D5BE20F9", //3586007289", //"708960007
            "G_M_Y_BALLAEAST_01_BLACK_MINI_03", //C77B8474", //3346760820", //"948206476
            "G_M_Y_BALLAORIG_01_BLACK_FULL_01", //F0D6A527", //4040598823", //"254368473
            "G_M_Y_BALLAORIG_01_BLACK_FULL_02", //DF4101FC", //3745579516", //"549387780
            "G_M_Y_BALLAORIG_01_BLACK_MINI_01", //719C62A9", //1906074281", //1906074281
            "G_M_Y_BALLAORIG_01_BLACK_MINI_02", //AD1BD9A7", //2904283559", //"1390683737
            "G_M_Y_BALLAORIG_01_BLACK_MINI_03", //925BA427", //2455479335", //"1839487961
            "G_M_Y_BALLASOUT_01_BLACK_FULL_01", //60B320B0", //1622352048", //1622352048
            "G_M_Y_BALLASOUT_01_BLACK_FULL_02", //2A5033EB", //709899243", //709899243
            "G_M_Y_BALLASOUT_01_BLACK_MINI_01", //6ED150A0", //1859211424", //1859211424
            "G_M_Y_BALLASOUT_01_BLACK_MINI_02", //A00D3317", //2685219607", //"1609747689
            "G_M_Y_BALLASOUT_01_BLACK_MINI_03", //BE746FE5", //3195301861", //"1099665435
            "G_M_Y_FAMCA_01_BLACK_FULL_01", //3F299AE9", //1059691241", //1059691241
            "G_M_Y_FAMCA_01_BLACK_FULL_02", //51573F44", //1364672324", //1364672324
            "G_M_Y_FAMCA_01_BLACK_MINI_01", //D991FA9F", //3650222751", //"644744545
            "G_M_Y_FAMCA_01_BLACK_MINI_02", //6B6D9E58", //1802346072", //1802346072
            "G_M_Y_FAMCA_01_BLACK_MINI_03", //0658D3F8", //106484728", //106484728
            "G_M_Y_FAMDNF_01_BLACK_FULL_01", //5F8F7FB9", //1603239865", //1603239865
            "G_M_Y_FAMDNF_01_BLACK_FULL_02", //B271257B", //2993759611", //"1301207685
            "G_M_Y_FAMDNF_01_BLACK_MINI_01", //BA8A1C11", //3129613329", //"1165353967
            "G_M_Y_FAMDNF_01_BLACK_MINI_02", //28A77842", //682063938", //682063938
            "G_M_Y_FAMDNF_01_BLACK_MINI_03", //D2384B6D", //3526904685", //"768062611
            "G_M_Y_FAMFOR_01_BLACK_FULL_01", //4D505739", //1297110841", //1297110841
            "G_M_Y_FAMFOR_01_BLACK_FULL_02", //7FEB3C3E", //2146122814", //2146122814
            "G_M_Y_FAMFOR_01_BLACK_MINI_01", //FA83BCD1", //4202937553", //"92029743
            "G_M_Y_FAMFOR_01_BLACK_MINI_02", //4721560B", //1193367051", //1193367051
            "G_M_Y_FAMFOR_01_BLACK_MINI_03", //56CEF566", //1456403814", //1456403814
            "G_M_Y_KOREAN_01_KOREAN_MINI_01", //3975B100", //964014336", //964014336
            "G_M_Y_KOREAN_01_KOREAN_MINI_02", //0F585CC6", //257449158", //257449158
            "G_M_Y_KOREAN_02_KOREAN_MINI_01", //E1E0349F", //3789567135", //"505400161
            "G_M_Y_KOREAN_02_KOREAN_MINI_02", //D41A1913", //3558480147", //"736487149
            "G_M_Y_KORLIEUT_01_KOREAN_MINI_01", //6B9A636E", //1805280110", //1805280110
            "G_M_Y_KORLIEUT_01_KOREAN_MINI_02", //2116CE64", //555142756", //555142756
            "G_M_Y_LATINO01_LATINO_MINI_02", //215F60FC", //559898876", //559898876
            "G_M_Y_LOST_01_BLACK_FULL_01", //BD922FD5", //3180474325", //"1114492971
            "G_M_Y_LOST_01_BLACK_FULL_02", //06D7C263", //114803299", //114803299
            "G_M_Y_LOST_01_BLACK_MINI_01", //D03903FA", //3493397498", //"801569798
            "G_M_Y_LOST_01_BLACK_MINI_02", //0154E631", //22341169", //22341169
            "G_M_Y_LOST_01_BLACK_MINI_03", //2ADE3943", //719206723", //719206723
            "G_M_Y_LOST_01_WHITE_FULL_01", //A29BB240", //2728112704", //"1566854592
            "G_M_Y_LOST_01_WHITE_MINI_01", //0477B521", //74954017", //74954017
            "G_M_Y_LOST_01_WHITE_MINI_02", //D6005837", //3590346807", //"704620489
            "G_M_Y_LOST_02_LATINO_FULL_01", //93D0C3D0", //2479932368", //"1815034928
            "G_M_Y_LOST_02_LATINO_FULL_02", //DD9DD769", //3718109033", //"576858263
            "G_M_Y_LOST_02_LATINO_MINI_01", //B4A96868", //3031001192", //"1263966104
            "G_M_Y_LOST_02_LATINO_MINI_02", //C34E85B2", //3276703154", //"1018264142
            "G_M_Y_LOST_02_LATINO_MINI_03", //D1C5229F", //3519357599", //"775609697
            "G_M_Y_LOST_02_WHITE_FULL_01", //552D4F23", //1429032739", //1429032739
            "G_M_Y_LOST_02_WHITE_MINI_01", //AC382220", //2889359904", //"1405607392
            "G_M_Y_LOST_02_WHITE_MINI_02", //302D2A08", //808266248", //808266248
            "G_M_Y_LOST_03_WHITE_FULL_01", //269A2029", //647634985", //647634985
            "G_M_Y_LOST_03_WHITE_MINI_02", //19793B32", //427375410", //427375410
            "G_M_Y_LOST_03_WHITE_MINI_03", //6C55606D", //1817534573", //1817534573
            "G_M_Y_MEXGOON_01_LATINO_MINI_01", //57C1000E", //1472266254", //1472266254
            "G_M_Y_MEXGOON_01_LATINO_MINI_02", //4F90EFAA", //1334898602", //1334898602
            "G_M_Y_MEXGOON_02_LATINO_MINI_01", //B00D3337", //2953655095", //"1341312201
            "G_M_Y_MEXGOON_02_LATINO_MINI_02", //6A4227A2", //1782720418", //1782720418
            "G_M_Y_MEXGOON_03_LATINO_MINI_01", //36640278", //912523896", //912523896
            "G_M_Y_MEXGOON_03_LATINO_MINI_02", //45EBA187", //1173070215", //1173070215
            "G_M_Y_POLOGOON_01_LATINO_MINI_01", //D1389B20", //3510147872", //"784819424
            "G_M_Y_POLOGOON_01_LATINO_MINI_02", //DBFFB0AE", //3690967214", //"604000082
            "G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_01", //083FF1D1", //138408401", //138408401
            "G_M_Y_SALVABOSS_01_SALVADORIAN_MINI_02", //FB1D578C", //4213004172", //"81963124
            "G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_01", //0E2D970B", //237868811", //237868811
            "G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_02", //C9228CF6", //3374484726", //"920482570
            "G_M_Y_SALVAGOON_01_SALVADORIAN_MINI_03", //D6DD286B", //3604818027", //"690149269
            "G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_01", //38FB557B", //955995515", //955995515
            "G_M_Y_SalvaGoon_02_SALVADORIAN_MINI_02", //2B1E39C1", //723401153", //723401153
            "G_M_Y_SALVAGOON_02_SALVADORIAN_MINI_03", //1C639C4C", //476290124", //476290124
            "G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_01", //B2F150B6", //3002159286", //"1292808010
            "G_M_Y_SALVAGOON_03_SALVADORIAN_MINI_02", //50C88C62", //1355320418", //1355320418
            "G_M_Y_SalvaGoon_03_SALVADORIAN_MINI_03", //61092CDF", //1627991263", //1627991263
            "G_M_Y_STREETPUNK02_BLACK_MINI_04", //5E2969AE", //1579772334", //1579772334
            "G_M_Y_STREETPUNK_01_BLACK_MINI_01", //A5364DA4", //2771799460", //"1523167836
            "G_M_Y_STREETPUNK_01_BLACK_MINI_02", //7AD978EB", //2061072619", //2061072619
            "G_M_Y_STREETPUNK_01_BLACK_MINI_03", //4A3417A1", //1244927905", //1244927905
            "G_M_Y_STREETPUNK_02_BLACK_MINI_01", //4C3FB5C7", //1279243719", //1279243719
            "G_M_Y_STREETPUNK_02_BLACK_MINI_02", //658FE867", //1703929959", //1703929959
            "G_M_Y_STREETPUNK_02_BLACK_MINI_03", //58794E3A", //1484344890", //1484344890
            "G_M_Y_X17_AGUARD_01", //0FC95A0C", //264854028", //264854028
            "G_M_Y_X17_AGUARD_02", //1AEC7052", //451702866", //451702866
            "G_M_Y_X17_AGUARD_03", //ED3E94F7", //3980301559", //"314665737
            "G_M_Y_X17_AGUARD_04", //71369CE9", //1899404521", //1899404521
            "G_M_Y_X17_AGUARD_05", //7B64B145", //2070196549", //2070196549
            "CONSTRUCTION_SITE_MALE_01", //C285BFCA", //3263545290", //"1031422006
            "CONSTRUCTION_SITE_MALE_02", //3572A596", //896705942", //896705942
            "CONSTRUCTION_SITE_MALE_03", //82A1C003", //2191638531", //"2103328765
            "CONSTRUCTION_SITE_MALE_04", //93CE625C", //2479776348", //"1815190948
            "BAILBOND1JUMPER", //6909D3CC", //1762251724", //1762251724
            "BAILBOND2JUMPER", //8C257BBD", //2351266749", //"1943700547
            "BAILBOND3JUMPER", //2E2EF1F8", //774828536", //774828536
            "BAILBOND4JUMPER", //643A0559", //1681524057", //1681524057
            "BARRY", //A9058E54", //2835713620", //"1459253676
            "BARRY_01_ALIEN_A", //82BA2086", //2193236102", //"2101731194
            "BARRY_01_ALIEN_B", //7494843B", //1955890235", //1955890235
            "BARRY_01_ALIEN_C", //F06D7BEB", //4033706987", //"261260309
            "BARRY_02_CLOWN_A", //7929F21D", //2032792093", //2032792093
            "BARRY_02_CLOWN_B", //66F4CDB3", //1727319475", //1727319475
            "BARRY_02_CLOWN_C", //9E16BBF6", //2652290038", //"1642677258
            "HOSTAGEBF1", //D5D22CA5", //3587320997", //"707646299
            "HOSTAGEBM1", //E8CB2CFF", //3905629439", //"389337857
            "HOSTAGEWF1", //8632FA43", //2251487811", //"2043479485
            "HOSTAGEWF2", //99952107", //2576687367", //"1718279929
            "HOSTAGEWM1", //5779B631", //1467594289", //1467594289
            "HOSTAGEWM2", //9F53C5E4", //2673067492", //"1621899804
            "FRANKLIN_1_NORMAL", //D603B047", //3590565959", //"704401337
            "FRANKLIN_2_NORMAL", //9F8D1B67", //2676824935", //"1618142361
            "FRANKLIN_3_NORMAL", //FA7C388C", //4202444940", //"92522356
            "FRANKLIN_ANGRY", //D227A0A9", //3525812393", //"769154903
            "FRANKLIN_DRUNK", //E6EFD5C5", //3874477509", //"420489787
            "FRANKLIN_NORMAL", //64CCE782", //1691150210", //1691150210
            "MICHAEL_1_NORMAL", //78BECF39", //2025770809", //2025770809
            "MICHAEL_2_NORMAL", //568D3564", //1452094820", //1452094820
            "MICHAEL_3_NORMAL", //FBC7F7B9", //4224186297", //"70780999
            "MICHAEL_ANGRY", //973C5F18", //2537316120", //"1757651176
            "MICHAEL_DRUNK", //DEBBCFA7", //3736850343", //"558116953
            "MICHAEL_NORMAL", //C46897D1", //3295188945", //"999778351
            "MP_M_SHOPKEEP_01_CHINESE_MINI_01", //D36AF9E4", //3547003364", //"747963932
            "MP_M_SHOPKEEP_01_LATINO_MINI_01", //0592C339", //93504313", //93504313
            "MP_M_SHOPKEEP_01_PAKISTANI_MINI_01", //25364924", //624314660", //624314660
            "PAIN_FRANKLIN_01", //2003420C", //537084428", //537084428
            "PAIN_FRANKLIN_02", //EBF4D9F0", //3958692336", //"336274960
            "PAIN_FRANKLIN_03", //1DA7BD55", //497532245", //497532245
            "PAIN_FRANKLIN_04", //C5B08D68", //3316682088", //"978285208
            "PAIN_MALE_MIXED_01", //0A14C671", //169133681", //169133681
            "PAIN_MALE_MIXED_02", //A251F75D", //2723280733", //"1571686563
            "PAIN_MALE_MIXED_03", //700712C8", //1879511752", //1879511752
            "PAIN_MALE_MIXED_04", //86A03FFA", //2258649082", //"2036318214
            "PAIN_MALE_MIXED_05", //5124548F", //1361335439", //1361335439
            "PAIN_MALE_MIXED_06", //B25B96FC", //2992346876", //"1302620420
            "PAIN_MALE_MIXED_07", //BC96AB72", //3163990898", //"1130976398
            "PAIN_MALE_MIXED_08", //8DA5CD91", //2376453521", //"1918513775
            "PAIN_MALE_MIXED_09", //97EBE21D", //2548818461", //"1746148835
            "PAIN_MALE_NORMAL_01", //E3B792BC", //3820458684", //"474508612
            "PAIN_MALE_NORMAL_02", //145573EB", //341144555", //341144555
            "PAIN_MALE_NORMAL_03", //E296906E", //3801518190", //"493449106
            "PAIN_MALE_NORMAL_04", //B7C53ACC", //3083156172", //"1211811124
            "PAIN_MALE_NORMAL_05", //09F45F29", //167010089", //167010089
            "PAIN_MALE_NORMAL_06", //CB49E1D5", //3410616789", //"884350507
            "PAIN_MALE_TOUGH_01", //ACC806D0", //2898790096", //"1396177200
            "PAIN_MALE_TOUGH_02", //DB33E3A7", //3677610919", //"617356377
            "PAIN_MALE_TOUGH_03", //90FF4F3B", //2432651067", //"1862316229
            "PAIN_MALE_TOUGH_04", //BF202B80", //3206556544", //"1088410752
            "PAIN_MALE_TOUGH_05", //F397946E", //4086797422", //"208169874
            "PAIN_MALE_WEAK_01", //22C36EE8", //583233256", //583233256
            "PAIN_MALE_WEAK_02", //B05B0A1D", //2958756381", //"1336210915
            "PAIN_MALE_WEAK_03", //D62355AD", //3592639917", //"702327379
            "PAIN_MALE_WEAK_04", //E61CF5A0", //3860657568", //"434309728
            "PAIN_MICHAEL_01", //E657BAA9", //3864509097", //"430458199
            "PAIN_MICHAEL_02", //D8151E24", //3625262628", //"669704668
            "PAIN_MICHAEL_03", //3436D666", //876009062", //876009062
            "PAIN_MICHAEL_04", //66EB3BD2", //1726692306", //1726692306
            "PAIN_PLAYER_TEST_01", //F38B2CC2", //4085984450", //"208982846
            "PAIN_PLAYER_TEST_02", //E161886F", //3781265519", //"513701777
            "PAIN_PLAYER_TEST_03", //576C746B", //1466725483", //1466725483
            "PAIN_TEST_01", //F5655828", //4117059624", //"177907672
            "PAIN_TEST_02", //FC1C6596", //4229719446", //"65247850
            "PAIN_TEST_03", //172E9BA2", //388930466", //388930466
            "PAIN_TREVOR_01", //21261ADB", //556145371", //556145371
            "PAIN_TREVOR_02", //32DCBE48", //853327432", //853327432
            "PAIN_TREVOR_03", //3DAED3EC", //1034867692", //1034867692
            "PAIN_TREVOR_04", //4F427713", //1329755923", //1329755923
            "S_M_M_AMMUCOUNTRY_01_WHITE_01", //14AE106F", //346951791", //346951791
            "S_M_M_AMMUCOUNTRY_WHITE_MINI_01", //B6A5CF41", //3064319809", //"1230647487
            "S_M_M_AUTOSHOP_01_WHITE_01", //B97E410A", //3112059146", //"1182908150
            "S_M_M_BOUNCER_01_BLACK_FULL_01", //5CF368B8", //1559455928", //1559455928
            "S_M_M_BOUNCER_01_LATINO_FULL_01", //57B91BD3", //1471749075", //1471749075
            "S_M_M_BOUNCER_LATINO_FULL_01", //66E1CE62", //1726074466", //1726074466
            "S_M_M_CIASEC_01_BLACK_MINI_01", //797CD9E6", //2038225382", //2038225382
            "S_M_M_CIASEC_01_BLACK_MINI_02", //F6AED44C", //4138652748", //"156314548
            "S_M_M_CIASEC_01_WHITE_MINI_01", //7DB88D9D", //2109246877", //2109246877
            "S_M_M_CIASEC_01_WHITE_MINI_02", //AF77F11B", //2943873307", //"1351093989
            "S_M_M_FIBOFFICE_01_BLACK_MINI_01", //DEA5CD64", //3735407972", //"559559324
            "S_M_M_FIBOFFICE_01_BLACK_MINI_02", //F0C0F19A", //4039176602", //"255790694
            "S_M_M_FIBOFFICE_01_LATINO_MINI_01", //655117C7", //1699813319", //1699813319
            "S_M_M_FIBOFFICE_01_LATINO_MINI_02", //938DF440", //2475553856", //"1819413440
            "S_M_M_FIBOFFICE_01_WHITE_MINI_01", //0AC9249C", //180954268", //180954268
            "S_M_M_FIBOFFICE_01_WHITE_MINI_02", //FE040B12", //4261677842", //"33289454
            "S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_01", //90328A79", //2419231353", //"1875735943
            "S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_02", //D9249C5C", //3643055196", //"651912100
            "S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_03", //EBDDC1CE", //3957178830", //"337788466
            "S_M_M_GENERICCHEAPWORKER_01_LATINO_MINI_04", //635D30CB", //1667051723", //1667051723
            "S_M_M_GENERICMARINE_01_LATINO_MINI_01", //24A78E34", //614960692", //614960692
            "S_M_M_GENERICMARINE_01_LATINO_MINI_02", //8F6E63C0", //2406376384", //"1888590912
            "S_M_M_GENERICMECHANIC_01_BLACK_MINI_01", //229CDFDF", //580706271", //580706271
            "S_M_M_GENERICMECHANIC_01_BLACK_MINI_02", //09392D18", //154742040", //154742040
            "S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_01", //10C0CBFD", //281070589", //281070589
            "S_M_M_GENERICPOSTWORKER_01_BLACK_MINI_02", //FC16A2A9", //4229341865", //"65625431
            "S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_01", //D2C75726", //3536279334", //"758687962
            "S_M_M_GENERICPOSTWORKER_01_WHITE_MINI_02", //DC906AB8", //3700452024", //"594515272
            "S_M_M_GENERICSECURITY_01_BLACK_MINI_01", //3D1D46D3", //1025328851", //1025328851
            "S_M_M_GENERICSECURITY_01_BLACK_MINI_02", //565A794D", //1448769869", //1448769869
            "S_M_M_GENERICSECURITY_01_BLACK_MINI_03", //9162EF15", //2439180053", //"1855787243
            "S_M_M_GENERICSECURITY_01_LATINO_MINI_01", //B5910C1D", //3046181917", //"1248785379
            "S_M_M_GENERICSECURITY_01_LATINO_MINI_02", //97D1D09F", //2547110047", //"1747857249
            "S_M_M_GENERICSECURITY_01_WHITE_MINI_01", //5D4BE0A9", //1565253801", //1565253801
            "S_M_M_GENERICSECURITY_01_WHITE_MINI_02", //4FE145D4", //1340163540", //1340163540
            "S_M_M_GENERICSECURITY_01_WHITE_MINI_03", //66DDF3D9", //1725821913", //1725821913
            "S_M_M_HAIRDRESSER_01_BLACK_MINI_01", //594BCB86", //1498139526", //1498139526
            "S_M_M_HAIRDRESS_01_BLACK_01", //7E2CBE66", //2116861542", //2116861542
            "S_M_M_PARAMEDIC_01_BLACK_MINI_01", //1DE649B3", //501631411", //501631411
            "S_M_M_PARAMEDIC_01_LATINO_MINI_01", //43261273", //1126568563", //1126568563
            "S_M_M_PARAMEDIC_01_WHITE_MINI_01", //54925FD6", //1418878934", //1418878934
            "S_M_M_PILOT_01_BLACK_FULL_01", //3DAC41B0", //1034699184", //1034699184
            "S_M_M_PILOT_01_BLACK_FULL_02", //4F73E53F", //1332995391", //1332995391
            "S_M_M_PILOT_01_WHITE_FULL_01", //BC0F504A", //3155120202", //"1139847094
            "S_M_M_PILOT_01_WHITE_FULL_02", //A9A32B72", //2846042994", //"1448924302
            "S_M_M_TRUCKER_01_BLACK_FULL_01", //D940A3BC", //3644892092", //"650075204
            "S_M_M_TRUCKER_01_WHITE_FULL_01", //3CA3269A", //1017325210", //1017325210
            "S_M_M_TRUCKER_01_WHITE_FULL_02", //0B4743DF", //189219807", //189219807
            "S_M_Y_AIRWORKER_BLACK_FULL_01", //90ECCFDC", //2431438812", //"1863528484
            "S_M_Y_AIRWORKER_BLACK_FULL_02", //9EAF6B61", //2662296417", //"1632670879
            "S_M_Y_AIRWORKER_LATINO_FULL_01", //0D981AB3", //228072115", //228072115
            "S_M_Y_AIRWORKER_LATINO_FULL_02", //234F4621", //592397857", //592397857
            "S_M_Y_AMMUCITY_01_WHITE_01", //5C7526F0", //1551181552", //1551181552
            "S_M_Y_AMMUCITY_01_WHITE_MINI_01", //20C18390", //549553040", //549553040
            "S_M_Y_BAYWATCH_01_BLACK_FULL_01", //CD79387C", //3447273596", //"847693700
            "S_M_Y_BAYWATCH_01_BLACK_FULL_02", //E32263CE", //3810681806", //"484285490
            "S_M_Y_BAYWATCH_01_WHITE_FULL_01", //BAB6D724", //3132544804", //"1162422492
            "S_M_Y_BAYWATCH_01_WHITE_FULL_02", //1EA89F06", //514367238", //514367238
            "S_M_Y_BLACKOPS_01_BLACK_MINI_01", //BBE7E188", //3152535944", //"1142431352
            "S_M_Y_BLACKOPS_01_BLACK_MINI_02", //DDB7A52B", //3719800107", //"575167189
            "S_M_Y_BLACKOPS_01_WHITE_MINI_01", //65B98207", //1706656263", //1706656263
            "S_M_Y_BLACKOPS_01_WHITE_MINI_02", //D7FFE692", //3623872146", //"671095150
            "S_M_Y_BLACKOPS_02_LATINO_MINI_01", //4214AE9E", //1108651678", //1108651678
            "S_M_Y_BLACKOPS_02_LATINO_MINI_02", //13E2520A", //333599242", //333599242
            "S_M_Y_BLACKOPS_02_WHITE_MINI_01", //C3A6E830", //3282495536", //"1012471760
            "S_M_Y_BUSBOY_01_WHITE_MINI_01", //C847EAA9", //3360156329", //"934810967
            "S_M_Y_COP_01_BLACK_FULL_01", //DD72FE87", //3715300999", //"579666297
            "S_M_Y_COP_01_BLACK_FULL_02", //C7B3D309", //3350450953", //"944516343
            "S_M_Y_COP_01_BLACK_MINI_01", //EF2409AE", //4012116398", //"282850898
            "S_M_Y_COP_01_BLACK_MINI_02", //00CDAD01", //13479169", //13479169
            "S_M_Y_COP_01_BLACK_MINI_03", //4A804065", //1249919077", //1249919077
            "S_M_Y_COP_01_BLACK_MINI_04", //5C34E3CE", //1546970062", //1546970062
            "S_M_Y_COP_01_WHITE_FULL_01", //6F38027D", //1865941629", //1865941629
            "S_M_Y_COP_01_WHITE_FULL_02", //360C1026", //906760230", //906760230
            "S_M_Y_COP_01_WHITE_MINI_01", //BA399207", //3124335111", //"1170632185
            "S_M_Y_COP_01_WHITE_MINI_02", //CBEB356A", //3421189482", //"873777814
            "S_M_Y_COP_01_WHITE_MINI_03", //DDB458FC", //3719583996", //"575383300
            "S_M_Y_COP_01_WHITE_MINI_04", //EF5EFC51", //4015979601", //"278987695
            "S_M_Y_FIREMAN_01_LATINO_FULL_01", //71549C50", //1901370448", //1901370448
            "S_M_Y_FIREMAN_01_LATINO_FULL_02", //7C0BB1BE", //2081141182", //2081141182
            "S_M_Y_FIREMAN_01_WHITE_FULL_01", //0094A96A", //9742698", //9742698
            "S_M_Y_FIREMAN_01_WHITE_FULL_02", //80DB29FD", //2161846781", //"2133120515
            "S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01", //09FD9FD3", //167616467", //167616467
            "S_M_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02", //37D07B78", //936409976", //936409976
            "S_M_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01", //3869CBA7", //946457511", //946457511
            "S_M_Y_GENERICMARINE_01_BLACK_MINI_01", //17F5909B", //401969307", //401969307
            "S_M_Y_GENERICMARINE_01_BLACK_MINI_02", //0E947DD1", //244612561", //244612561
            "S_M_Y_GENERICMARINE_01_WHITE_MINI_01", //55FDC164", //1442693476", //1442693476
            "S_M_Y_GENERICMARINE_01_WHITE_MINI_02", //08BBA6E1", //146515681", //146515681
            "S_M_Y_GENERICWORKER_01_BLACK_MINI_01", //0A3A301F", //171585567", //171585567
            "S_M_Y_GENERICWORKER_01_BLACK_MINI_02", //60D0DD4B", //1624300875", //1624300875
            "S_M_Y_GENERICWORKER_01_LATINO_MINI_01", //86640419", //2254701593", //"2040265703
            "S_M_Y_GENERICWORKER_01_LATINO_MINI_02", //F4AC60AC", //4104937644", //"190029652
            "S_M_Y_GENERICWORKER_01_WHITE_01", //129AD4A3", //312136867", //312136867
            "S_M_Y_GENERICWORKER_01_WHITE_MINI_01", //E8727D7D", //3899817341", //"395149955
            "S_M_Y_GENERICWORKER_01_WHITE_MINI_02", //B23310FF", //2989691135", //"1305276161
            "S_M_Y_HWAYCOP_01_BLACK_FULL_01", //DC403AA7", //3695196839", //"599770457
            "S_M_Y_HWAYCOP_01_BLACK_FULL_02", //11AAA57B", //296396155", //296396155
            "S_M_Y_HWAYCOP_01_WHITE_FULL_01", //F332D786", //4080195462", //"214771834
            "S_M_Y_HWAYCOP_01_WHITE_FULL_02", //0384F82A", //59045930", //59045930
            "S_M_Y_MCOP_01_WHITE_MINI_01", //7A44FB56", //2051341142", //2051341142
            "S_M_Y_MCOP_01_WHITE_MINI_02", //670ED4EA", //1729025258", //1729025258
            "S_M_Y_MCOP_01_WHITE_MINI_03", //54D0306D", //1422930029", //1422930029
            "S_M_Y_MCOP_01_WHITE_MINI_04", //B361ED8F", //3009539471", //"1285427825
            "S_M_Y_MCOP_01_WHITE_MINI_05", //0F8FA5E9", //261072361", //261072361
            "S_M_Y_MCOP_01_WHITE_MINI_06", //FFE50694", //4293199508", //"1767788
            "S_M_Y_RANGER_01_LATINO_FULL_01", //94EBCA6B", //2498480747", //"1796486549
            "S_M_Y_RANGER_01_WHITE_FULL_01", //9723C55B", //2535703899", //"1759263397
            "S_M_Y_SHERIFF_01_WHITE_FULL_01", //A1C8B88A", //2714286218", //"1580681078
            "S_M_Y_SHERIFF_01_WHITE_FULL_02", //939F1C37", //2476678199", //"1818289097
            "S_M_Y_SHOP_MASK_WHITE_MINI_01", //03AAB8B0", //61520048", //61520048
            "S_M_Y_SWAT_01_WHITE_FULL_01", //BA960340", //3130393408", //"1164573888
            "S_M_Y_SWAT_01_WHITE_FULL_02", //E55E58D0", //3848165584", //"446801712
            "S_M_Y_SWAT_01_WHITE_FULL_03", //F324745C", //4079252572", //"215714724
            "S_M_Y_SWAT_01_WHITE_FULL_04", //0236127F", //37098111", //37098111
            "U_M_Y_TATTOO_01_WHITE_MINI_01", //956C178D", //2506889101", //"1788078195
            "TAXIALONZO", //A0B07846", //2695919686", //"1599047610
            "TAXIBRUCE", //1E0A9C18", //504011800", //504011800
            "TAXICLYDE", //90992C60", //2425957472", //"1869009824
            "TAXIDARREN", //2C1A5202", //739922434", //739922434
            "TAXIDERRICK", //2D71435C", //762397532", //762397532
            "TAXIDOM", //9DA9FDB5", //2645163445", //"1649803851
            "TAXIFELIPE", //E66D1B66", //3865910118", //"429057178
            "TAXIGANGM", //08AC318A", //145502602", //145502602
            "TAXIJAMES", //A8A8F64E", //2829645390", //"1465321906
            "TAXIKWAK", //58B68A9D", //1488358045", //1488358045
            "TAXIOJCOP1", //5883C603", //1485030915", //1485030915
            "TAXIOTIS", //A0B868F9", //2696440057", //"1598527239
            "TAXIPAULIE", //05437D58", //88309080", //88309080
            "TAXIWALTER", //1A43E0E1", //440656097", //440656097
            "TEST_VOICE", //62883B8C", //1653095308", //1653095308
            "TREVOR_1_NORMAL", //3AD6D338", //987157304", //987157304
            "TREVOR_2_NORMAL", //CB2DDB29", //3408780073", //"886187223
            "TREVOR_3_NORMAL", //4697A021", //1184342049", //1184342049
            "TREVOR_ANGRY", //0953FCF8", //156499192", //156499192
            "TREVOR_DRUNK", //EA0CA87A", //3926698106", //"368269190
            "TREVOR_NORMAL", //4072CC77", //1081265271", //1081265271
            "VB_LIFEGUARD_01", //6B6161EE", //1801544174", //1801544174
            "VB_MALE_01", //AC519660", //2891028064", //"1403939232
            "VB_MALE_02", //B5E5A988", //3051727240", //"1243240056
            "VB_MALE_03", //3A03B192", //973320594", //973320594
            "WAVELOAD_PAIN_FRANKLIN", //33F65FC3", //871784387", //871784387
            "WAVELOAD_PAIN_MALE", //804C18BB", //2152470715", //"2142496581
            "WAVELOAD_PAIN_MICHAEL", //6531A692", //1697752722", //1697752722
            "WAVELOAD_PAIN_TREVOR" //0CF83E9F", //217595551", //217595551
        };
        private List<string> FVoices = new List<string>
        {
            "Default",
            "ABIGAIL", //073DD899", //121493657", //121493657
            "AIRPORT_PA_FEMALE", //80D0944F", //2161153103", //"2133814193
            "AMANDA_DRUNK", //5C0B144D", //1544229965", //1544229965
            "AMANDA_NORMAL", //EC6C9072", //3966537842", //"328429454
            "CHASTITY", //9B4468A9", //2604951721", //"1690015575
            "CHASTITY_MP", //4E0041AA", //1308639658", //1308639658
            "CST4ACTRESS", //6A8C4C84", //1787579524", //1787579524
            "DARYL", //10088962", //268994914", //268994914
            "DENISE", //860AA79A", //2248845210", //"2046122086
            "EXECPA_FEMALE", //B6FB2A37", //3069913655", //"1225053641
            "GIRL1", //9ABA4CB8", //2595900600", //"1699066696
            "GIRL2", //C38C1E5B", //3280739931", //"1014227365
            "GRIFF", //03DD4948", //64833864", //64833864
            "FUFU", //ED8EA575", //3985548661", //"309418635
            "FUFU_MP", //4EA343CA", //1319322570", //1319322570
            "JANE", //893E74D0", //2302571728", //"1992395568
            "JANET", //8498F40B", //2224616459", //"2070350837
            "JULIET", //27AD5D38", //665673016", //665673016
            "KAREN", //FBF9CDB2", //4227452338", //"67514958
            "KIDNAPPEDFEMALE", //064DC6E9", //105760489", //105760489
            "LACEY", //29CAB776", //701151094", //701151094
            "LI_FEMALE_01", //E58E5187", //3851309447", //"443657849
            "LOSTKIDNAPGIRL", //7D8F4F88", //2106544008", //2106544008
            "MAID", //015EE6C7", //22996679", //22996679
            "MARNIE", //5FA82CAC", //1604857004", //1604857004
            "MARYANN", //9FEEF145", //2683236677", //"1611730619
            "MAUDE", //1AE32960", //451094880", //451094880
            "MRSTHORNHILL", //C6DE44C8", //3336455368", //"958511928
            "NIKKI", //47F4D564", //1207227748", //1207227748
            "NIKKI_MP", //11515E1F", //290545183", //290545183
            "PAIGE", //C2515320", //3260109600", //"1034857696
            "PAMELA_DRAKE", //714E62B7", //1900962487", //1900962487
            "PATRICIA", //D22B34C3", //3526046915", //"768920381
            "PEACH", //FE7FCDEA", //4269788650", //"25178646
            "PIER_ANNOUNCE_FEMALE", //3AB5E64D", //984999501", //984999501
            "REHH5BRIDE", //923B42A5", //2453357221", //"1841610075
            "REHOMGIRL", //745E2A7D", //1952328317", //1952328317
            "REPRI1LOST", //4E9991FE", //1318687230", //1318687230
            "SAPPHIRE", //74F8F352", //1962472274", //1962472274
            "TALINA", //ED031790", //3976402832", //"318564464
            "TAXIGANGGIRL1", //E2228087", //3793911943", //"501055353
            "TAXIGANGGIRL2", //F7E3AC09", //4158893065", //"136074231
            "TAXIKEYLA", //23ACB127", //598520103", //598520103
            "TAXILIZ", //C8B6AC99", //3367414937", //"927552359
            "TAXIMIRANDA", //97A199A8", //2543950248", //"1751017048
            "TONYA", //FCB43161", //4239667553", //"55299743
            "TRACEY", //5A7D2459", //1518150745", //1518150745
            "VB_FEMALE_01", //CB2136C8", //3407951560", //"887015736
            "VB_FEMALE_02", //E4EA6A5A", //3840567898", //"454399398
            "VB_FEMALE_03", //B1510330", //2974876464", //"1320090832
            "VB_FEMALE_04", //C397A7BD", //3281495997", //"1013471299
            "WAVELOAD_PAIN_FEMALE", //332128AB", //857811115", //857811115
            "WFSTEWARDESS", //84EDE1BF", //2230182335", //"2064784961
            "HS4_KAYLEE_PVG",
            "HS4_JACKIE_PVG",
            "FEMALE_CLUB_R2PVG",
            "BTL_CONNIE_PVG",
            "AFFLUENT_SUBURBAN_FEMALE_01", //FF4D4698", //4283254424", //"11712872
            "AFFLUENT_SUBURBAN_FEMALE_02", //12836D04", //310603012", //310603012
            "AFFLUENT_SUBURBAN_FEMALE_03", //DC6000BE", //3697279166", //"597688130
            "AFFLUENT_SUBURBAN_FEMALE_04", //EE1AA433", //3994723379", //"300243917
            "AFFLUENT_SUBURBAN_FEMALE_05", //A47190DE", //2758906078", //"1536061218
            "AFFLUENT_SUBURBAN_FEMALE_06", //B62C3453", //3056350291", //"1238617005
            "AIRCRAFT_WARNING_FEMALE_01", //85A08F9C", //2241892252", //"2053075044
            "A_F_M_BEACH_01_WHITE_FULL_01", //6B996380", //1805214592", //1805214592
            "A_F_M_BEACH_01_WHITE_MINI_01", //139EA948", //329165128", //329165128
            "A_F_M_BEVHILLS_01_WHITE_FULL_01", //00A8641D", //11035677", //11035677
            "A_F_M_BEVHILLS_01_WHITE_MINI_01", //3E0995AE", //1040815534", //1040815534
            "A_F_M_BEVHILLS_01_WHITE_MINI_02", //4ABAAF10", //1253748496", //1253748496
            "A_F_M_BEVHILLS_02_BLACK_FULL_01", //8455F5F0", //2220226032", //"2074741264
            "A_F_M_BEVHILLS_02_BLACK_MINI_01", //466B8D2A", //1181453610", //1181453610
            "A_F_M_BEVHILLS_02_WHITE_FULL_01", //B228C501", //2989016321", //"1305950975
            "A_F_M_BEVHILLS_02_WHITE_FULL_02", //CC76F99D", //3430349213", //"864618083
            "A_F_M_BEVHILLS_02_WHITE_MINI_01", //3FD63057", //1071001687", //1071001687
            "A_F_M_BODYBUILD_01_BLACK_FULL_01", //4B0E89BF", //1259243967", //1259243967
            "A_F_M_BODYBUILD_01_BLACK_MINI_01", //23D791B0", //601330096", //601330096
            "A_F_M_BODYBUILD_01_WHITE_FULL_01", //8773ADD6", //2272505302", //"2022461994
            "A_F_M_BODYBUILD_01_WHITE_MINI_01", //B902AA3A", //3103959610", //"1191007686
            "A_F_M_BUSINESS_02_WHITE_MINI_01", //9C4AD53A", //2622149946", //"1672817350
            "A_F_M_DOWNTOWN_01_BLACK_FULL_01", //0AA25C8F", //178412687", //178412687
            "A_F_M_EASTSA_01_LATINO_FULL_01", //0ACC23F9", //181150713", //181150713
            "A_F_M_EASTSA_01_LATINO_MINI_01", //CE348715", //3459548949", //"835418347
            "A_F_M_EASTSA_02_LATINO_FULL_01", //0AA30167", //178454887", //178454887
            "A_F_M_EASTSA_02_LATINO_MINI_01", //721CC9FF", //1914489343", //1914489343
            "A_F_M_FATWHITE_01_WHITE_FULL_01", //D2158D79", //3524627833", //"770339463
            "A_F_M_FATWHITE_01_WHITE_MINI_01", //59E595EB", //1508218347", //1508218347
            "A_F_M_KTOWN_01_KOREAN_FULL_01", //D77777E6", //3614930918", //"680036378
            "A_F_M_KTOWN_01_KOREAN_MINI_01", //AF6FB9B1", //2943334833", //"1351632463
            "A_F_M_KTOWN_02_CHINESE_MINI_01", //C533C983", //3308505475", //"986461821
            "A_F_M_KTOWN_02_KOREAN_FULL_01", //D8CD3773", //3637327731", //"657639565
            "A_F_M_SALTON_01_WHITE_FULL_01", //89DA8A2E", //2312800814", //"1982166482
            "A_F_M_SALTON_01_WHITE_FULL_02", //9C052E83", //2617585283", //"1677382013
            "A_F_M_SALTON_01_WHITE_FULL_03", //A66E4355", //2792244053", //"1502723243
            "A_F_M_SALTON_01_WHITE_MINI_01", //8701705E", //2265018462", //"2029948834
            "A_F_M_SALTON_01_WHITE_MINI_02", //7DC35DE2", //2109955554", //2109955554
            "A_F_M_SALTON_01_WHITE_MINI_03", //6675AF47", //1718988615", //1718988615
            "A_F_M_SKIDROW_01_BLACK_FULL_01", //A7C0DE51", //2814434897", //"1480532399
            "A_F_M_SKIDROW_01_BLACK_MINI_01", //443E6FBE", //1144942526", //1144942526
            "A_F_M_SKIDROW_01_WHITE_FULL_01", //F8F30014", //4176674836", //"118292460
            "A_F_M_SKIDROW_01_WHITE_MINI_01", //705684C4", //1884718276", //1884718276
            "A_F_M_SOUCENT_01_BLACK_FULL_01", //4E0DA806", //1309517830", //1309517830
            "A_F_M_SOUCENT_02_BLACK_FULL_01", //C725E5CC", //3341149644", //"953817652
            "A_F_M_TOURIST_01_WHITE_MINI_01", //25365382", //624317314", //624317314
            "A_F_M_TRAMPBEAC_01_BLACK_FULL_01", //F091AF03", //4036079363", //"258887933
            "A_F_M_TRAMPBEAC_01_BLACK_MINI_01", //DE24211D", //3726909725", //"568057571
            "A_F_M_TRAMPBEAC_01_WHITE_FULL_01", //8D34DFCC", //2369052620", //"1925914676
            "A_F_M_TRAMP_01_WHITE_FULL_01", //D05841FA", //3495444986", //"799522310
            "A_F_M_TRAMP_01_WHITE_MINI_01", //55CE3CCC", //1439579340", //1439579340
            "A_F_O_GENSTREET_01_WHITE_MINI_01", //482D1EC8", //1210916552", //1210916552
            "A_F_O_INDIAN_01_INDIAN_MINI_01", //8755E8CA", //2270554314", //"2024412982
            "A_F_O_KTOWN_01_KOREAN_FULL_01", //DBE7871F", //3689383711", //"605583585
            "A_F_O_KTOWN_01_KOREAN_MINI_01", //F94EAEEB", //4182683371", //"112283925
            "A_F_O_SALTON_01_WHITE_FULL_01", //F79EEC05", //4154387461", //"140579835
            "A_F_O_SALTON_01_WHITE_MINI_01", //FCBC6F1F", //4240207647", //"54759649
            "A_F_O_SOUCENT_01_BLACK_FULL_01", //3439D3C2", //876204994", //876204994
            "A_F_O_SOUCENT_02_BLACK_FULL_01", //F27CEF94", //4068274068", //"226693228
            "A_F_Y_BEACH_01_BLACK_MINI_01", //4B79AF9D", //1266266013", //1266266013
            "A_F_Y_BEACH_01_WHITE_FULL_01", //2BCAB282", //734704258", //734704258
            "A_F_Y_BEACH_01_WHITE_MINI_01", //13609A3C", //325098044", //325098044
            "A_F_Y_BEACH_BLACK_FULL_01", //0422CC2C", //69389356", //69389356
            "A_F_Y_BEVHILLS_01_WHITE_FULL_01", //E7099D21", //3876166945", //"418800351
            "A_F_Y_BEVHILLS_01_WHITE_MINI_01", //D2C133B9", //3535877049", //"759090247
            "A_F_Y_BEVHILLS_02_WHITE_FULL_01", //F700AB54", //4144016212", //"150951084
            "A_F_Y_BEVHILLS_02_WHITE_MINI_01", //AA4B2212", //2857050642", //"1437916654
            "A_F_Y_BEVHILLS_02_WHITE_MINI_02", //7E1BC9B0", //2115750320", //2115750320
            "A_F_Y_BEVHILLS_03_WHITE_FULL_01", //8558FF3F", //2237202239", //"2057765057
            "A_F_Y_BEVHILLS_03_WHITE_MINI_01", //D17E6765", //3514722149", //"780245147
            "A_F_Y_BEVHILLS_04_WHITE_FULL_01", //B91127EB", //3104909291", //"1190058005
            "A_F_Y_BEVHILLS_04_WHITE_MINI_01", //9A251230", //2586120752", //"1708846544
            "A_F_Y_BUSINESS_01_WHITE_FULL_01", //A3D0C7CD", //2748368845", //"1546598451
            "A_F_Y_BUSINESS_01_WHITE_MINI_01", //87816F13", //2273406739", //"2021560557
            "A_F_Y_BUSINESS_01_WHITE_MINI_02", //188B9125", //411799845", //411799845
            "A_F_Y_BUSINESS_02_WHITE_FULL_01", //4CC300E2", //1287848162", //1287848162
            "A_F_Y_BUSINESS_02_WHITE_MINI_01", //94B7537B", //2495042427", //"1799924869
            "A_F_Y_BUSINESS_03_CHINESE_FULL_01", //7D9DD020", //2107494432", //2107494432
            "A_F_Y_BUSINESS_03_CHINESE_MINI_01", //D41AE44A", //3558532170", //"736435126
            "A_F_Y_BUSINESS_03_LATINO_FULL_01", //420377DE", //1107523550", //1107523550
            "A_F_Y_BUSINESS_04_BLACK_FULL_01", //26D1F656", //651294294", //651294294
            "A_F_Y_BUSINESS_04_BLACK_MINI_01", //97D8B312", //2547561234", //"1747406062
            "A_F_Y_BUSINESS_04_WHITE_MINI_01", //BE6FAE2C", //3194990124", //"1099977172
            "A_F_Y_EASTSA_01_LATINO_FULL_01", //3CB71B34", //1018633012", //1018633012
            "A_F_Y_EASTSA_01_LATINO_MINI_01", //D3A7F87F", //3551000703", //"743966593
            "A_F_Y_EASTSA_02_WHITE_FULL_01", //3DDC0236", //1037828662", //1037828662
            "A_F_Y_EASTSA_03_LATINO_FULL_01", //C801D0E0", //3355562208", //"939405088
            "A_F_Y_EASTSA_03_LATINO_MINI_01", //38E9E4FC", //954852604", //954852604
            "A_F_Y_EPSILON_01_WHITE_MINI_01", //1B66BF81", //459718529", //459718529
            "A_F_Y_FITNESS_01_WHITE_FULL_01", //7639B49D", //1983493277", //1983493277
            "A_F_Y_FITNESS_01_WHITE_MINI_01", //E2D732E6", //3805754086", //"489213210
            "A_F_Y_FITNESS_02_BLACK_FULL_01", //851B5376", //2233160566", //"2061806730
            "A_F_Y_FITNESS_02_BLACK_MINI_01", //27C40170", //667156848", //667156848
            "A_F_Y_FITNESS_02_WHITE_FULL_01", //BF9CB8C8", //3214719176", //"1080248120
            "A_F_Y_FITNESS_02_WHITE_MINI_01", //A105E3A0", //2701517728", //"1593449568
            "A_F_Y_Golfer_01_WHITE_FULL_01", //B81316C5", //3088258757", //"1206708539
            "A_F_Y_Golfer_01_WHITE_MINI_01", //5F5BFB44", //1599863620", //1599863620
            "A_F_Y_HIKER_01_WHITE_FULL_01", //BB0A674E", //3138021198", //"1156946098
            "A_F_Y_HIKER_01_WHITE_MINI_01", //C8CAFB5E", //3368745822", //"926221474
            "A_F_Y_HIPSTER_01_WHITE_FULL_01", //A24D58EA", //2722978026", //"1571989270
            "A_F_Y_HIPSTER_01_WHITE_MINI_01", //92D2202A", //2463244330", //"1831722966
            "A_F_Y_HIPSTER_02_WHITE_FULL_01", //83EA9D79", //2213191033", //"2081776263
            "A_F_Y_HIPSTER_02_WHITE_MINI_01", //41543F56", //1096040278", //1096040278
            "A_F_Y_HIPSTER_02_WHITE_MINI_02", //2F6F9B8D", //795843469", //795843469
            "A_F_Y_HIPSTER_03_WHITE_FULL_01", //ADED3C9F", //2918005919", //"1376961377
            "A_F_Y_HIPSTER_03_WHITE_MINI_01", //F824C1C7", //4163158471", //"131808825
            "A_F_Y_HIPSTER_03_WHITE_MINI_02", //E95A2432", //3914998834", //"379968462
            "A_F_Y_HIPSTER_04_WHITE_FULL_01", //3141C876", //826394742", //826394742
            "A_F_Y_HIPSTER_04_WHITE_MINI_01", //6B08FBA6", //1795750822", //1795750822
            "A_F_Y_HIPSTER_04_WHITE_MINI_02", //3BDF1D53", //1004477779", //1004477779
            "A_F_Y_INDIAN_01_INDIAN_MINI_01", //AD0551E1", //2902807009", //"1392160287
            "A_F_Y_INDIAN_01_INDIAN_MINI_02", //BF49F66A", //3209295466", //"1085671830
            "A_F_Y_ROLLERCOASTER_01_MINI_01", //5470D900", //1416681728", //1416681728
            "A_F_Y_ROLLERCOASTER_01_MINI_02", //4295B54A", //1117107530", //1117107530
            "A_F_Y_ROLLERCOASTER_01_MINI_03", //C2393483", //3258528899", //"1036438397
            "A_F_Y_ROLLERCOASTER_01_MINI_04", //B015903C", //2954203196", //"1340764100
            "A_F_Y_SKATER_01_WHITE_FULL_01", //52D929F1", //1389963761", //1389963761
            "A_F_Y_SKATER_01_WHITE_MINI_01", //6E55B81F", //1851111455", //1851111455
            "A_F_Y_SOUCENT_01_BLACK_FULL_01", //A0FDDA5B", //2700991067", //"1593976229
            "A_F_Y_SOUCENT_02_BLACK_FULL_01", //DB96A76C", //3684083564", //"610883732
            "A_F_Y_SOUCENT_03_LATINO_FULL_01", //AA71DF24", //2859589412", //"1435377884
            "A_F_Y_SOUCENT_03_LATINO_MINI_01", //656710BE", //1701253310", //1701253310
            "A_F_Y_TENNIS_01_BLACK_MINI_01", //B602DF7D", //3053641597", //"1241325699
            "A_F_Y_TENNIS_01_WHITE_MINI_01", //434E2C2C", //1129196588", //1129196588
            "A_F_Y_TOURIST_01_BLACK_FULL_01", //ECA3EB4D", //3970165581", //"324801715
            "A_F_Y_TOURIST_01_BLACK_MINI_01", //A3713FCD", //2742108109", //"1552859187
            "A_F_Y_TOURIST_01_LATINO_FULL_01", //D6F2B12F", //3606229295", //"688738001
            "A_F_Y_TOURIST_01_LATINO_MINI_01", //122F5483", //305091715", //305091715
            "A_F_Y_TOURIST_01_WHITE_FULL_01", //DBEFEC5C", //3689933916", //"605033380
            "A_F_Y_TOURIST_01_WHITE_MINI_01", //216BE906", //560720134", //560720134
            "A_F_Y_TOURIST_02_WHITE_MINI_01", //0D6F398A", //225393034", //225393034
            "A_F_Y_VINEWOOD_01_WHITE_FULL_01", //2AF2EF5B", //720564059", //720564059
            "A_F_Y_VINEWOOD_01_WHITE_MINI_01", //23A74DCA", //598166986", //598166986
            "A_F_Y_VINEWOOD_02_WHITE_FULL_01", //3A311C01", //976296961", //976296961
            "A_F_Y_VINEWOOD_02_WHITE_MINI_01", //191A5AF2", //421157618", //421157618
            "A_F_Y_Vinewood_03_Chinese_FULL_01", //E632B0F0", //3862081776", //"432885520
            "A_F_Y_VINEWOOD_03_CHINESE_MINI_01", //3512D951", //890427729", //890427729
            "A_F_Y_VINEWOOD_04_WHITE_FULL_01", //20C68AC8", //549882568", //549882568
            "A_F_Y_VINEWOOD_04_WHITE_MINI_01", //12763C39", //309738553", //309738553
            "A_F_Y_VINEWOOD_04_WHITE_MINI_02", //C8CB28E4", //3368757476", //"926209820
            "G_F_Y_BALLAS_01_BLACK_MINI_01", //15BB1C9C", //364584092", //364584092
            "G_F_Y_BALLAS_01_BLACK_MINI_02", //17F72114", //402071828", //402071828
            "G_F_Y_BALLAS_01_BLACK_MINI_03", //1D7F2C2C", //494873644", //494873644
            "G_F_Y_BALLAS_01_BLACK_MINI_04", //403F71AC", //1077899692", //1077899692
            "G_F_Y_FAMILIES_01_BLACK_MINI_01", //4D341506", //1295258886", //1295258886
            "G_F_Y_FAMILIES_01_BLACK_MINI_02", //69F34E84", //1777553028", //1777553028
            "G_F_Y_FAMILIES_01_BLACK_MINI_03", //B0B85C0D", //2964872205", //"1330095091
            "G_F_Y_FAMILIES_01_BLACK_MINI_04", //5B7DB199", //1534964121", //1534964121
            "G_F_Y_FAMILIES_01_BLACK_MINI_05", //85658568", //2238023016", //"2056944280
            "G_F_Y_FAMILIES_01_BLACK_MINI_06", //BFA0F9DE", //3214997982", //"1079969314
            "G_F_Y_VAGOS_01_LATINO_MINI_01", //0320E887", //52488327", //52488327
            "G_F_Y_VAGOS_01_LATINO_MINI_02", //D6930F6C", //3599961964", //"695005332
            "G_F_Y_VAGOS_01_LATINO_MINI_03", //7E0BDE5F", //2114707039", //2114707039
            "G_F_Y_VAGOS_01_LATINO_MINI_04", //8854F2F1", //2287268593", //"2007698703
            "NIGHT_OUT_FEMALE_01", //33A0908D", //866160781", //866160781
            "NIGHT_OUT_FEMALE_02", //49EBBD23", //1240186147", //1240186147
            "NIGHT_OUT_FEMALE_03", //831EAF88", //2199826312", //"2095140984
            "NIGHT_OUT_FEMALE_04", //A56CF424", //2775381028", //"1519586268
            "PAIN_FEMALE_01", //40F0B1B8", //1089515960", //1089515960
            "PAIN_FEMALE_02", //D828602D", //3626524717", //"668442579
            "PAIN_FEMALE_NORMAL_01", //6EF36D3C", //1861446972", //1861446972
            "PAIN_FEMALE_NORMAL_02", //5CECC92F", //1559021871", //1559021871
            "PAIN_FEMALE_NORMAL_03", //8AA3249B", //2325947547", //"1969019749
            "PAIN_FEMALE_NORMAL_04", //78878064", //2022146148", //2022146148
            "PAIN_FEMALE_NORMAL_05", //2629DBA6", //640277414", //640277414
            "PAIN_FEMALE_NORMAL_06", //0BF1A736", //200386358", //200386358
            "PAIN_FEMALE_NORMAL_07", //41699229", //1097437737", //1097437737
            "PAIN_FEMALE_NORMAL_08", //374E7DEF", //927890927", //927890927
            "PAIN_FEMALE_NORMAL_09", //DCDE4910", //3705555216", //"589412080
            "PAIN_FEMALE_NORMAL_10", //966B3B23", //2523609891", //"1771357405
            "PAIN_FEMALE_NORMAL_11", //343976BD", //876181181", //876181181
            "PAIN_FEMALE_NORMAL_12", //21EAD220", //569037344", //569037344
            "PAIN_FEMALE_TEST_01", //95928372", //2509407090", //"1785560206
            "PAIN_FEMALE_TEST_02", //AAE0AE0E", //2866851342", //"1428115954
            "PAIN_FEMALE_TEST_03", //B89E4989", //3097381257", //"1197586039
            "S_F_M_FEMBARBER_BLACK_MINI_01", //4B82A928", //1266854184", //1266854184
            "S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_01", //E085EF87", //3766873991", //"528093305
            "S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_02", //EA440303", //3930325763", //"364641533
            "S_F_M_GENERICCHEAPWORKER_01_LATINO_MINI_03", //51565112", //1364611346", //1364611346
            "S_F_M_PONSEN_01_BLACK_01", //B60A191B", //3054115099", //"1240852197
            "S_F_M_SHOP_HIGH_WHITE_MINI_01", //AD7E25AA", //2910725546", //"1384241750
            "S_F_Y_AIRHOSTESS_01_BLACK_FULL_01", //50B140C7", //1353793735", //1353793735
            "S_F_Y_AIRHOSTESS_01_BLACK_FULL_02", //D0FFC16E", //3506422126", //"788545170
            "S_F_Y_AIRHOSTESS_01_WHITE_FULL_01", //090B4CD4", //151735508", //151735508
            "S_F_Y_AIRHOSTESS_01_WHITE_FULL_02", //E1B67E2B", //3786833451", //"508133845
            "S_F_Y_BAYWATCH_01_BLACK_FULL_01", //F33860E9", //4080558313", //"214408983
            "S_F_Y_BAYWATCH_01_BLACK_FULL_02", //880F0A98", //2282687128", //"2012280168
            "S_F_Y_BAYWATCH_01_WHITE_FULL_01", //26DECE02", //652135938", //652135938
            "S_F_Y_BAYWATCH_01_WHITE_FULL_02", //35226A89", //891447945", //891447945
            "S_F_Y_Cop_01_BLACK_FULL_01", //EFB0FA91", //4021353105", //"273614191
            "S_F_Y_COP_01_BLACK_FULL_02", //62A6E07B", //1655103611", //1655103611
            "S_F_Y_COP_01_WHITE_FULL_01", //EB73C44F", //3950232655", //"344734641
            "S_F_Y_COP_01_WHITE_FULL_02", //F9C560F2", //4190462194", //"104505102
            "S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_01", //44ACE464", //1152181348", //1152181348
            "S_F_Y_GENERICCHEAPWORKER_01_BLACK_MINI_02", //3707C91A", //923257114", //923257114
            "S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_01", //A135DE73", //2704662131", //"1590305165
            "S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_02", //CF08BA18", //3473455640", //"821511656
            "S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_03", //BC269454", //3156644948", //"1138322348
            "S_F_Y_GENERICCHEAPWORKER_01_LATINO_MINI_04", //EB8E7323", //3951981347", //"342985949
            "S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_01", //E5EAA67A", //3857360506", //"437606790
            "S_F_Y_GENERICCHEAPWORKER_01_WHITE_MINI_02", //39B64E08", //968248840", //968248840
            "S_F_Y_HOOKER_01_WHITE_FULL_01", //18B73C7E", //414661758", //414661758
            "S_F_Y_HOOKER_01_WHITE_FULL_02", //66F658FB", //1727420667", //1727420667
            "S_F_Y_HOOKER_01_WHITE_FULL_03", //75E576D9", //1977972441", //1977972441
            "S_F_Y_HOOKER_02_WHITE_FULL_01", //77BE674B", //2008966987", //2008966987
            "S_F_Y_HOOKER_02_WHITE_FULL_02", //09978AFF", //160926463", //160926463
            "S_F_Y_HOOKER_02_WHITE_FULL_03", //1B382E40", //456666688", //456666688
            "S_F_Y_HOOKER_03_BLACK_FULL_01", //875814D6", //2270696662", //"2024270634
            "S_F_Y_HOOKER_03_BLACK_FULL_03", //129DAB5F", //312322911", //312322911
            "S_F_Y_PECKER_01_WHITE_01", //6B019062", //1795264610", //1795264610
            "S_F_Y_RANGER_01_WHITE_MINI_01", //47A85382", //1202213762", //1202213762
            "S_F_Y_SHOP_LOW_WHITE_MINI_01", //ED77E493", //3984057491", //"310909805
            "S_F_Y_SHOP_MID_WHITE_MINI_01" //77B47F14", //2008317716", //2008317716
        };
        //Voice list was taken from https://pastebin.com/vDWd8RYx

        public RSMain()
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
                    DataStore.TombStone = AddTombStone();
                    LoggerLight.SendRequest("Tomb_" + DataStore.TombStone.Handle, DataStore.sSaveArts, true);
                    bIsReady = false;
                    RsActions.StartTheMod(0, true);
                }
            }
            else if (DataStore.bMenuOpen)
            {
                if (MyMenuPool.IsAnyMenuOpen())
                    MyMenuPool.ProcessMenus();
                else
                {
                    DataStore.bMenuOpen = false;
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
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
                        RsActions.TopCornerUI(DataStore.RsTranslate[92]);
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
                else if (DataStore.MySettingsXML.ControlSupport)
                {
                    if (RsReturns.ButtonDown(DataStore.MySettingsXML.ControlA, false))
                    {
                        if (RsReturns.ButtonDown(DataStore.MySettingsXML.ControlB, false))
                        {
                            PedMenuMain();
                            DataStore.bMenuOpen = true;
                        }
                    }
                }

                if (DataStore.MySettingsXML.DisableRecord)
                {
                    if (Function.Call<bool>(Hash._IS_RECORDING))
                        Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                }

                if (iSlowDown < Game.GameTime)
                {
                    iSlowDown = Game.GameTime + 2000;
                    if (DataStore.bDontStopMe)
                        RsActions.InRestrictedArea();
                    else if (DataStore.bOpenDoors)
                        RsActions.OpeningDoors(DataStore.PeskyDoors[0], DataStore.PeskyDoors[1], DataStore.PeskyDoors[2]);
                    else if (DataStore.PeddyList.Count > 0)
                        PedDisables();
                }

            }
        }
        private void PedDisables()
        {
            Vector3 Me = Game.Player.Character.Position;
            for (int i = 0; i < DataStore.PeddyList.Count; i++)
            {
                if (DataStore.PeddyList[i].Position.DistanceTo(Me) > 100f)
                {
                    RsActions.RemoveThis(DataStore.PeddyList[i]);
                    DataStore.PeddyList.RemoveAt(i);
                }
            }
        }
        private void KeyPlunk(object sender, KeyEventArgs e)
        {
            if (DataStore.bStart)
            {
                if (DataStore.bKeyFinder)
                {
                    DataStore.MySettingsXML.MenuKey = e.KeyCode;
                    UI.ShowSubtitle("~r~" + DataStore.MySettingsXML.MenuKey + "' ~w~" + DataStore.RsTranslate[90]);
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                    DataStore.bKeyFinder = false;
                }
                else if (e.KeyCode == DataStore.MySettingsXML.MenuKey)
                {
                    Game.FadeScreenIn(1);
                    if (DataStore.bAllowControl)
                        UI.Notify(DataStore.RsTranslate[89]);
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
            var mainMenu = new UIMenu(DataStore.RsTranslate[6], "");
            MyMenuPool.Add(mainMenu);
            RanPedMenu(mainMenu);
            SetLocate(mainMenu);
            SetChar(mainMenu);
            SetLoadWeps(mainMenu);
            SetMenuKey(mainMenu);
            SetControlKey(mainMenu);
            SelectSaved(mainMenu);
            PedPosses(mainMenu);
            InstantReincarnate(mainMenu);
            DisRecord(mainMenu);
            AddBeachParty(mainMenu);
            SeatBeltON(mainMenu);
            MinMap(mainMenu);
            Re_WriteLoadout(mainMenu);
            MyMenuPool.RefreshIndex();
            DataStore.bMenuOpen = true;
            mainMenu.Visible = true;
        }
        private List<dynamic> CompileMenuTotals(int iTotal, int iBZero)
        {
            LoggerLight.Loggers("CompileMenuTotals iTotal == " + iTotal + ", iBZero == " + iBZero);

            List<dynamic> dList = new List<dynamic>();
            if (iTotal == iBZero)
                iTotal++;

            while (iBZero < iTotal)
            {
                dList.Add(iBZero);
                iBZero++;
            }

            return dList;
        }
        private List<dynamic> CompileMenuTotalsFloats(int iLow, int iTotal)
        {
            LoggerLight.Loggers("CompileMenuTotalsFloats");

            List<dynamic> dList = new List<dynamic>();
            if (iTotal == iLow)
                iTotal++;
            int iUpC = iLow;
            while (iUpC < iTotal)
            {
                if (iUpC < -9)
                {
                    dList.Add("-0." + iUpC * -1 + "");
                }
                else if (iUpC < 0)
                {
                    dList.Add("-0.0" + iUpC * -1 + "");
                }
                else if (iUpC < 10)
                    dList.Add("0.0" + iUpC + "");
                else
                    dList.Add("0." + iUpC + "");
                iUpC++;
            }
            return dList;
        }
        private List<dynamic> CompOutfits(List<ClothX> MyList)
        {
            List<dynamic> MyOuts = new List<dynamic>();

            for (int i = 0; i < MyList.Count; i++)
                MyOuts.Add(MyList[i].Title);

            return MyOuts;
        }
        private List<dynamic> HairyList(int iChar)
        {
            List<dynamic> Hairs = new List<dynamic>();

            if (iChar == 4)
            {
                for (int i = 0; i < FHairsets.Count; i++)
                    Hairs.Add(FHairsets[i].Name);
            }
            else if (iChar == 5)
            {
                for (int i = 0; i < MHairsets.Count; i++)
                    Hairs.Add(MHairsets[i].Name);
            }

            return Hairs;
        }
        private List<dynamic> VoiceList(bool male)
        {
            List<dynamic> Voice = new List<dynamic>();

            if (male)
            {
                for (int i = 0; i < MVoices.Count; i++)
                    Voice.Add(MVoices[i]);
            }
            else
            {
                for (int i = 0; i < FVoices.Count; i++)
                    Voice.Add(FVoices[i]);
            }
            return Voice;
        }
        private int FindAVoice(bool bMale, string sName)
        {
            int iPoint = 0;
            if (bMale)
            {
                for (int i = 0; i < MVoices.Count; i++)
                {
                    if (MVoices[i] == sName)
                        iPoint = i;
                }
            }
            else
            {
                for (int i = 0; i < FVoices.Count; i++)
                {
                    if (FVoices[i] == sName)
                        iPoint = i;
                }
            }

            return iPoint;
        }
        private void PedPosses(UIMenu XMen)
        {
            LoggerLight.Loggers("PedPosses");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[136], DataStore.RsTranslate[137]);
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
        private void SavePedMenu(int iPed)
        {
            LoggerLight.Loggers("SavePedMenu");

            MyMenuPool = new MenuPool();
            var playermodelmenu = new UIMenu(DataStore.RsTranslate[8], "");
            MyMenuPool.Add(playermodelmenu);

            bool bMale = false;

            SelectComps(playermodelmenu);

            SetComponents(playermodelmenu, iPed);
            SetPedProps(playermodelmenu);
            ResetPedProps(playermodelmenu);

            if (iPed == 1)
            {
                bMale = true;
                AddTatts(playermodelmenu, 1);
            }
            else if (iPed == 2)
            {
                bMale = true;
                AddTatts(playermodelmenu, 2);
            }
            else if (iPed == 3)
            {
                bMale = true;
                AddTatts(playermodelmenu, 3);
            }
            else if (iPed == 4)
            {
                Hairy(playermodelmenu, iPed);   //Head
                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 4);
                SetFaceFeatures(playermodelmenu);
            }
            else if (iPed == 5)
            {
                bMale = true;
                Hairy(playermodelmenu, iPed);   //Head
                SetHair01(playermodelmenu);
                SetHair02(playermodelmenu);
                SetHEyes(playermodelmenu);
                SetOverLays(playermodelmenu);
                AddTatts(playermodelmenu, 5);
                SetFaceFeatures(playermodelmenu);
            }
            else
            {
                if (Game.Player.Character.Gender == Gender.Male)
                    bMale = true;
            }

            SetHVoice(playermodelmenu, bMale);
            if (DataStore.iCurrentPed != 0)
                SaveMyPed(playermodelmenu);
            else
                CreateNewPed(playermodelmenu);

            if (DataStore.iCurrentPed != 0)
                DeleteCurrentPed(playermodelmenu);

            MyMenuPool.RefreshIndex();
            DataStore.bMenuOpen = true;
            playermodelmenu.Visible = true;
        }
        private void SelectComps(UIMenu XMen)
        {
            LoggerLight.Loggers("SelectComps");

            int iZero = DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt;

            var newitem = new UIMenuListItem(DataStore.RsTranslate[167], CompOutfits(DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing), 0);
            newitem.Description = DataStore.RsTranslate[157];
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt = newitem.Index;
                    RsActions.SavePedFinder(DataStore.iCurrentPed);
                }
            };
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].Title = Game.GetUserInput(255);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing.Add(new ClothX(Game.Player.Character));
                    DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt++;
                    DataStore.SaveChars(DataStore.MyPedCollection, DataStore.sSavedFile);
                    newitem.Items = CompOutfits(DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing);
                }
            };
        }
        private void SelectSaved(UIMenu XMen)
        {
            LoggerLight.Loggers("SelectSaved");

            var LoadInSavedmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[8]);

            ClothBank Cb = new ClothBank(Game.Player.Character);
            Cb.Name = "Current";

            if (!RsReturns.AreTheyTheSame(DataStore.MyPedCollection[0], Cb))
                DataStore.MyPedCollection[0] = Cb;

            DataStore.iCurrentPed = RsReturns.IsInTheList(DataStore.MyPedCollection[0]);

            List<dynamic> SavedPeds = new List<dynamic>();

            for (int i = 0; i < DataStore.MyPedCollection.Count; i++)
                SavedPeds.Add(DataStore.MyPedCollection[i].Name);

            var ThisShizle = new UIMenuListItem("", SavedPeds, 0);
            ThisShizle.Description = DataStore.RsTranslate[98];
            ThisShizle.Index = DataStore.iCurrentPed;
            LoadInSavedmenu.AddItem(ThisShizle);

            LoadInSavedmenu.OnListChange += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (index < DataStore.MyPedCollection.Count)
                    {
                        if (DataStore.MyPedCollection[index].FreeMode && DataStore.MyPedCollection[index].MyHair.Comp == 0)
                            DataStore.MyPedCollection[index].MyHair = GetYourHair(DataStore.MyPedCollection[index].Male, DataStore.MyPedCollection[index].Cothing[DataStore.MyPedCollection[index].CothInt].ClothA[2]);
                        RsActions.SavePedFinder(index);
                    }
                }
            };
            LoadInSavedmenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == ThisShizle)
                {
                    if (DataStore.iCurrentPed != 0)
                    {
                        int iSpot = -1;
                        for (int i = 0; i < DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing.Count; i++)
                        {
                            if (DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[i].Title == "Current" || DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[i].Title == "")
                            {
                                DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[i] = new ClothX(Game.Player.Character);
                                iSpot = i;
                            }
                        }

                        if (iSpot == -1)
                        {
                            DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing.Add(new ClothX(Game.Player.Character));
                            iSpot = DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing.Count -1;
                        }

                        DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt = iSpot;

                        if (DataStore.MyPedCollection[DataStore.iCurrentPed].FreeMode && DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Name == "")
                            DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair = GetYourHair(DataStore.MyPedCollection[DataStore.iCurrentPed].Male, DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[iSpot].ClothA[2]);
                    }
                    MyMenuPool.CloseAllMenus();
                    SavePedMenu(RsReturns.MyPedIs());
                }
            };
        }
        private HairSets GetYourHair(bool male, int iCut)
        {
            HairSets hairFlick = new HairSets();

            if (male)
            {
                for (int i = 0; i < MHairsets.Count; i++)
                {
                    if (iCut == MHairsets[i].Comp)
                        hairFlick = MHairsets[i];
                }
            }
            else
            {
                for (int i = 0; i < FHairsets.Count; i++)
                {
                    if (iCut == FHairsets[i].Comp)
                        hairFlick = FHairsets[i];
                }
            }
            return hairFlick;
        }
        private void SetHair01(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHair01");

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            var newitem = new UIMenuListItem(DataStore.RsTranslate[9], CompileMenuTotals(iCount, 0), 0);
            newitem.Description = DataStore.RsTranslate[161];
            newitem.Index = DataStore.MyPedCollection[DataStore.iCurrentPed].HairColour;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character.Handle, index, DataStore.MyPedCollection[DataStore.iCurrentPed].HairStreaks);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].HairColour = newitem.Index;
                }
            };
        }
        private void SetHair02(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHair02");

            int iCount = Function.Call<int>(Hash._GET_NUM_HAIR_COLORS);
            var newitem = new UIMenuListItem(DataStore.RsTranslate[10], CompileMenuTotals(iCount, 0), 0);
            newitem.Description = DataStore.RsTranslate[162];
            newitem.Index = DataStore.MyPedCollection[DataStore.iCurrentPed].HairStreaks;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_HAIR_COLOR, Game.Player.Character.Handle, DataStore.MyPedCollection[DataStore.iCurrentPed].HairColour, index);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].HairStreaks = newitem.Index;
                }
            };
        }
        private void SetHEyes(UIMenu XMen)
        {
            LoggerLight.Loggers("SetHEyes");

            int iCount = 32;
            var newitem = new UIMenuListItem(DataStore.RsTranslate[11], CompileMenuTotals(iCount, 0), 0);
            newitem.Description = DataStore.RsTranslate[163];
            newitem.Index = DataStore.MyPedCollection[DataStore.iCurrentPed].EyeColour;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash._SET_PED_EYE_COLOR, Game.Player.Character.Handle, index);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].EyeColour = newitem.Index;
                }
            };
        }
        private void SetHVoice(UIMenu XMen, bool bMale)
        {
            LoggerLight.Loggers("SetHVoice");

            var pmmVoice = new UIMenuListItem(DataStore.RsTranslate[169], VoiceList(bMale), 0);
            pmmVoice.Description = DataStore.RsTranslate[168];
            pmmVoice.Index = FindAVoice(bMale, DataStore.MyPedCollection[DataStore.iCurrentPed].PedVoice);
            XMen.AddItem(pmmVoice);

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == pmmVoice)
                {
                    if (pmmVoice.Index == 0)
                    {
                        DataStore.MyPedCollection[DataStore.iCurrentPed].PedVoice = "";

                        Function.Call((Hash)0x40CF0D12D142A9E8, Game.Player.Character.Handle);
                        Function.Call((Hash)0x4ADA3F19BE4A6047, Game.Player.Character.Handle);
                        UI.Notify("Voice Cleared");
                    }
                    else
                    {
                        DataStore.MyPedCollection[DataStore.iCurrentPed].PedVoice = Convert.ToString(pmmVoice.Items[pmmVoice.Index]);

                        Function.Call(Hash.SET_AMBIENT_VOICE_NAME, Game.Player.Character.Handle, DataStore.MyPedCollection[DataStore.iCurrentPed].PedVoice);
                        Function.Call((Hash)0x4ADA3F19BE4A6047, Game.Player.Character.Handle);
                        UI.Notify("Voice set to " + DataStore.MyPedCollection[DataStore.iCurrentPed].PedVoice);
                    }
                }
            };
        }
        private void SetOverLays(UIMenu XMen)
        {
            LoggerLight.Loggers("SetOverLays");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[12]);

            if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay.Count == 0)
                DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay = RsReturns.BuildOverlay(Game.Player.Character);

            SetOvers(playermodelmenu, 0, DataStore.RsTranslate[13], 23);
            SetOversColour(playermodelmenu, 1, DataStore.RsTranslate[14], 28);
            SetOversColour(playermodelmenu, 2, DataStore.RsTranslate[15], 33);
            SetOvers(playermodelmenu, 3, DataStore.RsTranslate[16], 14);
            SetOvers(playermodelmenu, 4, DataStore.RsTranslate[17], 74);
            SetOversColour(playermodelmenu, 5, DataStore.RsTranslate[18], 6);
            SetOvers(playermodelmenu, 6, DataStore.RsTranslate[19], 11);
            SetOvers(playermodelmenu, 7, DataStore.RsTranslate[20], 10);
            SetOversColour(playermodelmenu, 8, DataStore.RsTranslate[21], 9);
            SetOvers(playermodelmenu, 9, DataStore.RsTranslate[22], 17);
            SetOversColour(playermodelmenu, 10, DataStore.RsTranslate[23], 16);
            SetOvers(playermodelmenu, 11, DataStore.RsTranslate[24], 11);
        }
        private void SetOvers(UIMenu XMen, int OverLayId, string sName, int iCount)
        {
            LoggerLight.Loggers("SetOvers");

            string sOpacity = "" + sName + DataStore.RsTranslate[25];

            int iZero = DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].Overlay;
            if (iZero == 255)
                iZero = -1;
            var newitem = new UIMenuListItem(sName, CompileMenuTotals(iCount, -1), 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            iCount = 99;
            float fOvers = DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc;
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            var newitemOpac = new UIMenuListItem(sOpacity, CompileMenuTotalsFloats(0, iCount), 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = (int)Convert.ToInt32(newitem.Items[index]);
                    if (iDex == -1)
                        iDex = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, iDex, DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].Overlay = iDex;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character.Handle, OverLayId), fOpal);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc = fOpal;
                }
            };
        }
        private void SetOversColour(UIMenu XMen, int OverLayId, string sName, int iCount)
        {
            LoggerLight.Loggers("SetOversColour");

            string sOpacity = "" + sName + DataStore.RsTranslate[25];
            string sColour = "" + sName + DataStore.RsTranslate[26];

            int iZero = DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].Overlay;
            if (iZero == 255)
                iZero = -1;
            var newitem = new UIMenuListItem(sName, CompileMenuTotals(iCount, -1), 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            iCount = 64;
            var newitem2 = new UIMenuListItem(sColour, CompileMenuTotals(iCount, 0), 0);
            newitem2.Index = DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverCol;
            XMen.AddItem(newitem2);

            iCount = 99;
            float fOvers = DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc;
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers);
            var newitemOpac = new UIMenuListItem(sOpacity, CompileMenuTotalsFloats(0, iCount), 0);
            newitemOpac.Index = iAM;
            XMen.AddItem(newitemOpac);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = (int)Convert.ToInt32(newitem.Items[newitem.Index]);
                    if (iDex == -1)
                        iDex = 255;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, iDex, DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].Overlay = iDex;
                }
                else if (item == newitem2)
                {
                    Function.Call(Hash._SET_PED_HEAD_OVERLAY_COLOR, Game.Player.Character.Handle, OverLayId, 1, index, 0);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverCol = newitem2.Index;
                }
                else if (item == newitemOpac)
                {
                    float fOpal = (int)newitemOpac.Index;
                    fOpal = fOpal / 100;
                    Function.Call(Hash.SET_PED_HEAD_OVERLAY, Game.Player.Character.Handle, OverLayId, Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Game.Player.Character.Handle, OverLayId), fOpal);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyOverlay[OverLayId].OverOpc = fOpal;
                }
            };
        }
        private void SetComponents(UIMenu XMen, int iPed)
        {
            LoggerLight.Loggers("SetComponents");

            bool bIsFree = false;
            if (iPed == 4 || iPed == 5)
                bIsFree = true;
            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[27], DataStore.RsTranslate[158]);

            if (!RsReturns.GetMainChar())
            {
                int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, 1);
                if (iCount > 0)
                    Componets(playermodelmenu, 0, DataStore.RsTranslate[28], iCount);
            }
            int iText = 29;
            for (int i = 1; i < 12; i++)
            {
                if (i == 2 && bIsFree)
                {

                }
                else
                {
                    int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character, i);
                    if (iCount > 0)
                        Componets(playermodelmenu, i, DataStore.RsTranslate[iText], iCount);
                }
                iText++;
            }
            if (iPed == 4 || iPed == 5)
                AddTShirt(playermodelmenu, iPed);
        }
        private void Componets(UIMenu XMen, int CompId, string sName, int iCount)
        {
            LoggerLight.Loggers("Componets");

            string sText = "" + sName + DataStore.RsTranslate[40];


            int iZero = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character, CompId);
            var newitem = new UIMenuListItem(sName, CompileMenuTotals(iCount, -1), 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iZero);
            var newitem2 = new UIMenuListItem(sText, CompileMenuTotals(iTexTotal, 0), 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = (int)Convert.ToInt32(newitem.Items[newitem.Index]);
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex);
                    newitem2.Items = CompileMenuTotals(iTexTotal, 0);
                    newitem2.Index = 0;
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iDex, 0, 2);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    int iDex = newitem2.Index;
                    int iAmComp = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iAmComp, iDex, 2);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothB[CompId] = iDex;
                }
            };
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    newitem.Index = 0;
                    int iDex = (int)Convert.ToInt32(newitem.Items[newitem.Index]);
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex);
                    newitem2.Items = CompileMenuTotals(iTexTotal, 0);
                    newitem2.Index = 0;
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iDex, 0, 2);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    newitem2.Index = 0;
                    int iDex = index;
                    int iAmComp = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, CompId, iAmComp, iDex, 2);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothB[CompId] = iDex;
                }
            };
        }
        private void SetPedProps(UIMenu XMen)
        {
            LoggerLight.Loggers("SetPedProps");

            var playermodelmenu2 = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[41], DataStore.RsTranslate[159]);

            int iText = 42;

            for (int i = 0; i < 5; i++)
            {
                int iCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, i);
                if (iCount > 0)
                    PedProps(playermodelmenu2, i, DataStore.RsTranslate[iText], iCount);
                iText++;
            }
        }
        private void PedProps(UIMenu XMen, int CompId, string sName, int iCount)
        {
            LoggerLight.Loggers("PedProps");

            string sText = "" + sName + DataStore.RsTranslate[40];

            int iZero = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId);
            var newitem = new UIMenuListItem(sName, CompileMenuTotals(iCount, -1), 0);
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            int iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iZero);
            var newitem2 = new UIMenuListItem(sText, CompileMenuTotals(iTexTotal, 0), 0);
            newitem2.Index = 0;
            XMen.AddItem(newitem2);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    int iDex = (int)Convert.ToInt32(newitem.Items[newitem.Index]);
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex);
                    newitem2.Items = CompileMenuTotals(iTexTotal, 0);
                    newitem2.Index = 0;
                    if (iDex == -1)
                        Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, CompId);
                    else
                        Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iDex, 0, false);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ExtraA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    int iDex = newitem2.Index;
                    int iAmComp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iAmComp, iDex, false);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ExtraB[CompId] = iDex;
                }
            };
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    newitem.Index = 0;
                    int iDex = (int)Convert.ToInt32(newitem.Items[index]);
                    iTexTotal = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_TEXTURE_VARIATIONS, Game.Player.Character.Handle, CompId, iDex);
                    newitem2.Items = CompileMenuTotals(iTexTotal, 0);
                    newitem2.Index = 0;
                    if (iDex == -1)
                        Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, CompId);
                    else
                        Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iDex, 0, false);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ExtraA[CompId] = iDex;
                }
                else if (item == newitem2)
                {
                    newitem2.Index = 0;
                    int iDex = index;
                    int iAmComp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId);
                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, CompId, iAmComp, iDex, false);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ExtraB[CompId] = iDex;
                }
            };
        }
        private void ResetPedProps(UIMenu XMen)
        {
            LoggerLight.Loggers("ResetPedProps");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[46], DataStore.RsTranslate[47]);
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
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[109], DataStore.RsTranslate[165]);

                Tatty(playermodelmenu, iChar, 1, DataStore.RsTranslate[100]);    //TORSO
                Tatty(playermodelmenu, iChar, 2, DataStore.RsTranslate[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 3, DataStore.RsTranslate[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 4, DataStore.RsTranslate[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 5, DataStore.RsTranslate[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 6, DataStore.RsTranslate[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
            else
            {
                var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[109], DataStore.RsTranslate[165]);

                Tatty(playermodelmenu, iChar, 1, DataStore.RsTranslate[99]);    //BACK
                Tatty(playermodelmenu, iChar, 2, DataStore.RsTranslate[110]);   //CHEST
                Tatty(playermodelmenu, iChar, 3, DataStore.RsTranslate[111]);   //STOMACH
                Tatty(playermodelmenu, iChar, 4, DataStore.RsTranslate[106]);   //HEAD
                Tatty(playermodelmenu, iChar, 5, DataStore.RsTranslate[103]);   //LEFT ARM
                Tatty(playermodelmenu, iChar, 6, DataStore.RsTranslate[102]);   //RIGHT ARM
                Tatty(playermodelmenu, iChar, 7, DataStore.RsTranslate[105]);   //LEFT LEG
                Tatty(playermodelmenu, iChar, 8, DataStore.RsTranslate[104]);   //RIGHT LEG

                ClearTats(playermodelmenu);
            }
        }
        private void Tatty(UIMenu XMen, int iChar, int iSkin, string sName)
        {
            LoggerLight.Loggers("Tatty");

            var pmmTats = MyMenuPool.AddSubMenu(XMen, sName);

            List<Tattoo> sub_01 = RsReturns.TattoosList(iChar, iSkin);

            if (sub_01[0].Name != "No Tattoos Available")
            {
                for (int i = 0; i < sub_01.Count; i++)
                {
                    var item_ = new UIMenuItem(sub_01[i].Name, "");
                    pmmTats.AddItem(item_);
                    if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Contains(sub_01[i]))
                        item_.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);

                }

                pmmTats.OnItemSelect += (sender, item, index) =>
                {
                    if (sender == pmmTats)
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);

                        if (!DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Contains(sub_01[index]))
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);
                            DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Add(sub_01[index]);
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sub_01[index].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, sub_01[index].TatName));
                        }
                        else
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.None);
                            int iAm = DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.IndexOf(sub_01[index]);
                            DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.RemoveAt(iAm);
                        }
                    }
                };
                pmmTats.OnMenuClose += (sender) =>
                {
                    if (sender == pmmTats)
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                        for (int i = 0; i < DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Count; i++)
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo[i].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo[i].TatName));
                    }
                };
            }
        }
        private void ClearTats(UIMenu XMen)
        {
            LoggerLight.Loggers("ClearTats");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[108], "");
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Clear();
                }
            };
        }
        private void AddTShirt(UIMenu XMen, int iChar)
        {
            LoggerLight.Loggers("AddTShirt");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[145]);

            Shirty(playermodelmenu, iChar, DataStore.RsTranslate[110]);   //CHEST
            ClearShirts(playermodelmenu);
        }
        private void Shirty(UIMenu XMen, int iChar, string sName)
        {
            LoggerLight.Loggers("Tatty");

            var playerShirty = MyMenuPool.AddSubMenu(XMen, sName);

            List<TShirt> sub_01 = RsReturns.ShirtyList(iChar);

            if (sub_01[0].Name != "No Shirt Tags Available")
            {
                for (int i = 0; i < sub_01.Count; i++)
                {
                    var item_ = new UIMenuItem(sub_01[i].Name, "");
                    playerShirty.AddItem(item_);
                    if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag == sub_01[i])
                        item_.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

                }

                playerShirty.OnItemSelect += (sender, item, index) =>
                {
                    if (sender == playerShirty)
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);

                        if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag != sub_01[index])
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Tatoo);
                            DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag = sub_01[index];
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, sub_01[index].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, sub_01[index].ShirtName));
                        }
                        else
                        {
                            item.SetRightBadge(UIMenuItem.BadgeStyle.None);
                            DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag = new TShirt();
                        }
                    }
                };
                playerShirty.OnMenuClose += (sender) =>
                {
                    if (sender == playerShirty)
                    {
                        Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                        if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag.BaseName != "")
                            Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag.BaseName), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag.ShirtName));
                    }
                };
            }
        }
        private void ClearShirts(UIMenu XMen)
        {
            LoggerLight.Loggers("ClearShirts");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[108] + "Tshirts", "");
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].MyTag = new TShirt();
                }
            };
        }
        private void Hairy(UIMenu XMen, int iChar)
        {
            LoggerLight.Loggers("Hairy");

            int iZero = GetHairStyles(DataStore.iCurrentPed);

            var newitem = new UIMenuListItem(DataStore.RsTranslate[107], HairyList(iChar), 0);
            newitem.Description = DataStore.RsTranslate[160];
            newitem.Index = iZero;
            XMen.AddItem(newitem);

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    Function.Call(Hash.CLEAR_PED_DECORATIONS, Game.Player.Character.Handle);

                    if (iChar == 4)
                        DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair = FHairsets[index];
                    else
                        DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair = MHairsets[index];

                    Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, 2, DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Comp, DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Text, 2);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothA[2] = DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Comp;
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Cothing[DataStore.MyPedCollection[DataStore.iCurrentPed].CothInt].ClothB[2] = DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Text;

                    if (DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.OverLib != -1)
                        Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.OverLib, DataStore.MyPedCollection[DataStore.iCurrentPed].MyHair.Over);

                    for (int i = 0; i < DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo.Count; i++)
                        Function.Call(Hash._SET_PED_DECORATION, Game.Player.Character.Handle, Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo[i].BaseName), Function.Call<int>(Hash.GET_HASH_KEY, DataStore.MyPedCollection[DataStore.iCurrentPed].MyTattoo[i].TatName));
                }
            };
        }
        private int GetHairStyles(int iPed)
        {
            int iH = 0;
            if (DataStore.MyPedCollection[iPed].Male)
            {
                for (int i = 0; i < MHairsets.Count; i++)
                {
                    if (DataStore.MyPedCollection[iPed].MyHair.Name == MHairsets[i].Name)
                        iH = i;
                }
            }
            else 
            {
                for (int i = 0; i < FHairsets.Count; i++)
                {
                    if (DataStore.MyPedCollection[iPed].MyHair.Name == FHairsets[i].Name)
                        iH = i;
                }
            }
            return iH;
        }
        private void SetFaceFeatures(UIMenu XMen)
        {
            LoggerLight.Loggers("SetFaceFeatures");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[134]);

            if (DataStore.MyPedCollection[DataStore.iCurrentPed].FaceScale.Count == 0)
            {
                for (int i = 0; i < 20; i++)
                    DataStore.MyPedCollection[DataStore.iCurrentPed].FaceScale.Add(0f);
            }

            FaceFeatures(playermodelmenu, 0, DataStore.RsTranslate[114]);
            FaceFeatures(playermodelmenu, 1, DataStore.RsTranslate[115]);
            FaceFeatures(playermodelmenu, 2, DataStore.RsTranslate[116]);
            FaceFeatures(playermodelmenu, 3, DataStore.RsTranslate[117]);
            FaceFeatures(playermodelmenu, 4, DataStore.RsTranslate[118]);
            FaceFeatures(playermodelmenu, 5, DataStore.RsTranslate[119]);
            FaceFeatures(playermodelmenu, 6, DataStore.RsTranslate[120]);
            FaceFeatures(playermodelmenu, 7, DataStore.RsTranslate[121]);
            FaceFeatures(playermodelmenu, 8, DataStore.RsTranslate[122]);
            FaceFeatures(playermodelmenu, 9, DataStore.RsTranslate[123]);
            FaceFeatures(playermodelmenu, 10, DataStore.RsTranslate[124]);
            FaceFeatures(playermodelmenu, 11, DataStore.RsTranslate[125]);
            FaceFeatures(playermodelmenu, 12, DataStore.RsTranslate[126]);
            FaceFeatures(playermodelmenu, 13, DataStore.RsTranslate[127]);
            FaceFeatures(playermodelmenu, 14, DataStore.RsTranslate[128]);
            FaceFeatures(playermodelmenu, 15, DataStore.RsTranslate[129]);
            FaceFeatures(playermodelmenu, 16, DataStore.RsTranslate[130]);
            FaceFeatures(playermodelmenu, 17, DataStore.RsTranslate[131]);
            FaceFeatures(playermodelmenu, 18, DataStore.RsTranslate[132]);
            FaceFeatures(playermodelmenu, 19, DataStore.RsTranslate[133]);
        }
        private void FaceFeatures(UIMenu XMen, int CompId, string sName)
        {
            LoggerLight.Loggers("FaceFeatures");

            float fOvers = DataStore.MyPedCollection[DataStore.iCurrentPed].FaceScale[CompId];
            fOvers = fOvers * 100;
            int iAM = (int)Math.Ceiling(fOvers) + 99;
            var newitem = new UIMenuListItem(sName, CompileMenuTotalsFloats(-99, 99), 99);
            newitem.Description = DataStore.RsTranslate[165];
            XMen.AddItem(newitem);
            newitem.Index = iAM;

            XMen.OnListChange += (sender, item, index) =>
            {
                if (item == newitem)
                {
                    float fOpal = (int)index - 99;
                    fOpal = (fOpal / 100);
                    Function.Call(Hash._SET_PED_FACE_FEATURE, Game.Player.Character.Handle, CompId, fOpal);
                    DataStore.MyPedCollection[DataStore.iCurrentPed].FaceScale[CompId] = fOpal;
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

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[48], DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
            playermodelmenu.Description = DataStore.RsTranslate[178];
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle("~g~" + DataStore.RsTranslate[50] + DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
                    DataStore.SaveChars(DataStore.MyPedCollection, DataStore.sSavedFile);
                    LoggerLight.SendRequest(DataStore.MyPedCollection[DataStore.iCurrentPed].Name, DataStore.sCurrentPed, true);
                }
            };
        }
        private void CreateNewPed(UIMenu XMen)
        {
            LoggerLight.Loggers("CreateNewPed");

            var playerNewSave = new UIMenuItem(DataStore.RsTranslate[112] + DataStore.RsTranslate[48], DataStore.RsTranslate[49]);
            XMen.AddItem(playerNewSave);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playerNewSave)
                {
                    if (DataStore.iCurrentPed == 0)
                        DataStore.MyPedCollection.Add(DataStore.MyPedCollection[0]);
                    DataStore.iCurrentPed = DataStore.MyPedCollection.Count - 1;
                    DataStore.MyPedCollection[DataStore.iCurrentPed].Name = Game.GetUserInput(255);
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle("~g~" + DataStore.RsTranslate[50] + DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
                    DataStore.SaveChars(DataStore.MyPedCollection, DataStore.sSavedFile);
                    LoggerLight.SendRequest(DataStore.MyPedCollection[DataStore.iCurrentPed].Name, DataStore.sCurrentPed, true);
                }
            };
        }
        private void SetLocate(UIMenu XMen)
        {
            LoggerLight.Loggers("SetLocate");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[51], DataStore.RsTranslate[52]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SetChar(UIMenu XMen)
        {
            LoggerLight.Loggers("SetChar");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[53], DataStore.RsTranslate[54]);
            if (DataStore.MySettingsXML.Spawn)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);

            var SetSVSaveOpt = new UIMenuItem(DataStore.RsTranslate[57], DataStore.RsTranslate[58]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }

            };
        }
        private void DisRecord(UIMenu XMen)
        {
            LoggerLight.Loggers("DisRecord");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[55], DataStore.RsTranslate[56]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SeatBeltON(UIMenu XMen)
        {
            LoggerLight.Loggers("SeatBeltON");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[96], DataStore.RsTranslate[152]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void MinMap(UIMenu XMen)
        {
            LoggerLight.Loggers("SeatBeltON");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[171], DataStore.RsTranslate[172]);
            if (DataStore.MySettingsXML.MinMap)
                SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            XMen.AddItem(SetCharOpt);

            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == SetCharOpt)
                {
                    DataStore.MySettingsXML.MinMap = !DataStore.MySettingsXML.MinMap;

                    if (DataStore.MySettingsXML.MinMap)
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
                    else
                        SetCharOpt.SetRightBadge(UIMenuItem.BadgeStyle.None);

                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void InstantReincarnate(UIMenu XMen)
        {
            LoggerLight.Loggers("InstantReincarnate");

            var playermodelmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[140], DataStore.RsTranslate[150]);

            var Rand_01 = new UIMenuItem(DataStore.RsTranslate[140], DataStore.RsTranslate[141]);
            if (DataStore.MySettingsXML.Reincarn)
                Rand_01.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_02 = new UIMenuItem(DataStore.RsTranslate[142], DataStore.RsTranslate[154]);
            if (DataStore.MySettingsXML.ReCritter)
                Rand_02.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_03 = new UIMenuItem(DataStore.RsTranslate[143], DataStore.RsTranslate[155]);
            if (DataStore.MySettingsXML.ReSave)
                Rand_03.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            var Rand_04 = new UIMenuItem(DataStore.RsTranslate[144], DataStore.RsTranslate[156]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
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

                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void AddBeachParty(UIMenu XMen)
        {
            LoggerLight.Loggers("AddBeachParty");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[97], DataStore.RsTranslate[151]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void SetLoadWeps(UIMenu XMen)
        {
            LoggerLight.Loggers("SetLoadWeps");

            var SetSVCharOpt = new UIMenuItem(DataStore.RsTranslate[59], DataStore.RsTranslate[60]);
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
                    DataStore.SaveSetMain(DataStore.MySettingsXML, DataStore.sSettings);
                }
            };
        }
        private void Re_WriteLoadout(UIMenu XMen)
        {
            LoggerLight.Loggers("Re_WriteLoadout");

            var SetCharOpt = new UIMenuItem(DataStore.RsTranslate[135], DataStore.RsTranslate[153]);
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

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[61], DataStore.RsTranslate[62]);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    UI.ShowSubtitle(DataStore.RsTranslate[63]);
                    DataStore.bKeyFinder = true;
                }
            };
        }
        private void SetControlKey(UIMenu XMen)
        {
            LoggerLight.Loggers("SetControlKey");

            var playermodelmenu = new UIMenuItem("Add Controler Support", "Add controler load keys");
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    MyMenuPool.CloseAllMenus();
                    RsActions.GetControlsSet();
                }
            };
        }
        private void DeleteCurrentPed(UIMenu XMen)
        {
            LoggerLight.Loggers("DeleteCurrentPed");

            var playermodelmenu = new UIMenuItem(DataStore.RsTranslate[64], DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
            XMen.AddItem(playermodelmenu);
            XMen.OnItemSelect += (sender, item, index) =>
            {
                if (item == playermodelmenu)
                {
                    UI.ShowSubtitle("~g~" + DataStore.RsTranslate[65] + " " + DataStore.MyPedCollection[DataStore.iCurrentPed].Name);
                    DataStore.MyPedCollection.RemoveAt(DataStore.iCurrentPed);
                    DataStore.SaveChars(DataStore.MyPedCollection, DataStore.sSavedFile);
                    MyMenuPool.CloseAllMenus();
                    DataStore.iCurrentPed = -1;
                }
            };
        }
        private void RanPedMenu(UIMenu XMen)
        {
            LoggerLight.Loggers("RanPedMenu");

            var randomAccessmenu = MyMenuPool.AddSubMenu(XMen, DataStore.RsTranslate[66], DataStore.RsTranslate[148]);
            //for (int i = 0; i < 1; i++) ;
            var Rand_01 = new UIMenuItem(DataStore.RsTranslate[67], "");
            var Rand_02 = new UIMenuItem(DataStore.RsTranslate[68], "");
            var Rand_03 = new UIMenuItem(DataStore.RsTranslate[69], "");
            var Rand_04 = new UIMenuItem(DataStore.RsTranslate[70], "");
            var Rand_05 = new UIMenuItem(DataStore.RsTranslate[71], "");
            var Rand_06 = new UIMenuItem(DataStore.RsTranslate[72], "");
            var Rand_07 = new UIMenuItem(DataStore.RsTranslate[73], "");
            var Rand_08 = new UIMenuItem(DataStore.RsTranslate[74], "");
            var Rand_09 = new UIMenuItem(DataStore.RsTranslate[75], "");
            var Rand_10 = new UIMenuItem(DataStore.RsTranslate[76], "");
            var Rand_11 = new UIMenuItem(DataStore.RsTranslate[77], "");
            var Rand_12 = new UIMenuItem(DataStore.RsTranslate[78], "");
            var Rand_13 = new UIMenuItem(DataStore.RsTranslate[79], "");
            var Rand_14 = new UIMenuItem(DataStore.RsTranslate[80], "");
            var Rand_15 = new UIMenuItem(DataStore.RsTranslate[81], "");
            var Rand_16 = new UIMenuItem(DataStore.RsTranslate[82], "");
            var Rand_17 = new UIMenuItem(DataStore.RsTranslate[83], "");
            var Rand_18 = new UIMenuItem(DataStore.RsTranslate[84], "");
            var Rand_19 = new UIMenuItem(DataStore.RsTranslate[85], "");
            var Rand_20 = new UIMenuItem(DataStore.RsTranslate[86], "");
            var Rand_21 = new UIMenuItem(DataStore.RsTranslate[87], "");
            var Rand_22 = new UIMenuItem(DataStore.RsTranslate[93], "");
            var Rand_23 = new UIMenuItem(DataStore.RsTranslate[139], "");
            var Rand_24 = new UIMenuItem(DataStore.RsTranslate[94], "");
            var Rand_25 = new UIMenuItem(DataStore.RsTranslate[95], "");

            randomAccessmenu.AddItem(Rand_01);
            randomAccessmenu.AddItem(Rand_02);
            randomAccessmenu.AddItem(Rand_03);
            randomAccessmenu.AddItem(Rand_04);
            randomAccessmenu.AddItem(Rand_05);
            randomAccessmenu.AddItem(Rand_06);
            randomAccessmenu.AddItem(Rand_07);
            randomAccessmenu.AddItem(Rand_08);
            randomAccessmenu.AddItem(Rand_09);
            randomAccessmenu.AddItem(Rand_10);
            randomAccessmenu.AddItem(Rand_11);
            randomAccessmenu.AddItem(Rand_12);
            randomAccessmenu.AddItem(Rand_13);
            randomAccessmenu.AddItem(Rand_14);
            randomAccessmenu.AddItem(Rand_15);
            randomAccessmenu.AddItem(Rand_16);
            randomAccessmenu.AddItem(Rand_17);
            randomAccessmenu.AddItem(Rand_18);
            randomAccessmenu.AddItem(Rand_19);
            randomAccessmenu.AddItem(Rand_20);
            randomAccessmenu.AddItem(Rand_21);
            randomAccessmenu.AddItem(Rand_22);
            randomAccessmenu.AddItem(Rand_23);
            randomAccessmenu.AddItem(Rand_24);
            randomAccessmenu.AddItem(Rand_25);

            randomAccessmenu.OnItemSelect += (sender, item, index) =>
            {
                if (sender == randomAccessmenu)
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
                }
            };
        }
        private Prop AddTombStone()
        {
            if (File.Exists(DataStore.sSaveArts))
            {
                try
                {
                    EraseOldAss(DataStore.sSaveArts);
                }
                catch
                {

                }
            }
            Prop MyTomb = World.CreateProp("prop_fib_3b_cover1", new Vector3(-282.8405f, 2834.9153f, 53.3622f), new Vector3(0.00f, 0.00f, 151.3774f), false, false);

            return MyTomb;
        }
        private void EraseOldAss(string fileName)
        {
            string[] readNote = File.ReadAllLines(fileName);

            for (int i = 0; i < readNote.Count(); i++)
            {
                LoggerLight.Loggers("AssestRem_" + readNote[i]);

                if (readNote[i].Contains("Tomb_"))
                {
                    string sHandle = readNote[0].Remove(0, 5);
                    int iHandlle = (int)Convert.ToInt32(sHandle);
                    Prop MyTomb = new Prop(iHandlle);

                    if (MyTomb.Exists())
                        DataStore.PropList.Add(new Prop(iHandlle));
                    else
                        break;
                }
                else if (readNote[i].Contains("MyPed_"))
                {
                    string sHandle = readNote[0].Remove(0, 6);
                    int iHandlle = (int)Convert.ToInt32(sHandle);
                    DataStore.PeddyList.Add(new Ped(iHandlle));
                }
                else if (readNote[i].Contains("MyProp_"))
                {
                    string sHandle = readNote[0].Remove(0, 7);
                    int iHandlle = (int)Convert.ToInt32(sHandle);
                    DataStore.PropList.Add(new Prop(iHandlle));
                }
                else if (readNote[i].Contains("MyVeh_"))
                {
                    string sHandle = readNote[0].Remove(0, 6);
                    int iHandlle = (int)Convert.ToInt32(sHandle);
                    DataStore.VehList.Add(new Vehicle(iHandlle));
                }
                else if (readNote[i].Contains("CayoLoad"))
                    RsActions.CayoPerico(false);
                else if (readNote[i].Contains("YankLoad"))
                    RsActions.Yankton(false);              
            }
            RsActions.CleanUpAss(true);
        }
    }
}