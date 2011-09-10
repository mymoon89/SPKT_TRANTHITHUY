import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;
import org.xml.sax.*;
import com.jclark.xsl.sax.*;
import java.net.URL;
import java.util.Enumeration;


/*
 * Adapted by Edd Dumbill <edd@usefulinc.com> from original source by
 * James Clark <jjc@jclark.com> to work with the 2.0 servlet API as well
 * as the 2.1 API.  We lose a small bit of niceness with the handling of
 * the stylesheet filename in the process. For the purposes of this
 * demonstration it needs to be an absolute path.
 *
 * portions copyright (c) 1999 Edd Dumbill. See copying.txt
 * portions copyright (c) 1998,1999 James Clark. See copying.jclark.txt
 * 
 */

public class XSLServlet extends HttpServlet { 
	private XSLProcessor cached;
	
	public void init(ServletConfig config) throws ServletException {
		super.init(config);
		String stylesheet = getInitParameter("stylesheet"); 

		if (stylesheet == null)
			throw new ServletException("missing stylesheet parameter");
		cached = new XSLProcessorImpl();
		cached.setParser(createParser());
		try {
			cached.loadStylesheet(fileInputSource(new File(stylesheet)));
		}
		catch (SAXException e) {
			throw new ServletException(e.toString());
		}
		catch (IOException e) {
			throw new ServletException(e.toString());
		}
		log("init done");
	}

	public void doGet(HttpServletRequest request, HttpServletResponse response)
		throws ServletException, IOException {
		
		File inputFile = new File(request.getPathTranslated());
		if (!inputFile.isFile()) {
			inputFile = new File(request.getPathTranslated() + ".xml");
			if (!inputFile.isFile()) {
				// Final check for index.xml being a 'welcome' page if
				// nothing else works: added by ED. Really this ought to
				// be a nice bit of code that gets acceptable prefixes
				// from the initargs and checks to see if any of them
				// exist.
				inputFile = new File(request.getPathTranslated() + 
									 "index.xml");
				if (!inputFile.isFile()) {
					response.sendError(HttpServletResponse.SC_NOT_FOUND,
									   "File not found: " + 
									   request.getPathTranslated());
					return;
				}
			}
		}
		
		XSLProcessor xsl = (XSLProcessor)cached.clone();
		xsl.setParser(createParser());
		for (Enumeration e = request.getParameterNames(); 
			 e.hasMoreElements();) {
			String name = (String)e.nextElement();
			// What to do about multiple values?
			xsl.setParameter(name, request.getParameter(name));
		}
		OutputMethodHandlerImpl outputMethodHandler = 
			new OutputMethodHandlerImpl(xsl);
		xsl.setOutputMethodHandler(outputMethodHandler);
		outputMethodHandler.setDestination(new ServletDestination(response));
		try {
			xsl.parse(fileInputSource(inputFile));
		}
		catch (SAXException e) {
			throw new ServletException(e.toString());
		}
	}

	static Parser createParser() throws ServletException {
		String parserClass = System.getProperty("com.jclark.xsl.sax.parser");
		if (parserClass == null)
			parserClass = System.getProperty("org.xml.sax.parser");
		if (parserClass == null)
			parserClass = "com.jclark.xml.sax.CommentDriver";
		try {
			return (Parser)Class.forName(parserClass).newInstance();
		}
		catch (ClassNotFoundException e) {
			throw new ServletException(e.toString());
		}
		catch (InstantiationException e) {
			throw new ServletException(e.toString());
		}
		catch (IllegalAccessException e) {
			throw new ServletException(e.toString());
		}
		catch (ClassCastException e) {
			throw new ServletException(parserClass + " is not a SAX driver");
		}
	}
	
	/**
	 * Generates an <code>InputSource</code> from a file name.
	 */
	static public InputSource fileInputSource(File file) {
		String path = file.getAbsolutePath();
		String fSep = System.getProperty("file.separator");
		if (fSep != null && fSep.length() == 1)
			path = path.replace(fSep.charAt(0), '/');
		if (path.length() > 0 && path.charAt(0) != '/')
			path = '/' + path;
		try {
			return new InputSource(new URL("file", "", path).toString());
		}
		catch (java.net.MalformedURLException e) {
			/* According to the spec this could only happen if the file
			   protocol were not recognized. */
			throw new Error("unexpected MalformedURLException");
		}
	}
}

