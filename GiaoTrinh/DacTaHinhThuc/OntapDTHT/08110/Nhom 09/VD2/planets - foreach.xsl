<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="/">
	<HTML>
		<xsl:apply-templates/>
	</HTML>
</xsl:template>
<xsl:template match="PLANETS">
	<xsl:apply-templates/>
</xsl:template>
<xsl:template match="PLANET">
	<xsl:for-each select="NAME">
		<p>
			<xsl:value-of select="."/>
		</p>
	</xsl:for-each>

</xsl:template>

</xsl:stylesheet>

