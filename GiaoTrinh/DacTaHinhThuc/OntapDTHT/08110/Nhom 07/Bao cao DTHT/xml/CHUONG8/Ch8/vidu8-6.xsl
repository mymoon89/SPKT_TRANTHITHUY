<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method = "text"/>
   <xsl:template match="equipments">
        <HTML>
            <HEAD>
                <TITLE>
                    The Equipment
                </TITLE>
            </HEAD>
            <BODY>
                <H1>
                    The Equipment
                </H1>
                <xsl:apply-templates select="equipment"/>
            </BODY>
        </HTML>
    </xsl:template>
    <xsl:template match="equipment">
        <P>
            <xsl:value-of select="position()"/>.
            <xsl:value-of select="name"/>
        </P>
    </xsl:template>
</xsl:stylesheet>

