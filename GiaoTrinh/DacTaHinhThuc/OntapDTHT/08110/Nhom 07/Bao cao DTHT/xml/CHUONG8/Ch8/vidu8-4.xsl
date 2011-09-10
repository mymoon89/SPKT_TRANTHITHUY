<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/equipments">
        <HTML>
            <HEAD>
                <TITLE>
                    Equipments Information
                </TITLE>
            </HEAD>
            <BODY>
                <H1>
                    Equipment List
                </H1>
                <TABLE BORDER="1">
                    <TR>
                        <TD>Name</TD>
                        <TD>Manufacture</TD>
                        <TD>Price</TD>
                    </TR>
                    <xsl:apply-templates/>
                </TABLE>
            </BODY>
        </HTML>
    </xsl:template>

    <xsl:template match="equipment">
       <TR>
          <TD><xsl:value-of select="name"/></TD>
          <TD><xsl:apply-templates select="manufacture"/></TD>
          <TD><xsl:apply-templates select="price"/></TD>
       </TR>
   </xsl:template>
     <xsl:template match="manufacture">
        <xsl:value-of select="."/>
    </xsl:template>

    <xsl:template match="price">
        <xsl:value-of select="."/>
        <xsl:text> </xsl:text>
        <xsl:value-of select="@units"/>
    </xsl:template>

</xsl:stylesheet>

