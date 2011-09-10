function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location);

	menu = new Menu();

// Comment, do not delete
// Main Menus
	menu.addItem("programmingid", "Th&#7843;o Ch&#432;&#417;ng", "Programming in Vovisoft", null, null);
//	menu.addItem("tutorialid", "T&#7921; H&#7885;c VB", "Programming Tutorials",null, null);
	menu.addItem("classid", "L&#7899;p H&#7885;c tr&#432;&#7899;c", "Classes organised by Vovisoft", null, null);
	menu.addItem("courseid", "Khoá H&#7885;c Vovisoft", "Courses run by Vovisoft", null, null);
	menu.addItem("newsletterid", "Lá Th&#432; Tin T&#7913;c", "News Letters", null, null);
	menu.addItem("vovimailid", "Di&#7877;n Ðàn Thông Tin", "Vovisoft Communication Forums", null, null);
	menu.addItem("vovilinksid", "Vovi Links", "Links to other Vovi sites", null, null);
	menu.addItem("homeid", "Languages", "Vovisoft Language Site", null, null);
//	menu.addItem("homeid", "English", "Vovisoft English Site", "http://www.vovisoft.com/vovisofteng/default.htm", null);

// Sub Menus
// Vovisoft programming projects
	menu.addSubItem("programmingid", "Vi&#7871;t ASP", "Active Server Page",  "http://www.vovisoft.com/asp/");
//	menu.addSubItem("programmingid", "FrontPage 2000", "FrontPage 2000",  "http://www.vovisoft.com/fp2000");
//	menu.addSubItem("programmingid", "Vi&#7871;t DHTML", "Dynamic HTML",  "http://www.vovisoft.com/dhtml/");
	menu.addSubItem("programmingid", "Vi&#7871;t JavaScript", "Javascript",  "http://www.vovisoft.com/javascript/");
//	menu.addSubItem("programmingid", "Hi&#7879;n T&#432;&#7907;ng Java", "Introduction to Java",  "http://www.vovisoft.com/vovisoft/HienTuongJava.htm");
	menu.addSubItem("programmingid", "Viet VB.NET", "Introduction to Java",  "http://www.vovisoft.com/dotNet/default.asp");
	menu.addSubItem("programmingid", "Vi&#7871;t Java", "Java",  "http://www.vovisoft.com/java/");
	menu.addSubItem("programmingid", "Vi&#7871;t CGI-Perl", "CGI-Perl",  "http://www.vovisoft.com/perlcgi/");
//	menu.addSubItem("programmingid", "Vi&#7871;t VbScript", "VbScript",  "http://www.vovisoft.com/vbscript/");
//	menu.addSubItem("programmingid", "Visual Basic 6", "Visual Basic 6",  "http://www.vovisoft.com/vb6/");
	menu.addSubItem("programmingid", "Unicode", "Unicode",  "http://www.vovisoft.com/unicode/default.htm");
	menu.addSubItem("programmingid", "Vi&#7871;t XML", "Extensibale Markup Language",  "http://www.vovisoft.com/xml/");

// Vovisoft Tutorials
//	menu.addSubItem("tutorialid", "Visual Basic", "Introduction to Visual Basic", "http://www.vovisoft.com/vovisoft/tutorials/tutorial1/tutorial1.htm");
//	menu.addSubItem("tutorialid", "VB S&#417; C&#7845;p", "Visual Basic for Begnners", "http://www.vovisoft.com/vovisoft/tutorial.htm");
//	menu.addSubItem("tutorialid", "VB Bách Khoa", "Mastering Visual Basic", "http://www.vovisoft.com/vovisoft/tutorials/vb6course/toc.htm");
//	menu.addSubItem("tutorialid", "M&#7865;o v&#7863;t VB", "Visual Basic Tips and Tricks", "http://www.vovisoft.com/vovisoft/tipstricks/forms.htm");
//	menu.addSubItem("tutorialid", "Th&#7855;c M&#7855;c VB", "Visual Basic Frequently Asked Questions", "http://www.vovisoft.com/vovisoft/faqs/vbfaqs.htm");
//	menu.addSubItem("tutorialid", "Mã L&#7853;p Trình VB", "Visual Basic Codes", "http://www.vovisoft.com/vovisoft/sources/code1/code1.htm");

// Vovisoft classes
	menu.addSubItem("classid", "Các Khóa H&#7885;c", "All Classes", "http://www.vovisoft.com/vovisoft/classes.htm");
	menu.addSubItem("classid", "Khóa H&#7885;c 1998a", "Class 1998", "http://www.vovisoft.com/vovisoft/classes/class3.htm");
	menu.addSubItem("classid", "Khóa H&#7885;c 1998b", "Class 1998 X'mas", "http://www.vovisoft.com/vovisoft/classes/visual_basic_class.htm");
	menu.addSubItem("classid", "Khóa H&#7885;c 1999", "Class 1999 X'mas", "http://www.vovisoft.com/vovisoft/classes/class99.htm");
//	menu.addSubItem("classid", "Khóa H&#7885;c 2000", "Class 2000", "http://www.vovisoft.com/");

// 5 Regular Courses 
	menu.addSubItem("courseid", "English", "English", "http://www.vovisoft.com/english/default.htm");
	menu.addSubItem("courseid", "MCSE", "Microsoft Certified System Engineer",  "http://www.vovisoft.com/mcse/default.htm");
	menu.addSubItem("courseid", "Ms Office", "Ms Office 2000", "http://www.vovisoft.com/office2k/default.htm");
	menu.addSubItem("courseid", "Visual Basic 6", "Ms Visual Basic 6", "http://www.vovisoft.com/visualbasic/default.htm");
	menu.addSubItem("courseid", ".NET", ".Net Web Development", "http://www.vovisoft.com/dotNet/default.asp");
	menu.addSubItem("courseid", "Th&#7901;i Khóa Bi&#7875;u", "Classes Time Table", "http://www.vovisoft.com/vovisoft/classes/classtimetable1.htm");

// Vovisoft News Letters
	menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 1", "News Letter #1", "http://www.vovisoft.com/newsletters/news1.html");
	menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 2", "News Letter #2", "http://www.vovisoft.com/newsletters/news2.html");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 3", "News Letter #3", "http://www.vovisoft.com/newsletters/news3/news3.html");
	menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 4", "News Letter #4", "http://www.vovisoft.com/newsletters/news4/news4a.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 5", "News Letter #5", "http://www.vovisoft.com/newsletters/news5/news5.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 6", "News Letter #6", "http://www.vovisoft.com/newsletters/news6/news6a.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 7", "News Letter #7", "http://www.vovisoft.com/newsletters/news7/voviletter7.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 8", "News Letter #8", "http://www.vovisoft.com/newsletters/news8/voviletter8.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 9", "News Letter #9", "http://www.vovisoft.com/newsletters/news9/voviletter9.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 10", "News Letter #10", "http://www.vovisoft.com/newsletters/news10/voviletter10.htm");
   menu.addSubItem("newsletterid", "Lá Th&#432; s&#7889; 11", "News Letter #11", "http://www.vovisoft.com/newsletters/news11/voviletter11.htm");

// Vovisoft Photos
	menu.addSubItem("vovimailid", "Vovisoft là nhóm nào?", "Who are we?", "http://www.vovisoft.com/vovisoft/whoarewe.htm");
	menu.addSubItem("vovimailid", "B&#7843;n Tin Vovisoft", "Vovisoft Bulletin Board", "http://www.vovisoft.com/bulletin/default.asp");
	menu.addSubItem("vovimailid", "Di&#7877;n Ðàn Vovisoft", "Vovisoft Forums", "http://www.vovisoft.com/forums2001/default.asp");
	menu.addSubItem("vovimailid", "Ði&#7879;n th&#432; VoviMail", "VoviMail", "http://www.vovisoft.com/VoviMail/default.asp");
	menu.addSubItem("vovimailid", "Hình &#7842;nh 1999", "Photos 1999", "http://www.vovisoft.com/vovisoft/photos/photo99/");
//	menu.addSubItem("vovimailid", "Hình &#7842;nh 2000", "Photos 2000", "http://www.vovisoft.com/");

// Vovi Links
	menu.addSubItem("vovilinksid", "VoviLearned", "VoviLearned", "http://www.vovisoft.com/vovilearned/");
	menu.addSubItem("vovilinksid", "VoviKungFu", "VoviKungFu", "http://www.vovisoft.com/vovikungfu/");
	menu.addSubItem("vovilinksid", "Nam Chi", "Learning Vietnamese", "http://www.vovisoft.com/vovilearned/namchi/");
	menu.addSubItem("vovilinksid", "VoviTech", "VoviTech", "http://www.vovisoft.com/vovilearned/vovitech/");
	menu.addSubItem("vovilinksid", "V&#259;n H&#7885;c Vi&#7879;t Nam", "Vietnamese Literature", "http://www.vovisoft.com/vovilearned/vanhoc/");
	menu.addSubItem("vovilinksid", "Vovi Care", "Vovi Care for the Miserables", "http://www.vovisoft.com/vovicare/index.htm");
	menu.addSubItem("vovilinksid", "T&#7921; Xoa Bóp", "Health Massage", "http://www.vovisoft.com/tuxoabop.htm");
// Languages used 
//	menu.addSubItem("homeid", "English", "Vovisoft English Site", "http://www.vovisoft.com/vovisofteng/");
	menu.addSubItem("homeid", "Vi&#7879;t Ng&#7919;", "Vovisoft Vietnamese Site", "http://www.vovisoft.com/");
	menu.addSubItem("homeid", "English", "Vovisoft English Site", "http://www.vovisoft.com/vovisofteng/");

	menu.showMenu();
}