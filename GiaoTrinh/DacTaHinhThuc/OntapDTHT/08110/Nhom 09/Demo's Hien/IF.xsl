<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="/">
<xsl:for-each select="PLANETS/PLANET">
<p>
<xsl:value-of select="NAME"/> is planet number<xsl:value-of select="position()"/> from the sun.
</p>
<xsl:if test="position()=last()">
<xsl:element name="HR"/>
</xsl:if>
</xsl:for-each>
</xsl:template>

</xsl:stylesheet>
