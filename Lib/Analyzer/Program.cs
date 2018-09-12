﻿using Opportunity.AssLoader;
using Opportunity.AssLoader.Serializer;
using Opportunity.AssLoader.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    internal class Program
    {
        private class a : IDeserializeInfo
        {
            public void AddException(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static int Foo<TEnum>(TEnum value)
            where TEnum : struct, IConvertible  // C# does not allow enum constraint
        {
            return value.ToInt32(null);
        }
        private static void Main(string[] args)
        {
            //var f = File.ReadAllText(@"..\..\..\TestFiles\Upotte[02].ass");
            //for (var i = 0; i < 0xffff; i++)
            //{
            //    var t = Subtitle.Parse<AssScriptInfo>(f);
            //    t.Result.Serialize();
            //}
            TagParser.Parse(@"as".AsSpan(), new a());
            var ssa = Subtitle.Parse(@"[Script Info]
; This is a Sub Station Alpha v4 script.
; For Sub Station Alpha info and downloads,
; go to http://www.eswat.demon.co.uk/
; or email kotus@eswat.demon.co.uk
; 
ScriptType: v4.00
Collisions: Normal
PlayResX: 320
PlayResY: 240
Timer: 100.0000

[V4 Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, TertiaryColour, BackColour, Bold, Italic, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, AlphaLevel, Encoding
Style: MainB,Arial,14,&H00ffff,&H00ff00,&H000000,&H000000, 0,-1,1,2,4,1,16,16,16,0,0
Style: Default,Arial,18,&Hffffff,&H00ffff,&H000000,&H000000, -1, 0,1,2,3,2,20,20,20,0,1
Style: MainT,Arial,14,&H00ffff,&H00ff00,&H000000,&H000000, 0, 0,1,2,4,5,16,16,16,0,0
Style: Karaoke,Arial,14,&H40ffff,&Hff4040,&H000000,&H000000, 0, 0,1,2,4,5,16,16,16,0,0
Style: B4S4B,Arial,14,&He0e0e0,&H00ff00,&H804000,&H804000, 0,-1,1,4,4,5,16,16,40,0,0
Style: B0S0K,Arial,14,&He0e0e0,&H00ff00,&H000000,&H000000, 0,-1,1,0,0,5,16,16,40,0,0
Style: B2S2R,Arial,14,&He0e0e0,&H00ff00,&H004080,&H004080, 0,-1,1,2,2,5,16,16,40,0,0
Style: B2S6G,Arial,14,&He0e0e0,&H00ff00,&H408000,&H408000, 0,-1,1,2,6,5,16,16,40,0,0
Style: ShiftJIS,MS Gothic,20,&He0e0e0,&H00ff00,&H000000,&H000000, 0, 0,1,2,4,5,16,16,16,0,128
Style: Timer,Arial,14,&H00ffff,&H00ff00,&H000000,&H000000, 0,-1,1,2,4,5,16,16,40,0,0


[Events]
Format: Marked, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
Dialogue: Marked=0,0:00:00.00,0:00:05.00,MainB,,0000,0000,0000,!Effect,{\q1}Subtitler filter for VirtualDub\NDemonstration script\N\NAvery Lee <phaeron@virtualdub.org>
Dialogue: Marked=0,0:00:05.00,0:00:10.00,MainB,,0000,0000,0000,!Effect,{\q1}Introduction\N\NThis script will demonstrate some of the simpler features of the subtitler. You will want to refer to the {\fnCourier New\b1}readme.txt{\r} file for a more complete reference.
Dialogue: Marked=0,0:00:10.00,0:00:21.00,MainB,,0000,0000,0000,!Effect,{\q1}Dialogue lines\N\NScripts are based on dialogue lines. Each dialogue line has a start time, an end time, and text to display in between.
Dialogue: Marked=0,0:00:10.00,0:00:11.00,Timer,,0000,0000,0000,!Effect,0:00
Dialogue: Marked=0,0:00:11.00,0:00:12.00,Timer,,0000,0000,0000,!Effect,0:01
Dialogue: Marked=0,0:00:12.00,0:00:13.00,Timer,,0000,0000,0000,!Effect,0:02
Dialogue: Marked=0,0:00:13.00,0:00:14.00,Timer,,0000,0000,0000,!Effect,0:03
Dialogue: Marked=0,0:00:14.00,0:00:15.00,Timer,,0000,0000,0000,!Effect,0:04
Dialogue: Marked=0,0:00:15.00,0:00:16.00,Timer,,0000,0000,0000,!Effect,0:05
Dialogue: Marked=0,0:00:16.00,0:00:17.00,Timer,,0000,0000,0000,!Effect,0:06
Dialogue: Marked=0,0:00:17.00,0:00:18.00,Timer,,0000,0000,0000,!Effect,0:07
Dialogue: Marked=0,0:00:18.00,0:00:19.00,Timer,,0000,0000,0000,!Effect,0:08
Dialogue: Marked=0,0:00:19.00,0:00:20.00,Timer,,0000,0000,0000,!Effect,0:09
Dialogue: Marked=0,0:00:20.00,0:00:21.00,Timer,,0000,0000,0000,!Effect,0:10
Dialogue: Marked=0,0:00:12.00,0:00:15.00,MainT,,0000,0000,0000,!Effect,{\c&H80FF00&}Hello.
Dialogue: Marked=0,0:00:16.00,0:00:19.00,MainT,,0000,0000,0000,!Effect,{\c&HE0E0E0&}Oh, hi.
Dialogue: Marked=0,0:00:10.00,0:00:12.00,MainT,,0000,0000,0080,!Effect,{\c&H407F00&}[02:00-05:00] Hello.
Dialogue: Marked=0,0:00:12.00,0:00:15.00,MainT,,0000,0000,0080,!Effect,{\c&H80FF00&}[02:00-05:00] Hello.
Dialogue: Marked=0,0:00:15.00,0:00:21.00,MainT,,0000,0000,0080,!Effect,{\c&H407F00&}[02:00-05:00] Hello.
Dialogue: Marked=0,0:00:10.00,0:00:16.00,MainT,,0000,0000,0080,!Effect,{\c&H707070&}[06:00-09:00] Oh, hi.
Dialogue: Marked=0,0:00:16.00,0:00:19.00,MainT,,0000,0000,0080,!Effect,{\c&HE0E0E0&}[06:00-09:00] Oh, hi.
Dialogue: Marked=0,0:00:19.00,0:00:21.00,MainT,,0000,0000,0080,!Effect,{\c&H707070&}[06:00-09:00] Oh, hi.
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0055,0055,0000,!Effect,{\q1\a10}Alignment\N\NDialogue lines may be placed in any of three horizontal placements and any of three vertical placements.
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a1\c&HE0E0E0&}Bottom\Nleft
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a2\c&HE0E0E0&}Bottom\Ncenter
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a3\c&HE0E0E0&}Bottom\Nright
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a5\c&HE0E0E0&}Top\Nleft
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a6\c&HE0E0E0&}Top\Ncenter
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a7\c&HE0E0E0&}Top\Nright
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a9\c&HE0E0E0&}Middle\Nleft
Dialogue: Marked=0,0:00:23.00,0:00:33.00,MainB,,0008,0008,0008,!Effect,{\a11\c&HE0E0E0&}Middle\Nright
Dialogue: Marked=0,0:00:35.00,0:00:45.00,MainB,,0000,0000,0000,!Effect,{\q1}Text styles\N\NText may be varied in font, size, color, and style.
Dialogue: Marked=0,0:00:35.00,0:00:45.00,MainT,,0000,0000,0000,!Effect,{\q1}You can have your text in {\c&H4060FF&}red{\r}, {\c&H60FF40&}green{\r}, and {\c&HFF6040&}blue{\r}; {\fnCourier New}Courier{\r}; {\fs16}16 point{\r} or {\fs32}32 point{\r}; {\b1}bold{\r}, {\i1}italic{\r}, or even {\b1\i1}bold italic{\r}.
Dialogue: Marked=0,0:00:47.00,0:00:57.00,MainB,,0000,0000,0000,!Effect,{\q1}Wrapping styles\N\NThree wrapping modes are supported: manual only, automatic wrapping, and smart wrapping. Smart wrapping is automatic wrapping, but with the lines broken as evenly as possible.
Dialogue: Marked=0,0:00:47.00,0:00:57.00,MainT,,0000,0000,0000,!Effect,{\q2\c&HE0FF80&}This line uses manual wrapping and won't\nbe wrapped except where explicitly broken.
Dialogue: Marked=0,0:00:47.00,0:00:57.00,MainT,,0000,0000,0045,!Effect,{\q1\c&H80E0FF&}This line uses automatic wrapping and is broken automatically.
Dialogue: Marked=0,0:00:47.00,0:00:57.00,MainT,,0000,0000,0090,!Effect,{\q0\a6\c&HFFE080&}This line uses smart wrapping and is broken with even lines. It's good for centered text.
Dialogue: Marked=0,0:00:59.00,0:01:24.00,MainB,,0000,0000,0000,!Effect,{\q1}Collisions\N\NIf two dialogue items attempt to display at the same time and place, the second one is pushed clear of the first. However, text stays in place after it is resolved, even if the collider disappears.
Dialogue: Marked=0,0:01:02.00,0:01:07.00,MainT,,0000,0000,0000,!Effect,{\q1\c&HE0E0E0&}Man, I gotta get out of here!
Dialogue: Marked=0,0:01:07.00,0:01:17.00,MainT,,0000,0000,0000,!Effect,{\q1\c&HE0E0E0&}Which way should I go? I'm not going back to school....
Dialogue: Marked=0,0:01:10.00,0:01:21.00,MainT,,0000,0000,0000,!Effect,{\q1\a7\c&H50D0FF&}Ranma, you're in the way! Move!
Dialogue: Marked=0,0:01:15.00,0:01:21.30,MainT,,0000,0000,0000,!Effect,{\q1\c&HE0E0E0&}Why would I move for an uncute tomboy like you?
Dialogue: Marked=0,0:01:21.00,0:01:25.00,MainT,,0000,0000,0000,!Effect,{\q1\a7\c&H50D0FF&}Ranma no baka!!!
Dialogue: Marked=0,0:01:21.50,0:01:24.00,MainT,,0000,0000,0000,!Effect,{\q1\c&HE0E0E0&}*wham*
Dialogue: Marked=0,0:01:26.00,0:01:36.00,MainB,,0000,0000,0000,!Effect,{\q1}Shadows and borders\N\NYou can vary the depth of the translucent shadow as well as the thickness and color of the border.
Dialogue: Marked=0,0:01:26.00,0:01:36.00,B0S0K,,0000,0000,0000,!Effect,Border=0, shadow=0
Dialogue: Marked=0,0:01:26.00,0:01:36.00,B2S2R,,0000,0000,0030,!Effect,Border=2, shadow=2 (red)
Dialogue: Marked=0,0:01:26.00,0:01:36.00,B2S6G,,0000,0000,0060,!Effect,Border=2, shadow=6 (green)
Dialogue: Marked=0,0:01:26.00,0:01:36.00,B4S4B,,0000,0000,0090,!Effect,Border=4, shadow=4 (blue)
Dialogue: Marked=0,0:01:38.00,0:01:48.00,MainB,,0000,0000,0000,!Effect,{\q1}Karaoke\N\NLetting people sing to music is dangerous. But if they're going to do it anyway, they might as well have some help. Both snap and smooth styles are supported.
Dialogue: Marked=0,0:01:40.00,0:01:45.00,Karaoke,,0000,0000,0000,Karaoke,{\fs18\k100}one {\k100}two {\k50}three-{\k50}and {\k100}four
Dialogue: Marked=0,0:01:40.00,0:01:45.00,Karaoke,,0000,0000,0030,Karaoke,{\fs18\K100}one {\K100}two {\K50}three-{\K50}and {\K100}four
Dialogue: Marked=0,0:01:50.00,0:02:00.00,MainB,,0000,0000,0000,!Effect,{\q1}DBCS (double-byte character set) support\N\NIf you have the appropriate language support installed, you can display far-east text in your subtitles. (By the way, I don't really know Japanese, so I'm kind of winged it above with the JWPce dictionary.)
Dialogue: Marked=0,0:01:50.00,0:02:00.00,ShiftJIS,,0000,0000,0000,!Effect,{\q1}{\fe0}[Keitarou]{\fe128}だ。。。大丈夫？
Dialogue: Marked=0,0:01:52.00,0:02:00.00,ShiftJIS,,0000,0000,0000,!Effect,{\a7\q1\c&HFFFF00&\fe0}[Naru]{\fe128}何よ！
Dialogue: Marked=0,0:02:02.00,0:02:17.00,MainB,,0000,0000,0000,!Effect,{\q1}Motion effects\N\NYou can scroll text in like a banner, or up the screen.
Dialogue: Marked=0,0:02:02.00,0:02:17.00,MainT,,0000,0000,0000,Banner;30,Text is fun.  We like scrolling text.
Dialogue: Marked=0,0:02:02.00,0:02:17.00,MainT,,0000,0000,0000,Scroll Up;40;50;120,{\q1}You can scroll lots of text up this way. Personally, I find it a little annoying to have a lot of text coming up very slowly on screen, but it's a useful technique to have for credits and other long lists in tabular form.
Dialogue: Marked=0,0:02:19.00,0:02:50.00,MainB,,0000,0000,0000,!Effect,{\q1}Conclusion\N\NThat concludes the demo. I hope you've enjoyed the brief glimpse I've given you here, and encourage you to read the {\fnCourier New\b1}readme.txt{\r} file for more information on the effects you've seen here. Also, if you're bored, try loading this script into Kotus' Sub Station Alpha V4 program. Not all effects will render correctly, but most of the file will. Have fun, and keep on subtitling!\N\N{\fnCourier New}--{\r}Avery Lee <phaeron@virtualdub.org>\N{\fnCourier New}\h\h{\r}Author of VirtualDub and the 'subtitler' filter
");
        }
    }
}
