Imports <xmlns:v-on="vue">
Imports <xmlns:v-bind="vue-bind">
Public Class testPage
    Inherits XPage

    Public Overrides Function Build() As String
        Return <html>
                   <head>
                       '<base href="file:///D:/Projects/ZiheCulture.com/Apps/yybc/"/>
                       '<base target="_blank"/>
                       <meta charset="utf-8"/>
                       <meta name="viewport" content="width=device-width,initial-scale=1, maximum-scale=1.0, user-scalable=0"/>
                       <meta name="apple-mobile-web-app-capable" content="yes"/>
                       <title>介绍</title>
                       <script src="https://unpkg.com/ajax-hook@2.0.3/dist/ajaxhook.min.js"></script>
                       <script src="vue.global.prod.js"></script>
                       <style type="text/css">
        ::selection {
            background-color: #B7FD51;
        }

        *, body, h1, h2, h4, h4, h5, h6, li, p, img {
            max-width: 100%
        }

        body {
            padding: 1em 0;
        }

        h2, h4, h4 {
            margin-left: 1em
        }

        div {
            background: #fefefe;
            box-shadow: 0px 0px 17px rgba(0,0,0,0.15);
            border: 1px solid #eee;
            text-overflow: ellipsis;
            padding: 20px;
            margin: 7px;
            min-height: 20px;
            border-radius: 7px;
        }

        a {
            color: #00B564;
            text-decoration: none
        }


        table, table tr th, table tr td {
            border: 1px solid #aaa;
            padding: 2px 5px;
        }

        table {
            border-collapse: collapse;
            max-width: 100%;
            width: 100%;
            font-size: smaller
        }
    </style>
                       <style type="text/css">
        body {
            margin: 0;
            -ms-overflow-style: none;
            -ms-content-zooming: none;
            overflow: hidden;
        }

        .u-parent {
            display: flex;
            align-items: center;
        }

        .u-left {
            width: auto;
        }

        .u-hcenter {
            flex: 1;
        }

        .u-right {
            width: auto;
        }

        .u-txtcenter {
            text-align: center;
        }

        .u-fixtop, .u-fixbottom {
            position: fixed;
            left: 0;
            right: 0;
            height: 53px;
            line-height: 53px;
        }

        .u-fixtop {
            top: 0;
        }

        .u-fixbottom {
            bottom: 0;
        }

        .u-fixmain {
            overflow-y: scroll;
            position: fixed;
            top: 53px;
            bottom: 53px;
            left: 0;
            right: 0;
        }

        .u-hscroll {
            white-space: nowrap;
            overflow-x: scroll;
            overflow-y: hidden;
        }
    </style>
                       <style type="text/css">

        ::-webkit-scrollbar {
            width: 0px;
        }

        .u-fixmain > section, .u-fixtop > section, .u-fixbottom > section {
            max-width: 800px;
            margin-right: auto;
            margin-left: auto;
        }

        .u-fixmain-bg {
            background-size: cover;
            position: fixed;
            position: fixed;
            top: 53px;
            bottom: 53px;
            left: 0;
            right: 0;
        }

        .u-fixtop {
            border-bottom: 1px solid #eee;
            background: #fff;
            background-size: contain;
        }

        .u-fixbottom {
            background-color: #FFF;
            border-top: 1px solid #eee;
        }

            .u-fixtop .u-parent, .u-fixbottom .u-parent {
                height: 53px;
                line-height: 53px;
            }

            .u-fixbottom .u-hcenter {
                padding: 8px 0 4px 0;
                color: #808080;
            }

                .u-fixbottom .u-hcenter:hover {
                    padding: 8px 0 4px 0;
                    color: #000;
                }

        i {
            cursor: pointer;
            font-style: normal
        }

        .sele {
            color: #00B564 !important;
        }
    </style>
                   </head>
                   <body>
                       <section id="view">
                           <section class="u-fixmain-bg"></section>
                           <section class="u-fixmain">
                               <section>
                                   <template v-if="showCzsm">
                                       <h4>快速上手</h4>
                                       <div>
                                           <p>下面演示一段简单旋律</p>
                                           <img src="de1.png" style="width:440px"/>
                                           <p>这是一段由Lua编程语言和简谱标记语言组成的代码，整段代码的意思是分别以不同乐器以四分音演奏一段简谱。</p>
                                           <p>如果你看不懂这段代码可以仅改动框线画出的部分，快速开始尝试：</p>
                                           <ul>
                                               <li><span style="color:green">绿色</span>部分是简谱标记语言，在学习简谱标记语言之前你可以随便写一些1-7的数字感受一下，如果要深入学习如何写简谱标记可以参照：<a v-on:click="vJpdy">简谱标记语言</a></li>
                                               <li><span style="color:orange">黄色</span>部分指的是以4分音演奏，不了解之前可以暂时不动</li>
                                               <li><span style="color:dodgerblue">蓝色</span>部分每个数字代表一种音色(乐器)，用逗号(半角)隔开,要更改请参照：<a v-on:click="vYsb">音色表</a></li>
                                           </ul>
                                       </div>
                                       <section v-for="i in czsm.is">
                                           <h4>{{i.t}}<small> (手机版)</small></h4>
                                           <div>
                                               <p v-html="i.v"></p>
                                           </div>
                                       </section>
                                   </template>
                                   <template v-if="showYsb">
                                       <div style="padding: 1em;">
                                           <table>
                                               <thead>
                                                   <tr style="font-size:1.2em;font-weight:bold">
                                                       <td colspan="2">{{ysb.t}}</td>
                                                   </tr>
                                                   <tr style="font-weight:bold">
                                                       <td>{{ysb.h.code}}</td>
                                                       <td>{{ysb.h.name}}</td>
                                                   </tr>
                                               </thead>
                                               <template v-for="(g,i) in ysb.gs">
                                                   <tr>
                                                       <td colspan="2">{{g.gt}}</td>
                                                   </tr>
                                                   <tr v-for="gi in g.gis">
                                                       <td>{{gi.code}}</td>
                                                       <td>{{gi.name}}</td>
                                                   </tr>
                                               </template>
                                           </table>
                                       </div>
                                   </template>
                                   <template v-if="showJpdy">
                                       <h4>简谱写法定义</h4>
                                       <div>
                                           <p>一个音符(音调)由1-7的数字、井号#(读sharp)、单引号'（半角）、点号. （半角）组成，数字是必须项，其他非必须，多个音符直接连载一起写即可。</p>
                                           <ul>
                                               <li>#：表示升调（偏音），仅在1、2、4、5、6后面有效</li>
                                               <li>在音符后面加点表示低八度 如 1.1..</li>
                                               <li>在音符后面加单引号表示高八度 如1'1''</li>
                                               <li>每节可用竖线分隔符"|"分开，此分隔符仅用于方便阅读，不会影响演奏</li>
                                               <li>0 ：表示无声</li>
                                               <li>- ：表示延长1拍，---延长3拍</li>
                                               <li>[xx] ：表示括号里的音符一起占一拍：[12]</li>
                                               <li>(xxx/) ：括号表示括号里的音符拍长减半，与简谱下横线同理，如 (5533//)</li>
                                           </ul>
                                       </div>
                                       <h4>Lua 的作用</h4>
                                       <div>
                                           <p>Lua 是一种简单、轻巧、自然的编程语言，广泛应用于游戏、硬件编程等领域，这里也引入lua编程语言，为的是处理重复工作，以更加灵活地创作。</p>
                                           <p>如果你不了解或者不想了解lua也没有关系，你可以按照“<a v-on:click="vCzsm">快速上手</a>”提供的范式修改创作即可。</p>
                                           <p>要想了解更多lua知识可以去搜索学习。</p>
                                       </div>
                                   </template>
                                   <template v-if="showKecheng">
                                       <section>
                                           <section>
                                               <h4>单音轨示例</h4>
                                               <div class="div">
                                                   <textarea type="text" style="width:95%;height:5em">for i, tone in pairs({11,24,26,32,33,46,88,99}) do
    DoQupu(tone,4,[[
553-5'5'3'-35513-3-1332126.-6.216.116.-000
]])
end</textarea><br/><br/>
                                                   <a class="button" onclick="this.previousSibling.select(); document.execCommand('copy');" href="midifun-editor:">试听</a>
                                               </div>
                                           </section>
                                           <section>
                                               <h4>双音轨示例</h4>
                                               <div class="div">
                                                   <textarea type="text" style="width:95%;height:5em">p=[[
3'-3'5'3'2'2'-1'2'3'1'6--1'2'3'1'6---1.5.1115..2.5.5.5.6..3.6.6.6.4..1.4.4.4.3'-3'5'3'2'2'--1'2'3'1'6--1'2'3'1'665--1.5.1115..2.5.5.5.6..3.6.6.6.4..1.4.5..2.5.01'61'1'02'1'2'1'2'1'2'1'2'1'3'1'0561'1'1.5.1.5.1.5.1.5.5..2.5.2.5.2.5.2.6..3.6.3.6.3.6.3.044434432101'61'1'61'1'3'2'02'1'2'1'2'1'2'1'23614..1.4.1.5..3.5.3.1.5.15.15.15.5..2.5.2.5.2.5.2.000
]]
DottQupu(0,4,p,32,4,"(-///)"..p)</textarea><br/><br/>
                                                   <a class="button" onclick="this.previousSibling.select(); document.execCommand('copy');" href="midifun-editor:">试听</a>
                                               </div>
                                           </section>
                                           <h4>视频课程</h4>
                                           <div style="margin-top:20px">
                                               <label style="font-weight:bold"></label>
                                               <p>
                                视频课程还在准备中，可关注抖音“子禾学长”（抖音号：ziheno1），后续会直播讲解如何创作以及后台审核作品的过程，指出大家作品中的问题并做解答。
                                <!--请查看：<a href="https://www.bilibili.com/video/BV1Me411W7rd">基础操作</a>-->
                                               </p>
                                               <h4>每晚9:00-9:30 B站直播</h4>
                                               <p>
                                每晚9:00-9:30 B站直播回答问题，有问题这个时间B站搜索“<b>子禾学长</b>”来直播间提问。
                            </p>
                                           </div>
                                           <p style="text-align:center;margin-top:50px">
                                               <!--此入口仅供审核团使用，想成为审核团的一员可以加QQ群参与选拔。-->
                                               <a href="http://ziheculture.com/App_Apps/MidiFun/manage-login.vbhtml">🐼</a>
                                           </p>
                                       </section>
                                   </template>
                               </section>
                           </section>
                           <section class="u-fixtop">
                               <section class="u-parent">
                                   <section class="u-left">
                                       <h3 style="margin:0 0.5em">{{t}}</h3>
                                   </section>
                                   <section class="u-right" style="padding:0 1em">
                                   </section>
                                   <section class="u-hcenter u-parent">
                                       <i v-on:click="vCzsm" v-bind:class="[showCzsm?'u-hcenter u-txtcenter sele':'u-hcenter u-txtcenter',false]">操作说明</i>
                                       <i v-on:click="vJpdy" v-bind:class="[showJpdy?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">语法</i>
                                       <i v-on:click="vYsb" v-bind:class="[showYsb?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">音色表</i>
                                       <i v-on:click="vKecheng" v-bind:class="[showKecheng?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">课程</i>
                                   </section>
                               </section>
                           </section>
                           <section class="u-fixbottom">
                               <section class="u-parent">
                                   <i v-on:click="vCzsm" v-bind:class="[showCzsm?'u-hcenter u-txtcenter sele':'u-hcenter u-txtcenter',false]">操作说明</i>
                                   <i v-on:click="vJpdy" v-bind:class="[showJpdy?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">简谱语法</i>
                                   <i v-on:click="vYsb" v-bind:class="[showYsb?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">音色表</i>
                                   <i v-on:click="vKecheng" v-bind:class="[showKecheng?'sele u-hcenter u-txtcenter':'u-hcenter u-txtcenter',false]">课程</i>
                               </section>
                           </section>

                       </section>


                       <script type="text/javascript">
        const model = {
            data() {
                return {
                    showCzsm: true,
                    showJpdy: false,
                    showYsb: false,
                    showKecheng: false,
                    t: "帮助文档",
                    is: [
                        { "t": "", "v": "" }
                    ],
                    czsm: {
                        "t": "操作说明",
                        "is": [
                            { "t": "保存", "v": '<p>点击创作界面的保存图标按钮，可以将作品保存在手机中。保存完的作品可以在“我的&gt;作品”中查看管理（左滑可删除）.</p><p>*保存的数据卸载重置软件或者清理应用数据后会丢失，请谨慎操作。</p>' },
                            { "t": "投稿", "v": '<p>你可以投稿作品到电圈中，通过审核后会出现在电圈动态中。</p><p>优秀作品会入选“精选作品”让更多人看到。</p>' },
                            { "t": "分享", "v": '<p>你可以将创作好的作品分享到其他APP中（如QQ、微信等）。让更多人欣赏你的创作，分享的内容是音频格式，几乎所以手机电脑都可播放，对方不用下载此APP。当然我们也非常欢迎你可以向好友们推荐本APP，让他们也来体验音乐创作的乐趣。</p>' }
                        ]
                    },
                    ysb: {
                        "t": "音色值对应表",
                        "h": { "code": "音色号", "name": "中文名称" },
                        "gs": [
                            {
                                "gt": "钢琴类（Piano）", "gis": [
                                    { "code": "0", "name": "原声大钢琴" },
                                    { "code": "1", "name": "亮音钢琴" },
                                    { "code": "2", "name": "电子大钢琴" },
                                    { "code": "3", "name": "酒吧钢琴" },
                                    { "code": "4", "name": "电钢琴1" },
                                    { "code": "5", "name": "电钢琴2" },
                                    { "code": "6", "name": "拨弦古钢琴" },
                                    { "code": "7", "name": "电子击弦古钢琴" }]
                            },
                            {
                                "gt": "半音性打击乐器（Chromatic Percussion）", "gis": [
                                    { "code": "8", "name": "钢片琴" },
                                    { "code": "9", "name": "钟琴" },
                                    { "code": "10", "name": "八音盒" },
                                    { "code": "11", "name": "颤音琴" },
                                    { "code": "12", "name": "马林巴" },
                                    { "code": "13", "name": "木琴" },
                                    { "code": "14", "name": "管钟" },
                                    { "code": "15", "name": "扬琴" }]
                            },
                            {
                                "gt": "风琴类（Organ）", "gis": [
                                    { "code": "16", "name": "哈蒙德风琴" },
                                    { "code": "17", "name": "击音管风琴" },
                                    { "code": "18", "name": "摇滚风琴" },
                                    { "code": "19", "name": "教堂管风琴" },
                                    { "code": "20", "name": "簧片风琴" },
                                    { "code": "21", "name": "手风琴" },
                                    { "code": "22", "name": "口琴" },
                                    { "code": "23", "name": "探戈手风琴" }]
                            },
                            {
                                "gt": "吉它类（Guitar）", "gis": [
                                    { "code": "24", "name": "尼龙弦吉它" },
                                    { "code": "25", "name": "钢弦吉它" },
                                    { "code": "26", "name": "爵士吉它" },
                                    { "code": "27", "name": "纯音吉它" },
                                    { "code": "28", "name": "闷音吉它" },
                                    { "code": "29", "name": "激励音吉它" },
                                    { "code": "30", "name": "失真吉它" },
                                    { "code": "31", "name": "吉它泛音" }]
                            },
                            {
                                "gt": "贝司类（Bass）", "gis": [
                                    { "code": "32", "name": "原声贝司" },
                                    { "code": "33", "name": "指弹电贝司" },
                                    { "code": "34", "name": "拨片电贝司" },
                                    { "code": "35", "name": "无品贝司" },
                                    { "code": "36", "name": "打弦贝司1" },
                                    { "code": "37", "name": "打弦贝司2" },
                                    { "code": "38", "name": "合成贝司1" },
                                    { "code": "39", "name": "合成贝司2" }]
                            },
                            {
                                "gt": "弦乐器（Strings）", "gis": [
                                    { "code": "40", "name": "小提琴" },
                                    { "code": "41", "name": "中提琴" },
                                    { "code": "42", "name": "大提琴" },
                                    { "code": "43", "name": "低音提琴" },
                                    { "code": "44", "name": "弦乐震音" },
                                    { "code": "45", "name": "弦乐拨音" },
                                    { "code": "46", "name": "坚琴" },
                                    { "code": "47", "name": "定音鼓" }]
                            },
                            {
                                "gt": "合奏（唱）组（Ensemble）", "gis": [
                                    { "code": "48", "name": "弦乐组 1" },
                                    { "code": "49", "name": "弦乐组 2" },
                                    { "code": "50", "name": "合成弦乐组 1" },
                                    { "code": "51", "name": "合成弦乐组 2" },
                                    { "code": "52", "name": "唱诗班啊声" },
                                    { "code": "53", "name": "哦声合唱" },
                                    { "code": "54", "name": "合成人声" },
                                    { "code": "55", "name": "管弦乐齐奏" }]
                            },
                            {
                                "gt": "铜管乐器（Brass）", "gis": [
                                    { "code": "56", "name": "小号" },
                                    { "code": "57", "name": "长号" },
                                    { "code": "58", "name": "大号" },
                                    { "code": "59", "name": "小号加弱音器" },
                                    { "code": "60", "name": "法国号" },
                                    { "code": "61", "name": "铜管组" },
                                    { "code": "62", "name": "合成铜管 1" },
                                    { "code": "63", "name": "合成铜管 2" }]
                            },
                            {
                                "gt": "簧片乐器（Reed）", "gis": [
                                    { "code": "64 ", "name": "高音萨克斯" },
                                    { "code": "65", "name": "中音萨克斯" },
                                    { "code": "66", "name": "次中音萨克斯" },
                                    { "code": "67", "name": "低音萨克斯" },
                                    { "code": "68", "name": "双簧管" },
                                    { "code": "69", "name": "英国管" },
                                    { "code": "70", "name": "大管" },
                                    { "code": "71 ", "name": "单簧管" }]
                            },
                            {
                                "gt": "管鸣乐器（Pipe）", "gis": [
                                    { "code": "72", "name": "短笛" },
                                    { "code": "73", "name": "长笛" },
                                    { "code": "74", "name": "竖笛" },
                                    { "code": "75", "name": "牧笛" },
                                    { "code": "76", "name": "瓶笛" },
                                    { "code": "77 ", "name": "尺巴" },
                                    { "code": "78 ", "name": "口哨" },
                                    { "code": "79", "name": "陶笛" }]
                            },
                            {
                                "gt": "合成领奏（Synth Lead） ", "gis": [
                                    { "code": "80 ", "name": "领奏 1 （方波）" },
                                    { "code": "81", "name": "领奏 2 （锯齿波）" },
                                    { "code": "82 ", "name": "领奏 3" },
                                    { "code": "83", "name": "领奏 4" },
                                    { "code": "84", "name": "领奏 5" },
                                    { "code": "85", "name": "领奏 6 （人声）" },
                                    { "code": "86", "name": "领奏 7 （五度）" },
                                    { "code": "87", "name": "领奏 8 （贝司与领奏）" }]
                            },
                            {
                                "gt": "合成背景音色（Synth Pad） ", "gis": [
                                    { "code": "88  ", "name": "背景 1 （新时代）" },
                                    { "code": "89", "name": "背景 2 （温暖的）" },
                                    { "code": "90", "name": "背景 3 （复合合成）" },
                                    { "code": "91", "name": "背景 4 （唱诗班）" },
                                    { "code": "92", "name": "背景 5 （弓弦音色）" },
                                    { "code": "93", "name": "背景 6 （金属般）" },
                                    { "code": "94 ", "name": "背景 7 （问候）" },
                                    { "code": "95", "name": "背景 8 （宽阔的）" }]
                            },
                            {
                                "gt": "合成效果（Synth Effects）", "gis": [
                                    { "code": "96 ", "name": "效果 1 （下雨）" },
                                    { "code": "97", "name": "效果 2 （音轨）" },
                                    { "code": "98", "name": "效果 3 （晶体）" },
                                    { "code": "99", "name": "效果 4 （气氛）" },
                                    { "code": "100", "name": "效果 5 （明亮）" },
                                    { "code": "102 ", "name": "效果 6" },
                                    { "code": "102", "name": "效果 7 （回声）" },
                                    { "code": "103", "name": "效果 8" }]
                            },
                            {
                                "gt": "民间乐器（Ethnic）", "gis": [
                                    { "code": "105 ", "name": "西塔尔" },
                                    { "code": "105", "name": "班卓" },
                                    { "code": "106", "name": "三味线" },
                                    { "code": "107", "name": "日本筝" },
                                    { "code": "108", "name": "卡林巴" },
                                    { "code": "109", "name": "风笛" },
                                    { "code": "110", "name": "小提琴" },
                                    { "code": "111", "name": "山奈" }]
                            },
                            {
                                "gt": "打击乐（Percussive） ", "gis": [
                                    { "code": "113 ", "name": "铃铛" },
                                    { "code": "113", "name": "阿果果" },
                                    { "code": "114", "name": "钢鼓" },
                                    { "code": "115", "name": "帮子" },
                                    { "code": "117 ", "name": "太叩鼓" },
                                    { "code": "117", "name": "旋律性嗵嗵鼓" },
                                    { "code": "118", "name": "合成鼓" },
                                    { "code": "119", "name": "反钹" }]
                            },
                            {
                                "gt": "音响效果（Sound Effects）", "gis": [
                                    { "code": "120", "name": "吉它滑品噪音" },
                                    { "code": "121", "name": "呼吸声" },
                                    { "code": "122", "name": "海浪声" },
                                    { "code": "123", "name": "鸟叫" },
                                    { "code": "124", "name": "电话铃声" },
                                    { "code": "125", "name": "直升飞机声" },
                                    { "code": "126", "name": "掌声" },
                                    { "code": "127", "name": "枪声" }
                                ]
                            }]
                    }
                }
            },
            methods: {
                rt() { this.t = "音乐编程帮助文档"; document.title = this.t; },
                vCzsm() { this.showCzsm = true; this.showJpdy = this.showYsb = this.showKecheng = false },
                vJpdy() { this.showJpdy = true; this.showCzsm = this.showYsb = this.showKecheng = false },
                vYsb() { this.showYsb = true; this.showCzsm = this.showJpdy = this.showKecheng = false },
                vKecheng() { this.showKecheng = true; this.showCzsm = this.showJpdy = this.showYsb = false }
            }
        }
        Vue.createApp(model).mount('#view')

       </script>
                       <script>
                           <%= <![CDATA[function loadXMLDoc()
{
  var xmlhttp;
  var txt,x,i;
  if (window.XMLHttpRequest)
  {
    // IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
    xmlhttp=new XMLHttpRequest();
  }
  else
  {
    // IE6, IE5 浏览器执行代码
    xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  }
  xmlhttp.onreadystatechange=function()
  {
    if (xmlhttp.readyState==4 && xmlhttp.status==200)
    {
      xmlDoc=xmlhttp.responseXML;
      txt="";
      x=xmlDoc.getElementsByTagName("ARTIST");
      for (i=0;i<x.length;i++)
      {
        txt=txt + x[i].childNodes[0].nodeValue + "<br>";
      }
      document.getElementById("myDiv").innerHTML=txt;
    }
  }
  xmlhttp.open("GET","https://www.runoob.com/try/demo_source/cd_catalog.xml",true);
  xmlhttp.send();
}
]]>.Value %>
                       </script>

                       <button type="button" onclick="loadXMLDoc()">获取我的 CD</button>

                       <div id="myDiv"></div>

                   </body>
               </html>.ToString
    End Function

End Class
