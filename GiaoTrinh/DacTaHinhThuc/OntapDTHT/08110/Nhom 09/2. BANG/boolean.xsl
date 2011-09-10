<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<xsl:apply-templates/>
		</html>
	</xsl:template>
	<xsl:template match="PLANETS">		
		<xsl:apply-templates/>		
	</xsl:template>
	<xsl:template match="PLANET">
		<p>
			<xsl:value-of select="NAME"/>
		</p>
	</xsl:template>
<xsl:template match=”ATOMIC_NUMBER[position()=1 or position()=last()]”>
	<xsl:value-of select=”.”/>
</xsl:template>

	</xsl:template>
</xsl:stylesheet>
