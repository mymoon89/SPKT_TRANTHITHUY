<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns="http://www.w3.org/TR/REC-html40"
  >

  <xsl:output indent="yes" encoding="iso-8859-1" method="html"
      doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN"/>

  <xsl:template match="hello">
    <xsl:text>Hello, </xsl:text>
    <xsl:apply-templates/>
  </xsl:template>

  <xsl:template match="/">
	<html><head><title>Example</title></head><body>
    <xsl:apply-templates/>
	</body></html>
  </xsl:template>

</xsl:stylesheet>
