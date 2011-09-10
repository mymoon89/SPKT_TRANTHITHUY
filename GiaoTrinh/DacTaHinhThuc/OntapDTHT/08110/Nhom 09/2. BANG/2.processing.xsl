<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/processing-instruction('xml-stylesheet')">
		<p>
			<i>
				<xsl:value-of select="."/>
			</i>
		</p>
	</xsl:template>
</xsl:stylesheet>
