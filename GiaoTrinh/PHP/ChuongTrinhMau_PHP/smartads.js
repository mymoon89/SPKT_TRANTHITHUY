var KeywordMax = 50;
var numberKeywords = 0;
var currentPopup = "";
var dragObject = null;
var mouseOffset = null;
var mouseIsDown = false;
var whichDrag = null;
var lastPopupId = 0;
var xOffset = 5;
var yOffset = 1;
var spacesRegExp = new RegExp("(^[\\240\\s]+)|([\\240\\s]+$)", "g");
var server_image_location =   "http://static.vclick.vn/vclick/www/delivery/";
var aHighlightedKeywords = new Array();

document.write("<style>");
document.write(".VClickTextLink{text-decoration:underline;border-bottom:1px solid #2B9900;padding-bottom: 0px;color:darkgreen;background-color:transparent;cursor:pointer;cursor:hand;white-space:nowrap;}");
document.write(".VClickTooltip{border:none;border-style:none;padding:0px 0px 0px 0px;margin:0px 0px 0px 0px;background-color:transparent;}");
document.write(".td_reset { margin:0; padding:0; }");
document.write(".table_reset {margin:0;padding:0;}");
document.write("</style>");
document.write('<link type="text/css" rel="stylesheet" href="' + server_location + 'vclick.css">');

if (navigator.appName == "Netscape")
    document.write("<style>.VClickTextLink{padding-bottom: 0px;}</style>");


function objectTransparent() {
    var objects = document.getElementsByTagName('object');
    if (objects) {
        for (i = 0; i != objects.length; i++) {
            objects[i].setAttribute('wmode', 'transparent');
        }
        var embeds = document.getElementsByTagName('embed');
        for (i = 0; i != embeds.length; i++) {
            embeds[i].setAttribute('wmode', 'transparent');
        }
    }
}
objectTransparent();
function traverseDomTree() {
    var content_section = document.getElementById("vclick");
    if(content_section)
    {
        traverseDomTree_recurse(content_section, 0);
    }
    else{
        var body_element = document.getElementsByTagName("body");
        traverseDomTree_recurse(body_element[0], 0);
    }
    // Get Banner.
    if(auto_extract_keyword == false)
    {
        var strKeywords = aHighlightedKeywords.join("_");
        var link = '<s' + 'cript src="' + server_location + 'txtadslist.php?keywordid=' + strKeywords + '" language="javascript"></' + 'script>';
        document.write(link);
    }
}
function traverseDomTree_recurse(curr_element, level){
    var i;
    if (curr_element.childNodes.length <= 0) {
        if (curr_element.nodeName == "#text") {
			curr_element.nodeValue = curr_element.nodeValue.replace(/\n/g,' ');
			setUnderlineContent(curr_element);
        }
    } else {
        for (i = 0; curr_element.childNodes[i]; i++) {
            var isValid = isValidNode(curr_element.childNodes[i]);
            var isHidden = isHiddenNode(curr_element.childNodes[i]);
			if (isValid && !isHidden) {
				traverseDomTree_recurse(curr_element.childNodes[i], level + 1);
            }
        }
    }
}
function isValidNode(node) {
    var aInvalidNode = [',', 'OBJECT','EMBED', 'SELECT', 'SCRIPT', 'NOSCRIPT', 'TEXTAREA', 'IFRAME', 'PRE', 'META', 'MARQUEE', 'INPUT', 'STYLE', '#COMMENT', 'LINK', 'A', ','];
    var strInvalidNode = aInvalidNode.toString();
    var nodeName = node.nodeName;
    if (strInvalidNode.search(("," +nodeName + ",").toUpperCase()) != -1 ) {
        return false;
    }
    return true;
}
function isHiddenNode(node) {
    if (node.nodeType == 1) {
        var cStyle = getNodeStyle(node);
        if (cStyle && (cStyle.visibility == 'hidden' || cStyle.visibility == 'hide' || cStyle.display == 'none'))
			return true;
    }
    return false;
}
function getNodeStyle(node) {
    var s = null;
    if (node.currentStyle) {
        s = node.currentStyle;
    } else if (document.defaultView && document.defaultView.getComputedStyle) {
        s = document.defaultView.getComputedStyle(node, null);
    }
    if (!s && node.style) s = node.style;
    return s;
}
function trim(str) {
    return str.replace(spacesRegExp, "");
}
function setUnderlineContent(nodeText) {
    var curNode = nodeText;
    var cur = trim(curNode.nodeValue).length;
    if (cur < 100) return;

    var i = 0;
	if(numberKeywords > KeywordMax)
		return;
	var count = 0;
    while (i < keywords.length) {
        if(curNode == null)
            break;
        var words = keywords[i][1].toLowerCase().split(" ");
        if (words.length == 1) reg = new RegExp("(\\s" + keywords[i][1] + "\\s)", "i");
        else reg = new RegExp("(" + keywords[i][1] + ")", "i");
        strContent = curNode.nodeValue.toLowerCase();
        if (strContent.search(reg) != -1) {
            var linkOffset = strContent.search(reg);
			if(numberKeywords > KeywordMax || count > 0) {
				break;
			}
            curNode = insertUnderline(curNode, linkOffset, RegExp.$1, keywords[i][0], keywords[i][2]);
            aHighlightedKeywords.push(keywords[i][0]);
            keywords[i][1] = "(^#$%&)(-+^@^)";
			numberKeywords++;
			count++;

        }
		i++;

    }
}
function insertUnderline(node, stringPosition, keyword, keyword_id, banner_id) {

	var innerText = node.nodeValue.substring(stringPosition, stringPosition + keyword.length);
    var beforeText = node.nodeValue.substring(0, stringPosition);
    var afterText = node.nodeValue.substring(stringPosition + keyword.length);
    var beforeNode = null;
    var afterNode = null;
    var linkNode = buildLink(keyword_id, innerText, banner_id);
    if (beforeText == null) beforeText = '';
    beforeNode = document.createTextNode(beforeText);
    node.parentNode.insertBefore(beforeNode, node);
    node.parentNode.insertBefore(linkNode, node);
    if (afterText) {
        afterNode = document.createTextNode(afterText);
        node.parentNode.insertBefore(afterNode, node);
    }
    node.parentNode.removeChild(node);
    return afterNode;
}
function buildLink(keyword_id, keyword, banner_id) {
    var span = document.createElement("span");
    span.setAttribute('style', "text-decoration: underline; border-bottom-style: solid;border-bottom-width: 1px;");
    span.id = "link" + keyword_id;
    span.onmouseover = function() {
        showAdvertisementBanner(keyword_id,  banner_id)
    };
    span.onmouseout = function() {
        hideAdvertisementBanner(keyword_id);
    };
    span.className = "VClickTextLink";
    span.innerHTML = keyword;
    return span;
}
function setStyleValue(objectID, propertyName, propertyValue) {
    try {
    document.getElementById(objectID).style[propertyName] = propertyValue;
    }
    	catch(e) {  }
}
function setPropertyValue(objectID, propertyName, propertyValue) {
    document.getElementById(objectID)[propertyName] = propertyValue;
}
function getStyleValue(objectID, propertyName) {
    return document.getElementById(objectID).style[propertyName];
}
function getPropertyValue(objectID, propertyName) {
    return document.getElementById(objectID)[propertyName];
}
function getRealPosition(control, direct) {
    (direct == "x") ? pos = control.offsetLeft: pos = control.offsetTop;
    tempEle = control.offsetParent;
    while (tempEle != null) {
        pos += (direct == "x") ? tempEle.offsetLeft: tempEle.offsetTop;
        tempEle = tempEle.offsetParent;
    }
    return pos;
}
function getScrollY() {
    if (window.pageYOffset != null) {
        return window.pageYOffset;
    } else {
        return document.body.scrollTop;
    }
}
function getScrollX() {
    if (window.pageXOffset != null) {
        return window.pageXOffset;
    } else {
        return document.body.scrollLeft;
    }
}
function clearAdInterval() {
    clearInterval(lastPopupId);
}
function expireTime() {
    if(whichDrag == null)
    {
        setStyleValue(currentPopup, 'visibility', 'hidden');
        clearInterval(lastPopupId);
    }
}
function showAdvertisementBanner(keyword_id,banner_id) {
	
	if(currentPopup != "")
		document.getElementById(currentPopup).style.visibility = 'hidden';
    whichDrag = null;
    var spanId = "link" + keyword_id;
    var spanControl = document.getElementById(spanId);
    clearInterval(lastPopupId);



	var divControlId = 'popup_' + spanId;
    var tmpDIV = document.getElementById(divControlId);
    if (!tmpDIV)
    {
        var width, height, type;
        if(auto_extract_keyword == false)
        {
            for(var i = 0; BannerLinked.length; i++)
            {
                if(BannerLinked[i][0] == keyword_id)
                {
                    banner_id = BannerLinked[i][1];
                    if(BannerLinked[i][2] == 'html')
                    {
//                        width = 200;
//                        height = 150;
                        width = BannerLinked[i][3];
                        height = BannerLinked[i][4];

                    }
                    else
                    {
                        width = BannerLinked[i][3];
                        height = BannerLinked[i][4];
                    }                    
                    break;
                }
            }
        }
        
        strPopupWindows = getHtmlCode("1", keyword_id, banner_id, divControlId, width, height);

        var body = document.getElementsByTagName('body');
        var divControl = document.createElement('div');
        divControl.id = divControlId;        
        divControl.style.position = 'absolute';
        divControl.style.zIndex = '500';
        divControl.style.width = 'auto';
        divControl.innerHTML = strPopupWindows;
        body[0].appendChild(divControl);

    }

	currentPopup = divControlId;

    var browserType = navigator.appName;
	switch (browserType) {
		case('Netscape'):
		    document.getElementById('tblAdvertisement_' + divControlId).style.MozOpacity = .95;
		    break;
		case ('Microsoft Internet Explorer'):
		    document.getElementById('tblAdvertisement_' + divControlId).style.filter = "alpha(opacity=95)";
		    break;
		default:
		    document.getElementById('tblAdvertisement_' + divControlId).style.opacity = 1.00;
    }

     width = getPropertyValue(divControlId, 'offsetWidth');
	 height = getPropertyValue(divControlId, 'offsetHeight');

    var linkPosX = getRealPosition(spanControl, 'x') + xOffset;
    var linkPosY = getRealPosition(spanControl, 'y') - height + yOffset;

    var tempOffset = 2;

    if ((getScrollX() + document.body.clientWidth) < (linkPosX + width)) {
        tempOffset = (linkPosX + width) - (getScrollX() + document.body.clientWidth);
        linkPosX -= tempOffset + 30;
    }

    if (getScrollY() > linkPosY) {
        var tempName = document.getElementById("link" + keyword_id);
        tempOffset = tempName.offsetHeight;
        linkPosY += height - (2 * yOffset) + tempOffset + 10;
    }

    var linkPosXString = linkPosX + "px";
    var linkPosYString = linkPosY + "px";

    setStyleValue(divControlId, 'left', linkPosXString);
    setStyleValue(divControlId, 'top', linkPosYString);

    setStyleValue(divControlId, 'visibility', 'visible');

	setObjectMovable(document.getElementById(divControlId), document.getElementById('topBorderBar_' + divControlId));

    var shadOffset = 7;
//    console.log(1 + "-" + document.getElementById('tblAdvertisement_' + divControlId).offsetHeight);
    document.getElementById('ttShadow_' + divControlId).style.width = (document.getElementById('tblAdvertisement_' + divControlId).offsetWidth + shadOffset) + 'px';
    document.getElementById('ttShadowImage_' + divControlId).style.width = (document.getElementById('tblAdvertisement_' + divControlId).offsetWidth + shadOffset) + 'px';
    document.getElementById('ttShadow_' + divControlId).style.height = (document.getElementById('tblAdvertisement_' + divControlId).offsetHeight + shadOffset) + 'px';
    document.getElementById('ttShadowImage_' + divControlId).style.height = (document.getElementById('tblAdvertisement_' + divControlId).offsetHeight + shadOffset) + 'px';

	animatePop(divControlId);
}

function getHtmlCode(type, keyword_id, banner_id, divControlId, width, height){
//    console.log(2 + "-" + height);
    var strPopupWindows = '';
    var w = parseInt(width) + 14;
    var w2 = parseInt(width) - 61;
//    var w2 = parseInt(width);
    switch (type)
        {
        case "1": // Images, Flash, Movie
/*
            strPopupWindows += '<div id="ttShadow_' + divControlId + '"style="position:absolute;z-index:-100;left:0px;top:0px;display:inline-block;width=260p;height=265px">';
            strPopupWindows += '<img id="ttShadowImage_' + divControlId + '" src="' +  server_image_location + 'images/sh_305x200.png" style="cursor:default">';
            strPopupWindows += '</div>';

            strPopupWindows += '<table id="tblAdvertisement_' + divControlId + '" width="' + w + 'px" name="tblAdvertisement" cellspacing="0" cellpadding="0" border="0" style="background:transparent;cursor:move;">';
            // First Row
            strPopupWindows += '<tr id="topBorderBar_' + divControlId + '" class="VClickTooltip" style="width:100%;height:22px">';
            // Top -Left Conner
            strPopupWindows += '<td style="background-image:url(\'' +  server_image_location + 'images/top-left-c.gif\');background-repeat:no-repeat;width:7px" ></td>';
            // Logo
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/logo.gif\');background-repeat:no-repeat;width:61px" ></td>';
            // Top-Middle
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/top-middle.gif\');background-repeat:repeat-x;width:' + w2 +'px" valign="middle">';
            strPopupWindows += '<table width="100%" border="0px" cellspacing="0" cellpadding="0">';
            strPopupWindows += '<tr>';
            strPopupWindows += '<td align="right" valign="middle">';
            strPopupWindows += '<table border="0" cellspacing="0" cellpadding="0">';
            strPopupWindows += '<tr>';
            strPopupWindows += '<td><img style="border:none;display:inline;width:2px;height:11px;" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            strPopupWindows += '<td><a href="http://vega.com.vn" target="_blank"><img id="imgAsk" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);" style="border:none;display:inline;width:11px;height:11px;" src="' +  server_location + 'images/ask_off.gif" ></a></td>';
            strPopupWindows += '<td>&nbsp;<img style="border:none;display:inline;width:2px;height:11px;" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            // Close butttom
            strPopupWindows += '<td  onClick="closeAdvertisementPopup()" style="cursor:pointer"><img id="imgClose" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);"  style="padding:0px 0px;margin:0px 0px;border:none;display:inline;width:11px;height:11px;" src="' +  server_image_location + 'images/close_off.gif" ></td>';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
            strPopupWindows += '</td>';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
            strPopupWindows += '</td>';
            // Top-Right Conner
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/top-right-c.gif\');background-repeat:no-repeat;width:7px" ></td>';
            strPopupWindows += '</tr>';
            // Second Row
            strPopupWindows += '<tr style="cursor:default;">';
            //
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/left-border.gif\');background-repeat:repeat-y;" ></td>';
            //
            strPopupWindows += '<td colspan="2"  style=";z-index:10;padding-top:4px;background:#ededed">';
            //Play QC
            if(auto_extract_keyword)
                strPopupWindows += "<iframe src='" + server_location + "auto_txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='247' height='171'><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            else
                strPopupWindows += "<iframe src='" + server_location + "txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='100%' height='" + height +"px' ><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            strPopupWindows += '</td>';
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/right-border_2.gif\');background-repeat:repeat-y;" >';
            strPopupWindows += '</td>';
            strPopupWindows += '</tr>';
            // Bottom Row
            strPopupWindows += '<tr style="height:7px;cursor:default;">';
            // Bottom-Left Conner
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/bottom-left-c.gif\');background-repeat:no-repeat;" />';
            strPopupWindows += '<td colspan="2" style="background:url(\'' +  server_image_location + 'images/bottom-middle.gif\');background-repeat:repeat-x" />';
            strPopupWindows += '<td style="background:url(\'' +  server_image_location + 'images/bottom-right-c.gif\');background-repeat:no-repeat" />';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
	
*/
/*
			case "1": // Images, Flash, Movie
			strPopupWindows += '<div id="ttShadow_' + divControlId + '"style="position:absolute;z-index:-100;left:0px;top:0px;display:inline-block;">';
            strPopupWindows += '<img id="ttShadowImage_' + divControlId + '" src="' +  server_image_location + 'images/sh_305x200.png" style="cursor:default">';
            strPopupWindows += '</div>';
            strPopupWindows += '<table class="vclick_tbl_common" id="tblAdvertisement_' + divControlId + '" width="' + w + 'px" cellspacing="0" cellpadding="0" name="tblAdvertisement" style="background:transparent;cursor:move;">';
            // First Row
            strPopupWindows += '<tr id="topBorderBar_' + divControlId + '" class="VClickTooltip" style="width:100%;height:22px">';
            // Top -Left Conner
            strPopupWindows += '<td class="vclick_td_top_left_c" ></td>';
            // Logo
            strPopupWindows += '<td class="vclick_td_logo" ></td>';
            // Top-Middle
            strPopupWindows += '<td class="vclick_td_top_middle" style="width:' + w2 +'px">';
            strPopupWindows += '<table class="vclick_table_action_button">';
            strPopupWindows += '<tr>';
            strPopupWindows += '<td class="vclick_td_common"><img class = "vclick_image_seperate" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            strPopupWindows += '<td class="vclick_td_common"><a href="http://vega.com.vn" target="_blank"><img id="imgAsk" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);" class="vclick_image_question" src="' +  server_location + 'images/ask_off.gif" ></a></td>';
            strPopupWindows += '<td class="vclick_td_common">&nbsp;<img class = "vclick_image_seperate" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            strPopupWindows += '<td class="vclick_td_common" onClick="closeAdvertisementPopup()" style="cursor:pointer"><img id="imgClose" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);"  class="vclick_image_close" src="' +  server_image_location + 'images/close_off.gif" ></td>';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
            strPopupWindows += '</td>';
            // Top-Right Conner
            strPopupWindows += '<td class="vclick_td_top_right_c"></td>';
            strPopupWindows += '</tr>';
            // Second Row
            strPopupWindows += '<tr style="cursor:default;">';
            //
            strPopupWindows += '<td class="vclick_td_left_border"></td>';
            //
            strPopupWindows += '<td class="vclick_td_center" colspan="2" >';
            //Play QC
            if(auto_extract_keyword)
                strPopupWindows += "<iframe src='" + server_location + "auto_txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='100%' height='" + height + "px'><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            else
                strPopupWindows += "<iframe src='" + server_location + "txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='100%' height='" + height + "px' ><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            strPopupWindows += '</td>';
            strPopupWindows += '<td class="vclick_td_right_border" >';
            strPopupWindows += '</td>';
            strPopupWindows += '</tr>';
            // Bottom Row
            strPopupWindows += '<tr style="height:7px;cursor:default;padding:0;">';
            // Bottom-Left Conner
            strPopupWindows += '<td class="vclick_td_bottom_left_c" />';
            strPopupWindows += '<td class="vclick_td_bottom_middle" colspan="2"  />';
            strPopupWindows += '<td class="vclick_td_bottom_right_c" />';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';

*/
            
			strPopupWindows += '<div id="ttShadow_' + divControlId + '"style="position:absolute;z-index:-100;left:0px;top:0px;display:inline-block;width=260p;height=265px">';
            strPopupWindows += '<img id="ttShadowImage_' + divControlId + '" src="' +  server_image_location + 'images/sh_305x200.png" style="cursor:default">';
            strPopupWindows += '</div>';

//            strPopupWindows += '<table class="table_reset" id="tblAdvertisement_' + divControlId + '" width="' + w + 'px" name="tblAdvertisement" cellspacing="0" cellpadding="0" border="0" style="background:transparent;cursor:move;">';
            strPopupWindows += '<table class="vclick_tbl_common" id="tblAdvertisement_' + divControlId + '" width="' + w + 'px" cellspacing="0" cellpadding="0" name="tblAdvertisement" style="background:transparent;cursor:move;">';
            // First Row
            strPopupWindows += '<tr id="topBorderBar_' + divControlId + '" class="VClickTooltip" style="width:100%;height:22px">';
            // Top -Left Conner
//            strPopupWindows += '<td class="td_reset" style="background-image:url(\'' +  server_image_location + 'images/top-left-c.gif\');background-repeat:no-repeat;width:7px" ></td>';
            strPopupWindows += '<td class="vclick_td_top_left_c" ></td>';
            // Logo
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/logo.gif\');background-repeat:no-repeat;width:61px" ></td>';
            // Top-Middle
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/top-middle.gif\');background-repeat:repeat-x;width:' + w2 +'px" valign="middle">';
			strPopupWindows += '<td class="vclick_td_logo" ></td>';
            // Top-Middle
            strPopupWindows += '<td class="vclick_td_top_middle" style="width:' + w2 +'px">';

//            strPopupWindows += '<table class="table_reset" align="right" border="0px" cellspacing="0" cellpadding="0">';
            strPopupWindows += '<table class="vclick_table_action_button">';
            strPopupWindows += '<tr>';

//            strPopupWindows += '<td  class="td_reset" align="right" valign="middle">';
//            strPopupWindows += '<table class="table_reset"  style="width: auto;" border="0" cellspacing="0" cellpadding="0" align="right">';
//            strPopupWindows += '<tr>';
//            strPopupWindows += '<td class="td_reset"><img style="border:none;display:inline;width:2px;height:11px;" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
//            strPopupWindows += '<td class="td_reset"><a href="http://vega.com.vn" target="_blank"><img id="imgAsk" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);" style="border:none;display:inline;width:11px;height:11px;" src="' +  server_location + 'images/ask_off.gif" ></a></td>';
//            strPopupWindows += '<td class="td_reset">&nbsp;<img style="border:none;display:inline;width:2px;height:11px;" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            // Close butttom
//            strPopupWindows += '<td class="td_reset" onClick="closeAdvertisementPopup()" style="cursor:pointer"><img id="imgClose" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);"  style="padding:0px 0px;margin:0px 0px;border:none;display:inline;width:11px;height:11px;" src="' +  server_image_location + 'images/close_off.gif" ></td>';


            strPopupWindows += '<td class="vclick_td_common"><img class = "vclick_image_seperate" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            strPopupWindows += '<td class="vclick_td_common"><a href="http://ads.vclick.vn:8080/vclick/public/index.php" target="_blank"><img id="imgAsk" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);" class="vclick_image_question" src="' +  server_location + 'images/ask_off.gif" ></a></td>';
            strPopupWindows += '<td class="vclick_td_common">&nbsp;<img class = "vclick_image_seperate" src="' +  server_location + 'images/saperate2.gif" >&nbsp;</td>';
            strPopupWindows += '<td class="vclick_td_common" onClick="closeAdvertisementPopup()" style="cursor:pointer"><img id="imgClose" onMouseOver="ChangeImage(this,1);" onMouseOut="ChangeImage(this,0);"  class="vclick_image_close" src="' +  server_image_location + 'images/close_off.gif" ></td>';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
//            strPopupWindows += '</td>';
//            strPopupWindows += '</tr>';
//            strPopupWindows += '</table>';
            strPopupWindows += '</td>';
            // Top-Right Conner
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/top-right-c.gif\');background-repeat:no-repeat;width:7px" ></td>';
            strPopupWindows += '<td class="vclick_td_top_right_c"></td>';
            strPopupWindows += '</tr>';
            // Second Row
            strPopupWindows += '<tr style="cursor:default;">';
            //
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/left-border.gif\');background-repeat:repeat-y;" ></td>';
            //
//            strPopupWindows += '<td class="td_reset" class="td_reset" colspan="2"  style=";z-index:10;padding-top:4px;background:#ededed">';

            strPopupWindows += '<td class="vclick_td_left_border"/>';
            //
            strPopupWindows += '<td class="vclick_td_center" colspan="2" >';
            //Play QC
            if(auto_extract_keyword)
                strPopupWindows += "<iframe src='" + server_location + "auto_txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='100%' height='" + height + "px'><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            else
                strPopupWindows += "<iframe src='" + server_location + "txtafr.php?keywordid=" + keyword_id + "&bannerid=" + banner_id + "' framespacing='0' frameborder='no' scrolling='no' width='" + width + "' height='" + height + "px' ><a href='" + server_location + "ck.php?n=a6fc1541&amp;cb=INSERT_RANDOM_NUMBER_HERE' target='_blank'><img src='" + server_location + "avw.php?zoneid=" + keyword_id + "&amp;cb=INSERT_RANDOM_NUMBER_HERE&amp;n=a6fc1541' border='0' alt='' /></a></iframe>";
            strPopupWindows += '</td>';
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/right-border_2.gif\');background-repeat:repeat-y;" >';
            strPopupWindows += '<td class="vclick_td_right_border" >';
            strPopupWindows += '</td>';
            strPopupWindows += '</tr>';
            // Bottom Row
            strPopupWindows += '<tr style="height:7px;cursor:default;">';
            // Bottom-Left Conner
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/bottom-left-c.gif\');background-repeat:no-repeat;" />';
//            strPopupWindows += '<td class="td_reset" colspan="2" style="background:url(\'' +  server_image_location + 'images/bottom-middle.gif\');background-repeat:repeat-x" />';
//            strPopupWindows += '<td class="td_reset" style="background:url(\'' +  server_image_location + 'images/bottom-right-c.gif\');background-repeat:no-repeat" />';
            strPopupWindows += '<td class="vclick_td_bottom_left_c" />';
            strPopupWindows += '<td class="vclick_td_bottom_middle" colspan="2"  />';
            strPopupWindows += '<td class="vclick_td_bottom_right_c" />';
            strPopupWindows += '</tr>';
            strPopupWindows += '</table>';
			
    }
    return strPopupWindows;
}

function decorate()
{
    
}
function animatePop(divControlId) {
    enhance(divControlId, document.getElementById(divControlId).offsetLeft, document.getElementById(divControlId).offsetLeft - 5, document.getElementById(divControlId).offsetTop, document.getElementById(divControlId).offsetTop - 5, .2);
}
function enhance(objectName, startX, endX, startY, endY, slideTime) {

    var objectRef = document.getElementById(objectName);

    if (typeof objectRef.slideID == "number") clearInterval(objectRef.slideID);
    var time = slideTime * 1000;
    var steps = 30 * slideTime;
    var slideXArray = new Array();
    var slideYArray = new Array();
    var slideDeltaX = (endX - startX) / steps;
    var slideDeltaY = (endY - startY) / steps;
    for (x = 0; x <= steps; x++) {
        slideXArray.push(Math.round(startX + (x * slideDeltaX)));
        slideYArray.push(Math.round(startY + (x * slideDeltaY)));
    }
    objectRef.slideStep = 0;
    objectRef.nameString = objectName;
    var slideInterval = time / steps;
    objectRef.slideID = setInterval(slideFunction, slideInterval);
    var selfReference = objectRef;
    function slideFunction() {
        selfReference.slideStep++;
        if (selfReference.slideStep <= steps) {
            var tempX = slideXArray[selfReference.slideStep] + "px";
            var tempY = slideYArray[selfReference.slideStep] + "px";
            setStyleValue(selfReference.nameString, 'left', tempX);
            setStyleValue(selfReference.nameString, 'top', tempY);
        } else {
            var tempX = endX + "px";
            var tempY = endY + "px";
            setStyleValue(selfReference.nameString, 'left', tempX);
            setStyleValue(selfReference.nameString, 'top', tempY);
            clearInterval(selfReference.slideID);
        }
    }
}
function hideAdvertisementBanner() {
    if (whichDrag == null) {
		lastPopupId = setInterval(expireTime, 1250);
    }

}
function closeAdvertisementPopup() {
    setStyleValue(currentPopup, 'visibility', 'hidden');
    clearInterval(lastPopupId);
}
function mouseDown() {
    mouseIsDown = true;    
}
function mouseUp() {
    mouseIsDown = false;
    dragObject = null;
}
function mouseMove(ev) {
    ev = ev || window.event;
    if (mouseIsDown) {
        if (dragObject) {
            var mousePos = mouseCoords(ev);
            whichDrag = dragObject;
            dragObject.style.position = 'absolute';
            var top = mousePos.y - mouseOffset.y + "px";
            var left= mousePos.x - mouseOffset.x + "px";
			dragObject.style.left = left;
			dragObject.style.top = top;
        }
    }
}
function getMouseOffset(target, ev) {
    ev = ev || window.event;
    var docPos = getPosition(target);
    var mousePos = mouseCoords(ev);
    return {
        x: mousePos.x - docPos.x,
        y: mousePos.y - docPos.y
    };
}
function getPosition(e) {
    var left = 0;
    var top = 0;
    while (e.offsetParent) {
        left += e.offsetLeft;
        top += e.offsetTop;
        e = e.offsetParent;
    }
    left += e.offsetLeft;
    top += e.offsetTop;
    return {
        x: left,
        y: top
    };
}
function mouseCoords(ev) {
    if (ev.pageX || ev.pageY) {
        return {
            x: ev.pageX,
            y: ev.pageY
        };
    }
    return {
        x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
        y: ev.clientY + document.body.scrollTop - document.body.clientTop
    };
}
function setObjectMovable(item, handle) {
    if (!item) return;
    handle.onmousedown = function(ev) {
        dragObject = item;
        mouseOffset = getMouseOffset(dragObject, ev);
    }
}
function ChangeImage(o, on) {
    var s = o.src;
    o.src = (on) ? s.replace('_off', '_on') : s.replace('_on', '_off');
}

document.onmousemove = mouseMove;
document.onmouseup = mouseUp;
document.onmousedown = mouseDown;

traverseDomTree();

// Preload images

//var images = Array();
//
//var imgT_L = new Image();
//var imgT_M = new Image();
//var imgT_R = new Image();
//var imgL = new Image();
//var imgT_R = new Image();
//img.src = '';
