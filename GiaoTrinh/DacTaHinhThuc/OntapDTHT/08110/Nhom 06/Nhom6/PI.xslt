<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<table border=" 2">
							<xsl:apply-templates select="//row"/>
				</table>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="//thead">
	<tr>
	<xsl:attribute name="bordercolor">
	<xsl:value-of select="processing-instruction('bordercolor')"></xsl:value-of>
	</xsl:attribute>
	<xsl:attribute name="bgcolor">
	<xsl:value-of select="processing-instruction('bgcolor')"></xsl:value-of>
	</xsl:attribute>
	</tr>
	</xsl:template>
	<xsl:template match="//row">
	<tr>
	<xsl:attribute name="bordercolor">
	<xsl:value-of select="processing-instruction('bordercolor')"></xsl:value-of>
	</xsl:attribute>
	<xsl:attribute name="bgcolor">
	<xsl:value-of select="processing-instruction('bgcolor')"></xsl:value-of>
	</xsl:attribute>	
	<xsl:for-each select="entry">
	<td>
	<xsl:value-of select="."></xsl:value-of>
	</td>
	</xsl:for-each>
	</tr>
	</xsl:template>
</xsl:stylesheet>
