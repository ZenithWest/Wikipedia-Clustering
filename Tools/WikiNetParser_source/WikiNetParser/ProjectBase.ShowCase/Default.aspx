<%@ Page Language="C#"
validateRequest="false"
CodeBehind="Default.aspx.cs"
Inherits="ProjectBase.ShowCase.Default"
EnableViewState="false"
 %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Wiki.NET example</title>
    <link href="css/110Basic.css" rel="stylesheet" type="text/css" />
    <link href="css/330Document.css" rel="stylesheet" type="text/css" />
</head>
<body style="overflow: auto;">

    <form id="form1" runat="server" action="Default.aspx">
    <div style="height:30px;">
    <button type="submit">Change the text</button> Adjust the wiki text (central column) and test it
    (Reload the <a href="Default.aspx" >Default</a>)
    </div>
    <div>
        <div style="float: left; width:32%;" ><b>browser's RESULT</b></div>
        <div style="float: left; width:32%;" ><b>EDITOR Wiki .NET Syntax (type here)</b></div>
        <div style="float: left; width:32%;" ><b>generated HTML</b></div>
    </div>
    <div style="height:600px; font-size:100%; " class="documentation">
        <div class="document" style="float: left; border:1px solid blue; width:32%; height: 100%; overflow: auto; ">
            <asp:Literal ID="converted" runat="server" ></asp:Literal>
        </div>

        <textarea runat="server" id="txtarea" name="txtarea"
        style="display:block; float: left; width:32%; height: 600px;"  >[B: latest downloads]: [URL:http://catarsa.com/Articles/Download/WikiParser]

|H1 WIKI.NET [NAME:top]

[NUM
[URL:#simpleText|TEXT: Simple Text]
[URL:#paragraph|TEXT: Headers and Paragraphs]
[URL:#lists|TEXT: Lists] [GREEN:[I:(extended)]]
[URL:#navigation|TEXT: Navigation]  [GREEN:[I:(fixed for long url)]]
[URL:#image|TEXT: Image]
[URL:#decoration|TEXT: Decorations and Colors]  [GREEN:[I:(extended)]]
[URL:#block|TEXT: Block]
[URL:#escaped|TEXT: Escaped character syntax]
[URL:#tables|TEXT: Tables]  [GREEN:[I:(new)]]
NUM]


|H2 Notes
|P1 This document is written in the [B:[GREEN:Wiki .NET]] Syntax and converted with the [B:[GREEN:Wiki .NET Parser]]  (and therefore could be taken as a proof of concept).
|P1 [B:[GREEN:WIKI.NET]] is based on the ANTLR3 for C#.NET. Very few rows of the lexer, grammar and AST Parser; future extensibility; easy maintainability; exceptional performance
|P1 Syntax of the [B:[GREEN:Wiki .NET]] is (from the highlighting point of view) mostly C# and XML oriented.
|P1 In next paragraphs there is complete description of the syntax with examples. Syntax elements could be split into these categories:

[LI
Blocks (special formatting like XML)
Inline Blocks (text)
Decoration (styles, colors)
Hyperlinks and images
LI]

|P1 As in another languages there is a small set of the special leading characters used in [B:[GREEN:Wiki .NET]] Syntax:
[LI
[SAMP:[PURPLE:[[]]] (opening block)
[SAMP:[PURPLE:[]]]] (closing block)
[SAMP:[PURPLE:[|]]] (inline block; attribute separator)
[SAMP:[PURPLE:[:]]] (attribute value starts)
LI]
|P1 These signs combined with keywords provides complete [B:[GREEN:Wiki .NET]] playground for safe text publishing.




|H2 [NAME:simpleText] Simple Text
|PR [URL:#top | TEXT: top]



|H3 Keywords
[LI
[SAMP:[I:(there are NO keywords)]]
LI]

|H3 Description
|P1 You can type text as it goes. It will be rendered as usual text without any formatting.

|P1 The newlines (ENTER) will be rendered as a html specific new lines (instead of &quot;\r\n&quot; - &quot;&lt;br /&gt;&quot;).

|P1 More Spaces (more then 1) will be all rendered (not skipped). [I: (Standard HTML browser will convert multi-space into single one)]

|P1 Empty lines are skipped. To append empty line to the output, place the White space on the line [I:(white space and press ENTER)]

|H3 Syntax
[CODE
There is no special syntax, just type...

CODE]

|H3 Example

|H4 wiki
[CODE
1) Text with the
broken lines
2) Text with    spaces
CODE]

|H4 result
[BQ
1) Text with the
broken lines
2) Text with    spaces
BQ]










|H2 [NAME:paragraph] Headers and Paragraph
|PR [URL:#top | TEXT: top]




|P Headers and Paragraphs has the syntax based on 3 parts
[NUM
[SAMP:[BLUE:[|]]] Leading vertical line at the beginning
[SAMP:[BLUE:H1]] The name of the used header or paragraph
[SAMP:[BLUE:&#39; &#39;]] One WHITE SPACE!
NUM]
|H3 Keywords
[LI
[SAMP:[PURPLE:[|]H1 .. [|]H6 ]  ](headers)
[SAMP:[PURPLE:[|]P ]          ](paragraph)
[SAMP:[PURPLE:[|]P1 .. [|]P3 ]  ](paragraphs with different margins)
[SAMP:[PURPLE:[|]PC ]         ](center aligned paragraph)
[SAMP:[PURPLE:[|]PR ]         ](right aligned paragraph)
[SAMP:[PURPLE:[|]CITE ]       ](cite text (italic))
[SAMP:[PURPLE:[|]BQ ]         ](blockquote text with larger padding)
LI]

|H3 Description

|P1 Headers and Paragraphs allows formatting based on &#39;inline block&#39; style.

|P1 It means, that the text between the opening symbol (e.g. &#39;[SAMP:[PURPLE:[|]P ]]&#39; and the end of line [I:(ENTER)] is rendered as a paragraph &lt;p&gt;...&lt;/p&gt;)


|H3 Syntax
[CODE
[PURPLE:[|]H1 ] Header 1
- &gt; &lt;h6&gt;Header 1 &lt;/h6&gt;
..
[PURPLE:[|]H6 ] Header 6
- &gt; &lt;h6&gt;Header 6&lt;/h6&gt;

[PURPLE:[|]P ] Usuall text...
- &gt; &lt;p&gt;Usuall text...&lt;/p&gt;

CODE]

|H3 Example

|H4 wiki
[CODE
[PURPLE:[|]H3 ] Lorem ipsum
[PURPLE:[|]P1 ] Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dor eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

[PURPLE:[|]P2 ] Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum


[PURPLE:[|]CITE ] Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.

[PURPLE:[|]BQ ] Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

[PURPLE:[|]PR ] Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.

CODE]

|H4 result
[BQ

|H3 Lorem ipsum
|P1 Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dor eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

|P2 Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

|CITE Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.

|BQ Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.

|PR Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.

BQ]






|H2 [NAME:lists] Lists
|PR [URL:#top | TEXT: top]


|P1 There are two types of lists. Wrapped and inline, for both &#39;numbered&#39; and &#39;pointed&#39; types.

|H3 Keywords
Block syntax, uses starting and closing tags LI or/and NUM to wrap selected rows as list items.
[LI
[SAMP:&#39;[[]LI&#39;   &#39;LI[]]&#39;  ]
[SAMP:&#39;[[]NUM&#39;  &#39;NUM[]]&#39;  ]
LI]

Inline syntax will render every row as a list item if starting with one of below statements (the space sign after asterix or hash is important)
[LI
[SAMP:&#39;* &#39;]
[SAMP:&#39;** &#39;]
[SAMP:&#39;*** &#39;]
[SAMP:&#39;# &#39;]
[SAMP:&#39;## &#39;]
[SAMP:&#39;### &#39;]
LI]

|H3 Description
|P1 You can choose block or inline style. Block lists can be nested. Inline syntax must be correctly growing (cannot start with &#39;** &#39;)


|H3 Block Syntax
[CODE
[PURPLE:[[]LI ]
meals
colors
[PURPLE:[[]NUM ]
blue
red
[PURPLE: NUM[]]]
[PURPLE: LI[]]]
CODE]

|H3 Inline Syntax
[CODE
[PURPLE:* ] meals
[PURPLE:* ] colors
[PURPLE:## ] blue
[PURPLE:## ] read
CODE]

|H3 Result for both
[CODE
&lt;ul&gt;
&lt;li&gt;meals&lt;/li&gt;
&lt;li&gt;colors
&lt;ol&gt;
 &lt;li&gt;blue&lt;/li&gt;
 &lt;li&gt;red&lt;/li&gt;
&lt;/ol&gt;&lt;/li&gt;
&lt;ul&gt;
CODE]


|H3 Example

|H4 wiki
[CODE
 // blocks
[PURPLE:[[]LI ]
Meals:
Supported colors are:
[PURPLE:[[]NUM ]
blue
red
green
[PURPLE:NUM[]]]
[PURPLE: LI[]]]
 // inlines
[*] Meals:
[*] Supported colors are:
[#]# blue
[#]# red
[#]# green
CODE]

|H4 result
[BQ
 // blocks
[LI Meals:
Supported colors are:
[NUM blue
red
green NUM]
LI]
 // inlines
* Meals:
* Supported colors are:
## blue
## red
## green

BQ]










|H2 [NAME:navigation] Navigation
|PR [URL:#top | TEXT: top]





|H3 Keywords
[LI
[SAMP:[PURPLE:URL]]
[SAMP:[PURPLE:URL [|] TEXT]]
[SAMP:[PURPLE:NAME]]
LI]
|H3 Description

|P1 There are two keywords: [SAMP:URL] and [SAMP:NAME] for creating the hyperlinks.

|P1 The first [I:([SAMP:URL])] will result in the hyperlink with the [V:href] attribute (where to navigate). There are few different ways how to change the text of the hyperlink, if the [VAR:url] itself is not suitable (e.g. [DFN:&lt;a href=&quot;target&quot;&gt;target&lt;/a&gt;] to [DFN:&lt;a href=&quot;target&quot;&gt;my TEXT&lt;/a&gt;])

|P1 The second will create the anchor  [I:([SAMP:NAME])] to which could be page scrolled [I:(e.g. the &#39;top&#39; hyperlinks navigating to the top of the page)]

|H3 Syntax URL
[CODE

[PURPLE:[[]URL:index.htm#top]] // only url
==&gt; &lt;a ref=&quot;index.htm#top&quot;&gt;index.htm#top&lt;/a&gt;

[PURPLE:[[]URL: click here [|] index.htm#top]]          // short text first
==&gt; &lt;a ref=&quot;index.htm#top&quot; &gt;click here&lt;/a&gt; // then vline &#39;|&#39; and url


// OR
[PURPLE:[[]URL:  index.htm#top [|]TEXT: click here]]    // first url
==&gt; &lt;a ref=&quot;index.htm#top&quot; &gt;click here&lt;/a&gt; // then attr &#39;|TEXT:&#39; and text

[PURPLE:[[]URL: [&quot;]index.htm#top[&quot;] [|]TEXT: click here]]   // quoted url (if too long and complicated url)
==&gt; &lt;a ref=&quot;index.htm#top&quot; &gt;click here&lt;/a&gt; // |TEXT: next with an attr &#39;TEXT:&#39;


CODE]

|H3 Syntax NAME
[CODE
[PURPLE:[[]NAME:top]]
- &lt;a name=&quot;top&quot;&gt;&lt;/a&gt;
CODE]

|H3 Example

|H4 Wiki
[CODE
[PURPLE:[[]URL:#top]]   - only url
[PURPLE:[[]URL:TOP [|] #top]]  - text first


[PURPLE:[[]URL: #top  [|]TEXT: TOP]] - TEXT: attribute
[PURPLE:[[]URL:[&quot;]#top[&quot;] [|]TEXT: TOP]] - quoted url

CODE]
|H4 Result

[BQ
[URL:#top]  - only url
[URL:TOP|#top] - short text first


[URL:#top|TEXT:TOP]  - TEXT: attribute
[URL:&quot;#top&quot;|TEXT:TOP]  - quoted url
BQ]








|H2 [NAME:image] Image
|PR [URL:#top | TEXT: top]





|H3 Keywords
[LI
[SAMP:[PURPLE:IMG]]
[SAMP:[PURPLE:HEIGHT]]
[SAMP:[PURPLE:WIDTH]]
[SAMP:[PURPLE:FLOAT]]
LI]

|H3 Description
|P1 [SAMP:[PURPLE:IMG]] element allows you to insert the image into to the page.

|P1 The URL for image should be relative, for instance &#39;i/cs.png&#39;

|P1 There is an issue with the virtual directories for applications. E.g. instead of [I:http://mydomain/] there is [I:http://mydomain/myvirtualdir/]. In these situations there is a background call which will change the IMG src attribute from  [S:[RED:&#39;i/cs.png&#39;]] to  [GREEN:&#39;myvirtualdir/i/cs.png&#39;] and the image will be correctly displayed.

|H3 Syntax
[CODE
[PURPLE:[[]IMG:i/cs.png[]]]
==&gt; &lt;img src=&quot;i/cs.png&quot; /&gt;

[PURPLE:[[]IMG:i/cs.png [|]HEIGHT:100px[|]WIDTH:80px[]]]
==&gt; &lt;img src=&quot;i/cs.png&quot; style=&quot;height:100px;width:80px;&quot; /&gt;

[PURPLE:[[]IMG:i/cs.png [|]FLOAT:right[]]]
==&gt; &lt;img src=&quot;i/cs.png&quot; style=&quot;float:right;&quot; /&gt;

CODE]

|H3 Example

|H4 wiki
[CODE

[PURPLE:[|]P1 ] Lorem ipsum dolor [PURPLE:[[]IMG:i/cs.png[]]]  sit amet, consectetur adipisicing elit, sed dor eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

[PURPLE:[|]P2 ] Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. [PURPLE:[[]IMG:i/cs.png[|]HEIGHT:100px[|] WIDTH:80px[]]]  Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

[PURPLE:[|]P3 ] Sed [PURPLE:[[]IMG:i/cs.png[|]FLOAT:right[]]]  ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.


CODE]

|H4 result
[BQ

|P1 Lorem ipsum dolor [IMG:i/cs.png]  sit amet, consectetur adipisicing elit, sed dor eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.


|P2 Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. [IMG:i/cs.png |HEIGHT:100px| WIDTH:80px]  Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

|P3 Sed [IMG:i/cs.png|FLOAT:right] ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.

BQ]







|H2 [NAME:decoration] Decorations and Colors
|PR [URL:#top | TEXT: top]




|H3 Keywords
[B: Special bold and italic:]
[LI
[SAMP: [*]bold text[*]   ]*bold text*
[SAMP: [_]italic text[_] ] _italic text_
LI]

[B: Decorations:]
[LI
[SAMP:[PURPLE:B]     ][B:bold]
[SAMP:[PURPLE:I]     ][I:italic]
[SAMP:[PURPLE:U]     ][U:underline]
[SAMP:[PURPLE:S]     ][S:striked]
[SAMP:[PURPLE:V]     ][V:variable]
[SAMP:[PURPLE:SAMP]  ][SAMP:sample]
[SAMP:[PURPLE:BIG]   ][BIG:big]
[SAMP:[PURPLE:SMALL] ][SMALL:small]
[SAMP:[PURPLE:SUP]   ]sup [SUP:*sup]
[SAMP:[PURPLE:SUB]   ]sub [SUB:*sub]
LI]

[B: Colors:]
[LI
[SAMP:[PURPLE:BLUE]   ][BLUE:blue]
[SAMP:[PURPLE:RED]    ][RED:red]
[SAMP:[PURPLE:GREEN]  ][GREEN:green]
[SAMP:[PURPLE:OLIVE]  ][OLIVE:olive]
[SAMP:[PURPLE:LIME]   ][LIME:lime]
[SAMP:[PURPLE:PURPLE] ][PURPLE:purple]
[SAMP:[PURPLE:YELLOW] ][YELLOW:yellow]
[SAMP:[PURPLE:MAROON] ][MAROON:maroon]
[SAMP:[PURPLE:SILVER] ][SILVER:silver]
[SAMP:[PURPLE:ORANGE] ][ORANGE:orange]
[SAMP:[PURPLE:NAVY]   ][NAVY:navy]
[SAMP:[PURPLE:PINK]   ][PINK:pink]
LI]

|H3 Description
|P1 Decoration styles and colors are &#39;inline&#39; elements. This means that these elements cannot contain new lines!

|P1 You can use them almost anywhere and if needed they can be even nested (e.g. bold and blue)

|H3 Syntax
[CODE
// bold and italic inside some row
.. not bold [*]now bold until here[*] not bold ..
==&gt; .. not bold &lt;b&gt;now bold until here&lt;/b&gt; not bold ..

.. not italic [_]now italic until here[_] not italic ..
==&gt; .. not italic &lt;i&gt;now italic until here&lt;/i&gt; not italic ..

// bold and italic
[PURPLE:[[]B:bold[]]]
==&gt; &lt;b&gt;bold&lt;/b&gt;

[PURPLE:[[]I:italic[]]]
==&gt; &lt;i&gt;italic&lt;/i&gt;


// COLOR example: blue and purple
[PURPLE:[[]BLUE:blue[]]]
- &gt; &lt;span style=&quot;color:blue;&quot;
&gt;blue&lt;/span&gt;
[PURPLE:[[]PURPLE:purple[]]]
- &gt; &lt;span style=&quot;color:purple;&quot;
&gt;purple&lt;/span&gt;

CODE]

|H3 Example

|H4 wiki
[CODE
[PURPLE:[|]CITE] This text could be partially [PURPLE:[[]B:]bold end even [PURPLE:[[]ORANGE:]orange[PURPLE:[]][]]]. And that all inside the big [PURPLE:[[]BIG:]CITE[PURPLE:[]]] element.
CODE]

|H4 result
[BQ
|CITE This text could be partially [B:bold end even [ORANGE:orange]]. And that all inside the [BIG:CITE] element.
BQ]






|H2 [NAME:block] Block
|PR [URL:#top | TEXT: top]



|P1 There are 3 special block elements for specific text rendering: CODE, XML, HTML. There is also the BlockQuote element: BQ.

|H3 Keywords
[LI
[SAMP:[PURPLE:CODE ]  ][I:C# syntax support]
[SAMP:[PURPLE:XML ]   ][I:xml syntax support]
[SAMP:[PURPLE:HTML ]  ][I:html specific syntax support]
[SAMP:[PURPLE:BQ ]    ][I:support for multi-line blockquote]
[SAMP:[PURPLE:PRE ]   ][I:renders PRE element]
LI]

|H3 Description

|P1 These block elementshas the special syntax which has OPENING and CLOSING tags. The text placed between the CODE, XML, HTML marks is rendered with special syntax support.

|P1 Usage of these element is extremely simple: just copy your code, and place it between [PURPLE:[[]CODE CODE[]]] elements. That&#39;s all


|H3 Syntax
[CODE
[PURPLE:[[]CODE ]
public interface IModel {}
[PURPLE:CODE[]]]
- &gt; &lt;code&gt;
&lt;span class=&quot;base&quot; &gt;public&lt;/span&gt;
&lt;span class=&quot;base&quot; &gt;interface&lt;/span&gt;
IModel&lt;br /&gt;
&lt;span class=&quot;smbl&quot; &gt;{&lt;/span&gt;&lt;br /&gt;

&lt;span class=&quot;cmmnt&quot;
&gt;// TODO&lt;/span&gt;&lt;br /&gt;
&lt;span class=&quot;smbl&quot; &gt;}&lt;/span&gt;&lt;br /&gt;
&lt;/code&gt;

CODE]

|H3 Example

|H4 wiki
[CODE

[PURPLE:[|]H5 ] CODE

[PURPLE:[[]CODE ]
public interface IModel
{
// TODO
}
[PURPLE:CODE[]]]


[PURPLE:[|]H5] XML

[PURPLE:[[]XML ]
&lt;project&gt;
  &lt;settings&gt;
    &lt;mode value=&quot;Leveled&quot;
       type=&quot;Fluent&quot; /&gt;
    &lt;readability name=&quot;Inner&quot; &gt;
      &lt;!-- TODO --&gt;
      ... extended in the next phase ...
    &lt;/readability&gt;
  &lt;/settings&gt;
&lt;/project&gt;
[PURPLE:XML[]] ]


[PURPLE:[|]H5] HTML

[PURPLE:[[]HTML ]
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
  &lt;head&gt;
    &lt;title&gt;&lt;/title&gt;
  &lt;/head&gt;
  &lt;body&gt;
    &lt;a href=&quot;Default.aspx&quot; &gt;
      Default&lt;/a&gt;
  &lt;/body&gt;
&lt;/html&gt;
[PURPLE:HTML[]] ]

CODE]



|H4 result
[BQ

|H5 CODE

[CODE
public interface IModel
{
   // TODO
}
CODE]


|H5 XML
[XML
&lt;project&gt;
  &lt;settings&gt;
    &lt;mode value=&quot;Leveled&quot;
        type=&quot;Fluent&quot; /&gt;
    &lt;readability name=&quot;Inner&quot; &gt;
        &lt;!-- TODO --&gt;
        extended in the next phase
    &lt;/readability&gt;
  &lt;/settings&gt;
&lt;/project&gt;
XML]


|H5  HTML

[HTML
&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; &gt;
  &lt;head&gt;
    &lt;title&gt;&lt;/title&gt;
  &lt;/head&gt;
  &lt;body&gt;
    &lt;a href=&quot;Default.aspx&quot; &gt;
    Default&lt;/a&gt;
  &lt;/body&gt;
&lt;/html&gt;
HTML]


BQ]



|H2 [NAME:escaped] Escaped character syntax
|PR [URL:#top | TEXT: top]


|P1 There are some special characters used for this wiki markup. They are [B:leading symbols] and therefore cannot be used directly in the text

|P1 If they are used directly (without escaping) they could result in unwanted streams; or even break the whole page.

|H3 Keywords
[LI
[SAMP:[PURPLE:[[] ]]
[SAMP:[PURPLE:[]] ]]
[SAMP:[PURPLE:[|] ]]
[SAMP:[PURPLE:[:] ]]
[SAMP:[PURPLE:[&lt;] ]]
[SAMP:[PURPLE:[&gt;] ]]
[SAMP:[PURPLE:[*] ]]
[SAMP:[PURPLE:[#] ]]
[SAMP:[PURPLE:[_] ]]
[SAMP:[PURPLE:[&quot;] ]]
LI]

|H3 Description
|P1 To correctly render these signs you have to use the [B:escape syntax]

|P1 The syntax is simple: encapsulate the sign in these braces &#39;[[]&#39; &#39;[]]&#39;

|H3 Syntax
[CODE
[PURPLE:[[][[][]]]
==&gt; [[]
[PURPLE:[[][]][]]]
==&gt; []]
[PURPLE:[[][:][]]]
==&gt; [:]
[PURPLE:[[][|][]]]
==&gt; [|]
[PURPLE:[[][&lt;][]]]
==&gt; [&lt;]
[PURPLE:[[][&gt;][]]]
==&gt; [&gt;]
[PURPLE:[[][*][]]]
==&gt; [*]
[PURPLE:[[][#][]]]
==&gt; [#]
[PURPLE:[[][_][]]]
==&gt; [_]
[PURPLE:[[][&quot;][]]]
==&gt; [&quot;]

CODE]

|H3 Example

|H4 wiki
[CODE

[PURPLE:Index[[][[][]]2[[][]][]]]

to not display less and greater as the element
[PURPLE:[[]XML ]
[RED:&lt;wrong&gt;]
[PURPLE:[[][&lt;][]]right[[][&gt;][]]]
[PURPLE:XML[]]]

CODE]

|H4 result
[BQ
Index[[]2[]]
[XML
&lt;wrong&gt;
[&lt;]right[&gt;]
XML]
BQ]



|H2 [NAME:tables] Tables
|PR [URL:#top | TEXT: top]

|P1 Tables has been introduced following the usual syntax of the VLINE  [SAMP:[|]]
|P1 Use two VLINEs [SAMP:[|][|]] for a table head, and single VLINE [SAMP:[|]] for a table row

|H3 Keywords
[LI
[|]|
[|]
LI]
|H3 Syntax
[CODE
[|]| heading1 || heading2 // two VLINEs will render THEAD
[|]| heading3 || heading4
[|]  cell1    |  cell2    // single VLINE for a row
[|]  cell3    |  cell4
CODE]

|H3 Example

|H4 wiki
[CODE
[|]| id  || date     || name
[|]  123 |  1.2.2011 | myName
CODE]


|H4 result

|| id || date || name
|  123 |  1.2.2011 | myName


|PR [URL:#top | TEXT: top]

Enjoy the Wiki .NET Parser</textarea>

        <div style="float: left; border:1px solid green; width:32%; height: 100%; overflow: auto;">
            <asp:Literal ID="source" runat="server" ></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
