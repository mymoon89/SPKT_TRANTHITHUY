<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="/">
		<xsl:for-each select="PLANETS/PLANET">
			<xsl:choose>
				<xsl:when test="@COLOR='RED' ">
					<b>
						<xsl:value-of select="NAME"/>
					</b>
				</xsl:when>
				<xsl:when test="@COLOR='WHILE' ">
					<i>
						<xsl:value-of select="NAME"/>
					</i>
				</xsl:when>
				<xsl:when test="@COLOR='BLUE' ">
					<u>
						<xsl:value-of select="NAME"/>
					</u>
				</xsl:when>
				<xsl:otherwise>
					<pre>
						<xsl:value-of select="."/>
					</pre>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
