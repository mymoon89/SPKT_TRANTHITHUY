<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="equipments">
        <HTML>
            <BODY>
                <xsl:apply-templates/>
            </BODY>
        </HTML>
    </xsl:template>

    <xsl:template match="equipment">
        <P>
            <xsl:value-of select="name"/>
        </P>
    </xsl:template>

</xsl:stylesheet>

