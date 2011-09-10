<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="equipments">
     <HTML><BODY>
                <xsl:apply-templates/>
         </BODY></HTML>
   </xsl:template>
    <xsl:template match="equipment">
         <P>Ten linh kien xuat hien o day</P>
    </xsl:template>
</xsl:stylesheet>
