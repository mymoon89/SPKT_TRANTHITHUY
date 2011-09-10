<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="/">
	<html>
		<head>
			<title>The Planets Table</title>
		</head>
		<body>
			<h1>
			The Planet Table
			</h1>
			<table>
				<td>Name</td>
				<td>Mass</td>
				<td>Radius</td>
				<td>Day</td>
				<xsl:apply-templates/>
			</table>		
		</body>
	</html>
</xsl:template>
<xsl:template match="PLANETS">
	<xsl:apply-templates/>
</xsl:template>
<xsl:template match="PLANET">
	<tr>
		<td><xsl:value-of select="NAME"/></td>
		<td><xsl:apply-templates select="MASS"/></td>
		<td><xsl:apply-templates select="RADIUS"/></td>
	</tr>
</xsl:template>
<xsl:template match="MASS">
	<xsl:value-of select="."/>
	<xsl:value-of select="@UNITS"/>
</xsl:template>
<xsl:template match="RADIUS">
	<xsl:value-of select="."/>
	<xsl:value-of select="@UNITS"/>
</xsl:template>
<xsl:template match="DAY">
	<xsl:value-of select="."/>
	<xsl:value-of select="@UNITS"/>
</xsl:template>
</xsl:stylesheet>
