<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="PLANETS">
		<html>
			<xsl:apply-templates/>
		</html>
	</xsl:template>
	<xsl:template match="PLANET[AB='5']">
		<p>
			<h1>
				<xsl:apply-templates/>
			</h1>
		</p>
	</xsl:template>
</xsl:stylesheet>