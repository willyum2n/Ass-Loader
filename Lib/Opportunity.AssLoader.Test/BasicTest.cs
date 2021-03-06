﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opportunity.AssLoader;
using Opportunity.AssLoader.Collections;
using Opportunity.AssLoader.Effects;
using Opportunity.AssLoader.Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Opportunity.AssLoader.Test
{
    [TestClass]
    public class BasicTest : TestBase
    {
        public const string DATA =
@"[Script Info]
; This file is generated by AssLoader
; https://github.com/OpportunityLiu/Ass-Loader

ScriptType: v4.00+
Title: untitled
Original Script: unknown
Collisions: Reverse
PlayResY: 720
PlayResX: 1280
WrapStyle: 0
ScaledBorderAndShadow: No
Synch Point: 0.01
Timer: 100.0001

Video Aspect Ratio: 0
Video Zoom: 6
Video Position: 0
Last Style Storage: Upotte

[V4+ Styles]
Format: Name,Fontname,Fontsize,PrimaryColour,SecondaryColour,OutlineColour,BackColour,Bold,Italic,Underline,StrikeOut,ScaleX,ScaleY,Spacing,Angle,BorderStyle,Outline,Shadow,Alignment,MarginL,MarginR,MarginV,Encoding
Style: Comment,FZZhunYuan-M02,35,&H00FFFFFF,&H000000FF,&H00F2A5A0,&H00000000,-1,0,0,0,100,100,0,0,1,3,0,8,10,10,20,1
Style: Default,FZZhunYuan-M02,46,&H00FFFFFF,&H000000FF,&H00F2A5A0,&H00000000,-1,0,0,0,100,100,0,0,1,3,0,2,10,10,20,1
Style: STAFF,思源黑体 Heavy,38,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,0,0,0,0,100,100,0,0,1,2,0,8,10,10,20,1
Style: OP-CH,华康圆体W5(P),42,&H00FFFFFF,&H000000FF,&H00E69D50,&H00FFFFFF,0,0,0,0,100,100,0,0,1,3,2,8,20,20,20,1
Style: OP-JP,DFPPOPMix-W5,42,&H00FFFFFF,&H000000FF,&H00E69D50,&H00FFFFFF,0,0,0,0,100,100,0,0,1,3,2,2,20,20,20,1
Style: ED-CH,DFPKaiShuW5-UN,45,&H00FFFFFF,&H000000FF,&H000049FF,&H0000A2FF,0,0,0,0,100,100,0,0,1,2,3,8,10,10,20,1
Style: ED-JP,DFPKaiSho-Bd,45,&H00FFFFFF,&H000000FF,&H000049FF,&H0000A2FF,0,0,0,0,100,100,0,0,1,2,3,2,10,10,20,1

[Events]
Format: Layer,Start,End,Style,Name,MarginL,MarginR,MarginV,Effect,Text
Dialogue: 0,0:00:00.43,0:00:15.85,OP-JP,,0,0,0,aaa;bbb;ccc,{\be5\blur2\fad(150,200)}見上げる空に太陽　どんな今日にも輝く
Dialogue: 0,0:00:00.43,0:00:15.85,OP-CH,,0,0,0,Banner;12.7;1;-1.7,{\be5\blur2\fad(150,200)}仰望天空的太阳, 今天也无比闪耀
Dialogue: 0,0:00:16.35,0:00:19.81,OP-JP,,0,0,0,,{\be5\blur2\fad(150,200)}だから Go my way
Dialogue: 0,0:00:16.35,0:00:19.81,OP-CH,,0,0,0,,{\be5\blur2\fad(150,200)}来吧 Go my way

[Fonts]
fontname: name.bmp
97*D:!
fontname: name (2).bmp
97*D:'5
fontname: 中日韩.bmp
97*D:'6G

[Graphics]
filename: No Extenion
97*D:!
filename: spac   es.png
97*D:'5
filename: dd.f.ff.jpg
97*D:'6G

";

        [TestMethod]
        public void LoadExample()
        {
            var r = Subtitle.Parse(DATA);
            var t = r.Result;
            Assert.AreEqual(6, r.Exceptions.Count);
            Assert.AreEqual(7, t.Styles.Count);

            var e = t.Events.Select(ef => ef.Effect).ToArray();
            Assert.IsNull(e[2]);
            Assert.AreEqual("aaa", ((UnknownEffect)e[0]).Name);
            Assert.AreEqual(13, ((BannerEffect)e[1]).Delay);
            Assert.IsTrue(((BannerEffect)e[1]).IsLeftToRight);
            Assert.AreEqual(0, ((BannerEffect)e[1]).FadeAwayMargin);
            Assert.AreEqual(4, t.ScriptInfo.UndefinedFields.Count);
            Assert.AreEqual(4, t.Events.Count);
        }

        private sealed class CustomScriptInfo : AssScriptInfo
        {
            public override void Serialize(TextWriter writer, ISerializeInfo serializeInfo)
            {
                writer.WriteLine("; This file is generated by AssLoader");
                writer.WriteLine("; https://github.com/OpportunityLiu/Ass-Loader");
                writer.WriteLine();
                base.Serialize(writer, serializeInfo);
            }
        }

        [TestMethod]
        public void SaveExample()
        {
            var t = Subtitle.Parse<CustomScriptInfo>(DATA).Result;
            Assert.That.AreMultiLineStringEquals(DATA, t.Serialize());
        }
    }

    public class TestSerializeInfo : ISerializeInfo, IDeserializeInfo
    {
        public static TestSerializeInfo Throw { get; } = new TestSerializeInfo { isempty = false };
        public static TestSerializeInfo Empty { get; } = new TestSerializeInfo { isempty = true };

        private bool isempty;
        public void AddException(Exception ex) { if (!isempty) System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex).Throw(); }
    }
}
