<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="/">
		<xsl:for-each select="SINHVIEN">
			<xsl:variable name="name">
				<xsl:value-of select="NAME"/>
			</xsl:variable>
			<xsl:value-of select="$name"/>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
