<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="PLANETS">
		<html>
			<xsl:apply-templates/>
		</html>
	</xsl:template>
	<xsl:template match="PLANET">
		<p>
			<xsl:apply-templates/>
		</p>
	</xsl:template>
	<xsl:template match="NAME | MASS">
		<p>
			<b>
				<xsl:apply-templates/>
			</b>
		</p>
	</xsl:template>
</xsl:stylesheet>
