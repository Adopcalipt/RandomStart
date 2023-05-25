using GTA;
using GTA.Math;
using GTA.Native;
using RandomStart.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RandomStart
{
    public class RsReturns
    {
        public readonly static List<AnimatedActions> MaleDance01 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_male^5"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_male^6"),
        };
        public readonly static List<AnimatedActions> MaleDance02 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_male^6")
        };
        public readonly static List<AnimatedActions> MaleDance03 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_male^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_male^6")
        };

        public readonly static List<AnimatedActions> FemaleDance01 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_09_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_11_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_13_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_15_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@low_intesnsity", "li_dance_facedj_17_v2_female^6")
        };
        public readonly static List<AnimatedActions> FemaleDance02 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_09_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_11_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_13_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_15_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@med_intensity", "mi_dance_facedj_17_v1_female^6")
        };
        public readonly static List<AnimatedActions> FemaleDance03 = new List<AnimatedActions>
        {
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_09_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_11_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_13_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_15_v2_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v1_female^6"),

            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^1"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^2"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^3"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^4"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^5"),
            new AnimatedActions("anim@amb@nightclub@dancers@crowddance_facedj@hi_intensity", "hi_dance_facedj_17_v2_female^6")
        };

        public static List<TShirt> TShirtyFe = new List<TShirt>
        {
            new TShirt("mpheist_overlays","MP_Bugstar_C","MP_Bugstar_C"),
            new TShirt("mpheist_overlays","MP_Als_A","MP_Als_A"),
            new TShirt("mpheist_overlays","MP_Als_B","MP_Als_B"),
            new TShirt("mpheist_overlays","MP_Bugstar_A","MP_Bugstar_A"),
            new TShirt("mpheist_overlays","MP_Bugstar_B","MP_Bugstar_B"),
            new TShirt("mpheist_overlays","MP_Power_A","MP_Power_A"),
            new TShirt("mpheist_overlays","MP_Power_B","MP_Power_B"),
            new TShirt("mpheist_overlays","MP_Rogers_A","MP_Rogers_A"),
            new TShirt("mpheist_overlays","MP_Rogers_B","MP_Rogers_B"),
            new TShirt("multiplayer_overlays","mp_fm_branding_019","mp_fm_branding_019"),
            new TShirt("multiplayer_overlays","mp_fm_branding_025","mp_fm_branding_025"),
            new TShirt("multiplayer_overlays","mp_fm_branding_037","mp_fm_branding_037"),
            new TShirt("mphalloween_overlays","HW_Tee_000_F","HW_Tee_000_F"),
            new TShirt("mphalloween_overlays","HW_Tee_001_F","HW_Tee_001_F"),
            new TShirt("mphalloween_overlays","HW_Tee_002_F","HW_Tee_002_F"),
            new TShirt("mphalloween_overlays","HW_Tee_003_F","HW_Tee_003_F"),
            new TShirt("mphalloween_overlays","HW_Tee_004_F","HW_Tee_004_F"),
            new TShirt("mphalloween_overlays","HW_Tee_005_F","HW_Tee_005_F"),
            new TShirt("mphalloween_overlays","HW_Tee_006_F","HW_Tee_006_F"),
            new TShirt("mphalloween_overlays","HW_Tee_007_F","HW_Tee_007_F"),
            new TShirt("mphalloween_overlays","HW_Tee_008_F","HW_Tee_008_F"),
            new TShirt("mphalloween_overlays","HW_Tee_009_F","HW_Tee_009_F"),
            new TShirt("mphalloween_overlays","HW_Tee_010_F","HW_Tee_010_F"),
            new TShirt("mphalloween_overlays","HW_Tee_011_F","HW_Tee_011_F"),
            new TShirt("mphalloween_overlays","HW_Tee_012_F","HW_Tee_012_F"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_004","MP_Award_F_Tshirt_004"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_005","MP_Award_F_Tshirt_005"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_006","MP_Award_F_Tshirt_006"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_007","MP_Award_F_Tshirt_007"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_008","MP_Award_F_Tshirt_008"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_009","MP_Award_F_Tshirt_009"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_010","MP_Award_F_Tshirt_010"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_011","MP_Award_F_Tshirt_011"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_012","MP_Award_F_Tshirt_012"),
            new TShirt("mpheist_overlays","MP_Award_F_Tshirt_013","MP_Award_F_Tshirt_013"),
            new TShirt("mpheist_overlays","MP_Elite_F_Tshirt","MP_Elite_F_Tshirt"),
            new TShirt("mpheist_overlays","MP_Elite_F_Tshirt_1","MP_Elite_F_Tshirt_1"),
            new TShirt("mpheist_overlays","MP_Elite_F_Tshirt_2","MP_Elite_F_Tshirt_2"),
            new TShirt("mpheist_overlays","MP_Fli_F_Tshirt_000","MP_Fli_F_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_000","FM_Hip_F_Retro_000"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_001","FM_Hip_F_Retro_001"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_002","FM_Hip_F_Retro_002"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_003","FM_Hip_F_Retro_003"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_004","FM_Hip_F_Retro_004"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_005","FM_Hip_F_Retro_005"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_006","FM_Hip_F_Retro_006"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_007","FM_Hip_F_Retro_007"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_008","FM_Hip_F_Retro_008"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_009","FM_Hip_F_Retro_009"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_010","FM_Hip_F_Retro_010"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_011","FM_Hip_F_Retro_011"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_012","FM_Hip_F_Retro_012"),
            new TShirt("mphipster_overlays","FM_Hip_F_Retro_013","FM_Hip_F_Retro_013"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_000","FM_Hip_F_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_001","FM_Hip_F_Tshirt_001"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_002","FM_Hip_F_Tshirt_002"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_003","FM_Hip_F_Tshirt_003"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_004","FM_Hip_F_Tshirt_004"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_005","FM_Hip_F_Tshirt_005"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_006","FM_Hip_F_Tshirt_006"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_007","FM_Hip_F_Tshirt_007"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_008","FM_Hip_F_Tshirt_008"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_009","FM_Hip_F_Tshirt_009"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_010","FM_Hip_F_Tshirt_010"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_011","FM_Hip_F_Tshirt_011"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_012","FM_Hip_F_Tshirt_012"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_013","FM_Hip_F_Tshirt_013"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_014","FM_Hip_F_Tshirt_014"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_015","FM_Hip_F_Tshirt_015"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_016","FM_Hip_F_Tshirt_016"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_017","FM_Hip_F_Tshirt_017"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_018","FM_Hip_F_Tshirt_018"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_019","FM_Hip_F_Tshirt_019"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_020","FM_Hip_F_Tshirt_020"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_021","FM_Hip_F_Tshirt_021"),
            new TShirt("mphipster_overlays","FM_Hip_F_Tshirt_022","FM_Hip_F_Tshirt_022"),
            new TShirt("mphipster_overlays","FM_Rstar_F_Tshirt_000","FM_Rstar_F_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Rstar_F_Tshirt_001","FM_Rstar_F_Tshirt_001"),
            new TShirt("mphipster_overlays","FM_Rstar_F_Tshirt_002","FM_Rstar_F_Tshirt_002"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Award_000","FM_Ind_F_Award_000"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_000","FM_Ind_F_Tshirt_000"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_001","FM_Ind_F_Tshirt_001"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_002","FM_Ind_F_Tshirt_002"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_003","FM_Ind_F_Tshirt_003"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_004","FM_Ind_F_Tshirt_004"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_005","FM_Ind_F_Tshirt_005"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_006","FM_Ind_F_Tshirt_006"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_007","FM_Ind_F_Tshirt_007"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_008","FM_Ind_F_Tshirt_008"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_009","FM_Ind_F_Tshirt_009"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_010","FM_Ind_F_Tshirt_010"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_011","FM_Ind_F_Tshirt_011"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_012","FM_Ind_F_Tshirt_012"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_013","FM_Ind_F_Tshirt_013"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_014","FM_Ind_F_Tshirt_014"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_015","FM_Ind_F_Tshirt_015"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_016","FM_Ind_F_Tshirt_016"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_017","FM_Ind_F_Tshirt_017"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_018","FM_Ind_F_Tshirt_018"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_019","FM_Ind_F_Tshirt_019"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_020","FM_Ind_F_Tshirt_020"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_021","FM_Ind_F_Tshirt_021"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_022","FM_Ind_F_Tshirt_022"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_023","FM_Ind_F_Tshirt_023"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_024","FM_Ind_F_Tshirt_024"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_025","FM_Ind_F_Tshirt_025"),
            new TShirt("mpindependance_overlays","FM_Ind_F_Tshirt_026","FM_Ind_F_Tshirt_026"),
            new TShirt("mplowrider_overlays","MP_Bennys_000_F","MP_Bennys_000_F"),
            new TShirt("mplowrider_overlays","MP_Bennys_001_F","MP_Bennys_001_F"),
            new TShirt("mplowrider_overlays","MP_Broker_000_F","MP_Broker_000_F"),
            new TShirt("mplowrider_overlays","MP_Broker_001_F","MP_Broker_001_F"),
            new TShirt("mplowrider_overlays","MP_Broker_002_F","MP_Broker_002_F"),
            new TShirt("mplowrider_overlays","MP_Broker_003_F","MP_Broker_003_F"),
            new TShirt("mplowrider_overlays","MP_Broker_004_F","MP_Broker_004_F"),
            new TShirt("mplowrider_overlays","MP_Broker_005_F","MP_Broker_005_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_000_F","MP_Magnetics_000_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_001_F","MP_Magnetics_001_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_002_F","MP_Magnetics_002_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_003_F","MP_Magnetics_003_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_004_F","MP_Magnetics_004_F"),
            new TShirt("mplowrider_overlays","MP_Magnetics_005_F","MP_Magnetics_005_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_000_F","MP_Trickster_000_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_001_F","MP_Trickster_001_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_002_F","MP_Trickster_002_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_003_F","MP_Trickster_003_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_004_F","MP_Trickster_004_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_005_F","MP_Trickster_005_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_006_F","MP_Trickster_006_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_007_F","MP_Trickster_007_F"),
            new TShirt("mplowrider_overlays","MP_Trickster_010_F","MP_Trickster_010_F"),
            new TShirt("mplts_overlays","FM_LTS_F_Tshirt_000","FM_LTS_F_Tshirt_000"),
            new TShirt("mpluxe_overlays","MP_FAKE_DIS_000_F","MP_FAKE_DIS_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_DIS_001_F","MP_FAKE_DIS_001_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_DS_000_F","MP_FAKE_DS_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_ENEMA_000_F","MP_FAKE_ENEMA_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_LB_000_F","MP_FAKE_LB_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_LC_000_F","MP_FAKE_LC_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_Per_000_F","MP_FAKE_Per_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_SC_000_F","MP_FAKE_SC_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_SN_000_F","MP_FAKE_SN_000_F"),
            new TShirt("mpluxe_overlays","MP_FAKE_Vap_000_F","MP_FAKE_Vap_000_F"),
            new TShirt("mpluxe_overlays","MP_FILM_000_F","MP_FILM_000_F"),
            new TShirt("mpluxe_overlays","MP_FILM_001_F","MP_FILM_001_F"),
            new TShirt("mpluxe_overlays","MP_FILM_002_F","MP_FILM_002_F"),
            new TShirt("mpluxe_overlays","MP_FILM_003_F","MP_FILM_003_F"),
            new TShirt("mpluxe_overlays","MP_FILM_004_F","MP_FILM_004_F"),
            new TShirt("mpluxe_overlays","MP_FILM_005_F","MP_FILM_005_F"),
            new TShirt("mpluxe_overlays","MP_FILM_006_F","MP_FILM_006_F"),
            new TShirt("mpluxe_overlays","MP_FILM_007_F","MP_FILM_007_F"),
            new TShirt("mpluxe_overlays","MP_FILM_008_F","MP_FILM_008_F"),
            new TShirt("mpluxe_overlays","MP_FILM_009_F","MP_FILM_009_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_000_F","MP_LUXE_DIX_000_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_001_F","MP_LUXE_DIX_001_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_002_F","MP_LUXE_DIX_002_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_Enema_000_F","MP_LUXE_Enema_000_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_004_F","MP_LUXE_LC_004_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_005_F","MP_LUXE_LC_005_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_010_F","MP_LUXE_LC_010_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_011_F","MP_LUXE_LC_011_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_Per_001_F","MP_LUXE_Per_001_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SC_000_F","MP_LUXE_SC_000_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_000_F","MP_LUXE_SN_000_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_001_F","MP_LUXE_SN_001_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_002_F","MP_LUXE_SN_002_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_003_F","MP_LUXE_SN_003_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_004_F","MP_LUXE_SN_004_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_005_F","MP_LUXE_SN_005_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_006_F","MP_LUXE_SN_006_F"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_007_F","MP_LUXE_SN_007_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_000_F","MP_LUXE_LC_000_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_001_F","MP_LUXE_LC_001_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_002_F","MP_LUXE_LC_002_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_003_F","MP_LUXE_LC_003_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_006_F","MP_LUXE_LC_006_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_007_F","MP_LUXE_LC_007_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_008_F","MP_LUXE_LC_008_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_009_F","MP_LUXE_LC_009_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_012_F","MP_LUXE_LC_012_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_013_F","MP_LUXE_LC_013_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_014_F","MP_LUXE_LC_014_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_015_F","MP_LUXE_LC_015_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_000_F","MP_LUXE_VDG_000_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_001_F","MP_LUXE_VDG_001_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_002_F","MP_LUXE_VDG_002_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_004_F","MP_LUXE_VDG_004_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_005_F","MP_LUXE_VDG_005_F"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_006_F","MP_LUXE_VDG_006_F"),
            new TShirt("mppilot_overlays","MP_Fli_F_Tshirt_000","MP_Fli_F_Tshirt_000"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_A","MP_Val_F_Tshirt_A"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_B","MP_Val_F_Tshirt_B"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_C","MP_Val_F_Tshirt_C"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_D","MP_Val_F_Tshirt_D"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_E","MP_Val_F_Tshirt_E"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_F","MP_Val_F_Tshirt_F"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_G","MP_Val_F_Tshirt_G"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_H","MP_Val_F_Tshirt_H"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_I","MP_Val_F_Tshirt_I"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_J","MP_Val_F_Tshirt_J"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_K","MP_Val_F_Tshirt_K"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_L","MP_Val_F_Tshirt_L"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_M","MP_Val_F_Tshirt_M"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_N","MP_Val_F_Tshirt_N"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_O","MP_Val_F_Tshirt_O"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_P","MP_Val_F_Tshirt_P"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_Q","MP_Val_F_Tshirt_Q"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_R","MP_Val_F_Tshirt_R"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_S","MP_Val_F_Tshirt_S"),
            new TShirt("mpvalentines_overlays","MP_Val_F_Tshirt_T","MP_Val_F_Tshirt_T"),
            new TShirt("mpxmas_604490_overlays","MP_IHeartLC_001_F","MP_IHeartLC_001_F"),
            new TShirt("multiplayer_overlays","FM_CREW_F_000_A","FM_CREW_F_000_A"),
            new TShirt("multiplayer_overlays","FM_CREW_F_000_B","FM_CREW_F_000_B"),
            new TShirt("multiplayer_overlays","FM_CREW_F_000_C","FM_CREW_F_000_C"),
            new TShirt("multiplayer_overlays","FM_CREW_F_000_D","FM_CREW_F_000_D"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_F_000","FM_Tshirt_Award_F_000"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_F_001","FM_Tshirt_Award_F_001"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_F_002","FM_Tshirt_Award_F_002"),
            new TShirt("multiplayer_overlays","mp_fm_branding_027_f","mp_fm_branding_027_f"),
            new TShirt("multiplayer_overlays","mp_fm_branding_028_F","mp_fm_branding_028_F"),
            new TShirt("multiplayer_overlays","mp_fm_branding_034_f","mp_fm_branding_034_f"),
            new TShirt("multiplayer_overlays","mp_fm_branding_036_F","mp_fm_branding_036_F"),
            new TShirt("multiplayer_overlays","mp_fm_branding_039_f","mp_fm_branding_039_f"),
            new TShirt("multiplayer_overlays","mp_fm_branding_048","mp_fm_branding_048"),
            new TShirt("multiplayer_overlays","mp_fm_branding_049","mp_fm_branding_049"),
            new TShirt("multiplayer_overlays","mp_fm_branding_050","mp_fm_branding_050"),
            new TShirt("multiplayer_overlays","mp_fm_branding_051","mp_fm_branding_051"),
            new TShirt("multiplayer_overlays","mp_fm_branding_052","mp_fm_branding_052"),
            new TShirt("multiplayer_overlays","mp_fm_branding_053","mp_fm_branding_053"),
            new TShirt("multiplayer_overlays","mp_fm_branding_054","mp_fm_branding_054"),
            new TShirt("multiplayer_overlays","mp_fm_branding_055","mp_fm_branding_055"),
            new TShirt("multiplayer_overlays","mp_fm_branding_056","mp_fm_branding_056"),
            new TShirt("multiplayer_overlays","mp_fm_branding_057","mp_fm_branding_057"),
            new TShirt("multiplayer_overlays","mp_fm_branding_058","mp_fm_branding_058"),
            new TShirt("multiplayer_overlays","mp_fm_branding_059","mp_fm_branding_059"),
            new TShirt("multiplayer_overlays","mp_fm_branding_060","mp_fm_branding_060"),
            new TShirt("multiplayer_overlays","mp_fm_branding_061","mp_fm_branding_061"),
            new TShirt("multiplayer_overlays","mp_fm_branding_062","mp_fm_branding_062"),
            new TShirt("multiplayer_overlays","mp_fm_branding_066","mp_fm_branding_066"),
            new TShirt("multiplayer_overlays","mp_fm_branding_067","mp_fm_branding_067"),
            new TShirt("multiplayer_overlays","mp_fm_branding_068","mp_fm_branding_068"),
            new TShirt("multiplayer_overlays","mp_fm_branding_069","mp_fm_branding_069"),
            new TShirt("multiplayer_overlays","mp_fm_branding_070","mp_fm_branding_070"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_000_f","mp_fm_OGA_000_f"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_001_f","mp_fm_OGA_001_f"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_002_f","mp_fm_OGA_002_f"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_003_f","mp_fm_OGA_003_f"),
            new TShirt("mplowrider2_overlays","MP_Chianski_000_F","MP_Chianski_000_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_001_F","MP_Chianski_001_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_002_F","MP_Chianski_002_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_003_F","MP_Chianski_003_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_004_F","MP_Chianski_004_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_005_F","MP_Chianski_005_F"),
            new TShirt("mplowrider2_overlays","MP_Chianski_006_F","MP_Chianski_006_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_000_F","MP_Hntr_000_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_001_F","MP_Hntr_001_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_002_F","MP_Hntr_002_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_003_F","MP_Hntr_003_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_004_F","MP_Hntr_004_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_005_F","MP_Hntr_005_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_006_F","MP_Hntr_006_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_007_F","MP_Hntr_007_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_008_F","MP_Hntr_008_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_009_F","MP_Hntr_009_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_010_F","MP_Hntr_010_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_011_F","MP_Hntr_011_F"),
            new TShirt("mplowrider2_overlays","MP_Hntr_012_F","MP_Hntr_012_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_000_F","MP_Dense_000_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_001_F","MP_Dense_001_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_002_F","MP_Dense_002_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_003_F","MP_Dense_003_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_004_F","MP_Dense_004_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_005_F","MP_Dense_005_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_006_F","MP_Dense_006_F"),
            new TShirt("mplowrider2_overlays","MP_Dense_007_F","MP_Dense_007_F"),
            new TShirt("mpexecutive_overlays","MP_Securoserv_000_F","MP_Securoserv_000_F"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_000_F","MP_exec_teams_000_F"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_001_F","MP_exec_teams_001_F"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_002_F","MP_exec_teams_002_F"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_003_F","MP_exec_teams_003_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_000_F","MP_exec_prizes_000_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_001_F","MP_exec_prizes_001_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_002_F","MP_exec_prizes_002_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_003_F","MP_exec_prizes_003_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_004_F","MP_exec_prizes_004_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_005_F","MP_exec_prizes_005_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_006_F","MP_exec_prizes_006_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_007_F","MP_exec_prizes_007_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_008_F","MP_exec_prizes_008_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_009_F","MP_exec_prizes_009_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_010_F","MP_exec_prizes_010_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_011_F","MP_exec_prizes_011_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_012_F","MP_exec_prizes_012_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_013_F","MP_exec_prizes_013_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_014_F","MP_exec_prizes_014_F"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_015_F","MP_exec_prizes_015_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Award_000_F","MP_Biker_Award_000_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Award_001_F","MP_Biker_Award_001_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_000_F","MP_Biker_Rank_000_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_001_F","MP_Biker_Rank_001_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_002_F","MP_Biker_Rank_002_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_003_F","MP_Biker_Rank_003_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_004_F","MP_Biker_Rank_004_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_005_F","MP_Biker_Rank_005_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_006_F","MP_Biker_Rank_006_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_007_F","MP_Biker_Rank_007_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_008_F","MP_Biker_Rank_008_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_009_F","MP_Biker_Rank_009_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_010_F","MP_Biker_Rank_010_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_011_F","MP_Biker_Rank_011_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_012_F","MP_Biker_Rank_012_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_013_F","MP_Biker_Rank_013_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_014_F","MP_Biker_Rank_014_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_015_F","MP_Biker_Rank_015_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_016_F","MP_Biker_Rank_016_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_017_F","MP_Biker_Rank_017_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_000_F","MP_Biker_Tee_000_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_001_F","MP_Biker_Tee_001_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_002_F","MP_Biker_Tee_002_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_003_F","MP_Biker_Tee_003_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_004_F","MP_Biker_Tee_004_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_005_F","MP_Biker_Tee_005_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_006_F","MP_Biker_Tee_006_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_007_F","MP_Biker_Tee_007_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_008_F","MP_Biker_Tee_008_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_009_F","MP_Biker_Tee_009_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_010_F","MP_Biker_Tee_010_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_011_F","MP_Biker_Tee_011_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_012_F","MP_Biker_Tee_012_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_013_F","MP_Biker_Tee_013_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_014_F","MP_Biker_Tee_014_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_015_F","MP_Biker_Tee_015_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_016_F","MP_Biker_Tee_016_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_017_F","MP_Biker_Tee_017_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_018_F","MP_Biker_Tee_018_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_019_F","MP_Biker_Tee_019_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_020_F","MP_Biker_Tee_020_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_021_F","MP_Biker_Tee_021_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_022_F","MP_Biker_Tee_022_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_023_F","MP_Biker_Tee_023_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_024_F","MP_Biker_Tee_024_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_025_F","MP_Biker_Tee_025_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_026_F","MP_Biker_Tee_026_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_027_F","MP_Biker_Tee_027_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_028_F","MP_Biker_Tee_028_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_029_F","MP_Biker_Tee_029_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_030_F","MP_Biker_Tee_030_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_031_F","MP_Biker_Tee_031_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_032_F","MP_Biker_Tee_032_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_033_F","MP_Biker_Tee_033_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_034_F","MP_Biker_Tee_034_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_035_F","MP_Biker_Tee_035_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_036_F","MP_Biker_Tee_036_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_037_F","MP_Biker_Tee_037_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_038_F","MP_Biker_Tee_038_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_039_F","MP_Biker_Tee_039_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_040_F","MP_Biker_Tee_040_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_041_F","MP_Biker_Tee_041_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_042_F","MP_Biker_Tee_042_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_043_F","MP_Biker_Tee_043_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_044_F","MP_Biker_Tee_044_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_045_F","MP_Biker_Tee_045_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_046_F","MP_Biker_Tee_046_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_047_F","MP_Biker_Tee_047_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_048_F","MP_Biker_Tee_048_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_049_F","MP_Biker_Tee_049_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_050_F","MP_Biker_Tee_050_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_051_F","MP_Biker_Tee_051_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_052_F","MP_Biker_Tee_052_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_053_F","MP_Biker_Tee_053_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_054_F","MP_Biker_Tee_054_F"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_055_F","MP_Biker_Tee_055_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_000_F","MP_Gunrunning_Award_000_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_001_F","MP_Gunrunning_Award_001_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_002_F","MP_Gunrunning_Award_002_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_003_F","MP_Gunrunning_Award_003_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_004_F","MP_Gunrunning_Award_004_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_005_F","MP_Gunrunning_Award_005_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_006_F","MP_Gunrunning_Award_006_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_007_F","MP_Gunrunning_Award_007_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_008_F","MP_Gunrunning_Award_008_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_009_F","MP_Gunrunning_Award_009_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_010_F","MP_Gunrunning_Award_010_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_011_F","MP_Gunrunning_Award_011_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_012_F","MP_Gunrunning_Award_012_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_013_F","MP_Gunrunning_Award_013_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_014_F","MP_Gunrunning_Award_014_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_015_F","MP_Gunrunning_Award_015_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_016_F","MP_Gunrunning_Award_016_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_017_F","MP_Gunrunning_Award_017_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_018_F","MP_Gunrunning_Award_018_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_019_F","MP_Gunrunning_Award_019_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_020_F","MP_Gunrunning_Award_020_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_021_F","MP_Gunrunning_Award_021_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_022_F","MP_Gunrunning_Award_022_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_023_F","MP_Gunrunning_Award_023_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_024_F","MP_Gunrunning_Award_024_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_025_F","MP_Gunrunning_Award_025_F"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_026_F","MP_Gunrunning_Award_026_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_000_F","MP_Battle_Clothing_000_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_001_F","MP_Battle_Clothing_001_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_002_F","MP_Battle_Clothing_002_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_003_F","MP_Battle_Clothing_003_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_004_F","MP_Battle_Clothing_004_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_005_F","MP_Battle_Clothing_005_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_006_F","MP_Battle_Clothing_006_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_007_F","MP_Battle_Clothing_007_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_008_F","MP_Battle_Clothing_008_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_009_F","MP_Battle_Clothing_009_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_010_F","MP_Battle_Clothing_010_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_011_F","MP_Battle_Clothing_011_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_012_F","MP_Battle_Clothing_012_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_013_F","MP_Battle_Clothing_013_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_014_F","MP_Battle_Clothing_014_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_015_F","MP_Battle_Clothing_015_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_016_F","MP_Battle_Clothing_016_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_017_F","MP_Battle_Clothing_017_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_018_F","MP_Battle_Clothing_018_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_019_F","MP_Battle_Clothing_019_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_020_F","MP_Battle_Clothing_020_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_021_F","MP_Battle_Clothing_021_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_022_F","MP_Battle_Clothing_022_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_023_F","MP_Battle_Clothing_023_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_024_F","MP_Battle_Clothing_024_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_025_F","MP_Battle_Clothing_025_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_026_F","MP_Battle_Clothing_026_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_027_F","MP_Battle_Clothing_027_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_028_F","MP_Battle_Clothing_028_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_029_F","MP_Battle_Clothing_029_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_030_F","MP_Battle_Clothing_030_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_031_F","MP_Battle_Clothing_031_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_032_F","MP_Battle_Clothing_032_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_033_F","MP_Battle_Clothing_033_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_034_F","MP_Battle_Clothing_034_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_035_F","MP_Battle_Clothing_035_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_036_F","MP_Battle_Clothing_036_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_037_F","MP_Battle_Clothing_037_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_038_F","MP_Battle_Clothing_038_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_039_F","MP_Battle_Clothing_039_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_040_F","MP_Battle_Clothing_040_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_041_F","MP_Battle_Clothing_041_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_042_F","MP_Battle_Clothing_042_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_043_F","MP_Battle_Clothing_043_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_044_F","MP_Battle_Clothing_044_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_045_F","MP_Battle_Clothing_045_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_046_F","MP_Battle_Clothing_046_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_047_F","MP_Battle_Clothing_047_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_048_F","MP_Battle_Clothing_048_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_049_F","MP_Battle_Clothing_049_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_050_F","MP_Battle_Clothing_050_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_051_F","MP_Battle_Clothing_051_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_052_F","MP_Battle_Clothing_052_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_053_F","MP_Battle_Clothing_053_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_054_F","MP_Battle_Clothing_054_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_055_F","MP_Battle_Clothing_055_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_056_F","MP_Battle_Clothing_056_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_057_F","MP_Battle_Clothing_057_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_058_F","MP_Battle_Clothing_058_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_059_F","MP_Battle_Clothing_059_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_060_F","MP_Battle_Clothing_060_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_061_F","MP_Battle_Clothing_061_F"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_062_F","MP_Battle_Clothing_062_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_000_F","MP_Christmas2018_Tee_000_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_001_F","MP_Christmas2018_Tee_001_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_002_F","MP_Christmas2018_Tee_002_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_003_F","MP_Christmas2018_Tee_003_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_004_F","MP_Christmas2018_Tee_004_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_005_F","MP_Christmas2018_Tee_005_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_006_F","MP_Christmas2018_Tee_006_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_007_F","MP_Christmas2018_Tee_007_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_008_F","MP_Christmas2018_Tee_008_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_009_F","MP_Christmas2018_Tee_009_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_010_F","MP_Christmas2018_Tee_010_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_011_F","MP_Christmas2018_Tee_011_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_012_F","MP_Christmas2018_Tee_012_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_013_F","MP_Christmas2018_Tee_013_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_014_F","MP_Christmas2018_Tee_014_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_015_F","MP_Christmas2018_Tee_015_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_016_F","MP_Christmas2018_Tee_016_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_017_F","MP_Christmas2018_Tee_017_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_018_F","MP_Christmas2018_Tee_018_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_019_F","MP_Christmas2018_Tee_019_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_020_F","MP_Christmas2018_Tee_020_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_021_F","MP_Christmas2018_Tee_021_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_022_F","MP_Christmas2018_Tee_022_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_023_F","MP_Christmas2018_Tee_023_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_024_F","MP_Christmas2018_Tee_024_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_025_F","MP_Christmas2018_Tee_025_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_026_F","MP_Christmas2018_Tee_026_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_027_F","MP_Christmas2018_Tee_027_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_028_F","MP_Christmas2018_Tee_028_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_029_F","MP_Christmas2018_Tee_029_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_030_F","MP_Christmas2018_Tee_030_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_031_F","MP_Christmas2018_Tee_031_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_032_F","MP_Christmas2018_Tee_032_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_033_F","MP_Christmas2018_Tee_033_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_034_F","MP_Christmas2018_Tee_034_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_035_F","MP_Christmas2018_Tee_035_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_036_F","MP_Christmas2018_Tee_036_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_037_F","MP_Christmas2018_Tee_037_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_038_F","MP_Christmas2018_Tee_038_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_039_F","MP_Christmas2018_Tee_039_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_040_F","MP_Christmas2018_Tee_040_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_041_F","MP_Christmas2018_Tee_041_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_042_F","MP_Christmas2018_Tee_042_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_043_F","MP_Christmas2018_Tee_043_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_044_F","MP_Christmas2018_Tee_044_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_045_F","MP_Christmas2018_Tee_045_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_046_F","MP_Christmas2018_Tee_046_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_047_F","MP_Christmas2018_Tee_047_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_048_F","MP_Christmas2018_Tee_048_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_049_F","MP_Christmas2018_Tee_049_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_050_F","MP_Christmas2018_Tee_050_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_051_F","MP_Christmas2018_Tee_051_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_052_F","MP_Christmas2018_Tee_052_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_053_F","MP_Christmas2018_Tee_053_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_054_F","MP_Christmas2018_Tee_054_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_055_F","MP_Christmas2018_Tee_055_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_056_F","MP_Christmas2018_Tee_056_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_057_F","MP_Christmas2018_Tee_057_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_058_F","MP_Christmas2018_Tee_058_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_059_F","MP_Christmas2018_Tee_059_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_060_F","MP_Christmas2018_Tee_060_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_061_F","MP_Christmas2018_Tee_061_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_062_F","MP_Christmas2018_Tee_062_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_063_F","MP_Christmas2018_Tee_063_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_064_F","MP_Christmas2018_Tee_064_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_065_F","MP_Christmas2018_Tee_065_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_066_F","MP_Christmas2018_Tee_066_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_067_F","MP_Christmas2018_Tee_067_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_068_F","MP_Christmas2018_Tee_068_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_069_F","MP_Christmas2018_Tee_069_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_070_F","MP_Christmas2018_Tee_070_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_071_F","MP_Christmas2018_Tee_071_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_072_F","MP_Christmas2018_Tee_072_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_073_F","MP_Christmas2018_Tee_073_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_074_F","MP_Christmas2018_Tee_074_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_075_F","MP_Christmas2018_Tee_075_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_076_F","MP_Christmas2018_Tee_076_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_077_F","MP_Christmas2018_Tee_077_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_078_F","MP_Christmas2018_Tee_078_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_079_F","MP_Christmas2018_Tee_079_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_080_F","MP_Christmas2018_Tee_080_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_081_F","MP_Christmas2018_Tee_081_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_082_F","MP_Christmas2018_Tee_082_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_083_F","MP_Christmas2018_Tee_083_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_084_F","MP_Christmas2018_Tee_084_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_085_F","MP_Christmas2018_Tee_085_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_086_F","MP_Christmas2018_Tee_086_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_087_F","MP_Christmas2018_Tee_087_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_088_F","MP_Christmas2018_Tee_088_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_089_F","MP_Christmas2018_Tee_089_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_090_F","MP_Christmas2018_Tee_090_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_091_F","MP_Christmas2018_Tee_091_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_092_F","MP_Christmas2018_Tee_092_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_093_F","MP_Christmas2018_Tee_093_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_094_F","MP_Christmas2018_Tee_094_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_095_F","MP_Christmas2018_Tee_095_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_096_F","MP_Christmas2018_Tee_096_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_097_F","MP_Christmas2018_Tee_097_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_098_F","MP_Christmas2018_Tee_098_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_099_F","MP_Christmas2018_Tee_099_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_100_F","MP_Christmas2018_Tee_100_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_101_F","MP_Christmas2018_Tee_101_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_102_F","MP_Christmas2018_Tee_102_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_103_F","MP_Christmas2018_Tee_103_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_104_F","MP_Christmas2018_Tee_104_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_105_F","MP_Christmas2018_Tee_105_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_106_F","MP_Christmas2018_Tee_106_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_107_F","MP_Christmas2018_Tee_107_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_108_F","MP_Christmas2018_Tee_108_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_109_F","MP_Christmas2018_Tee_109_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_110_F","MP_Christmas2018_Tee_110_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_111_F","MP_Christmas2018_Tee_111_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_112_F","MP_Christmas2018_Tee_112_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_113_F","MP_Christmas2018_Tee_113_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_114_F","MP_Christmas2018_Tee_114_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_115_F","MP_Christmas2018_Tee_115_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_116_F","MP_Christmas2018_Tee_116_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_117_F","MP_Christmas2018_Tee_117_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_118_F","MP_Christmas2018_Tee_118_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_119_F","MP_Christmas2018_Tee_119_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_120_F","MP_Christmas2018_Tee_120_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_121_F","MP_Christmas2018_Tee_121_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_122_F","MP_Christmas2018_Tee_122_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_123_F","MP_Christmas2018_Tee_123_F"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_124_F","MP_Christmas2018_Tee_124_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_000_F","MP_Smuggler_Graphic_000_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_001_F","MP_Smuggler_Graphic_001_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_002_F","MP_Smuggler_Graphic_002_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_003_F","MP_Smuggler_Graphic_003_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_004_F","MP_Smuggler_Graphic_004_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_005_F","MP_Smuggler_Graphic_005_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_006_F","MP_Smuggler_Graphic_006_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_007_F","MP_Smuggler_Graphic_007_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_008_F","MP_Smuggler_Graphic_008_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_009_F","MP_Smuggler_Graphic_009_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_010_F","MP_Smuggler_Graphic_010_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_011_F","MP_Smuggler_Graphic_011_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_012_F","MP_Smuggler_Graphic_012_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_013_F","MP_Smuggler_Graphic_013_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_014_F","MP_Smuggler_Graphic_014_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_015_F","MP_Smuggler_Graphic_015_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_016_F","MP_Smuggler_Graphic_016_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_017_F","MP_Smuggler_Graphic_017_F"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_018_F","MP_Smuggler_Graphic_018_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_000_F","mpHeist3_Tee_000_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_001_F","mpHeist3_Tee_001_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_002_F","mpHeist3_Tee_002_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_003_F","mpHeist3_Tee_003_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_004_F","mpHeist3_Tee_004_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_005_F","mpHeist3_Tee_005_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_006_F","mpHeist3_Tee_006_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_007_F","mpHeist3_Tee_007_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_008_F","mpHeist3_Tee_008_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_009_F","mpHeist3_Tee_009_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_010_F","mpHeist3_Tee_010_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_011_F","mpHeist3_Tee_011_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_012_F","mpHeist3_Tee_012_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_013_F","mpHeist3_Tee_013_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_014_F","mpHeist3_Tee_014_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_015_F","mpHeist3_Tee_015_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_016_F","mpHeist3_Tee_016_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_017_F","mpHeist3_Tee_017_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_018_F","mpHeist3_Tee_018_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_019_F","mpHeist3_Tee_019_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_020_F","mpHeist3_Tee_020_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_021_F","mpHeist3_Tee_021_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_022_F","mpHeist3_Tee_022_F"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_023_F","mpHeist3_Tee_023_F"),
            new TShirt("mpchristmas3_overlays","MP_Christmas3_Tee_000_F","MP_Christmas3_Tee_000_F"),
            new TShirt("mpchristmas3_overlays","MP_Christmas3_Tee_001_F","MP_Christmas3_Tee_001_F"),
            new TShirt("mpsecurity_overlays","MP_Security_Tee_000_F","MP_Security_Tee_000_F"),
            new TShirt("mpsecurity_overlays","MP_Security_Tee_001_F","MP_Security_Tee_001_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_000_F","mpSum_Tee_000_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_001_F","mpSum_Tee_001_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_002_F","mpSum_Tee_002_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_003_F","mpSum_Tee_003_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_004_F","mpSum_Tee_004_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_005_F","mpSum_Tee_005_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_006_F","mpSum_Tee_006_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_007_F","mpSum_Tee_007_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_008_F","mpSum_Tee_008_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_009_F","mpSum_Tee_009_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_010_F","mpSum_Tee_010_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_011_F","mpSum_Tee_011_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_012_F","mpSum_Tee_012_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_013_F","mpSum_Tee_013_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_014_F","mpSum_Tee_014_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_015_F","mpSum_Tee_015_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_016_F","mpSum_Tee_016_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_017_F","mpSum_Tee_017_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_018_F","mpSum_Tee_018_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_019_F","mpSum_Tee_019_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_020_F","mpSum_Tee_020_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_021_F","mpSum_Tee_021_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_022_F","mpSum_Tee_022_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_023_F","mpSum_Tee_023_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_024_F","mpSum_Tee_024_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_025_F","mpSum_Tee_025_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_026_F","mpSum_Tee_026_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_027_F","mpSum_Tee_027_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_028_F","mpSum_Tee_028_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_029_F","mpSum_Tee_029_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_030_F","mpSum_Tee_030_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_031_F","mpSum_Tee_031_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_032_F","mpSum_Tee_032_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_033_F","mpSum_Tee_033_F"),
            new TShirt("mpsum_overlays","mpSum_Tee_034_F","mpSum_Tee_034_F"),
            new TShirt("mpsum2_overlays","MP_Sum2_Tee_000_F","MP_Sum2_Tee_000_F"),
            new TShirt("mpsum2_overlays","MP_Sum2_Tee_001_F","MP_Sum2_Tee_001_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_000_F","MP_Tuner_Tee_000_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_001_F","MP_Tuner_Tee_001_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_002_F","MP_Tuner_Tee_002_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_003_F","MP_Tuner_Tee_003_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_004_F","MP_Tuner_Tee_004_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_005_F","MP_Tuner_Tee_005_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_006_F","MP_Tuner_Tee_006_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_007_F","MP_Tuner_Tee_007_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_008_F","MP_Tuner_Tee_008_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_009_F","MP_Tuner_Tee_009_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_010_F","MP_Tuner_Tee_010_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_011_F","MP_Tuner_Tee_011_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_012_F","MP_Tuner_Tee_012_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_013_F","MP_Tuner_Tee_013_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_014_F","MP_Tuner_Tee_014_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_015_F","MP_Tuner_Tee_015_F"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_016_F","MP_Tuner_Tee_016_F")
        };
        public static List<TShirt> TShirtyMa = new List<TShirt>
        {
            new TShirt("mpheist_overlays","MP_Bugstar_C","MP_Bugstar_C"),
            new TShirt("mpheist_overlays","MP_Als_A","MP_Als_A"),
            new TShirt("mpheist_overlays","MP_Als_B","MP_Als_B"),
            new TShirt("mpheist_overlays","MP_Bugstar_A","MP_Bugstar_A"),
            new TShirt("mpheist_overlays","MP_Bugstar_B","MP_Bugstar_B"),
            new TShirt("mpheist_overlays","MP_Power_A","MP_Power_A"),
            new TShirt("mpheist_overlays","MP_Power_B","MP_Power_B"),
            new TShirt("mpheist_overlays","MP_Rogers_A","MP_Rogers_A"),
            new TShirt("mpheist_overlays","MP_Rogers_B","MP_Rogers_B"),
            new TShirt("multiplayer_overlays","mp_fm_branding_019","mp_fm_branding_019"),
            new TShirt("multiplayer_overlays","mp_fm_branding_025","mp_fm_branding_025"),
            new TShirt("multiplayer_overlays","mp_fm_branding_037","mp_fm_branding_037"),
            new TShirt("mphalloween_overlays","HW_Tee_000_M","HW_Tee_000_M"),
            new TShirt("mphalloween_overlays","HW_Tee_001_M","HW_Tee_001_M"),
            new TShirt("mphalloween_overlays","HW_Tee_002_M","HW_Tee_002_M"),
            new TShirt("mphalloween_overlays","HW_Tee_003_M","HW_Tee_003_M"),
            new TShirt("mphalloween_overlays","HW_Tee_004_M","HW_Tee_004_M"),
            new TShirt("mphalloween_overlays","HW_Tee_005_M","HW_Tee_005_M"),
            new TShirt("mphalloween_overlays","HW_Tee_006_M","HW_Tee_006_M"),
            new TShirt("mphalloween_overlays","HW_Tee_007_M","HW_Tee_007_M"),
            new TShirt("mphalloween_overlays","HW_Tee_008_M","HW_Tee_008_M"),
            new TShirt("mphalloween_overlays","HW_Tee_009_M","HW_Tee_009_M"),
            new TShirt("mphalloween_overlays","HW_Tee_010_M","HW_Tee_010_M"),
            new TShirt("mphalloween_overlays","HW_Tee_011_M","HW_Tee_011_M"),
            new TShirt("mphalloween_overlays","HW_Tee_012_M","HW_Tee_012_M"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_004","MP_Award_M_Tshirt_004"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_005","MP_Award_M_Tshirt_005"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_006","MP_Award_M_Tshirt_006"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_007","MP_Award_M_Tshirt_007"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_008","MP_Award_M_Tshirt_008"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_009","MP_Award_M_Tshirt_009"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_010","MP_Award_M_Tshirt_010"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_011","MP_Award_M_Tshirt_011"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_012","MP_Award_M_Tshirt_012"),
            new TShirt("mpheist_overlays","MP_Award_M_Tshirt_013","MP_Award_M_Tshirt_013"),
            new TShirt("mpheist_overlays","MP_Elite_M_Tshirt","MP_Elite_M_Tshirt"),
            new TShirt("mpheist_overlays","MP_Elite_M_Tshirt_1","MP_Elite_M_Tshirt_1"),
            new TShirt("mpheist_overlays","MP_Elite_M_Tshirt_2","MP_Elite_M_Tshirt_2"),
            new TShirt("mpheist_overlays","MP_Fli_M_Tshirt_000","MP_Fli_M_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_000","FM_Hip_M_Retro_000"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_001","FM_Hip_M_Retro_001"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_002","FM_Hip_M_Retro_002"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_003","FM_Hip_M_Retro_003"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_004","FM_Hip_M_Retro_004"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_005","FM_Hip_M_Retro_005"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_006","FM_Hip_M_Retro_006"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_007","FM_Hip_M_Retro_007"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_008","FM_Hip_M_Retro_008"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_009","FM_Hip_M_Retro_009"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_010","FM_Hip_M_Retro_010"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_011","FM_Hip_M_Retro_011"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_012","FM_Hip_M_Retro_012"),
            new TShirt("mphipster_overlays","FM_Hip_M_Retro_013","FM_Hip_M_Retro_013"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_000","FM_Hip_M_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_001","FM_Hip_M_Tshirt_001"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_002","FM_Hip_M_Tshirt_002"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_003","FM_Hip_M_Tshirt_003"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_004","FM_Hip_M_Tshirt_004"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_005","FM_Hip_M_Tshirt_005"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_006","FM_Hip_M_Tshirt_006"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_007","FM_Hip_M_Tshirt_007"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_008","FM_Hip_M_Tshirt_008"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_009","FM_Hip_M_Tshirt_009"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_010","FM_Hip_M_Tshirt_010"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_011","FM_Hip_M_Tshirt_011"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_012","FM_Hip_M_Tshirt_012"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_013","FM_Hip_M_Tshirt_013"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_014","FM_Hip_M_Tshirt_014"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_015","FM_Hip_M_Tshirt_015"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_016","FM_Hip_M_Tshirt_016"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_017","FM_Hip_M_Tshirt_017"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_018","FM_Hip_M_Tshirt_018"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_019","FM_Hip_M_Tshirt_019"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_020","FM_Hip_M_Tshirt_020"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_021","FM_Hip_M_Tshirt_021"),
            new TShirt("mphipster_overlays","FM_Hip_M_Tshirt_022","FM_Hip_M_Tshirt_022"),
            new TShirt("mphipster_overlays","FM_Rstar_M_Tshirt_000","FM_Rstar_M_Tshirt_000"),
            new TShirt("mphipster_overlays","FM_Rstar_M_Tshirt_001","FM_Rstar_M_Tshirt_001"),
            new TShirt("mphipster_overlays","FM_Rstar_M_Tshirt_002","FM_Rstar_M_Tshirt_002"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Award_000","FM_Ind_M_Award_000"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_000","FM_Ind_M_Tshirt_000"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_001","FM_Ind_M_Tshirt_001"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_002","FM_Ind_M_Tshirt_002"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_003","FM_Ind_M_Tshirt_003"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_004","FM_Ind_M_Tshirt_004"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_005","FM_Ind_M_Tshirt_005"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_006","FM_Ind_M_Tshirt_006"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_007","FM_Ind_M_Tshirt_007"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_008","FM_Ind_M_Tshirt_008"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_009","FM_Ind_M_Tshirt_009"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_010","FM_Ind_M_Tshirt_010"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_011","FM_Ind_M_Tshirt_011"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_012","FM_Ind_M_Tshirt_012"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_013","FM_Ind_M_Tshirt_013"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_014","FM_Ind_M_Tshirt_014"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_015","FM_Ind_M_Tshirt_015"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_016","FM_Ind_M_Tshirt_016"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_017","FM_Ind_M_Tshirt_017"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_018","FM_Ind_M_Tshirt_018"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_019","FM_Ind_M_Tshirt_019"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_020","FM_Ind_M_Tshirt_020"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_021","FM_Ind_M_Tshirt_021"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_022","FM_Ind_M_Tshirt_022"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_023","FM_Ind_M_Tshirt_023"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_024","FM_Ind_M_Tshirt_024"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_025","FM_Ind_M_Tshirt_025"),
            new TShirt("mpindependance_overlays","FM_Ind_M_Tshirt_026","FM_Ind_M_Tshirt_026"),
            new TShirt("mplowrider_overlays","MP_Bennys_000_M","MP_Bennys_000_M"),
            new TShirt("mplowrider_overlays","MP_Bennys_001_M","MP_Bennys_001_M"),
            new TShirt("mplowrider_overlays","MP_Broker_000_M","MP_Broker_000_M"),
            new TShirt("mplowrider_overlays","MP_Broker_001_M","MP_Broker_001_M"),
            new TShirt("mplowrider_overlays","MP_Broker_002_M","MP_Broker_002_M"),
            new TShirt("mplowrider_overlays","MP_Broker_003_M","MP_Broker_003_M"),
            new TShirt("mplowrider_overlays","MP_Broker_004_M","MP_Broker_004_M"),
            new TShirt("mplowrider_overlays","MP_Broker_005_M","MP_Broker_005_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_000_M","MP_Magnetics_000_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_001_M","MP_Magnetics_001_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_002_M","MP_Magnetics_002_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_003_M","MP_Magnetics_003_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_004_M","MP_Magnetics_004_M"),
            new TShirt("mplowrider_overlays","MP_Magnetics_005_M","MP_Magnetics_005_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_000_M","MP_Trickster_000_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_001_M","MP_Trickster_001_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_002_M","MP_Trickster_002_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_003_M","MP_Trickster_003_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_004_M","MP_Trickster_004_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_005_M","MP_Trickster_005_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_006_M","MP_Trickster_006_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_007_M","MP_Trickster_007_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_008_M","MP_Trickster_008_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_009_M","MP_Trickster_009_M"),
            new TShirt("mplowrider_overlays","MP_Trickster_010_M","MP_Trickster_010_M"),
            new TShirt("mplts_overlays","FM_LTS_M_Tshirt_000","FM_LTS_M_Tshirt_000"),
            new TShirt("mpluxe_overlays","MP_FAKE_DIS_000_M","MP_FAKE_DIS_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_DIS_001_M","MP_FAKE_DIS_001_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_DS_000_M","MP_FAKE_DS_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_ENEMA_000_M","MP_FAKE_ENEMA_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_LB_000_M","MP_FAKE_LB_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_LC_000_M","MP_FAKE_LC_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_Per_000_M","MP_FAKE_Per_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_SC_000_M","MP_FAKE_SC_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_SN_000_M","MP_FAKE_SN_000_M"),
            new TShirt("mpluxe_overlays","MP_FAKE_Vap_000_M","MP_FAKE_Vap_000_M"),
            new TShirt("mpluxe_overlays","MP_FILM_000_M","MP_FILM_000_M"),
            new TShirt("mpluxe_overlays","MP_FILM_001_M","MP_FILM_001_M"),
            new TShirt("mpluxe_overlays","MP_FILM_002_M","MP_FILM_002_M"),
            new TShirt("mpluxe_overlays","MP_FILM_003_M","MP_FILM_003_M"),
            new TShirt("mpluxe_overlays","MP_FILM_004_M","MP_FILM_004_M"),
            new TShirt("mpluxe_overlays","MP_FILM_005_M","MP_FILM_005_M"),
            new TShirt("mpluxe_overlays","MP_FILM_006_M","MP_FILM_006_M"),
            new TShirt("mpluxe_overlays","MP_FILM_007_M","MP_FILM_007_M"),
            new TShirt("mpluxe_overlays","MP_FILM_008_M","MP_FILM_008_M"),
            new TShirt("mpluxe_overlays","MP_FILM_009_M","MP_FILM_009_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_000_M","MP_LUXE_DIX_000_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_001_M","MP_LUXE_DIX_001_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_DIX_002_M","MP_LUXE_DIX_002_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_ENEMA_000_M","MP_LUXE_ENEMA_000_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_004_M","MP_LUXE_LC_004_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_005_M","MP_LUXE_LC_005_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_010_M","MP_LUXE_LC_010_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_LC_011_M","MP_LUXE_LC_011_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_Per_001_M","MP_LUXE_Per_001_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SC_000_M","MP_LUXE_SC_000_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_000_M","MP_LUXE_SN_000_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_001_M","MP_LUXE_SN_001_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_002_M","MP_LUXE_SN_002_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_003_M","MP_LUXE_SN_003_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_004_M","MP_LUXE_SN_004_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_005_M","MP_LUXE_SN_005_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_006_M","MP_LUXE_SN_006_M"),
            new TShirt("mpluxe_overlays","MP_LUXE_SN_007_M","MP_LUXE_SN_007_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_000_M","MP_LUXE_LC_000_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_001_M","MP_LUXE_LC_001_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_002_M","MP_LUXE_LC_002_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_003_M","MP_LUXE_LC_003_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_006_M","MP_LUXE_LC_006_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_007_M","MP_LUXE_LC_007_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_008_M","MP_LUXE_LC_008_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_009_M","MP_LUXE_LC_009_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_012_M","MP_LUXE_LC_012_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_013_M","MP_LUXE_LC_013_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_014_M","MP_LUXE_LC_014_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_LC_015_M","MP_LUXE_LC_015_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_000_M","MP_LUXE_VDG_000_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_001_M","MP_LUXE_VDG_001_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_002_M","MP_LUXE_VDG_002_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_004_M","MP_LUXE_VDG_004_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_005_M","MP_LUXE_VDG_005_M"),
            new TShirt("mpluxe2_overlays","MP_LUXE_VDG_006_M","MP_LUXE_VDG_006_M"),
            new TShirt("mppilot_overlays","MP_Fli_M_Tshirt_000","MP_Fli_M_Tshirt_000"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_A","MP_Val_M_Tshirt_A"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_B","MP_Val_M_Tshirt_B"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_C","MP_Val_M_Tshirt_C"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_D","MP_Val_M_Tshirt_D"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_E","MP_Val_M_Tshirt_E"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_F","MP_Val_M_Tshirt_F"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_G","MP_Val_M_Tshirt_G"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_H","MP_Val_M_Tshirt_H"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_I","MP_Val_M_Tshirt_I"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_J","MP_Val_M_Tshirt_J"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_K","MP_Val_M_Tshirt_K"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_L","MP_Val_M_Tshirt_L"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_M","MP_Val_M_Tshirt_M"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_N","MP_Val_M_Tshirt_N"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_O","MP_Val_M_Tshirt_O"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_P","MP_Val_M_Tshirt_P"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_Q","MP_Val_M_Tshirt_Q"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_R","MP_Val_M_Tshirt_R"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_S","MP_Val_M_Tshirt_S"),
            new TShirt("mpvalentines_overlays","MP_Val_M_Tshirt_T","MP_Val_M_Tshirt_T"),
            new TShirt("mpxmas_604490_overlays","MP_IHeartLC_000_M","MP_IHeartLC_000_M"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_A","FM_CREW_M_000_A"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_B","FM_CREW_M_000_B"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_C","FM_CREW_M_000_C"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_D","FM_CREW_M_000_D"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_E","FM_CREW_M_000_E"),
            new TShirt("multiplayer_overlays","FM_CREW_M_000_F","FM_CREW_M_000_F"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_000","FM_Tshirt_Award_000"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_001","FM_Tshirt_Award_001"),
            new TShirt("multiplayer_overlays","FM_Tshirt_Award_002","FM_Tshirt_Award_002"),
            new TShirt("multiplayer_overlays","mp_fm_branding_001","mp_fm_branding_001"),
            new TShirt("multiplayer_overlays","mp_fm_branding_002","mp_fm_branding_002"),
            new TShirt("multiplayer_overlays","mp_fm_branding_003","mp_fm_branding_003"),
            new TShirt("multiplayer_overlays","mp_fm_branding_004","mp_fm_branding_004"),
            new TShirt("multiplayer_overlays","mp_fm_branding_005","mp_fm_branding_005"),
            new TShirt("multiplayer_overlays","mp_fm_branding_006","mp_fm_branding_006"),
            new TShirt("multiplayer_overlays","mp_fm_branding_007","mp_fm_branding_007"),
            new TShirt("multiplayer_overlays","mp_fm_branding_008","mp_fm_branding_008"),
            new TShirt("multiplayer_overlays","mp_fm_branding_009","mp_fm_branding_009"),
            new TShirt("multiplayer_overlays","mp_fm_branding_010","mp_fm_branding_010"),
            new TShirt("multiplayer_overlays","mp_fm_branding_011","mp_fm_branding_011"),
            new TShirt("multiplayer_overlays","mp_fm_branding_012","mp_fm_branding_012"),
            new TShirt("multiplayer_overlays","mp_fm_branding_013","mp_fm_branding_013"),
            new TShirt("multiplayer_overlays","mp_fm_branding_014","mp_fm_branding_014"),
            new TShirt("multiplayer_overlays","mp_fm_branding_015","mp_fm_branding_015"),
            new TShirt("multiplayer_overlays","mp_fm_branding_016","mp_fm_branding_016"),
            new TShirt("multiplayer_overlays","mp_fm_branding_017","mp_fm_branding_017"),
            new TShirt("multiplayer_overlays","mp_fm_branding_018","mp_fm_branding_018"),
            new TShirt("multiplayer_overlays","mp_fm_branding_020","mp_fm_branding_020"),
            new TShirt("multiplayer_overlays","mp_fm_branding_022","mp_fm_branding_022"),
            new TShirt("multiplayer_overlays","mp_fm_branding_023","mp_fm_branding_023"),
            new TShirt("multiplayer_overlays","mp_fm_branding_024","mp_fm_branding_024"),
            new TShirt("multiplayer_overlays","mp_fm_branding_027","mp_fm_branding_027"),
            new TShirt("multiplayer_overlays","mp_fm_branding_028","mp_fm_branding_028"),
            new TShirt("multiplayer_overlays","mp_fm_branding_029","mp_fm_branding_029"),
            new TShirt("multiplayer_overlays","mp_fm_branding_031","mp_fm_branding_031"),
            new TShirt("multiplayer_overlays","mp_fm_branding_032","mp_fm_branding_032"),
            new TShirt("multiplayer_overlays","mp_fm_branding_034","mp_fm_branding_034"),
            new TShirt("multiplayer_overlays","mp_fm_branding_035","mp_fm_branding_035"),
            new TShirt("multiplayer_overlays","mp_fm_branding_036","mp_fm_branding_036"),
            new TShirt("multiplayer_overlays","mp_fm_branding_038","mp_fm_branding_038"),
            new TShirt("multiplayer_overlays","mp_fm_branding_039","mp_fm_branding_039"),
            new TShirt("multiplayer_overlays","mp_fm_branding_040","mp_fm_branding_040"),
            new TShirt("multiplayer_overlays","mp_fm_branding_041","mp_fm_branding_041"),
            new TShirt("multiplayer_overlays","mp_fm_branding_042","mp_fm_branding_042"),
            new TShirt("multiplayer_overlays","mp_fm_branding_043","mp_fm_branding_043"),
            new TShirt("multiplayer_overlays","mp_fm_branding_044","mp_fm_branding_044"),
            new TShirt("multiplayer_overlays","mp_fm_branding_045","mp_fm_branding_045"),
            new TShirt("multiplayer_overlays","mp_fm_branding_046","mp_fm_branding_046"),
            new TShirt("multiplayer_overlays","mp_fm_branding_047","mp_fm_branding_047"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_000_m","mp_fm_OGA_000_m"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_001_m","mp_fm_OGA_001_m"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_002_m","mp_fm_OGA_002_m"),
            new TShirt("multiplayer_overlays","mp_fm_OGA_003_m","mp_fm_OGA_003_m"),
            new TShirt("mplowrider2_overlays","MP_Chianski_000_M","MP_Chianski_000_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_001_M","MP_Chianski_001_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_002_M","MP_Chianski_002_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_003_M","MP_Chianski_003_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_004_M","MP_Chianski_004_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_005_M","MP_Chianski_005_M"),
            new TShirt("mplowrider2_overlays","MP_Chianski_006_M","MP_Chianski_006_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_000_M","MP_Hntr_000_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_001_M","MP_Hntr_001_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_002_M","MP_Hntr_002_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_003_M","MP_Hntr_003_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_004_M","MP_Hntr_004_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_005_M","MP_Hntr_005_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_006_M","MP_Hntr_006_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_007_M","MP_Hntr_007_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_008_M","MP_Hntr_008_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_009_M","MP_Hntr_009_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_010_M","MP_Hntr_010_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_011_M","MP_Hntr_011_M"),
            new TShirt("mplowrider2_overlays","MP_Hntr_012_M","MP_Hntr_012_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_000_M","MP_Dense_000_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_001_M","MP_Dense_001_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_002_M","MP_Dense_002_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_003_M","MP_Dense_003_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_004_M","MP_Dense_004_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_005_M","MP_Dense_005_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_006_M","MP_Dense_006_M"),
            new TShirt("mplowrider2_overlays","MP_Dense_007_M","MP_Dense_007_M"),
            new TShirt("mpexecutive_overlays","MP_Securoserv_000_M","MP_Securoserv_000_M"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_000_M","MP_exec_teams_000_M"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_001_M","MP_exec_teams_001_M"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_002_M","MP_exec_teams_002_M"),
            new TShirt("mpexecutive_overlays","MP_exec_teams_003_M","MP_exec_teams_003_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_000_M","MP_exec_prizes_000_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_001_M","MP_exec_prizes_001_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_002_M","MP_exec_prizes_002_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_003_M","MP_exec_prizes_003_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_004_M","MP_exec_prizes_004_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_005_M","MP_exec_prizes_005_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_006_M","MP_exec_prizes_006_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_007_M","MP_exec_prizes_007_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_008_M","MP_exec_prizes_008_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_009_M","MP_exec_prizes_009_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_010_M","MP_exec_prizes_010_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_011_M","MP_exec_prizes_011_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_012_M","MP_exec_prizes_012_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_013_M","MP_exec_prizes_013_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_014_M","MP_exec_prizes_014_M"),
            new TShirt("mpexecutive_overlays","MP_exec_prizes_015_M","MP_exec_prizes_015_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Award_000_M","MP_Biker_Award_000_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Award_001_M","MP_Biker_Award_001_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_000_M","MP_Biker_Rank_000_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_001_M","MP_Biker_Rank_001_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_002_M","MP_Biker_Rank_002_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_003_M","MP_Biker_Rank_003_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_004_M","MP_Biker_Rank_004_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_005_M","MP_Biker_Rank_005_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_006_M","MP_Biker_Rank_006_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_007_M","MP_Biker_Rank_007_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_008_M","MP_Biker_Rank_008_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_009_M","MP_Biker_Rank_009_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_010_M","MP_Biker_Rank_010_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_011_M","MP_Biker_Rank_011_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_012_M","MP_Biker_Rank_012_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_013_M","MP_Biker_Rank_013_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_014_M","MP_Biker_Rank_014_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_015_M","MP_Biker_Rank_015_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_016_M","MP_Biker_Rank_016_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Rank_017_M","MP_Biker_Rank_017_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_000_M","MP_Biker_Tee_000_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_001_M","MP_Biker_Tee_001_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_002_M","MP_Biker_Tee_002_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_003_M","MP_Biker_Tee_003_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_004_M","MP_Biker_Tee_004_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_005_M","MP_Biker_Tee_005_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_006_M","MP_Biker_Tee_006_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_007_M","MP_Biker_Tee_007_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_008_M","MP_Biker_Tee_008_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_009_M","MP_Biker_Tee_009_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_010_M","MP_Biker_Tee_010_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_011_M","MP_Biker_Tee_011_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_012_M","MP_Biker_Tee_012_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_013_M","MP_Biker_Tee_013_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_014_M","MP_Biker_Tee_014_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_015_M","MP_Biker_Tee_015_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_016_M","MP_Biker_Tee_016_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_017_M","MP_Biker_Tee_017_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_018_M","MP_Biker_Tee_018_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_019_M","MP_Biker_Tee_019_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_020_M","MP_Biker_Tee_020_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_021_M","MP_Biker_Tee_021_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_022_M","MP_Biker_Tee_022_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_023_M","MP_Biker_Tee_023_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_024_M","MP_Biker_Tee_024_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_025_M","MP_Biker_Tee_025_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_026_M","MP_Biker_Tee_026_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_027_M","MP_Biker_Tee_027_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_028_M","MP_Biker_Tee_028_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_029_M","MP_Biker_Tee_029_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_030_M","MP_Biker_Tee_030_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_031_M","MP_Biker_Tee_031_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_032_M","MP_Biker_Tee_032_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_033_M","MP_Biker_Tee_033_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_034_M","MP_Biker_Tee_034_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_035_M","MP_Biker_Tee_035_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_036_M","MP_Biker_Tee_036_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_037_M","MP_Biker_Tee_037_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_038_M","MP_Biker_Tee_038_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_039_M","MP_Biker_Tee_039_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_040_M","MP_Biker_Tee_040_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_041_M","MP_Biker_Tee_041_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_042_M","MP_Biker_Tee_042_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_043_M","MP_Biker_Tee_043_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_044_M","MP_Biker_Tee_044_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_045_M","MP_Biker_Tee_045_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_046_M","MP_Biker_Tee_046_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_047_M","MP_Biker_Tee_047_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_048_M","MP_Biker_Tee_048_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_049_M","MP_Biker_Tee_049_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_050_M","MP_Biker_Tee_050_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_051_M","MP_Biker_Tee_051_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_052_M","MP_Biker_Tee_052_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_053_M","MP_Biker_Tee_053_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_054_M","MP_Biker_Tee_054_M"),
            new TShirt("mpbiker_overlays","MP_Biker_Tee_055_M","MP_Biker_Tee_055_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_000_M","MP_Gunrunning_Award_000_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_001_M","MP_Gunrunning_Award_001_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_002_M","MP_Gunrunning_Award_002_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_003_M","MP_Gunrunning_Award_003_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_004_M","MP_Gunrunning_Award_004_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_005_M","MP_Gunrunning_Award_005_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_006_M","MP_Gunrunning_Award_006_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_007_M","MP_Gunrunning_Award_007_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_008_M","MP_Gunrunning_Award_008_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_009_M","MP_Gunrunning_Award_009_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_010_M","MP_Gunrunning_Award_010_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_011_M","MP_Gunrunning_Award_011_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_012_M","MP_Gunrunning_Award_012_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_013_M","MP_Gunrunning_Award_013_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_014_M","MP_Gunrunning_Award_014_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_015_M","MP_Gunrunning_Award_015_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_016_M","MP_Gunrunning_Award_016_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_017_M","MP_Gunrunning_Award_017_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_018_M","MP_Gunrunning_Award_018_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_019_M","MP_Gunrunning_Award_019_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_020_M","MP_Gunrunning_Award_020_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_021_M","MP_Gunrunning_Award_021_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_022_M","MP_Gunrunning_Award_022_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_023_M","MP_Gunrunning_Award_023_M"),
            new TShirt("mpgunrunning_overlays","MP_Gunrunning_Award_024_M","MP_Gunrunning_Award_024_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_000_M","MP_Battle_Clothing_000_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_001_M","MP_Battle_Clothing_001_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_002_M","MP_Battle_Clothing_002_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_003_M","MP_Battle_Clothing_003_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_004_M","MP_Battle_Clothing_004_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_005_M","MP_Battle_Clothing_005_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_006_M","MP_Battle_Clothing_006_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_007_M","MP_Battle_Clothing_007_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_008_M","MP_Battle_Clothing_008_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_009_M","MP_Battle_Clothing_009_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_010_M","MP_Battle_Clothing_010_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_011_M","MP_Battle_Clothing_011_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_012_M","MP_Battle_Clothing_012_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_013_M","MP_Battle_Clothing_013_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_014_M","MP_Battle_Clothing_014_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_015_M","MP_Battle_Clothing_015_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_016_M","MP_Battle_Clothing_016_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_017_M","MP_Battle_Clothing_017_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_018_M","MP_Battle_Clothing_018_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_019_M","MP_Battle_Clothing_019_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_020_M","MP_Battle_Clothing_020_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_021_M","MP_Battle_Clothing_021_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_022_M","MP_Battle_Clothing_022_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_023_M","MP_Battle_Clothing_023_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_024_M","MP_Battle_Clothing_024_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_025_M","MP_Battle_Clothing_025_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_026_M","MP_Battle_Clothing_026_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_027_M","MP_Battle_Clothing_027_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_028_M","MP_Battle_Clothing_028_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_029_M","MP_Battle_Clothing_029_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_030_M","MP_Battle_Clothing_030_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_031_M","MP_Battle_Clothing_031_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_032_M","MP_Battle_Clothing_032_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_033_M","MP_Battle_Clothing_033_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_034_M","MP_Battle_Clothing_034_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_035_M","MP_Battle_Clothing_035_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_036_M","MP_Battle_Clothing_036_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_037_M","MP_Battle_Clothing_037_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_038_M","MP_Battle_Clothing_038_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_039_M","MP_Battle_Clothing_039_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_040_M","MP_Battle_Clothing_040_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_041_M","MP_Battle_Clothing_041_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_042_M","MP_Battle_Clothing_042_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_043_M","MP_Battle_Clothing_043_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_044_M","MP_Battle_Clothing_044_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_045_M","MP_Battle_Clothing_045_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_046_M","MP_Battle_Clothing_046_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_047_M","MP_Battle_Clothing_047_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_048_M","MP_Battle_Clothing_048_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_049_M","MP_Battle_Clothing_049_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_050_M","MP_Battle_Clothing_050_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_051_M","MP_Battle_Clothing_051_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_052_M","MP_Battle_Clothing_052_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_053_M","MP_Battle_Clothing_053_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_054_M","MP_Battle_Clothing_054_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_055_M","MP_Battle_Clothing_055_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_056_M","MP_Battle_Clothing_056_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_057_M","MP_Battle_Clothing_057_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_058_M","MP_Battle_Clothing_058_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_059_M","MP_Battle_Clothing_059_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_060_M","MP_Battle_Clothing_060_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_061_M","MP_Battle_Clothing_061_M"),
            new TShirt("mpbattle_overlays","MP_Battle_Clothing_062_M","MP_Battle_Clothing_062_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_000_M","MP_Christmas2018_Tee_000_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_001_M","MP_Christmas2018_Tee_001_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_002_M","MP_Christmas2018_Tee_002_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_003_M","MP_Christmas2018_Tee_003_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_004_M","MP_Christmas2018_Tee_004_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_005_M","MP_Christmas2018_Tee_005_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_006_M","MP_Christmas2018_Tee_006_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_007_M","MP_Christmas2018_Tee_007_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_008_M","MP_Christmas2018_Tee_008_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_009_M","MP_Christmas2018_Tee_009_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_010_M","MP_Christmas2018_Tee_010_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_011_M","MP_Christmas2018_Tee_011_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_012_M","MP_Christmas2018_Tee_012_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_013_M","MP_Christmas2018_Tee_013_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_014_M","MP_Christmas2018_Tee_014_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_015_M","MP_Christmas2018_Tee_015_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_016_M","MP_Christmas2018_Tee_016_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_017_M","MP_Christmas2018_Tee_017_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_018_M","MP_Christmas2018_Tee_018_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_019_M","MP_Christmas2018_Tee_019_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_020_M","MP_Christmas2018_Tee_020_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_021_M","MP_Christmas2018_Tee_021_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_022_M","MP_Christmas2018_Tee_022_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_023_M","MP_Christmas2018_Tee_023_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_024_M","MP_Christmas2018_Tee_024_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_025_M","MP_Christmas2018_Tee_025_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_026_M","MP_Christmas2018_Tee_026_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_027_M","MP_Christmas2018_Tee_027_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_028_M","MP_Christmas2018_Tee_028_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_029_M","MP_Christmas2018_Tee_029_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_030_M","MP_Christmas2018_Tee_030_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_031_M","MP_Christmas2018_Tee_031_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_032_M","MP_Christmas2018_Tee_032_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_033_M","MP_Christmas2018_Tee_033_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_034_M","MP_Christmas2018_Tee_034_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_035_M","MP_Christmas2018_Tee_035_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_036_M","MP_Christmas2018_Tee_036_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_037_M","MP_Christmas2018_Tee_037_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_038_M","MP_Christmas2018_Tee_038_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_039_M","MP_Christmas2018_Tee_039_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_040_M","MP_Christmas2018_Tee_040_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_041_M","MP_Christmas2018_Tee_041_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_042_M","MP_Christmas2018_Tee_042_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_043_M","MP_Christmas2018_Tee_043_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_044_M","MP_Christmas2018_Tee_044_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_045_M","MP_Christmas2018_Tee_045_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_046_M","MP_Christmas2018_Tee_046_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_047_M","MP_Christmas2018_Tee_047_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_048_M","MP_Christmas2018_Tee_048_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_049_M","MP_Christmas2018_Tee_049_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_050_M","MP_Christmas2018_Tee_050_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_051_M","MP_Christmas2018_Tee_051_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_052_M","MP_Christmas2018_Tee_052_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_053_M","MP_Christmas2018_Tee_053_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_054_M","MP_Christmas2018_Tee_054_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_055_M","MP_Christmas2018_Tee_055_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_056_M","MP_Christmas2018_Tee_056_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_057_M","MP_Christmas2018_Tee_057_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_058_M","MP_Christmas2018_Tee_058_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_059_M","MP_Christmas2018_Tee_059_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_060_M","MP_Christmas2018_Tee_060_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_061_M","MP_Christmas2018_Tee_061_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_062_M","MP_Christmas2018_Tee_062_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_063_M","MP_Christmas2018_Tee_063_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_064_M","MP_Christmas2018_Tee_064_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_065_M","MP_Christmas2018_Tee_065_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_066_M","MP_Christmas2018_Tee_066_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_067_M","MP_Christmas2018_Tee_067_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_068_M","MP_Christmas2018_Tee_068_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_069_M","MP_Christmas2018_Tee_069_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_070_M","MP_Christmas2018_Tee_070_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_071_M","MP_Christmas2018_Tee_071_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_072_M","MP_Christmas2018_Tee_072_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_073_M","MP_Christmas2018_Tee_073_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_074_M","MP_Christmas2018_Tee_074_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_075_M","MP_Christmas2018_Tee_075_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_076_M","MP_Christmas2018_Tee_076_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_077_M","MP_Christmas2018_Tee_077_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_078_M","MP_Christmas2018_Tee_078_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_079_M","MP_Christmas2018_Tee_079_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_080_M","MP_Christmas2018_Tee_080_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_081_M","MP_Christmas2018_Tee_081_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_082_M","MP_Christmas2018_Tee_082_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_083_M","MP_Christmas2018_Tee_083_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_084_M","MP_Christmas2018_Tee_084_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_085_M","MP_Christmas2018_Tee_085_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_086_M","MP_Christmas2018_Tee_086_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_087_M","MP_Christmas2018_Tee_087_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_088_M","MP_Christmas2018_Tee_088_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_089_M","MP_Christmas2018_Tee_089_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_090_M","MP_Christmas2018_Tee_090_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_091_M","MP_Christmas2018_Tee_091_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_092_M","MP_Christmas2018_Tee_092_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_093_M","MP_Christmas2018_Tee_093_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_094_M","MP_Christmas2018_Tee_094_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_095_M","MP_Christmas2018_Tee_095_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_096_M","MP_Christmas2018_Tee_096_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_097_M","MP_Christmas2018_Tee_097_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_098_M","MP_Christmas2018_Tee_098_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_099_M","MP_Christmas2018_Tee_099_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_100_M","MP_Christmas2018_Tee_100_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_101_M","MP_Christmas2018_Tee_101_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_102_M","MP_Christmas2018_Tee_102_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_103_M","MP_Christmas2018_Tee_103_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_104_M","MP_Christmas2018_Tee_104_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_105_M","MP_Christmas2018_Tee_105_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_106_M","MP_Christmas2018_Tee_106_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_107_M","MP_Christmas2018_Tee_107_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_108_M","MP_Christmas2018_Tee_108_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_109_M","MP_Christmas2018_Tee_109_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_110_M","MP_Christmas2018_Tee_110_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_111_M","MP_Christmas2018_Tee_111_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_112_M","MP_Christmas2018_Tee_112_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_113_M","MP_Christmas2018_Tee_113_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_114_M","MP_Christmas2018_Tee_114_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_115_M","MP_Christmas2018_Tee_115_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_116_M","MP_Christmas2018_Tee_116_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_117_M","MP_Christmas2018_Tee_117_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_118_M","MP_Christmas2018_Tee_118_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_119_M","MP_Christmas2018_Tee_119_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_120_M","MP_Christmas2018_Tee_120_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_121_M","MP_Christmas2018_Tee_121_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_122_M","MP_Christmas2018_Tee_122_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_123_M","MP_Christmas2018_Tee_123_M"),
            new TShirt("mpchristmas2018_overlays","MP_Christmas2018_Tee_124_M","MP_Christmas2018_Tee_124_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_000_M","MP_Smuggler_Graphic_000_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_001_M","MP_Smuggler_Graphic_001_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_002_M","MP_Smuggler_Graphic_002_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_003_M","MP_Smuggler_Graphic_003_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_004_M","MP_Smuggler_Graphic_004_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_005_M","MP_Smuggler_Graphic_005_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_006_M","MP_Smuggler_Graphic_006_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_007_M","MP_Smuggler_Graphic_007_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_008_M","MP_Smuggler_Graphic_008_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_009_M","MP_Smuggler_Graphic_009_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_010_M","MP_Smuggler_Graphic_010_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_011_M","MP_Smuggler_Graphic_011_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_012_M","MP_Smuggler_Graphic_012_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_013_M","MP_Smuggler_Graphic_013_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_014_M","MP_Smuggler_Graphic_014_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_015_M","MP_Smuggler_Graphic_015_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_016_M","MP_Smuggler_Graphic_016_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_017_M","MP_Smuggler_Graphic_017_M"),
            new TShirt("mpsmuggler_overlays","MP_Smuggler_Graphic_018_M","MP_Smuggler_Graphic_018_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_000_M","mpHeist3_Tee_000_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_001_M","mpHeist3_Tee_001_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_002_M","mpHeist3_Tee_002_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_003_M","mpHeist3_Tee_003_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_004_M","mpHeist3_Tee_004_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_005_M","mpHeist3_Tee_005_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_006_M","mpHeist3_Tee_006_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_007_M","mpHeist3_Tee_007_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_008_M","mpHeist3_Tee_008_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_009_M","mpHeist3_Tee_009_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_010_M","mpHeist3_Tee_010_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_011_M","mpHeist3_Tee_011_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_012_M","mpHeist3_Tee_012_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_013_M","mpHeist3_Tee_013_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_014_M","mpHeist3_Tee_014_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_015_M","mpHeist3_Tee_015_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_016_M","mpHeist3_Tee_016_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_017_M","mpHeist3_Tee_017_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_018_M","mpHeist3_Tee_018_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_019_M","mpHeist3_Tee_019_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_020_M","mpHeist3_Tee_020_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_021_M","mpHeist3_Tee_021_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_022_M","mpHeist3_Tee_022_M"),
            new TShirt("mpheist3_overlays","mpHeist3_Tee_023_M","mpHeist3_Tee_023_M"),
            new TShirt("mpchristmas3_overlays","MP_Christmas3_Tee_000_M","MP_Christmas3_Tee_000_M"),
            new TShirt("mpchristmas3_overlays","MP_Christmas3_Tee_001_M","MP_Christmas3_Tee_001_M"),
            new TShirt("mpsecurity_overlays","MP_Security_Tee_000_M","MP_Security_Tee_000_M"),
            new TShirt("mpsecurity_overlays","MP_Security_Tee_001_M","MP_Security_Tee_001_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_000_M","mpSum_Tee_000_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_001_M","mpSum_Tee_001_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_002_M","mpSum_Tee_002_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_003_M","mpSum_Tee_003_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_004_M","mpSum_Tee_004_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_005_M","mpSum_Tee_005_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_006_M","mpSum_Tee_006_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_007_M","mpSum_Tee_007_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_008_M","mpSum_Tee_008_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_009_M","mpSum_Tee_009_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_010_M","mpSum_Tee_010_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_011_M","mpSum_Tee_011_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_012_M","mpSum_Tee_012_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_013_M","mpSum_Tee_013_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_014_M","mpSum_Tee_014_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_015_M","mpSum_Tee_015_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_016_M","mpSum_Tee_016_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_017_M","mpSum_Tee_017_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_018_M","mpSum_Tee_018_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_019_M","mpSum_Tee_019_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_020_M","mpSum_Tee_020_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_021_M","mpSum_Tee_021_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_022_M","mpSum_Tee_022_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_023_M","mpSum_Tee_023_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_024_M","mpSum_Tee_024_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_025_M","mpSum_Tee_025_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_026_M","mpSum_Tee_026_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_027_M","mpSum_Tee_027_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_028_M","mpSum_Tee_028_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_029_M","mpSum_Tee_029_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_030_M","mpSum_Tee_030_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_031_M","mpSum_Tee_031_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_032_M","mpSum_Tee_032_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_033_M","mpSum_Tee_033_M"),
            new TShirt("mpsum_overlays","mpSum_Tee_034_M","mpSum_Tee_034_M"),
            new TShirt("mpsum2_overlays","MP_Sum2_Tee_000_M","MP_Sum2_Tee_000_M"),
            new TShirt("mpsum2_overlays","MP_Sum2_Tee_001_M","MP_Sum2_Tee_001_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_000_M","MP_Tuner_Tee_000_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_001_M","MP_Tuner_Tee_001_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_002_M","MP_Tuner_Tee_002_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_003_M","MP_Tuner_Tee_003_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_004_M","MP_Tuner_Tee_004_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_005_M","MP_Tuner_Tee_005_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_006_M","MP_Tuner_Tee_006_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_007_M","MP_Tuner_Tee_007_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_008_M","MP_Tuner_Tee_008_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_009_M","MP_Tuner_Tee_009_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_010_M","MP_Tuner_Tee_010_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_011_M","MP_Tuner_Tee_011_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_012_M","MP_Tuner_Tee_012_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_013_M","MP_Tuner_Tee_013_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_014_M","MP_Tuner_Tee_014_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_015_M","MP_Tuner_Tee_015_M"),
            new TShirt("mptuner_overlays","MP_Tuner_Tee_016_M","MP_Tuner_Tee_016_M")
        };

        public static bool GetMainChar()
        {
            bool bYes = false;
            if (Game.Player.Character.Model == PedHash.Franklin || Game.Player.Character.Model == PedHash.Michael || Game.Player.Character.Model == PedHash.Trevor)
                bYes = true;
            return bYes;
        }
        private static List<int> BuildStartsList()
        {
            LoggerLight.Loggers("BuildStartsList");

            List<int> iSel = new List<int>();

            for (int i = 1; i < 26; i++)
                iSel.Add(i);

            return iSel;
        }
        public static int RandomSeletor()
        {
            int iYourSell = -1;
            List<int> Starters = BuildStartsList();

            if (!DataStore.MySettingsXML.BeachPed)
                Starters.Remove(1);
            if (!DataStore.MySettingsXML.Tramps)
                Starters.Remove(2);
            if (!DataStore.MySettingsXML.Highclass)
                Starters.Remove(3);
            if (!DataStore.MySettingsXML.Midclass)
                Starters.Remove(4);
            if (!DataStore.MySettingsXML.Lowclass)
                Starters.Remove(5);
            if (!DataStore.MySettingsXML.Business)
                Starters.Remove(6);
            if (!DataStore.MySettingsXML.Bodybuilder)
                Starters.Remove(7);
            if (!DataStore.MySettingsXML.GangStars)
                Starters.Remove(8);
            if (!DataStore.MySettingsXML.Epsilon)
                Starters.Remove(9);
            if (!DataStore.MySettingsXML.Jogger)
                Starters.Remove(10);
            if (!DataStore.MySettingsXML.Golfer)
                Starters.Remove(11);
            if (!DataStore.MySettingsXML.Hiker)
                Starters.Remove(12);
            if (!DataStore.MySettingsXML.Methaddict)
                Starters.Remove(13);
            if (!DataStore.MySettingsXML.Rural)
                Starters.Remove(14);
            if (!DataStore.MySettingsXML.Cyclist)
                Starters.Remove(15);
            if (!DataStore.MySettingsXML.LGBTWXYZ)
                Starters.Remove(16);
            if (!DataStore.MySettingsXML.PoolPeds)
                Starters.Remove(17);
            if (!DataStore.MySettingsXML.Workers)
                Starters.Remove(18);
            if (!DataStore.MySettingsXML.Jetski)
                Starters.Remove(19);
            if (!DataStore.MySettingsXML.BikeATV)
                Starters.Remove(20);
            if (!DataStore.MySettingsXML.Services)
                Starters.Remove(21);
            if (!DataStore.MySettingsXML.Pilot)
                Starters.Remove(22);
            if (!DataStore.MySettingsXML.Animals)
                Starters.Remove(23);
            if (!DataStore.MySettingsXML.Yankton)
                Starters.Remove(24);
            if (!DataStore.MySettingsXML.Cayo)
                Starters.Remove(25);

            if (Starters.Count < 1)
                DataStore.MySettingsXML.Locate = false;
            else
                iYourSell = RandomX.FindRandomList("StartTypeSelect", Starters);

            return iYourSell;
        }
        public static bool WhileButtonDown(int CButt, bool bDisable)
        {
            if (bDisable)
                RsActions.ButtonDisabler(CButt); ;

            bool bButt = Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);

            if (bButt)
            {
                while (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, 0, CButt))
                    Script.Wait(1);
            }

            return bButt;
        }
        public static bool ButtonDown(int CButt, bool bDisable)
        {
            if (bDisable)
                RsActions.ButtonDisabler(CButt);
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, 0, CButt);
        }
        public static int GetButtonDown()
        {
            int iB = -1;
            for (int i = 0; i < DataStore.ControlerList.Count; i++)
            {
                Script.Wait(100);
                if (ButtonDown(i,true))
                {
                    iB = i;
                    break;
                }
            }
            return iB;
        }
        public static int Mk2AmmoFix(string sWeapo)
        {
            int iAmmo = 0;
            Ped Peddy = Game.Player.Character;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeapo);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }

            return iAmmo;
        }
        public static int MaxAmmo(string sWeap, Ped Peddy)
        {
            int iAmmo = 0;
            int iWeap = Function.Call<int>(Hash.GET_HASH_KEY, sWeap);

            unsafe
            {
                Function.Call<bool>(Hash.GET_MAX_AMMO, Peddy.Handle, iWeap, &iAmmo);
            }
            return iAmmo;
        }
        public static string BuildRandVeh(int iList, int iSubSet)
        {
            LoggerLight.Loggers("BuildRandVeh, iList == " + iList + ", iSubSet == " + iSubSet);

            List<string> sVeh = new List<string>();
            string sVehc = "";

            if (iList == 1)
            {
                sVeh.Add("JETMAX"); //>
                sVeh.Add("MARQUIS"); //>
                sVeh.Add("SPEEDER"); //>
                sVeh.Add("SPEEDER2"); //><!-- Speeder yacht variant -->
                sVeh.Add("SQUALO"); //>
                sVeh.Add("SUNTRAP"); //>
                sVeh.Add("TORO"); //>
                sVeh.Add("TORO2"); //><!-- Toro yacht variant -->
                sVeh.Add("TROPIC"); //>
                sVeh.Add("TROPIC2"); //><!-- Tropic yacht variant -->
                if (!DataStore.bDisableDLCVeh)
                {
                    sVeh.Add("AVISA"); //><!-- Kraken Avisa -->
                    sVeh.Add("LONGFIN"); //><!-- Shitzu Longfin -->
                }
            }
            else if (iList == 3)
            {
                sVeh.Add("PFISTER811"); //><!-- 811 -->
                sVeh.Add("ADDER"); //>
                sVeh.Add("AUTARCH"); //>
                sVeh.Add("BANSHEE2"); //><!-- Banshee 900R -->
                sVeh.Add("BULLET"); //>
                sVeh.Add("CHEETAH"); //>
                sVeh.Add("CYCLONE"); //>
                sVeh.Add("ENTITYXF"); //>
                sVeh.Add("ENTITY2"); //><!-- Entity XXR -->
                sVeh.Add("SHEAVA"); //><!-- ETR1 -->
                sVeh.Add("FMJ"); //>
                sVeh.Add("GP1"); //>
                sVeh.Add("INFERNUS"); //>
                sVeh.Add("ITALIGTB"); //>
                sVeh.Add("ITALIGTB2"); //><!-- Itali GTB Custom -->
                sVeh.Add("OSIRIS"); //>
                sVeh.Add("NERO"); //>
                sVeh.Add("NERO2"); //><!-- Nero Custom -->
                sVeh.Add("PENETRATOR"); //>
                sVeh.Add("REAPER"); //>
                sVeh.Add("SC1"); //>
                sVeh.Add("SULTANRS"); //>
                sVeh.Add("T20"); //>
                sVeh.Add("TAIPAN"); //>
                sVeh.Add("TEMPESTA"); //>
                sVeh.Add("TEZERACT"); //>
                sVeh.Add("TURISMOR"); //>
                sVeh.Add("TYRANT"); //>
                sVeh.Add("TYRUS"); //>
                sVeh.Add("VACCA"); //>
                sVeh.Add("VAGNER"); //>
                sVeh.Add("VIGILANTE"); //>
                sVeh.Add("VISIONE"); //>
                sVeh.Add("PROTOTIPO"); //><!-- X80 Proto -->
                sVeh.Add("XA21"); //>
                sVeh.Add("ZENTORNO"); //>
                sVeh.Add("NINEF"); //>
                sVeh.Add("NINEF2"); //><!-- 9F Cabrio -->
                sVeh.Add("ALPHA"); //>
                sVeh.Add("BANSHEE"); //>
                sVeh.Add("BESTIAGTS"); //>
                sVeh.Add("CARBONIZZARE"); //>
                sVeh.Add("COMET2"); //><!-- Comet -->
                sVeh.Add("COMET3"); //><!-- Comet Retro Custom -->
                sVeh.Add("COMET4"); //><!-- Comet Safari -->
                sVeh.Add("COMET5"); //><!-- Comet SR -->
                sVeh.Add("COQUETTE"); //>
                sVeh.Add("TAMPA2"); //><!-- Drift Tampa -->
                sVeh.Add("ELEGY"); //><!-- Elegy Retro Custom -->
                sVeh.Add("ELEGY2"); //><!-- Elegy RH8 -->
                sVeh.Add("FELTZER2"); //><!-- Feltzer -->
                sVeh.Add("FUROREGT"); //>
                sVeh.Add("GB200"); //>
                sVeh.Add("JESTER"); //>
                sVeh.Add("JESTER2"); //><!-- Jester (Racecar) -->
                sVeh.Add("JESTER3"); //><!-- Jester Classic -->
                sVeh.Add("LYNX"); //>
                sVeh.Add("MASSACRO"); //>
                sVeh.Add("NEON"); //>
                sVeh.Add("OMNIS"); //>
                sVeh.Add("PARIAH"); //>
                sVeh.Add("PENUMBRA"); //>
                sVeh.Add("RAIDEN"); //>
                sVeh.Add("RAPIDGT"); //>
                sVeh.Add("RAPIDGT2"); //><!-- Rapid GT Cabrio -->
                sVeh.Add("REVOLTER"); //>
                sVeh.Add("SEVEN70"); //>
                sVeh.Add("SPECTER"); //>
                sVeh.Add("SPECTER2"); //><!-- Specter Custom -->
                sVeh.Add("BUFFALO3"); //><!-- Sprunk Buffalo -->
                sVeh.Add("STREITER"); //>
                sVeh.Add("SURANO"); //>
                sVeh.Add("TROPOS"); //>
                sVeh.Add("VERLIERER2"); //>
                sVeh.Add("BUCCANEER2"); //><!-- Buccaneer Custom -->
                sVeh.Add("STALION2"); //><!-- Burger Shot Stallion -->
                sVeh.Add("CHINO"); //>
                sVeh.Add("CHINO2"); //><!-- Chino Custom -->
                sVeh.Add("COQUETTE3"); //><!-- Coquette BlackFin -->
                sVeh.Add("DOMINATOR3"); //><!-- Dominator GTX -->
                sVeh.Add("ELLIE"); //>
                sVeh.Add("NIGHTSHADE"); //>
                sVeh.Add("SABREGT2"); //><!-- Sabre Turbo Custom -->
                sVeh.Add("VIRGO2"); //><!-- Virgo Classic Custom -->
                sVeh.Add("Z190"); //><!-- 190z -->
                sVeh.Add("ARDENT"); //>
                sVeh.Add("CASCO"); //>
                sVeh.Add("CHEETAH2"); //><!-- Cheetah Classic -->
                sVeh.Add("COQUETTE2"); //><!-- Coquette Classic -->
                sVeh.Add("INFERNUS2"); //><!-- Infernus Classic -->				
                sVeh.Add("JB700"); //>
                sVeh.Add("MAMBA"); //>				
                sVeh.Add("MICHELLI"); //>	
                sVeh.Add("RAPIDGT3"); //><!-- Rapid GT Classic -->	
                sVeh.Add("BTYPE"); //><!-- Roosevelt -->
                sVeh.Add("BTYPE3"); //><!-- Roosevelt Valor -->	
                sVeh.Add("STINGER"); //>
                sVeh.Add("STINGERGT"); //>		
                sVeh.Add("FELTZER3"); //><!-- Stirling GT -->	
                sVeh.Add("SWINGER"); //>
                sVeh.Add("TORERO"); //>	
                sVeh.Add("VISERIS"); //>
                sVeh.Add("ZTYPE"); //>	
                sVeh.Add("STAFFORD"); //>
                sVeh.Add("SUPERD"); //>
                sVeh.Add("FREECRAWLER"); //>
                sVeh.Add("HELLION");
                sVeh.Add("KALAHARI"); //>
                sVeh.Add("KAMACHO"); //>
                sVeh.Add("MENACER"); //>
                sVeh.Add("CONTENDER"); //>
                sVeh.Add("DUBSTA"); //>
                sVeh.Add("DUBSTA2"); //><!-- Dubsta black variant -->
                sVeh.Add("PATRIOT"); //>
                sVeh.Add("RADI"); //>
                sVeh.Add("ROCOTO"); //>
                sVeh.Add("XLS"); //>
                sVeh.Add("XLS2"); //><!-- XLS (Armored) -->
                if (!DataStore.bDisableDLCVeh)
                {
                    sVeh.Add("DEVESTE"); //>                ------------DIssapears....
                    sVeh.Add("EMERUS"); //>                ------------DIssapears....
                    sVeh.Add("FURIA"); //>                ------------DIssapears....
                    sVeh.Add("KRIEGER"); //>                ------------DIssapears....
                    sVeh.Add("S80"); //>                ------------DIssapears....
                    sVeh.Add("THRAX"); //>                ------------DIssapears....
                    sVeh.Add("ZORRUSSO"); //>                ------------DIssapears....
                    sVeh.Add("TIGON"); //>                ------------DIssapears....
                    sVeh.Add("DRAFTER"); //><!-- 8F Drafter -->                ------------DIssapears....
                    sVeh.Add("IMORGON"); //>                ------------DIssapears....
                    sVeh.Add("ITALIGTO"); //>                ------------DIssapears....
                    sVeh.Add("JUGULAR"); //>                ------------DIssapears....
                    sVeh.Add("KOMODA"); //>                ------------DIssapears....
                    sVeh.Add("LOCUST"); //>                ------------DIssapears....
                    sVeh.Add("NEO"); //>                ------------DIssapears....
                    sVeh.Add("VSTR"); //><!-- V-STR -->                 ------------DIssapears....
                    sVeh.Add("PENUMBRA2"); //>                ------------DIssapears...
                    sVeh.Add("DEVIANT"); //>                 ------------DIssapears....
                    sVeh.Add("GAUNTLET4"); //><!-- Gauntlet Hellfire -->                 ------------DIssapears....
                    sVeh.Add("TULIP"); //>                 ------------DIssapears....
                    sVeh.Add("JB7002"); //><!-- JB 700W -->                 ------------DIssapears....
                    sVeh.Add("ZION3"); //><!-- Zion Classic -->                 ------------DIssapears....
                    sVeh.Add("COQUETTE4"); //>                 ------------DIssapears....
                    sVeh.Add("DUKES3"); //>                 ------------DIssapears....
                    sVeh.Add("GAUNTLET5"); //>                 ------------DIssapears....
                    sVeh.Add("GLENDALE2"); //>                 ------------DIssapears....
                    sVeh.Add("MANANA2"); //>                 ------------DIssapears....
                    sVeh.Add("PEYOTE3"); //>                 ------------DIssapears....
                    sVeh.Add("YOSEMITE3"); //>                 ------------DIssapears....
                    sVeh.Add("YOUGA3"); //>                 ------------DIssapears....
                    sVeh.Add("TOREADOR"); //><!-- Pegassi Toreador -->
                    sVeh.Add("ITALIRSX"); //><!-- Grotti Itali RSX -->
                    sVeh.Add("champion"); //Dewbauchee Champion
                    sVeh.Add("ignus"); //Pegassi Ignus
                    sVeh.Add("zeno"); //Overflod Zeno

                    sVeh.Add("sentinel4"); //
                    sVeh.Add("tenf2"); //
                    sVeh.Add("tenf"); //
                    sVeh.Add("sm722"); //
                    sVeh.Add("omnisegt"); //
                    sVeh.Add("corsita"); //
                    sVeh.Add("torero2"); //
                    sVeh.Add("lm87"); //
                }
            }
            else if (iList == 4)
            {
                sVeh.Add("BLISTA2"); //><!-- Blista Compact -->
                sVeh.Add("BUFFALO"); //>
                sVeh.Add("BUFFALO2"); //><!-- Buffalo S -->
                sVeh.Add("FLASHGT"); //>
                sVeh.Add("FUTO"); //>
                sVeh.Add("FUSILADE"); //>
                sVeh.Add("KHAMELION"); //>
                sVeh.Add("KURUMA"); //>
                sVeh.Add("RUSTON"); //>
                sVeh.Add("SCHAFTER4"); //><!-- Schafter LWB -->
                sVeh.Add("SCHAFTER3"); //><!-- Schafter V12 -->
                sVeh.Add("SCHWARZER"); //> 
                sVeh.Add("SENTINEL3"); //><!-- Sentinel Classic -->
                sVeh.Add("SULTAN"); //>
                sVeh.Add("COGCABRIO"); //>
                sVeh.Add("EXEMPLAR"); //>
                sVeh.Add("F620"); //>
                sVeh.Add("FELON"); //>
                sVeh.Add("FELON2"); //><!-- Felon GT -->
                sVeh.Add("JACKAL"); //>
                sVeh.Add("ORACLE"); //>
                sVeh.Add("ORACLE2"); //><!-- Oracle XS -->
                sVeh.Add("SENTINEL2"); //><!-- Sentinel -->
                sVeh.Add("SENTINEL"); //><!-- Sentinel XS -->
                sVeh.Add("WINDSOR"); //>
                sVeh.Add("WINDSOR2"); //><!-- Windsor Drop -->
                sVeh.Add("ZION"); //>
                sVeh.Add("ZION2"); //><!-- Zion Cabrio -->
                sVeh.Add("DOMINATOR"); //>
                sVeh.Add("DUKES"); //>
                sVeh.Add("FACTION2"); //><!-- Faction Custom -->
                sVeh.Add("FACTION3"); //><!-- Faction Custom Donk -->
                sVeh.Add("GAUNTLET"); //>
                sVeh.Add("HERMES"); //>
                sVeh.Add("HOTKNIFE"); //>
                sVeh.Add("HUSTLER"); //>
                sVeh.Add("SLAMVAN2"); //><!-- Lost Slamvan -->
                sVeh.Add("LURCHER"); //>
                sVeh.Add("MOONBEAM2"); //><!-- Moonbeam Custom -->
                sVeh.Add("PHOENIX"); //>
                sVeh.Add("DOMINATOR2"); //><!-- Pisswasser Dominator -->
                sVeh.Add("RATLOADER"); //>
                sVeh.Add("RATLOADER2"); //><!-- Rat-Truck -->
                sVeh.Add("GAUNTLET2"); //><!-- Redwood Gauntlet -->
                sVeh.Add("RUINER"); //>
                sVeh.Add("SABREGT"); //>
                sVeh.Add("SLAMVAN3"); //><!-- Slamvan Custom -->
                sVeh.Add("STALION"); //>
                sVeh.Add("TAMPA"); //>
                sVeh.Add("VIGERO"); //>
                sVeh.Add("VIRGO"); //>
                sVeh.Add("VIRGO3"); //><!-- Virgo Classic -->
                sVeh.Add("VOODOO2"); //><!-- Voodoo Custom -->
                sVeh.Add("YOSEMITE"); //>
                sVeh.Add("BTYPE2"); //><!-- FrÃ¤nken Stange -->
                sVeh.Add("GT500"); //>
                sVeh.Add("MONROE"); //>
                sVeh.Add("PEYOTE"); //>
                sVeh.Add("RETINUE"); //>
                sVeh.Add("SAVESTRA"); //>
                sVeh.Add("TORNADO2"); //><!-- Tornado Cabrio -->
                sVeh.Add("TORNADO3"); //><!-- Rusty Tornado -->
                sVeh.Add("TORNADO5"); //><!-- Tornado Custom -->
                sVeh.Add("TORNADO6"); //><!-- Tornado Rat Rod -->
                sVeh.Add("TURISMO2"); //><!-- Turismo Classic -->
                sVeh.Add("FUGITIVE"); //>
                sVeh.Add("PRIMO2"); //><!-- Primo Custom -->
                sVeh.Add("COGNOSCENTI"); //>
                sVeh.Add("COGNOSCENTI2"); //><!-- Cognoscenti (Armored) -->
                sVeh.Add("SCHAFTER2"); //>
                sVeh.Add("SCHAFTER6"); //><!-- Schafter LWB (Armored) -->
                sVeh.Add("SCHAFTER5"); //><!-- Schafter V12 (Armored) -->
                sVeh.Add("SURGE"); //>
                sVeh.Add("TAILGATER"); //>
                sVeh.Add("COG55"); //><!-- Cognoscenti 55 -->
                sVeh.Add("COG552"); //><!-- Cognoscenti 55 (Armored) -->
                sVeh.Add("BIFTA"); //>
                sVeh.Add("BLAZER"); //>
                sVeh.Add("BODHI2"); //>
                sVeh.Add("BRAWLER"); //>
                sVeh.Add("TROPHYTRUCK2"); //><!-- Desert Raid -->
                sVeh.Add("DUNE"); //>
                sVeh.Add("RIATA"); //>
                sVeh.Add("SANDKING2"); //><!-- Sandking SWB -->
                sVeh.Add("SANDKING"); //><!-- Sandking XL -->
                sVeh.Add("TROPHYTRUCK"); //>
                sVeh.Add("BALLER"); //>
                sVeh.Add("BALLER2"); //><!-- Baller 2nd gen variant -->
                sVeh.Add("BALLER3"); //><!-- Baller LE -->
                sVeh.Add("BALLER5"); //><!-- Baller LE (Armored) -->
                sVeh.Add("BALLER4"); //><!-- Baller LE LWB -->
                sVeh.Add("BALLER6"); //><!-- Baller LE LWB (Armored) -->
                sVeh.Add("SEMINOLE"); //>
                sVeh.Add("SERRANO"); //>
                sVeh.Add("HUNTLEY"); //>
                sVeh.Add("LANDSTALKER"); //>
                sVeh.Add("BRIOSO"); //>
                sVeh.Add("ISSI2"); //>
                sVeh.Add("ISSI3"); //><!-- Issi Classic -->
                sVeh.Add("PANTO"); //>
                if (!DataStore.bDisableDLCVeh)
                {
                    sVeh.Add("ISSI7"); //><!-- Issi Sport -->                ------------DIssapears....
                    sVeh.Add("PARAGON"); //>                ------------DIssapears....
                    sVeh.Add("PARAGON2"); //><!-- Paragon R (Armored) -->                ------------DIssapears....
                    sVeh.Add("SCHLAGEN"); //>                ------------DIssapears....
                    sVeh.Add("SUGOI"); //>                 ------------DIssapears....
                    sVeh.Add("SULTAN2"); //><!-- Sultan Classic -->               ------------DIssapears....
                    sVeh.Add("CLIQUE"); //>                 ------------DIssapears....
                    sVeh.Add("YOSEMITE2"); //><!-- Drift Yosemite -->                 ------------DIssapears....
                    sVeh.Add("GAUNTLET3"); //><!-- Gauntlet Classic -->                 ------------DIssapears....
                    sVeh.Add("PEYOTE2"); //><!-- Peyote Gasser -->                 ------------DIssapears....
                    sVeh.Add("IMPALER"); //>                 ------------DIssapears....
                    sVeh.Add("VAMOS"); //>                 ------------DIssapears....
                    sVeh.Add("DYNASTY"); //>                 ------------DIssapears....
                    sVeh.Add("RETINUE2"); //><!-- Retinue MkII -->                 ------------DIssapears....	
                    sVeh.Add("CARACARA2"); //><!-- Caracara 4x4 -->                 ------------DIssapears....								
                    sVeh.Add("EVERON"); //>                 ------------DIssapears....
                    sVeh.Add("OUTLAW"); //>                 ------------DIssapears....
                    sVeh.Add("VAGRANT"); //>                 ------------DIssapears....
                    sVeh.Add("NOVAK"); //>                 ------------DIssapears....
                    sVeh.Add("REBLA"); //>                 ------------DIssapears....
                    sVeh.Add("TOROS"); //>                 ------------DIssapears....
                    sVeh.Add("LANDSTALKER2"); //>                 ------------DIssapears....
                    sVeh.Add("SEMINOLE2"); //>                 ------------DIssapears....
                    sVeh.Add("ASBO"); //>                 -                        -----------DIssapears....
                    sVeh.Add("KANJO"); //><!-- Blista Kanjo -->                 ------------DIssapears....
                    sVeh.Add("CLUB"); //>                 -                        -----------DIssapears....
                    sVeh.Add("BRIOSO2"); //>Grotti Brioso 300
                    sVeh.Add("WEEVIL"); //><!-- BF Weevil -->
                    sVeh.Add("buffalo4"); //Bravado Buffalo STX
                    sVeh.Add("astron"); //Pfister Astron
                    sVeh.Add("baller7"); //Gallivanter Baller ST
                    sVeh.Add("granger2"); //Declasse Granger 3600LX
                    sVeh.Add("iwagen"); //Obey I-Wagen
                    sVeh.Add("jubilee"); //Enus Jubilee
                    sVeh.Add("patriot3"); //Mammoth Patriot Mil-Spec
                    sVeh.Add("greenwood");
                    sVeh.Add("ruiner4");
                    sVeh.Add("vigero2");
                    sVeh.Add("weevil2");
                    sVeh.Add("draugur");
                }
            }
            else if (iList == 5)
            {
                sVeh.Add("BLADE"); //>
                sVeh.Add("BUCCANEER"); //>
                sVeh.Add("FACTION"); //>
                sVeh.Add("MOONBEAM"); //>
                sVeh.Add("PICADOR"); //>
                sVeh.Add("SLAMVAN"); //>
                sVeh.Add("VOODOO"); //>
                sVeh.Add("CHEBUREK"); //>
                sVeh.Add("FAGALOA"); //>
                sVeh.Add("MANANA"); //>
                sVeh.Add("PIGALLE"); //>
                sVeh.Add("TORNADO"); //>
                sVeh.Add("TORNADO4"); //><!-- Mariachi Tornado -->
                sVeh.Add("ASEA"); //>
                sVeh.Add("ASTEROPE"); //>
                sVeh.Add("EMPEROR"); //>
                sVeh.Add("EMPEROR2"); //><!-- Emperor beater variant -->
                sVeh.Add("GLENDALE"); //>
                sVeh.Add("INGOT"); //>
                sVeh.Add("INTRUDER"); //>
                sVeh.Add("PREMIER"); //>
                sVeh.Add("PRIMO"); //>
                sVeh.Add("REGINA"); //>
                sVeh.Add("ROMERO"); //>
                sVeh.Add("STANIER"); //>
                sVeh.Add("STRATUM"); //>
                sVeh.Add("WARRENER"); //>
                sVeh.Add("WASHINGTON"); //>
                sVeh.Add("DLOADER"); //>
                sVeh.Add("BFINJECTION"); //>
                sVeh.Add("MESA3"); //><!-- Merryweather Mesa -->
                sVeh.Add("REBEL2"); //>
                sVeh.Add("BJXL"); //>
                sVeh.Add("CAVALCADE"); //>
                sVeh.Add("CAVALCADE2"); //><!-- Cavalcade 2nd gen variant -->
                sVeh.Add("FQ2"); //>
                sVeh.Add("GRANGER"); //>
                sVeh.Add("GRESLEY"); //>
                sVeh.Add("HABANERO"); //>
                sVeh.Add("MESA"); //>
                sVeh.Add("BLISTA"); //>
                sVeh.Add("DILETTANTE"); //>
                sVeh.Add("PRAIRIE"); //>
                sVeh.Add("RHAPSODY"); //>

                if (!DataStore.bDisableDLCVeh)
                {
                    sVeh.Add("NEBULA"); //>                 ------------DIssapears....
                    sVeh.Add("cinquemila"); //Lampadati Cinquemila
                    sVeh.Add("deity"); //Enus Deity
                    sVeh.Add("kanjosj"); //>
                    sVeh.Add("postlude"); //>
                    sVeh.Add("brioso3"); //>
                    sVeh.Add("rhinehart"); //>
                }
            }
            else if (iList == 6)
            {
                sVeh.Add("SWIFT2"); //>
            }
            else if (iList == 11)
            {
                sVeh.Add("CADDY"); //>
            }
            else if (iList == 14)
            {
                sVeh.Add("REBEL"); //><!-- Rusty Rebel -->
                sVeh.Add("RANCHERXL"); //>
                sVeh.Add("TRACTOR2"); //>
                sVeh.Add("SCRAP"); //>      
            }
            else if (iList == 15)
            {
                if (iSubSet == 1)
                {
                    sVeh.Add("TRIBIKE");
                    sVeh.Add("TRIBIKE2");
                    sVeh.Add("TRIBIKE3");
                    sVeh.Add("FIXTER");
                }
                else if (iSubSet == 2)
                    sVeh.Add("SCORCHER");
                else if (iSubSet ==3)
                    sVeh.Add("BMX");
                else
                    sVeh.Add("CRUISER");
            }
            else if (iList == 18)
            {
                if (iSubSet == 7)
                {
                    sVeh.Add("STOCKADE");
                }
                else if (iSubSet == 8)
                {
                    sVeh.Add("DILETTANTE2");
                }
                else if (iSubSet == 11)
                {
                    sVeh.Add("BULLDOZER");
                    sVeh.Add("FORKLIFT");
                    sVeh.Add("RIPLEY");
                    sVeh.Add("UTILLITRUCK");
                }
                else if (iSubSet == 12)
                {
                    sVeh.Add("DOCKTUG");
                }
                else if (iSubSet == 13)
                {
                    sVeh.Add("AIRTUG");
                }
                else if (iSubSet == 14)
                {
                    sVeh.Add("TRASH2");
                }
                else if (iSubSet == 17)
                {
                    sVeh.Add("BUS");
                    sVeh.Add("RENTALBUS");
                    sVeh.Add("COACH");
                }
                else if (iSubSet == 19)
                {
                    sVeh.Add("BOXVILLE2");
                }
                else
                {
                    sVeh.Add("BOXVILLE2");
                    sVeh.Add("Mule2");
                }
            }
            else if (iList == 19)
            {
                sVeh.Add("SEASHARK");
            }
            else if (iList == 20)
            {
                sVeh.Add("BF400");
                sVeh.Add("MANCHEZ");
                sVeh.Add("SANCHEZ");
                sVeh.Add("BLAZER");
                sVeh.Add("BLAZER5");
                sVeh.Add("BLAZER4");
                if (!DataStore.bDisableDLCVeh)
                {
                    sVeh.Add("MANCHEZ2"); //><!-- Maibatsu Manchez Scout -->
                    sVeh.Add("VERUS"); //><!-- Dinka Verus -->
                }
            }
            else if (iList == 21)
            {
                if (iSubSet == 1)
                {
                    sVeh.Add("BLAZER2"); //><!-- Blazer Lifeguard -->
                    sVeh.Add("LGUARD"); //>
                }            //"Baywatch 
                else if (iSubSet == 2)
                {
                    sVeh.Add("PREDATOR");
                }       //"US Coastguard
                else if (iSubSet == 3)
                {
                    sVeh.Add("POLICE2"); //><!-- Police Cruiser Buffalo -->
                    sVeh.Add("POLICE"); //><!-- Police Cruiser Stanier -->
                    sVeh.Add("POLICE3"); //><!-- Police Cruiser Interceptor -->
                    sVeh.Add("POLICET"); //><!-- Police Transporter -->
                }       //><!--Cops
                else if (iSubSet == 4)
                {
                    sVeh.Add("POLICEB");
                }       //><!-- PoliceBike
                else if (iSubSet == 5)
                {
                    sVeh.Add("PRANGER"); //><!-- Park Ranger -->
                }       //><!-- Ranger
                else if (iSubSet == 6)
                {
                    sVeh.Add("SHERIFF"); //><!-- Sheriff Cruiser -->
                    sVeh.Add("SHERIFF2"); //><!-- Sheriff SUV -->
                }       //><!-- Sherif
                else if (iSubSet == 7)
                {
                    sVeh.Add("FBI"); //><!-- FIB Buffalo -->
                    sVeh.Add("FBI2"); //><!-- FIB Granger -->
                }       //><!-- fib
                else if (iSubSet == 8)
                {
                    sVeh.Add("RIOT");
                }       //><!-- swat
                else if (iSubSet == 9)
                {
                    sVeh.Add("BARRACKS");
                    sVeh.Add("BARRACKS2");
                    sVeh.Add("BARRAGE");
                    sVeh.Add("CHERNOBOG");
                    sVeh.Add("CRUSADER");
                    sVeh.Add("RHINO");
                    sVeh.Add("KHANJALI");
                    if (!DataStore.bDisableDLCVeh)
                    {
                        sVeh.Add("SQUADDIE"); //><!-- Mammoth Squaddie -->
                        sVeh.Add("VETIR"); //>Vetir--Patriot truck--
                        sVeh.Add("WINKY"); //><!-- Vapid Winky -->	
                    }
                }       //military
                else if (iSubSet == 10)
                {
                    sVeh.Add("AMBULANCE");
                }       //medic
                else
                {
                    sVeh.Add("FIRETRUK");
                }       //fireman
            }       //oddnumbers fixit
            else if (iList == 22)
            {
                if (iSubSet == 1)
                {
                    sVeh.Add("CARGOPLANE"); //>
                    sVeh.Add("CUBAN800"); //>
                    sVeh.Add("JET"); //>
                    sVeh.Add("LUXOR"); //>
                    sVeh.Add("LUXOR2"); //>
                    sVeh.Add("MOGUL"); //>
                    sVeh.Add("SHAMAL"); //>
                    sVeh.Add("VELUM"); //>
                    sVeh.Add("VELUM2"); //>
                }            //civilian
                else if (iSubSet == 2)
                {
                    sVeh.Add("BESRA"); //>
                    sVeh.Add("LAZER"); //>
                    sVeh.Add("NOKOTA"); //>
                    sVeh.Add("PYRO"); //>
                    sVeh.Add("BOMBUSHKA"); //>
                    sVeh.Add("ROGUE"); //>
                    sVeh.Add("TITAN"); //>
                    sVeh.Add("MOLOTOK"); //>
                    sVeh.Add("VOLATOL"); //>
                }       //military
                else if (iSubSet == 3)
                {
                    sVeh.Add("FROGGER"); //>
                }       //Hell tours
                else
                {
                    sVeh.Add("SUPERVOLITO2"); //>
                }       //office Hell
            }
            else if (iList == 23)
            {
                sVeh.Add("TRACTOR3"); //>
                sVeh.Add("ASEA2"); //>
                sVeh.Add("EMPEROR3"); //>
                sVeh.Add("RANCHERXL2"); //>
                sVeh.Add("MESA2"); //>
                sVeh.Add("SADLER2"); //>
                sVeh.Add("BURRITO5"); //>
            }
            else
            {
                if (iSubSet == 1)
                {

                }       //A_C_Panther
                else if (iSubSet == 2)
                {

                }       //A_F_Y_Beach_02
                else if (iSubSet == 3)
                {
                    if (DataStore.bDisableDLCVeh)
                    {
                        sVeh.Add("MANCHEZ"); //>
                        sVeh.Add("TECHNICAL"); //>
                        sVeh.Add("MESA3"); //>
                    }
                    else
                    {
                        sVeh.Add("winky"); //Vapid Winky -Road
                        sVeh.Add("vetir"); //Vetir -Military
                        sVeh.Add("slamtruck"); //Vapid Slamtruck -Utility
                        sVeh.Add("VERUS"); //><!-- Dinka Verus -->ATV
                        sVeh.Add("manchez2"); //Maibatsu Manchez Scout -Motorcycles
                    }
                }       //Guard
                else if (iSubSet == 4)
                {

                }       //Bar
                else if (iSubSet == 5)
                {

                }       //worker
                else if (iSubSet == 6)
                {

                }       //pilot
                else
                {
                    sVeh.Add("VETO"); //><!-- Dinka Veto Classic -->GoCart
                    sVeh.Add("VETO2"); //><!-- Dinka Veto Modern -->GoCart
                }       //randomOther??
            }
            
            if (sVeh.Count() == 1)
                sVehc = sVeh[0];
            else
                sVehc = sVeh[RandomX.RandInt(0, sVeh.Count() - 1)];

            return sVehc;
        }
        public static string BuildRandomPed(int iPedtype, int iSubType)
        {
            LoggerLight.Loggers("BuildRandomPed, iPedtype == " + iPedtype + ", iSubType == " + iSubType);

            List<string> sPeddy = new List<string>();

            string sPed = "";

            if (iPedtype == 1)
            {
                sPeddy.Add("a_f_m_beach_01");                //"Beach Female");  
                sPeddy.Add("a_f_m_fatcult_01");                //"Fat Cult Female");  
                sPeddy.Add("a_f_y_hippie_01");                //"Hippie Female"); 
                sPeddy.Add("a_f_y_yoga_01");                //"Yoga Female"); 
                sPeddy.Add("a_m_m_beach_01");                //"Beach Male");  
                sPeddy.Add("a_m_y_beach_01");                //"Beach Young Male");  
                sPeddy.Add("a_m_y_beach_02");                //"Beach Young Male 2");  
                sPeddy.Add("a_m_y_beach_03");                //"Beach Young Male 3"); 
                sPeddy.Add("a_m_y_breakdance_01");                //"Breakdancer Male");
                sPeddy.Add("a_m_y_hippy_01");                //"Hippie Male");  
                sPeddy.Add("a_m_y_sunbathe_01");                //"Sunbather Male");  
                sPeddy.Add("a_m_y_surfer_01");                //"Surfer");
                sPeddy.Add("a_m_y_beachvesp_01");                //"Vespucci Beach Male");  
                sPeddy.Add("a_m_y_beachvesp_02");                //"Vespucci Beach Male 2");  
                sPeddy.Add("a_m_y_stwhi_01");                //"White Street Male");  
                sPeddy.Add("a_m_y_yoga_01");                //"Yoga Male");
            }            //Beach Peds
            else if (iPedtype == 2)
            {
                sPeddy.Add("a_f_m_trampbeac_01");                //"Beach Tramp Female");  
                sPeddy.Add("a_f_m_tramp_01");                //"Tramp Female");  
                sPeddy.Add("a_m_o_beach_01");                //"Beach Old Male");  
                sPeddy.Add("a_m_m_trampbeac_01");                //"Beach Tramp Male");  
                sPeddy.Add("a_m_m_tramp_01");                //"Tramp Male");  
                sPeddy.Add("a_m_o_tramp_01");                //"Tramp Old Male");  
            }       //Tramps
            else if (iPedtype == 3)
            {
                sPeddy.Add("a_f_y_scdressy_01");                //"Dressy Female");  
                sPeddy.Add("a_f_y_bevhills_04");                //"Beverly Hills Young Female 4"); 
                sPeddy.Add("a_f_y_clubcust_01");                //"Club Customer Female 1");  
                sPeddy.Add("a_f_y_clubcust_02");                //"Club Customer Female 2");  
                sPeddy.Add("a_f_y_clubcust_03");                //"Club Customer Female 3"); 
                sPeddy.Add("a_f_y_smartcaspat_01");                //"Formel Casino Guest");  
                sPeddy.Add("s_f_y_movprem_01");                //"Movie Premiere Female");  
                sPeddy.Add("A_F_Y_StudioParty_01");
                sPeddy.Add("A_F_Y_StudioParty_02");

                sPeddy.Add("a_m_y_bevhills_02");                //"Beverly Hills Young Male 2"); 
                sPeddy.Add("a_m_y_smartcaspat_01");                //"Formel Casino Guests"); 
                sPeddy.Add("a_m_m_malibu_01");                //"Malibu Male");  
                sPeddy.Add("a_m_y_soucent_04");                //"South Central Young Male 4");  
                sPeddy.Add("s_m_m_movprem_01");                //"Movie Premiere Male");  
                sPeddy.Add("A_M_M_StudioParty_01");
                sPeddy.Add("A_M_Y_StudioParty_01");
            }       //High class
            else if (iPedtype == 4)
            {
                sPeddy.Add("a_f_y_bevhills_01");                //"Beverly Hills Young Female");  
                sPeddy.Add("a_f_y_bevhills_02");                //"Beverly Hills Young Female 2");  
                sPeddy.Add("a_f_y_bevhills_03");                //"Beverly Hills Young Female 3"); 
                sPeddy.Add("a_f_y_eastsa_01");                //"East SA Young Female");  
                sPeddy.Add("a_f_y_eastsa_02");                //"East SA Young Female 2");  
                sPeddy.Add("a_f_y_genhot_01");                //"General Hot Young Female");  
                sPeddy.Add("a_f_y_hipster_01");                //"Hipster Female");  
                sPeddy.Add("a_f_y_hipster_02");                //"Hipster Female 2");  
                sPeddy.Add("a_f_y_hipster_03");                //"Hipster Female 3");  
                sPeddy.Add("a_f_y_hipster_04");                //"Hipster Female 4"); 
                sPeddy.Add("a_f_y_indian_01");                //"Indian Young Female");  
                sPeddy.Add("a_f_y_soucent_03");                //"South Central Young Female 3");  
                sPeddy.Add("a_f_y_tourist_01");                //"Tourist Young Female");  
                sPeddy.Add("a_f_y_vinewood_01");                //"Vinewood Female");  
                sPeddy.Add("a_f_y_vinewood_02");                //"Vinewood Female 2");  
                sPeddy.Add("a_f_y_vinewood_03");                //"Vinewood Female 3");  
                sPeddy.Add("a_f_y_vinewood_04");                //"Vinewood Female 4"); 
                sPeddy.Add("A_F_Y_CarClub_01");
                sPeddy.Add("A_M_Y_CarClub_01");

                sPeddy.Add("a_m_m_afriamer_01");                //"African American Male");  
                sPeddy.Add("a_m_m_bevhills_01");                //"Beverly Hills Male");  
                sPeddy.Add("a_m_m_bevhills_02");                //"Beverly Hills Male 2");  
                sPeddy.Add("a_m_y_bevhills_01");                //"Beverly Hills Young Male");  
                sPeddy.Add("a_m_y_stbla_02");                //"Black Street Male 2");
                sPeddy.Add("a_m_y_gencaspat_01");                //"Casual Casino Guests");  
                sPeddy.Add("a_m_y_genstreet_01");                //"General Street Young Male");  
                sPeddy.Add("a_m_y_genstreet_02");                //"General Street Young Male 2");  
                sPeddy.Add("a_m_m_hasjew_01");                //"Hasidic Jew Male");  
                sPeddy.Add("a_m_y_hasjew_01");                //"Hasidic Jew Young Male");  
                sPeddy.Add("a_m_y_hipster_01");                //"Hipster Male");  
                sPeddy.Add("a_m_y_hipster_02");                //"Hipster Male 2");  
                sPeddy.Add("a_m_y_hipster_03");                //"Hipster Male 3");  
                sPeddy.Add("a_m_y_indian_01");                //"Indian Young Male");  
                sPeddy.Add("a_m_y_ktown_01");                //"Korean Young Male");  
                sPeddy.Add("a_m_y_ktown_02");                //"Korean Young Male 2");  
                sPeddy.Add("a_m_y_polynesian_01");                //"Polynesian Young"); 
                sPeddy.Add("a_m_y_vindouche_01");                //"Vinewood Douche");  
                sPeddy.Add("a_m_y_vinewood_01");                //"Vinewood Male");  
                sPeddy.Add("a_m_y_vinewood_02");                //"Vinewood Male 2");  
                sPeddy.Add("a_m_y_vinewood_03");                //"Vinewood Male 3");  
                sPeddy.Add("a_m_y_vinewood_04");                //"Vinewood Male 4");  
                sPeddy.Add("a_m_y_stwhi_02");                //"White Street Male 2"); 
                sPeddy.Add("a_m_y_clubcust_01");                //"Club Customer Male 1");  
                sPeddy.Add("a_m_y_clubcust_02");                //"Club Customer Male 2");  
                sPeddy.Add("a_m_y_clubcust_03");                //"Club Customer Male 3"); 
                sPeddy.Add("A_M_Y_CarClub_01");
            }       //Mid class
            else if (iPedtype == 5)
            {
                sPeddy.Add("a_f_m_downtown_01");                //"Downtown Female"); 
                sPeddy.Add("a_f_y_gencaspat_01");                //"Casual Casino Guest");  
                sPeddy.Add("a_f_m_eastsa_01");                //"East SA Female");  
                sPeddy.Add("a_f_m_eastsa_02");                //"East SA Female 2");  
                sPeddy.Add("a_f_m_fatbla_01");                //"Fat Black Female");  
                sPeddy.Add("a_f_m_fatwhite_01");                //"Fat White Female");  
                sPeddy.Add("a_f_o_genstreet_01");                //"General Street Old Female");  
                sPeddy.Add("a_f_o_indian_01");                //"Indian Old Female");  
                sPeddy.Add("a_f_m_ktown_01");                //"Korean Female");  
                sPeddy.Add("a_f_m_ktown_02");                //"Korean Female 2");  
                sPeddy.Add("a_f_o_ktown_01");                //"Korean Old Female");  
                sPeddy.Add("a_f_m_skidrow_01");                //"Skid Row Female");  
                sPeddy.Add("a_f_m_soucent_01");                //"South Central Female");  
                sPeddy.Add("a_f_m_soucent_02");                //"South Central Female 2");  
                sPeddy.Add("a_f_m_soucentmc_01");                //"South Central MC Female");  
                sPeddy.Add("a_f_o_soucent_01");                //"South Central Old Female");  
                sPeddy.Add("a_f_o_soucent_02");                //"South Central Old Female 2");  
                sPeddy.Add("a_f_y_soucent_01");                //"South Central Young Female");  
                sPeddy.Add("a_f_y_soucent_02");                //"South Central Young Female 2");  
                sPeddy.Add("a_f_m_tourist_01");                //"Tourist Female");              
                sPeddy.Add("a_f_y_tourist_02");                //"Tourist Young Female 2");  

                sPeddy.Add("a_m_y_stbla_01");                //"Black Street Male");  
                sPeddy.Add("a_m_y_downtown_01");                //"Downtown Male");  
                sPeddy.Add("a_m_m_eastsa_01");                //"East SA Male");  
                sPeddy.Add("a_m_m_eastsa_02");                //"East SA Male 2");  
                sPeddy.Add("a_m_y_eastsa_01");                //"East SA Young Male");  
                sPeddy.Add("a_m_y_eastsa_02");                //"East SA Young Male 2");  
                sPeddy.Add("a_m_m_fatlatin_01");                //"Fat Latino Male");  
                sPeddy.Add("a_m_m_genfat_01");                //"General Fat Male");  
                sPeddy.Add("a_m_m_genfat_02");                //"General Fat Male 2");  
                sPeddy.Add("a_m_o_genstreet_01");                //"General Street Old Male");  
                sPeddy.Add("a_m_m_indian_01");                //"Indian Male"); 
                sPeddy.Add("a_m_m_ktown_01");                //"Korean Male");  
                sPeddy.Add("a_m_o_ktown_01");                //"Korean Old Male"); 
                sPeddy.Add("a_m_m_stlat_02");                //"Latino Street Male 2");  
                sPeddy.Add("a_m_y_stlat_01");                //"Latino Street Young Male");  
                sPeddy.Add("a_m_y_latino_01");                //"Latino Young Male");
                sPeddy.Add("a_m_m_mexlabor_01");                //"Mexican Labourer");  
                sPeddy.Add("a_m_m_mexcntry_01");                //"Mexican Rural"); 
                sPeddy.Add("a_m_m_polynesian_01");                //"Polynesian");   
                sPeddy.Add("a_m_m_skidrow_01");                //"Skid Row Male");  
                sPeddy.Add("a_m_m_socenlat_01");                //"South Central Latino Male");  
                sPeddy.Add("a_m_m_soucent_01");                //"South Central Male");  
                sPeddy.Add("a_m_m_soucent_02");                //"South Central Male 2");  
                sPeddy.Add("a_m_m_soucent_03");                //"South Central Male 3");  
                sPeddy.Add("a_m_m_soucent_04");                //"South Central Male 4");  
                sPeddy.Add("a_m_o_soucent_01");                //"South Central Old Male");  
                sPeddy.Add("a_m_o_soucent_02");                //"South Central Old Male 2");  
                sPeddy.Add("a_m_o_soucent_03");                //"South Central Old Male 3");  
                sPeddy.Add("a_m_y_soucent_01");                //"South Central Young Male");  
                sPeddy.Add("a_m_y_soucent_02");                //"South Central Young Male 2");  
                sPeddy.Add("a_m_y_soucent_03");                //"South Central Young Male 3"); 
                sPeddy.Add("a_m_m_tourist_01");                //"Tourist Male");  
                sPeddy.Add("g_m_m_casrn_01");                //"Casino Guests?");  
            }       //Low class 
            else if (iPedtype == 6)
            {
                sPeddy.Add("a_f_m_bevhills_01");                //"Beverly Hills Female");  
                sPeddy.Add("a_f_m_bevhills_02");                //"Beverly Hills Female 2"); 
                sPeddy.Add("a_f_m_business_02");                //"Business Female 2");  
                sPeddy.Add("a_f_y_business_01");                //"Business Young Female");  
                sPeddy.Add("a_f_y_business_02");                //"Business Young Female 2");  
                sPeddy.Add("a_f_y_business_03");                //"Business Young Female 3");  
                sPeddy.Add("a_f_y_business_04");                //"Business Young Female 4");  
                sPeddy.Add("a_f_y_femaleagent");                //"Female Agent");  

                sPeddy.Add("a_m_y_busicas_01");                //"Business Casual");  
                sPeddy.Add("a_m_m_business_01");                //"Business Male");  
                sPeddy.Add("a_m_y_business_01");                //"Business Young Male");  
                sPeddy.Add("a_m_y_business_02");                //"Business Young Male 2");  
                sPeddy.Add("a_m_y_business_03");                //"Business Young Male 3");  
                sPeddy.Add("a_m_m_prolhost_01");                //"Prologue Host Male");  
            }       //Buisness
            else if (iPedtype == 7)
            {
                sPeddy.Add("a_f_m_bodybuild_01");                //"Bodybuilder Female");  
                sPeddy.Add("a_m_y_musclbeac_01");                //"Beach Muscle Male");  
                sPeddy.Add("a_m_y_musclbeac_02");                //"Beach Muscle Male 2");  
            }       //Body builder
            else if (iPedtype == 8)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("g_f_importexport_01");                //"Gang Female (Import-Export)"); 
                    sPeddy.Add("a_f_y_eastsa_03");                //"East SA Young Female 3"); 
                    sPeddy.Add("g_f_importexport_01");                //"Import Export Female"); 
                    sPeddy.Add("g_m_importexport_01");                //"Gang Male (Import-Export)");
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("g_m_m_armboss_01");                //"Armenian Boss");  Rogers Salvage and Scrap in La Puerta.-- NON -- 
                    sPeddy.Add("g_m_m_armgoon_01");                //"Armenian Goon");  
                    sPeddy.Add("g_m_y_armgoon_02");                //"Armenian Goon 2");  
                    sPeddy.Add("g_m_m_armlieut_01");                //"Armenian Lieutenant");  
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("g_f_y_ballas_01");                //"Ballas Female"); Davis,--Families--Vagos
                    sPeddy.Add("g_m_y_ballaeast_01");                //"Ballas East Male");  
                    sPeddy.Add("g_m_y_ballaorig_01");                //"Ballas Original Male");  
                    sPeddy.Add("g_m_y_ballasout_01");                //"Ballas South Male");  
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("g_m_m_chiboss_01");                //"Chinese Boss");   textstyle-- korean
                    sPeddy.Add("g_m_m_chigoon_01");                //"Chinese Goon");  
                    sPeddy.Add("g_m_m_chigoon_02");                //"Chinese Goon 2");  
                    sPeddy.Add("g_m_m_chicold_01");                //"Chinese Goon Older");  
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("g_f_y_families_01");                //"Families Female");Strawberry--Chamberlain Hills-- Ballas-- Vagos-- Mexican Street Gang-- The Lost MC--
                    sPeddy.Add("g_m_y_famca_01");                //"Families CA Male");  
                    sPeddy.Add("g_m_y_famdnf_01");                //"Families DNF Male");  
                    sPeddy.Add("g_m_y_famfor_01");                //"Families FOR Male"); 
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("g_m_m_korboss_01");                //"Korean Boss");  K-town-- Chinesse
                    sPeddy.Add("g_m_y_korlieut_01");                //"Korean Lieutenant");  
                    sPeddy.Add("g_m_y_korean_01");                //"Korean Young Male");  
                    sPeddy.Add("g_m_y_korean_02");                //"Korean Young Male 2");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("g_m_y_azteca_01");                //"Azteca"); 
                    sPeddy.Add("g_f_y_vagos_01");                //"Vagos Female"); Rancho--Central Cypress Flats,--Families--Ballas
                    sPeddy.Add("a_m_y_mexthug_01");                //"Mexican Thug"); -- Northern Rancho --The Lost MC--Salvadoran Street Gang
                    sPeddy.Add("g_m_m_mexboss_01");                //"Mexican Boss");  
                    sPeddy.Add("g_m_m_mexboss_02");                //"Mexican Boss 2");  
                    sPeddy.Add("g_m_y_mexgang_01");                //"Mexican Gang Member");  
                    sPeddy.Add("g_m_y_mexgoon_01");                //"Mexican Goon");  
                    sPeddy.Add("g_m_y_mexgoon_02");                //"Mexican Goon 2");  
                    sPeddy.Add("g_m_y_mexgoon_03");                //"Mexican Goon 3");  
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("g_m_y_pologoon_01");                //"Polynesian Goon");  
                    sPeddy.Add("g_m_y_pologoon_02");                //"Polynesian Goon 2");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("g_m_y_salvaboss_01");                //"Salvadoran Boss");  El Burro Heights--Vespucci Beach(night)--East Vinewood Drain Canal,---Mexican Street Gang--Los Santos Vagos--Ballas
                    sPeddy.Add("g_m_y_salvagoon_01");                //"Salvadoran Goon");  
                    sPeddy.Add("g_m_y_salvagoon_02");                //"Salvadoran Goon 2");  
                    sPeddy.Add("g_m_y_salvagoon_03");                //"Salvadoran Goon 3");  
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("g_f_y_lost_01");                //"The Lost MC Female");  
                    sPeddy.Add("g_m_y_lost_01");                //"The Lost MC Male");  
                    sPeddy.Add("g_m_y_lost_02");                //"The Lost MC Male 2");  
                    sPeddy.Add("g_m_y_lost_03");                //"The Lost MC Male 3");
                    sPeddy.Add("A_F_M_GenBiker_01");                //
                    sPeddy.Add("A_M_M_GenBiker_01");                //
                }
                else
                {
                    sPeddy.Add("g_m_y_strpunk_01");                //"Street Punk");  
                    sPeddy.Add("g_m_y_strpunk_02");                //"Street Punk 2");  
                    sPeddy.Add("G_M_M_GenThug_01");
                    sPeddy.Add("G_M_M_Goons_01");
                }
            }       //GangStars--Subset
            else if (iPedtype == 9)
            {
                sPeddy.Add("a_f_y_epsilon_01");                //"Epsilon Female");  
                sPeddy.Add("a_m_y_epsilon_01");                //"Epsilon Male");  
                sPeddy.Add("a_m_y_epsilon_02");                //"Epsilon Male 2"); 
            }       //Epslon 
            else if (iPedtype == 10)
            {
                sPeddy.Add("a_f_y_fitness_01");                //"Fitness Female");  
                sPeddy.Add("a_f_y_fitness_02");                //"Fitness Female 2");  
                sPeddy.Add("a_f_y_runner_01");                //"Jogger Female");
                sPeddy.Add("a_f_y_tennis_01");                //"Tennis Player Female");  
                sPeddy.Add("a_m_y_runner_01");                //"Jogger Male");  
                sPeddy.Add("a_m_y_runner_02");                //"Jogger Male 2"); 
            }       //Jogger
            else if (iPedtype == 11)
            {
                sPeddy.Add("a_f_y_golfer_01");                //"Golfer Young Female");  
                sPeddy.Add("a_m_m_golfer_01");                //"Golfer Male");  
                sPeddy.Add("a_m_y_golfer_01");                //"Golfer Young Male");  
            }       //Golfer
            else if (iPedtype == 12)
            {
                sPeddy.Add("a_f_y_hiker_01");                //"Hiker Female");  
                sPeddy.Add("a_m_y_hiker_01");                //"Hiker Male");  
            }       //Hiker
            else if (iPedtype == 13)
            {
                sPeddy.Add("a_f_y_juggalo_01");                //"Juggalo Female");  
                sPeddy.Add("a_m_y_juggalo_01");                //"Juggalo Male"); 
                sPeddy.Add("a_f_y_rurmeth_01");                //"Rural Meth Addict Female");  
                sPeddy.Add("a_m_m_rurmeth_01");                //"Rural Meth Addict Male");  
            }       //Meth
            else if (iPedtype == 14)
            {
                sPeddy.Add("a_f_m_salton_01");                //"Salton Female");  
                sPeddy.Add("a_f_o_salton_01");                //"Salton Old Female");  
                sPeddy.Add("a_m_m_farmer_01");                //"Farmer"); 
                sPeddy.Add("a_m_m_hillbilly_01");                //"Hillbilly Male");  
                sPeddy.Add("a_m_m_hillbilly_02");                //"Hillbilly Male 2");  
                sPeddy.Add("a_m_y_methhead_01");                //"Meth Addict");  

                sPeddy.Add("a_m_m_salton_01");                //"Salton Male");  
                sPeddy.Add("a_m_m_salton_02");                //"Salton Male 2");  
                sPeddy.Add("a_m_m_salton_03");                //"Salton Male 3");  
                sPeddy.Add("a_m_m_salton_04");                //"Salton Male 4");  
                sPeddy.Add("a_m_o_salton_01");                //"Salton Old Male");  
                sPeddy.Add("a_m_y_salton_01");                //"Salton Young Male");  
                sPeddy.Add("s_m_m_cntrybar_01");                //"Bartender (Rural)"); 
            }       //Rural 
            else if (iPedtype == 15)
            {
                sPeddy.Add("a_f_y_skater_01");                //"Skater Female");  
                sPeddy.Add("a_m_y_cyclist_01");                //"Cyclist Male");  
                sPeddy.Add("a_m_y_dhill_01");                //"Downhill Cyclist"); 
                sPeddy.Add("a_m_y_roadcyc_01");                //"Road Cyclist");  
                sPeddy.Add("a_m_y_skater_01");                //"Skater Young Male");  
                sPeddy.Add("a_m_y_skater_02");                //"Skater Young Male 2");  
                sPeddy.Add("a_m_m_tennis_01");                //"Tennis Player Male");  
            }       //Cycles
            else if (iPedtype == 16)
            {
                sPeddy.Add("a_m_y_gay_01");                //"Gay Male");  
                sPeddy.Add("a_m_y_gay_02");                //"Gay Male 2"); 
                sPeddy.Add("a_m_m_tranvest_01");                //"Transvestite Male");  
                sPeddy.Add("a_m_m_tranvest_02");                //"Transvestite Male 2"); 
            }       //LGBTQWSTRVX
            else if (iPedtype == 17)
            {
                sPeddy.Add("a_f_y_beach_01");                //"Beach Young Female"); --Acc set to 1 for swimm 
                sPeddy.Add("a_m_m_beach_02");                //"Beach Male 2");--set torso to 0 for swim
            }       //Pool Peds
            else if (iPedtype == 18)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("mp_f_bennymech_01");                //"Benny Mechanic (Female)"); 
                    sPeddy.Add("s_m_m_autoshop_01");                //"Autoshop Worker");  
                    sPeddy.Add("s_m_m_autoshop_02");                //"Autoshop Worker 2");  
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("s_f_y_bartender_01");                //"Bartender");  
                    sPeddy.Add("s_f_y_clubbar_01");                //"Club Bartender Female"); 
                    sPeddy.Add("s_m_y_barman_01");                //"Barman");
                    sPeddy.Add("s_m_y_waiter_01");                //"Waiter"); 
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("s_f_y_factory_01");                //"Factory Worker Female");  
                    sPeddy.Add("s_f_m_sweatshop_01");                //"Sweatshop Worker");  
                    sPeddy.Add("s_f_y_sweatshop_01");                //"Sweatshop Worker Young");  
                    sPeddy.Add("S_F_M_Warehouse_01");
                    sPeddy.Add("S_M_M_Warehouse_01");
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("mp_m_shopkeep_01");                //"Shopkeeper (Male)"); 
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("s_f_y_scrubs_01");                //"Hospital Scrubs Female");  
                    sPeddy.Add("s_m_m_doctor_01");                //"Doctor"); 
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("s_f_m_maid_01");                //"Maid");  
                    sPeddy.Add("s_f_y_migrant_01");                //"Migrant Female--cleaner");  
                    sPeddy.Add("s_m_m_migrant_01");                //"Migrant Male");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("mp_s_m_armoured_01");                //"Armoured Van Security Male"); 
                    sPeddy.Add("s_m_m_armoured_01");                //"Armoured Van Security");  
                    sPeddy.Add("s_m_m_armoured_02");                //"Armoured Van Security 2"); 
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("s_m_m_chemsec_01");                //"Chemical Plant Security");  
                    sPeddy.Add("mp_m_securoguard_01");                //"Securoserve Guard (Male)"); 
                    sPeddy.Add("s_m_m_security_01");                //"Security Guard");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("s_m_y_autopsy_01");                //"Autopsy Tech");  
                    sPeddy.Add("s_m_m_scientist_01");                //"Scientist");  
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("g_m_m_chemwork_01");                //"Chemical Plant Worker");  
                }
                else if (iSubType == 11)
                {
                    sPeddy.Add("s_m_y_construct_01");                //"construction Worker");  
                    sPeddy.Add("s_m_y_construct_02");                //"construction Worker 2");  
                }
                else if (iSubType == 12)
                {
                    sPeddy.Add("s_m_m_dockwork_01");                //"Dock Worker");  
                    sPeddy.Add("s_m_y_dockwork_01");                //"Dock Worker");  
                }
                else if (iSubType == 13)
                {
                    sPeddy.Add("s_m_y_airworker");                //"Air Worker Male"); 
                    sPeddy.Add("s_m_y_dwservice_01");                //"DW Airport Worker");  
                    sPeddy.Add("s_m_y_dwservice_02");                //"DW Airport Worker 2");   
                }
                else if (iSubType == 14)
                {
                    sPeddy.Add("s_m_y_garbage");                //"Garbage Worker");  
                }
                else if (iSubType == 15)
                {
                    sPeddy.Add("s_m_m_gardener_01");                //"Gardener");  
                    sPeddy.Add("s_m_m_lathandy_01");                //"Latino Handyman Male");  
                }
                else if (iSubType == 16)
                {
                    sPeddy.Add("s_m_m_lsmetro_01");                //"LS Metro Worker Male");  
                }
                else if (iSubType == 17)
                {
                    sPeddy.Add("s_m_m_gentransport");                //"Transport Worker Male");  
                }
                else if (iSubType == 18)
                {
                    sPeddy.Add("s_m_y_pestcont_01");                //"Pest Control");  
                }
                else if (iSubType == 19)
                {
                    sPeddy.Add("s_m_m_postal_01");                //"Postal Worker Male");  
                    sPeddy.Add("s_m_m_postal_02");                //"Postal Worker Male 2");  
                }
                else if (iSubType == 20)
                {
                    sPeddy.Add("s_m_m_ups_01");                //"UPS Driver");  
                    sPeddy.Add("s_m_m_ups_02");                //"UPS Driver 2");  
                }
                else if (iSubType == 21)
                {
                    sPeddy.Add("s_m_m_strvend_01");                //"Street Vendor");  
                    sPeddy.Add("s_m_y_strvend_01");                //"Street Vendor Young");  
                }
                else if (iSubType == 22)
                {
                    sPeddy.Add("s_m_y_valet_01");                //"Valet");  
                }
                else
                {
                    sPeddy.Add("s_m_y_winclean_01");                //"Window Cleaner");   
                }
            }       //Workers--Subset
            else if (iPedtype == 19)
            {
                sPeddy.Add("a_m_y_jetski_01");                //"Jetskier");  
            }       //jet ski
            else if (iPedtype == 20)
            {
                sPeddy.Add("a_m_y_motox_01");                //"Motocross Biker");  
                sPeddy.Add("a_m_y_motox_02");                //"Motocross Biker 2"); 
            }       //Bike/ATV Male
            else if (iPedtype == 21)
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("s_f_y_baywatch_01");                //"Baywatch Female"); 
                    sPeddy.Add("s_m_y_baywatch_01");                //"Baywatch Male"); 
                }
                else if (iSubType == 2)
                {
                    sPeddy.Add("s_m_y_uscg_01");                //"US Coastguard"); 
                }
                else if (iSubType == 3)
                {
                    sPeddy.Add("s_m_y_cop_01");                //"Cop Male");  
                    sPeddy.Add("s_f_y_cop_01");                //"Cop Female");
                }
                else if (iSubType == 4)
                {
                    sPeddy.Add("s_m_y_hwaycop_01");                //"Highway Cop");  
                }
                else if (iSubType == 5)
                {
                    sPeddy.Add("s_f_y_ranger_01");                //"Ranger Female"); 
                    sPeddy.Add("s_m_y_ranger_01");                //"Ranger Male");  
                }
                else if (iSubType == 6)
                {
                    sPeddy.Add("s_f_y_sheriff_01");                //"Sheriff Female"); 
                    sPeddy.Add("s_m_y_sheriff_01");                //"Sheriff Male");  
                }
                else if (iSubType == 7)
                {
                    sPeddy.Add("s_m_m_fibsec_01");                //"FIB Security"); 
                }
                else if (iSubType == 8)
                {
                    sPeddy.Add("s_m_y_swat_01");                //"SWAT");  
                }
                else if (iSubType == 9)
                {
                    sPeddy.Add("s_m_y_armymech_01");                //"Army Mechanic");  
                    sPeddy.Add("s_m_m_ccrew_01");                //"Crew Member"); 
                    sPeddy.Add("s_m_y_blackops_01");                //"Black Ops Soldier");  
                    sPeddy.Add("s_m_y_blackops_02");                //"Black Ops Soldier 2");  
                    sPeddy.Add("s_m_y_blackops_03");                //"Black Ops Soldier 3");  
                    sPeddy.Add("s_m_m_marine_01");                //"Marine");  
                    sPeddy.Add("s_m_m_marine_02");                //"Marine 2");  
                    sPeddy.Add("s_m_y_marine_01");                //"Marine Young");  
                    sPeddy.Add("s_m_y_marine_02");                //"Marine Young 2");  
                    sPeddy.Add("s_m_y_marine_03");                //"Marine Young 3"); 
                }
                else if (iSubType == 10)
                {
                    sPeddy.Add("s_m_m_paramedic_01");                //"Paramedic"); 
                }
                else
                {
                    sPeddy.Add("s_m_y_fireman_01");                //"Fireman Male"); 
                }
            }       //Services
            else if (iPedtype == 22)
            {
                if (iSubType == 1)
                    sPeddy.Add("s_m_y_pilot_01");                //"Pilot");  
                else if (iSubType == 2)
                    sPeddy.Add("s_m_m_pilot_02");                //"Pilot 2"); 
                else if (iSubType == 3)
                    sPeddy.Add("s_m_m_pilot_01");                //"Pilot");  
                else
                    sPeddy.Add("mp_f_helistaff_01");                //"Heli-Staff Female" />
            }       //Pilot
            else if (iPedtype == 23)
            {
                if (iSubType == 1)
                    sPeddy.Add("a_c_boar");                //"a_c_boar");  
                else if (iSubType == 2)
                {
                    sPeddy.Add("a_c_cat_01");
                    sPeddy.Add("a_c_husky");
                    sPeddy.Add("a_c_poodle");
                    sPeddy.Add("a_c_pug");
                    sPeddy.Add("a_c_retriever");
                    sPeddy.Add("a_c_rottweiler");
                    sPeddy.Add("a_c_shepherd");
                    sPeddy.Add("a_c_westy");
                }                //"Cats/dogs"); 
                else if (iSubType == 3)
                    sPeddy.Add("a_c_pigeon");                //"a_c_pigeon" />
                else if (iSubType == 4)
                    sPeddy.Add("a_c_rat");                //"a_c_rat" />
                else if (iSubType == 5)
                    sPeddy.Add("a_c_cow");                //"a_c_cow" />
                else if (iSubType == 6)
                    sPeddy.Add("a_c_coyote");                //"a_c_coyote" />
                else if (iSubType == 7)
                    sPeddy.Add("a_c_crow");                //"a_c_crow" />
                else if (iSubType == 8)
                {
                    sPeddy.Add("a_c_rabbit_01");                //"a_c_rabbit_01" />
                    sPeddy.Add("a_c_deer");                //"a_c_deer" />
                }
                else if (iSubType == 9)
                    sPeddy.Add("a_c_hen");                //"a_c_hen" />
                else if (iSubType == 10)
                    sPeddy.Add("a_c_mtlion");                //"mountain lion" />
                else if (iSubType == 11)
                    sPeddy.Add("a_c_pig");                //"a_c_pig" />
                else if (iSubType == 12)
                {
                    sPeddy.Add("a_c_dolphin");                //"fish/sharks" />
                    sPeddy.Add("a_c_fish");
                    sPeddy.Add("a_c_sharkhammer");
                    sPeddy.Add("a_c_humpback");
                    sPeddy.Add("a_c_killerwhale");
                    sPeddy.Add("a_c_stingray");
                    sPeddy.Add("a_c_sharktiger");
                }
                else if (iSubType == 13)
                    sPeddy.Add("a_c_chickenhawk");                //"a_c_chickenhawk");  
                else
                {
                    sPeddy.Add("a_c_cormorant");                //"a_c_cormorant" />
                    sPeddy.Add("a_c_seagull");
                }
            }       //animals
            else if (iPedtype == 24)
            {
                sPeddy.Add("csb_prologuedriver");
                sPeddy.Add("csb_prolsec");
                sPeddy.Add("cs_prolsec_02");
                sPeddy.Add("ig_prolsec_02");
                sPeddy.Add("u_f_o_prolhost_01");
                sPeddy.Add("u_f_m_promourn_01");
            }       //Yankton
            else
            {
                if (iSubType == 1)
                {
                    sPeddy.Add("A_C_Panther");
                }       //A_C_Panther
                else if (iSubType == 2)
                {
                    sPeddy.Add("A_F_Y_Beach_02");
                    sPeddy.Add("A_M_O_Beach_02");
                    sPeddy.Add("A_M_Y_Beach_04");
                    sPeddy.Add("A_F_Y_ClubCust_04");
                    sPeddy.Add("A_M_Y_ClubCust_04");
                }       //A_F_Y_Beach_02
                else if (iSubType == 3)
                {
                    sPeddy.Add("G_M_M_CartelGuards_01");
                    sPeddy.Add("G_M_M_CartelGuards_02");
                    sPeddy.Add("S_M_M_HighSec_04");
                }       //Guard
                else if (iSubType == 4)
                {
                    sPeddy.Add("S_F_Y_BeachBarStaff_01");
                }       //Bar
                else if (iSubType == 5)
                {
                    sPeddy.Add("S_M_M_DrugProcess_01");
                    sPeddy.Add("S_M_M_FieldWorker_01");
                }       //worker
                else if (iSubType == 6)
                {
                    sPeddy.Add("IG_Pilot");
                }       //pilot
                else
                {
                    sPeddy.Add("CSB_JIO");
                    sPeddy.Add("CSB_JuanStrickler");
                    sPeddy.Add("CSB_MJO");
                    sPeddy.Add("CSB_SSS");
                    sPeddy.Add("IG_ARY");
                    sPeddy.Add("IG_JIO");
                    sPeddy.Add("IG_MJO");
                    sPeddy.Add("IG_OldRichGuy");
                    sPeddy.Add("IG_SSS");
                }

                //sPeddy.Add("S_F_Y_ClubBar_02");
                //sPeddy.Add("S_M_M_Bouncer_02");

            }     //Cayo Perico

            if (sPeddy.Count() == 1)
                sPed = sPeddy[0];
            else
                sPed = sPeddy[RandomX.RandInt(0, sPeddy.Count() - 1)];

            return sPed;
        }
        public static Prop PropBuild(string sPop, Vector3 Local, Vector3 Rotate, int iPropTask)
        {
            LoggerLight.Loggers("MyPropBuild, sPop == " + sPop + ", iPropTask == " + iPropTask);

            Prop Propper;

            int iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, sPop);

            if (!Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, iPropHash))
            {
                LoggerLight.Loggers("BuildProp, spropMissing...");
                iPropHash = Function.Call<int>(Hash.GET_HASH_KEY, "zprop_bin_01a_old");
            }

            Function.Call(Hash.REQUEST_MODEL, iPropHash);
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, iPropHash))
                Script.Wait(1);

            int iProps = Function.Call<int>(Hash.CREATE_OBJECT, iPropHash, Local.X, Local.Y, Local.Z, false, true, false);
            Propper = new Prop(iProps);

            if (Propper.Exists())
            {
                Propper.Rotation = Rotate;
                Propper.IsPersistent = true;

                LoggerLight.SendRequest("MyProp_" + Propper.Handle, DataStore.sSaveArts, false);
                DataStore.PropList.Add(new Prop(Propper.Handle));

                if (iPropTask > 0)
                    RsActions.PropTasks(Propper, iPropTask);
            }
            else
                Propper = null;

            Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, iPropHash);

            return Propper;
        }
        public static Prop MyPropBuild(string sPop, Vector3 Local, Vector3 Rotate, int iPropTask)
        {
            Prop pX = null;

            while (pX == null)
            {
                pX = PropBuild(sPop, Local, Rotate, iPropTask);
                Script.Wait(10);
            }

            return pX;
        }
        public static AnimatedActions DanceList(bool bMale, int iSpeed)
        {
            LoggerLight.Loggers("DanceList, bMale == " + bMale + ", iSpeed == " + iSpeed);

            if (bMale)
            {
                if (iSpeed == 1)
                {
                    return MaleDance01[RandomX.FindRandom("DanceListM01", 0, MaleDance01.Count - 1)];
                }
                else if (iSpeed == 2)
                {
                    return MaleDance02[RandomX.FindRandom("DanceListM02", 0, MaleDance02.Count - 1)];
                }
                else
                {
                    return MaleDance03[RandomX.FindRandom("DanceListM03", 0, MaleDance03.Count - 1)];
                }
            }
            else
            {
                if (iSpeed == 1)
                {
                    return FemaleDance01[RandomX.FindRandom("DanceListF01", 0, FemaleDance01.Count - 1)];
                }
                else if (iSpeed == 2)
                {
                    return FemaleDance02[RandomX.FindRandom("DanceListF02", 0, FemaleDance02.Count - 1)];
                }
                else
                {
                    return FemaleDance03[RandomX.FindRandom("DanceListF03", 0, FemaleDance03.Count-1)];
                }
            }
        }
        public static string AddAnyPed(int iType)
        {
            LoggerLight.Loggers("RsReturns.AddAnyPed");

            List<string> sPeds = new List<string>();

            if (iType == 1)
            {
                sPeds.Add("a_f_o_soucent_01");                //"South Central Old Female");  
                sPeds.Add("a_f_o_soucent_02");                //"South Central Old Female 2"); 
                sPeds.Add("a_f_o_indian_01");                //"Indian Old Female");  
                sPeds.Add("a_f_o_genstreet_01");                //"General Street Old Female");  
                sPeds.Add("a_f_o_ktown_01");                //"Korean Old Female");  
            }           //Old dear 
            else if (iType == 2)
            {
                sPeds.Add("a_f_m_beach_01");                //"Beach Female");   
                sPeds.Add("a_f_y_hippie_01");                //"Hippie Female"); 
                sPeds.Add("a_m_m_beach_01");                //"Beach Male");  
                sPeds.Add("a_m_y_beach_01");                //"Beach Young Male");  
                sPeds.Add("a_m_y_beach_03");                //"Beach Young Male 3"); 
                sPeds.Add("a_m_y_sunbathe_01");                //"Sunbather Male");  
                sPeds.Add("a_m_y_beachvesp_01");                //"Vespucci Beach Male");  
                sPeds.Add("a_m_y_beachvesp_02");                //"Vespucci Beach Male 2"); 
                sPeds.Add("A_F_Y_Beach_02");
                sPeds.Add("A_M_O_Beach_02");
                sPeds.Add("A_M_Y_Beach_04");
            }           //DancingBeach

            return sPeds[RandomX.RandInt(0, sPeds.Count() - 1)];
        }
        public static float RandFloat(float fMin, float fMax)
        {
            float iMyRanFlow = Function.Call<float>(Hash.GET_RANDOM_FLOAT_IN_RANGE, fMin, fMax);

            return iMyRanFlow;
        }
        public static List<Tattoo> TattoosList(int iPed, int iZone)
        {
            LoggerLight.Loggers("TattoosList, iPed == " + iPed + ", iZone == " + iZone);

            bool bEmpty = false;
            List<Tattoo> TatList = new List<Tattoo>();

            if (iPed == 1)
            {
                if (iZone == 1)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_018", Name = "Impotent Rage" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_014", Name = "Chinese Dragon" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_008", Name = "Trinity Knot" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_004", Name = "Lucky" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_020", Name = "Way of the Gun" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_017", Name = "Whiskey Life" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_015", Name = "Flaming Shamrock" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_006", Name = "Eagle and Serpent" });
                }//TORSO
                else if (iZone == 2)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_003", Name = "The Rose of My Heart" });
                }//HEAD
                else if (iZone == 3)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_019", Name = "Dragon" });//     
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_012", Name = "Faith" });//   
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_010", Name = "Lady M" });//   
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_009", Name = "Lucky Celtic Dogs" });//  
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_007", Name = "Mermaid" });//       
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_000", Name = "Mandy" });//    
                }//LEFT ARM 
                else if (iZone == 4)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_016", Name = "Michael and Amanda" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_013", Name = "Flower Mural" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_005", Name = "Virgin Mary" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_001", Name = "Family is Forever" });
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_002", Name = "Smoking Dagger" });
                }//LEFT LEG
                else
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "MK_011", Name = "Tiki Pinup " });
                }//RIGHT LEG
            }// Michael
            else if (iPed == 2)
            {
                if (iZone == 1)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_038", Name = "Angel of Los Santos" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_010", Name = "Grace and Power" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_004", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_039", Name = "Impotent Rage" });//   
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_037", Name = "Los Santos Bills" });// 
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_036", Name = "These Streets" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_035", Name = "Families" });//      
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_032", Name = "LS Flames" });//  
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_031", Name = "Fam 4 Life" });//   
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_030", Name = "Families Symbol" });//      
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_029", Name = "FAM Power" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_028", Name = "Flaming Cross" });//  
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_021", Name = "Chamberlain Families LS" });//  
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_020", Name = "LS Heart " });//   
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_018", Name = "Families Kings" });//  
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_011", Name = "Forum4Life" });//      
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_000", Name = "Chamberlain" });//     
                    //Not in List
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_025", Name = "Skull on the Cross" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_024", Name = "Skull and Dragon" });
                }//TORSO
                else if (iZone == 2)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_022", Name = "Chamberlain Families" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_005", Name = "Faith" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_034", Name = "LS Bold" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_033", Name = "LS Script" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_014", Name = "F King" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_013", Name = "F Crown " });
                }//HEAD
                else if (iZone == 3)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_019", Name = "FAMILIES" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_017", Name = "Lion" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_016", Name = "Dragon Mural" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_007", Name = "Serpent Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_001", Name = "Brotherhood" });
                }//LEFT ARM
                else if (iZone == 4)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_023", Name = "Fiery Dragon" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_012", Name = "Oriental Mural" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_009", Name = "Chop" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_008", Name = "Mother" });//    
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_006", Name = "Serpents" });//    
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_027", Name = "Hottie" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_015", Name = "The Warrior" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_002", Name = "Dragons" });
                }//LEFT LEG
                else
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_026", Name = "Trust No One" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "fr_003", Name = "Melting Skull" });
                }//RIGHT LEG
            }// Franklin
            else if (iPed == 3)
            {
                if (iZone == 1)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_032", Name = "Lucky" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_031", Name = "Unzipped" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_026", Name = "Skulls and Rose" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_022", Name = "Chinese Dragon" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_033", Name = "Impotent Rage" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_030", Name = "Fuck Cops" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_029", Name = "Smiley" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_028", Name = "Ace" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_027", Name = "Piggy" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_023", Name = "Monster Pups" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_021", Name = "Stone Cross" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_015", Name = "Tweaker" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_013", Name = "Betraying Scroll" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_012", Name = "Eye Catcher" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_006", Name = "Blackjack" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_004", Name = "Evil Clown" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_000", Name = "Imperial Douche" });
                }//TORSO
                else if (iZone == 2)
                {
                    bEmpty = true;
                }//HEAD
                else if (iZone == 3)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_024", Name = "Grim Reaper Smoking Gun" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_018", Name = "Dope Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_017", Name = "The Wages of Sin" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_016", Name = "Dragon and Dagger" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_003", Name = "Zodiac Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_001", Name = "R.I.P Michael" });
                }//LEFT ARM
                else if (iZone == 4)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_020", Name = "Indian Ram" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_014", Name = "Muertos" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_010", Name = "Flaming Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_009", Name = "Broken Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_008", Name = "Dagger" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_007", Name = "Tribal" });
                }//RIGHT ARM
                else if (iZone == 5)
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_011", Name = "Serpant Skull" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_002", Name = "Grim Reaper" });
                }//LEFT LEG
                else
                {
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_025", Name = "Freedom" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_019", Name = "Flaming Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "singleplayer_overlays", TatName = "TP_005", Name = "Love to Hate" });
                }//RIGHT LEG
            }// Trevor
            else if (iPed == 4)
            {
                if (iZone == 1)
                {
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_F", Name = "Painted Micro SMG" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_F", Name = "Weapon King" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_F", Name = "Sniff Sniff" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_F", Name = "Charm Pattern" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_F", Name = "Witch & Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_F", Name = "Pumpkin Bug" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_F", Name = "Sinner" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_F", Name = "Gray Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_F", Name = "Hood Heart" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_F", Name = "Los Santos Tag" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_F", Name = "Blessed Boombox" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_F", Name = "Chamberlain Hills" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_F", Name = "Smoking Barrels" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_F", Name = "Dollar Guns Crossed" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_F", Name = "Skull Surfer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_F", Name = "Speaker Tower" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_F", Name = "Record Shot" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_F", Name = "Record Head" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_F", Name = "Tropical Sorcerer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_F", Name = "Rose Panther" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_F", Name = "Paradise Ukulele" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_F", Name = "Paradise Nap" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_F", Name = "Wild Dancers" });//

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_F", Name = "Space Rangers" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_F", Name = "Robot Bubblegum" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_F", Name = "LS Shield" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_F", Name = "Howitzer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_F", Name = "Bananas Gone Bad" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_F", Name = "Epsilon" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_F", Name = "Mount Chiliad" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_F", Name = "Bigfoot" });//

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_F", Name = "Play Your Ace" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_F", Name = "The Table" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_F", Name = "Show Your Hand" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_F", Name = "Roll the Dice" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_F", Name = "The Jolly Joker" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_F", Name = "Life's a Gamble" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_F", Name = "Photo Finish" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_F", Name = "Till Death Do Us Part" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_F", Name = "Snake Eyes" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_F", Name = "777" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_F", Name = "Wheel of Suits" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_F", Name = "Jackpot" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_F", Name = "Molon Labe" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_F", Name = "Dragon Slayer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_F", Name = "Spartan and Horse" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_F", Name = "Spartan and Lion" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_F", Name = "Odin and Raven" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_F", Name = "Samurai Combat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_F", Name = "Weathered Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_F", Name = "Spartan Shield" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_F", Name = "Norse Rune" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_F", Name = "Ghost Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_F", Name = "Kabuto" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_F", Name = "Claimed By The Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_F", Name = "Pirate Captain" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_F", Name = "X Marks The Spot" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_F", Name = "Finders Keepers" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_F", Name = "Framed Tall Ship" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_F", Name = "Skull Compass" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_F", Name = "Torn Wings" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_F", Name = "Tall Ship Conflict" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_F", Name = "Never Surrender" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_F", Name = "Give Nothing Back" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_F", Name = "Eagle Eyes" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_F", Name = "Parachute Belle" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_F", Name = "Balloon Pioneer" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_F", Name = "Winged Bombshell" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_F", Name = "Pilot Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_F", Name = "Explosive Heart" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_F", Name = "Pistol Wings" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_F", Name = "Dual Wield Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_F", Name = "Backstabber" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_F", Name = "Wolf Insignia" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_F", Name = "Butterfly Knife" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_F", Name = "Crossed Weapons" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_F", Name = "Bullet Proof" });

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_F", Name = "Talk Shit Get Hit" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_F", Name = "Take the Wheel" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_F", Name = "Serpents of Destruction" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_F", Name = "Tuned to Death" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_F", Name = "Power Plant" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_F", Name = "Block Back" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_F", Name = "Ride Forever" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_F", Name = "Brothers For Life" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_F", Name = "Flaming Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_F", Name = "Clawed Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_F", Name = "R.I.P. My Brothers" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_F", Name = "Freedom Wheels" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_F", Name = "Chopper Freedom" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_F", Name = "Racing Doll" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_F", Name = "Full Throttle" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_F", Name = "Brapp" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_F", Name = "Monkey Chopper" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_F", Name = "Big Grills" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_F", Name = "Feather Road Kill" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_F", Name = "Man's Ruin" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_F", Name = "Majestic Finish" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_F", Name = "Winged Wheel" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_F", Name = "Road Kill" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_F", Name = "Reign Over" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_F", Name = "Dead Pretty" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_F", Name = "Love the Game" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_F", Name = "SA Assault" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_F", Name = "Sad Angel" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_F", Name = "Love is Blind" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_F", Name = "Bad Angel" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_F", Name = "Amazon" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_F", Name = "Geometric Design" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_F", Name = "Cloaked Angel" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_024_F", Name = "Feather Mural" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_006_F", Name = "Adorned Wolf" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_015", Name = "Japanese Warrior" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_011", Name = "Roaring Tiger" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_006", Name = "Carp Shaded" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_005", Name = "Carp Outline" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_046", Name = "Triangles" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_041", Name = "Tooth" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_032", Name = "Paper Plane" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_031", Name = "Skateboard" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_030", Name = "Shark Fin" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_025", Name = "Watch Your Step" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_024", Name = "Pyamid" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_012", Name = "Antlers" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_011", Name = "Infinity" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_000", Name = "Crossed Arrows" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_001", Name = "Gold Digger" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Back_000", Name = "Respect" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_000", Name = "Sea Horses" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_002", Name = "Shrimp" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Should_001", Name = "Catfish" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_000", Name = "Rock Solid" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Back_001", Name = "Hibiscus Flower Duo" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_045", Name = "Skulls and Rose" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_030", Name = "Lucky Celtic Dogs" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_020", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_019", Name = "The Wages of Sin" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_016", Name = "Evil Clown" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_013", Name = "Eagle and Serpent" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_011", Name = "LS Script" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_009", Name = "Skull on the Cross" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_019", Name = "Clown Dual Wield Dollars" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_018", Name = "Clown Dual Wield" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_017", Name = "Clown and Gun" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_016", Name = "Clown" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_014", Name = "Trust No One" });//Car Bomb Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_008", Name = "Los Santos Customs" });//Mod a Car Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_005", Name = "Angel" });//Win Every Game Mode Award
                    //Not In List
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_046", Name = "Zip?" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_F", Name = "???" });
                }//BACK
                else if (iZone == 2)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_004_F", Name = "Herbal Bouquet" }); ;
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_005_F", Name = "Cash Krampus" }); ;
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_006_F", Name = "All In One Night" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_007_F", Name = "A Little Present For You" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_014_F", Name = "Masked Machete Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_015_F", Name = "Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_016_F", Name = "Powwer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_017_F", Name = "Two Headed Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_018_F", Name = "Dudes" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_019_F", Name = "Fooligan Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_020_F", Name = "Vile Smile" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_021_F", Name = "Demon Skull Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_022_F", Name = "Fatal Incursion Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_023_F", Name = "Many-Headed Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_024_F", Name = "Demon Stitches" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_025_F", Name = "Collector" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_040_F", Name = "Monkey" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_041_F", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_042_F", Name = "Snake" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_043_F", Name = "Goat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_044_F", Name = "Rat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_045_F", Name = "Rabbit" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_046_F", Name = "Ox" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_047_F", Name = "Pig" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_048_F", Name = "Rooster" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_049_F", Name = "Dog" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_050_F", Name = "Horse" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_051_F", Name = "Tiger" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_F", Name = "Bullet Mouth" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_F", Name = "Smoking Barrel" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_F", Name = "Carved Pumpkin" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_F", Name = "Branched Werewolf" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_F", Name = "Winged Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_F", Name = "Shrieking Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_F", Name = "Swords & City" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_F", Name = "All From The Same Tree" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_F", Name = "King of the Jungle" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_F", Name = "Night Owl" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_F", Name = "Techno Glitch" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_F", Name = "Paradise Sirens" });//

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_F", Name = "LS Panic" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_F", Name = "LS City" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_F", Name = "Dignity" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_F", Name = "Davis" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_F", Name = "Blood Money" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_F", Name = "Royal Flush" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_F", Name = "In the Pocket" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_F", Name = "Spartan Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_F", Name = "Medusa's Gaze" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_F", Name = "Strike Force" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_F", Name = "Native Warrior" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_F", Name = "Thor - Goblin" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_F", Name = "Dead Tales" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_F", Name = "Lost At Sea" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_F", Name = "No Honor" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_F", Name = "Bless The Dead" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_F", Name = "Turbulence" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_F", Name = "Micro SMG Chain" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_F", Name = "Crowned Weapons" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_F", Name = "Dog Tags" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_F", Name = "Dollar Daggers" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_F", Name = "We Are The Mods!" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_F", Name = "Faggio" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_F", Name = "Reaper Vulture" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_F", Name = "Unforgiven" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_F", Name = "No Regrets" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_F", Name = "Brotherhood of Bikes" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_F", Name = "Western Eagle" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_F", Name = "Bone Wrench" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_F", Name = "American Dream" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_F", Name = "Western MC" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_F", Name = "Gruesome Talons" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_F", Name = "Skeletal Chopper" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_F", Name = "Demon Crossbones" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_F", Name = "Made In America" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_F", Name = "Both Barrels" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_F", Name = "Demon Rider" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_F", Name = "Ram Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_F", Name = "Sugar Skull Trucker" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_F", Name = "Punk Road Hog" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_F", Name = "Engine Heart" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_F", Name = "Vintage Bully" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_F", Name = "Wheels of Death" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_F", Name = "Death Behind" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_F", Name = "Royal Kiss" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_F", Name = "Royal Takeover" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_F", Name = "Love Gamble" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_F", Name = "Holy Mary" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_F", Name = "King Fight" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_F", Name = "Cobra Dawn" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_F", Name = "Reaper Sway" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_F", Name = "Geometric Galaxy" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_F", Name = "The Howler" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_F", Name = "Smoking Sisters" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_F", Name = "Ancient Queen" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_F", Name = "Flying Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_F", Name = "Eye of the Griffin" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_019", Name = "Royal Dagger Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_018", Name = "Royal Dagger Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_017", Name = "Loose Lips Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_016", Name = "Loose Lips Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_009", Name = "Time To Die" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_047", Name = "Cassette" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_033", Name = "Stag" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_013", Name = "Boombox" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_002", Name = "Chemistry" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_002", Name = "Love Money" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_001", Name = "Makin' Money" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Chest_000", Name = "High Roller" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_001", Name = "Anchor" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_000", Name = "Anchor" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Chest_002", Name = "Los Santos Wreath" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_044", Name = "Stone Cross" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_034", Name = "Flaming Shamrock" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_025", Name = "LS Bold" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_024", Name = "Flaming Cross" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_010", Name = "LS Flames" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_013", Name = "Seven Deadly Sins" });//Kill 1000 Players Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_012", Name = "Embellished Scroll" });//Kill 500 Players Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_011", Name = "Blank Scroll" });////Kill 100 Players Award?
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_003", Name = "Blackjack" });
                    //
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Female_Crew_Tat_000", Name = "Crew Emblem" });
                }//CHEST
                else if (iZone == 3)
                {
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_F", Name = "Concealed" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_F", Name = "Cursed Saki" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_F", Name = "Smouldering Bat & Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_F", Name = "Blaine County" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_F", Name = "Angry Possum" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_F", Name = "Floral Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_F", Name = "Beatbox Silhouette" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_F", Name = "Davis Flames" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_F", Name = "Radio Tape" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_F", Name = "Skeleton Breeze" });//

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_F", Name = "LadyBug" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_F", Name = "Fatal Incursion" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_F", Name = "Gambling Royalty" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_F", Name = "Cash Mouth" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_F", Name = "Rose and Aces" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_F", Name = "Skull of Suits" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_F", Name = "Spartan Warrior" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_F", Name = "Jolly Roger" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_F", Name = "See You In Hell" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_F", Name = "Dead Lies" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_F", Name = "Bombs Away" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_F", Name = "Win Some Lose Some" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_F", Name = "Cash Money" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_F", Name = "Biker Mount" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_F", Name = "Gas Guzzler" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_F", Name = "Gear Head" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_F", Name = "Skull Of Taurus" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_F", Name = "Web Rider" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_F", Name = "Bat Cat of Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_F", Name = "Punk Biker" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_F", Name = "Two Face" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_F", Name = "Lady Liberty" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_F", Name = "Gun Mic" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_F", Name = "Abstract Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_028", Name = "Executioner" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_013", Name = "Lizard" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_035", Name = "Sewn Heart" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_029", Name = "Sad" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_006", Name = "Feather Birds" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_002", Name = "Money Bag" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_001", Name = "Santo Capra Logo" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Stom_000", Name = "Diamond Back" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_000", Name = "Swallow" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_002", Name = "Dolphin" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Stom_001", Name = "Hibiscus Flower" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RSide_000", Name = "Love Dagger" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_036", Name = "Way of the Gun" });//500 Pistol kills Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_029", Name = "Trinity Knot" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_012", Name = "Los Santos Bills" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_004", Name = "Faith" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_004", Name = "Hustler" });//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_010_F", Name = "Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_011_F", Name = "Fooligan Tribal" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_012_F", Name = "Skull Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_013_F", Name = "Budonk-adonk!" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_F", Name = "Live Fast Mono" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_F", Name = "Live Fast Color" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_F", Name = "Branched Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_F", Name = "Scythed Corpse" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_F", Name = "Scythed Corpse & Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_F", Name = "Third Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_F", Name = "Pierced Third Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_F", Name = "Lip Drip" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_F", Name = "Skin Mask" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_F", Name = "Webbed Scythe" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_F", Name = "Oni Demon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_F", Name = "Bat Wings" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_F", Name = "Bright Diamond" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_F", Name = "Hustle" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_F", Name = "Black Widow" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_F", Name = "Clubs" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_F", Name = "Diamonds" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_F", Name = "Hearts" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_F", Name = "Thong's Sword" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_F", Name = "Wanted" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_F", Name = "UFO" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_F", Name = "Teddy Bear" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_F", Name = "Stitches" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_F", Name = "Space Monkey" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_F", Name = "Sleepy" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_F", Name = "On/Off" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_F", Name = "LS Wings" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_F", Name = "LS Star" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_F", Name = "Razor Pop" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_F", Name = "Lipstick Kiss" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_F", Name = "Green Leaf" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_F", Name = "Knifed" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_F", Name = "Ice Cream" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_F", Name = "Two Horns" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_F", Name = "Crowned" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_F", Name = "Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_F", Name = "Bandage" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_F", Name = "Assault Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_F", Name = "Animal" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_F", Name = "Ace of Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_F", Name = "Five Stars" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_F", Name = "Thief" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_F", Name = "Sinner" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_F", Name = "Lock and Load" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_F", Name = "Western Stylized" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_F", Name = "FTW" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_F", Name = "Morbid Arachnid" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_F", Name = "Flaming Quad" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_F", Name = "Bat Wheel" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_F", Name = "Toxic Spider" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_F", Name = "Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_F", Name = "Stunt Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_029", Name = "Beautiful Death" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_025", Name = "Snake Head Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_024", Name = "Snake Head Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_007", Name = "Los Muertos" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_021", Name = "Geo Fox" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_005", Name = "Beautiful Eye" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_001", Name = "Money Rose" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_Neck_000", Name = "Val-de-Grace Logo" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Tribal Butterfly" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_Neck_000", Name = "Little Fish" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_000", Name = "Skull" });//500 Headshots Award
                    //Not On the TatlIst     ...                            
                }//HEAD
                else if (iZone == 5)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_033_F", Name = "Fooligan Impotent Rage" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_030_F", Name = "Dude Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_026_F", Name = "Fooligan Clown" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_028_F", Name = "Dude Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_000_F", Name = "The Christmas Spirit" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_001_F", Name = "Festive Reaper" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_F", Name = "Bigness Chimp" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_F", Name = "Up-n-Atomizer Design" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_F", Name = "Rocket Launcher Girl" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_F", Name = "Laser Eyes Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_F", Name = "Classic Vampire" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_F", Name = "Demon Drummer" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_F", Name = "Skeleton Shot" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_F", Name = "Music Is The Remedy" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_F", Name = "Serpent Mic" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_F", Name = "Weed Knuckles" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_F", Name = "Scratch Panther" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_F", Name = "Mighty Thog" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_F", Name = "Tiger Heart" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_F", Name = "Banknote Rose" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_F", Name = "Can't Win Them All" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_F", Name = "Vice" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_F", Name = "Get Lucky" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_F", Name = "Suits" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_F", Name = "Cerberus" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_F", Name = "Winged Serpent" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_F", Name = "Katana" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_F", Name = "Spartan Combat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_F", Name = "Tiger and Mask" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_F", Name = "Viking Warrior" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_F", Name = "Mermaid's Curse" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_F", Name = "Horrors Of The Deep" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_F", Name = "Honor" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_F", Name = "Toxic Trails" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_F", Name = "Serpent Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_F", Name = "Praying Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_F", Name = "Blood Money" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_F", Name = "Spiked Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_F", Name = "Bandolier" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_F", Name = "Sidearm" });

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_F", Name = "Scarlett" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_F", Name = "Piston Sleeve" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_F", Name = "Poison Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_F", Name = "Muffler Helmet" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_F", Name = "Ride Hard Die Fast" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_F", Name = "Chain Fist" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_F", Name = "Good Luck" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_F", Name = "Live to Ride" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_F", Name = "Cranial Rose" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_F", Name = "Macabre Tree" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_F", Name = "Urban Stunter" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_F", Name = "Engine Arm" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_F", Name = "Kaboom" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_F", Name = "Stuntman's End" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_F", Name = "Tanked" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_F", Name = "Piston Head" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_F", Name = "Moonlight Ride" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_F", Name = "Big Cat" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_F", Name = "8 Eyed Skull" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_F", Name = "My Crazy Life" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_F", Name = "Skeleton Party" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_F", Name = "Love Hustle" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_F", Name = "City Sorrow" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_F", Name = "Los Santos Life" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_F", Name = "No Evil" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_F", Name = "Python Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_F", Name = "Divine Goddess" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_F", Name = "Egyptian Mural" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_F", Name = "Fatal Dagger" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_F", Name = "Gabriel" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_F", Name = "Archangel and Mary" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_F", Name = "Floral Symmetry" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_021", Name = "Time's Up Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_020", Name = "Time's Up Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_012", Name = "8 Ball Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_010", Name = "Electric Snake" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_000", Name = "Skull Rider" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_048", Name = "Peace" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_043", Name = "Triangle White" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_039", Name = "Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_037", Name = "Sunrise" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_034", Name = "Stop" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_028", Name = "Thorny Rose" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_027", Name = "Padlock" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_026", Name = "Pizza" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_016", Name = "Lightning Bolt" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_015", Name = "Mustache" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_007", Name = "Bricks" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_003", Name = "Diamond Sparkle" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LArm_000", Name = "Greed is Good" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_001", Name = "Parrot" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_LArm_000", Name = "Tribal Flower" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_041", Name = "Dope Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_031", Name = "Lady M" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_015", Name = "Zodiac Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_006", Name = "Oriental Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_005", Name = "Serpents" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_015", Name = "Racing Brunette" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_007", Name = "Racing Blonde" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_001", Name = "Burning Heart" });//50 Death Match Award
                    //not on list
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_F", Name = "Geometric Design" });
                }//LEFT ARM
                else if (iZone == 6)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_032_F", Name = "Fooligan" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_027_F", Name = "Orang-O-Tang Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_029_F", Name = "Orang-O-Tang Gray" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_031_F", Name = "Sailor Fuku Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_002_F", Name = "Skull Bauble" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_003_F", Name = "Bony Snowman" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_F", Name = "Nothing Mini About It" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_F", Name = "Snake Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_F", Name = "Weapon Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_F", Name = "Centipede" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_F", Name = "Fleshy Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_F", Name = "Armored Arm" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_F", Name = "Demon Smile" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_F", Name = "Angel & Devil" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_F", Name = "Death Is Certain" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_F", Name = "Hood Skeleton" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_F", Name = "Peacock" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_F", Name = "Ballas 4 Life" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_F", Name = "Ascension" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_F", Name = "Zombie Rhymes" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_F", Name = "Dog Fist" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_F", Name = "K.U.L.T.99.1 FM" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_F", Name = "Octopus Shades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_F", Name = "Shark Water" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_F", Name = "Still Slipping" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_F", Name = "Soulwax" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_F", Name = "Smiley Glitch" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_F", Name = "Skeleton DJ" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_F", Name = "Music Locker" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_F", Name = "LSUR" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_F", Name = "Lighthouse" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_F", Name = "Jellyfish Shades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_F", Name = "Tropical Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_F", Name = "Headphone Splat" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_F", Name = "LS Monogram" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_F", Name = "Skull and Aces" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_F", Name = "Queen of Roses" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_F", Name = "The Gambler's Life" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_F", Name = "Lady Luck" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_F", Name = "Spartan Mural" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_F", Name = "Samurai Tallship" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_F", Name = "Muscle Tear" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_F", Name = "Feather Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_F", Name = "Celtic Band" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_F", Name = "Tiger Headdress" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_F", Name = "Medusa" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_F", Name = "Stylized Kraken" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_F", Name = "Mutiny" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_F", Name = "Crackshot" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_F", Name = "Combat Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_F", Name = "Have a Nice Day" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_F", Name = "Grenade" });

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_F", Name = "Drive Forever" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_F", Name = "Engulfed Block" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_F", Name = "Dialed In" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_F", Name = "Mechanical Sleeve" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_F", Name = "Mum" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_F", Name = "These Colors Don't Run" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_F", Name = "Snake Bike" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_F", Name = "Skull Chain" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_F", Name = "Grim Rider" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_F", Name = "Eagle Emblem" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_F", Name = "Lady Mortality" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_F", Name = "Swooping Eagle" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_F", Name = "Seductive Mechanic" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_F", Name = "One Down Five Up" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_F", Name = "Biker Stallion" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_F", Name = "Coffin Racer" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_F", Name = "Grave Vulture" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_F", Name = "Arachnid of Death" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_F", Name = "Poison Wrench" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_F", Name = "Black Tears" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_F", Name = "Loving Los Muertos" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_F", Name = "Lady Vamp" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_F", Name = "Seductress" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_F", Name = "Floral Print" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_F", Name = "Heavenly Deity" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_F", Name = "Intrometric" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_F", Name = "Geisha Bloom" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_F", Name = "Mermaid Harpist" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_F", Name = "Floral Raven" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_027", Name = "Fuck Luck Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_026", Name = "Fuck Luck Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_023", Name = "You're Next Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_022", Name = "You're Next Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_008", Name = "Death Before Dishonor" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_004", Name = "Snake Shaded" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_003", Name = "Snake Outline" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_045", Name = "Mesh Band" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_044", Name = "Triangle Black" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_036", Name = "Shapes" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_023", Name = "Smiley" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_022", Name = "Pencil" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_020", Name = "Geo Pattern" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_018", Name = "Origami" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_017", Name = "Eye Triangle" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_014", Name = "Spray Can" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_010", Name = "Horseshoe" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_008", Name = "Cube" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_004", Name = "Bone" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_001", Name = "Single Arrow" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RArm_000", Name = "Dollar Sign" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RArm_001", Name = "Tribal Fish" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_047", Name = "Lion" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_038", Name = "Dagger" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_028", Name = "Mermaid" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_027", Name = "Virgin Mary" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_018", Name = "Serpent Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_014", Name = "Flower Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_003", Name = "Dragons and Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_001", Name = "Dragons" });
                    //TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_000", Name = "Brotherhood" } );-empty load?

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_010", Name = "Ride or Die" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_002", Name = "Grim Reaper Smoking Gun" });//Clear 5 Gang Atacks in a Day Award
                    //Not In List
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Female_Crew_Tat_001", Name = "Crew Tattoo" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_F", Name = "Geometric Design" });
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_038_F", Name = "Fool" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_037_F", Name = "Orang-O-Tang Grenade" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_034_F", Name = "Zombie Head" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_009_F", Name = "Naughty Snow Globe" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_F", Name = "Cobra Biker" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_F", Name = "Minimal SMG" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_F", Name = "Minimal Advanced Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_F", Name = "Minimal Sniper Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_F", Name = "Many-eyed Goat" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_F", Name = "Mobster Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_F", Name = "Wounded Head" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_F", Name = "Stabbed Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_F", Name = "Tiger Blade" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_F", Name = "LS Smoking Cartridges" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_F", Name = "Trust" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_F", Name = "Soundwaves" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_F", Name = "Skull Waters" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_F", Name = "Glow Princess" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_F", Name = "Pineapple Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_F", Name = "Tropical Serpent" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_F", Name = "Love Fist" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_F", Name = "8-Ball Rose" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_F", Name = "One-armed Bandit" });//

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_F", Name = "Rose Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_F", Name = "Death Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_F", Name = "Stylized Tiger" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_F", Name = "Patriot Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_F", Name = "Laughing Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_F", Name = "Bone Cruiser" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_F", Name = "Ride Free" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_F", Name = "Scorched Soul" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_F", Name = "Engulfed Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_F", Name = "Bad Luck" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_F", Name = "Ride or Die" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_F", Name = "Rose Tribute" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_F", Name = "Stunt Jesus" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_F", Name = "Quad Goblin" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_F", Name = "Golden Cobra" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_F", Name = "Dirt Track Hero" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_F", Name = "Dagger Devil" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_F", Name = "Death Us Do Part" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_F", Name = "Presidents" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_F", Name = "LS Serpent" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_F", Name = "Cross of Roses" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_F", Name = "Serpent of Death" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_002", Name = "Spider Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_001", Name = "Spider Outline" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_040", Name = "Black Anchor" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_019", Name = "Charm" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_009", Name = "Squares" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_LLeg_000", Name = "Single" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_032", Name = "Faith" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_037", Name = "Grim Reaper" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_035", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_033", Name = "Chinese Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_026", Name = "Smoking Dagger" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_023", Name = "Hottie" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_021", Name = "Serpent Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_008", Name = "Dragon Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_002", Name = "Melting Skull" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_009", Name = "Dragon and Dagger" });
                }//LEFT LEG
                else
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_039_F", Name = "Jack Me" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_035_F", Name = "Erupting Skeleton" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_036_F", Name = "B Donk Now Crank It Later" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_008_F", Name = "Gingerbread Steed" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_F", Name = "Skull Grenade" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_F", Name = "Three-eyed Demon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_F", Name = "Smoldering Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_F", Name = "Gold Gun" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_F", Name = "Blue Serpent" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_F", Name = "Night Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_F", Name = "Bandana Knife" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_F", Name = "Graffiti Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_F", Name = "Skullphones" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_F", Name = "Kifflom" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_F", Name = "Cash is King" });//

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_F", Name = "Homeward Bound" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_F", Name = "Pistol Ace" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_F", Name = "Restless Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_F", Name = "Combat Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_F", Name = "STFU" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_F", Name = "American Made" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_F", Name = "Dusk Rider" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_F", Name = "Western Insignia" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_F", Name = "Dragon's Fury" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_F", Name = "Brake Knife" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_F", Name = "Severed Hand" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_F", Name = "Wheelie Mouse" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_F", Name = "Speed Freak" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_F", Name = "Piston Angel" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_F", Name = "Praying Gloves" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_F", Name = "Demon Spark Plug" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_F", Name = "San Andreas Prayer" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_F", Name = "Dance of Hearts" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_F", Name = "Ink Me" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_F", Name = "Starmetric" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_F", Name = "Elaborate Los Muertos" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_F_Tat_014", Name = "Floral Dagger" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_042", Name = "Sparkplug" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_F_Tat_038", Name = "Grub" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_F_RLeg_000", Name = "Diamond Crown" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_F_RLeg_000", Name = "School of Fish" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_043", Name = "Indian Ram" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_042", Name = "Flaming Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_040", Name = "Flaming Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_039", Name = "Broken Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_022", Name = "Fiery Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_017", Name = "Tribal" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_F_007", Name = "The Warrior" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_F_006", Name = "Skull and Sword" });//Collect 25 Bounties Award
                }//RIGHT LEG
            }// FreeFemale
            else if (iPed == 5)
            {
                if (iZone == 1)
                {
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_006_M", Name = "Painted Micro SMG" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_007_M", Name = "Weapon King" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_035_M", Name = "Sniff Sniff" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_036_M", Name = "Charm Pattern" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_037_M", Name = "Witch & Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_038_M", Name = "Pumpkin Bug" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_039_M", Name = "Sinner" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_057_M", Name = "Gray Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_004_M", Name = "Hood Heart" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_008_M", Name = "Los Santos Tag" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_013_M", Name = "Blessed Boombox" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_014_M", Name = "Chamberlain Hills" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_015_M", Name = "Smoking Barrels" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_026_M", Name = "Dollar Guns Crossed" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_021_M", Name = "Skull Surfer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_020_M", Name = "Speaker Tower" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_019_M", Name = "Record Shot" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_018_M", Name = "Record Head" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_017_M", Name = "Tropical Sorcerer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_016_M", Name = "Rose Panther" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_015_M", Name = "Paradise Ukulele" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_014_M", Name = "Paradise Nap" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_013_M", Name = "Wild Dancers" });//

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_039_M", Name = "Space Rangers" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_038_M", Name = "Robot Bubblegum" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_036_M", Name = "LS Shield" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_030_M", Name = "Howitzer" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_028_M", Name = "Bananas Gone Bad" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_027_M", Name = "Epsilon" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_024_M", Name = "Mount Chiliad" });//
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_023_M", Name = "Bigfoot" });//

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_032_M", Name = "Play Your Ace" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_029_M", Name = "The Table" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_021_M", Name = "Show Your Hand" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_017_M", Name = "Roll the Dice" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_015_M", Name = "The Jolly Joker" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_011_M", Name = "Life's a Gamble" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_010_M", Name = "Photo Finish" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_009_M", Name = "Till Death Do Us Part" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_008_M", Name = "Snake Eyes" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_007_M", Name = "777" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_006_M", Name = "Wheel of Suits" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_001_M", Name = "Jackpot" });//

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_027_M", Name = "Molon Labe" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_024_M", Name = "Dragon Slayer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_022_M", Name = "Spartan and Horse" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_021_M", Name = "Spartan and Lion" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_016_M", Name = "Odin and Raven" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_015_M", Name = "Samurai Combat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_011_M", Name = "Weathered Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_010_M", Name = "Spartan Shield" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_009_M", Name = "Norse Rune" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_005_M", Name = "Ghost Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_002_M", Name = "Kabuto" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_025_M", Name = "Claimed By The Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_024_M", Name = "Pirate Captain" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_022_M", Name = "X Marks The Spot" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_018_M", Name = "Finders Keepers" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_017_M", Name = "Framed Tall Ship" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_016_M", Name = "Skull Compass" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_013_M", Name = "Torn Wings" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_009_M", Name = "Tall Ship Conflict" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_006_M", Name = "Never Surrender" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_003_M", Name = "Give Nothing Back" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_007_M", Name = "Eagle Eyes" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_005_M", Name = "Parachute Belle" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_004_M", Name = "Balloon Pioneer" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_002_M", Name = "Winged Bombshell" });
                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_001_M", Name = "Pilot Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_022_M", Name = "Explosive Heart" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_019_M", Name = "Pistol Wings" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_018_M", Name = "Dual Wield Skull" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_014_M", Name = "Backstabber" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_013_M", Name = "Wolf Insignia" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_009_M", Name = "Butterfly Knife" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_001_M", Name = "Crossed Weapons" });//
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_000_M", Name = "Bullet Proof" });//

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_011_M", Name = "Talk Shit Get Hit" });//
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_010_M", Name = "Take the Wheel" });//
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_009_M", Name = "Serpents of Destruction" });//
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_002_M", Name = "Tuned to Death" });//
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_001_M", Name = "Power Plant" });//
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_000_M", Name = "Block Back" });//

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_043_M", Name = "Ride Forever" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_030_M", Name = "Brothers For Life" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_021_M", Name = "Flaming Reaper" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_017_M", Name = "Clawed Beast" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_011_M", Name = "R.I.P. My Brothers" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_008_M", Name = "Freedom Wheels" });//
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_006_M", Name = "Chopper Freedom" });//

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_048_M", Name = "Racing Doll" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_046_M", Name = "Full Throttle" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_041_M", Name = "Brapp" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_040_M", Name = "Monkey Chopper" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_037_M", Name = "Big Grills" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_034_M", Name = "Feather Road Kill" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_030_M", Name = "Man's Ruin" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_029_M", Name = "Majestic Finish" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_026_M", Name = "Winged Wheel" });//
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_024_M", Name = "Road Kill" });//

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_032_M", Name = "Reign Over" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_031_M", Name = "Dead Pretty" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_008_M", Name = "Love the Game" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_000_M", Name = "SA Assault" });//

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_021_M", Name = "Sad Angel" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_014_M", Name = "Love is Blind" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_010_M", Name = "Bad Angel" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_009_M", Name = "Amazon" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_029_M", Name = "Geometric Design" });//   
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_022_M", Name = "Cloaked Angel" });//  
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_024_M", Name = "Feather Mural" });//    
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_006_M", Name = "Adorned Wolf" });//   

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_015", Name = "Japanese Warrior" });//          
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_011", Name = "Roaring Tiger" });//      
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_006", Name = "Carp Shaded" });//   
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_005", Name = "Carp Outline" });//   

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_046", Name = "Triangles" });//         
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_041", Name = "Tooth" });//         
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_032", Name = "Paper Plane" });//         
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_031", Name = "Skateboard" });//           
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_030", Name = "Shark Fin" });//        
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_025", Name = "Watch Your Step" });//          
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_024", Name = "Pyamid" });//   
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_012", Name = "Antlers" });//  
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_011", Name = "Infinity" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_000", Name = "Crossed Arrows" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Back_000", Name = "Makin' Paper" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Back_000", Name = "Ship Arms" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_045", Name = "Skulls and Rose" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_030", Name = "Lucky Celtic Dogs" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_020", Name = "Dragon" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_019", Name = "The Wages of Sin" });//Survival Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_016", Name = "Evil Clown" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_013", Name = "Eagle and Serpent" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_011", Name = "LS Script" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_009", Name = "Skull on the Cross" });//

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_019", Name = "Clown Dual Wield Dollars" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_018", Name = "Clown Dual Wield" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_017", Name = "Clown and Gun" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_016", Name = "Clown" });//
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_014", Name = "Trust No One" });//Car Bomb Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_008", Name = "Los Santos Customs" });//Mod a Car Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_005", Name = "Angel" });//Win Every Game Mode Award
                    //Unknowen
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_046", Name = "Zip?" });//Zip???
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2018_overlays", TatName = "MP_Christmas2018_Tat_000_M", Name = "Unknowen" });//
                }//BACK
                else if (iZone == 2)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_004_M", Name = "Herbal Bouquet" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_005_M", Name = "Cash Krampus" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_006_M", Name = "All In One Night" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_007_M", Name = "A Little Present For You" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_014_M", Name = "Masked Machete Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_015_M", Name = "Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_016_M", Name = "Powwer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_017_M", Name = "Two Headed Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_018_M", Name = "Dudes" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_019_M", Name = "Fooligan Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_020_M", Name = "Vile Smile" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_021_M", Name = "Demon Skull Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_022_M", Name = "Fatal Incursion Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_023_M", Name = "Many-Headed Beast" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_024_M", Name = "Demon Stitches" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_025_M", Name = "Collector" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_040_M", Name = "Monkey" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_041_M", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_042_M", Name = "Snake" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_043_M", Name = "Goat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_044_M", Name = "Rat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_045_M", Name = "Rabbit" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_046_M", Name = "Ox" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_047_M", Name = "Pig" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_048_M", Name = "Rooster" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_049_M", Name = "Dog" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_050_M", Name = "Horse" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_051_M", Name = "Tiger" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_003_M", Name = "Bullet Mouth" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_004_M", Name = "Smoking Barrel" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_040_M", Name = "Carved Pumpkin" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_041_M", Name = "Branched Werewolf" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_042_M", Name = "Winged Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_058_M", Name = "Shrieking Dragon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_059_M", Name = "Swords & City" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_016_M", Name = "All From The Same Tree" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_017_M", Name = "King of the Jungle" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_018_M", Name = "Night Owl" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_023_M", Name = "Techno Glitch" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_022_M", Name = "Paradise Sirens" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_035_M", Name = "LS Panic" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_033_M", Name = "LS City" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_026_M", Name = "Dignity" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_025_M", Name = "Davis" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_022_M", Name = "Blood Money" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_003_M", Name = "Royal Flush" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_000_M", Name = "In the Pocket" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_026_M", Name = "Spartan Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_020_M", Name = "Medusa's Gaze" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_019_M", Name = "Strike Force" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_003_M", Name = "Native Warrior" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_000_M", Name = "Thor - Goblin" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_021_M", Name = "Dead Tales" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_019_M", Name = "Lost At Sea" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_007_M", Name = "No Honor" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_000_M", Name = "Bless The Dead" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_000_M", Name = "Turbulence" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_028_M", Name = "Micro SMG Chain" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_020_M", Name = "Crowned Weapons" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_017_M", Name = "Dog Tags" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_012_M", Name = "Dollar Daggers" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_060_M", Name = "We Are The Mods!" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_059_M", Name = "Faggio" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_058_M", Name = "Reaper Vulture" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_050_M", Name = "Unforgiven" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_041_M", Name = "No Regrets" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_034_M", Name = "Brotherhood of Bikes" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_032_M", Name = "Western Eagle" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_029_M", Name = "Bone Wrench" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_026_M", Name = "American Dream" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_023_M", Name = "Western MC" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_019_M", Name = "Gruesome Talons" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_018_M", Name = "Skeletal Chopper" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_013_M", Name = "Demon Crossbones" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_005_M", Name = "Made In America" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_001_M", Name = "Both Barrels" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_000_M", Name = "Demon Rider" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_044_M", Name = "Ram Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_033_M", Name = "Sugar Skull Trucker" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_027_M", Name = "Punk Road Hog" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_019_M", Name = "Engine Heart" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_018_M", Name = "Vintage Bully" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_011_M", Name = "Wheels of Death" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_019_M", Name = "Death Behind" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_012_M", Name = "Royal Kiss" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_026_M", Name = "Royal Takeover" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_013_M", Name = "Love Gamble" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_002_M", Name = "Holy Mary" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_001_M", Name = "King Fight" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_027_M", Name = "Cobra Dawn" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_025_M", Name = "Reaper Sway" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_012_M", Name = "Geometric Galaxy" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_002_M", Name = "The Howler" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_015_M", Name = "Smoking Sisters" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_014_M", Name = "Ancient Queen" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_008_M", Name = "Flying Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_007_M", Name = "Eye of the Griffin" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_019", Name = "Royal Dagger Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_018", Name = "Royal Dagger Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_017", Name = "Loose Lips Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_016", Name = "Loose Lips Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_009", Name = "Time To Die" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_047", Name = "Cassette" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_033", Name = "Stag" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_013", Name = "Boombox" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_002", Name = "Chemistry" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_001", Name = "$$$" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Chest_000", Name = "Rich" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_001", Name = "Tribal Shark" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Chest_000", Name = "Tribal Hammerhead" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_044", Name = "Stone Cross" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_034", Name = "Flaming Shamrock" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_025", Name = "LS Bold" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_024", Name = "Flaming Cross" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_010", Name = "LS Flames" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_013", Name = "Seven Deadly Sins" });//Kill 1000 Players Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_012", Name = "Embellished Scroll" });//Kill 500 Players Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_011", Name = "Blank Scroll" });////Kill 100 Players Award?
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_003", Name = "Blackjack" });
                    //
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Male_Crew_Tat_000", Name = "Crew Emblem" });
                }//CHEST
                else if (iZone == 3)
                {
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_005_M", Name = "Concealed" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_043_M", Name = "Cursed Saki" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_044_M", Name = "Smouldering Bat & Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_060_M", Name = "Blaine County" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_061_M", Name = "Angry Possum" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_062_M", Name = "Floral Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_024_M", Name = "Beatbox Silhouette" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_025_M", Name = "Davis Flames" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_030_M", Name = "Radio Tape" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_004_M", Name = "Skeleton Breeze" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_037_M", Name = "LadyBug" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_029_M", Name = "Fatal Incursion" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_031_M", Name = "Gambling Royalty" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_024_M", Name = "Cash Mouth" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_016_M", Name = "Rose and Aces" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "mp_vinewood_tat_012_M", Name = "Skull of Suits" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_008_M", Name = "Spartan Warrior" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_015_M", Name = "Jolly Roger" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_010_M", Name = "See You In Hell" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_002_M", Name = "Dead Lies" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_006_M", Name = "Bombs Away" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_029_M", Name = "Win Some Lose Some" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_010_M", Name = "Cash Money" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_052_M", Name = "Biker Mount" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_039_M", Name = "Gas Guzzler" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_031_M", Name = "Gear Head" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_010_M", Name = "Skull Of Taurus" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_003_M", Name = "Web Rider" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_014_M", Name = "Bat Cat of Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_012_M", Name = "Punk Biker" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_016_M", Name = "Two Face" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_011_M", Name = "Lady Liberty" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_004_M", Name = "Gun Mic" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_003_M", Name = "Abstract Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_028", Name = "Executioner" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_013", Name = "Lizard" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_035", Name = "Sewn Heart" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_029", Name = "Sad" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_006", Name = "Feather Birds" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Stomach_000", Name = "Refined Hustler" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_001", Name = "Wheel" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Stom_000", Name = "Swordfish" });


                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_036", Name = "Way of the Gun" });//500 Pistol kills Award
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_029", Name = "Trinity Knot" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_012", Name = "Los Santos Bills" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_004", Name = "Faith" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_004", Name = "Hustler" });//Make 50000 from betting Award
                }//STOMACH
                else if (iZone == 4)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_010_M", Name = "Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_011_M", Name = "Fooligan Tribal" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_012_M", Name = "Skull Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_013_M", Name = "Budonk-adonk!" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_000_M", Name = "Live Fast Mono" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_001_M", Name = "Live Fast Color" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_018_M", Name = "Branched Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_019_M", Name = "Scythed Corpse" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_020_M", Name = "Scythed Corpse & Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_021_M", Name = "Third Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_022_M", Name = "Pierced Third Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_023_M", Name = "Lip Drip" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_024_M", Name = "Skin Mask" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_025_M", Name = "Webbed Scythe" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_026_M", Name = "Oni Demon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_027_M", Name = "Bat Wings" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_001_M", Name = "Bright Diamond" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_002_M", Name = "Hustle" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_027_M", Name = "Black Widow" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_044_M", Name = "Clubs" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_043_M", Name = "Diamonds" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_042_M", Name = "Hearts" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_022_M", Name = "Thong's Sword" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_021_M", Name = "Wanted" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_020_M", Name = "UFO" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_019_M", Name = "Teddy Bear" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_018_M", Name = "Stitches" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_017_M", Name = "Space Monkey" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_016_M", Name = "Sleepy" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_015_M", Name = "On/Off" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_014_M", Name = "LS Wings" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_013_M", Name = "LS Star" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_012_M", Name = "Razor Pop" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_011_M", Name = "Lipstick Kiss" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_010_M", Name = "Green Leaf" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_009_M", Name = "Knifed" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_008_M", Name = "Ice Cream" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_007_M", Name = "Two Horns" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_006_M", Name = "Crowned" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_005_M", Name = "Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_004_M", Name = "Bandage" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_003_M", Name = "Assault Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_002_M", Name = "Animal" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_001_M", Name = "Ace of Spades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_000_M", Name = "Five Stars" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_012_M", Name = "Thief" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_011_M", Name = "Sinner" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_003_M", Name = "Lock and Load" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_051_M", Name = "Western Stylized" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_038_M", Name = "FTW" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_009_M", Name = "Morbid Arachnid" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_042_M", Name = "Flaming Quad" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_017_M", Name = "Bat Wheel" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_006_M", Name = "Toxic Spider" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_004_M", Name = "Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_Tat_000_M", Name = "Stunt Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_029", Name = "Beautiful Death" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_025", Name = "Snake Head Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_024", Name = "Snake Head Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_007", Name = "Los Muertos" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_021", Name = "Geo Fox" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_005", Name = "Beautiful Eye" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_003", Name = "$100" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_002", Name = "Script Dollar Sign" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_001", Name = "Bold Dollar Sign" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_Neck_000", Name = "Cash is King" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_002", Name = "Shark" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_001", Name = "Surfs Up" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Neck_000", Name = "Little Fish" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_001", Name = "Surf LS" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Head_000", Name = "Pirate Skull" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_000", Name = "Skull" });
                    //Not On the TatlIst     ...                            
                }//HEAD
                else if (iZone == 5)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_033_M", Name = "Fooligan Impotent Rage" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_030_M", Name = "Dude Jester" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_026_M", Name = "Fooligan Clown" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_028_M", Name = "Dude Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_000_M", Name = "The Christmas Spirit" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_001_M", Name = "Festive Reaper" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_008_M", Name = "Bigness Chimp" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_009_M", Name = "Up-n-Atomizer Design" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_010_M", Name = "Rocket Launcher Girl" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_028_M", Name = "Laser Eyes Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_029_M", Name = "Classic Vampire" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_049_M", Name = "Demon Drummer" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_006_M", Name = "Skeleton Shot" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_010_M", Name = "Music Is The Remedy" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_011_M", Name = "Serpent Mic" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_019_M", Name = "Weed Knuckles" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_009_M", Name = "Scratch Panther" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_041_M", Name = "Mighty Thog" });
                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_040_M", Name = "Tiger Heart" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_026_M", Name = "Banknote Rose" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_019_M", Name = "Can't Win Them All" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_014_M", Name = "Vice" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_005_M", Name = "Get Lucky" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_002_M", Name = "Suits" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_029_M", Name = "Cerberus" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_025_M", Name = "Winged Serpent" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_013_M", Name = "Katana" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_007_M", Name = "Spartan Combat" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_004_M", Name = "Tiger and Mask" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_001_M", Name = "Viking Warrior" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_014_M", Name = "Mermaid's Curse" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_008_M", Name = "Horrors Of The Deep" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_004_M", Name = "Honor" });

                    TatList.Add(new Tattoo { BaseName = "mpairraces_overlays", TatName = "MP_Airraces_Tattoo_003_M", Name = "Toxic Trails" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_027_M", Name = "Serpent Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_025_M", Name = "Praying Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_016_M", Name = "Blood Money" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_015_M", Name = "Spiked Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_008_M", Name = "Bandolier" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_004_M", Name = "Sidearm" });

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_008_M", Name = "Scarlett" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_004_M", Name = "Piston Sleeve" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_055_M", Name = "Poison Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_053_M", Name = "Muffler Helmet" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_045_M", Name = "Ride Hard Die Fast" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_035_M", Name = "Chain Fist" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_025_M", Name = "Good Luck" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_024_M", Name = "Live to Ride" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_020_M", Name = "Cranial Rose" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_016_M", Name = "Macabre Tree" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_012_M", Name = "Urban Stunter" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_043_M", Name = "Engine Arm" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_039_M", Name = "Kaboom" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_035_M", Name = "Stuntman's End" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_023_M", Name = "Tanked" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_022_M", Name = "Piston Head" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_008_M", Name = "Moonlight Ride" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_002_M", Name = "Big Cat" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_001_M", Name = "8 Eyed Skull" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_022_M", Name = "My Crazy Life" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_018_M", Name = "Skeleton Party" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_006_M", Name = "Love Hustle" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_033_M", Name = "City Sorrow" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_027_M", Name = "Los Santos Life" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_005_M", Name = "No Evil" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_028_M", Name = "Python Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_018_M", Name = "Divine Goddess" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_016_M", Name = "Egyptian Mural" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_005_M", Name = "Fatal Dagger" });


                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_021_M", Name = "Gabriel" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_020_M", Name = "Archangel and Mary" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_Luxe_Tat_009_M", Name = "Floral Symmetry" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_021", Name = "Time's Up Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_020", Name = "Time's Up Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_012", Name = "8 Ball Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_010", Name = "Electric Snake" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_000", Name = "Skull Rider" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_048", Name = "Peace" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_043", Name = "Triangle White" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_039", Name = "Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_037", Name = "Sunrise" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_034", Name = "Stop" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_028", Name = "Thorny Rose" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_027", Name = "Padlock" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_026", Name = "Pizza" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_016", Name = "Lightning Bolt" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_015", Name = "Mustache" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_007", Name = "Bricks" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_003", Name = "Diamond Sparkle" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_001", Name = "All-Seeing Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_LeftArm_000", Name = "$100 Bill" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_000", Name = "Tiki Tower" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_LArm_001", Name = "Mermaid L.S." });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_041", Name = "Dope Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_031", Name = "Lady M" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_015", Name = "Zodiac Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_006", Name = "Oriental Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_005", Name = "Serpents" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_015", Name = "Racing Brunette" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_007", Name = "Racing Blonde" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_001", Name = "Burning Heart" });//50 Death Match Award
                    //not on list
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_031_M", Name = "Geometric Design" });
                }//LEFT ARM
                else if (iZone == 6)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_032_M", Name = "Fooligan" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_027_M", Name = "Orang-O-Tang Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_029_M", Name = "Orang-O-Tang Gray" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_031_M", Name = "Sailor Fuku Killer" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_002_M", Name = "Skull Bauble" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_003_M", Name = "Bony Snowman" });


                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_011_M", Name = "Nothing Mini About It" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_012_M", Name = "Snake Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_013_M", Name = "Weapon Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_030_M", Name = "Centipede" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_031_M", Name = "Fleshy Eye" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_045_M", Name = "Armored Arm" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_046_M", Name = "Demon Smile" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_047_M", Name = "Angel & Devil" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_048_M", Name = "Death Is Certain" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_000_M", Name = "Hood Skeleton" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_005_M", Name = "Peacock" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_007_M", Name = "Ballas 4 Life" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_009_M", Name = "Ascension" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_012_M", Name = "Zombie Rhymes" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_020_M", Name = "Dog Fist" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_032_M", Name = "K.U.L.T.99.1 FM" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_031_M", Name = "Octopus Shades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_026_M", Name = "Shark Water" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_012_M", Name = "Still Slipping" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_011_M", Name = "Soulwax" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_008_M", Name = "Smiley Glitch" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_007_M", Name = "Skeleton DJ" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_006_M", Name = "Music Locker" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_005_M", Name = "LSUR" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_003_M", Name = "Lighthouse" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_002_M", Name = "Jellyfish Shades" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_001_M", Name = "Tropical Dude" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_000_M", Name = "Headphone Splat" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_034_M", Name = "LS Monogram" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_028_M", Name = "Skull and Aces" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_025_M", Name = "Queen of Roses" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_018_M", Name = "The Gambler's Life" });
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_004_M", Name = "Lady Luck" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_028_M", Name = "Spartan Mural" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_023_M", Name = "Samurai Tallship" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_018_M", Name = "Muscle Tear" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_017_M", Name = "Feather Sleeve" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_014_M", Name = "Celtic Band" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_012_M", Name = "Tiger Headdress" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2017_overlays", TatName = "MP_Christmas2017_Tattoo_006_M", Name = "Medusa" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_023_M", Name = "Stylized Kraken" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_005_M", Name = "Mutiny" });
                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_001_M", Name = "Crackshot" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_024_M", Name = "Combat Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_021_M", Name = "Have a Nice Day" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_002_M", Name = "Grenade" });

                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_007_M", Name = "Drive Forever" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_006_M", Name = "Engulfed Block" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_005_M", Name = "Dialed In" });
                    TatList.Add(new Tattoo { BaseName = "mpimportexport_overlays", TatName = "MP_MP_ImportExport_Tat_003_M", Name = "Mechanical Sleeve" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_054_M", Name = "Mum" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_049_M", Name = "These Colors Don't Run" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_047_M", Name = "Snake Bike" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_046_M", Name = "Skull Chain" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_042_M", Name = "Grim Rider" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_033_M", Name = "Eagle Emblem" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_014_M", Name = "Lady Mortality" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_007_M", Name = "Swooping Eagle" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_049_M", Name = "Seductive Mechanic" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_038_M", Name = "One Down Five Up" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_036_M", Name = "Biker Stallion" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_016_M", Name = "Coffin Racer" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_010_M", Name = "Grave Vulture" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_009_M", Name = "Arachnid of Death" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_003_M", Name = "Poison Wrench" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_035_M", Name = "Black Tears" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_028_M", Name = "Loving Los Muertos" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_003_M", Name = "Lady Vamp" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_015_M", Name = "Seductress" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_026_M", Name = "Floral Print" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_017_M", Name = "Heavenly Deity" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_010_M", Name = "Intrometric" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_019_M", Name = "Geisha Bloom" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_013_M", Name = "Mermaid Harpist" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_004_M", Name = "Floral Raven" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_027", Name = "Fuck Luck Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_026", Name = "Fuck Luck Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_023", Name = "You're Next Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_022", Name = "You're Next Outline" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_008", Name = "Death Before Dishonor" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_004", Name = "Snake Shaded" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_003", Name = "Snake Outline" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_045", Name = "Mesh Band" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_044", Name = "Triangle Black" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_036", Name = "Shapes" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_023", Name = "Smiley" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_022", Name = "Pencil" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_020", Name = "Geo Pattern" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_018", Name = "Origami" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_017", Name = "Eye Triangle" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_014", Name = "Spray Can" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_010", Name = "Horseshoe" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_008", Name = "Cube" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_004", Name = "Bone" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_001", Name = "Single Arrow" });

                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_001", Name = "Green" });
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Buis_M_RightArm_000", Name = "Dollar Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_001", Name = "Vespucci Beauty" });
                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_RArm_000", Name = "Tribal Sun" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_047", Name = "Lion" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_038", Name = "Dagger" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_028", Name = "Mermaid" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_027", Name = "Virgin Mary" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_018", Name = "Serpent Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_014", Name = "Flower Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_003", Name = "Dragons and Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_001", Name = "Dragons" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_000", Name = "Brotherhood" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_010", Name = "Ride or Die" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_002", Name = "Grim Reaper Smoking Gun" });
                    //Not In List
                    TatList.Add(new Tattoo { BaseName = "mpbusiness_overlays", TatName = "MP_Male_Crew_Tat_001", Name = "Crew Tattoo" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_030_M", Name = "Geometric Design" });
                }//RIGHT ARM
                else if (iZone == 7)
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_038_M", Name = "Fool" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_037_M", Name = "Orang-O-Tang Grenade" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_034_M", Name = "Zombie Head" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_009_M", Name = "Naughty Snow Globe" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_002_M", Name = "Cobra Biker" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_014_M", Name = "Minimal SMG" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_015_M", Name = "Minimal Advanced Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_016_M", Name = "Minimal Sniper Rifle" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_032_M", Name = "Many-eyed Goat" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_053_M", Name = "Mobster Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_054_M", Name = "Wounded Head" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_055_M", Name = "Stabbed Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_056_M", Name = "Tiger Blade" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_022_M", Name = "LS Smoking Cartridges" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_023_M", Name = "Trust" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_029_M", Name = "Soundwaves" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_028_M", Name = "Skull Waters" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_025_M", Name = "Glow Princess" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_024_M", Name = "Pineapple Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_010_M", Name = "Tropical Serpent" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_032_M", Name = "Love Fist" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_027_M", Name = "8-Ball Rose" });//
                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_013_M", Name = "One-armed Bandit" });//

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_023_M", Name = "Rose Revolver" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_011_M", Name = "Death Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_007_M", Name = "Stylized Tiger" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_005_M", Name = "Patriot Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_057_M", Name = "Laughing Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_056_M", Name = "Bone Cruiser" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_044_M", Name = "Ride Free" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_037_M", Name = "Scorched Soul" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_036_M", Name = "Engulfed Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_027_M", Name = "Bad Luck" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_015_M", Name = "Ride or Die" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_002_M", Name = "Rose Tribute" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_031_M", Name = "Stunt Jesus" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_028_M", Name = "Quad Goblin" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_021_M", Name = "Golden Cobra" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_013_M", Name = "Dirt Track Hero" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_007_M", Name = "Dagger Devil" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_029_M", Name = "Death Us Do Part" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_020_M", Name = "Presidents" });//
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_007_M", Name = "LS Serpent" });//

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_Luxe_Tat_011_M", Name = "Cross of Roses" });
                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_000_M", Name = "Serpent of Death" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_002", Name = "Spider Color" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_001", Name = "Spider Outline" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_040", Name = "Black Anchor" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_019", Name = "Charm" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_009", Name = "Squares" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Lleg_000", Name = "Tribal Star" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_032", Name = "Faith" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_037", Name = "Grim Reaper" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_035", Name = "Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_033", Name = "Chinese Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_026", Name = "Smoking Dagger" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_023", Name = "Hottie" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_021", Name = "Serpent Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_008", Name = "Dragon Mural" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_002", Name = "Melting Skull" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_009", Name = "Dragon and Dagger" });
                }//LEFT LEG
                else
                {
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_039_M", Name = "Jack Me" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_035_M", Name = "Erupting Skeleton" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_036_M", Name = "B Donk Now Crank It Later" });
                    TatList.Add(new Tattoo { BaseName = "mpchristmas3_overlays", TatName = "MP_Christmas3_Tat_008_M", Name = "Gingerbread Steed" });

                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_017_M", Name = "Skull Grenade" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_033_M", Name = "Three-eyed Demon" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_034_M", Name = "Smoldering Reaper" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_050_M", Name = "Gold Gun" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_051_M", Name = "Blue Serpent" });
                    TatList.Add(new Tattoo { BaseName = "mpsum2_overlays", TatName = "MP_Sum2_Tat_052_M", Name = "Night Demon" });

                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_003_M", Name = "Bandana Knife" });
                    TatList.Add(new Tattoo { BaseName = "mpsecurity_overlays", TatName = "MP_Security_Tat_021_M", Name = "Graffiti Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpheist4_overlays", TatName = "MP_Heist4_Tat_027_M", Name = "Skullphones" });

                    TatList.Add(new Tattoo { BaseName = "mpheist3_overlays", TatName = "mpHeist3_Tat_031_M", Name = "Kifflom" });

                    TatList.Add(new Tattoo { BaseName = "mpvinewood_overlays", TatName = "MP_Vinewood_Tat_020_M", Name = "Cash is King" });

                    TatList.Add(new Tattoo { BaseName = "mpsmuggler_overlays", TatName = "MP_Smuggler_Tattoo_020_M", Name = "Homeward Bound" });

                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_030_M", Name = "Pistol Ace" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_026_M", Name = "Restless Skull" });
                    TatList.Add(new Tattoo { BaseName = "mpgunrunning_overlays", TatName = "MP_Gunrunning_Tattoo_006_M", Name = "Combat Skull" });

                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_048_M", Name = "STFU" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_040_M", Name = "American Made" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_028_M", Name = "Dusk Rider" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_022_M", Name = "Western Insignia" });
                    TatList.Add(new Tattoo { BaseName = "mpbiker_overlays", TatName = "MP_MP_Biker_Tat_004_M", Name = "Dragon's Fury" });

                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_047_M", Name = "Brake Knife" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_045_M", Name = "Severed Hand" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_032_M", Name = "Wheelie Mouse" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_025_M", Name = "Speed Freak" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_020_M", Name = "Piston Angel" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_015_M", Name = "Praying Gloves" });
                    TatList.Add(new Tattoo { BaseName = "mpstunt_overlays", TatName = "MP_MP_Stunt_tat_005_M", Name = "Demon Spark Plug" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider2_overlays", TatName = "MP_LR_Tat_030_M", Name = "San Andreas Prayer" });

                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_023_M", Name = "Dance of Hearts" });
                    TatList.Add(new Tattoo { BaseName = "mplowrider_overlays", TatName = "MP_LR_Tat_017_M", Name = "Ink Me" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe2_overlays", TatName = "MP_LUXE_TAT_023_M", Name = "Starmetric" });

                    TatList.Add(new Tattoo { BaseName = "mpluxe_overlays", TatName = "MP_LUXE_TAT_001_M", Name = "Elaborate Los Muertos" });

                    TatList.Add(new Tattoo { BaseName = "mpchristmas2_overlays", TatName = "MP_Xmas2_M_Tat_014", Name = "Floral Dagger" });

                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_042", Name = "Sparkplug" });
                    TatList.Add(new Tattoo { BaseName = "mphipster_overlays", TatName = "FM_Hip_M_Tat_038", Name = "Grub" });

                    TatList.Add(new Tattoo { BaseName = "mpbeach_overlays", TatName = "MP_Bea_M_Rleg_000", Name = "Tribal Tiki Tower" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_043", Name = "Indian Ram" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_042", Name = "Flaming Scorpion" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_040", Name = "Flaming Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_039", Name = "Broken Skull" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_022", Name = "Fiery Dragon" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_017", Name = "Tribal" });
                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_M_007", Name = "The Warrior" });

                    TatList.Add(new Tattoo { BaseName = "multiplayer_overlays", TatName = "FM_Tat_Award_M_006", Name = "Skull and Sword" });
                }//RIGHT LEG
            }// FreeMale

            if (bEmpty)
                TatList.Add(new Tattoo("", "", "No Tattoos Available"));

            return TatList;
        }
        public static List<TShirt> ShirtyList(int iPed)
        {
            List<TShirt> MyShirt = new List<TShirt>();
            if (iPed == 4)
                MyShirt = TShirtyFe;// FreeFemale
            else if (iPed == 5)
                MyShirt = TShirtyMa;// FreeMale

            if (MyShirt.Count == 0)
                MyShirt.Add(new TShirt("", "", "No Shirt Tags Available"));
            return MyShirt;
        }
        public static List<string> PedCollect()
        {
            List<string> JustNames = new List<string>();

            for (int i = 0; i < DataStore.MyPedCollection.Count(); i++)
                JustNames.Add(DataStore.MyPedCollection[i].Name);

            return JustNames;
        }
        public static bool SelectingPeds(bool bRando)
        {
            WhileButtonDown(21, true);
            bool bDone = false;
            float fDis = 50.00f;
            if (bRando)
                fDis = 150.00f;
            List<Ped> NearPeds = new List<Ped>();
            Ped[] PedXs = World.GetNearbyPeds(Game.Player.Character.Position, fDis);

            if (bRando)
            {
                for (int i = 0; i < PedXs.Count(); i++)
                {
                    if (PedXs[i] != Game.Player.Character && !PedXs[i].IsPersistent && !PedXs[i].IsDead && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_pigeon") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_crow") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_chickenhawk") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_cormorant") && PedXs[i].Model.Hash != Function.Call<int>(Hash.GET_HASH_KEY, "a_c_seagull") && PedXs[i].Model.Hash != DataStore.iAmModelHash)
                    {
                        if (DataStore.MySettingsXML.ReCritter)
                            NearPeds.Add(new Ped(PedXs[i].Handle));
                        else if (Function.Call<int>(Hash.GET_PED_TYPE, PedXs[i].Handle) != 28)
                            NearPeds.Add(new Ped(PedXs[i].Handle));
                    }
                }
            }
            else
            {
                for (int i = 0; i < PedXs.Count(); i++)
                {
                    if (PedXs[i] != Game.Player.Character && !PedXs[i].IsPersistent && !PedXs[i].IsDead)
                        NearPeds.Add(new Ped(PedXs[i].Handle));
                }
            }

            int iPerPickP = NearPeds.Count - 1;
            bool bLooking = true;
            unsafe
            {
                if (iPerPickP > -1)
                {
                    if (bRando)
                    {
                        iPerPickP = RandomX.RandInt(0, NearPeds.Count - 1);
                        Vector3 Campo = Game.Player.Character.Position;
                        if (DataStore.MySettingsXML.ReCurr)
                        {
                            Vector3 Pedpos = NearPeds[iPerPickP].Position;
                            float PedHed = NearPeds[iPerPickP].Heading;
                            NearPeds[iPerPickP].Delete();
                            Game.Player.Character.Position = Pedpos;
                            Game.Player.Character.Heading = PedHed;
                        }
                        else if (DataStore.MySettingsXML.ReSave)
                        {
                            Vector3 Pedpos = NearPeds[iPerPickP].Position;
                            float PedHed = NearPeds[iPerPickP].Heading;
                            NearPeds[iPerPickP].Delete();
                            RsActions.SavePedFinder(RandomX.FindRandom("YourSavedPed01", 0, DataStore.MyPedCollection.Count - 1));
                            Game.Player.Character.Position = Pedpos;
                            Game.Player.Character.Heading = PedHed;
                        }
                        else
                            RsActions.YourPickedPed(NearPeds[iPerPickP]);
                        bDone = true;
                    }
                    else
                    {
                        while (bLooking && NearPeds[iPerPickP].Exists())
                        {
                            Script.Wait(1);
                            RsActions.TopCornerUI(DataStore.RsTranslate[138]);
                            World.DrawMarker(MarkerType.UpsideDownCone, new Vector3(NearPeds[iPerPickP].Position.X, NearPeds[iPerPickP].Position.Y, NearPeds[iPerPickP].Position.Z + 1.50f), Vector3.Zero, Vector3.Zero, new Vector3(0.75f, 0.75f, 0.75f), Color.Red);
                            if (WhileButtonDown(51, true))
                            {
                                iPerPickP -= 1;
                                if (iPerPickP < 0)
                                    iPerPickP = NearPeds.Count - 1;

                                NearPeds[iPerPickP].Position = (Game.Player.Character.Position) + (Game.Player.Character.ForwardVector * 3);
                            }
                            else if (WhileButtonDown(21, true))
                            {
                                RsActions.YourPickedPed(NearPeds[iPerPickP]);
                                bLooking = false;
                            }
                            else if (WhileButtonDown(23, true))
                                bLooking = false;
                        }
                    }
                }
            }
            return bDone;
        }
        public static bool AreTheyTheSame(ClothBank OldBank, ClothBank newBank)
        {
            bool bYes = true;
            if (OldBank.FreeMode && newBank.FreeMode) 
            {
                if (OldBank.MyFaces == newBank.MyFaces && OldBank.Male == newBank.Male)
                {

                }
                else
                    bYes = false;
            }
            else if (OldBank.ModelX == newBank.ModelX)
            {

            }
            else
                bYes = false;

            LoggerLight.Loggers("AreTheyTheSame, bYes == " + bYes);

            return bYes;
        }
        public static int IsInTheList(ClothBank thisBank)
        {
            int inList = 0;
            for (int i = 1; i < DataStore.MyPedCollection.Count; i++)
            {
                if (thisBank.FreeMode && DataStore.MyPedCollection[i].FreeMode)
                {
                    if (thisBank.MyFaces.XshapeFirstID == DataStore.MyPedCollection[i].MyFaces.XshapeFirstID && thisBank.MyFaces.XshapeSecondID == DataStore.MyPedCollection[i].MyFaces.XshapeSecondID && thisBank.MyFaces.XshapeThirdID == DataStore.MyPedCollection[i].MyFaces.XshapeThirdID && thisBank.MyFaces.XisParent == DataStore.MyPedCollection[i].MyFaces.XisParent && thisBank.Male == DataStore.MyPedCollection[i].Male)
                        inList = i;
                }
                else if (thisBank.ModelX == DataStore.MyPedCollection[i].ModelX)
                    inList = i;
            }
            LoggerLight.Loggers("IsInTheList, Ped == " + thisBank.Name + ", inList == " + inList);
            return inList;
        }
        public static int MyPedIs()
        {
            int iPed = 0;

            if (Game.Player.Character.Model == PedHash.Michael)
                iPed = 1;
            else if (Game.Player.Character.Model == PedHash.Franklin)
                iPed = 2;
            else if (Game.Player.Character.Model == PedHash.Trevor)
                iPed = 3;
            else if (Game.Player.Character.Model == PedHash.FreemodeFemale01)
                iPed = 4;
            else if (Game.Player.Character.Model == PedHash.FreemodeMale01)
                iPed = 5;

            return iPed;
        }
        public static List<FreeOverLay> BuildOverlay(Ped Peddy)
        {
            List<FreeOverLay> MyOvers = new List<FreeOverLay>();

            for (int i = 0; i < 12; i++)
            {
                int iColour = RandomX.RandInt(0, 64);
                int iChange = Function.Call<int>(Hash._GET_PED_HEAD_OVERLAY_VALUE, Peddy.Handle, i);
                float fVar = RandomX.RandFlow(0.35f, 0.65f);

                MyOvers.Add(new FreeOverLay(iChange, iColour, fVar));
            }

            return MyOvers;
        }
        public static ClothX PickOutfit(bool bMale, int iSelect, int iSubset)
        {
            LoggerLight.Loggers("FreemodePed.PickOutfit");
            ClothX cOutput = new ClothX();

            if (bMale)
            {
                List<ClothX> CBList = new List<ClothX>();
                int iText = 0;
                int iText2 = 0;
                int iText3 = 0;

                if (iSelect == 1)
                {
                    iText = RandomX.RandInt(0, 11);
                    iText2 = RandomX.RandInt(0, 15);
                    ClothX myCB0 = new ClothX("M_Beach_0", new List<int> { 0, 0, -1, 15, 16, 0, 1, 16, -1, 0, 0, 15 }, new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, 0 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 });
                    CBList.Add(myCB0);
                    iText = RandomX.RandInt(0, 15);
                    iText2 = RandomX.RandInt(0, 11);
                    iText3 = RandomX.RandInt(0, 5);
                    ClothX myCB2 = new ClothX("M_Beach_2", new List<int> { 0, 0, -1, 5, 15, 0, 16, 0, 15, 0, 0, 17 }, new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, iText3 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 });
                    CBList.Add(myCB2);
                    ClothX myCB3 = new ClothX("M_Beach_3", new List<int> { 0, 0, -1, 5, 18, 0, 16, 0, 15, 0, 0, 36 }, new List<int> { 0, 0, 0, 0, iText2, 0, iText2, 0, 0, 0, 0, iText3 }, new List<int> { -1, -1, -1, -1, -1 }, new List<int> { -1, -1, -1, -1, -1 });
                    CBList.Add(myCB3);
                }//Beach
                else if (iSelect == 3)
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
                }//HighClass
                else if (iSelect == 4)
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
                }//MiddleClass
                else if (iSelect == 6)
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
                }//Buisness
                else if (iSelect == 9)
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
                }//Eppps
                else if (iSelect == 10)
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
                }//jogger
                else if (iSelect == 17)
                {
                    iText = RandomX.RandInt(0, 11);
                    iText2 = RandomX.RandInt(0, 3);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_Swim_14",
                        ClothA = new List<int> { 0, 0, -1, 15, 18, 0, 5, 0, 15, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 0, 0, 0, 0, 0 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                }//Swim
                else if (iSelect == 20)
                {
                    iText = RandomX.RandInt(0, 10);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "M_BikeATV_0",
                        ClothA = new List<int> { 0, 0, -1, 17, 77, 0, 55, 0, 15, 0, 0, 178 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 91, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomX.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "M_BikeATV_1",
                        ClothA = new List<int> { 0, 0, -1, 110, 67, 0, 47, 0, 15, 0, 0, 148 },
                        ClothB = new List<int> { 0, 0, 0, iText, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 62, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }//BikeATV
                else if (iSelect == 21)
                {
                    if (iSubset == 3 || iSubset == 4 || iSubset == 5 || iSubset == 6)
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
                    else if (iSubset == 7)
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
                    else if (iSubset == 10)
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
                    else if (iSubset == 11)
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
                }//Services
                else if (iSelect == 25)
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
                }//Cayo

                cOutput = CBList[RandomX.RandInt(0, CBList.Count - 1)];
            }
            else
            {
                List<ClothX> CBList = new List<ClothX>();
                int iText = 0;
                int iText2 = 0;
                int iText3 = 0;

                if (iSelect == 1)
                {
                    iText = RandomX.RandInt(0, 11);
                    iText2 = RandomX.RandInt(0, 11);
                    iText3 = RandomX.RandInt(0, 4);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Beach_0",
                        ClothA = new List<int> { 0, 0, -1, 11, 17, 0, 16, 11, 3, 0, 0, 36 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText2, 2, 0, 0, 0, iText3 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomX.RandInt(0, 15);
                    iText2 = RandomX.RandInt(0, 15);
                    iText3 = RandomX.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Beach_1",
                        ClothA = new List<int> { 0, 0, -1, 15, 12, 0, 3, 11, 3, 0, 0, 18 },
                        ClothB = new List<int> { 0, 0, 0, 0, 15, 0, 15, 1, 0, 0, 0, 11 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                    iText = RandomX.RandInt(0, 12);
                    iText2 = RandomX.RandInt(0, 11);
                    iText3 = RandomX.RandInt(0, 11);
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
                else if (iSelect == 3)
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
                }//HighClass
                else if (iSelect == 4)
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
                }//MiddleClass
                else if (iSelect == 6)
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
                }//Buisness
                else if (iSelect == 9)
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
                }//Eppps
                else if (iSelect == 10)
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
                }//jogger
                else if (iSelect == 17)
                {
                    iText = RandomX.RandInt(0, 11);
                    iText2 = RandomX.RandInt(0, 4);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_Swim_14",
                        ClothA = new List<int> { 0, 0, -1, 11, 17, 0, 35, 11, 3, 0, 0, 36 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, 0, 2, 0, 0, 0, iText2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomX.RandInt(0, 11);
                    iText2 = RandomX.RandInt(0, 10);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_Swim_15",
                        ClothA = new List<int> { 0, 0, -1, 15, 17, 0, 35, 11, 3, 0, 0, 15 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, 0, 2, 0, 0, 0, iText2 },
                        ExtraA = new List<int> { -1, -1, -1, -1, -1 },
                        ExtraB = new List<int> { -1, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }//Swim
                else if (iSelect == 20)
                {
                    iText = RandomX.RandInt(0, 10);
                    ClothX myCB0 = new ClothX
                    {
                        Title = "F_BikeATV_3",
                        ClothA = new List<int> { 0, 0, -1, 18, 79, 0, 58, 0, 3, 0, 0, 180 },
                        ClothB = new List<int> { 0, 0, 0, 0, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 90, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB0);
                    iText = RandomX.RandInt(0, 11);
                    ClothX myCB1 = new ClothX
                    {
                        Title = "F_BikeATV_4",
                        ClothA = new List<int> { 0, 0, -1, 127, 69, 0, 48, 0, 14, 0, 0, 145 },
                        ClothB = new List<int> { 0, 0, 0, iText, iText, 0, iText, 0, 0, 0, 0, iText },
                        ExtraA = new List<int> { 62, -1, -1, -1, -1 },
                        ExtraB = new List<int> { iText, -1, -1, -1, -1 }
                    };
                    CBList.Add(myCB1);
                }//BikeATV
                else if (iSelect == 21)
                {
                    if (iSubset == 3 || iSubset == 4 || iSubset == 5 || iSubset == 6)
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
                    else if (iSubset == 7)
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
                    else if (iSubset == 10)
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
                    else if (iSubset == 11)
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
                }//Services
                else if (iSelect == 25)
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
                }//Cayo

                cOutput = CBList[RandomX.RandInt(0, CBList.Count - 1)];
            }

            return cOutput;
        }
    }
}