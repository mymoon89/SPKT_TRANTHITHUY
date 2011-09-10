<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="BBB">
		<P><xsl:text> BBB[</xsl:text>
		<xsl:value-of select="position()"/>
		<xsl:text>]: </xsl:text>
		<xsl:value-of select="."/></P>
	</xsl:template>
</xsl:stylesheet>
