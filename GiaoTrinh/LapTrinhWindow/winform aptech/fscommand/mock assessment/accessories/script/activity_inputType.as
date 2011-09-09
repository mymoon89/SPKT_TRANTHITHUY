stop();
var nAttempt = 0;
var count = 0;
var sType;
var counter;
var scount = 0;
var correct_Array;
var correctCount = 0;
var incorrectCount = 0;
var questionText = new Array();
var correctFeedback = new Array();
var incorrectFeedback = new Array();
var correctAns = new Array();
var options = new Array();
var score_array = new Array();
var userArray = new Array(0);
var questionOption = new Array(0);
var sdata;
var sresult = new Array();
var xPos;
var yPos;
close_btn.enabled = 0;
close_btn._alpha = 30;
tick_mc._visible = 0;
submit_btn.enabled = 0;
submit_btn._alpha = 50;
view_btn.enabled = 0;
view_btn._alpha = 50;
xPos = submit_btn._x;
yPos = submit_btn._y;
_level0.emptyHolder_mc.slide_mc.score_mc._visible = true;
_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = "0";
_level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text = "0";
//-- this is for th bookmarking of the score
bookmark = SharedObject.getLocal("Bookmark", "/");
trace("drop down code ============================================ is called herer");
if (bookmark.getSize() == 0) {
	trace("first Time");
	rightScore = new Array();
	bookmark.data.rightCount = rightScore;
	_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = "0";
	bookmark.data.rightCount = _level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text;
	wrongScore = new Array();
	bookmark.data.wrongCount = wrongScore;
	_level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text = "0";
	bookmark.data.wrongCount = _level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text;
	bookmark.flush(500);
} else {
	trace("visited Time "+bookmark.data.wrongCount);
	rightScore = bookmark.data.rightCount;
	wrongScore = bookmark.data.wrongCount;
	if (bookmark.data.rightCount != undefined) {
		_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = bookmark.data.rightCount;
	} else {
		_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = "0";
	}
	if (bookmark.data.wrongCount != undefined) {
		trace("wrong book count is not undefined == "+wrongScore);
		_level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text = bookmark.data.wrongCount;
	} else {
		trace("wrong book count is  undefined");
		_level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text = "0";
	}
	//_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = "0";
	//_level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text = "0";
}
// -- this is for the storing of values
/*function loadXML() {
	myData = new XML();
	myData.ignoreWhite = true;
	myData.load("cm_c01_t01/textdata/MCSS.xml");
	myData.onLoad = fnParseAssessment;
	delete loadXML;
}*/
// -- this is for the storing of values
function fnParseAssessment() {
	//trace("fnParseAssessment == ");
	glnFirstChild = myData.childNodes[0].childNodes;
	//trace(glnFirstChild+" the gchildNodes");
	for (var i = 0; i<glnFirstChild.length; i++) {
		questionText[i] = glnFirstChild[i].childNodes[0].firstChild.nodeValue;
		//trace(questionText[i]);
		question_txt.html=true;
		question_txt.htmlText = questionText[i];
		//correct_Array[i] = new Array();
		correct_Array = glnFirstChild[i].childNodes[4].firstChild.nodeValue;
		sdata = correctAns[i];
		correctAnswer_mc.option0_txt.text = correct_Array;
		for (j=0; j<sdata.length; j++) {
			sresult[j] = sdata[j];
		}
		//trace(glnFirstChild[i].childNodes[4].firstChild.nodeValue+"is the value");
		correctFeedback[i] = glnFirstChild[i].childNodes[5].firstChild.nodeValue;
		incorrectFeedback[i] = glnFirstChild[i].childNodes[6].firstChild.nodeValue;
		sType = glnFirstChild[i].childNodes[2].firstChild.nodeValue;
		options[i] = new Array();
		count = glnFirstChild[i].childNodes[1].childNodes.length;
		//trace(incorrectFeedback);
		for (var j = 0; j<glnFirstChild[i].childNodes[1].childNodes.length; j++) {
			options[i][j] = glnFirstChild[i].childNodes[1].childNodes[j].firstChild.nodeValue;
			questionOption.push(options[i][j]);
			//trace(options[i][j]);
			eval("option"+(j)+"_mc")._visible = 1;
			eval("option"+(j)+"_mc.option"+(j)+"_txt").text = "";
			eval("option"+(j)+"_mc.option"+(j)+"_txt").setFocus();
		}
	}
	handcursor(sType);
	//delete glnFirstChild;
	//delete myData;
	//delete fnParseAssessment;
}
//--------------------------------------------------------------------------------
loadXML();
submit_btn.enabled = 0;
submit_btn._alpha = 50;
function handcursor(svalue) {
	for (i=0; i<=10; i++) {
		//trace("option"+i+"_mc.radio_opt"+i);onChanged 
		eval("option"+(i)+"_mc.radio_opt"+(i+1)).useHandCursor = true;
		eval("option"+(i)+"_mc.radio_opt"+(i+1))._visible = true;
		eval("option"+(i)+"_mc.radio_opt"+(i+1)).selected = false;
		//trace(eval("option"+(i+1)+"_mc.check_opt"+(i+1)));
	}
}
function validate() {
	_level0.emptyHolder_mc.MCQ_fnShowNext();
	option0_mc.option0_txt.enabled = false;
	option0_mc.option0_txt.selectable = false;
	submit_btn.enabled = false;
	submit_btn._alpha = 50;
	// this is for the Multiple choce multiple select quiz 
trace(correct_Array);
	if (String(option0_mc.option0_txt.text) == String(correct_Array)) {
		feedback_mc._visible = 1;
		feedback_mc.gotoAndStop(1);
		feedback_mc.feedback_txt.html = true;
		feedback_mc.feedback_txt.htmlText = correctFeedback;
		correctCount++;
		rightCount.text = "0"+correctCount;
		submit_btn.enabled = false;
		submit_btn._alpha = 50;
		// this is where the score gets updated
			var temp = _level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text;
			_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = Number(temp)+Number(correctCount);
			rightScore = _level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text;
			wrongScore = _level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text;
			bookmark.data.rightCount = rightScore;
			bookmark.data.wrongCount = wrongScore;
	} else {
		feedback_mc._visible = 1;
		feedback_mc.gotoAndStop(1);
		feedback_mc.feedback_txt.html = true;
		feedback_mc.feedback_txt.htmlText = incorrectFeedback;
		view_btn.enabled = true;
		view_btn._alpha = 100;
		correctCount++;
		// this is where the score gets updated
			var temp = _level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text;
			_level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text = Number(temp)+Number(correctCount);
			rightScore = _level0.emptyHolder_mc.slide_mc.score_mc.rightCount.text;
			wrongScore = _level0.emptyHolder_mc.slide_mc.score_mc.wrongCount.text;
			bookmark.data.rightCount = rightScore;
			bookmark.data.wrongCount = wrongScore;
	}
	for (i=1; i<=count; i++) {
		eval("ans"+i)._visible = 1;
		eval("ans"+i).gotoAndStop("neg");
		//eval("option"+sresult[i]+"_mc.dis_mc").gotoAndStop(2);
	}
	//trace(sresult.sort());
	for (i=0; i<=count; i++) {
		eval("ans"+i)._visible = 1;
		eval("ans"+sresult[i]).gotoAndStop(1);
	}
	close_btn.enabled = 1;
	close_btn._alpha = 100;
	disable(sType);
	//unloadMovieNum(5);
}
view_btn.onRelease = function() {
		view_btn.enabled = 0;
		view_btn._alpha = 50;
		displayAnswer();
	};
function disable(svalue) {
	for (i=0; i<=count; i++) {
		//trace("option"+i+"_mc.radio_opt"+i);
		eval("option"+(i)+"_mc.radio_opt"+(i+1)).useHandCursor = false;
		eval("option"+(i)+"_mc.radio_opt"+(i+1)).enabled = false;
	}
}
function displayAnswer() {
	correctAnswer_mc._visible = true;
	correctAnswer_mc.option0_txt.selectable = false;
	}
submit_btn.onRelease = function() {
	this._parent.MCQ_fnShowNext();
	validate();
};
